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

    public class Subscription : Resource 
    {
    
        public Subscription() { }

        public Subscription(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Subscription(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Subscription(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

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
        public static CreateWithItemsRequest CreateWithItems(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "subscription_for_items");
            return new CreateWithItemsRequest(url, HttpMethod.POST);
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
        public static ListRequest ContractTermsForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "contract_terms");
            return new ListRequest(url);
        }
        public static ListRequest ListDiscounts(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "discounts");
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
        public static UpdateForItemsRequest UpdateForItems(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "update_for_items");
            return new UpdateForItemsRequest(url, HttpMethod.POST);
        }
        public static ChangeTermEndRequest ChangeTermEnd(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "change_term_end");
            return new ChangeTermEndRequest(url, HttpMethod.POST);
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
        public static EditAdvanceInvoiceScheduleRequest EditAdvanceInvoiceSchedule(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "edit_advance_invoice_schedule");
            return new EditAdvanceInvoiceScheduleRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> RetrieveAdvanceInvoiceSchedule(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "retrieve_advance_invoice_schedule");
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static RemoveAdvanceInvoiceScheduleRequest RemoveAdvanceInvoiceSchedule(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "remove_advance_invoice_schedule");
            return new RemoveAdvanceInvoiceScheduleRequest(url, HttpMethod.POST);
        }
        public static RegenerateInvoiceRequest RegenerateInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "regenerate_invoice");
            return new RegenerateInvoiceRequest(url, HttpMethod.POST);
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
        public static ImportContractTermRequest ImportContractTerm(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "import_contract_term");
            return new ImportContractTermRequest(url, HttpMethod.POST);
        }
        public static ImportUnbilledChargesRequest ImportUnbilledCharges(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "import_unbilled_charges");
            return new ImportUnbilledChargesRequest(url, HttpMethod.POST);
        }
        public static ImportForItemsRequest ImportForItems(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "import_for_items");
            return new ImportForItemsRequest(url, HttpMethod.POST);
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
        public static PauseRequest Pause(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "pause");
            return new PauseRequest(url, HttpMethod.POST);
        }
        public static CancelRequest Cancel(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "cancel");
            return new CancelRequest(url, HttpMethod.POST);
        }
        public static CancelForItemsRequest CancelForItems(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "cancel_for_items");
            return new CancelForItemsRequest(url, HttpMethod.POST);
        }
        public static ResumeRequest Resume(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "resume");
            return new ResumeRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> RemoveScheduledPause(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "remove_scheduled_pause");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> RemoveScheduledResumption(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "remove_scheduled_resumption");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static MoveRequest Move(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "move");
            return new MoveRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public string PlanId 
        {
            get { return GetValue<string>("plan_id", false); }
        }
        public int PlanQuantity 
        {
            get { return GetValue<int>("plan_quantity", false); }
        }
        public long? PlanUnitPrice 
        {
            get { return GetValue<long?>("plan_unit_price", false); }
        }
        public long? SetupFee 
        {
            get { return GetValue<long?>("setup_fee", false); }
        }
        public int? BillingPeriod 
        {
            get { return GetValue<int?>("billing_period", false); }
        }
        public BillingPeriodUnitEnum? BillingPeriodUnit 
        {
            get { return GetEnum<BillingPeriodUnitEnum>("billing_period_unit", false); }
        }
        public DateTime? StartDate 
        {
            get { return GetDateTime("start_date", false); }
        }
        public DateTime? TrialEnd 
        {
            get { return GetDateTime("trial_end", false); }
        }
        public int? RemainingBillingCycles 
        {
            get { return GetValue<int?>("remaining_billing_cycles", false); }
        }
        public string PoNumber 
        {
            get { return GetValue<string>("po_number", false); }
        }
        public AutoCollectionEnum? AutoCollection 
        {
            get { return GetEnum<AutoCollectionEnum>("auto_collection", false); }
        }
        public string PlanQuantityInDecimal 
        {
            get { return GetValue<string>("plan_quantity_in_decimal", false); }
        }
        public string PlanUnitPriceInDecimal 
        {
            get { return GetValue<string>("plan_unit_price_in_decimal", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public long? PlanAmount 
        {
            get { return GetValue<long?>("plan_amount", false); }
        }
        public int? PlanFreeQuantity 
        {
            get { return GetValue<int?>("plan_free_quantity", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? TrialStart 
        {
            get { return GetDateTime("trial_start", false); }
        }
        public TrialEndActionEnum? TrialEndAction 
        {
            get { return GetEnum<TrialEndActionEnum>("trial_end_action", false); }
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
        public string GiftId 
        {
            get { return GetValue<string>("gift_id", false); }
        }
        public int? ContractTermBillingCycleOnRenewal 
        {
            get { return GetValue<int?>("contract_term_billing_cycle_on_renewal", false); }
        }
        public bool? OverrideRelationship 
        {
            get { return GetValue<bool?>("override_relationship", false); }
        }
        public DateTime? PauseDate 
        {
            get { return GetDateTime("pause_date", false); }
        }
        public DateTime? ResumeDate 
        {
            get { return GetDateTime("resume_date", false); }
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
        public bool HasScheduledAdvanceInvoices 
        {
            get { return GetValue<bool>("has_scheduled_advance_invoices", true); }
        }
        public bool HasScheduledChanges 
        {
            get { return GetValue<bool>("has_scheduled_changes", true); }
        }
        public string PaymentSourceId 
        {
            get { return GetValue<string>("payment_source_id", false); }
        }
        public string PlanFreeQuantityInDecimal 
        {
            get { return GetValue<string>("plan_free_quantity_in_decimal", false); }
        }
        public string PlanAmountInDecimal 
        {
            get { return GetValue<string>("plan_amount_in_decimal", false); }
        }
        public DateTime? CancelScheduleCreatedAt 
        {
            get { return GetDateTime("cancel_schedule_created_at", false); }
        }
        public OfflinePaymentMethodEnum? OfflinePaymentMethod 
        {
            get { return GetEnum<OfflinePaymentMethodEnum>("offline_payment_method", false); }
        }
        public ChannelEnum? Channel 
        {
            get { return GetEnum<ChannelEnum>("channel", false); }
        }
        public int? NetTermDays 
        {
            get { return GetValue<int?>("net_term_days", false); }
        }
        public string ActiveId 
        {
            get { return GetValue<string>("active_id", false); }
        }
        public List<SubscriptionSubscriptionItem> SubscriptionItems 
        {
            get { return GetResourceList<SubscriptionSubscriptionItem>("subscription_items"); }
        }
        public List<SubscriptionItemTier> ItemTiers 
        {
            get { return GetResourceList<SubscriptionItemTier>("item_tiers"); }
        }
        public List<SubscriptionChargedItem> ChargedItems 
        {
            get { return GetResourceList<SubscriptionChargedItem>("charged_items"); }
        }
        public int? DueInvoicesCount 
        {
            get { return GetValue<int?>("due_invoices_count", false); }
        }
        public DateTime? DueSince 
        {
            get { return GetDateTime("due_since", false); }
        }
        public long? TotalDues 
        {
            get { return GetValue<long?>("total_dues", false); }
        }
        public long? Mrr 
        {
            get { return GetValue<long?>("mrr", false); }
        }
        [Obsolete]
        public long? Arr 
        {
            get { return GetValue<long?>("arr", false); }
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
        public List<SubscriptionEventBasedAddon> EventBasedAddons 
        {
            get { return GetResourceList<SubscriptionEventBasedAddon>("event_based_addons"); }
        }
        public List<SubscriptionChargedEventBasedAddon> ChargedEventBasedAddons 
        {
            get { return GetResourceList<SubscriptionChargedEventBasedAddon>("charged_event_based_addons"); }
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
        public JToken Metadata 
        {
            get { return GetJToken("metadata", false); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        public DateTime? ChangesScheduledAt 
        {
            get { return GetDateTime("changes_scheduled_at", false); }
        }
        public SubscriptionContractTerm ContractTerm 
        {
            get { return GetSubResource<SubscriptionContractTerm>("contract_term"); }
        }
        public string CancelReasonCode 
        {
            get { return GetValue<string>("cancel_reason_code", false); }
        }
        public int? FreePeriod 
        {
            get { return GetValue<int?>("free_period", false); }
        }
        public FreePeriodUnitEnum? FreePeriodUnit 
        {
            get { return GetEnum<FreePeriodUnitEnum>("free_period_unit", false); }
        }
        public bool? CreatePendingInvoices 
        {
            get { return GetValue<bool?>("create_pending_invoices", false); }
        }
        public bool? AutoCloseInvoices 
        {
            get { return GetValue<bool?>("auto_close_invoices", false); }
        }
        public List<SubscriptionDiscount> Discounts 
        {
            get { return GetResourceList<SubscriptionDiscount>("discounts"); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
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
            public CreateRequest PlanQuantityInDecimal(string planQuantityInDecimal) 
            {
                m_params.AddOpt("plan_quantity_in_decimal", planQuantityInDecimal);
                return this;
            }
            public CreateRequest PlanUnitPrice(long planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public CreateRequest PlanUnitPriceInDecimal(string planUnitPriceInDecimal) 
            {
                m_params.AddOpt("plan_unit_price_in_decimal", planUnitPriceInDecimal);
                return this;
            }
            public CreateRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
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
            public CreateRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public CreateRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
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
            public CreateRequest OfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum offlinePaymentMethod) 
            {
                m_params.AddOpt("offline_payment_method", offlinePaymentMethod);
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
            public CreateRequest TokenId(string tokenId) 
            {
                m_params.AddOpt("token_id", tokenId);
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
            public CreateRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
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
            public CreateRequest FreePeriod(int freePeriod) 
            {
                m_params.AddOpt("free_period", freePeriod);
                return this;
            }
            public CreateRequest FreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum freePeriodUnit) 
            {
                m_params.AddOpt("free_period_unit", freePeriodUnit);
                return this;
            }
            public CreateRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateRequest TrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
                return this;
            }
            public CreateRequest ClientProfileId(string clientProfileId) 
            {
                m_params.AddOpt("client_profile_id", clientProfileId);
                return this;
            }
            public CreateRequest PaymentInitiator(ChargeBee.Models.Enums.PaymentInitiatorEnum paymentInitiator) 
            {
                m_params.AddOpt("payment_initiator", paymentInitiator);
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
            public CreateRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CreateRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public CreateRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
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
            public CreateRequest CustomerTaxjarExemptionCategory(ChargeBee.Models.Enums.TaxjarExemptionCategoryEnum customerTaxjarExemptionCategory) 
            {
                m_params.AddOpt("customer[taxjar_exemption_category]", customerTaxjarExemptionCategory);
                return this;
            }
            public CreateRequest CustomerAutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum customerAutoCollection) 
            {
                m_params.AddOpt("customer[auto_collection]", customerAutoCollection);
                return this;
            }
            public CreateRequest CustomerOfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum customerOfflinePaymentMethod) 
            {
                m_params.AddOpt("customer[offline_payment_method]", customerOfflinePaymentMethod);
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
            public CreateRequest BankAccountGatewayAccountId(string bankAccountGatewayAccountId) 
            {
                m_params.AddOpt("bank_account[gateway_account_id]", bankAccountGatewayAccountId);
                return this;
            }
            public CreateRequest BankAccountIban(string bankAccountIban) 
            {
                m_params.AddOpt("bank_account[iban]", bankAccountIban);
                return this;
            }
            public CreateRequest BankAccountFirstName(string bankAccountFirstName) 
            {
                m_params.AddOpt("bank_account[first_name]", bankAccountFirstName);
                return this;
            }
            public CreateRequest BankAccountLastName(string bankAccountLastName) 
            {
                m_params.AddOpt("bank_account[last_name]", bankAccountLastName);
                return this;
            }
            public CreateRequest BankAccountCompany(string bankAccountCompany) 
            {
                m_params.AddOpt("bank_account[company]", bankAccountCompany);
                return this;
            }
            public CreateRequest BankAccountEmail(string bankAccountEmail) 
            {
                m_params.AddOpt("bank_account[email]", bankAccountEmail);
                return this;
            }
            public CreateRequest BankAccountPhone(string bankAccountPhone) 
            {
                m_params.AddOpt("bank_account[phone]", bankAccountPhone);
                return this;
            }
            public CreateRequest BankAccountBankName(string bankAccountBankName) 
            {
                m_params.AddOpt("bank_account[bank_name]", bankAccountBankName);
                return this;
            }
            public CreateRequest BankAccountAccountNumber(string bankAccountAccountNumber) 
            {
                m_params.AddOpt("bank_account[account_number]", bankAccountAccountNumber);
                return this;
            }
            public CreateRequest BankAccountRoutingNumber(string bankAccountRoutingNumber) 
            {
                m_params.AddOpt("bank_account[routing_number]", bankAccountRoutingNumber);
                return this;
            }
            public CreateRequest BankAccountBankCode(string bankAccountBankCode) 
            {
                m_params.AddOpt("bank_account[bank_code]", bankAccountBankCode);
                return this;
            }
            public CreateRequest BankAccountAccountType(ChargeBee.Models.Enums.AccountTypeEnum bankAccountAccountType) 
            {
                m_params.AddOpt("bank_account[account_type]", bankAccountAccountType);
                return this;
            }
            public CreateRequest BankAccountAccountHolderType(ChargeBee.Models.Enums.AccountHolderTypeEnum bankAccountAccountHolderType) 
            {
                m_params.AddOpt("bank_account[account_holder_type]", bankAccountAccountHolderType);
                return this;
            }
            public CreateRequest BankAccountEcheckType(ChargeBee.Models.Enums.EcheckTypeEnum bankAccountEcheckType) 
            {
                m_params.AddOpt("bank_account[echeck_type]", bankAccountEcheckType);
                return this;
            }
            public CreateRequest BankAccountIssuingCountry(string bankAccountIssuingCountry) 
            {
                m_params.AddOpt("bank_account[issuing_country]", bankAccountIssuingCountry);
                return this;
            }
            public CreateRequest BankAccountSwedishIdentityNumber(string bankAccountSwedishIdentityNumber) 
            {
                m_params.AddOpt("bank_account[swedish_identity_number]", bankAccountSwedishIdentityNumber);
                return this;
            }
            public CreateRequest BankAccountBillingAddress(JToken bankAccountBillingAddress) 
            {
                m_params.AddOpt("bank_account[billing_address]", bankAccountBillingAddress);
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
            public CreateRequest PaymentMethodIssuingCountry(string paymentMethodIssuingCountry) 
            {
                m_params.AddOpt("payment_method[issuing_country]", paymentMethodIssuingCountry);
                return this;
            }
            public CreateRequest PaymentMethodAdditionalInformation(JToken paymentMethodAdditionalInformation) 
            {
                m_params.AddOpt("payment_method[additional_information]", paymentMethodAdditionalInformation);
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
            public CreateRequest CardPreferredScheme(Card.PreferredSchemeEnum cardPreferredScheme) 
            {
                m_params.AddOpt("card[preferred_scheme]", cardPreferredScheme);
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
            public CreateRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
                return this;
            }
            public CreateRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public CreateRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CreateRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public CreateRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
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
            public CreateRequest StatementDescriptorDescriptor(string statementDescriptorDescriptor) 
            {
                m_params.AddOpt("statement_descriptor[descriptor]", statementDescriptorDescriptor);
                return this;
            }
            public CreateRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CreateRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public CreateRequest CustomerEntityIdentifierScheme(string customerEntityIdentifierScheme) 
            {
                m_params.AddOpt("customer[entity_identifier_scheme]", customerEntityIdentifierScheme);
                return this;
            }
            public CreateRequest CustomerEntityIdentifierStandard(string customerEntityIdentifierStandard) 
            {
                m_params.AddOpt("customer[entity_identifier_standard]", customerEntityIdentifierStandard);
                return this;
            }
            public CreateRequest CustomerIsEinvoiceEnabled(bool customerIsEinvoiceEnabled) 
            {
                m_params.AddOpt("customer[is_einvoice_enabled]", customerIsEinvoiceEnabled);
                return this;
            }
            public CreateRequest CustomerEinvoicingMethod(ChargeBee.Models.Enums.EinvoicingMethodEnum customerEinvoicingMethod) 
            {
                m_params.AddOpt("customer[einvoicing_method]", customerEinvoicingMethod);
                return this;
            }
            public CreateRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public CreateRequest CustomerBusinessCustomerWithoutVatNumber(bool customerBusinessCustomerWithoutVatNumber) 
            {
                m_params.AddOpt("customer[business_customer_without_vat_number]", customerBusinessCustomerWithoutVatNumber);
                return this;
            }
            public CreateRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateRequest CustomerExemptionDetails(JArray customerExemptionDetails) 
            {
                m_params.AddOpt("customer[exemption_details]", customerExemptionDetails);
                return this;
            }
            public CreateRequest CustomerCustomerType(ChargeBee.Models.Enums.CustomerTypeEnum customerCustomerType) 
            {
                m_params.AddOpt("customer[customer_type]", customerCustomerType);
                return this;
            }
            public CreateRequest EntityIdentifierId(int index, string entityIdentifierId) 
            {
                m_params.AddOpt("entity_identifiers[id][" + index + "]", entityIdentifierId);
                return this;
            }
            public CreateRequest EntityIdentifierScheme(int index, string entityIdentifierScheme) 
            {
                m_params.AddOpt("entity_identifiers[scheme][" + index + "]", entityIdentifierScheme);
                return this;
            }
            public CreateRequest EntityIdentifierValue(int index, string entityIdentifierValue) 
            {
                m_params.AddOpt("entity_identifiers[value][" + index + "]", entityIdentifierValue);
                return this;
            }
            public CreateRequest EntityIdentifierStandard(int index, string entityIdentifierStandard) 
            {
                m_params.AddOpt("entity_identifiers[standard][" + index + "]", entityIdentifierStandard);
                return this;
            }
            public CreateRequest TaxProvidersFieldProviderName(int index, string taxProvidersFieldProviderName) 
            {
                m_params.AddOpt("tax_providers_fields[provider_name][" + index + "]", taxProvidersFieldProviderName);
                return this;
            }
            public CreateRequest TaxProvidersFieldFieldId(int index, string taxProvidersFieldFieldId) 
            {
                m_params.AddOpt("tax_providers_fields[field_id][" + index + "]", taxProvidersFieldFieldId);
                return this;
            }
            public CreateRequest TaxProvidersFieldFieldValue(int index, string taxProvidersFieldFieldValue) 
            {
                m_params.AddOpt("tax_providers_fields[field_value][" + index + "]", taxProvidersFieldFieldValue);
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
            public CreateRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public CreateRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CreateRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CreateRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CreateRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CreateRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public CreateRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public CreateRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CreateRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CreateRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public CreateRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
            [Obsolete]
            public CreateRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public CreateRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
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
            public CreateForCustomerRequest PlanQuantityInDecimal(string planQuantityInDecimal) 
            {
                m_params.AddOpt("plan_quantity_in_decimal", planQuantityInDecimal);
                return this;
            }
            public CreateForCustomerRequest PlanUnitPrice(long planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public CreateForCustomerRequest PlanUnitPriceInDecimal(string planUnitPriceInDecimal) 
            {
                m_params.AddOpt("plan_unit_price_in_decimal", planUnitPriceInDecimal);
                return this;
            }
            public CreateForCustomerRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
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
            public CreateForCustomerRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public CreateForCustomerRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
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
            public CreateForCustomerRequest OfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum offlinePaymentMethod) 
            {
                m_params.AddOpt("offline_payment_method", offlinePaymentMethod);
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
            public CreateForCustomerRequest OverrideRelationship(bool overrideRelationship) 
            {
                m_params.AddOpt("override_relationship", overrideRelationship);
                return this;
            }
            public CreateForCustomerRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateForCustomerRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
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
            public CreateForCustomerRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateForCustomerRequest FreePeriod(int freePeriod) 
            {
                m_params.AddOpt("free_period", freePeriod);
                return this;
            }
            public CreateForCustomerRequest FreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum freePeriodUnit) 
            {
                m_params.AddOpt("free_period_unit", freePeriodUnit);
                return this;
            }
            public CreateForCustomerRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateForCustomerRequest TrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
                return this;
            }
            public CreateForCustomerRequest PaymentInitiator(ChargeBee.Models.Enums.PaymentInitiatorEnum paymentInitiator) 
            {
                m_params.AddOpt("payment_initiator", paymentInitiator);
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
            public CreateForCustomerRequest StatementDescriptorDescriptor(string statementDescriptorDescriptor) 
            {
                m_params.AddOpt("statement_descriptor[descriptor]", statementDescriptorDescriptor);
                return this;
            }
            public CreateForCustomerRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public CreateForCustomerRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateForCustomerRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CreateForCustomerRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public CreateForCustomerRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateForCustomerRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateForCustomerRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public CreateForCustomerRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public CreateForCustomerRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
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
            public CreateForCustomerRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateForCustomerRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateForCustomerRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateForCustomerRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CreateForCustomerRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public CreateForCustomerRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
            [Obsolete]
            public CreateForCustomerRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public CreateForCustomerRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
                return this;
            }
        }
        public class CreateWithItemsRequest : EntityRequest<CreateWithItemsRequest> 
        {
            public CreateWithItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateWithItemsRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CreateWithItemsRequest BusinessEntityId(string businessEntityId) 
            {
                m_params.AddOpt("business_entity_id", businessEntityId);
                return this;
            }
            public CreateWithItemsRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public CreateWithItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            [Obsolete]
            public CreateWithItemsRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public CreateWithItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public CreateWithItemsRequest NetTermDays(int netTermDays) 
            {
                m_params.AddOpt("net_term_days", netTermDays);
                return this;
            }
            public CreateWithItemsRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            [Obsolete]
            public CreateWithItemsRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateWithItemsRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateWithItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public CreateWithItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public CreateWithItemsRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateWithItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateWithItemsRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateWithItemsRequest OverrideRelationship(bool overrideRelationship) 
            {
                m_params.AddOpt("override_relationship", overrideRelationship);
                return this;
            }
            public CreateWithItemsRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateWithItemsRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateWithItemsRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public CreateWithItemsRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public CreateWithItemsRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateWithItemsRequest FreePeriod(int freePeriod) 
            {
                m_params.AddOpt("free_period", freePeriod);
                return this;
            }
            public CreateWithItemsRequest FreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum freePeriodUnit) 
            {
                m_params.AddOpt("free_period_unit", freePeriodUnit);
                return this;
            }
            public CreateWithItemsRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public CreateWithItemsRequest CreatePendingInvoices(bool createPendingInvoices) 
            {
                m_params.AddOpt("create_pending_invoices", createPendingInvoices);
                return this;
            }
            public CreateWithItemsRequest AutoCloseInvoices(bool autoCloseInvoices) 
            {
                m_params.AddOpt("auto_close_invoices", autoCloseInvoices);
                return this;
            }
            public CreateWithItemsRequest FirstInvoicePending(bool firstInvoicePending) 
            {
                m_params.AddOpt("first_invoice_pending", firstInvoicePending);
                return this;
            }
            public CreateWithItemsRequest TrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
                return this;
            }
            public CreateWithItemsRequest PaymentInitiator(ChargeBee.Models.Enums.PaymentInitiatorEnum paymentInitiator) 
            {
                m_params.AddOpt("payment_initiator", paymentInitiator);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateWithItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateWithItemsRequest StatementDescriptorDescriptor(string statementDescriptorDescriptor) 
            {
                m_params.AddOpt("statement_descriptor[descriptor]", statementDescriptorDescriptor);
                return this;
            }
            public CreateWithItemsRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public CreateWithItemsRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateWithItemsRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CreateWithItemsRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public CreateWithItemsRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateWithItemsRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateWithItemsRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public CreateWithItemsRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            [Obsolete]
            public CreateWithItemsRequest ContractTermContractStart(long contractTermContractStart) 
            {
                m_params.AddOpt("contract_term[contract_start]", contractTermContractStart);
                return this;
            }
            public CreateWithItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemUnitPrice(int index, long subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            [Obsolete]
            public CreateWithItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public CreateWithItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CreateWithItemsRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public CreateWithItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateWithItemsRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateWithItemsRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public CreateWithItemsRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public CreateWithItemsRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CreateWithItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            public CreateWithItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateWithItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateWithItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateWithItemsRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateWithItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateWithItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateWithItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            [Obsolete]
            public CreateWithItemsRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public CreateWithItemsRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
                return this;
            }
            public CreateWithItemsRequest SubscriptionItemUsageAccumulationResetFrequency(int index, ChargeBee.Models.Enums.UsageAccumulationResetFrequencyEnum subscriptionItemUsageAccumulationResetFrequency) 
            {
                m_params.AddOpt("subscription_items[usage_accumulation_reset_frequency][" + index + "]", subscriptionItemUsageAccumulationResetFrequency);
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
            public StringFilter<SubscriptionListRequest> ItemId() 
            {
                return new StringFilter<SubscriptionListRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<SubscriptionListRequest> ItemPriceId() 
            {
                return new StringFilter<SubscriptionListRequest>("item_price_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Subscription.StatusEnum, SubscriptionListRequest> Status() 
            {
                return new EnumFilter<Subscription.StatusEnum, SubscriptionListRequest>("status", this);        
            }
            public EnumFilter<Subscription.CancelReasonEnum, SubscriptionListRequest> CancelReason() 
            {
                return new EnumFilter<Subscription.CancelReasonEnum, SubscriptionListRequest>("cancel_reason", this).SupportsPresenceOperator(true);        
            }
            public StringFilter<SubscriptionListRequest> CancelReasonCode() 
            {
                return new StringFilter<SubscriptionListRequest>("cancel_reason_code", this).SupportsMultiOperators(true);        
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
            public EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, SubscriptionListRequest> OfflinePaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, SubscriptionListRequest>("offline_payment_method", this);        
            }
            public BooleanFilter<SubscriptionListRequest> AutoCloseInvoices() 
            {
                return new BooleanFilter<SubscriptionListRequest>("auto_close_invoices", this);        
            }
            public BooleanFilter<SubscriptionListRequest> OverrideRelationship() 
            {
                return new BooleanFilter<SubscriptionListRequest>("override_relationship", this);        
            }
            
            public SubscriptionListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
            public SubscriptionListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
            public StringFilter<SubscriptionListRequest> BusinessEntityId() 
            {
                return new StringFilter<SubscriptionListRequest>("business_entity_id", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, SubscriptionListRequest> Channel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, SubscriptionListRequest>("channel", this);        
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
            public UpdateRequest PlanUnitPrice(long planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public UpdateRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public UpdateRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public UpdateRequest MandatoryAddonsToRemove(List<string> mandatoryAddonsToRemove) 
            {
                m_params.AddOpt("mandatory_addons_to_remove", mandatoryAddonsToRemove);
                return this;
            }
            public UpdateRequest PlanQuantityInDecimal(string planQuantityInDecimal) 
            {
                m_params.AddOpt("plan_quantity_in_decimal", planQuantityInDecimal);
                return this;
            }
            public UpdateRequest PlanUnitPriceInDecimal(string planUnitPriceInDecimal) 
            {
                m_params.AddOpt("plan_unit_price_in_decimal", planUnitPriceInDecimal);
                return this;
            }
            public UpdateRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
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
            public UpdateRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public UpdateRequest OfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum offlinePaymentMethod) 
            {
                m_params.AddOpt("offline_payment_method", offlinePaymentMethod);
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
            public UpdateRequest TokenId(string tokenId) 
            {
                m_params.AddOpt("token_id", tokenId);
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
            public UpdateRequest OverrideRelationship(bool overrideRelationship) 
            {
                m_params.AddOpt("override_relationship", overrideRelationship);
                return this;
            }
            public UpdateRequest ChangesScheduledAt(long changesScheduledAt) 
            {
                m_params.AddOpt("changes_scheduled_at", changesScheduledAt);
                return this;
            }
            public UpdateRequest ChangeOption(ChargeBee.Models.Enums.ChangeOptionEnum changeOption) 
            {
                m_params.AddOpt("change_option", changeOption);
                return this;
            }
            public UpdateRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public UpdateRequest FreePeriod(int freePeriod) 
            {
                m_params.AddOpt("free_period", freePeriod);
                return this;
            }
            public UpdateRequest FreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum freePeriodUnit) 
            {
                m_params.AddOpt("free_period_unit", freePeriodUnit);
                return this;
            }
            public UpdateRequest TrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
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
            public UpdateRequest PaymentMethodIssuingCountry(string paymentMethodIssuingCountry) 
            {
                m_params.AddOpt("payment_method[issuing_country]", paymentMethodIssuingCountry);
                return this;
            }
            public UpdateRequest PaymentMethodAdditionalInformation(JToken paymentMethodAdditionalInformation) 
            {
                m_params.AddOpt("payment_method[additional_information]", paymentMethodAdditionalInformation);
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
            public UpdateRequest CardPreferredScheme(Card.PreferredSchemeEnum cardPreferredScheme) 
            {
                m_params.AddOpt("card[preferred_scheme]", cardPreferredScheme);
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
            public UpdateRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
                return this;
            }
            public UpdateRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public UpdateRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public UpdateRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public UpdateRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public UpdateRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public UpdateRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public UpdateRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
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
            public UpdateRequest StatementDescriptorDescriptor(string statementDescriptorDescriptor) 
            {
                m_params.AddOpt("statement_descriptor[descriptor]", statementDescriptorDescriptor);
                return this;
            }
            public UpdateRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public UpdateRequest CustomerEntityIdentifierScheme(string customerEntityIdentifierScheme) 
            {
                m_params.AddOpt("customer[entity_identifier_scheme]", customerEntityIdentifierScheme);
                return this;
            }
            public UpdateRequest CustomerIsEinvoiceEnabled(bool customerIsEinvoiceEnabled) 
            {
                m_params.AddOpt("customer[is_einvoice_enabled]", customerIsEinvoiceEnabled);
                return this;
            }
            public UpdateRequest CustomerEinvoicingMethod(ChargeBee.Models.Enums.EinvoicingMethodEnum customerEinvoicingMethod) 
            {
                m_params.AddOpt("customer[einvoicing_method]", customerEinvoicingMethod);
                return this;
            }
            public UpdateRequest CustomerEntityIdentifierStandard(string customerEntityIdentifierStandard) 
            {
                m_params.AddOpt("customer[entity_identifier_standard]", customerEntityIdentifierStandard);
                return this;
            }
            public UpdateRequest CustomerBusinessCustomerWithoutVatNumber(bool customerBusinessCustomerWithoutVatNumber) 
            {
                m_params.AddOpt("customer[business_customer_without_vat_number]", customerBusinessCustomerWithoutVatNumber);
                return this;
            }
            public UpdateRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public UpdateRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public UpdateRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
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
            public UpdateRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public UpdateRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public UpdateRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public UpdateRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public UpdateRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public UpdateRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public UpdateRequest EventBasedAddonChargeOn(int index, ChargeBee.Models.Enums.ChargeOnEnum eventBasedAddonChargeOn) 
            {
                m_params.AddOpt("event_based_addons[charge_on][" + index + "]", eventBasedAddonChargeOn);
                return this;
            }
            public UpdateRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public UpdateRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public UpdateRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public UpdateRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public UpdateRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public UpdateRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public UpdateRequest AddonTrialEnd(int index, long addonTrialEnd) 
            {
                m_params.AddOpt("addons[trial_end][" + index + "]", addonTrialEnd);
                return this;
            }
            public UpdateRequest AddonProrationType(int index, ChargeBee.Models.Enums.ProrationTypeEnum addonProrationType) 
            {
                m_params.AddOpt("addons[proration_type][" + index + "]", addonProrationType);
                return this;
            }
            [Obsolete]
            public UpdateRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public UpdateRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
                return this;
            }
        }
        public class UpdateForItemsRequest : EntityRequest<UpdateForItemsRequest> 
        {
            public UpdateForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateForItemsRequest MandatoryItemsToRemove(List<string> mandatoryItemsToRemove) 
            {
                m_params.AddOpt("mandatory_items_to_remove", mandatoryItemsToRemove);
                return this;
            }
            public UpdateForItemsRequest ReplaceItemsList(bool replaceItemsList) 
            {
                m_params.AddOpt("replace_items_list", replaceItemsList);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public UpdateForItemsRequest NetTermDays(int netTermDays) 
            {
                m_params.AddOpt("net_term_days", netTermDays);
                return this;
            }
            public UpdateForItemsRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public UpdateForItemsRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            public UpdateForItemsRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public UpdateForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public UpdateForItemsRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public UpdateForItemsRequest ReactivateFrom(long reactivateFrom) 
            {
                m_params.AddOpt("reactivate_from", reactivateFrom);
                return this;
            }
            public UpdateForItemsRequest BillingAlignmentMode(ChargeBee.Models.Enums.BillingAlignmentModeEnum billingAlignmentMode) 
            {
                m_params.AddOpt("billing_alignment_mode", billingAlignmentMode);
                return this;
            }
            public UpdateForItemsRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public UpdateForItemsRequest OfflinePaymentMethod(ChargeBee.Models.Enums.OfflinePaymentMethodEnum offlinePaymentMethod) 
            {
                m_params.AddOpt("offline_payment_method", offlinePaymentMethod);
                return this;
            }
            public UpdateForItemsRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public UpdateForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public UpdateForItemsRequest ReplaceCouponList(bool replaceCouponList) 
            {
                m_params.AddOpt("replace_coupon_list", replaceCouponList);
                return this;
            }
            public UpdateForItemsRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public UpdateForItemsRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public UpdateForItemsRequest ForceTermReset(bool forceTermReset) 
            {
                m_params.AddOpt("force_term_reset", forceTermReset);
                return this;
            }
            public UpdateForItemsRequest Reactivate(bool reactivate) 
            {
                m_params.AddOpt("reactivate", reactivate);
                return this;
            }
            public UpdateForItemsRequest TokenId(string tokenId) 
            {
                m_params.AddOpt("token_id", tokenId);
                return this;
            }
            public UpdateForItemsRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public UpdateForItemsRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public UpdateForItemsRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public UpdateForItemsRequest OverrideRelationship(bool overrideRelationship) 
            {
                m_params.AddOpt("override_relationship", overrideRelationship);
                return this;
            }
            public UpdateForItemsRequest ChangesScheduledAt(long changesScheduledAt) 
            {
                m_params.AddOpt("changes_scheduled_at", changesScheduledAt);
                return this;
            }
            public UpdateForItemsRequest ChangeOption(ChargeBee.Models.Enums.ChangeOptionEnum changeOption) 
            {
                m_params.AddOpt("change_option", changeOption);
                return this;
            }
            public UpdateForItemsRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public UpdateForItemsRequest FreePeriod(int freePeriod) 
            {
                m_params.AddOpt("free_period", freePeriod);
                return this;
            }
            public UpdateForItemsRequest FreePeriodUnit(ChargeBee.Models.Enums.FreePeriodUnitEnum freePeriodUnit) 
            {
                m_params.AddOpt("free_period_unit", freePeriodUnit);
                return this;
            }
            public UpdateForItemsRequest CreatePendingInvoices(bool createPendingInvoices) 
            {
                m_params.AddOpt("create_pending_invoices", createPendingInvoices);
                return this;
            }
            public UpdateForItemsRequest AutoCloseInvoices(bool autoCloseInvoices) 
            {
                m_params.AddOpt("auto_close_invoices", autoCloseInvoices);
                return this;
            }
            public UpdateForItemsRequest TrialEndAction(ChargeBee.Models.Enums.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
                return this;
            }
            public UpdateForItemsRequest PaymentInitiator(ChargeBee.Models.Enums.PaymentInitiatorEnum paymentInitiator) 
            {
                m_params.AddOpt("payment_initiator", paymentInitiator);
                return this;
            }
            public UpdateForItemsRequest InvoiceUsages(bool invoiceUsages) 
            {
                m_params.AddOpt("invoice_usages", invoiceUsages);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public UpdateForItemsRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public UpdateForItemsRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest PaymentMethodGateway(ChargeBee.Models.Enums.GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public UpdateForItemsRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public UpdateForItemsRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public UpdateForItemsRequest PaymentMethodTmpToken(string paymentMethodTmpToken) 
            {
                m_params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
                return this;
            }
            public UpdateForItemsRequest PaymentMethodIssuingCountry(string paymentMethodIssuingCountry) 
            {
                m_params.AddOpt("payment_method[issuing_country]", paymentMethodIssuingCountry);
                return this;
            }
            public UpdateForItemsRequest PaymentMethodAdditionalInformation(JToken paymentMethodAdditionalInformation) 
            {
                m_params.AddOpt("payment_method[additional_information]", paymentMethodAdditionalInformation);
                return this;
            }
            public UpdateForItemsRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public UpdateForItemsRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public UpdateForItemsRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public UpdateForItemsRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public UpdateForItemsRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public UpdateForItemsRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public UpdateForItemsRequest CardPreferredScheme(Card.PreferredSchemeEnum cardPreferredScheme) 
            {
                m_params.AddOpt("card[preferred_scheme]", cardPreferredScheme);
                return this;
            }
            public UpdateForItemsRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public UpdateForItemsRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public UpdateForItemsRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public UpdateForItemsRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public UpdateForItemsRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public UpdateForItemsRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public UpdateForItemsRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest CardIpAddress(string cardIpAddress) 
            {
                m_params.AddOpt("card[ip_address]", cardIpAddress);
                return this;
            }
            public UpdateForItemsRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
                return this;
            }
            public UpdateForItemsRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public UpdateForItemsRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public UpdateForItemsRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public UpdateForItemsRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public UpdateForItemsRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public UpdateForItemsRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public UpdateForItemsRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public UpdateForItemsRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public UpdateForItemsRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public UpdateForItemsRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public UpdateForItemsRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public UpdateForItemsRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateForItemsRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateForItemsRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateForItemsRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateForItemsRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateForItemsRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public UpdateForItemsRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateForItemsRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateForItemsRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateForItemsRequest StatementDescriptorDescriptor(string statementDescriptorDescriptor) 
            {
                m_params.AddOpt("statement_descriptor[descriptor]", statementDescriptorDescriptor);
                return this;
            }
            public UpdateForItemsRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateForItemsRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public UpdateForItemsRequest CustomerEntityIdentifierScheme(string customerEntityIdentifierScheme) 
            {
                m_params.AddOpt("customer[entity_identifier_scheme]", customerEntityIdentifierScheme);
                return this;
            }
            public UpdateForItemsRequest CustomerIsEinvoiceEnabled(bool customerIsEinvoiceEnabled) 
            {
                m_params.AddOpt("customer[is_einvoice_enabled]", customerIsEinvoiceEnabled);
                return this;
            }
            public UpdateForItemsRequest CustomerEinvoicingMethod(ChargeBee.Models.Enums.EinvoicingMethodEnum customerEinvoicingMethod) 
            {
                m_params.AddOpt("customer[einvoicing_method]", customerEinvoicingMethod);
                return this;
            }
            public UpdateForItemsRequest CustomerEntityIdentifierStandard(string customerEntityIdentifierStandard) 
            {
                m_params.AddOpt("customer[entity_identifier_standard]", customerEntityIdentifierStandard);
                return this;
            }
            public UpdateForItemsRequest CustomerBusinessCustomerWithoutVatNumber(bool customerBusinessCustomerWithoutVatNumber) 
            {
                m_params.AddOpt("customer[business_customer_without_vat_number]", customerBusinessCustomerWithoutVatNumber);
                return this;
            }
            public UpdateForItemsRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public UpdateForItemsRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public UpdateForItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest ContractTermContractStart(long contractTermContractStart) 
            {
                m_params.AddOpt("contract_term[contract_start]", contractTermContractStart);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemUnitPrice(int index, long subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemChargeOnOption(int index, ChargeBee.Models.Enums.ChargeOnOptionEnum subscriptionItemChargeOnOption) 
            {
                m_params.AddOpt("subscription_items[charge_on_option][" + index + "]", subscriptionItemChargeOnOption);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public UpdateForItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public UpdateForItemsRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public UpdateForItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public UpdateForItemsRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public UpdateForItemsRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public UpdateForItemsRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public UpdateForItemsRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public UpdateForItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public UpdateForItemsRequest DiscountOperationType(int index, ChargeBee.Models.Enums.OperationTypeEnum discountOperationType) 
            {
                m_params.Add("discounts[operation_type][" + index + "]", discountOperationType);
                return this;
            }
            public UpdateForItemsRequest DiscountId(int index, string discountId) 
            {
                m_params.AddOpt("discounts[id][" + index + "]", discountId);
                return this;
            }
            public UpdateForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public UpdateForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public UpdateForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public UpdateForItemsRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public UpdateForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public UpdateForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public UpdateForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemProrationType(int index, ChargeBee.Models.Enums.ProrationTypeEnum subscriptionItemProrationType) 
            {
                m_params.AddOpt("subscription_items[proration_type][" + index + "]", subscriptionItemProrationType);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public UpdateForItemsRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
                return this;
            }
            public UpdateForItemsRequest SubscriptionItemUsageAccumulationResetFrequency(int index, ChargeBee.Models.Enums.UsageAccumulationResetFrequencyEnum subscriptionItemUsageAccumulationResetFrequency) 
            {
                m_params.AddOpt("subscription_items[usage_accumulation_reset_frequency][" + index + "]", subscriptionItemUsageAccumulationResetFrequency);
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
            public ReactivateRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public ReactivateRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public ReactivateRequest PaymentInitiator(ChargeBee.Models.Enums.PaymentInitiatorEnum paymentInitiator) 
            {
                m_params.AddOpt("payment_initiator", paymentInitiator);
                return this;
            }
            public ReactivateRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public ReactivateRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public ReactivateRequest StatementDescriptorDescriptor(string statementDescriptorDescriptor) 
            {
                m_params.AddOpt("statement_descriptor[descriptor]", statementDescriptorDescriptor);
                return this;
            }
            public ReactivateRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public ReactivateRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public ReactivateRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public ReactivateRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public ReactivateRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public ReactivateRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public ReactivateRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
        }
        public class AddChargeAtTermEndRequest : EntityRequest<AddChargeAtTermEndRequest> 
        {
            public AddChargeAtTermEndRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddChargeAtTermEndRequest Amount(long amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public AddChargeAtTermEndRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public AddChargeAtTermEndRequest AmountInDecimal(string amountInDecimal) 
            {
                m_params.AddOpt("amount_in_decimal", amountInDecimal);
                return this;
            }
            public AddChargeAtTermEndRequest AvalaraSaleType(ChargeBee.Models.Enums.AvalaraSaleTypeEnum avalaraSaleType) 
            {
                m_params.AddOpt("avalara_sale_type", avalaraSaleType);
                return this;
            }
            public AddChargeAtTermEndRequest AvalaraTransactionType(int avalaraTransactionType) 
            {
                m_params.AddOpt("avalara_transaction_type", avalaraTransactionType);
                return this;
            }
            public AddChargeAtTermEndRequest AvalaraServiceType(int avalaraServiceType) 
            {
                m_params.AddOpt("avalara_service_type", avalaraServiceType);
                return this;
            }
            public AddChargeAtTermEndRequest DateFrom(long dateFrom) 
            {
                m_params.AddOpt("date_from", dateFrom);
                return this;
            }
            public AddChargeAtTermEndRequest DateTo(long dateTo) 
            {
                m_params.AddOpt("date_to", dateTo);
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
            public ChargeAddonAtTermEndRequest AddonUnitPrice(long addonUnitPrice) 
            {
                m_params.AddOpt("addon_unit_price", addonUnitPrice);
                return this;
            }
            public ChargeAddonAtTermEndRequest AddonQuantityInDecimal(string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addon_quantity_in_decimal", addonQuantityInDecimal);
                return this;
            }
            public ChargeAddonAtTermEndRequest AddonUnitPriceInDecimal(string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addon_unit_price_in_decimal", addonUnitPriceInDecimal);
                return this;
            }
            public ChargeAddonAtTermEndRequest DateFrom(long dateFrom) 
            {
                m_params.AddOpt("date_from", dateFrom);
                return this;
            }
            public ChargeAddonAtTermEndRequest DateTo(long dateTo) 
            {
                m_params.AddOpt("date_to", dateTo);
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
            public ChargeFutureRenewalsRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
                return this;
            }
            public ChargeFutureRenewalsRequest ScheduleType(ChargeBee.Models.Enums.ScheduleTypeEnum scheduleType) 
            {
                m_params.AddOpt("schedule_type", scheduleType);
                return this;
            }
            public ChargeFutureRenewalsRequest FixedIntervalScheduleNumberOfOccurrences(int fixedIntervalScheduleNumberOfOccurrences) 
            {
                m_params.AddOpt("fixed_interval_schedule[number_of_occurrences]", fixedIntervalScheduleNumberOfOccurrences);
                return this;
            }
            public ChargeFutureRenewalsRequest FixedIntervalScheduleDaysBeforeRenewal(int fixedIntervalScheduleDaysBeforeRenewal) 
            {
                m_params.AddOpt("fixed_interval_schedule[days_before_renewal]", fixedIntervalScheduleDaysBeforeRenewal);
                return this;
            }
            public ChargeFutureRenewalsRequest FixedIntervalScheduleEndScheduleOn(ChargeBee.Models.Enums.EndScheduleOnEnum fixedIntervalScheduleEndScheduleOn) 
            {
                m_params.AddOpt("fixed_interval_schedule[end_schedule_on]", fixedIntervalScheduleEndScheduleOn);
                return this;
            }
            public ChargeFutureRenewalsRequest FixedIntervalScheduleEndDate(long fixedIntervalScheduleEndDate) 
            {
                m_params.AddOpt("fixed_interval_schedule[end_date]", fixedIntervalScheduleEndDate);
                return this;
            }
            public ChargeFutureRenewalsRequest SpecificDatesScheduleTermsToCharge(int index, int specificDatesScheduleTermsToCharge) 
            {
                m_params.AddOpt("specific_dates_schedule[terms_to_charge][" + index + "]", specificDatesScheduleTermsToCharge);
                return this;
            }
            public ChargeFutureRenewalsRequest SpecificDatesScheduleDate(int index, long specificDatesScheduleDate) 
            {
                m_params.AddOpt("specific_dates_schedule[date][" + index + "]", specificDatesScheduleDate);
                return this;
            }
        }
        public class EditAdvanceInvoiceScheduleRequest : EntityRequest<EditAdvanceInvoiceScheduleRequest> 
        {
            public EditAdvanceInvoiceScheduleRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EditAdvanceInvoiceScheduleRequest TermsToCharge(int termsToCharge) 
            {
                m_params.AddOpt("terms_to_charge", termsToCharge);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest ScheduleType(ChargeBee.Models.Enums.ScheduleTypeEnum scheduleType) 
            {
                m_params.AddOpt("schedule_type", scheduleType);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest FixedIntervalScheduleNumberOfOccurrences(int fixedIntervalScheduleNumberOfOccurrences) 
            {
                m_params.AddOpt("fixed_interval_schedule[number_of_occurrences]", fixedIntervalScheduleNumberOfOccurrences);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest FixedIntervalScheduleDaysBeforeRenewal(int fixedIntervalScheduleDaysBeforeRenewal) 
            {
                m_params.AddOpt("fixed_interval_schedule[days_before_renewal]", fixedIntervalScheduleDaysBeforeRenewal);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest FixedIntervalScheduleEndScheduleOn(ChargeBee.Models.Enums.EndScheduleOnEnum fixedIntervalScheduleEndScheduleOn) 
            {
                m_params.AddOpt("fixed_interval_schedule[end_schedule_on]", fixedIntervalScheduleEndScheduleOn);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest FixedIntervalScheduleEndDate(long fixedIntervalScheduleEndDate) 
            {
                m_params.AddOpt("fixed_interval_schedule[end_date]", fixedIntervalScheduleEndDate);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest SpecificDatesScheduleId(int index, string specificDatesScheduleId) 
            {
                m_params.AddOpt("specific_dates_schedule[id][" + index + "]", specificDatesScheduleId);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest SpecificDatesScheduleTermsToCharge(int index, int specificDatesScheduleTermsToCharge) 
            {
                m_params.AddOpt("specific_dates_schedule[terms_to_charge][" + index + "]", specificDatesScheduleTermsToCharge);
                return this;
            }
            public EditAdvanceInvoiceScheduleRequest SpecificDatesScheduleDate(int index, long specificDatesScheduleDate) 
            {
                m_params.AddOpt("specific_dates_schedule[date][" + index + "]", specificDatesScheduleDate);
                return this;
            }
        }
        public class RemoveAdvanceInvoiceScheduleRequest : EntityRequest<RemoveAdvanceInvoiceScheduleRequest> 
        {
            public RemoveAdvanceInvoiceScheduleRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemoveAdvanceInvoiceScheduleRequest SpecificDatesScheduleId(int index, string specificDatesScheduleId) 
            {
                m_params.AddOpt("specific_dates_schedule[id][" + index + "]", specificDatesScheduleId);
                return this;
            }
        }
        public class RegenerateInvoiceRequest : EntityRequest<RegenerateInvoiceRequest> 
        {
            public RegenerateInvoiceRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RegenerateInvoiceRequest DateFrom(long dateFrom) 
            {
                m_params.AddOpt("date_from", dateFrom);
                return this;
            }
            public RegenerateInvoiceRequest DateTo(long dateTo) 
            {
                m_params.AddOpt("date_to", dateTo);
                return this;
            }
            public RegenerateInvoiceRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public RegenerateInvoiceRequest InvoiceImmediately(bool invoiceImmediately) 
            {
                m_params.AddOpt("invoice_immediately", invoiceImmediately);
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
            public ImportSubscriptionRequest ClientProfileId(string clientProfileId) 
            {
                m_params.AddOpt("client_profile_id", clientProfileId);
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
            public ImportSubscriptionRequest PlanQuantityInDecimal(string planQuantityInDecimal) 
            {
                m_params.AddOpt("plan_quantity_in_decimal", planQuantityInDecimal);
                return this;
            }
            public ImportSubscriptionRequest PlanUnitPrice(long planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public ImportSubscriptionRequest PlanUnitPriceInDecimal(string planUnitPriceInDecimal) 
            {
                m_params.AddOpt("plan_unit_price_in_decimal", planUnitPriceInDecimal);
                return this;
            }
            public ImportSubscriptionRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
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
            public ImportSubscriptionRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
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
            public ImportSubscriptionRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
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
            public ImportSubscriptionRequest ActivatedAt(long activatedAt) 
            {
                m_params.AddOpt("activated_at", activatedAt);
                return this;
            }
            public ImportSubscriptionRequest PauseDate(long pauseDate) 
            {
                m_params.AddOpt("pause_date", pauseDate);
                return this;
            }
            public ImportSubscriptionRequest ResumeDate(long resumeDate) 
            {
                m_params.AddOpt("resume_date", resumeDate);
                return this;
            }
            public ImportSubscriptionRequest CreateCurrentTermInvoice(bool createCurrentTermInvoice) 
            {
                m_params.AddOpt("create_current_term_invoice", createCurrentTermInvoice);
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
            public ImportSubscriptionRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public ImportSubscriptionRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public ImportSubscriptionRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
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
            public ImportSubscriptionRequest CustomerTaxjarExemptionCategory(ChargeBee.Models.Enums.TaxjarExemptionCategoryEnum customerTaxjarExemptionCategory) 
            {
                m_params.AddOpt("customer[taxjar_exemption_category]", customerTaxjarExemptionCategory);
                return this;
            }
            public ImportSubscriptionRequest CustomerCustomerType(ChargeBee.Models.Enums.CustomerTypeEnum customerCustomerType) 
            {
                m_params.AddOpt("customer[customer_type]", customerCustomerType);
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
            public ImportSubscriptionRequest ContractTermId(string contractTermId) 
            {
                m_params.AddOpt("contract_term[id]", contractTermId);
                return this;
            }
            public ImportSubscriptionRequest ContractTermCreatedAt(long contractTermCreatedAt) 
            {
                m_params.AddOpt("contract_term[created_at]", contractTermCreatedAt);
                return this;
            }
            public ImportSubscriptionRequest ContractTermContractStart(long contractTermContractStart) 
            {
                m_params.AddOpt("contract_term[contract_start]", contractTermContractStart);
                return this;
            }
            public ImportSubscriptionRequest ContractTermBillingCycle(int contractTermBillingCycle) 
            {
                m_params.AddOpt("contract_term[billing_cycle]", contractTermBillingCycle);
                return this;
            }
            public ImportSubscriptionRequest ContractTermTotalAmountRaised(long contractTermTotalAmountRaised) 
            {
                m_params.AddOpt("contract_term[total_amount_raised]", contractTermTotalAmountRaised);
                return this;
            }
            public ImportSubscriptionRequest ContractTermTotalAmountRaisedBeforeTax(long contractTermTotalAmountRaisedBeforeTax) 
            {
                m_params.AddOpt("contract_term[total_amount_raised_before_tax]", contractTermTotalAmountRaisedBeforeTax);
                return this;
            }
            public ImportSubscriptionRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public ImportSubscriptionRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
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
            public ImportSubscriptionRequest PaymentMethodIssuingCountry(string paymentMethodIssuingCountry) 
            {
                m_params.AddOpt("payment_method[issuing_country]", paymentMethodIssuingCountry);
                return this;
            }
            public ImportSubscriptionRequest PaymentMethodAdditionalInformation(JToken paymentMethodAdditionalInformation) 
            {
                m_params.AddOpt("payment_method[additional_information]", paymentMethodAdditionalInformation);
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
            public ImportSubscriptionRequest CardPreferredScheme(Card.PreferredSchemeEnum cardPreferredScheme) 
            {
                m_params.AddOpt("card[preferred_scheme]", cardPreferredScheme);
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
            public ImportSubscriptionRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
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
            public ImportSubscriptionRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public ImportSubscriptionRequest TransactionAmount(long transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public ImportSubscriptionRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.AddOpt("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public ImportSubscriptionRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
            public ImportSubscriptionRequest TransactionDate(long transactionDate) 
            {
                m_params.AddOpt("transaction[date]", transactionDate);
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
            public ImportSubscriptionRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public ImportSubscriptionRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public ImportSubscriptionRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public ImportSubscriptionRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public ImportSubscriptionRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public ImportSubscriptionRequest ChargedEventBasedAddonId(int index, string chargedEventBasedAddonId) 
            {
                m_params.AddOpt("charged_event_based_addons[id][" + index + "]", chargedEventBasedAddonId);
                return this;
            }
            public ImportSubscriptionRequest ChargedEventBasedAddonLastChargedAt(int index, long chargedEventBasedAddonLastChargedAt) 
            {
                m_params.AddOpt("charged_event_based_addons[last_charged_at][" + index + "]", chargedEventBasedAddonLastChargedAt);
                return this;
            }
            [Obsolete]
            public ImportSubscriptionRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public ImportSubscriptionRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
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
            public ImportForCustomerRequest PlanQuantityInDecimal(string planQuantityInDecimal) 
            {
                m_params.AddOpt("plan_quantity_in_decimal", planQuantityInDecimal);
                return this;
            }
            public ImportForCustomerRequest PlanUnitPrice(long planUnitPrice) 
            {
                m_params.AddOpt("plan_unit_price", planUnitPrice);
                return this;
            }
            public ImportForCustomerRequest PlanUnitPriceInDecimal(string planUnitPriceInDecimal) 
            {
                m_params.AddOpt("plan_unit_price_in_decimal", planUnitPriceInDecimal);
                return this;
            }
            public ImportForCustomerRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
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
            public ImportForCustomerRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
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
            public ImportForCustomerRequest ActivatedAt(long activatedAt) 
            {
                m_params.AddOpt("activated_at", activatedAt);
                return this;
            }
            public ImportForCustomerRequest PauseDate(long pauseDate) 
            {
                m_params.AddOpt("pause_date", pauseDate);
                return this;
            }
            public ImportForCustomerRequest ResumeDate(long resumeDate) 
            {
                m_params.AddOpt("resume_date", resumeDate);
                return this;
            }
            public ImportForCustomerRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public ImportForCustomerRequest CreateCurrentTermInvoice(bool createCurrentTermInvoice) 
            {
                m_params.AddOpt("create_current_term_invoice", createCurrentTermInvoice);
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
            public ImportForCustomerRequest ContractTermId(string contractTermId) 
            {
                m_params.AddOpt("contract_term[id]", contractTermId);
                return this;
            }
            public ImportForCustomerRequest ContractTermCreatedAt(long contractTermCreatedAt) 
            {
                m_params.AddOpt("contract_term[created_at]", contractTermCreatedAt);
                return this;
            }
            public ImportForCustomerRequest ContractTermContractStart(long contractTermContractStart) 
            {
                m_params.AddOpt("contract_term[contract_start]", contractTermContractStart);
                return this;
            }
            public ImportForCustomerRequest ContractTermBillingCycle(int contractTermBillingCycle) 
            {
                m_params.AddOpt("contract_term[billing_cycle]", contractTermBillingCycle);
                return this;
            }
            public ImportForCustomerRequest ContractTermTotalAmountRaised(long contractTermTotalAmountRaised) 
            {
                m_params.AddOpt("contract_term[total_amount_raised]", contractTermTotalAmountRaised);
                return this;
            }
            public ImportForCustomerRequest ContractTermTotalAmountRaisedBeforeTax(long contractTermTotalAmountRaisedBeforeTax) 
            {
                m_params.AddOpt("contract_term[total_amount_raised_before_tax]", contractTermTotalAmountRaisedBeforeTax);
                return this;
            }
            public ImportForCustomerRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public ImportForCustomerRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public ImportForCustomerRequest TransactionAmount(long transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public ImportForCustomerRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.AddOpt("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public ImportForCustomerRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
            public ImportForCustomerRequest TransactionDate(long transactionDate) 
            {
                m_params.AddOpt("transaction[date]", transactionDate);
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
            public ImportForCustomerRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public ImportForCustomerRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public ImportForCustomerRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public ImportForCustomerRequest AddonBillingCycles(int index, int addonBillingCycles) 
            {
                m_params.AddOpt("addons[billing_cycles][" + index + "]", addonBillingCycles);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonUnitPriceInDecimal(int index, string eventBasedAddonUnitPriceInDecimal) 
            {
                m_params.AddOpt("event_based_addons[unit_price_in_decimal][" + index + "]", eventBasedAddonUnitPriceInDecimal);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public ImportForCustomerRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public ImportForCustomerRequest ChargedEventBasedAddonId(int index, string chargedEventBasedAddonId) 
            {
                m_params.AddOpt("charged_event_based_addons[id][" + index + "]", chargedEventBasedAddonId);
                return this;
            }
            public ImportForCustomerRequest ChargedEventBasedAddonLastChargedAt(int index, long chargedEventBasedAddonLastChargedAt) 
            {
                m_params.AddOpt("charged_event_based_addons[last_charged_at][" + index + "]", chargedEventBasedAddonLastChargedAt);
                return this;
            }
            [Obsolete]
            public ImportForCustomerRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public ImportForCustomerRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
                return this;
            }
        }
        public class ImportContractTermRequest : EntityRequest<ImportContractTermRequest> 
        {
            public ImportContractTermRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportContractTermRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public ImportContractTermRequest ContractTermId(string contractTermId) 
            {
                m_params.AddOpt("contract_term[id]", contractTermId);
                return this;
            }
            public ImportContractTermRequest ContractTermCreatedAt(long contractTermCreatedAt) 
            {
                m_params.AddOpt("contract_term[created_at]", contractTermCreatedAt);
                return this;
            }
            public ImportContractTermRequest ContractTermContractStart(long contractTermContractStart) 
            {
                m_params.AddOpt("contract_term[contract_start]", contractTermContractStart);
                return this;
            }
            public ImportContractTermRequest ContractTermContractEnd(long contractTermContractEnd) 
            {
                m_params.AddOpt("contract_term[contract_end]", contractTermContractEnd);
                return this;
            }
            public ImportContractTermRequest ContractTermStatus(SubscriptionContractTerm.StatusEnum contractTermStatus) 
            {
                m_params.AddOpt("contract_term[status]", contractTermStatus);
                return this;
            }
            public ImportContractTermRequest ContractTermTotalAmountRaised(long contractTermTotalAmountRaised) 
            {
                m_params.AddOpt("contract_term[total_amount_raised]", contractTermTotalAmountRaised);
                return this;
            }
            public ImportContractTermRequest ContractTermTotalAmountRaisedBeforeTax(long contractTermTotalAmountRaisedBeforeTax) 
            {
                m_params.AddOpt("contract_term[total_amount_raised_before_tax]", contractTermTotalAmountRaisedBeforeTax);
                return this;
            }
            public ImportContractTermRequest ContractTermTotalContractValue(long contractTermTotalContractValue) 
            {
                m_params.AddOpt("contract_term[total_contract_value]", contractTermTotalContractValue);
                return this;
            }
            public ImportContractTermRequest ContractTermTotalContractValueBeforeTax(long contractTermTotalContractValueBeforeTax) 
            {
                m_params.AddOpt("contract_term[total_contract_value_before_tax]", contractTermTotalContractValueBeforeTax);
                return this;
            }
            public ImportContractTermRequest ContractTermBillingCycle(int contractTermBillingCycle) 
            {
                m_params.AddOpt("contract_term[billing_cycle]", contractTermBillingCycle);
                return this;
            }
            public ImportContractTermRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public ImportContractTermRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
        }
        public class ImportUnbilledChargesRequest : EntityRequest<ImportUnbilledChargesRequest> 
        {
            public ImportUnbilledChargesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportUnbilledChargesRequest UnbilledChargeId(int index, string unbilledChargeId) 
            {
                m_params.AddOpt("unbilled_charges[id][" + index + "]", unbilledChargeId);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeDateFrom(int index, long unbilledChargeDateFrom) 
            {
                m_params.Add("unbilled_charges[date_from][" + index + "]", unbilledChargeDateFrom);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeDateTo(int index, long unbilledChargeDateTo) 
            {
                m_params.Add("unbilled_charges[date_to][" + index + "]", unbilledChargeDateTo);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeEntityType(int index, UnbilledCharge.EntityTypeEnum unbilledChargeEntityType) 
            {
                m_params.Add("unbilled_charges[entity_type][" + index + "]", unbilledChargeEntityType);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeEntityId(int index, string unbilledChargeEntityId) 
            {
                m_params.AddOpt("unbilled_charges[entity_id][" + index + "]", unbilledChargeEntityId);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeDescription(int index, string unbilledChargeDescription) 
            {
                m_params.AddOpt("unbilled_charges[description][" + index + "]", unbilledChargeDescription);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeUnitAmount(int index, long unbilledChargeUnitAmount) 
            {
                m_params.AddOpt("unbilled_charges[unit_amount][" + index + "]", unbilledChargeUnitAmount);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeQuantity(int index, int unbilledChargeQuantity) 
            {
                m_params.AddOpt("unbilled_charges[quantity][" + index + "]", unbilledChargeQuantity);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeAmount(int index, long unbilledChargeAmount) 
            {
                m_params.AddOpt("unbilled_charges[amount][" + index + "]", unbilledChargeAmount);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeUnitAmountInDecimal(int index, string unbilledChargeUnitAmountInDecimal) 
            {
                m_params.AddOpt("unbilled_charges[unit_amount_in_decimal][" + index + "]", unbilledChargeUnitAmountInDecimal);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeQuantityInDecimal(int index, string unbilledChargeQuantityInDecimal) 
            {
                m_params.AddOpt("unbilled_charges[quantity_in_decimal][" + index + "]", unbilledChargeQuantityInDecimal);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeAmountInDecimal(int index, string unbilledChargeAmountInDecimal) 
            {
                m_params.AddOpt("unbilled_charges[amount_in_decimal][" + index + "]", unbilledChargeAmountInDecimal);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeDiscountAmount(int index, long unbilledChargeDiscountAmount) 
            {
                m_params.AddOpt("unbilled_charges[discount_amount][" + index + "]", unbilledChargeDiscountAmount);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeUseForProration(int index, bool unbilledChargeUseForProration) 
            {
                m_params.AddOpt("unbilled_charges[use_for_proration][" + index + "]", unbilledChargeUseForProration);
                return this;
            }
            public ImportUnbilledChargesRequest UnbilledChargeIsAdvanceCharge(int index, bool unbilledChargeIsAdvanceCharge) 
            {
                m_params.AddOpt("unbilled_charges[is_advance_charge][" + index + "]", unbilledChargeIsAdvanceCharge);
                return this;
            }
            public ImportUnbilledChargesRequest DiscountUnbilledChargeId(int index, string discountUnbilledChargeId) 
            {
                m_params.AddOpt("discounts[unbilled_charge_id][" + index + "]", discountUnbilledChargeId);
                return this;
            }
            public ImportUnbilledChargesRequest DiscountEntityType(int index, Invoice.InvoiceDiscount.EntityTypeEnum discountEntityType) 
            {
                m_params.AddOpt("discounts[entity_type][" + index + "]", discountEntityType);
                return this;
            }
            public ImportUnbilledChargesRequest DiscountEntityId(int index, string discountEntityId) 
            {
                m_params.AddOpt("discounts[entity_id][" + index + "]", discountEntityId);
                return this;
            }
            public ImportUnbilledChargesRequest DiscountDescription(int index, string discountDescription) 
            {
                m_params.AddOpt("discounts[description][" + index + "]", discountDescription);
                return this;
            }
            public ImportUnbilledChargesRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.Add("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public ImportUnbilledChargesRequest TierUnbilledChargeId(int index, string tierUnbilledChargeId) 
            {
                m_params.Add("tiers[unbilled_charge_id][" + index + "]", tierUnbilledChargeId);
                return this;
            }
            public ImportUnbilledChargesRequest TierStartingUnit(int index, int tierStartingUnit) 
            {
                m_params.AddOpt("tiers[starting_unit][" + index + "]", tierStartingUnit);
                return this;
            }
            public ImportUnbilledChargesRequest TierEndingUnit(int index, int tierEndingUnit) 
            {
                m_params.AddOpt("tiers[ending_unit][" + index + "]", tierEndingUnit);
                return this;
            }
            public ImportUnbilledChargesRequest TierQuantityUsed(int index, int tierQuantityUsed) 
            {
                m_params.AddOpt("tiers[quantity_used][" + index + "]", tierQuantityUsed);
                return this;
            }
            public ImportUnbilledChargesRequest TierUnitAmount(int index, long tierUnitAmount) 
            {
                m_params.AddOpt("tiers[unit_amount][" + index + "]", tierUnitAmount);
                return this;
            }
            public ImportUnbilledChargesRequest TierStartingUnitInDecimal(int index, string tierStartingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[starting_unit_in_decimal][" + index + "]", tierStartingUnitInDecimal);
                return this;
            }
            public ImportUnbilledChargesRequest TierEndingUnitInDecimal(int index, string tierEndingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[ending_unit_in_decimal][" + index + "]", tierEndingUnitInDecimal);
                return this;
            }
            public ImportUnbilledChargesRequest TierQuantityUsedInDecimal(int index, string tierQuantityUsedInDecimal) 
            {
                m_params.AddOpt("tiers[quantity_used_in_decimal][" + index + "]", tierQuantityUsedInDecimal);
                return this;
            }
            public ImportUnbilledChargesRequest TierUnitAmountInDecimal(int index, string tierUnitAmountInDecimal) 
            {
                m_params.AddOpt("tiers[unit_amount_in_decimal][" + index + "]", tierUnitAmountInDecimal);
                return this;
            }
        }
        public class ImportForItemsRequest : EntityRequest<ImportForItemsRequest> 
        {
            public ImportForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportForItemsRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public ImportForItemsRequest TrialEnd(long trialEnd) 
            {
                m_params.AddOpt("trial_end", trialEnd);
                return this;
            }
            public ImportForItemsRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            [Obsolete]
            public ImportForItemsRequest SetupFee(long setupFee) 
            {
                m_params.AddOpt("setup_fee", setupFee);
                return this;
            }
            public ImportForItemsRequest NetTermDays(int netTermDays) 
            {
                m_params.AddOpt("net_term_days", netTermDays);
                return this;
            }
            public ImportForItemsRequest StartDate(long startDate) 
            {
                m_params.AddOpt("start_date", startDate);
                return this;
            }
            public ImportForItemsRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public ImportForItemsRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public ImportForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public ImportForItemsRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public ImportForItemsRequest Status(Subscription.StatusEnum status) 
            {
                m_params.Add("status", status);
                return this;
            }
            public ImportForItemsRequest CurrentTermEnd(long currentTermEnd) 
            {
                m_params.AddOpt("current_term_end", currentTermEnd);
                return this;
            }
            public ImportForItemsRequest CurrentTermStart(long currentTermStart) 
            {
                m_params.AddOpt("current_term_start", currentTermStart);
                return this;
            }
            public ImportForItemsRequest TrialStart(long trialStart) 
            {
                m_params.AddOpt("trial_start", trialStart);
                return this;
            }
            public ImportForItemsRequest CancelledAt(long cancelledAt) 
            {
                m_params.AddOpt("cancelled_at", cancelledAt);
                return this;
            }
            public ImportForItemsRequest StartedAt(long startedAt) 
            {
                m_params.AddOpt("started_at", startedAt);
                return this;
            }
            public ImportForItemsRequest ActivatedAt(long activatedAt) 
            {
                m_params.AddOpt("activated_at", activatedAt);
                return this;
            }
            public ImportForItemsRequest PauseDate(long pauseDate) 
            {
                m_params.AddOpt("pause_date", pauseDate);
                return this;
            }
            public ImportForItemsRequest ResumeDate(long resumeDate) 
            {
                m_params.AddOpt("resume_date", resumeDate);
                return this;
            }
            public ImportForItemsRequest ContractTermBillingCycleOnRenewal(int contractTermBillingCycleOnRenewal) 
            {
                m_params.AddOpt("contract_term_billing_cycle_on_renewal", contractTermBillingCycleOnRenewal);
                return this;
            }
            public ImportForItemsRequest CreateCurrentTermInvoice(bool createCurrentTermInvoice) 
            {
                m_params.AddOpt("create_current_term_invoice", createCurrentTermInvoice);
                return this;
            }
            public ImportForItemsRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public ImportForItemsRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public ImportForItemsRequest CancelReasonCode(string cancelReasonCode) 
            {
                m_params.AddOpt("cancel_reason_code", cancelReasonCode);
                return this;
            }
            public ImportForItemsRequest CreatePendingInvoices(bool createPendingInvoices) 
            {
                m_params.AddOpt("create_pending_invoices", createPendingInvoices);
                return this;
            }
            public ImportForItemsRequest AutoCloseInvoices(bool autoCloseInvoices) 
            {
                m_params.AddOpt("auto_close_invoices", autoCloseInvoices);
                return this;
            }
            public ImportForItemsRequest ContractTermId(string contractTermId) 
            {
                m_params.AddOpt("contract_term[id]", contractTermId);
                return this;
            }
            public ImportForItemsRequest ContractTermCreatedAt(long contractTermCreatedAt) 
            {
                m_params.AddOpt("contract_term[created_at]", contractTermCreatedAt);
                return this;
            }
            public ImportForItemsRequest ContractTermContractStart(long contractTermContractStart) 
            {
                m_params.AddOpt("contract_term[contract_start]", contractTermContractStart);
                return this;
            }
            public ImportForItemsRequest ContractTermBillingCycle(int contractTermBillingCycle) 
            {
                m_params.AddOpt("contract_term[billing_cycle]", contractTermBillingCycle);
                return this;
            }
            public ImportForItemsRequest ContractTermTotalAmountRaised(long contractTermTotalAmountRaised) 
            {
                m_params.AddOpt("contract_term[total_amount_raised]", contractTermTotalAmountRaised);
                return this;
            }
            public ImportForItemsRequest ContractTermTotalAmountRaisedBeforeTax(long contractTermTotalAmountRaisedBeforeTax) 
            {
                m_params.AddOpt("contract_term[total_amount_raised_before_tax]", contractTermTotalAmountRaisedBeforeTax);
                return this;
            }
            public ImportForItemsRequest ContractTermActionAtTermEnd(SubscriptionContractTerm.ActionAtTermEndEnum contractTermActionAtTermEnd) 
            {
                m_params.AddOpt("contract_term[action_at_term_end]", contractTermActionAtTermEnd);
                return this;
            }
            public ImportForItemsRequest ContractTermCancellationCutoffPeriod(int contractTermCancellationCutoffPeriod) 
            {
                m_params.AddOpt("contract_term[cancellation_cutoff_period]", contractTermCancellationCutoffPeriod);
                return this;
            }
            public ImportForItemsRequest TransactionAmount(long transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public ImportForItemsRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.AddOpt("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public ImportForItemsRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
            public ImportForItemsRequest TransactionDate(long transactionDate) 
            {
                m_params.AddOpt("transaction[date]", transactionDate);
                return this;
            }
            public ImportForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public ImportForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public ImportForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public ImportForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public ImportForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public ImportForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public ImportForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public ImportForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public ImportForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public ImportForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public ImportForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public ImportForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public ImportForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public ImportForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.Add("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemUnitPrice(int index, long subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemBillingCycles(int index, int subscriptionItemBillingCycles) 
            {
                m_params.AddOpt("subscription_items[billing_cycles][" + index + "]", subscriptionItemBillingCycles);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemTrialEnd(int index, long subscriptionItemTrialEnd) 
            {
                m_params.AddOpt("subscription_items[trial_end][" + index + "]", subscriptionItemTrialEnd);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemChargeOnEvent(int index, ChargeBee.Models.Enums.ChargeOnEventEnum subscriptionItemChargeOnEvent) 
            {
                m_params.AddOpt("subscription_items[charge_on_event][" + index + "]", subscriptionItemChargeOnEvent);
                return this;
            }
            public ImportForItemsRequest SubscriptionItemChargeOnce(int index, bool subscriptionItemChargeOnce) 
            {
                m_params.AddOpt("subscription_items[charge_once][" + index + "]", subscriptionItemChargeOnce);
                return this;
            }
            [Obsolete]
            public ImportForItemsRequest SubscriptionItemItemType(int index, ChargeBee.Models.Enums.ItemTypeEnum subscriptionItemItemType) 
            {
                m_params.AddOpt("subscription_items[item_type][" + index + "]", subscriptionItemItemType);
                return this;
            }
            public ImportForItemsRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public ImportForItemsRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public ImportForItemsRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public ImportForItemsRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public ImportForItemsRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public ImportForItemsRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public ImportForItemsRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public ImportForItemsRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public ImportForItemsRequest ChargedItemItemPriceId(int index, string chargedItemItemPriceId) 
            {
                m_params.AddOpt("charged_items[item_price_id][" + index + "]", chargedItemItemPriceId);
                return this;
            }
            public ImportForItemsRequest ChargedItemLastChargedAt(int index, long chargedItemLastChargedAt) 
            {
                m_params.AddOpt("charged_items[last_charged_at][" + index + "]", chargedItemLastChargedAt);
                return this;
            }
            public ImportForItemsRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public ImportForItemsRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public ImportForItemsRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public ImportForItemsRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public ImportForItemsRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public ImportForItemsRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public ImportForItemsRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            [Obsolete]
            public ImportForItemsRequest CouponCouponId(int index, string couponCouponId) 
            {
                m_params.AddOpt("coupons[coupon_id][" + index + "]", couponCouponId);
                return this;
            }
            [Obsolete]
            public ImportForItemsRequest CouponApplyTill(int index, long couponApplyTill) 
            {
                m_params.AddOpt("coupons[apply_till][" + index + "]", couponApplyTill);
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
        public class PauseRequest : EntityRequest<PauseRequest> 
        {
            public PauseRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PauseRequest PauseOption(ChargeBee.Models.Enums.PauseOptionEnum pauseOption) 
            {
                m_params.AddOpt("pause_option", pauseOption);
                return this;
            }
            public PauseRequest PauseDate(long pauseDate) 
            {
                m_params.AddOpt("pause_date", pauseDate);
                return this;
            }
            public PauseRequest UnbilledChargesHandling(ChargeBee.Models.Enums.UnbilledChargesHandlingEnum unbilledChargesHandling) 
            {
                m_params.AddOpt("unbilled_charges_handling", unbilledChargesHandling);
                return this;
            }
            public PauseRequest InvoiceDunningHandling(ChargeBee.Models.Enums.InvoiceDunningHandlingEnum invoiceDunningHandling) 
            {
                m_params.AddOpt("invoice_dunning_handling", invoiceDunningHandling);
                return this;
            }
            public PauseRequest SkipBillingCycles(int skipBillingCycles) 
            {
                m_params.AddOpt("skip_billing_cycles", skipBillingCycles);
                return this;
            }
            public PauseRequest ResumeDate(long resumeDate) 
            {
                m_params.AddOpt("resume_date", resumeDate);
                return this;
            }
        }
        public class CancelRequest : EntityRequest<CancelRequest> 
        {
            public CancelRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CancelRequest CancelOption(ChargeBee.Models.Enums.CancelOptionEnum cancelOption) 
            {
                m_params.AddOpt("cancel_option", cancelOption);
                return this;
            }
            public CancelRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public CancelRequest CancelAt(long cancelAt) 
            {
                m_params.AddOpt("cancel_at", cancelAt);
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
            public CancelRequest ContractTermCancelOption(ChargeBee.Models.Enums.ContractTermCancelOptionEnum contractTermCancelOption) 
            {
                m_params.AddOpt("contract_term_cancel_option", contractTermCancelOption);
                return this;
            }
            public CancelRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CancelRequest CancelReasonCode(string cancelReasonCode) 
            {
                m_params.AddOpt("cancel_reason_code", cancelReasonCode);
                return this;
            }
            public CancelRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CancelRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CancelRequest EventBasedAddonUnitPrice(int index, long eventBasedAddonUnitPrice) 
            {
                m_params.AddOpt("event_based_addons[unit_price][" + index + "]", eventBasedAddonUnitPrice);
                return this;
            }
            public CancelRequest EventBasedAddonServicePeriodInDays(int index, int eventBasedAddonServicePeriodInDays) 
            {
                m_params.AddOpt("event_based_addons[service_period_in_days][" + index + "]", eventBasedAddonServicePeriodInDays);
                return this;
            }
        }
        public class CancelForItemsRequest : EntityRequest<CancelForItemsRequest> 
        {
            public CancelForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CancelForItemsRequest CancelOption(ChargeBee.Models.Enums.CancelOptionEnum cancelOption) 
            {
                m_params.AddOpt("cancel_option", cancelOption);
                return this;
            }
            public CancelForItemsRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public CancelForItemsRequest CancelAt(long cancelAt) 
            {
                m_params.AddOpt("cancel_at", cancelAt);
                return this;
            }
            public CancelForItemsRequest CreditOptionForCurrentTermCharges(ChargeBee.Models.Enums.CreditOptionForCurrentTermChargesEnum creditOptionForCurrentTermCharges) 
            {
                m_params.AddOpt("credit_option_for_current_term_charges", creditOptionForCurrentTermCharges);
                return this;
            }
            public CancelForItemsRequest UnbilledChargesOption(ChargeBee.Models.Enums.UnbilledChargesOptionEnum unbilledChargesOption) 
            {
                m_params.AddOpt("unbilled_charges_option", unbilledChargesOption);
                return this;
            }
            public CancelForItemsRequest AccountReceivablesHandling(ChargeBee.Models.Enums.AccountReceivablesHandlingEnum accountReceivablesHandling) 
            {
                m_params.AddOpt("account_receivables_handling", accountReceivablesHandling);
                return this;
            }
            public CancelForItemsRequest RefundableCreditsHandling(ChargeBee.Models.Enums.RefundableCreditsHandlingEnum refundableCreditsHandling) 
            {
                m_params.AddOpt("refundable_credits_handling", refundableCreditsHandling);
                return this;
            }
            public CancelForItemsRequest ContractTermCancelOption(ChargeBee.Models.Enums.ContractTermCancelOptionEnum contractTermCancelOption) 
            {
                m_params.AddOpt("contract_term_cancel_option", contractTermCancelOption);
                return this;
            }
            public CancelForItemsRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CancelForItemsRequest CancelReasonCode(string cancelReasonCode) 
            {
                m_params.AddOpt("cancel_reason_code", cancelReasonCode);
                return this;
            }
            public CancelForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.AddOpt("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CancelForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CancelForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
            public CancelForItemsRequest SubscriptionItemUnitPrice(int index, long subscriptionItemUnitPrice) 
            {
                m_params.AddOpt("subscription_items[unit_price][" + index + "]", subscriptionItemUnitPrice);
                return this;
            }
            public CancelForItemsRequest SubscriptionItemUnitPriceInDecimal(int index, string subscriptionItemUnitPriceInDecimal) 
            {
                m_params.AddOpt("subscription_items[unit_price_in_decimal][" + index + "]", subscriptionItemUnitPriceInDecimal);
                return this;
            }
            public CancelForItemsRequest SubscriptionItemServicePeriodDays(int index, int subscriptionItemServicePeriodDays) 
            {
                m_params.AddOpt("subscription_items[service_period_days][" + index + "]", subscriptionItemServicePeriodDays);
                return this;
            }
        }
        public class ResumeRequest : EntityRequest<ResumeRequest> 
        {
            public ResumeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ResumeRequest ResumeOption(ChargeBee.Models.Enums.ResumeOptionEnum resumeOption) 
            {
                m_params.AddOpt("resume_option", resumeOption);
                return this;
            }
            public ResumeRequest ResumeDate(long resumeDate) 
            {
                m_params.AddOpt("resume_date", resumeDate);
                return this;
            }
            public ResumeRequest ChargesHandling(ChargeBee.Models.Enums.ChargesHandlingEnum chargesHandling) 
            {
                m_params.AddOpt("charges_handling", chargesHandling);
                return this;
            }
            public ResumeRequest UnpaidInvoicesHandling(ChargeBee.Models.Enums.UnpaidInvoicesHandlingEnum unpaidInvoicesHandling) 
            {
                m_params.AddOpt("unpaid_invoices_handling", unpaidInvoicesHandling);
                return this;
            }
            public ResumeRequest PaymentInitiator(ChargeBee.Models.Enums.PaymentInitiatorEnum paymentInitiator) 
            {
                m_params.AddOpt("payment_initiator", paymentInitiator);
                return this;
            }
            public ResumeRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public ResumeRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public ResumeRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public ResumeRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public ResumeRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public ResumeRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public ResumeRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
        }
        public class MoveRequest : EntityRequest<MoveRequest> 
        {
            public MoveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public MoveRequest ToCustomerId(string toCustomerId) 
            {
                m_params.Add("to_customer_id", toCustomerId);
                return this;
            }
            public MoveRequest CopyPaymentSource(bool copyPaymentSource) 
            {
                m_params.AddOpt("copy_payment_source", copyPaymentSource);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "future")]
            Future,
            [EnumMember(Value = "in_trial")]
            InTrial,
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "non_renewing")]
            NonRenewing,
            [EnumMember(Value = "paused")]
            Paused,
            [EnumMember(Value = "cancelled")]
            Cancelled,
            [EnumMember(Value = "transferred")]
            Transferred,

        }
        public enum CancelReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "not_paid")]
            NotPaid,
            [EnumMember(Value = "no_card")]
            NoCard,
            [EnumMember(Value = "fraud_review_failed")]
            FraudReviewFailed,
            [EnumMember(Value = "non_compliant_eu_customer")]
            NonCompliantEuCustomer,
            [EnumMember(Value = "tax_calculation_failed")]
            TaxCalculationFailed,
            [EnumMember(Value = "currency_incompatible_with_gateway")]
            CurrencyIncompatibleWithGateway,
            [EnumMember(Value = "non_compliant_customer")]
            NonCompliantCustomer,

        }
        public enum BillingPeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "day")]
            Day,
            [EnumMember(Value = "week")]
            Week,
            [EnumMember(Value = "month")]
            Month,
            [EnumMember(Value = "year")]
            Year,

        }

        #region Subclasses
        public class SubscriptionSubscriptionItem : Resource
        {
            public enum ItemTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "charge")]
                Charge,
            }
            public enum ChargeOnOptionEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "immediately")]
                Immediately,
                [EnumMember(Value = "on_event")]
                OnEvent,
            }

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", true); }
            }

            public ItemTypeEnum ItemType {
                get { return GetEnum<ItemTypeEnum>("item_type", true); }
            }

            public int? Quantity {
                get { return GetValue<int?>("quantity", false); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string MeteredQuantity {
                get { return GetValue<string>("metered_quantity", false); }
            }

            public DateTime? LastCalculatedAt {
                get { return GetDateTime("last_calculated_at", false); }
            }

            public long? UnitPrice {
                get { return GetValue<long?>("unit_price", false); }
            }

            public string UnitPriceInDecimal {
                get { return GetValue<string>("unit_price_in_decimal", false); }
            }

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public string AmountInDecimal {
                get { return GetValue<string>("amount_in_decimal", false); }
            }

            public int? BillingPeriod {
                get { return GetValue<int?>("billing_period", false); }
            }

            public BillingPeriodUnitEnum? BillingPeriodUnit {
                get { return GetEnum<BillingPeriodUnitEnum>("billing_period_unit", false); }
            }

            public int? FreeQuantity {
                get { return GetValue<int?>("free_quantity", false); }
            }

            public string FreeQuantityInDecimal {
                get { return GetValue<string>("free_quantity_in_decimal", false); }
            }

            public DateTime? TrialEnd {
                get { return GetDateTime("trial_end", false); }
            }

            public int? BillingCycles {
                get { return GetValue<int?>("billing_cycles", false); }
            }

            public int? ServicePeriodDays {
                get { return GetValue<int?>("service_period_days", false); }
            }

            public ChargeOnEventEnum? ChargeOnEvent {
                get { return GetEnum<ChargeOnEventEnum>("charge_on_event", false); }
            }

            public bool? ChargeOnce {
                get { return GetValue<bool?>("charge_once", false); }
            }

            public ChargeOnOptionEnum? ChargeOnOption {
                get { return GetEnum<ChargeOnOptionEnum>("charge_on_option", false); }
            }

            public ProrationTypeEnum? ProrationType {
                get { return GetEnum<ProrationTypeEnum>("proration_type", false); }
            }

            public UsageAccumulationResetFrequencyEnum? UsageAccumulationResetFrequency {
                get { return GetEnum<UsageAccumulationResetFrequencyEnum>("usage_accumulation_reset_frequency", false); }
            }

        }
        public class SubscriptionItemTier : Resource
        {

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", true); }
            }

            public int StartingUnit {
                get { return GetValue<int>("starting_unit", true); }
            }

            public int? EndingUnit {
                get { return GetValue<int?>("ending_unit", false); }
            }

            public long Price {
                get { return GetValue<long>("price", true); }
            }

            public string StartingUnitInDecimal {
                get { return GetValue<string>("starting_unit_in_decimal", false); }
            }

            public string EndingUnitInDecimal {
                get { return GetValue<string>("ending_unit_in_decimal", false); }
            }

            public string PriceInDecimal {
                get { return GetValue<string>("price_in_decimal", false); }
            }

            public int Index {
                get { return GetValue<int>("index", true); }
            }

        }
        public class SubscriptionChargedItem : Resource
        {

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", true); }
            }

            public DateTime LastChargedAt {
                get { return (DateTime)GetDateTime("last_charged_at", true); }
            }

        }
        public class SubscriptionAddon : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public int? Quantity {
                get { return GetValue<int?>("quantity", false); }
            }

            public long? UnitPrice {
                get { return GetValue<long?>("unit_price", false); }
            }

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public DateTime? TrialEnd {
                get { return GetDateTime("trial_end", false); }
            }

            public int? RemainingBillingCycles {
                get { return GetValue<int?>("remaining_billing_cycles", false); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string UnitPriceInDecimal {
                get { return GetValue<string>("unit_price_in_decimal", false); }
            }

            public string AmountInDecimal {
                get { return GetValue<string>("amount_in_decimal", false); }
            }

            public ProrationTypeEnum? ProrationType {
                get { return GetEnum<ProrationTypeEnum>("proration_type", false); }
            }

        }
        public class SubscriptionEventBasedAddon : Resource
        {
            public enum OnEventEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "subscription_creation")]
                SubscriptionCreation,
                [EnumMember(Value = "subscription_trial_start")]
                SubscriptionTrialStart,
                [EnumMember(Value = "plan_activation")]
                PlanActivation,
                [EnumMember(Value = "subscription_activation")]
                SubscriptionActivation,
                [EnumMember(Value = "contract_termination")]
                ContractTermination,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public int Quantity {
                get { return GetValue<int>("quantity", true); }
            }

            public long UnitPrice {
                get { return GetValue<long>("unit_price", true); }
            }

            public int? ServicePeriodInDays {
                get { return GetValue<int?>("service_period_in_days", false); }
            }

            public OnEventEnum OnEvent {
                get { return GetEnum<OnEventEnum>("on_event", true); }
            }

            public bool ChargeOnce {
                get { return GetValue<bool>("charge_once", true); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string UnitPriceInDecimal {
                get { return GetValue<string>("unit_price_in_decimal", false); }
            }

        }
        public class SubscriptionChargedEventBasedAddon : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public DateTime LastChargedAt {
                get { return (DateTime)GetDateTime("last_charged_at", true); }
            }

        }
        public class SubscriptionCoupon : Resource
        {

            public string CouponId {
                get { return GetValue<string>("coupon_id", true); }
            }

            public DateTime? ApplyTill {
                get { return GetDateTime("apply_till", false); }
            }

            public int AppliedCount {
                get { return GetValue<int>("applied_count", true); }
            }

            public string CouponCode {
                get { return GetValue<string>("coupon_code", false); }
            }

        }
        public class SubscriptionShippingAddress : Resource
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

            public int Index {
                get { return GetValue<int>("index", true); }
            }

        }
        public class SubscriptionReferralInfo : Resource
        {
            public enum RewardStatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "pending")]
                Pending,
                [EnumMember(Value = "paid")]
                Paid,
                [EnumMember(Value = "invalid")]
                Invalid,
            }

            public string ReferralCode {
                get { return GetValue<string>("referral_code", false); }
            }

            public string CouponCode {
                get { return GetValue<string>("coupon_code", false); }
            }

            public string ReferrerId {
                get { return GetValue<string>("referrer_id", false); }
            }

            public string ExternalReferenceId {
                get { return GetValue<string>("external_reference_id", false); }
            }

            public RewardStatusEnum? RewardStatus {
                get { return GetEnum<RewardStatusEnum>("reward_status", false); }
            }

            public ReferralSystemEnum? ReferralSystem {
                get { return GetEnum<ReferralSystemEnum>("referral_system", false); }
            }

            public string AccountId {
                get { return GetValue<string>("account_id", true); }
            }

            public string CampaignId {
                get { return GetValue<string>("campaign_id", true); }
            }

            public string ExternalCampaignId {
                get { return GetValue<string>("external_campaign_id", false); }
            }

            public FriendOfferTypeEnum? FriendOfferType {
                get { return GetEnum<FriendOfferTypeEnum>("friend_offer_type", false); }
            }

            public ReferrerRewardTypeEnum? ReferrerRewardType {
                get { return GetEnum<ReferrerRewardTypeEnum>("referrer_reward_type", false); }
            }

            public NotifyReferralSystemEnum? NotifyReferralSystem {
                get { return GetEnum<NotifyReferralSystemEnum>("notify_referral_system", false); }
            }

            public string DestinationUrl {
                get { return GetValue<string>("destination_url", false); }
            }

            public bool PostPurchaseWidgetEnabled {
                get { return GetValue<bool>("post_purchase_widget_enabled", true); }
            }

        }
        public class SubscriptionContractTerm : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "active")]
                Active,
                [EnumMember(Value = "completed")]
                Completed,
                [EnumMember(Value = "cancelled")]
                Cancelled,
                [EnumMember(Value = "terminated")]
                Terminated,
            }
            public enum ActionAtTermEndEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "renew")]
                Renew,
                [EnumMember(Value = "evergreen")]
                Evergreen,
                [EnumMember(Value = "cancel")]
                Cancel,
                [EnumMember(Value = "renew_once")]
                RenewOnce,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public DateTime ContractStart {
                get { return (DateTime)GetDateTime("contract_start", true); }
            }

            public DateTime ContractEnd {
                get { return (DateTime)GetDateTime("contract_end", true); }
            }

            public int BillingCycle {
                get { return GetValue<int>("billing_cycle", true); }
            }

            public ActionAtTermEndEnum ActionAtTermEnd {
                get { return GetEnum<ActionAtTermEndEnum>("action_at_term_end", true); }
            }

            public long TotalContractValue {
                get { return GetValue<long>("total_contract_value", true); }
            }

            public long TotalContractValueBeforeTax {
                get { return GetValue<long>("total_contract_value_before_tax", true); }
            }

            public int? CancellationCutoffPeriod {
                get { return GetValue<int?>("cancellation_cutoff_period", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public string SubscriptionId {
                get { return GetValue<string>("subscription_id", true); }
            }

            public int? RemainingBillingCycles {
                get { return GetValue<int?>("remaining_billing_cycles", false); }
            }

        }
        public class SubscriptionDiscount : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "fixed_amount")]
                FixedAmount,
                [EnumMember(Value = "percentage")]
                Percentage,
            }
            public enum DurationTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "one_time")]
                OneTime,
                [EnumMember(Value = "forever")]
                Forever,
                [EnumMember(Value = "limited_period")]
                LimitedPeriod,
            }
            public enum ApplyOnEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "invoice_amount")]
                InvoiceAmount,
                [EnumMember(Value = "specific_item_price")]
                SpecificItemPrice,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string InvoiceName {
                get { return GetValue<string>("invoice_name", false); }
            }

            public TypeEnum DiscountType {
                get { return GetEnum<TypeEnum>("type", true); }
            }

            public double? Percentage {
                get { return GetValue<double?>("percentage", false); }
            }

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public string CurrencyCode {
                get { return GetValue<string>("currency_code", false); }
            }

            public DurationTypeEnum DurationType {
                get { return GetEnum<DurationTypeEnum>("duration_type", true); }
            }

            public int? Period {
                get { return GetValue<int?>("period", false); }
            }

            public PeriodUnitEnum? PeriodUnit {
                get { return GetEnum<PeriodUnitEnum>("period_unit", false); }
            }

            public bool IncludedInMrr {
                get { return GetValue<bool>("included_in_mrr", true); }
            }

            public ApplyOnEnum ApplyOn {
                get { return GetEnum<ApplyOnEnum>("apply_on", true); }
            }

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public DateTime? ApplyTill {
                get { return GetDateTime("apply_till", false); }
            }

            public int? AppliedCount {
                get { return GetValue<int?>("applied_count", false); }
            }

            public string CouponId {
                get { return GetValue<string>("coupon_id", true); }
            }

            public int Index {
                get { return GetValue<int>("index", true); }
            }

        }

        #endregion
    }
}
