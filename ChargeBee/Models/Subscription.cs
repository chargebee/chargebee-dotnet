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

    public class Subscription : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("subscriptions");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static CreateForCustomerRequest CreateForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "subscriptions");
            return new CreateForCustomerRequest(url, HttpMethod.POST);
        }
        public static SubscriptionListRequest List()
        {
            string url = ApiUtil.BuildUrl("subscriptions");
            return new SubscriptionListRequest(url);
        }
        [Obsolete]
        public static ListRequest SubscriptionsForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "subscriptions");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> RetrieveWithScheduledChanges(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "retrieve_with_scheduled_changes");
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> RemoveScheduledChanges(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "remove_scheduled_changes");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static RemoveScheduledCancellationRequest RemoveScheduledCancellation(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "remove_scheduled_cancellation");
            return new RemoveScheduledCancellationRequest(url, HttpMethod.POST);
        }
        public static RemoveCouponsRequest RemoveCoupons(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "remove_coupons");
            return new RemoveCouponsRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static ChangeTermEndRequest ChangeTermEnd(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "change_term_end");
            return new ChangeTermEndRequest(url, HttpMethod.POST);
        }
        public static CancelRequest Cancel(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "cancel");
            return new CancelRequest(url, HttpMethod.POST);
        }
        public static ReactivateRequest Reactivate(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "reactivate");
            return new ReactivateRequest(url, HttpMethod.POST);
        }
        public static AddChargeAtTermEndRequest AddChargeAtTermEnd(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "add_charge_at_term_end");
            return new AddChargeAtTermEndRequest(url, HttpMethod.POST);
        }
        public static ChargeAddonAtTermEndRequest ChargeAddonAtTermEnd(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "charge_addon_at_term_end");
            return new ChargeAddonAtTermEndRequest(url, HttpMethod.POST);
        }
        public static ChargeFutureRenewalsRequest ChargeFutureRenewals(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "charge_future_renewals");
            return new ChargeFutureRenewalsRequest(url, HttpMethod.POST);
        }
        public static ImportSubscriptionRequest ImportSubscription()
        {
            string url = ApiUtil.BuildUrl("subscriptions", "import_subscription");
            return new ImportSubscriptionRequest(url, HttpMethod.POST);
        }
        public static ImportForCustomerRequest ImportForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "import_subscription");
            return new ImportForCustomerRequest(url, HttpMethod.POST);
        }
        public static OverrideBillingProfileRequest OverrideBillingProfile(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "override_billing_profile");
            return new OverrideBillingProfileRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public string PlanId 
        {
            get { return GetValue<string>("plan_id", true); }
        }
        public int PlanQuantity 
        {
            get { return GetValue<int>("plan_quantity", true); }
        }
        public int? PlanUnitPrice 
        {
            get { return GetValue<int?>("plan_unit_price", false); }
        }
        public int? SetupFee 
        {
            get { return GetValue<int?>("setup_fee", false); }
        }
        public int? BillingPeriod 
        {
            get { return GetValue<int?>("billing_period", false); }
        }
        public BillingPeriodUnitEnum? BillingPeriodUnit 
        {
            get { return GetEnum<BillingPeriodUnitEnum>("billing_period_unit", false); }
        }
        public int? PlanFreeQuantity 
        {
            get { return GetValue<int?>("plan_free_quantity", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? StartDate 
        {
            get { return GetDateTime("start_date", false); }
        }
        public DateTime? TrialStart 
        {
            get { return GetDateTime("trial_start", false); }
        }
        public DateTime? TrialEnd 
        {
            get { return GetDateTime("trial_end", false); }
        }
        public DateTime? CurrentTermStart 
        {
            get { return GetDateTime("current_term_start", false); }
        }
        public DateTime? CurrentTermEnd 
        {
            get { return GetDateTime("current_term_end", false); }
        }
        public DateTime? NextBillingAt 
        {
            get { return GetDateTime("next_billing_at", false); }
        }
        public int? RemainingBillingCycles 
        {
            get { return GetValue<int?>("remaining_billing_cycles", false); }
        }
        public string PoNumber 
        {
            get { return GetValue<string>("po_number", false); }
        }
        public DateTime? CreatedAt 
        {
            get { return GetDateTime("created_at", false); }
        }
        public DateTime? StartedAt 
        {
            get { return GetDateTime("started_at", false); }
        }
        public DateTime? ActivatedAt 
        {
            get { return GetDateTime("activated_at", false); }
        }
        public DateTime? CancelledAt 
        {
            get { return GetDateTime("cancelled_at", false); }
        }
        public CancelReasonEnum? CancelReason 
        {
            get { return GetEnum<CancelReasonEnum>("cancel_reason", false); }
        }
        public string AffiliateToken 
        {
            get { return GetValue<string>("affiliate_token", false); }
        }
        public string CreatedFromIp 
        {
            get { return GetValue<string>("created_from_ip", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public bool HasScheduledChanges 
        {
            get { return GetValue<bool>("has_scheduled_changes", true); }
        }
        public string PaymentSourceId 
        {
            get { return GetValue<string>("payment_source_id", false); }
        }
        public AutoCollectionEnum? AutoCollection 
        {
            get { return GetEnum<AutoCollectionEnum>("auto_collection", false); }
        }
        public int? DueInvoicesCount 
        {
            get { return GetValue<int?>("due_invoices_count", false); }
        }
        public DateTime? DueSince 
        {
            get { return GetDateTime("due_since", false); }
        }
        public int? TotalDues 
        {
            get { return GetValue<int?>("total_dues", false); }
        }
        public int? Mrr 
        {
            get { return GetValue<int?>("mrr", false); }
        }
        public decimal? ExchangeRate 
        {
            get { return GetValue<decimal?>("exchange_rate", false); }
        }
        public string BaseCurrencyCode 
        {
            get { return GetValue<string>("base_currency_code", false); }
        }
        public List<SubscriptionAddon> Addons 
        {
            get { return GetResourceList<SubscriptionAddon>("addons"); }
        }
        [Obsolete]
        public string Coupon 
        {
            get { return GetValue<string>("coupon", false); }
        }
        public List<SubscriptionCoupon> Coupons 
        {
            get { return GetResourceList<SubscriptionCoupon>("coupons"); }
        }
        public SubscriptionShippingAddress ShippingAddress 
        {
            get { return GetSubResource<SubscriptionShippingAddress>("shipping_address"); }
        }
        public SubscriptionReferralInfo ReferralInfo 
        {
            get { return GetSubResource<SubscriptionReferralInfo>("referral_info"); }
        }
        public string InvoiceNotes 
        {
            get { return GetValue<string>("invoice_notes", false); }
        }
        public JToken MetaData 
        {
            get { return GetJToken("meta_data", false); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CreateRequest PlanId(string planId) 
            {
                m_params.Add("plan_id", planId);
                return this;
            }
            public CreateRequest PlanQuantity(int planQuantity) 
            {
                m_params.AddOpt("plan_quantity", planQuantity);
                return this;
            }
            public CreateRequest PlanUnitPrice(int planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public CreateRequest SetupFee(int setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public CreateRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            public CreateRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public CreateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            [Obsolete]
            public CreateRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateRequest AffiliateToken(string affiliateToken) 
            {
                m_params.AddOpt("affiliate_token", affiliateToken);
                return this;
            }
            [Obsolete]
            public CreateRequest CreatedFromIp(string createdFromIp) 
            {
                m_params.AddOpt("created_from_ip", createdFromIp);
                return this;
            }
            public CreateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public CreateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public CreateRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public CreateRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public CreateRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public CreateRequest CustomerCompany(string customerCompany) 
            {
                m_params.AddOpt("customer[company]", customerCompany);
                return this;
            }
            public CreateRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CreateRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public CreateRequest CustomerEntityCode(ChargeBee.Models.Enums.EntityCodeEnum customerEntityCode) 
            {
                m_params.AddOpt("customer[entity_code]", customerEntityCode);
                return this;
            }
            public CreateRequest CustomerExemptNumber(string customerExemptNumber) 
            {
                m_params.AddOpt("customer[exempt_number]", customerExemptNumber);
                return this;
            }
            public CreateRequest CustomerNetTermDays(int customerNetTermDays) 
            {
                m_params.AddOpt("customer[net_term_days]", customerNetTermDays);
                return this;
            }
            public CreateRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CreateRequest CustomerAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum customerAutoCollection) 
            {
                m_params.AddOpt("customer[auto_collection]", customerAutoCollection);
                return this;
            }
            public CreateRequest CustomerAllowDirectDebit(bool customerAllowDirectDebit) 
            {
                m_params.AddOpt("customer[allow_direct_debit]", customerAllowDirectDebit);
                return this;
            }
            public CreateRequest CustomerConsolidatedInvoicing(bool customerConsolidatedInvoicing) 
            {
                m_params.AddOpt("customer[consolidated_invoicing]", customerConsolidatedInvoicing);
                return this;
            }
            [Obsolete]
            public CreateRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CreateRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            [Obsolete]
            public CreateRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public CreateRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            [Obsolete]
            public CreateRequest PaymentMethodGateway(ChargeBee.Models.Enums.GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public CreateRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public CreateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public CreateRequest PaymentMethodTmpToken(string paymentMethodTmpToken) 
            {
                m_params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
                return this;
            }
            public CreateRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public CreateRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public CreateRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public CreateRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public CreateRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public CreateRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public CreateRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public CreateRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public CreateRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public CreateRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public CreateRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public CreateRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public CreateRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            [Obsolete]
            public CreateRequest CardIpAddress(string cardIpAddress) 
            {
                m_params.AddOpt("card[ip_address]", cardIpAddress);
                return this;
            }
            public CreateRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CreateRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CreateRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CreateRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CreateRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CreateRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CreateRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CreateRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CreateRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CreateRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class CreateForCustomerRequest : EntityRequest<CreateForCustomerRequest> 
        {
            public CreateForCustomerRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForCustomerRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CreateForCustomerRequest PlanId(string planId) 
            {
                m_params.Add("plan_id", planId);
                return this;
            }
            public CreateForCustomerRequest PlanQuantity(int planQuantity) 
            {
                m_params.AddOpt("plan_quantity", planQuantity);
                return this;
            }
            public CreateForCustomerRequest PlanUnitPrice(int planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public CreateForCustomerRequest SetupFee(int setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public CreateForCustomerRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            public CreateForCustomerRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public CreateForCustomerRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            [Obsolete]
            public CreateForCustomerRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateForCustomerRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateForCustomerRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateForCustomerRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateForCustomerRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateForCustomerRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateForCustomerRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateForCustomerRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateForCustomerRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public CreateForCustomerRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateForCustomerRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateForCustomerRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateForCustomerRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateForCustomerRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateForCustomerRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
        }
        public class SubscriptionListRequest : ListRequestBase<SubscriptionListRequest> 
        {
            public SubscriptionListRequest(string url) 
                    : base(url)
            {
            }

            public SubscriptionListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public StringFilter<SubscriptionListRequest> Id() 
            {
                return new StringFilter<SubscriptionListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<SubscriptionListRequest> CustomerId() 
            {
                return new StringFilter<SubscriptionListRequest>("customer_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<SubscriptionListRequest> PlanId() 
            {
                return new StringFilter<SubscriptionListRequest>("plan_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Subscription.StatusEnum, SubscriptionListRequest> Status() 
            {
                return new EnumFilter<Subscription.StatusEnum, SubscriptionListRequest>("status", this);        
            }
            public EnumFilter<Subscription.CancelReasonEnum, SubscriptionListRequest> CancelReason() 
            {
                return new EnumFilter<Subscription.CancelReasonEnum, SubscriptionListRequest>("cancel_reason", this).SupportsPresenceOperator(true);        
            }
            public NumberFilter<int, SubscriptionListRequest> RemainingBillingCycles() 
            {
                return new NumberFilter<int, SubscriptionListRequest>("remaining_billing_cycles", this).SupportsPresenceOperator(true);        
            }
            public TimestampFilter<SubscriptionListRequest> CreatedAt() 
            {
                return new TimestampFilter<SubscriptionListRequest>("created_at", this);        
            }
            public TimestampFilter<SubscriptionListRequest> ActivatedAt() 
            {
                return new TimestampFilter<SubscriptionListRequest>("activated_at", this).SupportsPresenceOperator(true);        
            }
            public TimestampFilter<SubscriptionListRequest> NextBillingAt() 
            {
                return new TimestampFilter<SubscriptionListRequest>("next_billing_at", this);        
            }
            public TimestampFilter<SubscriptionListRequest> CancelledAt() 
            {
                return new TimestampFilter<SubscriptionListRequest>("cancelled_at", this);        
            }
            public BooleanFilter<SubscriptionListRequest> HasScheduledChanges() 
            {
                return new BooleanFilter<SubscriptionListRequest>("has_scheduled_changes", this);        
            }
            public TimestampFilter<SubscriptionListRequest> UpdatedAt() 
            {
                return new TimestampFilter<SubscriptionListRequest>("updated_at", this);        
            }
            public SubscriptionListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
        }
        public class RemoveScheduledCancellationRequest : EntityRequest<RemoveScheduledCancellationRequest> 
        {
            public RemoveScheduledCancellationRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemoveScheduledCancellationRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
        }
        public class RemoveCouponsRequest : EntityRequest<RemoveCouponsRequest> 
        {
            public RemoveCouponsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemoveCouponsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest PlanId(string planId) 
            {
                m_params.AddOpt("plan_id", planId);
                return this;
            }
            public UpdateRequest PlanQuantity(int planQuantity) 
            {
                m_params.AddOpt("plan_quantity", planQuantity);
                return this;
            }
            public UpdateRequest PlanUnitPrice(int planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public UpdateRequest SetupFee(int setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public UpdateRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            public UpdateRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public UpdateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            [Obsolete]
            public UpdateRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public UpdateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public UpdateRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public UpdateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public UpdateRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public UpdateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public UpdateRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public UpdateRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public UpdateRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public UpdateRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public UpdateRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public UpdateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public UpdateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public UpdateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            [Obsolete]
            public UpdateRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public UpdateRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            [Obsolete]
            public UpdateRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public UpdateRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            [Obsolete]
            public UpdateRequest PaymentMethodGateway(ChargeBee.Models.Enums.GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public UpdateRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public UpdateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public UpdateRequest PaymentMethodTmpToken(string paymentMethodTmpToken) 
            {
                m_params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
                return this;
            }
            public UpdateRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public UpdateRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public UpdateRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public UpdateRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public UpdateRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public UpdateRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public UpdateRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public UpdateRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public UpdateRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public UpdateRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public UpdateRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public UpdateRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public UpdateRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            [Obsolete]
            public UpdateRequest CardIpAddress(string cardIpAddress) 
            {
                m_params.AddOpt("card[ip_address]", cardIpAddress);
                return this;
            }
            public UpdateRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public UpdateRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public UpdateRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public UpdateRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public UpdateRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public UpdateRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public UpdateRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public UpdateRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public UpdateRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public UpdateRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public UpdateRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public UpdateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public UpdateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public UpdateRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public UpdateRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public UpdateRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
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
        public class CancelRequest : EntityRequest<CancelRequest> 
        {
            public CancelRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CancelRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public CancelRequest CreditOptionForCurrentTermCharges(ChargeBee.Models.Enums.CreditOptionForCurrentTermChargesEnum creditOptionForCurrentTermCharges) 
            {
                m_params.AddOpt("credit_option_for_current_term_charges", creditOptionForCurrentTermCharges);
                return this;
            }
            public CancelRequest UnbilledChargesOption(ChargeBee.Models.Enums.UnbilledChargesOptionEnum unbilledChargesOption) 
            {
                m_params.AddOpt("unbilled_charges_option", unbilledChargesOption);
                return this;
            }
            public CancelRequest AccountReceivablesHandling(ChargeBee.Models.Enums.AccountReceivablesHandlingEnum accountReceivablesHandling) 
            {
                m_params.AddOpt("account_receivables_handling", accountReceivablesHandling);
                return this;
            }
            public CancelRequest RefundableCreditsHandling(ChargeBee.Models.Enums.RefundableCreditsHandlingEnum refundableCreditsHandling) 
            {
                m_params.AddOpt("refundable_credits_handling", refundableCreditsHandling);
                return this;
            }
        }
        public class ReactivateRequest : EntityRequest<ReactivateRequest> 
        {
            public ReactivateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ReactivateRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public ReactivateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            [Obsolete]
            public ReactivateRequest TrialPeriodDays(int trialPeriodDays) 
            {
                m_params.AddOpt("trial_period_days", trialPeriodDays);
                return this;
            }
            public ReactivateRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public ReactivateRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public ReactivateRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public ReactivateRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
        }
        public class AddChargeAtTermEndRequest : EntityRequest<AddChargeAtTermEndRequest> 
        {
            public AddChargeAtTermEndRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddChargeAtTermEndRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public AddChargeAtTermEndRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
        }
        public class ChargeAddonAtTermEndRequest : EntityRequest<ChargeAddonAtTermEndRequest> 
        {
            public ChargeAddonAtTermEndRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeAddonAtTermEndRequest AddonId(string addonId) 
            {
                m_params.Add("addon_id", addonId);
                return this;
            }
            public ChargeAddonAtTermEndRequest AddonQuantity(int addonQuantity) 
            {
                m_params.AddOpt("addon_quantity", addonQuantity);
                return this;
            }
            public ChargeAddonAtTermEndRequest AddonUnitPrice(int addonUnitPrice) 
            {
                m_params.AddOpt("addon_unit_price", addonUnitPrice);
                return this;
            }
        }
        public class ChargeFutureRenewalsRequest : EntityRequest<ChargeFutureRenewalsRequest> 
        {
            public ChargeFutureRenewalsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeFutureRenewalsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
        }
        public class ImportSubscriptionRequest : EntityRequest<ImportSubscriptionRequest> 
        {
            public ImportSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportSubscriptionRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public ImportSubscriptionRequest PlanId(string planId) 
            {
                m_params.Add("plan_id", planId);
                return this;
            }
            public ImportSubscriptionRequest PlanQuantity(int planQuantity) 
            {
                m_params.AddOpt("plan_quantity", planQuantity);
                return this;
            }
            public ImportSubscriptionRequest PlanUnitPrice(int planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public ImportSubscriptionRequest SetupFee(int setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public ImportSubscriptionRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            public ImportSubscriptionRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public ImportSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public ImportSubscriptionRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public ImportSubscriptionRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public ImportSubscriptionRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public ImportSubscriptionRequest Status(Subscription.StatusEnum status) 
            {
                m_params.Add("status", status);
                return this;
            }
            public ImportSubscriptionRequest CurrentTermEnd(long currentTermEnd) 
            {
                m_params.AddOpt("current_term_end", currentTermEnd);
                return this;
            }
            public ImportSubscriptionRequest CurrentTermStart(long currentTermStart) 
            {
                m_params.AddOpt("current_term_start", currentTermStart);
                return this;
            }
            public ImportSubscriptionRequest TrialStart(long trialStart) 
            {
                m_params.AddOpt("trial_start", trialStart);
                return this;
            }
            public ImportSubscriptionRequest CancelledAt(long cancelledAt) 
            {
                m_params.AddOpt("cancelled_at", cancelledAt);
                return this;
            }
            public ImportSubscriptionRequest StartedAt(long startedAt) 
            {
                m_params.AddOpt("started_at", startedAt);
                return this;
            }
            public ImportSubscriptionRequest AffiliateToken(string affiliateToken) 
            {
                m_params.AddOpt("affiliate_token", affiliateToken);
                return this;
            }
            public ImportSubscriptionRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public ImportSubscriptionRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public ImportSubscriptionRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public ImportSubscriptionRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public ImportSubscriptionRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public ImportSubscriptionRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public ImportSubscriptionRequest CustomerCompany(string customerCompany) 
            {
                m_params.AddOpt("customer[company]", customerCompany);
                return this;
            }
            public ImportSubscriptionRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public ImportSubscriptionRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public ImportSubscriptionRequest CustomerEntityCode(ChargeBee.Models.Enums.EntityCodeEnum customerEntityCode) 
            {
                m_params.AddOpt("customer[entity_code]", customerEntityCode);
                return this;
            }
            public ImportSubscriptionRequest CustomerExemptNumber(string customerExemptNumber) 
            {
                m_params.AddOpt("customer[exempt_number]", customerExemptNumber);
                return this;
            }
            public ImportSubscriptionRequest CustomerNetTermDays(int customerNetTermDays) 
            {
                m_params.AddOpt("customer[net_term_days]", customerNetTermDays);
                return this;
            }
            public ImportSubscriptionRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public ImportSubscriptionRequest CustomerAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum customerAutoCollection) 
            {
                m_params.AddOpt("customer[auto_collection]", customerAutoCollection);
                return this;
            }
            public ImportSubscriptionRequest CustomerAllowDirectDebit(bool customerAllowDirectDebit) 
            {
                m_params.AddOpt("customer[allow_direct_debit]", customerAllowDirectDebit);
                return this;
            }
            [Obsolete]
            public ImportSubscriptionRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public ImportSubscriptionRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            [Obsolete]
            public ImportSubscriptionRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public ImportSubscriptionRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            [Obsolete]
            public ImportSubscriptionRequest PaymentMethodGateway(ChargeBee.Models.Enums.GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public ImportSubscriptionRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public ImportSubscriptionRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public ImportSubscriptionRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public ImportSubscriptionRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public ImportSubscriptionRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public ImportSubscriptionRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public ImportSubscriptionRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public ImportSubscriptionRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public ImportSubscriptionRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public ImportSubscriptionRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public ImportSubscriptionRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public ImportSubscriptionRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public ImportSubscriptionRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public ImportSubscriptionRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public ImportSubscriptionRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public ImportSubscriptionRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public ImportSubscriptionRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public ImportSubscriptionRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public ImportSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public ImportSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public ImportSubscriptionRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
        }
        public class ImportForCustomerRequest : EntityRequest<ImportForCustomerRequest> 
        {
            public ImportForCustomerRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportForCustomerRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public ImportForCustomerRequest PlanId(string planId) 
            {
                m_params.Add("plan_id", planId);
                return this;
            }
            public ImportForCustomerRequest PlanQuantity(int planQuantity) 
            {
                m_params.AddOpt("plan_quantity", planQuantity);
                return this;
            }
            public ImportForCustomerRequest PlanUnitPrice(int planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public ImportForCustomerRequest SetupFee(int setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public ImportForCustomerRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            public ImportForCustomerRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public ImportForCustomerRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public ImportForCustomerRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public ImportForCustomerRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public ImportForCustomerRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public ImportForCustomerRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public ImportForCustomerRequest Status(Subscription.StatusEnum status) 
            {
                m_params.Add("status", status);
                return this;
            }
            public ImportForCustomerRequest CurrentTermEnd(long currentTermEnd) 
            {
                m_params.AddOpt("current_term_end", currentTermEnd);
                return this;
            }
            public ImportForCustomerRequest CurrentTermStart(long currentTermStart) 
            {
                m_params.AddOpt("current_term_start", currentTermStart);
                return this;
            }
            public ImportForCustomerRequest TrialStart(long trialStart) 
            {
                m_params.AddOpt("trial_start", trialStart);
                return this;
            }
            public ImportForCustomerRequest CancelledAt(long cancelledAt) 
            {
                m_params.AddOpt("cancelled_at", cancelledAt);
                return this;
            }
            public ImportForCustomerRequest StartedAt(long startedAt) 
            {
                m_params.AddOpt("started_at", startedAt);
                return this;
            }
            public ImportForCustomerRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public ImportForCustomerRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public ImportForCustomerRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public ImportForCustomerRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public ImportForCustomerRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public ImportForCustomerRequest AddonUnitPrice(int index, int addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
        }
        public class OverrideBillingProfileRequest : EntityRequest<OverrideBillingProfileRequest> 
        {
            public OverrideBillingProfileRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public OverrideBillingProfileRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public OverrideBillingProfileRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
        }
        #endregion

        public enum BillingPeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("week")]
            Week,
            [Description("month")]
            Month,
            [Description("year")]
            Year,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("future")]
            Future,
            [Description("in_trial")]
            InTrial,
            [Description("active")]
            Active,
            [Description("non_renewing")]
            NonRenewing,
            [Description("cancelled")]
            Cancelled,

        }
        public enum CancelReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("not_paid")]
            NotPaid,
            [Description("no_card")]
            NoCard,
            [Description("fraud_review_failed")]
            FraudReviewFailed,
            [Description("non_compliant_eu_customer")]
            NonCompliantEuCustomer,
            [Description("tax_calculation_failed")]
            TaxCalculationFailed,
            [Description("currency_incompatible_with_gateway")]
            CurrencyIncompatibleWithGateway,
            [Description("non_compliant_customer")]
            NonCompliantCustomer,

        }

        #region Subclasses
        public class SubscriptionAddon : Resource
        {

            public string Id() {
                return GetValue<string>("id", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public int? UnitPrice() {
                return GetValue<int?>("unit_price", false);
            }

            public DateTime? TrialEnd() {
                return GetDateTime("trial_end", false);
            }

        }
        public class SubscriptionCoupon : Resource
        {

            public string CouponId() {
                return GetValue<string>("coupon_id", true);
            }

            public DateTime? ApplyTill() {
                return GetDateTime("apply_till", false);
            }

            public int AppliedCount() {
                return GetValue<int>("applied_count", true);
            }

            public string CouponCode() {
                return GetValue<string>("coupon_code", false);
            }

        }
        public class SubscriptionShippingAddress : Resource
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
        public class SubscriptionReferralInfo : Resource
        {
            public enum RewardStatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("pending")]
                Pending,
                [Description("paid")]
                Paid,
                [Description("invalid")]
                Invalid,
            }

            public string ReferralCode() {
                return GetValue<string>("referral_code", false);
            }

            public string CouponCode() {
                return GetValue<string>("coupon_code", false);
            }

            public string ReferrerId() {
                return GetValue<string>("referrer_id", false);
            }

            public string ExternalReferenceId() {
                return GetValue<string>("external_reference_id", false);
            }

            public RewardStatusEnum? RewardStatus() {
                return GetEnum<RewardStatusEnum>("reward_status", false);
            }

            public ReferralSystemEnum? ReferralSystem() {
                return GetEnum<ReferralSystemEnum>("referral_system", false);
            }

            public string AccountId() {
                return GetValue<string>("account_id", true);
            }

            public string CampaignId() {
                return GetValue<string>("campaign_id", true);
            }

            public string ExternalCampaignId() {
                return GetValue<string>("external_campaign_id", false);
            }

            public FriendOfferTypeEnum? FriendOfferType() {
                return GetEnum<FriendOfferTypeEnum>("friend_offer_type", false);
            }

            public ReferrerRewardTypeEnum? ReferrerRewardType() {
                return GetEnum<ReferrerRewardTypeEnum>("referrer_reward_type", false);
            }

            public NotifyReferralSystemEnum? NotifyReferralSystem() {
                return GetEnum<NotifyReferralSystemEnum>("notify_referral_system", false);
            }

            public string DestinationUrl() {
                return GetValue<string>("destination_url", false);
            }

            public bool PostPurchaseWidgetEnabled() {
                return GetValue<bool>("post_purchase_widget_enabled", true);
            }

        }

        #endregion
    }
}
