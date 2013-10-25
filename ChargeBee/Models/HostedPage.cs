using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;

namespace ChargeBee.Models
{

    public class HostedPage : Resource 
    {
    

        #region Methods
        public static CheckoutNewRequest CheckoutNew()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_new");
            return new CheckoutNewRequest(url, HttpMethod.POST);
        }
        public static CheckoutExistingRequest CheckoutExisting()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_existing");
            return new CheckoutExistingRequest(url, HttpMethod.POST);
        }
        public static UpdateCardRequest UpdateCard()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "update_card");
            return new UpdateCardRequest(url, HttpMethod.POST);
        }
        public static CheckoutOnetimeChargeRequest CheckoutOnetimeCharge()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_onetime_charge");
            return new CheckoutOnetimeChargeRequest(url, HttpMethod.POST);
        }
        public static CheckoutOnetimeAddonsRequest CheckoutOnetimeAddons()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_onetime_addons");
            return new CheckoutOnetimeAddonsRequest(url, HttpMethod.POST);
        }
        public static EntityRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("hosted_pages", CheckNull(id));
            return new EntityRequest(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public TypeEnum? HostedPageType 
        {
            get { return GetEnum<TypeEnum>("type", false); }
        }
        public string Url 
        {
            get { return GetValue<string>("url", false); }
        }
        public StateEnum? State 
        {
            get { return GetEnum<StateEnum>("state", false); }
        }
        public FailureReasonEnum? FailureReason 
        {
            get { return GetEnum<FailureReasonEnum>("failure_reason", false); }
        }
        public string PassThruContent 
        {
            get { return GetValue<string>("pass_thru_content", false); }
        }
        public bool Embed 
        {
            get { return GetValue<bool>("embed", true); }
        }
        public DateTime? CreatedAt 
        {
            get { return GetDateTime("created_at", false); }
        }
        public DateTime? ExpiresAt 
        {
            get { return GetDateTime("expires_at", false); }
        }

        public HostedPageContent Content
        {
            get { return new HostedPageContent(GetValue<JToken>("content")); }
        }
        #endregion
        
        #region Requests
        public class CheckoutNewRequest : EntityRequest 
        {
            public CheckoutNewRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutNewRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CheckoutNewRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutNewRequest Embed(bool embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
            public CheckoutNewRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CheckoutNewRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public CheckoutNewRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public CheckoutNewRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public CheckoutNewRequest CustomerCompany(string customerCompany) 
            {
                m_params.AddOpt("customer[company]", customerCompany);
                return this;
            }
            public CheckoutNewRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CheckoutNewRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CheckoutNewRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CheckoutNewRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CheckoutNewRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CheckoutNewRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CheckoutNewRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            [Obsolete]
            public CheckoutNewRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutNewRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CheckoutNewRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        public class CheckoutExistingRequest : EntityRequest 
        {
            public CheckoutExistingRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutExistingRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CheckoutExistingRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public CheckoutExistingRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutExistingRequest Embed(bool embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
            public CheckoutExistingRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public CheckoutExistingRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CheckoutExistingRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CheckoutExistingRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CheckoutExistingRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CheckoutExistingRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            [Obsolete]
            public CheckoutExistingRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutExistingRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutExistingRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CheckoutExistingRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        public class UpdateCardRequest : EntityRequest 
        {
            public UpdateCardRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateCardRequest Embed(bool embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
            public UpdateCardRequest CustomerId(string customerId) 
            {
                m_params.Add("customer[id]", customerId);
                return this;
            }
            [Obsolete]
            public UpdateCardRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateCardRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
        }
        public class CheckoutOnetimeChargeRequest : EntityRequest 
        {
            public CheckoutOnetimeChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutOnetimeChargeRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public CheckoutOnetimeChargeRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public CheckoutOnetimeChargeRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutOnetimeChargeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public CheckoutOnetimeChargeRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
        }
        public class CheckoutOnetimeAddonsRequest : EntityRequest 
        {
            public CheckoutOnetimeAddonsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutOnetimeAddonsRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CheckoutOnetimeAddonsRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutOnetimeAddonsRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public CheckoutOnetimeAddonsRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutOnetimeAddonsRequest AddonId(int index, string addonId) 
            {
                m_params.Add("addons[id][" + index + "]", addonId);
                return this;
            }
            public CheckoutOnetimeAddonsRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("checkout_new")]
            CheckoutNew,
            [Description("checkout_existing")]
            CheckoutExisting,
            [Description("update_card")]
            UpdateCard,
            [Description("checkout_onetime_charge")]
            CheckoutOnetimeCharge,
            [Description("checkout_onetime_addons")]
            CheckoutOnetimeAddons,

        }
        public enum StateEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("created")]
            Created,
            [Description("requested")]
            Requested,
            [Description("succeeded")]
            Succeeded,
            [Description("cancelled")]
            Cancelled,
            [Description("failed")]
            Failed,

        }
        public enum FailureReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("card_error")]
            CardError,
            [Description("server_error")]
            ServerError,

        }

        #region Subclasses

        public class HostedPageContent : ResultBase
        {

            public HostedPageContent () { }

            internal HostedPageContent(JToken jobj)
            {
                m_jobj = jobj;
            }
        }
        #endregion
    }
}
