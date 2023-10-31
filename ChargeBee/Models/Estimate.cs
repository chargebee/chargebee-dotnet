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

    public class Estimate : Resource 
    {
    
        public Estimate() { }

        public Estimate(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Estimate(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Estimate(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateSubscriptionRequest CreateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "create_subscription");
            return new CreateSubscriptionRequest(url, HttpMethod.POST);
        }
        public static CreateSubItemEstimateRequest CreateSubItemEstimate()
        {
            string url = ApiUtil.BuildUrl("estimates", "create_subscription_for_items");
            return new CreateSubItemEstimateRequest(url, HttpMethod.POST);
        }
        public static CreateSubForCustomerEstimateRequest CreateSubForCustomerEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "create_subscription_estimate");
            return new CreateSubForCustomerEstimateRequest(url, HttpMethod.GET);
        }
        public static CreateSubItemForCustomerEstimateRequest CreateSubItemForCustomerEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "create_subscription_for_items_estimate");
            return new CreateSubItemForCustomerEstimateRequest(url, HttpMethod.POST);
        }
        public static UpdateSubscriptionRequest UpdateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "update_subscription");
            return new UpdateSubscriptionRequest(url, HttpMethod.POST);
        }
        public static UpdateSubscriptionForItemsRequest UpdateSubscriptionForItems()
        {
            string url = ApiUtil.BuildUrl("estimates", "update_subscription_for_items");
            return new UpdateSubscriptionForItemsRequest(url, HttpMethod.POST);
        }
        public static RenewalEstimateRequest RenewalEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "renewal_estimate");
            return new RenewalEstimateRequest(url, HttpMethod.GET);
        }
        public static AdvanceInvoiceEstimateRequest AdvanceInvoiceEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "advance_invoice_estimate");
            return new AdvanceInvoiceEstimateRequest(url, HttpMethod.POST);
        }
        public static RegenerateInvoiceEstimateRequest RegenerateInvoiceEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "regenerate_invoice_estimate");
            return new RegenerateInvoiceEstimateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> UpcomingInvoicesEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "upcoming_invoices_estimate");
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static ChangeTermEndRequest ChangeTermEnd(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "change_term_end_estimate");
            return new ChangeTermEndRequest(url, HttpMethod.POST);
        }
        public static CancelSubscriptionRequest CancelSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "cancel_subscription_estimate");
            return new CancelSubscriptionRequest(url, HttpMethod.POST);
        }
        public static CancelSubscriptionForItemsRequest CancelSubscriptionForItems(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "cancel_subscription_for_items_estimate");
            return new CancelSubscriptionForItemsRequest(url, HttpMethod.POST);
        }
        public static PauseSubscriptionRequest PauseSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "pause_subscription_estimate");
            return new PauseSubscriptionRequest(url, HttpMethod.POST);
        }
        public static ResumeSubscriptionRequest ResumeSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "resume_subscription_estimate");
            return new ResumeSubscriptionRequest(url, HttpMethod.POST);
        }
        public static GiftSubscriptionRequest GiftSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "gift_subscription");
            return new GiftSubscriptionRequest(url, HttpMethod.POST);
        }
        public static GiftSubscriptionForItemsRequest GiftSubscriptionForItems()
        {
            string url = ApiUtil.BuildUrl("estimates", "gift_subscription_for_items");
            return new GiftSubscriptionForItemsRequest(url, HttpMethod.POST);
        }
        public static CreateInvoiceRequest CreateInvoice()
        {
            string url = ApiUtil.BuildUrl("estimates", "create_invoice");
            return new CreateInvoiceRequest(url, HttpMethod.POST);
        }
        public static CreateInvoiceForItemsRequest CreateInvoiceForItems()
        {
            string url = ApiUtil.BuildUrl("estimates", "create_invoice_for_items");
            return new CreateInvoiceForItemsRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public SubscriptionEstimate SubscriptionEstimate 
        {
            get { return GetSubResource<SubscriptionEstimate>("subscription_estimate"); }
        }
        public List<SubscriptionEstimate> SubscriptionEstimates 
        {
            get { return GetResourceList<SubscriptionEstimate>("subscription_estimates"); }
        }
        public InvoiceEstimate InvoiceEstimate 
        {
            get { return GetSubResource<InvoiceEstimate>("invoice_estimate"); }
        }
        public List<InvoiceEstimate> InvoiceEstimates 
        {
            get { return GetResourceList<InvoiceEstimate>("invoice_estimates"); }
        }
        public InvoiceEstimate NextInvoiceEstimate 
        {
            get { return GetSubResource<InvoiceEstimate>("next_invoice_estimate"); }
        }
        public List<CreditNoteEstimate> CreditNoteEstimates 
        {
            get { return GetResourceList<CreditNoteEstimate>("credit_note_estimates"); }
        }
        public List<UnbilledCharge> UnbilledChargeEstimates 
        {
            get { return GetResourceList<UnbilledCharge>("unbilled_charge_estimates"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateSubscriptionRequest : EntityRequest<CreateSubscriptionRequest> 
        {
            public CreateSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubscriptionRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public CreateSubscriptionRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubscriptionRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubscriptionRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubscriptionRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateSubscriptionRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateSubscriptionRequest ClientProfileId(string clientProfileId) 
            {
                m_params.AddOpt("client_profile_id", clientProfileId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            [Obsolete]
            public CreateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubscriptionRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CreateSubscriptionRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public CreateSubscriptionRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public CreateSubscriptionRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CreateSubscriptionRequest CustomerEntityCode(ChargeBee.Models.Enums.EntityCodeEnum customerEntityCode) 
            {
                m_params.AddOpt("customer[entity_code]", customerEntityCode);
                return this;
            }
            public CreateSubscriptionRequest CustomerExemptNumber(string customerExemptNumber) 
            {
                m_params.AddOpt("customer[exempt_number]", customerExemptNumber);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionFreePeriod(int subscriptionFreePeriod) 
            {
                m_params.AddOpt("subscription[free_period]", subscriptionFreePeriod);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionFreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum subscriptionFreePeriodUnit) 
            {
                m_params.AddOpt("subscription[free_period_unit]", subscriptionFreePeriodUnit);
                return this;
            }
            public CreateSubscriptionRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateSubscriptionRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionTrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum subscriptionTrialEndAction) 
            {
                m_params.AddOpt("subscription[trial_end_action]", subscriptionTrialEndAction);
                return this;
            }
            public CreateSubscriptionRequest CustomerExemptionDetails(JArray customerExemptionDetails) 
            {
                m_params.AddOpt("customer[exemption_details]", customerExemptionDetails);
                return this;
            }
            public CreateSubscriptionRequest CustomerCustomerType(ChargeBee.Models.Enums.CustomerTypeEnum customerCustomerType) 
            {
                m_params.AddOpt("customer[customer_type]", customerCustomerType);
                return this;
            }
            public CreateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateSubscriptionRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateSubscriptionRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateSubscriptionRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CreateSubscriptionRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public CreateSubscriptionRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class CreateSubItemEstimateRequest : EntityRequest<CreateSubItemEstimateRequest> 
        {
            public CreateSubItemEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubItemEstimateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubItemEstimateRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public CreateSubItemEstimateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubItemEstimateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubItemEstimateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateSubItemEstimateRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateSubItemEstimateRequest ClientProfileId(string clientProfileId) 
            {
                m_params.AddOpt("client_profile_id", clientProfileId);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public CreateSubItemEstimateRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            [Obsolete]
            public CreateSubItemEstimateRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CreateSubItemEstimateRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubItemEstimateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerEntityCode(ChargeBee.Models.Enums.EntityCodeEnum customerEntityCode) 
            {
                m_params.AddOpt("customer[entity_code]", customerEntityCode);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerExemptNumber(string customerExemptNumber) 
            {
                m_params.AddOpt("customer[exempt_number]", customerExemptNumber);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionFreePeriod(int subscriptionFreePeriod) 
            {
                m_params.AddOpt("subscription[free_period]", subscriptionFreePeriod);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionFreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum subscriptionFreePeriodUnit) 
            {
                m_params.AddOpt("subscription[free_period_unit]", subscriptionFreePeriodUnit);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerExemptionDetails(JArray customerExemptionDetails) 
            {
                m_params.AddOpt("customer[exemption_details]", customerExemptionDetails);
                return this;
            }
            public CreateSubItemEstimateRequest CustomerCustomerType(ChargeBee.Models.Enums.CustomerTypeEnum customerCustomerType) 
            {
                m_params.AddOpt("customer[customer_type]", customerCustomerType);
                return this;
            }
            public CreateSubItemEstimateRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateSubItemEstimateRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionTrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum subscriptionTrialEndAction) 
            {
                m_params.AddOpt("subscription[trial_end_action]", subscriptionTrialEndAction);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            [Obsolete]
            public CreateSubItemEstimateRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountAmount(int index, int discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CreateSubItemEstimateRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CreateSubItemEstimateRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            public CreateSubItemEstimateRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateSubItemEstimateRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateSubItemEstimateRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateSubItemEstimateRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateSubItemEstimateRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateSubItemEstimateRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateSubItemEstimateRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class CreateSubForCustomerEstimateRequest : EntityRequest<CreateSubForCustomerEstimateRequest> 
        {
            public CreateSubForCustomerEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubForCustomerEstimateRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public CreateSubForCustomerEstimateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateSubForCustomerEstimateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubForCustomerEstimateRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public CreateSubForCustomerEstimateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubForCustomerEstimateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubForCustomerEstimateRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateSubForCustomerEstimateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionFreePeriod(int subscriptionFreePeriod) 
            {
                m_params.AddOpt("subscription[free_period]", subscriptionFreePeriod);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionFreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum subscriptionFreePeriodUnit) 
            {
                m_params.AddOpt("subscription[free_period_unit]", subscriptionFreePeriodUnit);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateSubForCustomerEstimateRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateSubForCustomerEstimateRequest SubscriptionTrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum subscriptionTrialEndAction) 
            {
                m_params.AddOpt("subscription[trial_end_action]", subscriptionTrialEndAction);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CreateSubForCustomerEstimateRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public CreateSubForCustomerEstimateRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class CreateSubItemForCustomerEstimateRequest : EntityRequest<CreateSubItemForCustomerEstimateRequest> 
        {
            public CreateSubItemForCustomerEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubItemForCustomerEstimateRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public CreateSubItemForCustomerEstimateRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionFreePeriod(int subscriptionFreePeriod) 
            {
                m_params.AddOpt("subscription[free_period]", subscriptionFreePeriod);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionFreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum subscriptionFreePeriodUnit) 
            {
                m_params.AddOpt("subscription[free_period_unit]", subscriptionFreePeriodUnit);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ContractTermActionAtTermEnd(ContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionContractTermBillingCycleOnRenewal(int subscriptionContractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("subscription[contract_term_billing_cycle_on_renewal]", subscriptionContractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionTrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum subscriptionTrialEndAction) 
            {
                m_params.AddOpt("subscription[trial_end_action]", subscriptionTrialEndAction);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            [Obsolete]
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountAmount(int index, int discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateSubItemForCustomerEstimateRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class UpdateSubscriptionRequest : EntityRequest<UpdateSubscriptionRequest> 
        {
            public UpdateSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateSubscriptionRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public UpdateSubscriptionRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public UpdateSubscriptionRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public UpdateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateSubscriptionRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public UpdateSubscriptionRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public UpdateSubscriptionRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public UpdateSubscriptionRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public UpdateSubscriptionRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public UpdateSubscriptionRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public UpdateSubscriptionRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public UpdateSubscriptionRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public UpdateSubscriptionRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public UpdateSubscriptionRequest IncludeDelayedCharges(bool includeDelayedCharges) 
            {
                m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
                return this;
            }
            public UpdateSubscriptionRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public UpdateSubscriptionRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanUnitPrice(int subscriptionPlanUnitPrice) 
            {
                m_params.AddOpt("subscription[plan_unit_price]", subscriptionPlanUnitPrice);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanUnitPriceInDecimal(string subscriptionPlanUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription[plan_unit_price_in_decimal]", subscriptionPlanUnitPriceInDecimal);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateSubscriptionRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public UpdateSubscriptionRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionFreePeriod(int subscriptionFreePeriod) 
            {
                m_params.AddOpt("subscription[free_period]", subscriptionFreePeriod);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionFreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum subscriptionFreePeriodUnit) 
            {
                m_params.AddOpt("subscription[free_period_unit]", subscriptionFreePeriodUnit);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionTrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum subscriptionTrialEndAction) 
            {
                m_params.AddOpt("subscription[trial_end_action]", subscriptionTrialEndAction);
                return this;
            }
            public UpdateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public UpdateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public UpdateSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public UpdateSubscriptionRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public UpdateSubscriptionRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public UpdateSubscriptionRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
            public UpdateSubscriptionRequest AddonProrationType(int index, ChargeBee.Models.Enums.ProrationTypeEnum addonProrationType) 
            {
                m_params.AddOpt("addons[proration_type][" + index + "]", addonProrationType);
                return this;
            }
        }
        public class UpdateSubscriptionForItemsRequest : EntityRequest<UpdateSubscriptionForItemsRequest> 
        {
            public UpdateSubscriptionForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateSubscriptionForItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ReplaceItemsList(bool replaceItemsList) 
            {
                m_params.AddOpt("replace_items_list", replaceItemsList);
                return this;
            }
            public UpdateSubscriptionForItemsRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateSubscriptionForItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public UpdateSubscriptionForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public UpdateSubscriptionForItemsRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public UpdateSubscriptionForItemsRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public UpdateSubscriptionForItemsRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public UpdateSubscriptionForItemsRequest IncludeDelayedCharges(bool includeDelayedCharges) 
            {
                m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
                return this;
            }
            public UpdateSubscriptionForItemsRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public UpdateSubscriptionForItemsRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionForItemsRequest SubscriptionSetupFee(int subscriptionSetupFee) 
            {
                m_params.AddOpt("subscription[setup_fee]", subscriptionSetupFee);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionForItemsRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum subscriptionAutoCollection) 
            {
                m_params.AddOpt("subscription[auto_collection]", subscriptionAutoCollection);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum subscriptionOfflinePaymentMethod) 
            {
                m_params.AddOpt("subscription[offline_payment_method]", subscriptionOfflinePaymentMethod);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateSubscriptionForItemsRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateSubscriptionForItemsRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateSubscriptionForItemsRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public UpdateSubscriptionForItemsRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionFreePeriod(int subscriptionFreePeriod) 
            {
                m_params.AddOpt("subscription[free_period]", subscriptionFreePeriod);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionFreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum subscriptionFreePeriodUnit) 
            {
                m_params.AddOpt("subscription[free_period_unit]", subscriptionFreePeriodUnit);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionForItemsRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionTrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum subscriptionTrialEndAction) 
            {
                m_params.AddOpt("subscription[trial_end_action]", subscriptionTrialEndAction);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            public UpdateSubscriptionForItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            [Obsolete]
            public UpdateSubscriptionForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountAmount(int index, int discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountOperationType(int index, ChargeBee.Models.Enums.OperationTypeEnum discountOperationType) 
            {
                m_params.Add("discounts[operation_type][" + index + "]", discountOperationType);
                return this;
            }
            public UpdateSubscriptionForItemsRequest DiscountId(int index, string discountId) 
            {
                m_params.AddOpt("discounts[id][" + index + "]", discountId);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public UpdateSubscriptionForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class RenewalEstimateRequest : EntityRequest<RenewalEstimateRequest> 
        {
            public RenewalEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RenewalEstimateRequest IncludeDelayedCharges(bool includeDelayedCharges) 
            {
                m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
                return this;
            }
            public RenewalEstimateRequest UseExistingBalances(bool useExistingBalances) 
            {
                m_params.AddOpt("use_existing_balances", useExistingBalances);
                return this;
            }
            public RenewalEstimateRequest IgnoreScheduledCancellation(bool ignoreScheduledCancellation) 
            {
                m_params.AddOpt("ignore_scheduled_cancellation", ignoreScheduledCancellation);
                return this;
            }
            public RenewalEstimateRequest IgnoreScheduledChanges(bool ignoreScheduledChanges) 
            {
                m_params.AddOpt("ignore_scheduled_changes", ignoreScheduledChanges);
                return this;
            }
        }
        public class AdvanceInvoiceEstimateRequest : EntityRequest<AdvanceInvoiceEstimateRequest> 
        {
            public AdvanceInvoiceEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AdvanceInvoiceEstimateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public AdvanceInvoiceEstimateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public AdvanceInvoiceEstimateRequest ScheduleType(ChargeBee.Models.Enums.ScheduleTypeEnum scheduleType) 
            {
                m_params.AddOpt("schedule_type", scheduleType);
                return this;
            }
            public AdvanceInvoiceEstimateRequest FixedIntervalScheduleNumberOfOccurrences(int fixedIntervalScheduleNumberOfOccurrences) 
            {
                m_params.AddOpt("fixed_interval_schedule[number_of_occurrences]", fixedIntervalScheduleNumberOfOccurrences);
                return this;
            }
            public AdvanceInvoiceEstimateRequest FixedIntervalScheduleDaysBeforeRenewal(int fixedIntervalScheduleDaysBeforeRenewal) 
            {
                m_params.AddOpt("fixed_interval_schedule[days_before_renewal]", fixedIntervalScheduleDaysBeforeRenewal);
                return this;
            }
            public AdvanceInvoiceEstimateRequest FixedIntervalScheduleEndScheduleOn(ChargeBee.Models.Enums.EndScheduleOnEnum fixedIntervalScheduleEndScheduleOn) 
            {
                m_params.AddOpt("fixed_interval_schedule[end_schedule_on]", fixedIntervalScheduleEndScheduleOn);
                return this;
            }
            public AdvanceInvoiceEstimateRequest FixedIntervalScheduleEndDate(long fixedIntervalScheduleEndDate) 
            {
                m_params.AddOpt("fixed_interval_schedule[end_date]", fixedIntervalScheduleEndDate);
                return this;
            }
            public AdvanceInvoiceEstimateRequest SpecificDatesScheduleTermsToCharge(int index, int specificDatesScheduleTermsToCharge) 
            {
                m_params.AddOpt("specific_dates_schedule[terms_to_charge][" + index + "]", specificDatesScheduleTermsToCharge);
                return this;
            }
            public AdvanceInvoiceEstimateRequest SpecificDatesScheduleDate(int index, long specificDatesScheduleDate) 
            {
                m_params.AddOpt("specific_dates_schedule[date][" + index + "]", specificDatesScheduleDate);
                return this;
            }
        }
        public class RegenerateInvoiceEstimateRequest : EntityRequest<RegenerateInvoiceEstimateRequest> 
        {
            public RegenerateInvoiceEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RegenerateInvoiceEstimateRequest DateFrom(long dateFrom) 
            {
                m_params.AddOpt("date_from", dateFrom);
                return this;
            }
            public RegenerateInvoiceEstimateRequest DateTo(long dateTo) 
            {
                m_params.AddOpt("date_to", dateTo);
                return this;
            }
            public RegenerateInvoiceEstimateRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public RegenerateInvoiceEstimateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
        }
        public class ChangeTermEndRequest : EntityRequest<ChangeTermEndRequest> 
        {
            public ChangeTermEndRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChangeTermEndRequest TermEndsAt(long termEndsAt) 
            {
                m_params.Add("term_ends_at", termEndsAt);
                return this;
            }
            public ChangeTermEndRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public ChangeTermEndRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
        }
        public class CancelSubscriptionRequest : EntityRequest<CancelSubscriptionRequest> 
        {
            public CancelSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CancelSubscriptionRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public CancelSubscriptionRequest CancelAt(long cancelAt) 
            {
                m_params.AddOpt("cancel_at", cancelAt);
                return this;
            }
            public CancelSubscriptionRequest CreditOptionForCurrentTermCharges(ChargeBee.Models.Enums.CreditOptionForCurrentTermChargesEnum creditOptionForCurrentTermCharges) 
            {
                m_params.AddOpt("credit_option_for_current_term_charges", creditOptionForCurrentTermCharges);
                return this;
            }
            public CancelSubscriptionRequest UnbilledChargesOption(ChargeBee.Models.Enums.UnbilledChargesOptionEnum unbilledChargesOption) 
            {
                m_params.AddOpt("unbilled_charges_option", unbilledChargesOption);
                return this;
            }
            public CancelSubscriptionRequest AccountReceivablesHandling(ChargeBee.Models.Enums.AccountReceivablesHandlingEnum accountReceivablesHandling) 
            {
                m_params.AddOpt("account_receivables_handling", accountReceivablesHandling);
                return this;
            }
            public CancelSubscriptionRequest RefundableCreditsHandling(ChargeBee.Models.Enums.RefundableCreditsHandlingEnum refundableCreditsHandling) 
            {
                m_params.AddOpt("refundable_credits_handling", refundableCreditsHandling);
                return this;
            }
            public CancelSubscriptionRequest ContractTermCancelOption(ChargeBee.Models.Enums.ContractTermCancelOptionEnum contractTermCancelOption) 
            {
                m_params.AddOpt("contract_term_cancel_option", contractTermCancelOption);
                return this;
            }
            public CancelSubscriptionRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CancelSubscriptionRequest CancelReasonCode(string cancelReasonCode) 
            {
                m_params.AddOpt("cancel_reason_code", cancelReasonCode);
                return this;
            }
            public CancelSubscriptionRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CancelSubscriptionRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CancelSubscriptionRequest EventBasedAddonUnitPrice(int index, int eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CancelSubscriptionRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
        }
        public class CancelSubscriptionForItemsRequest : EntityRequest<CancelSubscriptionForItemsRequest> 
        {
            public CancelSubscriptionForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CancelSubscriptionForItemsRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public CancelSubscriptionForItemsRequest CancelAt(long cancelAt) 
            {
                m_params.AddOpt("cancel_at", cancelAt);
                return this;
            }
            public CancelSubscriptionForItemsRequest CreditOptionForCurrentTermCharges(ChargeBee.Models.Enums.CreditOptionForCurrentTermChargesEnum creditOptionForCurrentTermCharges) 
            {
                m_params.AddOpt("credit_option_for_current_term_charges", creditOptionForCurrentTermCharges);
                return this;
            }
            public CancelSubscriptionForItemsRequest UnbilledChargesOption(ChargeBee.Models.Enums.UnbilledChargesOptionEnum unbilledChargesOption) 
            {
                m_params.AddOpt("unbilled_charges_option", unbilledChargesOption);
                return this;
            }
            public CancelSubscriptionForItemsRequest AccountReceivablesHandling(ChargeBee.Models.Enums.AccountReceivablesHandlingEnum accountReceivablesHandling) 
            {
                m_params.AddOpt("account_receivables_handling", accountReceivablesHandling);
                return this;
            }
            public CancelSubscriptionForItemsRequest RefundableCreditsHandling(ChargeBee.Models.Enums.RefundableCreditsHandlingEnum refundableCreditsHandling) 
            {
                m_params.AddOpt("refundable_credits_handling", refundableCreditsHandling);
                return this;
            }
            public CancelSubscriptionForItemsRequest ContractTermCancelOption(ChargeBee.Models.Enums.ContractTermCancelOptionEnum contractTermCancelOption) 
            {
                m_params.AddOpt("contract_term_cancel_option", contractTermCancelOption);
                return this;
            }
            public CancelSubscriptionForItemsRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CancelSubscriptionForItemsRequest CancelReasonCode(string cancelReasonCode) 
            {
                m_params.AddOpt("cancel_reason_code", cancelReasonCode);
                return this;
            }
            public CancelSubscriptionForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.AddOpt("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CancelSubscriptionForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CancelSubscriptionForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CancelSubscriptionForItemsRequest SubscriptionItemUnitPrice(int index, int subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CancelSubscriptionForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CancelSubscriptionForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
        }
        public class PauseSubscriptionRequest : EntityRequest<PauseSubscriptionRequest> 
        {
            public PauseSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PauseSubscriptionRequest PauseOption(ChargeBee.Models.Enums.PauseOptionEnum pauseOption) 
            {
                m_params.AddOpt("pause_option", pauseOption);
                return this;
            }
            public PauseSubscriptionRequest UnbilledChargesHandling(ChargeBee.Models.Enums.UnbilledChargesHandlingEnum unbilledChargesHandling) 
            {
                m_params.AddOpt("unbilled_charges_handling", unbilledChargesHandling);
                return this;
            }
            public PauseSubscriptionRequest SubscriptionPauseDate(long subscriptionPauseDate) 
            {
                m_params.AddOpt("subscription[pause_date]", subscriptionPauseDate);
                return this;
            }
            public PauseSubscriptionRequest SubscriptionResumeDate(long subscriptionResumeDate) 
            {
                m_params.AddOpt("subscription[resume_date]", subscriptionResumeDate);
                return this;
            }
            public PauseSubscriptionRequest SubscriptionSkipBillingCycles(int subscriptionSkipBillingCycles) 
            {
                m_params.AddOpt("subscription[skip_billing_cycles]", subscriptionSkipBillingCycles);
                return this;
            }
        }
        public class ResumeSubscriptionRequest : EntityRequest<ResumeSubscriptionRequest> 
        {
            public ResumeSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ResumeSubscriptionRequest ResumeOption(ChargeBee.Models.Enums.ResumeOptionEnum resumeOption) 
            {
                m_params.AddOpt("resume_option", resumeOption);
                return this;
            }
            public ResumeSubscriptionRequest ChargesHandling(ChargeBee.Models.Enums.ChargesHandlingEnum chargesHandling) 
            {
                m_params.AddOpt("charges_handling", chargesHandling);
                return this;
            }
            public ResumeSubscriptionRequest SubscriptionResumeDate(long subscriptionResumeDate) 
            {
                m_params.AddOpt("subscription[resume_date]", subscriptionResumeDate);
                return this;
            }
        }
        public class GiftSubscriptionRequest : EntityRequest<GiftSubscriptionRequest> 
        {
            public GiftSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public GiftSubscriptionRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public GiftSubscriptionRequest GiftScheduledAt(long giftScheduledAt) 
            {
                m_params.AddOpt("gift[scheduled_at]", giftScheduledAt);
                return this;
            }
            public GiftSubscriptionRequest GiftAutoClaim(bool giftAutoClaim) 
            {
                m_params.AddOpt("gift[auto_claim]", giftAutoClaim);
                return this;
            }
            public GiftSubscriptionRequest GiftNoExpiry(bool giftNoExpiry) 
            {
                m_params.AddOpt("gift[no_expiry]", giftNoExpiry);
                return this;
            }
            public GiftSubscriptionRequest GiftClaimExpiryDate(long giftClaimExpiryDate) 
            {
                m_params.AddOpt("gift[claim_expiry_date]", giftClaimExpiryDate);
                return this;
            }
            public GiftSubscriptionRequest GifterCustomerId(string gifterCustomerId) 
            {
                m_params.Add("gifter[customer_id]", gifterCustomerId);
                return this;
            }
            public GiftSubscriptionRequest GifterSignature(string gifterSignature) 
            {
                m_params.Add("gifter[signature]", gifterSignature);
                return this;
            }
            public GiftSubscriptionRequest GifterNote(string gifterNote) 
            {
                m_params.AddOpt("gifter[note]", gifterNote);
                return this;
            }
            public GiftSubscriptionRequest GifterPaymentSrcId(string gifterPaymentSrcId) 
            {
                m_params.AddOpt("gifter[payment_src_id]", gifterPaymentSrcId);
                return this;
            }
            public GiftSubscriptionRequest GiftReceiverCustomerId(string giftReceiverCustomerId) 
            {
                m_params.Add("gift_receiver[customer_id]", giftReceiverCustomerId);
                return this;
            }
            public GiftSubscriptionRequest GiftReceiverFirstName(string giftReceiverFirstName) 
            {
                m_params.Add("gift_receiver[first_name]", giftReceiverFirstName);
                return this;
            }
            public GiftSubscriptionRequest GiftReceiverLastName(string giftReceiverLastName) 
            {
                m_params.Add("gift_receiver[last_name]", giftReceiverLastName);
                return this;
            }
            public GiftSubscriptionRequest GiftReceiverEmail(string giftReceiverEmail) 
            {
                m_params.Add("gift_receiver[email]", giftReceiverEmail);
                return this;
            }
            public GiftSubscriptionRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public GiftSubscriptionRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public GiftSubscriptionRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public GiftSubscriptionRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public GiftSubscriptionRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public GiftSubscriptionRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public GiftSubscriptionRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public GiftSubscriptionRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public GiftSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public GiftSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public GiftSubscriptionRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public GiftSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public GiftSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public GiftSubscriptionRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
        }
        public class GiftSubscriptionForItemsRequest : EntityRequest<GiftSubscriptionForItemsRequest> 
        {
            public GiftSubscriptionForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public GiftSubscriptionForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftScheduledAt(long giftScheduledAt) 
            {
                m_params.AddOpt("gift[scheduled_at]", giftScheduledAt);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftAutoClaim(bool giftAutoClaim) 
            {
                m_params.AddOpt("gift[auto_claim]", giftAutoClaim);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftNoExpiry(bool giftNoExpiry) 
            {
                m_params.AddOpt("gift[no_expiry]", giftNoExpiry);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftClaimExpiryDate(long giftClaimExpiryDate) 
            {
                m_params.AddOpt("gift[claim_expiry_date]", giftClaimExpiryDate);
                return this;
            }
            public GiftSubscriptionForItemsRequest GifterCustomerId(string gifterCustomerId) 
            {
                m_params.Add("gifter[customer_id]", gifterCustomerId);
                return this;
            }
            public GiftSubscriptionForItemsRequest GifterSignature(string gifterSignature) 
            {
                m_params.Add("gifter[signature]", gifterSignature);
                return this;
            }
            public GiftSubscriptionForItemsRequest GifterNote(string gifterNote) 
            {
                m_params.AddOpt("gifter[note]", gifterNote);
                return this;
            }
            public GiftSubscriptionForItemsRequest GifterPaymentSrcId(string gifterPaymentSrcId) 
            {
                m_params.AddOpt("gifter[payment_src_id]", gifterPaymentSrcId);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftReceiverCustomerId(string giftReceiverCustomerId) 
            {
                m_params.Add("gift_receiver[customer_id]", giftReceiverCustomerId);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftReceiverFirstName(string giftReceiverFirstName) 
            {
                m_params.Add("gift_receiver[first_name]", giftReceiverFirstName);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftReceiverLastName(string giftReceiverLastName) 
            {
                m_params.Add("gift_receiver[last_name]", giftReceiverLastName);
                return this;
            }
            public GiftSubscriptionForItemsRequest GiftReceiverEmail(string giftReceiverEmail) 
            {
                m_params.Add("gift_receiver[email]", giftReceiverEmail);
                return this;
            }
            public GiftSubscriptionForItemsRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public GiftSubscriptionForItemsRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public GiftSubscriptionForItemsRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public GiftSubscriptionForItemsRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public GiftSubscriptionForItemsRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public GiftSubscriptionForItemsRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public GiftSubscriptionForItemsRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public GiftSubscriptionForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public GiftSubscriptionForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.AddOpt("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public GiftSubscriptionForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public GiftSubscriptionForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
        }
        public class CreateInvoiceRequest : EntityRequest<CreateInvoiceRequest> 
        {
            public CreateInvoiceRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateInvoiceRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateInvoiceRequest InvoiceNote(string invoiceNote) 
            {
                m_params.AddOpt("invoice_note", invoiceNote);
                return this;
            }
            public CreateInvoiceRequest RemoveGeneralNote(bool removeGeneralNote) 
            {
                m_params.AddOpt("remove_general_note", removeGeneralNote);
                return this;
            }
            [Obsolete]
            public CreateInvoiceRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateInvoiceRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateInvoiceRequest AuthorizationTransactionId(string authorizationTransactionId) 
            {
                m_params.AddOpt("authorization_transaction_id", authorizationTransactionId);
                return this;
            }
            public CreateInvoiceRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateInvoiceRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateInvoiceRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateInvoiceRequest InvoiceCustomerId(string invoiceCustomerId) 
            {
                m_params.AddOpt("invoice[customer_id]", invoiceCustomerId);
                return this;
            }
            public CreateInvoiceRequest InvoiceSubscriptionId(string invoiceSubscriptionId) 
            {
                m_params.AddOpt("invoice[subscription_id]", invoiceSubscriptionId);
                return this;
            }
            public CreateInvoiceRequest InvoicePoNumber(string invoicePoNumber) 
            {
                m_params.AddOpt("invoice[po_number]", invoicePoNumber);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateInvoiceRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateInvoiceRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateInvoiceRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateInvoiceRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateInvoiceRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateInvoiceRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateInvoiceRequest AddonDateFrom(int index, long addonDateFrom) 
            {
                m_params.AddOpt("addons[date_from][" + index + "]", addonDateFrom);
                return this;
            }
            public CreateInvoiceRequest AddonDateTo(int index, long addonDateTo) 
            {
                m_params.AddOpt("addons[date_to][" + index + "]", addonDateTo);
                return this;
            }
            public CreateInvoiceRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateInvoiceRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CreateInvoiceRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateInvoiceRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CreateInvoiceRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CreateInvoiceRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CreateInvoiceRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CreateInvoiceRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CreateInvoiceRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateInvoiceRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateInvoiceRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateInvoiceRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CreateInvoiceRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
            public CreateInvoiceRequest NotesToRemoveEntityType(int index, ChargeBee.Models.Enums.EntityTypeEnum notesToRemoveEntityType) 
            {
                m_params.AddOpt("notes_to_remove[entity_type][" + index + "]", notesToRemoveEntityType);
                return this;
            }
            public CreateInvoiceRequest NotesToRemoveEntityId(int index, string notesToRemoveEntityId) 
            {
                m_params.AddOpt("notes_to_remove[entity_id][" + index + "]", notesToRemoveEntityId);
                return this;
            }
        }
        public class CreateInvoiceForItemsRequest : EntityRequest<CreateInvoiceForItemsRequest> 
        {
            public CreateInvoiceForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateInvoiceForItemsRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateInvoiceForItemsRequest InvoiceNote(string invoiceNote) 
            {
                m_params.AddOpt("invoice_note", invoiceNote);
                return this;
            }
            public CreateInvoiceForItemsRequest RemoveGeneralNote(bool removeGeneralNote) 
            {
                m_params.AddOpt("remove_general_note", removeGeneralNote);
                return this;
            }
            [Obsolete]
            public CreateInvoiceForItemsRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateInvoiceForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateInvoiceForItemsRequest AuthorizationTransactionId(string authorizationTransactionId) 
            {
                m_params.AddOpt("authorization_transaction_id", authorizationTransactionId);
                return this;
            }
            public CreateInvoiceForItemsRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateInvoiceForItemsRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateInvoiceForItemsRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateInvoiceForItemsRequest InvoiceCustomerId(string invoiceCustomerId) 
            {
                m_params.AddOpt("invoice[customer_id]", invoiceCustomerId);
                return this;
            }
            public CreateInvoiceForItemsRequest InvoiceSubscriptionId(string invoiceSubscriptionId) 
            {
                m_params.AddOpt("invoice[subscription_id]", invoiceSubscriptionId);
                return this;
            }
            public CreateInvoiceForItemsRequest InvoicePoNumber(string invoicePoNumber) 
            {
                m_params.AddOpt("invoice[po_number]", invoicePoNumber);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateInvoiceForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemPriceItemPriceId(int index, string itemPriceItemPriceId) 
            {
                m_params.AddOpt("item_prices[item_price_id][" + index + "]", itemPriceItemPriceId);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemPriceQuantity(int index, int itemPriceQuantity) 
            {
                m_params.AddOpt("item_prices[quantity][" + index + "]", itemPriceQuantity);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemPriceQuantityInDecimal(int index, string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_prices[quantity_in_decimal][" + index + "]", itemPriceQuantityInDecimal);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemPriceUnitPrice(int index, int itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_prices[unit_price][" + index + "]", itemPriceUnitPrice);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemPriceUnitPriceInDecimal(int index, string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_prices[unit_price_in_decimal][" + index + "]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemPriceDateFrom(int index, long itemPriceDateFrom) 
            {
                m_params.AddOpt("item_prices[date_from][" + index + "]", itemPriceDateFrom);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemPriceDateTo(int index, long itemPriceDateTo) 
            {
                m_params.AddOpt("item_prices[date_to][" + index + "]", itemPriceDateTo);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateInvoiceForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CreateInvoiceForItemsRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
            public CreateInvoiceForItemsRequest NotesToRemoveEntityType(int index, ChargeBee.Models.Enums.EntityTypeEnum notesToRemoveEntityType) 
            {
                m_params.AddOpt("notes_to_remove[entity_type][" + index + "]", notesToRemoveEntityType);
                return this;
            }
            public CreateInvoiceForItemsRequest NotesToRemoveEntityId(int index, string notesToRemoveEntityId) 
            {
                m_params.AddOpt("notes_to_remove[entity_id][" + index + "]", notesToRemoveEntityId);
                return this;
            }
            public CreateInvoiceForItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateInvoiceForItemsRequest DiscountAmount(int index, int discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateInvoiceForItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CreateInvoiceForItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
