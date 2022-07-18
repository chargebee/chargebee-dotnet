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
    
        public Quote() { }

        public Quote(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Quote(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Quote(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

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
        public static EditCreateSubForCustomerQuoteRequest EditCreateSubForCustomerQuote(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "edit_create_subscription_quote");
            return new EditCreateSubForCustomerQuoteRequest(url, HttpMethod.POST);
        }
        public static UpdateSubscriptionQuoteRequest UpdateSubscriptionQuote()
        {
            string url = ApiUtil.BuildUrl("quotes", "update_subscription_quote");
            return new UpdateSubscriptionQuoteRequest(url, HttpMethod.POST);
        }
        public static EditUpdateSubscriptionQuoteRequest EditUpdateSubscriptionQuote(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "edit_update_subscription_quote");
            return new EditUpdateSubscriptionQuoteRequest(url, HttpMethod.POST);
        }
        public static CreateForOnetimeChargesRequest CreateForOnetimeCharges()
        {
            string url = ApiUtil.BuildUrl("quotes", "create_for_onetime_charges");
            return new CreateForOnetimeChargesRequest(url, HttpMethod.POST);
        }
        public static EditOneTimeQuoteRequest EditOneTimeQuote(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "edit_one_time_quote");
            return new EditOneTimeQuoteRequest(url, HttpMethod.POST);
        }
        public static CreateSubItemsForCustomerQuoteRequest CreateSubItemsForCustomerQuote(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "create_subscription_quote_for_items");
            return new CreateSubItemsForCustomerQuoteRequest(url, HttpMethod.POST);
        }
        public static EditCreateSubCustomerQuoteForItemsRequest EditCreateSubCustomerQuoteForItems(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "edit_create_subscription_quote_for_items");
            return new EditCreateSubCustomerQuoteForItemsRequest(url, HttpMethod.POST);
        }
        public static UpdateSubscriptionQuoteForItemsRequest UpdateSubscriptionQuoteForItems()
        {
            string url = ApiUtil.BuildUrl("quotes", "update_subscription_quote_for_items");
            return new UpdateSubscriptionQuoteForItemsRequest(url, HttpMethod.POST);
        }
        public static EditUpdateSubscriptionQuoteForItemsRequest EditUpdateSubscriptionQuoteForItems(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "edit_update_subscription_quote_for_items");
            return new EditUpdateSubscriptionQuoteForItemsRequest(url, HttpMethod.POST);
        }
        public static CreateForChargeItemsAndChargesRequest CreateForChargeItemsAndCharges()
        {
            string url = ApiUtil.BuildUrl("quotes", "create_for_charge_items_and_charges");
            return new CreateForChargeItemsAndChargesRequest(url, HttpMethod.POST);
        }
        public static EditForChargeItemsAndChargesRequest EditForChargeItemsAndCharges(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "edit_for_charge_items_and_charges");
            return new EditForChargeItemsAndChargesRequest(url, HttpMethod.POST);
        }
        public static QuoteListRequest List()
        {
            string url = ApiUtil.BuildUrl("quotes");
            return new QuoteListRequest(url);
        }
        public static ListRequest QuoteLineGroupsForQuote(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "quote_line_groups");
            return new ListRequest(url);
        }
        public static ConvertRequest Convert(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "convert");
            return new ConvertRequest(url, HttpMethod.POST);
        }
        public static UpdateStatusRequest UpdateStatus(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "update_status");
            return new UpdateStatusRequest(url, HttpMethod.POST);
        }
        public static ExtendExpiryDateRequest ExtendExpiryDate(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "extend_expiry_date");
            return new ExtendExpiryDateRequest(url, HttpMethod.POST);
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
        public string Name 
        {
            get { return GetValue<string>("name", false); }
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
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", false); }
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
        public long? TotalPayable 
        {
            get { return GetValue<long?>("total_payable", false); }
        }
        public int? ChargeOnAcceptance 
        {
            get { return GetValue<int?>("charge_on_acceptance", false); }
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
        public int? Version 
        {
            get { return GetValue<int?>("version", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string VatNumberPrefix 
        {
            get { return GetValue<string>("vat_number_prefix", false); }
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
        public List<QuoteLineItemTier> LineItemTiers 
        {
            get { return GetResourceList<QuoteLineItemTier>("line_item_tiers"); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public JArray Notes 
        {
            get { return GetJArray("notes", false); }
        }
        public QuoteShippingAddress ShippingAddress 
        {
            get { return GetSubResource<QuoteShippingAddress>("shipping_address"); }
        }
        public QuoteBillingAddress BillingAddress 
        {
            get { return GetSubResource<QuoteBillingAddress>("billing_address"); }
        }
        public DateTime? ContractTermStart 
        {
            get { return GetDateTime("contract_term_start", false); }
        }
        public DateTime? ContractTermEnd 
        {
            get { return GetDateTime("contract_term_end", false); }
        }
        public int? ContractTermTerminationFee 
        {
            get { return GetValue<int?>("contract_term_termination_fee", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateSubForCustomerQuoteRequest : EntityRequest<CreateSubForCustomerQuoteRequest> 
        {
            public CreateSubForCustomerQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubForCustomerQuoteRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public CreateSubForCustomerQuoteRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public CreateSubForCustomerQuoteRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubForCustomerQuoteRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
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
            public CreateSubForCustomerQuoteRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
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
            public CreateSubForCustomerQuoteRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateSubForCustomerQuoteRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateSubForCustomerQuoteRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
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
            public CreateSubForCustomerQuoteRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateSubForCustomerQuoteRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateSubForCustomerQuoteRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
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
            public CreateSubForCustomerQuoteRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CreateSubForCustomerQuoteRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
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
        public class EditCreateSubForCustomerQuoteRequest : EntityRequest<EditCreateSubForCustomerQuoteRequest> 
        {
            public EditCreateSubForCustomerQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EditCreateSubForCustomerQuoteRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public EditCreateSubForCustomerQuoteRequest AddonTrialEnd(int index, long addonTrialEnd) 
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

            public UpdateSubscriptionQuoteRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateSubscriptionQuoteRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
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
            public UpdateSubscriptionQuoteRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
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
            public UpdateSubscriptionQuoteRequest ChangeOption(ChargeBee.Models.Enums.ChangeOptionEnum changeOption) 
            {
                m_params.AddOpt("change_option", changeOption);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ChangesScheduledAt(long changesScheduledAt) 
            {
                m_params.AddOpt("changes_scheduled_at", changesScheduledAt);
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
            public UpdateSubscriptionQuoteRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
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
            public UpdateSubscriptionQuoteRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
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
            public UpdateSubscriptionQuoteRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public UpdateSubscriptionQuoteRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public UpdateSubscriptionQuoteRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public UpdateSubscriptionQuoteRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
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
            public UpdateSubscriptionQuoteRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class EditUpdateSubscriptionQuoteRequest : EntityRequest<EditUpdateSubscriptionQuoteRequest> 
        {
            public EditUpdateSubscriptionQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EditUpdateSubscriptionQuoteRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ChangeOption(ChargeBee.Models.Enums.ChangeOptionEnum changeOption) 
            {
                m_params.AddOpt("change_option", changeOption);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ChangesScheduledAt(long changesScheduledAt) 
            {
                m_params.AddOpt("changes_scheduled_at", changesScheduledAt);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public EditUpdateSubscriptionQuoteRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteRequest AddonTrialEnd(int index, long addonTrialEnd) 
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

            public CreateForOnetimeChargesRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
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
            public CreateForOnetimeChargesRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public CreateForOnetimeChargesRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
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
            public CreateForOnetimeChargesRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
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
            public CreateForOnetimeChargesRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateForOnetimeChargesRequest AddonServicePeriod(int index, int addonServicePeriod) 
            {
                m_params.AddOpt("addons[service_period][" + index + "]", addonServicePeriod);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateForOnetimeChargesRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
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
            public CreateForOnetimeChargesRequest ChargeServicePeriod(int index, int chargeServicePeriod) 
            {
                m_params.AddOpt("charges[service_period][" + index + "]", chargeServicePeriod);
                return this;
            }
        }
        public class EditOneTimeQuoteRequest : EntityRequest<EditOneTimeQuoteRequest> 
        {
            public EditOneTimeQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EditOneTimeQuoteRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public EditOneTimeQuoteRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public EditOneTimeQuoteRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public EditOneTimeQuoteRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public EditOneTimeQuoteRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public EditOneTimeQuoteRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public EditOneTimeQuoteRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public EditOneTimeQuoteRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public EditOneTimeQuoteRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public EditOneTimeQuoteRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public EditOneTimeQuoteRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public EditOneTimeQuoteRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public EditOneTimeQuoteRequest AddonServicePeriod(int index, int addonServicePeriod) 
            {
                m_params.AddOpt("addons[service_period][" + index + "]", addonServicePeriod);
                return this;
            }
            public EditOneTimeQuoteRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public EditOneTimeQuoteRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public EditOneTimeQuoteRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public EditOneTimeQuoteRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public EditOneTimeQuoteRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public EditOneTimeQuoteRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public EditOneTimeQuoteRequest ChargeServicePeriod(int index, int chargeServicePeriod) 
            {
                m_params.AddOpt("charges[service_period][" + index + "]", chargeServicePeriod);
                return this;
            }
        }
        public class CreateSubItemsForCustomerQuoteRequest : EntityRequest<CreateSubItemsForCustomerQuoteRequest> 
        {
            public CreateSubItemsForCustomerQuoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubItemsForCustomerQuoteRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public CreateSubItemsForCustomerQuoteRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            [Obsolete]
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateSubItemsForCustomerQuoteRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class EditCreateSubCustomerQuoteForItemsRequest : EntityRequest<EditCreateSubCustomerQuoteForItemsRequest> 
        {
            public EditCreateSubCustomerQuoteForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EditCreateSubCustomerQuoteForItemsRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            [Obsolete]
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public EditCreateSubCustomerQuoteForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class UpdateSubscriptionQuoteForItemsRequest : EntityRequest<UpdateSubscriptionQuoteForItemsRequest> 
        {
            public UpdateSubscriptionQuoteForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateSubscriptionQuoteForItemsRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ReplaceItemsList(bool replaceItemsList) 
            {
                m_params.AddOpt("replace_items_list", replaceItemsList);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ChangeOption(ChargeBee.Models.Enums.ChangeOptionEnum changeOption) 
            {
                m_params.AddOpt("change_option", changeOption);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ChangesScheduledAt(long changesScheduledAt) 
            {
                m_params.AddOpt("changes_scheduled_at", changesScheduledAt);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionQuoteForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public UpdateSubscriptionQuoteForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class EditUpdateSubscriptionQuoteForItemsRequest : EntityRequest<EditUpdateSubscriptionQuoteForItemsRequest> 
        {
            public EditUpdateSubscriptionQuoteForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EditUpdateSubscriptionQuoteForItemsRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ReplaceItemsList(bool replaceItemsList) 
            {
                m_params.AddOpt("replace_items_list", replaceItemsList);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ChangeOption(ChargeBee.Models.Enums.ChangeOptionEnum changeOption) 
            {
                m_params.AddOpt("change_option", changeOption);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ChangesScheduledAt(long changesScheduledAt) 
            {
                m_params.AddOpt("changes_scheduled_at", changesScheduledAt);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            [Obsolete]
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            [Obsolete]
            public EditUpdateSubscriptionQuoteForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public EditUpdateSubscriptionQuoteForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class CreateForChargeItemsAndChargesRequest : EntityRequest<CreateForChargeItemsAndChargesRequest> 
        {
            public CreateForChargeItemsAndChargesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForChargeItemsAndChargesRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceItemPriceId(int index, string itemPriceItemPriceId) 
            {
                m_params.AddOpt("item_prices[item_price_id][" + index + "]", itemPriceItemPriceId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceQuantity(int index, int itemPriceQuantity) 
            {
                m_params.AddOpt("item_prices[quantity][" + index + "]", itemPriceQuantity);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceQuantityInDecimal(int index, string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_prices[quantity_in_decimal][" + index + "]", itemPriceQuantityInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceUnitPrice(int index, int itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_prices[unit_price][" + index + "]", itemPriceUnitPrice);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceUnitPriceInDecimal(int index, string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_prices[unit_price_in_decimal][" + index + "]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceServicePeriodDays(int index, int itemPriceServicePeriodDays) 
            {
                m_params.AddOpt("item_prices[service_period_days][" + index + "]", itemPriceServicePeriodDays);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeServicePeriod(int index, int chargeServicePeriod) 
            {
                m_params.AddOpt("charges[service_period][" + index + "]", chargeServicePeriod);
                return this;
            }
        }
        public class EditForChargeItemsAndChargesRequest : EntityRequest<EditForChargeItemsAndChargesRequest> 
        {
            public EditForChargeItemsAndChargesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EditForChargeItemsAndChargesRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public EditForChargeItemsAndChargesRequest Notes(string notes) 
            {
                m_params.AddOpt("notes", notes);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ExpiresAt(long expiresAt) 
            {
                m_params.AddOpt("expires_at", expiresAt);
                return this;
            }
            public EditForChargeItemsAndChargesRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public EditForChargeItemsAndChargesRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public EditForChargeItemsAndChargesRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemPriceItemPriceId(int index, string itemPriceItemPriceId) 
            {
                m_params.AddOpt("item_prices[item_price_id][" + index + "]", itemPriceItemPriceId);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemPriceQuantity(int index, int itemPriceQuantity) 
            {
                m_params.AddOpt("item_prices[quantity][" + index + "]", itemPriceQuantity);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemPriceQuantityInDecimal(int index, string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_prices[quantity_in_decimal][" + index + "]", itemPriceQuantityInDecimal);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemPriceUnitPrice(int index, int itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_prices[unit_price][" + index + "]", itemPriceUnitPrice);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemPriceUnitPriceInDecimal(int index, string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_prices[unit_price_in_decimal][" + index + "]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemPriceServicePeriodDays(int index, int itemPriceServicePeriodDays) 
            {
                m_params.AddOpt("item_prices[service_period_days][" + index + "]", itemPriceServicePeriodDays);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public EditForChargeItemsAndChargesRequest ChargeServicePeriod(int index, int chargeServicePeriod) 
            {
                m_params.AddOpt("charges[service_period][" + index + "]", chargeServicePeriod);
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
        public class ConvertRequest : EntityRequest<ConvertRequest> 
        {
            public ConvertRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ConvertRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public ConvertRequest CreatePendingInvoices(bool createPendingInvoices) 
            {
                m_params.AddOpt("create_pending_invoices", createPendingInvoices);
                return this;
            }
            public ConvertRequest FirstInvoicePending(bool firstInvoicePending) 
            {
                m_params.AddOpt("first_invoice_pending", firstInvoicePending);
                return this;
            }
            public ConvertRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public ConvertRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public ConvertRequest SubscriptionPoNumber(string subscriptionPoNumber) 
            {
                m_params.AddOpt("subscription[po_number]", subscriptionPoNumber);
                return this;
            }
            public ConvertRequest SubscriptionAutoCloseInvoices(bool subscriptionAutoCloseInvoices) 
            {
                m_params.AddOpt("subscription[auto_close_invoices]", subscriptionAutoCloseInvoices);
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
        public class ExtendExpiryDateRequest : EntityRequest<ExtendExpiryDateRequest> 
        {
            public ExtendExpiryDateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ExtendExpiryDateRequest ValidTill(long validTill) 
            {
                m_params.Add("valid_till", validTill);
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

            public PdfRequest ConsolidatedView(bool consolidatedView) 
            {
                m_params.AddOpt("consolidated_view", consolidatedView);
                return this;
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
                [EnumMember(Value = "plan_item_price")]
                PlanItemPrice,
                [EnumMember(Value = "addon_item_price")]
                AddonItemPrice,
                [EnumMember(Value = "charge_item_price")]
                ChargeItemPrice,
            }

            public string Id {
                get { return GetValue<string>("id", false); }
            }

            public string SubscriptionId {
                get { return GetValue<string>("subscription_id", false); }
            }

            public DateTime DateFrom {
                get { return (DateTime)GetDateTime("date_from", true); }
            }

            public DateTime DateTo {
                get { return (DateTime)GetDateTime("date_to", true); }
            }

            public int UnitAmount {
                get { return GetValue<int>("unit_amount", true); }
            }

            public int? Quantity {
                get { return GetValue<int?>("quantity", false); }
            }

            public int? Amount {
                get { return GetValue<int?>("amount", false); }
            }

            public PricingModelEnum? PricingModel {
                get { return GetEnum<PricingModelEnum>("pricing_model", false); }
            }

            public bool IsTaxed {
                get { return GetValue<bool>("is_taxed", true); }
            }

            public int? TaxAmount {
                get { return GetValue<int?>("tax_amount", false); }
            }

            public double? TaxRate {
                get { return GetValue<double?>("tax_rate", false); }
            }

            public string UnitAmountInDecimal {
                get { return GetValue<string>("unit_amount_in_decimal", false); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string AmountInDecimal {
                get { return GetValue<string>("amount_in_decimal", false); }
            }

            public int? DiscountAmount {
                get { return GetValue<int?>("discount_amount", false); }
            }

            public int? ItemLevelDiscountAmount {
                get { return GetValue<int?>("item_level_discount_amount", false); }
            }

            public string Description {
                get { return GetValue<string>("description", true); }
            }

            public string EntityDescription {
                get { return GetValue<string>("entity_description", true); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public TaxExemptReasonEnum? TaxExemptReason {
                get { return GetEnum<TaxExemptReasonEnum>("tax_exempt_reason", false); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public string CustomerId {
                get { return GetValue<string>("customer_id", false); }
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
                [EnumMember(Value = "item_level_discount")]
                ItemLevelDiscount,
                [EnumMember(Value = "document_level_discount")]
                DocumentLevelDiscount,
            }

            public int Amount {
                get { return GetValue<int>("amount", true); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public string CouponSetCode {
                get { return GetValue<string>("coupon_set_code", false); }
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
                [EnumMember(Value = "item_level_discount")]
                ItemLevelDiscount,
                [EnumMember(Value = "document_level_discount")]
                DocumentLevelDiscount,
            }

            public string LineItemId {
                get { return GetValue<string>("line_item_id", true); }
            }

            public DiscountTypeEnum DiscountType {
                get { return GetEnum<DiscountTypeEnum>("discount_type", true); }
            }

            public string CouponId {
                get { return GetValue<string>("coupon_id", false); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public int DiscountAmount {
                get { return GetValue<int>("discount_amount", true); }
            }

        }
        public class QuoteTax : Resource
        {

            public string Name {
                get { return GetValue<string>("name", true); }
            }

            public int Amount {
                get { return GetValue<int>("amount", true); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

        }
        public class QuoteLineItemTax : Resource
        {

            public string LineItemId {
                get { return GetValue<string>("line_item_id", false); }
            }

            public string TaxName {
                get { return GetValue<string>("tax_name", true); }
            }

            public double TaxRate {
                get { return GetValue<double>("tax_rate", true); }
            }

            public bool? IsPartialTaxApplied {
                get { return GetValue<bool?>("is_partial_tax_applied", false); }
            }

            public bool? IsNonComplianceTax {
                get { return GetValue<bool?>("is_non_compliance_tax", false); }
            }

            public int TaxableAmount {
                get { return GetValue<int>("taxable_amount", true); }
            }

            public int TaxAmount {
                get { return GetValue<int>("tax_amount", true); }
            }

            public TaxJurisTypeEnum? TaxJurisType {
                get { return GetEnum<TaxJurisTypeEnum>("tax_juris_type", false); }
            }

            public string TaxJurisName {
                get { return GetValue<string>("tax_juris_name", false); }
            }

            public string TaxJurisCode {
                get { return GetValue<string>("tax_juris_code", false); }
            }

            public int? TaxAmountInLocalCurrency {
                get { return GetValue<int?>("tax_amount_in_local_currency", false); }
            }

            public string LocalCurrencyCode {
                get { return GetValue<string>("local_currency_code", false); }
            }

        }
        public class QuoteLineItemTier : Resource
        {

            public string LineItemId {
                get { return GetValue<string>("line_item_id", false); }
            }

            public int StartingUnit {
                get { return GetValue<int>("starting_unit", true); }
            }

            public int? EndingUnit {
                get { return GetValue<int?>("ending_unit", false); }
            }

            public int QuantityUsed {
                get { return GetValue<int>("quantity_used", true); }
            }

            public int UnitAmount {
                get { return GetValue<int>("unit_amount", true); }
            }

            public string StartingUnitInDecimal {
                get { return GetValue<string>("starting_unit_in_decimal", false); }
            }

            public string EndingUnitInDecimal {
                get { return GetValue<string>("ending_unit_in_decimal", false); }
            }

            public string QuantityUsedInDecimal {
                get { return GetValue<string>("quantity_used_in_decimal", false); }
            }

            public string UnitAmountInDecimal {
                get { return GetValue<string>("unit_amount_in_decimal", false); }
            }

        }
        public class QuoteShippingAddress : Resource
        {

            public string FirstName {
                get { return GetValue<string>("first_name", false); }
            }

            public string LastName {
                get { return GetValue<string>("last_name", false); }
            }

            public string Email {
                get { return GetValue<string>("email", false); }
            }

            public string Company {
                get { return GetValue<string>("company", false); }
            }

            public string Phone {
                get { return GetValue<string>("phone", false); }
            }

            public string Line1 {
                get { return GetValue<string>("line1", false); }
            }

            public string Line2 {
                get { return GetValue<string>("line2", false); }
            }

            public string Line3 {
                get { return GetValue<string>("line3", false); }
            }

            public string City {
                get { return GetValue<string>("city", false); }
            }

            public string StateCode {
                get { return GetValue<string>("state_code", false); }
            }

            public string State {
                get { return GetValue<string>("state", false); }
            }

            public string Country {
                get { return GetValue<string>("country", false); }
            }

            public string Zip {
                get { return GetValue<string>("zip", false); }
            }

            public ValidationStatusEnum? ValidationStatus {
                get { return GetEnum<ValidationStatusEnum>("validation_status", false); }
            }

        }
        public class QuoteBillingAddress : Resource
        {

            public string FirstName {
                get { return GetValue<string>("first_name", false); }
            }

            public string LastName {
                get { return GetValue<string>("last_name", false); }
            }

            public string Email {
                get { return GetValue<string>("email", false); }
            }

            public string Company {
                get { return GetValue<string>("company", false); }
            }

            public string Phone {
                get { return GetValue<string>("phone", false); }
            }

            public string Line1 {
                get { return GetValue<string>("line1", false); }
            }

            public string Line2 {
                get { return GetValue<string>("line2", false); }
            }

            public string Line3 {
                get { return GetValue<string>("line3", false); }
            }

            public string City {
                get { return GetValue<string>("city", false); }
            }

            public string StateCode {
                get { return GetValue<string>("state_code", false); }
            }

            public string State {
                get { return GetValue<string>("state", false); }
            }

            public string Country {
                get { return GetValue<string>("country", false); }
            }

            public string Zip {
                get { return GetValue<string>("zip", false); }
            }

            public ValidationStatusEnum? ValidationStatus {
                get { return GetEnum<ValidationStatusEnum>("validation_status", false); }
            }

        }

        #endregion
    }
}
