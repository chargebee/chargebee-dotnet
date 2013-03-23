using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

using NUnit.Framework;

using ChargeBee.Api;
using ChargeBee.Models;
using ChargeBee.Models.Enums;

namespace ChargeBee.Test
{
    [TestFixture]
    public class ApiTest
    {
        [SetUp]
        public void Configure()
        {
			ApiConfig.Proto = "http";
			ApiConfig.DomainSuffix = "localcb.com:8080";
			ApiConfig.Configure("mannar-test", "__dev__FhJgi9KugVCv9yO8zosAFC11lYCEAufI");
        }

        /*[Test]
        public void TestConfig()
        {
            Assert.AreEqual("https://guidebot-test.chargebee.com/api/v1", ApiConfig.Instance.ApiBaseUrl);
        }*/

        [Test]
        public void TestStatusCode()
        {
            ListResult result = Event.List().Request();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void TestListEvents()
        {
            ListResult result = Event.List().Request();

            foreach (var item in result.List)
            {
                Event evnt = item.Event;

                Assert.NotNull(evnt);
                Assert.NotNull(evnt.Id);

                Subscription subs = evnt.Content.Subscription;

                Assert.NotNull(subs);
                Assert.NotNull(subs.Id);
            }
        }

        [Test]
        public void TestListEventsOffset()
        {
            ListResult result1 = Event.List().Limit(1).Request();
            Assert.AreEqual(1, result1.List.Count);

            ListResult result2 = Event.List().Limit(1).Offset(result1.NextOffset).Request();
            Assert.AreEqual(1, result2.List.Count);

            Assert.AreNotEqual(result1.List[0].Event.Id, result2.List[0].Event.Id);
        }

        [Test]
        public void TestRetrieveEvent()
        {
            ListResult list = Event.List().Limit(1).Request();
            Assert.AreEqual(1, list.List.Count);

            Event eventFromList = list.List[0].Event;

            EventTypeEnum? type = eventFromList.EventType;
            Assert.NotNull(type);

            EntityResult result = Event.Retrieve(eventFromList.Id).Request();
            Event retrievedEvent = result.Event;
            Assert.AreEqual(eventFromList.Id, retrievedEvent.Id);
            Assert.AreEqual(eventFromList.OccurredAt, retrievedEvent.OccurredAt);
            Assert.AreEqual(eventFromList.Content.ToString(), retrievedEvent.Content.ToString());
        }

        [Test]
        [ExpectedException(
            ExpectedException = typeof(ApiException),
            ExpectedMessage = "Sorry, we couldn't find that resource")]
        public void TestRetrieveEventNotFound()
        {
            EntityResult result = Event.Retrieve("not_existent_id").Request();
        }

        [Test]
        public void TestCreateSubscription()
        {
            string planId = "enterprise_half_yearly";

            EntityResult result = Subscription.Create()
                              .PlanId(planId)
                              .CustomerEmail("john@user.com")
                              .CustomerFirstName("John")
                              .CustomerLastName("Wayne")
                              .AddonId(1, "on_call_support").Request();

            Subscription subs = result.Subscription;
            Assert.NotNull(subs);
            Assert.AreEqual(planId, subs.PlanId);
        }

        [Test]
        public void TestListSubscriptions()
        {
            ListResult result = Subscription.List().Request();

            foreach (var item in result.List)
            {
                Subscription subs = item.Subscription;

                Assert.NotNull(subs);
                Assert.NotNull(subs.Id);
            }
        }

        [Test]
        public void TestRetrieveSubscriptions()
        {
            EntityResult result = Subscription.Create().PlanId("enterprise_half_yearly").Request();
            Subscription subs1 = result.Subscription;
            Assert.NotNull(subs1);

            result = Subscription.Retrieve(subs1.Id).Request();
            Subscription subs2 = result.Subscription;
            Assert.NotNull(subs2);

            Assert.AreEqual(subs1.Status, subs2.Status);
        }

        [Test]
        public void TestUpdateSubscription()
        {
            EntityResult result = Subscription.Create().PlanId("enterprise_half_yearly").Request();
            Subscription subs1 = result.Subscription;
            Assert.NotNull(subs1);
            Assert.AreNotEqual("basic", subs1.PlanId);

            result = Subscription.Update(subs1.Id)
                .PlanId("basic")
                .AddonId(1, "on_call_support")
                .CardGateway(GatewayEnum.PaypalPro)
                .Request();

            Subscription subs2 = result.Subscription;
            Assert.NotNull(subs2);
            Assert.AreEqual("basic", subs2.PlanId);

            List<Subscription.SubscriptionAddon> addons = subs2.Addons;
            Assert.NotNull(addons);
        }

        [Test]
        public void TestCancelSubscription()
        {
            EntityResult result = Subscription.Create().PlanId("enterprise_half_yearly").Request();
            Subscription subs1 = result.Subscription;
            Assert.NotNull(subs1);

            result = Subscription.Cancel(subs1.Id).Request();

            Subscription subs2 = result.Subscription;
            Assert.NotNull(subs2);
            Assert.IsTrue(DateTime.Now.AddMinutes(-5) < subs2.CancelledAt &&
                DateTime.Now.AddMinutes(5) > subs2.CancelledAt);
        }

        [Test]
        [ExpectedException(
            ExpectedException = typeof(ApiException),
            ExpectedMessage = "Cannot re-activate subscription as there is no active credit card on file")]
        public void TestReactivateSubscriptionError()
        {
            EntityResult result = Subscription.Create().PlanId("enterprise_half_yearly").Request();
            Subscription subs = result.Subscription;
            result = Subscription.Cancel(subs.Id).Request();
            result = Subscription.Reactivate(subs.Id).
                TrialEnd(DateTime.Now.AddDays(5)).Request();
        }

        [Test]
        public void TestEventCtor()
        {
            string s = "{\"id\": \"ev_HwqE2wPNy5PuFEcd\",\"occurred_at\": 1361453444,\"webhook_status\": \"not_configured\",\"object\": \"event\",\"content\": {\"subscription\": {\"id\": \"HwqE2wPNy5PuEycb\",\"plan_id\": \"enterprise_half_yearly\",\"plan_quantity\": 1,\"status\": \"in_trial\",\"trial_start\": 1361453444,\"trial_end\": 1364045444,\"created_at\": 1361453444,\"due_invoices_count\": 0,\"object\": \"subscription\"},\"customer\": {\"id\": \"HwqE2wPNy5PuEycb\",\"created_at\": 1361453444,\"object\": \"customer\",\"card_status\": \"no_card\"}},\"event_type\": \"subscription_created\"}";

            using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(s)))
            {
                Event evnt = new Event(ms);
                Assert.AreEqual("ev_HwqE2wPNy5PuFEcd", evnt.Id);
                Assert.AreEqual(
                    DateTime.ParseExact("2013-02-21 17:30:44", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    evnt.OccurredAt);
            }
        }

