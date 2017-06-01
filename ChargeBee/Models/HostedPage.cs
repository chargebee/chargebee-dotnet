using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

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
        [Obsolete]
        public static UpdateCardRequest UpdateCard()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "update_card");
            return new UpdateCardRequest(url, HttpMethod.POST);
        }
        public static UpdatePaymentMethodRequest UpdatePaymentMethod()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "update_payment_method");
            return new UpdatePaymentMethodRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Acknowledge(string id)
        {
            string url = ApiUtil.BuildUrl("hosted_pages", CheckNull(id), "acknowledge");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("hosted_pages", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static HostedPageListRequest List()
        {
            string url = ApiUtil.BuildUrl("hosted_pages");
            return new HostedPageListRequest(url);
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
        [Obsolete]
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
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public JToken CheckoutInfo 
        {
            get { return GetJToken("checkout_info", false); }
        }
        public HostedPageContent Content
        {
            get
            {
                if(GetValue<JToken>("content", false) == null)
                {
                    return null;
                }
                return new HostedPageContent(GetValue<JToken>("content"));
            }
        }
        #endregion
        
        #region Requests
        public class CheckoutNewRequest : EntityRequest<CheckoutNewRequest> 
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
            public CheckoutNewRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CheckoutNewRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutNewRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
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
            public CheckoutNewRequest IframeMessaging(bool iframeMessaging) 
            {
                m_params.AddOpt("iframe_messaging", iframeMessaging);
                return this;
            }
            public CheckoutNewRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CheckoutNewRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
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
            public CheckoutNewRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CheckoutNewRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
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
            public CheckoutNewRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CheckoutNewRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
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
            public CheckoutNewRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public CheckoutNewRequest SubscriptionInvoiceNotes(string subscriptionInvoiceNotes) 
            {
                m_params.AddOpt("subscription[invoice_notes]", subscriptionInvoiceNotes);
                return this;
            }
            [Obsolete]
            public CheckoutNewRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutNewRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            [Obsolete]
            public CheckoutNewRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutNewRequest CustomerConsolidatedInvoicing(bool customerConsolidatedInvoicing) 
            {
                m_params.AddOpt("customer[consolidated_invoicing]", customerConsolidatedInvoicing);
                return this;
            }
            public CheckoutNewRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CheckoutNewRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CheckoutNewRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CheckoutNewRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CheckoutNewRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CheckoutNewRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CheckoutNewRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CheckoutNewRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CheckoutNewRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CheckoutNewRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CheckoutNewRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CheckoutNewRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CheckoutNewRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CheckoutNewRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CheckoutNewRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CheckoutNewRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CheckoutNewRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CheckoutNewRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CheckoutNewRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CheckoutNewRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CheckoutNewRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CheckoutNewRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CheckoutNewRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CheckoutNewRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CheckoutNewRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CheckoutNewRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CheckoutNewRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CheckoutNewRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
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
            public CheckoutNewRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
        }
        public class CheckoutExistingRequest : EntityRequest<CheckoutExistingRequest> 
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
            public CheckoutExistingRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CheckoutExistingRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public CheckoutExistingRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public CheckoutExistingRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public CheckoutExistingRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutExistingRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
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
            public CheckoutExistingRequest IframeMessaging(bool iframeMessaging) 
            {
                m_params.AddOpt("iframe_messaging", iframeMessaging);
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
            public CheckoutExistingRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CheckoutExistingRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
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
            public CheckoutExistingRequest SubscriptionInvoiceNotes(string subscriptionInvoiceNotes) 
            {
                m_params.AddOpt("subscription[invoice_notes]", subscriptionInvoiceNotes);
                return this;
            }
            [Obsolete]
            public CheckoutExistingRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            [Obsolete]
            public CheckoutExistingRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutExistingRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
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
            public CheckoutExistingRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
        }
        public class UpdateCardRequest : EntityRequest<UpdateCardRequest> 
        {
            public UpdateCardRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateCardRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public UpdateCardRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
                return this;
            }
            public UpdateCardRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public UpdateCardRequest Embed(bool embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
            public UpdateCardRequest IframeMessaging(bool iframeMessaging) 
            {
                m_params.AddOpt("iframe_messaging", iframeMessaging);
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
            [Obsolete]
            public UpdateCardRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public UpdateCardRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
        }
        public class UpdatePaymentMethodRequest : EntityRequest<UpdatePaymentMethodRequest> 
        {
            public UpdatePaymentMethodRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdatePaymentMethodRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public UpdatePaymentMethodRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
                return this;
            }
            public UpdatePaymentMethodRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public UpdatePaymentMethodRequest Embed(bool embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
            public UpdatePaymentMethodRequest IframeMessaging(bool iframeMessaging) 
            {
                m_params.AddOpt("iframe_messaging", iframeMessaging);
                return this;
            }
            public UpdatePaymentMethodRequest CustomerId(string customerId) 
            {
                m_params.Add("customer[id]", customerId);
                return this;
            }
            [Obsolete]
            public UpdatePaymentMethodRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            [Obsolete]
            public UpdatePaymentMethodRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public UpdatePaymentMethodRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
        }
        public class HostedPageListRequest : ListRequestBase<HostedPageListRequest> 
        {
            public HostedPageListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<HostedPageListRequest> Id() 
            {
                return new StringFilter<HostedPageListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<HostedPage.TypeEnum, HostedPageListRequest> Type() 
            {
                return new EnumFilter<HostedPage.TypeEnum, HostedPageListRequest>("type", this);        
            }
            public EnumFilter<HostedPage.StateEnum, HostedPageListRequest> State() 
            {
                return new EnumFilter<HostedPage.StateEnum, HostedPageListRequest>("state", this);        
            }
            public TimestampFilter<HostedPageListRequest> UpdatedAt() 
            {
                return new TimestampFilter<HostedPageListRequest>("updated_at", this);        
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
            [Obsolete]
            UpdateCard,
            [Description("update_payment_method")]
            UpdatePaymentMethod,

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
            [Obsolete]
            Failed,
            [Description("acknowledged")]
            Acknowledged,

        }
        [Obsolete]
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
