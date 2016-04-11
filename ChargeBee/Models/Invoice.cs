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
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("invoices");
            return new CreateRequest(url, HttpMethod.POST);
        }
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
        public static EntityRequest<Type> StopDunning(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "stop_dunning");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static InvoiceListRequest List()
        {
            string url = ApiUtil.BuildUrl("invoices");
            return new InvoiceListRequest(url);
        }
        public static ListRequest InvoicesForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "invoices");
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
        public static EntityRequest<Type> Close(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "close");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static CollectPaymentRequest CollectPayment(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "collect_payment");
            return new CollectPaymentRequest(url, HttpMethod.POST);
        }
        public static RecordPaymentRequest RecordPayment(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "record_payment");
            return new RecordPaymentRequest(url, HttpMethod.POST);
        }
        public static RefundRequest Refund(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "refund");
            return new RefundRequest(url, HttpMethod.POST);
        }
        public static RecordRefundRequest RecordRefund(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "record_refund");
            return new RecordRefundRequest(url, HttpMethod.POST);
        }
        public static VoidInvoiceRequest VoidInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "void");
            return new VoidInvoiceRequest(url, HttpMethod.POST);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
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
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public DateTime? Date 
        {
            get { return GetDateTime("date", false); }
        }
        public int? Total 
        {
            get { return GetValue<int?>("total", false); }
        }
        public int? AmountPaid 
        {
            get { return GetValue<int?>("amount_paid", false); }
        }
        public int? AmountAdjusted 
        {
            get { return GetValue<int?>("amount_adjusted", false); }
        }
        public int? WriteOffAmount 
        {
            get { return GetValue<int?>("write_off_amount", false); }
        }
        public int? CreditsApplied 
        {
            get { return GetValue<int?>("credits_applied", false); }
        }
        public int? AmountDue 
        {
            get { return GetValue<int?>("amount_due", false); }
        }
        public DateTime? PaidAt 
        {
            get { return GetDateTime("paid_at", false); }
        }
        public DunningStatusEnum? DunningStatus 
        {
            get { return GetEnum<DunningStatusEnum>("dunning_status", false); }
        }
        public DateTime? NextRetryAt 
        {
            get { return GetDateTime("next_retry_at", false); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public int Tax 
        {
            get { return GetValue<int>("tax", true); }
        }
        public bool? FirstInvoice 
        {
            get { return GetValue<bool?>("first_invoice", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
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
        public List<InvoiceLinkedPayment> LinkedPayments 
        {
            get { return GetResourceList<InvoiceLinkedPayment>("linked_payments"); }
        }
        public List<InvoiceAppliedCredit> AppliedCredits 
        {
            get { return GetResourceList<InvoiceAppliedCredit>("applied_credits"); }
        }
        public List<InvoiceAdjustmentCreditNote> AdjustmentCreditNotes 
        {
            get { return GetResourceList<InvoiceAdjustmentCreditNote>("adjustment_credit_notes"); }
        }
        public List<InvoiceIssuedCreditNote> IssuedCreditNotes 
        {
            get { return GetResourceList<InvoiceIssuedCreditNote>("issued_credit_notes"); }
        }
        public List<InvoiceLinkedOrder> LinkedOrders 
        {
            get { return GetResourceList<InvoiceLinkedOrder>("linked_orders"); }
        }
        public List<InvoiceNote> Notes 
        {
            get { return GetResourceList<InvoiceNote>("notes"); }
        }
        public InvoiceShippingAddress ShippingAddress 
        {
            get { return GetSubResource<InvoiceShippingAddress>("shipping_address"); }
        }
        public InvoiceBillingAddress BillingAddress 
        {
            get { return GetSubResource<InvoiceBillingAddress>("billing_address"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
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
            public CreateRequest ChargeAmount(int index, int chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
        }
        public class ChargeRequest : EntityRequest<ChargeRequest> 
        {
            public ChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public ChargeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
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
            public ChargeRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public ChargeRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
        }
        public class ChargeAddonRequest : EntityRequest<ChargeAddonRequest> 
        {
            public ChargeAddonRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeAddonRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public ChargeAddonRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
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
            public ChargeAddonRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public ChargeAddonRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
        }
        public class InvoiceListRequest : ListRequest 
        {
            public InvoiceListRequest(string url) 
                    : base(url)
            {
            }

            public InvoiceListRequest Limit(int limit) 
            {
                m_params.AddOpt("limit", limit);
                return this;
            }
            public InvoiceListRequest Offset(string offset) 
            {
                m_params.AddOpt("offset", offset);
                return this;
            }
            public InvoiceListRequest PaidOnAfter(long paidOnAfter) 
            {
                m_params.AddOpt("paid_on_after", paidOnAfter);
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
        public class CollectPaymentRequest : EntityRequest<CollectPaymentRequest> 
        {
            public CollectPaymentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CollectPaymentRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
        }
        public class RecordPaymentRequest : EntityRequest<RecordPaymentRequest> 
        {
            public RecordPaymentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordPaymentRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public RecordPaymentRequest TransactionAmount(int transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public RecordPaymentRequest TransactionPaymentMethod(PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.Add("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public RecordPaymentRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
            public RecordPaymentRequest TransactionDate(long transactionDate) 
            {
                m_params.AddOpt("transaction[date]", transactionDate);
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
            public RefundRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public RefundRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public RefundRequest CreditNoteReasonCode(CreditNote.ReasonCodeEnum creditNoteReasonCode) 
            {
                m_params.AddOpt("credit_note[reason_code]", creditNoteReasonCode);
                return this;
            }
        }
        public class RecordRefundRequest : EntityRequest<RecordRefundRequest> 
        {
            public RecordRefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordRefundRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public RecordRefundRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public RecordRefundRequest TransactionAmount(int transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public RecordRefundRequest TransactionPaymentMethod(PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.Add("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public RecordRefundRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
            public RecordRefundRequest TransactionDate(long transactionDate) 
            {
                m_params.Add("transaction[date]", transactionDate);
                return this;
            }
			public RecordRefundRequest CreditNoteReasonCode(CreditNote.ReasonCodeEnum creditNoteReasonCode) 
            {
                m_params.AddOpt("credit_note[reason_code]", creditNoteReasonCode);
                return this;
            }
        }
        public class VoidInvoiceRequest : EntityRequest<VoidInvoiceRequest> 
        {
            public VoidInvoiceRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public VoidInvoiceRequest Comment(string comment) 
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
            [Description("voided")]
            Voided,
            [Description("pending")]
            Pending,

        }
        public enum DunningStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("in_progress")]
            InProgress,
            [Description("exhausted")]
            Exhausted,
            [Description("stopped")]
            Stopped,
            [Description("success")]
            Success,

        }

        #region Subclasses
        public class InvoiceLineItem : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("plan_setup")]
                PlanSetup,
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

            public bool IsTaxed() {
                return GetValue<bool>("is_taxed", true);
            }

            public int? TaxAmount() {
                return GetValue<int?>("tax_amount", false);
            }

            public double? TaxRate() {
                return GetValue<double?>("tax_rate", false);
            }

            public int Amount() {
                return GetValue<int>("amount", true);
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

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class InvoiceDiscount : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("item_level_coupon")]
                ItemLevelCoupon,
                [Description("document_level_coupon")]
                DocumentLevelCoupon,
                [Description("promotional_credits")]
                PromotionalCredits,
                [Description("prorated_credits")]
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
        public class InvoiceTax : Resource
        {

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

        }
        public class InvoiceLinkedPayment : Resource
        {

            public string TxnId() {
                return GetValue<string>("txn_id", true);
            }

            public int AppliedAmount() {
                return GetValue<int>("applied_amount", true);
            }

            public DateTime AppliedAt() {
                return (DateTime)GetDateTime("applied_at", true);
            }

            public Transaction.StatusEnum? TxnStatus() {
                return GetEnum<Transaction.StatusEnum>("txn_status", false);
            }

            public DateTime? TxnDate() {
                return GetDateTime("txn_date", false);
            }

            public int? TxnAmount() {
                return GetValue<int?>("txn_amount", false);
            }

        }
        public class InvoiceAppliedCredit : Resource
        {

            public string CnId() {
                return GetValue<string>("cn_id", true);
            }

            public int AppliedAmount() {
                return GetValue<int>("applied_amount", true);
            }

            public DateTime AppliedAt() {
                return (DateTime)GetDateTime("applied_at", true);
            }

            public CreditNote.ReasonCodeEnum CnReasonCode() {
                return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", true);
            }

            public DateTime? CnDate() {
                return GetDateTime("cn_date", false);
            }

            public CreditNote.StatusEnum CnStatus() {
                return GetEnum<CreditNote.StatusEnum>("cn_status", true);
            }

        }
        public class InvoiceAdjustmentCreditNote : Resource
        {

            public string CnId() {
                return GetValue<string>("cn_id", true);
            }

            public CreditNote.ReasonCodeEnum CnReasonCode() {
                return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", true);
            }

            public DateTime? CnDate() {
                return GetDateTime("cn_date", false);
            }

            public int? CnTotal() {
                return GetValue<int?>("cn_total", false);
            }

            public CreditNote.StatusEnum CnStatus() {
                return GetEnum<CreditNote.StatusEnum>("cn_status", true);
            }

        }
        public class InvoiceIssuedCreditNote : Resource
        {

            public string CnId() {
                return GetValue<string>("cn_id", true);
            }

            public CreditNote.ReasonCodeEnum CnReasonCode() {
                return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", true);
            }

            public DateTime? CnDate() {
                return GetDateTime("cn_date", false);
            }

            public int? CnTotal() {
                return GetValue<int?>("cn_total", false);
            }

            public CreditNote.StatusEnum CnStatus() {
                return GetEnum<CreditNote.StatusEnum>("cn_status", true);
            }

        }
        public class InvoiceLinkedOrder : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("new")]
                New,
                [Description("processing")]
                Processing,
                [Description("complete")]
                Complete,
                [Description("cancelled")]
                Cancelled,
                [Description("voided")]
                Voided,
            }

            public string Id() {
                return GetValue<string>("id", true);
            }

            public StatusEnum? Status() {
                return GetEnum<StatusEnum>("status", false);
            }

            public string ReferenceId() {
                return GetValue<string>("reference_id", false);
            }

            public string FulfillmentStatus() {
                return GetValue<string>("fulfillment_status", false);
            }

            public string BatchId() {
                return GetValue<string>("batch_id", false);
            }

            public DateTime CreatedAt() {
                return (DateTime)GetDateTime("created_at", true);
            }

        }
        public class InvoiceNote : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("plan")]
                Plan,
                [Description("addon")]
                Addon,
                [Description("coupon")]
                Coupon,
                [Description("subscription")]
                Subscription,
                [Description("customer")]
                Customer,
            }

            public EntityTypeEnum EntityType() {
                return GetEnum<EntityTypeEnum>("entity_type", true);
            }

            public string Note() {
                return GetValue<string>("note", true);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class InvoiceShippingAddress : Resource
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
        public class InvoiceBillingAddress : Resource
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
