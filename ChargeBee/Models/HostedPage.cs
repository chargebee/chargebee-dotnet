using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    
        public HostedPage() { }

        public HostedPage(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public HostedPage(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public HostedPage(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CheckoutNewRequest CheckoutNew()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_new");
            return new CheckoutNewRequest(url, HttpMethod.POST);
        }
        public static CheckoutOneTimeRequest CheckoutOneTime()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_one_time");
            return new CheckoutOneTimeRequest(url, HttpMethod.POST);
        }
        public static CheckoutOneTimeForItemsRequest CheckoutOneTimeForItems()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_one_time_for_items");
            return new CheckoutOneTimeForItemsRequest(url, HttpMethod.POST);
        }
        public static CheckoutNewForItemsRequest CheckoutNewForItems()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_new_for_items");
            return new CheckoutNewForItemsRequest(url, HttpMethod.POST);
        }
        public static CheckoutExistingRequest CheckoutExisting()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_existing");
            return new CheckoutExistingRequest(url, HttpMethod.POST);
        }
        public static CheckoutExistingForItemsRequest CheckoutExistingForItems()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_existing_for_items");
            return new CheckoutExistingForItemsRequest(url, HttpMethod.POST);
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
        public static ManagePaymentSourcesRequest ManagePaymentSources()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "manage_payment_sources");
            return new ManagePaymentSourcesRequest(url, HttpMethod.POST);
        }
        public static CollectNowRequest CollectNow()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "collect_now");
            return new CollectNowRequest(url, HttpMethod.POST);
        }
        public static AcceptQuoteRequest AcceptQuote()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "accept_quote");
            return new AcceptQuoteRequest(url, HttpMethod.POST);
        }
        public static ExtendSubscriptionRequest ExtendSubscription()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "extend_subscription");
            return new ExtendSubscriptionRequest(url, HttpMethod.POST);
        }
        public static CheckoutGiftRequest CheckoutGift()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_gift");
            return new CheckoutGiftRequest(url, HttpMethod.POST);
        }
        public static CheckoutGiftForItemsRequest CheckoutGiftForItems()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "checkout_gift_for_items");
            return new CheckoutGiftForItemsRequest(url, HttpMethod.POST);
        }
        public static ClaimGiftRequest ClaimGift()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "claim_gift");
            return new ClaimGiftRequest(url, HttpMethod.POST);
        }
        public static RetrieveAgreementPdfRequest RetrieveAgreementPdf()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "retrieve_agreement_pdf");
            return new RetrieveAgreementPdfRequest(url, HttpMethod.POST);
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
        public static PreCancelRequest PreCancel()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "pre_cancel");
            return new PreCancelRequest(url, HttpMethod.POST);
        }
        public static EventsRequest Events()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "events");
            return new EventsRequest(url, HttpMethod.POST);
        }
        public static ViewVoucherRequest ViewVoucher()
        {
            string url = ApiUtil.BuildUrl("hosted_pages", "view_voucher");
            return new ViewVoucherRequest(url, HttpMethod.POST);
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
            get { return GetValue<bool>("embed", false); }
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
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
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
            public CheckoutNewRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public CheckoutNewRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CheckoutNewRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CheckoutNewRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
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
            public CheckoutNewRequest AllowOfflinePaymentMethods(bool allowOfflinePaymentMethods) 
            {
                m_params.AddOpt("allow_offline_payment_methods", allowOfflinePaymentMethods);
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
            public CheckoutNewRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CheckoutNewRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public CheckoutNewRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
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
            public CheckoutNewRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public CheckoutNewRequest SubscriptionPlanUnitPrice(long subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CheckoutNewRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
                return this;
            }
            public CheckoutNewRequest SubscriptionSetupFee(long subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CheckoutNewRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CheckoutNewRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            [Obsolete]
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
            public CheckoutNewRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
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
            public CheckoutNewRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutNewRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
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
            public CheckoutNewRequest SubscriptionAffiliateToken(string subscriptionAffiliateToken) 
            {
                m_params.AddOpt("subscription[affiliate_token]", subscriptionAffiliateToken);
                return this;
            }
            public CheckoutNewRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CheckoutNewRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CheckoutNewRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
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
            public CheckoutNewRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CheckoutNewRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CheckoutNewRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CheckoutNewRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CheckoutNewRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
        }
        public class CheckoutOneTimeRequest : EntityRequest<CheckoutOneTimeRequest> 
        {
            public CheckoutOneTimeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutOneTimeRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CheckoutOneTimeRequest InvoiceNote(string invoiceNote) 
            {
                m_params.AddOpt("invoice_note", invoiceNote);
                return this;
            }
            [Obsolete]
            public CheckoutOneTimeRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CheckoutOneTimeRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CheckoutOneTimeRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutOneTimeRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
                return this;
            }
            public CheckoutOneTimeRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutOneTimeRequest Embed(bool embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
            public CheckoutOneTimeRequest IframeMessaging(bool iframeMessaging) 
            {
                m_params.AddOpt("iframe_messaging", iframeMessaging);
                return this;
            }
            public CheckoutOneTimeRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public CheckoutOneTimeRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public CheckoutOneTimeRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public CheckoutOneTimeRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public CheckoutOneTimeRequest CustomerCompany(string customerCompany) 
            {
                m_params.AddOpt("customer[company]", customerCompany);
                return this;
            }
            public CheckoutOneTimeRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CheckoutOneTimeRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public CheckoutOneTimeRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CheckoutOneTimeRequest InvoicePoNumber(string invoicePoNumber) 
            {
                m_params.AddOpt("invoice[po_number]", invoicePoNumber);
                return this;
            }
            [Obsolete]
            public CheckoutOneTimeRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutOneTimeRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            public CheckoutOneTimeRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutOneTimeRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public CheckoutOneTimeRequest CustomerConsolidatedInvoicing(bool customerConsolidatedInvoicing) 
            {
                m_params.AddOpt("customer[consolidated_invoicing]", customerConsolidatedInvoicing);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CheckoutOneTimeRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CheckoutOneTimeRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CheckoutOneTimeRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CheckoutOneTimeRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CheckoutOneTimeRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CheckoutOneTimeRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CheckoutOneTimeRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CheckoutOneTimeRequest AddonDateFrom(int index, long addonDateFrom) 
            {
                m_params.AddOpt("addons[date_from][" + index + "]", addonDateFrom);
                return this;
            }
            public CheckoutOneTimeRequest AddonDateTo(int index, long addonDateTo) 
            {
                m_params.AddOpt("addons[date_to][" + index + "]", addonDateTo);
                return this;
            }
            public CheckoutOneTimeRequest ChargeAmount(int index, long chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CheckoutOneTimeRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CheckoutOneTimeRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CheckoutOneTimeRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CheckoutOneTimeRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CheckoutOneTimeRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CheckoutOneTimeRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CheckoutOneTimeRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CheckoutOneTimeRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CheckoutOneTimeRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CheckoutOneTimeRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CheckoutOneTimeRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CheckoutOneTimeRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
        }
        public class CheckoutOneTimeForItemsRequest : EntityRequest<CheckoutOneTimeForItemsRequest> 
        {
            public CheckoutOneTimeForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutOneTimeForItemsRequest BusinessEntityId(string businessEntityId) 
            {
                m_params.AddOpt("business_entity_id", businessEntityId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest Layout(ChargeBee.Models.Enums.LayoutEnum layout) 
            {
                m_params.AddOpt("layout", layout);
                return this;
            }
            public CheckoutOneTimeForItemsRequest InvoiceNote(string invoiceNote) 
            {
                m_params.AddOpt("invoice_note", invoiceNote);
                return this;
            }
            [Obsolete]
            public CheckoutOneTimeForItemsRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CheckoutOneTimeForItemsRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
                return this;
            }
            public CheckoutOneTimeForItemsRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerCompany(string customerCompany) 
            {
                m_params.AddOpt("customer[company]", customerCompany);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CheckoutOneTimeForItemsRequest InvoicePoNumber(string invoicePoNumber) 
            {
                m_params.AddOpt("invoice[po_number]", invoicePoNumber);
                return this;
            }
            [Obsolete]
            public CheckoutOneTimeForItemsRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerEinvoicingMethod(ChargeBee.Models.Enums.EinvoicingMethodEnum customerEinvoicingMethod) 
            {
                m_params.AddOpt("customer[einvoicing_method]", customerEinvoicingMethod);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerIsEinvoiceEnabled(bool customerIsEinvoiceEnabled) 
            {
                m_params.AddOpt("customer[is_einvoice_enabled]", customerIsEinvoiceEnabled);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerEntityIdentifierScheme(string customerEntityIdentifierScheme) 
            {
                m_params.AddOpt("customer[entity_identifier_scheme]", customerEntityIdentifierScheme);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerEntityIdentifierStandard(string customerEntityIdentifierStandard) 
            {
                m_params.AddOpt("customer[entity_identifier_standard]", customerEntityIdentifierStandard);
                return this;
            }
            public CheckoutOneTimeForItemsRequest CustomerConsolidatedInvoicing(bool customerConsolidatedInvoicing) 
            {
                m_params.AddOpt("customer[consolidated_invoicing]", customerConsolidatedInvoicing);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CheckoutOneTimeForItemsRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemPriceItemPriceId(int index, string itemPriceItemPriceId) 
            {
                m_params.AddOpt("item_prices[item_price_id][" + index + "]", itemPriceItemPriceId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemPriceQuantity(int index, int itemPriceQuantity) 
            {
                m_params.AddOpt("item_prices[quantity][" + index + "]", itemPriceQuantity);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemPriceQuantityInDecimal(int index, string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_prices[quantity_in_decimal][" + index + "]", itemPriceQuantityInDecimal);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemPriceUnitPrice(int index, long itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_prices[unit_price][" + index + "]", itemPriceUnitPrice);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemPriceUnitPriceInDecimal(int index, string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_prices[unit_price_in_decimal][" + index + "]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemPriceDateFrom(int index, long itemPriceDateFrom) 
            {
                m_params.AddOpt("item_prices[date_from][" + index + "]", itemPriceDateFrom);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemPriceDateTo(int index, long itemPriceDateTo) 
            {
                m_params.AddOpt("item_prices[date_to][" + index + "]", itemPriceDateTo);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierPricingType(int index, ChargeBee.Models.Enums.PricingTypeEnum itemTierPricingType) 
            {
                m_params.AddOpt("item_tiers[pricing_type][" + index + "]", itemTierPricingType);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ItemTierPackageSize(int index, int itemTierPackageSize) 
            {
                m_params.AddOpt("item_tiers[package_size][" + index + "]", itemTierPackageSize);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeAmount(int index, long chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CheckoutOneTimeForItemsRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
            public CheckoutOneTimeForItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CheckoutOneTimeForItemsRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CheckoutOneTimeForItemsRequest DiscountQuantity(int index, int discountQuantity) 
            {
                m_params.AddOpt("discounts[quantity][" + index + "]", discountQuantity);
                return this;
            }
            public CheckoutOneTimeForItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CheckoutOneTimeForItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest EntityIdentifierId(int index, string entityIdentifierId) 
            {
                m_params.AddOpt("entity_identifiers[id][" + index + "]", entityIdentifierId);
                return this;
            }
            public CheckoutOneTimeForItemsRequest EntityIdentifierScheme(int index, string entityIdentifierScheme) 
            {
                m_params.AddOpt("entity_identifiers[scheme][" + index + "]", entityIdentifierScheme);
                return this;
            }
            public CheckoutOneTimeForItemsRequest EntityIdentifierValue(int index, string entityIdentifierValue) 
            {
                m_params.AddOpt("entity_identifiers[value][" + index + "]", entityIdentifierValue);
                return this;
            }
            public CheckoutOneTimeForItemsRequest EntityIdentifierOperation(int index, ChargeBee.Models.Enums.OperationEnum entityIdentifierOperation) 
            {
                m_params.AddOpt("entity_identifiers[operation][" + index + "]", entityIdentifierOperation);
                return this;
            }
            public CheckoutOneTimeForItemsRequest EntityIdentifierStandard(int index, string entityIdentifierStandard) 
            {
                m_params.AddOpt("entity_identifiers[standard][" + index + "]", entityIdentifierStandard);
                return this;
            }
        }
        public class CheckoutNewForItemsRequest : EntityRequest<CheckoutNewForItemsRequest> 
        {
            public CheckoutNewForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutNewForItemsRequest Layout(ChargeBee.Models.Enums.LayoutEnum layout) 
            {
                m_params.AddOpt("layout", layout);
                return this;
            }
            public CheckoutNewForItemsRequest BusinessEntityId(string businessEntityId) 
            {
                m_params.AddOpt("business_entity_id", businessEntityId);
                return this;
            }
            public CheckoutNewForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CheckoutNewForItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public CheckoutNewForItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CheckoutNewForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CheckoutNewForItemsRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutNewForItemsRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
                return this;
            }
            public CheckoutNewForItemsRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutNewForItemsRequest AllowOfflinePaymentMethods(bool allowOfflinePaymentMethods) 
            {
                m_params.AddOpt("allow_offline_payment_methods", allowOfflinePaymentMethods);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerCompany(string customerCompany) 
            {
                m_params.AddOpt("customer[company]", customerCompany);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public CheckoutNewForItemsRequest SubscriptionSetupFee(long subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionInvoiceNotes(string subscriptionInvoiceNotes) 
            {
                m_params.AddOpt("subscription[invoice_notes]", subscriptionInvoiceNotes);
                return this;
            }
            [Obsolete]
            public CheckoutNewForItemsRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutNewForItemsRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerIsEinvoiceEnabled(bool customerIsEinvoiceEnabled) 
            {
                m_params.AddOpt("customer[is_einvoice_enabled]", customerIsEinvoiceEnabled);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerEntityIdentifierScheme(string customerEntityIdentifierScheme) 
            {
                m_params.AddOpt("customer[entity_identifier_scheme]", customerEntityIdentifierScheme);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerEntityIdentifierStandard(string customerEntityIdentifierStandard) 
            {
                m_params.AddOpt("customer[entity_identifier_standard]", customerEntityIdentifierStandard);
                return this;
            }
            public CheckoutNewForItemsRequest CustomerEinvoicingMethod(ChargeBee.Models.Enums.EinvoicingMethodEnum customerEinvoicingMethod) 
            {
                m_params.AddOpt("customer[einvoicing_method]", customerEinvoicingMethod);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionPoNumber(string subscriptionPoNumber) 
            {
                m_params.AddOpt("subscription[po_number]", subscriptionPoNumber);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CheckoutNewForItemsRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CheckoutNewForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CheckoutNewForItemsRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CheckoutNewForItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemUnitPrice(int index, long subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            [Obsolete]
            public CheckoutNewForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.AddOpt("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CheckoutNewForItemsRequest DiscountQuantity(int index, int discountQuantity) 
            {
                m_params.AddOpt("discounts[quantity][" + index + "]", discountQuantity);
                return this;
            }
            public CheckoutNewForItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierPricingType(int index, ChargeBee.Models.Enums.PricingTypeEnum itemTierPricingType) 
            {
                m_params.AddOpt("item_tiers[pricing_type][" + index + "]", itemTierPricingType);
                return this;
            }
            public CheckoutNewForItemsRequest ItemTierPackageSize(int index, int itemTierPackageSize) 
            {
                m_params.AddOpt("item_tiers[package_size][" + index + "]", itemTierPackageSize);
                return this;
            }
            public CheckoutNewForItemsRequest EntityIdentifierId(int index, string entityIdentifierId) 
            {
                m_params.AddOpt("entity_identifiers[id][" + index + "]", entityIdentifierId);
                return this;
            }
            public CheckoutNewForItemsRequest EntityIdentifierScheme(int index, string entityIdentifierScheme) 
            {
                m_params.AddOpt("entity_identifiers[scheme][" + index + "]", entityIdentifierScheme);
                return this;
            }
            public CheckoutNewForItemsRequest EntityIdentifierValue(int index, string entityIdentifierValue) 
            {
                m_params.AddOpt("entity_identifiers[value][" + index + "]", entityIdentifierValue);
                return this;
            }
            public CheckoutNewForItemsRequest EntityIdentifierOperation(int index, ChargeBee.Models.Enums.OperationEnum entityIdentifierOperation) 
            {
                m_params.AddOpt("entity_identifiers[operation][" + index + "]", entityIdentifierOperation);
                return this;
            }
            public CheckoutNewForItemsRequest EntityIdentifierStandard(int index, string entityIdentifierStandard) 
            {
                m_params.AddOpt("entity_identifiers[standard][" + index + "]", entityIdentifierStandard);
                return this;
            }
        }
        public class CheckoutExistingRequest : EntityRequest<CheckoutExistingRequest> 
        {
            public CheckoutExistingRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutExistingRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public CheckoutExistingRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public CheckoutExistingRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CheckoutExistingRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
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
            public CheckoutExistingRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CheckoutExistingRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CheckoutExistingRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
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
            public CheckoutExistingRequest AllowOfflinePaymentMethods(bool allowOfflinePaymentMethods) 
            {
                m_params.AddOpt("allow_offline_payment_methods", allowOfflinePaymentMethods);
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
            public CheckoutExistingRequest SubscriptionPlanUnitPrice(long subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CheckoutExistingRequest SubscriptionSetupFee(long subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CheckoutExistingRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public CheckoutExistingRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
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
            [Obsolete]
            public CheckoutExistingRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CheckoutExistingRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public CheckoutExistingRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CheckoutExistingRequest SubscriptionInvoiceNotes(string subscriptionInvoiceNotes) 
            {
                m_params.AddOpt("subscription[invoice_notes]", subscriptionInvoiceNotes);
                return this;
            }
            public CheckoutExistingRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutExistingRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
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
            public CheckoutExistingRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CheckoutExistingRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CheckoutExistingRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
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
            public CheckoutExistingRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CheckoutExistingRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CheckoutExistingRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CheckoutExistingRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CheckoutExistingRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
        }
        public class CheckoutExistingForItemsRequest : EntityRequest<CheckoutExistingForItemsRequest> 
        {
            public CheckoutExistingForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutExistingForItemsRequest Layout(ChargeBee.Models.Enums.LayoutEnum layout) 
            {
                m_params.AddOpt("layout", layout);
                return this;
            }
            public CheckoutExistingForItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public CheckoutExistingForItemsRequest ReplaceItemsList(bool replaceItemsList) 
            {
                m_params.AddOpt("replace_items_list", replaceItemsList);
                return this;
            }
            public CheckoutExistingForItemsRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CheckoutExistingForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CheckoutExistingForItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CheckoutExistingForItemsRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public CheckoutExistingForItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CheckoutExistingForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CheckoutExistingForItemsRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public CheckoutExistingForItemsRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public CheckoutExistingForItemsRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public CheckoutExistingForItemsRequest ChangeOption(ChargeBee.Models.Enums.ChangeOptionEnum changeOption) 
            {
                m_params.AddOpt("change_option", changeOption);
                return this;
            }
            public CheckoutExistingForItemsRequest ChangesScheduledAt(long changesScheduledAt) 
            {
                m_params.AddOpt("changes_scheduled_at", changesScheduledAt);
                return this;
            }
            public CheckoutExistingForItemsRequest InvoiceUsages(bool invoiceUsages) 
            {
                m_params.AddOpt("invoice_usages", invoiceUsages);
                return this;
            }
            public CheckoutExistingForItemsRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutExistingForItemsRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
                return this;
            }
            public CheckoutExistingForItemsRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public CheckoutExistingForItemsRequest AllowOfflinePaymentMethods(bool allowOfflinePaymentMethods) 
            {
                m_params.AddOpt("allow_offline_payment_methods", allowOfflinePaymentMethods);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            [Obsolete]
            public CheckoutExistingForItemsRequest SubscriptionSetupFee(long subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public CheckoutExistingForItemsRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionInvoiceNotes(string subscriptionInvoiceNotes) 
            {
                m_params.AddOpt("subscription[invoice_notes]", subscriptionInvoiceNotes);
                return this;
            }
            public CheckoutExistingForItemsRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CheckoutExistingForItemsRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public CheckoutExistingForItemsRequest CustomerIsEinvoiceEnabled(bool customerIsEinvoiceEnabled) 
            {
                m_params.AddOpt("customer[is_einvoice_enabled]", customerIsEinvoiceEnabled);
                return this;
            }
            public CheckoutExistingForItemsRequest CustomerEntityIdentifierScheme(string customerEntityIdentifierScheme) 
            {
                m_params.AddOpt("customer[entity_identifier_scheme]", customerEntityIdentifierScheme);
                return this;
            }
            public CheckoutExistingForItemsRequest CustomerEntityIdentifierStandard(string customerEntityIdentifierStandard) 
            {
                m_params.AddOpt("customer[entity_identifier_standard]", customerEntityIdentifierStandard);
                return this;
            }
            [Obsolete]
            public CheckoutExistingForItemsRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CheckoutExistingForItemsRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            public CheckoutExistingForItemsRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CheckoutExistingForItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemUnitPrice(int index, long subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            public CheckoutExistingForItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            [Obsolete]
            public CheckoutExistingForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.AddOpt("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountQuantity(int index, int discountQuantity) 
            {
                m_params.AddOpt("discounts[quantity][" + index + "]", discountQuantity);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountOperationType(int index, ChargeBee.Models.Enums.OperationTypeEnum discountOperationType) 
            {
                m_params.Add("discounts[operation_type][" + index + "]", discountOperationType);
                return this;
            }
            public CheckoutExistingForItemsRequest DiscountId(int index, string discountId) 
            {
                m_params.AddOpt("discounts[id][" + index + "]", discountId);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierPricingType(int index, ChargeBee.Models.Enums.PricingTypeEnum itemTierPricingType) 
            {
                m_params.AddOpt("item_tiers[pricing_type][" + index + "]", itemTierPricingType);
                return this;
            }
            public CheckoutExistingForItemsRequest ItemTierPackageSize(int index, int itemTierPackageSize) 
            {
                m_params.AddOpt("item_tiers[package_size][" + index + "]", itemTierPackageSize);
                return this;
            }
            public CheckoutExistingForItemsRequest EntityIdentifierId(int index, string entityIdentifierId) 
            {
                m_params.AddOpt("entity_identifiers[id][" + index + "]", entityIdentifierId);
                return this;
            }
            public CheckoutExistingForItemsRequest EntityIdentifierScheme(int index, string entityIdentifierScheme) 
            {
                m_params.AddOpt("entity_identifiers[scheme][" + index + "]", entityIdentifierScheme);
                return this;
            }
            public CheckoutExistingForItemsRequest EntityIdentifierValue(int index, string entityIdentifierValue) 
            {
                m_params.AddOpt("entity_identifiers[value][" + index + "]", entityIdentifierValue);
                return this;
            }
            public CheckoutExistingForItemsRequest EntityIdentifierOperation(int index, ChargeBee.Models.Enums.OperationEnum entityIdentifierOperation) 
            {
                m_params.AddOpt("entity_identifiers[operation][" + index + "]", entityIdentifierOperation);
                return this;
            }
            public CheckoutExistingForItemsRequest EntityIdentifierStandard(int index, string entityIdentifierStandard) 
            {
                m_params.AddOpt("entity_identifiers[standard][" + index + "]", entityIdentifierStandard);
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
            public UpdateCardRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
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
            public UpdatePaymentMethodRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
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
        public class ManagePaymentSourcesRequest : EntityRequest<ManagePaymentSourcesRequest> 
        {
            public ManagePaymentSourcesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ManagePaymentSourcesRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public ManagePaymentSourcesRequest CustomerId(string customerId) 
            {
                m_params.Add("customer[id]", customerId);
                return this;
            }
            [Obsolete]
            public ManagePaymentSourcesRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public ManagePaymentSourcesRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
        }
        public class CollectNowRequest : EntityRequest<CollectNowRequest> 
        {
            public CollectNowRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CollectNowRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CollectNowRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CollectNowRequest CustomerId(string customerId) 
            {
                m_params.Add("customer[id]", customerId);
                return this;
            }
            [Obsolete]
            public CollectNowRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CollectNowRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
        }
        public class AcceptQuoteRequest : EntityRequest<AcceptQuoteRequest> 
        {
            public AcceptQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AcceptQuoteRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public AcceptQuoteRequest Layout(ChargeBee.Models.Enums.LayoutEnum layout) 
            {
                m_params.AddOpt("layout", layout);
                return this;
            }
            public AcceptQuoteRequest QuoteId(string quoteId) 
            {
                m_params.Add("quote[id]", quoteId);
                return this;
            }
        }
        public class ExtendSubscriptionRequest : EntityRequest<ExtendSubscriptionRequest> 
        {
            public ExtendSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ExtendSubscriptionRequest Expiry(int expiry) 
            {
                m_params.AddOpt("expiry", expiry);
                return this;
            }
            public ExtendSubscriptionRequest BillingCycle(int billingCycle) 
            {
                m_params.AddOpt("billing_cycle", billingCycle);
                return this;
            }
            public ExtendSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
        }
        public class CheckoutGiftRequest : EntityRequest<CheckoutGiftRequest> 
        {
            public CheckoutGiftRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutGiftRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutGiftRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CheckoutGiftRequest GifterCustomerId(string gifterCustomerId) 
            {
                m_params.AddOpt("gifter[customer_id]", gifterCustomerId);
                return this;
            }
            public CheckoutGiftRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CheckoutGiftRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CheckoutGiftRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            [Obsolete]
            public CheckoutGiftRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CheckoutGiftRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CheckoutGiftRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CheckoutGiftRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
        }
        public class CheckoutGiftForItemsRequest : EntityRequest<CheckoutGiftForItemsRequest> 
        {
            public CheckoutGiftForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CheckoutGiftForItemsRequest BusinessEntityId(string businessEntityId) 
            {
                m_params.AddOpt("business_entity_id", businessEntityId);
                return this;
            }
            public CheckoutGiftForItemsRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CheckoutGiftForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CheckoutGiftForItemsRequest GifterCustomerId(string gifterCustomerId) 
            {
                m_params.AddOpt("gifter[customer_id]", gifterCustomerId);
                return this;
            }
            public CheckoutGiftForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.AddOpt("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CheckoutGiftForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CheckoutGiftForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CheckoutGiftForItemsRequest SubscriptionItemUnitPrice(int index, long subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CheckoutGiftForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CheckoutGiftForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CheckoutGiftForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CheckoutGiftForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CheckoutGiftForItemsRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CheckoutGiftForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CheckoutGiftForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CheckoutGiftForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class ClaimGiftRequest : EntityRequest<ClaimGiftRequest> 
        {
            public ClaimGiftRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ClaimGiftRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public ClaimGiftRequest GiftId(string giftId) 
            {
                m_params.Add("gift[id]", giftId);
                return this;
            }
            public ClaimGiftRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
        }
        public class RetrieveAgreementPdfRequest : EntityRequest<RetrieveAgreementPdfRequest> 
        {
            public RetrieveAgreementPdfRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveAgreementPdfRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.Add("payment_source_id", paymentSourceId);
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
        public class PreCancelRequest : EntityRequest<PreCancelRequest> 
        {
            public PreCancelRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PreCancelRequest PassThruContent(string passThruContent) 
            {
                m_params.AddOpt("pass_thru_content", passThruContent);
                return this;
            }
            public PreCancelRequest CancelUrl(string cancelUrl) 
            {
                m_params.AddOpt("cancel_url", cancelUrl);
                return this;
            }
            public PreCancelRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public PreCancelRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
        }
        public class EventsRequest : EntityRequest<EventsRequest> 
        {
            public EventsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EventsRequest EventName(ChargeBee.Models.Enums.EventNameEnum eventName) 
            {
                m_params.Add("event_name", eventName);
                return this;
            }
            public EventsRequest OccurredAt(long occurredAt) 
            {
                m_params.AddOpt("occurred_at", occurredAt);
                return this;
            }
            public EventsRequest EventData(JToken eventData) 
            {
                m_params.Add("event_data", eventData);
                return this;
            }
        }
        public class ViewVoucherRequest : EntityRequest<ViewVoucherRequest> 
        {
            public ViewVoucherRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ViewVoucherRequest PaymentVoucherId(string paymentVoucherId) 
            {
                m_params.Add("payment_voucher[id]", paymentVoucherId);
                return this;
            }
            public ViewVoucherRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "checkout_new")]
            CheckoutNew,
            [EnumMember(Value = "checkout_existing")]
            CheckoutExisting,
            [EnumMember(Value = "update_card")]
            [Obsolete]
            UpdateCard,
            [EnumMember(Value = "update_payment_method")]
            UpdatePaymentMethod,
            [EnumMember(Value = "manage_payment_sources")]
            ManagePaymentSources,
            [EnumMember(Value = "collect_now")]
            CollectNow,
            [EnumMember(Value = "extend_subscription")]
            ExtendSubscription,
            [EnumMember(Value = "checkout_one_time")]
            CheckoutOneTime,
            [EnumMember(Value = "pre_cancel")]
            PreCancel,
            [EnumMember(Value = "view_voucher")]
            ViewVoucher,
            [EnumMember(Value = "accept_quote")]
            AcceptQuote,
            [EnumMember(Value = "checkout_gift")]
            CheckoutGift,
            [EnumMember(Value = "claim_gift")]
            ClaimGift,

        }
        public enum StateEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "created")]
            Created,
            [EnumMember(Value = "requested")]
            Requested,
            [EnumMember(Value = "succeeded")]
            Succeeded,
            [EnumMember(Value = "cancelled")]
            Cancelled,
            [EnumMember(Value = "failed")]
            [Obsolete]
            Failed,
            [EnumMember(Value = "acknowledged")]
            Acknowledged,

        }
        [Obsolete]
        public enum FailureReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "card_error")]
            CardError,
            [EnumMember(Value = "server_error")]
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
