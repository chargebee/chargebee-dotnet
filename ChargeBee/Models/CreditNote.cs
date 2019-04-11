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

    public class CreditNote : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("credit_notes");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static PdfRequest Pdf(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "pdf");
            return new PdfRequest(url, HttpMethod.POST);
        }
        public static RecordRefundRequest RecordRefund(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "record_refund");
            return new RecordRefundRequest(url, HttpMethod.POST);
        }
        public static VoidCreditNoteRequest VoidCreditNote(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "void");
            return new VoidCreditNoteRequest(url, HttpMethod.POST);
        }
        public static CreditNoteListRequest List()
        {
            string url = ApiUtil.BuildUrl("credit_notes");
            return new CreditNoteListRequest(url);
        }
        [Obsolete]
        public static ListRequest CreditNotesForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "credit_notes");
            return new ListRequest(url);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
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
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string ReferenceInvoiceId 
        {
            get { return GetValue<string>("reference_invoice_id", true); }
        }
        public TypeEnum CreditNoteType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public ReasonCodeEnum ReasonCode 
        {
            get { return GetEnum<ReasonCodeEnum>("reason_code", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string VatNumber 
        {
            get { return GetValue<string>("vat_number", false); }
        }
        public DateTime? Date 
        {
            get { return GetDateTime("date", false); }
        }
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public int? Total 
        {
            get { return GetValue<int?>("total", false); }
        }
        public int? AmountAllocated 
        {
            get { return GetValue<int?>("amount_allocated", false); }
        }
        public int? AmountRefunded 
        {
            get { return GetValue<int?>("amount_refunded", false); }
        }
        public int? AmountAvailable 
        {
            get { return GetValue<int?>("amount_available", false); }
        }
        public DateTime? RefundedAt 
        {
            get { return GetDateTime("refunded_at", false); }
        }
        public DateTime? VoidedAt 
        {
            get { return GetDateTime("voided_at", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public int? RoundOffAmount 
        {
            get { return GetValue<int?>("round_off_amount", false); }
        }
        public List<CreditNoteLineItem> LineItems 
        {
            get { return GetResourceList<CreditNoteLineItem>("line_items"); }
        }
        public List<CreditNoteDiscount> Discounts 
        {
            get { return GetResourceList<CreditNoteDiscount>("discounts"); }
        }
        public List<CreditNoteLineItemDiscount> LineItemDiscounts 
        {
            get { return GetResourceList<CreditNoteLineItemDiscount>("line_item_discounts"); }
        }
        public List<CreditNoteLineItemTier> LineItemTiers 
        {
            get { return GetResourceList<CreditNoteLineItemTier>("line_item_tiers"); }
        }
        public List<CreditNoteTax> Taxes 
        {
            get { return GetResourceList<CreditNoteTax>("taxes"); }
        }
        public List<CreditNoteLineItemTax> LineItemTaxes 
        {
            get { return GetResourceList<CreditNoteLineItemTax>("line_item_taxes"); }
        }
        public List<CreditNoteLinkedRefund> LinkedRefunds 
        {
            get { return GetResourceList<CreditNoteLinkedRefund>("linked_refunds"); }
        }
        public List<CreditNoteAllocation> Allocations 
        {
            get { return GetResourceList<CreditNoteAllocation>("allocations"); }
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

            public CreateRequest ReferenceInvoiceId(string referenceInvoiceId) 
            {
                m_params.Add("reference_invoice_id", referenceInvoiceId);
                return this;
            }
            public CreateRequest Total(int total) 
            {
                m_params.AddOpt("total", total);
                return this;
            }
            public CreateRequest Type(CreditNote.TypeEnum type) 
            {
                m_params.Add("type", type);
                return this;
            }
            public CreateRequest ReasonCode(CreditNote.ReasonCodeEnum reasonCode) 
            {
                m_params.Add("reason_code", reasonCode);
                return this;
            }
            public CreateRequest Date(long date) 
            {
                m_params.AddOpt("date", date);
                return this;
            }
            public CreateRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public CreateRequest LineItemReferenceLineItemId(int index, string lineItemReferenceLineItemId) 
            {
                m_params.Add("line_items[reference_line_item_id][" + index + "]", lineItemReferenceLineItemId);
                return this;
            }
            public CreateRequest LineItemUnitAmount(int index, int lineItemUnitAmount) 
            {
                m_params.AddOpt("line_items[unit_amount][" + index + "]", lineItemUnitAmount);
                return this;
            }
            public CreateRequest LineItemQuantity(int index, int lineItemQuantity) 
            {
                m_params.AddOpt("line_items[quantity][" + index + "]", lineItemQuantity);
                return this;
            }
            public CreateRequest LineItemAmount(int index, int lineItemAmount) 
            {
                m_params.AddOpt("line_items[amount][" + index + "]", lineItemAmount);
                return this;
            }
            public CreateRequest LineItemDescription(int index, string lineItemDescription) 
            {
                m_params.AddOpt("line_items[description][" + index + "]", lineItemDescription);
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
            public RecordRefundRequest TransactionAmount(int transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public RecordRefundRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) 
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
        }
        public class VoidCreditNoteRequest : EntityRequest<VoidCreditNoteRequest> 
        {
            public VoidCreditNoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public VoidCreditNoteRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        public class CreditNoteListRequest : ListRequestBase<CreditNoteListRequest> 
        {
            public CreditNoteListRequest(string url) 
                    : base(url)
            {
            }

            public CreditNoteListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public StringFilter<CreditNoteListRequest> Id() 
            {
                return new StringFilter<CreditNoteListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CreditNoteListRequest> CustomerId() 
            {
                return new StringFilter<CreditNoteListRequest>("customer_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CreditNoteListRequest> SubscriptionId() 
            {
                return new StringFilter<CreditNoteListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public StringFilter<CreditNoteListRequest> ReferenceInvoiceId() 
            {
                return new StringFilter<CreditNoteListRequest>("reference_invoice_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<CreditNote.TypeEnum, CreditNoteListRequest> Type() 
            {
                return new EnumFilter<CreditNote.TypeEnum, CreditNoteListRequest>("type", this);        
            }
            public EnumFilter<CreditNote.ReasonCodeEnum, CreditNoteListRequest> ReasonCode() 
            {
                return new EnumFilter<CreditNote.ReasonCodeEnum, CreditNoteListRequest>("reason_code", this);        
            }
            public EnumFilter<CreditNote.StatusEnum, CreditNoteListRequest> Status() 
            {
                return new EnumFilter<CreditNote.StatusEnum, CreditNoteListRequest>("status", this);        
            }
            public TimestampFilter<CreditNoteListRequest> Date() 
            {
                return new TimestampFilter<CreditNoteListRequest>("date", this);        
            }
            public NumberFilter<int, CreditNoteListRequest> Total() 
            {
                return new NumberFilter<int, CreditNoteListRequest>("total", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, CreditNoteListRequest> PriceType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, CreditNoteListRequest>("price_type", this);        
            }
            public NumberFilter<int, CreditNoteListRequest> AmountAllocated() 
            {
                return new NumberFilter<int, CreditNoteListRequest>("amount_allocated", this);        
            }
            public NumberFilter<int, CreditNoteListRequest> AmountRefunded() 
            {
                return new NumberFilter<int, CreditNoteListRequest>("amount_refunded", this);        
            }
            public NumberFilter<int, CreditNoteListRequest> AmountAvailable() 
            {
                return new NumberFilter<int, CreditNoteListRequest>("amount_available", this);        
            }
            public TimestampFilter<CreditNoteListRequest> VoidedAt() 
            {
                return new TimestampFilter<CreditNoteListRequest>("voided_at", this);        
            }
            public TimestampFilter<CreditNoteListRequest> UpdatedAt() 
            {
                return new TimestampFilter<CreditNoteListRequest>("updated_at", this);        
            }
            public CreditNoteListRequest SortByDate(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","date");
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

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "adjustment")]
            Adjustment,
            [EnumMember(Value = "refundable")]
            Refundable,

        }
        public enum ReasonCodeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "write_off")]
            WriteOff,
            [EnumMember(Value = "subscription_change")]
            SubscriptionChange,
            [EnumMember(Value = "subscription_cancellation")]
            SubscriptionCancellation,
            [EnumMember(Value = "subscription_pause")]
            SubscriptionPause,
            [EnumMember(Value = "chargeback")]
            Chargeback,
            [EnumMember(Value = "product_unsatisfactory")]
            ProductUnsatisfactory,
            [EnumMember(Value = "service_unsatisfactory")]
            ServiceUnsatisfactory,
            [EnumMember(Value = "order_change")]
            OrderChange,
            [EnumMember(Value = "order_cancellation")]
            OrderCancellation,
            [EnumMember(Value = "waiver")]
            Waiver,
            [EnumMember(Value = "other")]
            Other,
            [EnumMember(Value = "fraudulent")]
            Fraudulent,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "adjusted")]
            Adjusted,
            [EnumMember(Value = "refunded")]
            Refunded,
            [EnumMember(Value = "refund_due")]
            RefundDue,
            [EnumMember(Value = "voided")]
            Voided,

        }

        #region Subclasses
        public class CreditNoteLineItem : Resource
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

        }
        public class CreditNoteDiscount : Resource
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
        public class CreditNoteLineItemDiscount : Resource
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
        public class CreditNoteLineItemTier : Resource
        {

            public string LineItemId() {
                return GetValue<string>("line_item_id", false);
            }

            public int StartingUnit() {
                return GetValue<int>("starting_unit", true);
            }

            public int? EndingUnit() {
                return GetValue<int?>("ending_unit", false);
            }

            public int QuantityUsed() {
                return GetValue<int>("quantity_used", true);
            }

            public int UnitAmount() {
                return GetValue<int>("unit_amount", true);
            }

        }
        public class CreditNoteTax : Resource
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
        public class CreditNoteLineItemTax : Resource
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
        public class CreditNoteLinkedRefund : Resource
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
        public class CreditNoteAllocation : Resource
        {

            public string InvoiceId() {
                return GetValue<string>("invoice_id", true);
            }

            public int AllocatedAmount() {
                return GetValue<int>("allocated_amount", true);
            }

            public DateTime AllocatedAt() {
                return (DateTime)GetDateTime("allocated_at", true);
            }

            public DateTime? InvoiceDate() {
                return GetDateTime("invoice_date", false);
            }

            public Invoice.StatusEnum InvoiceStatus() {
                return GetEnum<Invoice.StatusEnum>("invoice_status", true);
            }

        }

        #endregion
    }
}
