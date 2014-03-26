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

    public class Invoice : Resource 
    {
    

        #region Methods
        public static ChargeRequest Charge()
        {
            string url = ApiUtil.BuildUrl("invoices", "charge");
            return new ChargeRequest(url, HttpMethod.POST);
        }
        public static ChargeAddonRequest ChargeAddon()
        {
            string url = ApiUtil.BuildUrl("invoices", "charge_addon");
            return new ChargeAddonRequest(url, HttpMethod.POST);
        }
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("invoices");
            return new ListRequest(url);
        }
        public static ListRequest InvoicesForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "invoices");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Pdf(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "pdf");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static AddChargeRequest AddCharge(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "add_charge");
            return new AddChargeRequest(url, HttpMethod.POST);
        }
        public static AddAddonChargeRequest AddAddonCharge(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "add_addon_charge");
            return new AddAddonChargeRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Collect(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "collect");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static RefundRequest Refund(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "refund");
            return new RefundRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public bool Recurring 
        {
            get { return GetValue<bool>("recurring", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string VatNumber 
        {
            get { return GetValue<string>("vat_number", false); }
        }
        public DateTime StartDate 
        {
            get { return (DateTime)GetDateTime("start_date", true); }
        }
        public DateTime? EndDate 
        {
            get { return GetDateTime("end_date", false); }
        }
        public int? Amount 
        {
            get { return GetValue<int?>("amount", false); }
        }
        public DateTime? PaidOn 
        {
            get { return GetDateTime("paid_on", false); }
        }
        public DateTime? NextRetry 
        {
            get { return GetDateTime("next_retry", false); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public int Tax 
        {
            get { return GetValue<int>("tax", true); }
        }
        public List<InvoiceLineItem> LineItems 
        {
            get { return GetResourceList<InvoiceLineItem>("line_items"); }
        }
        public List<InvoiceDiscount> Discounts 
        {
            get { return GetResourceList<InvoiceDiscount>("discounts"); }
        }
        public List<InvoiceTax> Taxes 
        {
            get { return GetResourceList<InvoiceTax>("taxes"); }
        }
        public List<InvoiceLinkedTransaction> LinkedTransactions 
        {
            get { return GetResourceList<InvoiceLinkedTransaction>("linked_transactions"); }
        }
        
        #endregion
        
        #region Requests
        public class ChargeRequest : EntityRequest<ChargeRequest> 
        {
            public ChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public ChargeRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public ChargeRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
        }
        public class ChargeAddonRequest : EntityRequest<ChargeAddonRequest> 
        {
            public ChargeAddonRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeAddonRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public ChargeAddonRequest AddonId(string addonId) 
            {
                m_params.Add("addon_id", addonId);
                return this;
            }
            public ChargeAddonRequest AddonQuantity(int addonQuantity) 
            {
                m_params.AddOpt("addon_quantity", addonQuantity);
                return this;
            }
        }
        public class AddChargeRequest : EntityRequest<AddChargeRequest> 
        {
            public AddChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddChargeRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public AddChargeRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
        }
        public class AddAddonChargeRequest : EntityRequest<AddAddonChargeRequest> 
        {
            public AddAddonChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddAddonChargeRequest AddonId(string addonId) 
            {
                m_params.Add("addon_id", addonId);
                return this;
            }
            public AddAddonChargeRequest AddonQuantity(int addonQuantity) 
            {
                m_params.AddOpt("addon_quantity", addonQuantity);
                return this;
            }
        }
        public class RefundRequest : EntityRequest<RefundRequest> 
        {
            public RefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RefundRequest RefundAmount(int refundAmount) 
            {
                m_params.AddOpt("refund_amount", refundAmount);
                return this;
            }
            public RefundRequest Memo(string memo) 
            {
                m_params.AddOpt("memo", memo);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("paid")]
            Paid,
            [Description("payment_due")]
            PaymentDue,
            [Description("not_paid")]
            NotPaid,
            [Description("pending")]
            Pending,

        }

        #region Subclasses
        public class InvoiceLineItem : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("charge")]
                Charge,
                [Description("prorated_charge")]
                ProratedCharge,
                [Description("setup_charge")]
                SetupCharge,
            }
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("plan")]
                Plan,
                [Description("addon")]
                Addon,
                [Description("adhoc")]
                Adhoc,
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

            public int? Tax() {
                return GetValue<int?>("tax", false);
            }

            public double? TaxRate() {
                return GetValue<double?>("tax_rate", false);
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", true);
            }

            public TypeEnum LineItemType() {
                return GetEnum<TypeEnum>("type", true);
            }

            public EntityTypeEnum EntityType() {
                return GetEnum<EntityTypeEnum>("entity_type", true);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class InvoiceDiscount : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("coupon")]
                Coupon,
                [Description("credit_adjustment")]
                CreditAdjustment,
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

            public TypeEnum DiscountType() {
                return GetEnum<TypeEnum>("type", true);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class InvoiceTax : Resource
        {

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

        }
        public class InvoiceLinkedTransaction : Resource
        {
            public enum TxnTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("authorization")]
                Authorization,
                [Description("payment")]
                Payment,
                [Description("refund")]
                Refund,
            }
            public enum TxnStatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("success")]
                Success,
                [Description("voided")]
                Voided,
                [Description("failure")]
                Failure,
                [Description("timeout")]
                Timeout,
                [Description("needs_attention")]
                NeedsAttention,
            }

            public string TxnId() {
                return GetValue<string>("txn_id", true);
            }

            public int AppliedAmount() {
                return GetValue<int>("applied_amount", true);
            }

            public TxnTypeEnum TxnType() {
                return GetEnum<TxnTypeEnum>("txn_type", true);
            }

            public TxnStatusEnum? TxnStatus() {
                return GetEnum<TxnStatusEnum>("txn_status", false);
            }

            public DateTime? TxnDate() {
                return GetDateTime("txn_date", false);
            }

            public int? TxnAmount() {
                return GetValue<int?>("txn_amount", false);
            }

        }

        #endregion
    }
}
