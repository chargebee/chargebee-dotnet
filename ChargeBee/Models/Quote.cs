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

    public class Quote : Resource 
    {
    

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static CreateSubForCustomerQuoteRequest CreateSubForCustomerQuote(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "create_subscription_quote");
            return new CreateSubForCustomerQuoteRequest(url, HttpMethod.POST);
        }
        public static UpdateSubscriptionQuoteRequest UpdateSubscriptionQuote()
        {
            string url = ApiUtil.BuildUrl("quotes", "update_subscription_quote");
            return new UpdateSubscriptionQuoteRequest(url, HttpMethod.POST);
        }
        public static CreateForOnetimeChargesRequest CreateForOnetimeCharges()
        {
            string url = ApiUtil.BuildUrl("quotes", "create_for_onetime_charges");
            return new CreateForOnetimeChargesRequest(url, HttpMethod.POST);
        }
        public static QuoteListRequest List()
        {
            string url = ApiUtil.BuildUrl("quotes");
            return new QuoteListRequest(url);
        }
        public static EntityRequest<Type> Convert(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "convert");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static UpdateStatusRequest UpdateStatus(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "update_status");
            return new UpdateStatusRequest(url, HttpMethod.POST);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
        }
        public static PdfRequest Pdf(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "pdf");
            return new PdfRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string PoNumber 
        {
            get { return GetValue<string>("po_number", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public OperationTypeEnum OperationType 
        {
            get { return GetEnum<OperationTypeEnum>("operation_type", true); }
        }
        public string VatNumber 
        {
            get { return GetValue<string>("vat_number", false); }
        }
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public DateTime ValidTill 
        {
            get { return (DateTime)GetDateTime("valid_till", true); }
        }
        public DateTime Date 
        {
            get { return (DateTime)GetDateTime("date", true); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public int? Total 
        {
            get { return GetValue<int?>("total", false); }
        }
        public int? CreditsApplied 
        {
            get { return GetValue<int?>("credits_applied", false); }
        }
        public int? AmountPaid 
        {
            get { return GetValue<int?>("amount_paid", false); }
        }
        public int? AmountDue 
        {
            get { return GetValue<int?>("amount_due", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public List<QuoteLineItem> LineItems 
        {
            get { return GetResourceList<QuoteLineItem>("line_items"); }
        }
        public List<QuoteDiscount> Discounts 
        {
            get { return GetResourceList<QuoteDiscount>("discounts"); }
        }
        public List<QuoteLineItemDiscount> LineItemDiscounts 
        {
            get { return GetResourceList<QuoteLineItemDiscount>("line_item_discounts"); }
        }
        public List<QuoteTax> Taxes 
        {
            get { return GetResourceList<QuoteTax>("taxes"); }
        }
        public List<QuoteLineItemTax> LineItemTaxes 
        {
            get { return GetResourceList<QuoteLineItemTax>("line_item_taxes"); }
        }
        public QuoteShippingAddress ShippingAddress 
        {
            get { return GetSubResource<QuoteShippingAddress>("shipping_address"); }
        }
        public QuoteBillingAddress BillingAddress 
        {
            get { return GetSubResource<QuoteBillingAddress>("billing_address"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateSubForCustomerQuoteRequest : EntityRequest<CreateSubForCustomerQuoteRequest> 
        {
            public CreateSubForCustomerQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubForCustomerQuoteRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubForCustomerQuoteRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubForCustomerQuoteRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubForCustomerQuoteRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public CreateSubForCustomerQuoteRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubForCustomerQuoteRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateSubForCustomerQuoteRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateSubForCustomerQuoteRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateSubForCustomerQuoteRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public CreateSubForCustomerQuoteRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class UpdateSubscriptionQuoteRequest : EntityRequest<UpdateSubscriptionQuoteRequest> 
        {
            public UpdateSubscriptionQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateSubscriptionQuoteRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddons(string eventBasedAddons) 
            {
                m_params.AddOpt("event_based_addons", eventBasedAddons);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public UpdateSubscriptionQuoteRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public UpdateSubscriptionQuoteRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public UpdateSubscriptionQuoteRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public UpdateSubscriptionQuoteRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionQuoteRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateSubscriptionQuoteRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionQuoteRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateSubscriptionQuoteRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public UpdateSubscriptionQuoteRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public UpdateSubscriptionQuoteRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public UpdateSubscriptionQuoteRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public UpdateSubscriptionQuoteRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public UpdateSubscriptionQuoteRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class CreateForOnetimeChargesRequest : EntityRequest<CreateForOnetimeChargesRequest> 
        {
            public CreateForOnetimeChargesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForOnetimeChargesRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateForOnetimeChargesRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateForOnetimeChargesRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateForOnetimeChargesRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateForOnetimeChargesRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonDateFrom(int index, long addonDateFrom) 
            {
                m_params.AddOpt("addons[date_from][" + index + "]", addonDateFrom);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonDateTo(int index, long addonDateTo) 
            {
                m_params.AddOpt("addons[date_to][" + index + "]", addonDateTo);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
        }
        public class QuoteListRequest : ListRequestBase<QuoteListRequest> 
        {
            public QuoteListRequest(string url) 
                    : base(url)
            {
            }

            public QuoteListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public StringFilter<QuoteListRequest> Id() 
            {
                return new StringFilter<QuoteListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<QuoteListRequest> CustomerId() 
            {
                return new StringFilter<QuoteListRequest>("customer_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<QuoteListRequest> SubscriptionId() 
            {
                return new StringFilter<QuoteListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public EnumFilter<Quote.StatusEnum, QuoteListRequest> Status() 
            {
                return new EnumFilter<Quote.StatusEnum, QuoteListRequest>("status", this);        
            }
            public TimestampFilter<QuoteListRequest> Date() 
            {
                return new TimestampFilter<QuoteListRequest>("date", this);        
            }
            public TimestampFilter<QuoteListRequest> UpdatedAt() 
            {
                return new TimestampFilter<QuoteListRequest>("updated_at", this);        
            }
            public QuoteListRequest SortByDate(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","date");
                return this;
            }
        }
        public class UpdateStatusRequest : EntityRequest<UpdateStatusRequest> 
        {
            public UpdateStatusRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateStatusRequest Status(StatusEnum status) 
            {
                m_params.Add("status", status);
                return this;
            }
            public UpdateStatusRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        public class PdfRequest : EntityRequest<PdfRequest> 
        {
            public PdfRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PdfRequest DispositionType(ChargeBee.Models.Enums.DispositionTypeEnum dispositionType) 
            {
                m_params.AddOpt("disposition_type", dispositionType);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "open")]
            Open,
            [EnumMember(Value = "accepted")]
            Accepted,
            [EnumMember(Value = "declined")]
            Declined,
            [EnumMember(Value = "invoiced")]
            Invoiced,
            [EnumMember(Value = "closed")]
            Closed,

        }
        public enum OperationTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "create_subscription_for_customer")]
            CreateSubscriptionForCustomer,
            [EnumMember(Value = "change_subscription")]
            ChangeSubscription,
            [EnumMember(Value = "onetime_invoice")]
            OnetimeInvoice,

        }

        #region Subclasses
        public class QuoteLineItem : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan_setup")]
                PlanSetup,
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "adhoc")]
                Adhoc,
            }

            public string Id() {
                return GetValue<string>("id", false);
            }

            public string SubscriptionId() {
                return GetValue<string>("subscription_id", false);
            }

            public DateTime DateFrom() {
                return (DateTime)GetDateTime("date_from", true);
            }

            public DateTime DateTo() {
                return (DateTime)GetDateTime("date_to", true);
            }

            public int UnitAmount() {
                return GetValue<int>("unit_amount", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public int? Amount() {
                return GetValue<int?>("amount", false);
            }

            public PricingModelEnum? PricingModel() {
                return GetEnum<PricingModelEnum>("pricing_model", false);
            }

            public bool IsTaxed() {
                return GetValue<bool>("is_taxed", true);
            }

            public int? TaxAmount() {
                return GetValue<int?>("tax_amount", false);
            }

            public double? TaxRate() {
                return GetValue<double?>("tax_rate", false);
            }

            public int? DiscountAmount() {
                return GetValue<int?>("discount_amount", false);
            }

            public int? ItemLevelDiscountAmount() {
                return GetValue<int?>("item_level_discount_amount", false);
            }

            public string Description() {
                return GetValue<string>("description", true);
            }

            public EntityTypeEnum EntityType() {
                return GetEnum<EntityTypeEnum>("entity_type", true);
            }

            public TaxExemptReasonEnum? TaxExemptReason() {
                return GetEnum<TaxExemptReasonEnum>("tax_exempt_reason", false);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

            public string CustomerId() {
                return GetValue<string>("customer_id", false);
            }

        }
        public class QuoteDiscount : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

            public EntityTypeEnum EntityType() {
                return GetEnum<EntityTypeEnum>("entity_type", true);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class QuoteLineItemDiscount : Resource
        {
            public enum DiscountTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
            }

            public string LineItemId() {
                return GetValue<string>("line_item_id", true);
            }

            public DiscountTypeEnum DiscountType() {
                return GetEnum<DiscountTypeEnum>("discount_type", true);
            }

            public string CouponId() {
                return GetValue<string>("coupon_id", false);
            }

            public int DiscountAmount() {
                return GetValue<int>("discount_amount", true);
            }

        }
        public class QuoteTax : Resource
        {

            public string Name() {
                return GetValue<string>("name", true);
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

        }
        public class QuoteLineItemTax : Resource
        {

            public string LineItemId() {
                return GetValue<string>("line_item_id", false);
            }

            public string TaxName() {
                return GetValue<string>("tax_name", true);
            }

            public double TaxRate() {
                return GetValue<double>("tax_rate", true);
            }

            public bool? IsPartialTaxApplied() {
                return GetValue<bool?>("is_partial_tax_applied", false);
            }

            public bool? IsNonComplianceTax() {
                return GetValue<bool?>("is_non_compliance_tax", false);
            }

            public int TaxableAmount() {
                return GetValue<int>("taxable_amount", true);
            }

            public int TaxAmount() {
                return GetValue<int>("tax_amount", true);
            }

            public TaxJurisTypeEnum? TaxJurisType() {
                return GetEnum<TaxJurisTypeEnum>("tax_juris_type", false);
            }

            public string TaxJurisName() {
                return GetValue<string>("tax_juris_name", false);
            }

            public string TaxJurisCode() {
                return GetValue<string>("tax_juris_code", false);
            }

        }
        public class QuoteShippingAddress : Resource
        {

            public string FirstName() {
                return GetValue<string>("first_name", false);
            }

            public string LastName() {
                return GetValue<string>("last_name", false);
            }

            public string Email() {
                return GetValue<string>("email", false);
            }

            public string Company() {
                return GetValue<string>("company", false);
            }

            public string Phone() {
                return GetValue<string>("phone", false);
            }

            public string Line1() {
                return GetValue<string>("line1", false);
            }

            public string Line2() {
                return GetValue<string>("line2", false);
            }

            public string Line3() {
                return GetValue<string>("line3", false);
            }

            public string City() {
                return GetValue<string>("city", false);
            }

            public string StateCode() {
                return GetValue<string>("state_code", false);
            }

            public string State() {
                return GetValue<string>("state", false);
            }

            public string Country() {
                return GetValue<string>("country", false);
            }

            public string Zip() {
                return GetValue<string>("zip", false);
            }

            public ValidationStatusEnum? ValidationStatus() {
                return GetEnum<ValidationStatusEnum>("validation_status", false);
            }

        }
        public class QuoteBillingAddress : Resource
        {

            public string FirstName() {
                return GetValue<string>("first_name", false);
            }

            public string LastName() {
                return GetValue<string>("last_name", false);
            }

            public string Email() {
                return GetValue<string>("email", false);
            }

            public string Company() {
                return GetValue<string>("company", false);
            }

            public string Phone() {
                return GetValue<string>("phone", false);
            }

            public string Line1() {
                return GetValue<string>("line1", false);
            }

            public string Line2() {
                return GetValue<string>("line2", false);
            }

            public string Line3() {
                return GetValue<string>("line3", false);
            }

            public string City() {
                return GetValue<string>("city", false);
            }

            public string StateCode() {
                return GetValue<string>("state_code", false);
            }

            public string State() {
                return GetValue<string>("state", false);
            }

            public string Country() {
                return GetValue<string>("country", false);
            }

            public string Zip() {
                return GetValue<string>("zip", false);
            }

            public ValidationStatusEnum? ValidationStatus() {
                return GetEnum<ValidationStatusEnum>("validation_status", false);
            }

        }

        #endregion
    }
}
