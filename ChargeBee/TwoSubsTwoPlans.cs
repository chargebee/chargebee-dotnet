/*
 * Copyright (c) 2012 chargebee.com
 * All Rights Reserved.
 */
using System;
using System.IO;
using System.Net;

using ChargeBee.Api;
using ChargeBee.Models;
using ChargeBee.Models.Enums;

namespace ChargeBee
{ 
	public class TwoSubsTwoPlans
	{

		public static void Main (string[] args)
		{
			ApiConfig.Proto = "http";
			ApiConfig.DomainSuffix = "localcb.com:8080";
      
			Console.WriteLine ("Testing  collect_invoice ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Invoice.Collect ("12").Request ();
				Invoice invoice = result.Invoice; 
			} catch (ApiException exp) {
				HandleCbExp ("collect_invoice", exp);
			}

			Console.WriteLine ("Testing  checkout_new_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = HostedPage.CheckoutNew ()
                  .CustomerEmail ("john@user.com")
                  .CustomerFirstName ("John")
                  .CustomerLastName ("Wayne")
                  .SubscriptionPlanId ("Plan1").Request ();
				HostedPage hostedPage = result.HostedPage; 
			} catch (ApiException exp) {
				HandleCbExp ("checkout_new_subscription", exp);
			}

			Console.WriteLine ("Testing  charge_immediately ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Invoice.Charge ()
                  .SubscriptionId ("TestSub1")
                  .Amount (1000)
                  .Description ("Support charge").Request ();
				Invoice invoice = result.Invoice; 
			} catch (ApiException exp) {
				HandleCbExp ("charge_immediately", exp);
			}

			Console.WriteLine ("Testing  update_card_for_a_customer ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Card.UpdateCardForCustomer ("TestSub1")
                  .Gateway (GatewayEnum.Chargebee)
                  .FirstName ("Richard")
                  .LastName ("Fox")
                  .Number ("4012888888881881")
                  .ExpiryMonth (10)
                  .ExpiryYear (2015)
                  .Cvv ("999").Request ();
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("update_card_for_a_customer", exp);
			}

			Console.WriteLine ("Testing  update_a_customer ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Customer.Update ("TestSub1")
                  .FirstName ("Denise")
                  .LastName ("Barone").Request ();
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("update_a_customer", exp);
			}

			Console.WriteLine ("Testing  add_charge_to_invoice ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Invoice.AddCharge ("12")
                  .Amount (150)
                  .Description ("$0.05 each for 30 messages").Request ();
				Invoice invoice = result.Invoice; 
			} catch (ApiException exp) {
				HandleCbExp ("add_charge_to_invoice", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_offline_checkout ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = OfflineCheckout.Retrieve ("__dev__ixpmp3J9xZS2ols1CJtoZlNIBt99d0XX").Request ();
				OfflineCheckout offlineCheckout = result.OfflineCheckout; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_offline_checkout", exp);
			}

			Console.WriteLine ("Testing  list_plans ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Plan.List ()
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Plan plan = item.Plan;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_plans", exp);
			}

			Console.WriteLine ("Testing  checkout_onetime_addons ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = HostedPage.CheckoutOnetimeAddons ()
                  .SubscriptionId ("TestSub1")
                  .AddonId (1, "data_usage").Request ();
				HostedPage hostedPage = result.HostedPage; 
			} catch (ApiException exp) {
				HandleCbExp ("checkout_onetime_addons", exp);
			}

			Console.WriteLine ("Testing  list_events ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Event.List ()
                      .Limit (5)
                      .StartTime (1349029800)
                      .EndTime (1349116200).Request ();
				foreach (var item in result.List) {
					Event evt = item.Event;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_events", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_hosted_page ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = HostedPage.Retrieve ("__dev__2luk1v58rBnhotswSWWjkiMFXMLEfAJF").Request ();
				HostedPage hostedPage = result.HostedPage; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_hosted_page", exp);
			}

			Console.WriteLine ("Testing  list_subscriptions ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Subscription.List ()
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Subscription subscription = item.Subscription;
					Customer customer = item.Customer;
					Card card = item.Card;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_subscriptions", exp);
			}

			Console.WriteLine ("Testing  list_invoices_for_a_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Invoice.InvoicesForSubscription ("TestSub1")
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Invoice invoice = item.Invoice;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_invoices_for_a_subscription", exp);
			}

			Console.WriteLine ("Testing  post_register ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = OfflineCheckout.PostRegister ("__dev__ixpmp3J9xZS2ols1CJtoZlNIBt99d0XX")
                  .Succeeded (true).Request ();
				OfflineCheckout offlineCheckout = result.OfflineCheckout; 
			} catch (ApiException exp) {
				HandleCbExp ("post_register", exp);
			}

			Console.WriteLine ("Testing  update_an_address ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Address.Update ()
                  .SubscriptionId ("TestSub1")
                  .Label ("shipping_address")
                  .FirstName ("Benjamin")
                  .LastName ("Ross")
                  .Addr ("340 S LEMON AVE #1537")
                  .City ("Walnut")
                  .State ("CA")
                  .Zip ("91789")
                  .Country ("United States").Request ();
				Address address = result.Address; 
			} catch (ApiException exp) {
				HandleCbExp ("update_an_address", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_customer ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Customer.Retrieve ("TestSub1").Request ();
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_customer", exp);
			}

			Console.WriteLine ("Testing  list_transactions ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Transaction.List ()
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Transaction transaction = item.Transaction;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_transactions", exp);
			}

			Console.WriteLine ("Testing  pre_register ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = OfflineCheckout.PreRegister ()
                  .CustomerEmail ("john@user.com")
                  .SubscriptionPlanId ("no_trial").Request ();
				OfflineCheckout offlineCheckout = result.OfflineCheckout; 
			} catch (ApiException exp) {
				HandleCbExp ("pre_register", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_card ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Card.Retrieve ("TestSub1").Request ();
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_card", exp);
			}

			Console.WriteLine ("Testing  add_addon_charge_to_invoice ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Invoice.AddAddonCharge ("12")
                  .AddonId ("data_usage").Request ();
				Invoice invoice = result.Invoice; 
			} catch (ApiException exp) {
				HandleCbExp ("add_addon_charge_to_invoice", exp);
			}

			Console.WriteLine ("Testing  cancel_a_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Subscription.Cancel ("TestSub1").Request ();
				Subscription subscription = result.Subscription;
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("cancel_a_subscription", exp);
			}

			Console.WriteLine ("Testing  update_subscription_estimate ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Estimate.UpdateSubscription ()
                  .SubscriptionId ("TestSub1")
                  .SubscriptionPlanId ("Plan1").Request ();
				Estimate estimate = result.Estimate; 
			} catch (ApiException exp) {
				HandleCbExp ("update_subscription_estimate", exp);
			}

			Console.WriteLine ("Testing  retrieve_an_invoice ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Invoice.Retrieve ("3").Request ();
				Invoice invoice = result.Invoice; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_an_invoice", exp);
			}

			Console.WriteLine ("Testing  list_addons ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Addon.List ()
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Addon addon = item.Addon;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_addons", exp);
			}

			Console.WriteLine ("Testing  list_transactions_for_a_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Transaction.TransactionsForSubscription ("TestSub1")
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Transaction transaction = item.Transaction;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_transactions_for_a_subscription", exp);
			}

			Console.WriteLine ("Testing  update_card ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = HostedPage.UpdateCard ()
                  .CustomerId ("TestSub1").Request ();
				HostedPage hostedPage = result.HostedPage; 
			} catch (ApiException exp) {
				HandleCbExp ("update_card", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_transaction ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Transaction.Retrieve ("txn___dev__KyVqETO1N1FoG3j").Request ();
				Transaction transaction = result.Transaction; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_transaction", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_plan ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Plan.Retrieve ("Plan1").Request ();
				Plan plan = result.Plan; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_plan", exp);
			}

			Console.WriteLine ("Testing  create_a_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Subscription.Create ()
                  .PlanId ("Plan1")
                  .CustomerEmail ("john@user.com")
                  .CustomerFirstName ("John")
                  .CustomerLastName ("Wayne").Request ();
				Subscription subscription = result.Subscription;
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("create_a_subscription", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_event ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Event.Retrieve ("ev___dev__8avOpNy5AJLg4").Request ();
				Event evt = result.Event; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_event", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_addon ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Addon.Retrieve ("data_usage").Request ();
				Addon addon = result.Addon; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_addon", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Subscription.Retrieve ("TestSub1").Request ();
				Subscription subscription = result.Subscription;
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_subscription", exp);
			}

			Console.WriteLine ("Testing  list_customers ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Customer.List ()
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Customer customer = item.Customer;
					Card card = item.Card;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_customers", exp);
			}

			Console.WriteLine ("Testing  retrieve_a_coupon ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Coupon.Retrieve ("beta").Request ();
				Coupon coupon = result.Coupon; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_a_coupon", exp);
			}

			Console.WriteLine ("Testing  retrieve_an_address ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Address.Retrieve ()
                  .SubscriptionId ("TestSub1")
                  .Label ("shipping_address").Request ();
				Address address = result.Address; 
			} catch (ApiException exp) {
				HandleCbExp ("retrieve_an_address", exp);
			}

			Console.WriteLine ("Testing  reactivate_a_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Subscription.Reactivate ("TestSub1").Request ();
				Subscription subscription = result.Subscription;
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("reactivate_a_subscription", exp);
			}

			Console.WriteLine ("Testing  checkout_onetime_charge ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = HostedPage.CheckoutOnetimeCharge ()
                  .Amount (1000)
                  .Description ("Support charge")
                  .SubscriptionId ("TestSub1").Request ();
				HostedPage hostedPage = result.HostedPage; 
			} catch (ApiException exp) {
				HandleCbExp ("checkout_onetime_charge", exp);
			}

			Console.WriteLine ("Testing  list_coupons ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Coupon.List ()
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Coupon coupon = item.Coupon;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_coupons", exp);
			}

			Console.WriteLine ("Testing  checkout_existing_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = HostedPage.CheckoutExisting ()
                  .SubscriptionId ("TestSub1")
                  .SubscriptionPlanId ("Plan1").Request ();
				HostedPage hostedPage = result.HostedPage; 
			} catch (ApiException exp) {
				HandleCbExp ("checkout_existing_subscription", exp);
			}

			Console.WriteLine ("Testing  list_invoices ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				ListResult result = Invoice.List ()
                      .Limit (1).Request ();
				foreach (var item in result.List) {
					Invoice invoice = item.Invoice;
				} 
			} catch (ApiException exp) {
				HandleCbExp ("list_invoices", exp);
			}

			Console.WriteLine ("Testing  create_subscription_estimate ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Estimate.CreateSubscription ()
                  .SubscriptionPlanId ("Plan1").Request ();
				Estimate estimate = result.Estimate; 
			} catch (ApiException exp) {
				HandleCbExp ("create_subscription_estimate", exp);
			}

			Console.WriteLine ("Testing  charge_a_addon_immediately ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Invoice.ChargeAddon ()
                  .SubscriptionId ("TestSub1")
                  .AddonId ("data_usage").Request ();
				Invoice invoice = result.Invoice; 
			} catch (ApiException exp) {
				HandleCbExp ("charge_a_addon_immediately", exp);
			}

			Console.WriteLine ("Testing  update_a_subscription ");
			try {
            

				ApiConfig.Configure ("mannar-test", "__dev__eGY6Zt4ioEQIWRIXTzAjxYoO6Z6xeGVC");
				EntityResult result = Subscription.Update ("TestSub1")
                  .PlanId ("Plan2").Request ();
				Subscription subscription = result.Subscription;
				Customer customer = result.Customer;
				Card card = result.Card; 
			} catch (ApiException exp) {
				HandleCbExp ("update_a_subscription", exp);
			}

		}

		private static void HandleCbExp (string id, ApiException exp)
		{
			if (exp.HttpCode == HttpStatusCode.InternalServerError) {
				throw exp;
			}
			Console.WriteLine ("Operation error for id {0}. Reason: {1}", id, exp.ApiCode);
		}


	}

}