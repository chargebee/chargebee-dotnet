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
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("subscriptions");
            return new ListRequest(url);
        }
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
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string PlanId 
        {
            get { return GetValue<string>("plan_id", true); }
        }
        public int PlanQuantity 
        {
            get { return GetValue<int>("plan_quantity", true); }
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
        public bool? HasScheduledChanges 
        {
            get { return GetValue<bool?>("has_scheduled_changes", false); }
        }
        public string InvoiceNotes 
        {
            get { return GetValue<string>("invoice_notes", false); }
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
            public CreateRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateRequest AffiliateToken(string affiliateToken) 
            {
                m_params.AddOpt("affiliate_token", affiliateToken);
                return this;
            }
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
            public CreateRequest CustomerTaxability(TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CreateRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CreateRequest CustomerAutoCollection(AutoCollectionEnum customerAutoCollection) 
            {
                m_params.AddOpt("customer[auto_collection]", customerAutoCollection);
                return this;
            }
            public CreateRequest CustomerAllowDirectDebit(bool customerAllowDirectDebit) 
            {
                m_params.AddOpt("customer[allow_direct_debit]", customerAllowDirectDebit);
                return this;
            }
            public CreateRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CreateRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public CreateRequest PaymentMethodType(TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            public CreateRequest PaymentMethodGateway(GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public CreateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
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
            public CreateForCustomerRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateForCustomerRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateForCustomerRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
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
            public UpdateRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public UpdateRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
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
            public UpdateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public UpdateRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public UpdateRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public UpdateRequest PaymentMethodType(TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            public UpdateRequest PaymentMethodGateway(GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public UpdateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
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
        }
        #endregion

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

        }

        #endregion
    }
}