        [Test]
        public void TestHostedPageCheckoutNew()
        {
            EntityResult result = HostedPage.CheckoutNew()
                              .CustomerEmail("john@user.com")
                              .CustomerFirstName("John")
                              .CustomerLastName("Wayne")
                              .SubscriptionPlanId("enterprise_half_yearly")
                              .AddonId(1, "on_call_support").Request();

            HostedPage hostedPage = result.HostedPage;
            Assert.NotNull(hostedPage);
        }

        [Test]
        public void TestHostedPageCheckoutExisting()
        {
            EntityResult result = HostedPage.CheckoutExisting()
                  .SubscriptionId("HoR7OsYNy5YBOlyn")
                  .SubscriptionPlanId("enterprise_half_yearly")
                  .AddonId(1, "on_call_support").Request();

            HostedPage hostedPage = result.HostedPage;
            Assert.NotNull(hostedPage);
        }

        [Test]
        public void TestUpdateCard()
        {
            EntityResult result = HostedPage.UpdateCard()
                  .CustomerId("HoR7OsYNy5YBOlyn").Request();

            HostedPage hostedPage = result.HostedPage;
            Assert.NotNull(hostedPage);
        }

        [Test]
        [ExpectedException(
            ExpectedException = typeof(ApiException),
            ExpectedMessage = "This operation is not supported for ChargeBee gateway")]
        public void TestCheckoutOnetimeCharge()
        {
            EntityResult result = HostedPage.CheckoutOnetimeCharge()
                  .Amount(1000)
                  .Description("Support charge")
                  .SubscriptionId("HoR7OsYNy5YBOlyn").Request();
        }

        [Test]
        [ExpectedException(
            ExpectedException = typeof(ApiException),
            ExpectedMessage = "This operation is not supported for ChargeBee gateway")]
        public void TestCheckoutOnetimeAddons()
        {
            EntityResult result = HostedPage.CheckoutOnetimeAddons()
                  .SubscriptionId("HoR7OsYNy5YBOlyn")
                  .AddonId(1, "one-off_consulting_support")
                  .AddonQuantity(1, 2).Request();

            HostedPage hostedPage = result.HostedPage;
        }

        [Test]
        public void TestRetrieveHostedPage()
        {
            EntityResult result = HostedPage.CheckoutNew()
                              .CustomerEmail("john@user.com")
                              .CustomerFirstName("John")
                              .CustomerLastName("Wayne")
                              .SubscriptionPlanId("enterprise_half_yearly")
                              .AddonId(1, "on_call_support").Request();

            HostedPage hostedPage1 = result.HostedPage;
            Assert.NotNull(hostedPage1);

            result = HostedPage.Retrieve(hostedPage1.Id).Request();

            HostedPage hostedPage2 = result.HostedPage;
            Assert.NotNull(hostedPage2);

            Assert.AreEqual(hostedPage2.Url, hostedPage2.Url);
        }
    }
}
