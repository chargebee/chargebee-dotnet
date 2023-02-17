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
    
        public CreditNote() { }

        public CreditNote(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CreditNote(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CreditNote(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

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
        public static EntityRequest<Type> DownloadEinvoice(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "download_einvoice");
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static RefundRequest Refund(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "refund");
            return new RefundRequest(url, HttpMethod.POST);
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
        public static RemoveTaxWithheldRefundRequest RemoveTaxWithheldRefund(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "remove_tax_withheld_refund");
            return new RemoveTaxWithheldRefundRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> ResendEinvoice(string id)
        {
            string url = ApiUtil.BuildUrl("credit_notes", CheckNull(id), "resend_einvoice");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static ImportCreditNoteRequest ImportCreditNote()
        {
            string url = ApiUtil.BuildUrl("credit_notes", "import_credit_note");
            return new ImportCreditNoteRequest(url, HttpMethod.POST);
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
        public ReasonCodeEnum? ReasonCode 
        {
            get { return GetEnum<ReasonCodeEnum>("reason_code", false); }
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
        public DateTime? GeneratedAt 
        {
            get { return GetDateTime("generated_at", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public ChannelEnum? Channel 
        {
            get { return GetEnum<ChannelEnum>("channel", false); }
        }
        public CreditNoteEinvoice Einvoice 
        {
            get { return GetSubResource<CreditNoteEinvoice>("einvoice"); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public int? SubTotalInLocalCurrency 
        {
            get { return GetValue<int?>("sub_total_in_local_currency", false); }
        }
        public int? TotalInLocalCurrency 
        {
            get { return GetValue<int?>("total_in_local_currency", false); }
        }
        public string LocalCurrencyCode 
        {
            get { return GetValue<string>("local_currency_code", false); }
        }
        public int? RoundOffAmount 
        {
            get { return GetValue<int?>("round_off_amount", false); }
        }
        public int? FractionalCorrection 
        {
            get { return GetValue<int?>("fractional_correction", false); }
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
        public string CreateReasonCode 
        {
            get { return GetValue<string>("create_reason_code", false); }
        }
        public string VatNumberPrefix 
        {
            get { return GetValue<string>("vat_number_prefix", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", true); }
        }
        public CreditNoteShippingAddress ShippingAddress 
        {
            get { return GetSubResource<CreditNoteShippingAddress>("shipping_address"); }
        }
        public CreditNoteBillingAddress BillingAddress 
        {
            get { return GetSubResource<CreditNoteBillingAddress>("billing_address"); }
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
                m_params.AddOpt("reason_code", reasonCode);
                return this;
            }
            public CreateRequest CreateReasonCode(string createReasonCode) 
            {
                m_params.AddOpt("create_reason_code", createReasonCode);
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
            public CreateRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
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
            public CreateRequest LineItemUnitAmountInDecimal(int index, string lineItemUnitAmountInDecimal) 
            {
                m_params.AddOpt("line_items[unit_amount_in_decimal][" + index + "]", lineItemUnitAmountInDecimal);
                return this;
            }
            public CreateRequest LineItemQuantity(int index, int lineItemQuantity) 
            {
                m_params.AddOpt("line_items[quantity][" + index + "]", lineItemQuantity);
                return this;
            }
            public CreateRequest LineItemQuantityInDecimal(int index, string lineItemQuantityInDecimal) 
            {
                m_params.AddOpt("line_items[quantity_in_decimal][" + index + "]", lineItemQuantityInDecimal);
                return this;
            }
            public CreateRequest LineItemAmount(int index, int lineItemAmount) 
            {
                m_params.AddOpt("line_items[amount][" + index + "]", lineItemAmount);
                return this;
            }
            public CreateRequest LineItemDateFrom(int index, long lineItemDateFrom) 
            {
                m_params.AddOpt("line_items[date_from][" + index + "]", lineItemDateFrom);
                return this;
            }
            public CreateRequest LineItemDateTo(int index, long lineItemDateTo) 
            {
                m_params.AddOpt("line_items[date_to][" + index + "]", lineItemDateTo);
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
            public RefundRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public RefundRequest RefundReasonCode(string refundReasonCode) 
            {
                m_params.AddOpt("refund_reason_code", refundReasonCode);
                return this;
            }
        }
        public class RecordRefundRequest : EntityRequest<RecordRefundRequest> 
        {
            public RecordRefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordRefundRequest RefundReasonCode(string refundReasonCode) 
            {
                m_params.AddOpt("refund_reason_code", refundReasonCode);
                return this;
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
            public StringFilter<CreditNoteListRequest> CreateReasonCode() 
            {
                return new StringFilter<CreditNoteListRequest>("create_reason_code", this).SupportsMultiOperators(true);        
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
            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, CreditNoteListRequest> Channel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, CreditNoteListRequest>("channel", this);        
            }
            public EnumFilter<CreditNoteEinvoice.StatusEnum, CreditNoteListRequest> EinvoiceStatus() 
            {
                return new EnumFilter<CreditNoteEinvoice.StatusEnum, CreditNoteListRequest>("einvoice[status]", this);        
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
        public class RemoveTaxWithheldRefundRequest : EntityRequest<RemoveTaxWithheldRefundRequest> 
        {
            public RemoveTaxWithheldRefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemoveTaxWithheldRefundRequest TaxWithheldId(string taxWithheldId) 
            {
                m_params.Add("tax_withheld[id]", taxWithheldId);
                return this;
            }
        }
        public class ImportCreditNoteRequest : EntityRequest<ImportCreditNoteRequest> 
        {
            public ImportCreditNoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportCreditNoteRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
            public ImportCreditNoteRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public ImportCreditNoteRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public ImportCreditNoteRequest ReferenceInvoiceId(string referenceInvoiceId) 
            {
                m_params.Add("reference_invoice_id", referenceInvoiceId);
                return this;
            }
            public ImportCreditNoteRequest Type(CreditNote.TypeEnum type) 
            {
                m_params.Add("type", type);
                return this;
            }
            public ImportCreditNoteRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public ImportCreditNoteRequest CreateReasonCode(string createReasonCode) 
            {
                m_params.Add("create_reason_code", createReasonCode);
                return this;
            }
            public ImportCreditNoteRequest Date(long date) 
            {
                m_params.AddOpt("date", date);
                return this;
            }
            public ImportCreditNoteRequest Status(CreditNote.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public ImportCreditNoteRequest Total(int total) 
            {
                m_params.AddOpt("total", total);
                return this;
            }
            public ImportCreditNoteRequest RefundedAt(long refundedAt) 
            {
                m_params.AddOpt("refunded_at", refundedAt);
                return this;
            }
            public ImportCreditNoteRequest VoidedAt(long voidedAt) 
            {
                m_params.AddOpt("voided_at", voidedAt);
                return this;
            }
            public ImportCreditNoteRequest SubTotal(int subTotal) 
            {
                m_params.AddOpt("sub_total", subTotal);
                return this;
            }
            public ImportCreditNoteRequest RoundOffAmount(int roundOffAmount) 
            {
                m_params.AddOpt("round_off_amount", roundOffAmount);
                return this;
            }
            public ImportCreditNoteRequest FractionalCorrection(int fractionalCorrection) 
            {
                m_params.AddOpt("fractional_correction", fractionalCorrection);
                return this;
            }
            public ImportCreditNoteRequest VatNumberPrefix(string vatNumberPrefix) 
            {
                m_params.AddOpt("vat_number_prefix", vatNumberPrefix);
                return this;
            }
            public ImportCreditNoteRequest LineItemReferenceLineItemId(int index, string lineItemReferenceLineItemId) 
            {
                m_params.AddOpt("line_items[reference_line_item_id][" + index + "]", lineItemReferenceLineItemId);
                return this;
            }
            public ImportCreditNoteRequest LineItemId(int index, string lineItemId) 
            {
                m_params.AddOpt("line_items[id][" + index + "]", lineItemId);
                return this;
            }
            public ImportCreditNoteRequest LineItemDateFrom(int index, long lineItemDateFrom) 
            {
                m_params.AddOpt("line_items[date_from][" + index + "]", lineItemDateFrom);
                return this;
            }
            public ImportCreditNoteRequest LineItemDateTo(int index, long lineItemDateTo) 
            {
                m_params.AddOpt("line_items[date_to][" + index + "]", lineItemDateTo);
                return this;
            }
            public ImportCreditNoteRequest LineItemSubscriptionId(int index, string lineItemSubscriptionId) 
            {
                m_params.AddOpt("line_items[subscription_id][" + index + "]", lineItemSubscriptionId);
                return this;
            }
            public ImportCreditNoteRequest LineItemDescription(int index, string lineItemDescription) 
            {
                m_params.Add("line_items[description][" + index + "]", lineItemDescription);
                return this;
            }
            public ImportCreditNoteRequest LineItemUnitAmount(int index, int lineItemUnitAmount) 
            {
                m_params.AddOpt("line_items[unit_amount][" + index + "]", lineItemUnitAmount);
                return this;
            }
            public ImportCreditNoteRequest LineItemQuantity(int index, int lineItemQuantity) 
            {
                m_params.AddOpt("line_items[quantity][" + index + "]", lineItemQuantity);
                return this;
            }
            public ImportCreditNoteRequest LineItemAmount(int index, int lineItemAmount) 
            {
                m_params.AddOpt("line_items[amount][" + index + "]", lineItemAmount);
                return this;
            }
            public ImportCreditNoteRequest LineItemUnitAmountInDecimal(int index, string lineItemUnitAmountInDecimal) 
            {
                m_params.AddOpt("line_items[unit_amount_in_decimal][" + index + "]", lineItemUnitAmountInDecimal);
                return this;
            }
            public ImportCreditNoteRequest LineItemQuantityInDecimal(int index, string lineItemQuantityInDecimal) 
            {
                m_params.AddOpt("line_items[quantity_in_decimal][" + index + "]", lineItemQuantityInDecimal);
                return this;
            }
            public ImportCreditNoteRequest LineItemAmountInDecimal(int index, string lineItemAmountInDecimal) 
            {
                m_params.AddOpt("line_items[amount_in_decimal][" + index + "]", lineItemAmountInDecimal);
                return this;
            }
            public ImportCreditNoteRequest LineItemEntityType(int index, CreditNoteLineItem.EntityTypeEnum lineItemEntityType) 
            {
                m_params.AddOpt("line_items[entity_type][" + index + "]", lineItemEntityType);
                return this;
            }
            public ImportCreditNoteRequest LineItemEntityId(int index, string lineItemEntityId) 
            {
                m_params.AddOpt("line_items[entity_id][" + index + "]", lineItemEntityId);
                return this;
            }
            public ImportCreditNoteRequest LineItemItemLevelDiscount1EntityId(int index, string lineItemItemLevelDiscount1EntityId) 
            {
                m_params.AddOpt("line_items[item_level_discount1_entity_id][" + index + "]", lineItemItemLevelDiscount1EntityId);
                return this;
            }
            public ImportCreditNoteRequest LineItemItemLevelDiscount1Amount(int index, int lineItemItemLevelDiscount1Amount) 
            {
                m_params.AddOpt("line_items[item_level_discount1_amount][" + index + "]", lineItemItemLevelDiscount1Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemItemLevelDiscount2EntityId(int index, string lineItemItemLevelDiscount2EntityId) 
            {
                m_params.AddOpt("line_items[item_level_discount2_entity_id][" + index + "]", lineItemItemLevelDiscount2EntityId);
                return this;
            }
            public ImportCreditNoteRequest LineItemItemLevelDiscount2Amount(int index, int lineItemItemLevelDiscount2Amount) 
            {
                m_params.AddOpt("line_items[item_level_discount2_amount][" + index + "]", lineItemItemLevelDiscount2Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax1Name(int index, string lineItemTax1Name) 
            {
                m_params.AddOpt("line_items[tax1_name][" + index + "]", lineItemTax1Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax1Amount(int index, int lineItemTax1Amount) 
            {
                m_params.AddOpt("line_items[tax1_amount][" + index + "]", lineItemTax1Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax2Name(int index, string lineItemTax2Name) 
            {
                m_params.AddOpt("line_items[tax2_name][" + index + "]", lineItemTax2Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax2Amount(int index, int lineItemTax2Amount) 
            {
                m_params.AddOpt("line_items[tax2_amount][" + index + "]", lineItemTax2Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax3Name(int index, string lineItemTax3Name) 
            {
                m_params.AddOpt("line_items[tax3_name][" + index + "]", lineItemTax3Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax3Amount(int index, int lineItemTax3Amount) 
            {
                m_params.AddOpt("line_items[tax3_amount][" + index + "]", lineItemTax3Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax4Name(int index, string lineItemTax4Name) 
            {
                m_params.AddOpt("line_items[tax4_name][" + index + "]", lineItemTax4Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax4Amount(int index, int lineItemTax4Amount) 
            {
                m_params.AddOpt("line_items[tax4_amount][" + index + "]", lineItemTax4Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax5Name(int index, string lineItemTax5Name) 
            {
                m_params.AddOpt("line_items[tax5_name][" + index + "]", lineItemTax5Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax5Amount(int index, int lineItemTax5Amount) 
            {
                m_params.AddOpt("line_items[tax5_amount][" + index + "]", lineItemTax5Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax6Name(int index, string lineItemTax6Name) 
            {
                m_params.AddOpt("line_items[tax6_name][" + index + "]", lineItemTax6Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax6Amount(int index, int lineItemTax6Amount) 
            {
                m_params.AddOpt("line_items[tax6_amount][" + index + "]", lineItemTax6Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax7Name(int index, string lineItemTax7Name) 
            {
                m_params.AddOpt("line_items[tax7_name][" + index + "]", lineItemTax7Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax7Amount(int index, int lineItemTax7Amount) 
            {
                m_params.AddOpt("line_items[tax7_amount][" + index + "]", lineItemTax7Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax8Name(int index, string lineItemTax8Name) 
            {
                m_params.AddOpt("line_items[tax8_name][" + index + "]", lineItemTax8Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax8Amount(int index, int lineItemTax8Amount) 
            {
                m_params.AddOpt("line_items[tax8_amount][" + index + "]", lineItemTax8Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax9Name(int index, string lineItemTax9Name) 
            {
                m_params.AddOpt("line_items[tax9_name][" + index + "]", lineItemTax9Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax9Amount(int index, int lineItemTax9Amount) 
            {
                m_params.AddOpt("line_items[tax9_amount][" + index + "]", lineItemTax9Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax10Name(int index, string lineItemTax10Name) 
            {
                m_params.AddOpt("line_items[tax10_name][" + index + "]", lineItemTax10Name);
                return this;
            }
            public ImportCreditNoteRequest LineItemTax10Amount(int index, int lineItemTax10Amount) 
            {
                m_params.AddOpt("line_items[tax10_amount][" + index + "]", lineItemTax10Amount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierLineItemId(int index, string lineItemTierLineItemId) 
            {
                m_params.Add("line_item_tiers[line_item_id][" + index + "]", lineItemTierLineItemId);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierStartingUnit(int index, int lineItemTierStartingUnit) 
            {
                m_params.AddOpt("line_item_tiers[starting_unit][" + index + "]", lineItemTierStartingUnit);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierEndingUnit(int index, int lineItemTierEndingUnit) 
            {
                m_params.AddOpt("line_item_tiers[ending_unit][" + index + "]", lineItemTierEndingUnit);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierQuantityUsed(int index, int lineItemTierQuantityUsed) 
            {
                m_params.AddOpt("line_item_tiers[quantity_used][" + index + "]", lineItemTierQuantityUsed);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierUnitAmount(int index, int lineItemTierUnitAmount) 
            {
                m_params.AddOpt("line_item_tiers[unit_amount][" + index + "]", lineItemTierUnitAmount);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierStartingUnitInDecimal(int index, string lineItemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[starting_unit_in_decimal][" + index + "]", lineItemTierStartingUnitInDecimal);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierEndingUnitInDecimal(int index, string lineItemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[ending_unit_in_decimal][" + index + "]", lineItemTierEndingUnitInDecimal);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierQuantityUsedInDecimal(int index, string lineItemTierQuantityUsedInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[quantity_used_in_decimal][" + index + "]", lineItemTierQuantityUsedInDecimal);
                return this;
            }
            public ImportCreditNoteRequest LineItemTierUnitAmountInDecimal(int index, string lineItemTierUnitAmountInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[unit_amount_in_decimal][" + index + "]", lineItemTierUnitAmountInDecimal);
                return this;
            }
            public ImportCreditNoteRequest DiscountLineItemId(int index, string discountLineItemId) 
            {
                m_params.AddOpt("discounts[line_item_id][" + index + "]", discountLineItemId);
                return this;
            }
            public ImportCreditNoteRequest DiscountEntityType(int index, CreditNoteDiscount.EntityTypeEnum discountEntityType) 
            {
                m_params.Add("discounts[entity_type][" + index + "]", discountEntityType);
                return this;
            }
            public ImportCreditNoteRequest DiscountEntityId(int index, string discountEntityId) 
            {
                m_params.AddOpt("discounts[entity_id][" + index + "]", discountEntityId);
                return this;
            }
            public ImportCreditNoteRequest DiscountDescription(int index, string discountDescription) 
            {
                m_params.AddOpt("discounts[description][" + index + "]", discountDescription);
                return this;
            }
            public ImportCreditNoteRequest DiscountAmount(int index, int discountAmount) 
            {
                m_params.Add("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public ImportCreditNoteRequest TaxName(int index, string taxName) 
            {
                m_params.Add("taxes[name][" + index + "]", taxName);
                return this;
            }
            public ImportCreditNoteRequest TaxRate(int index, double taxRate) 
            {
                m_params.Add("taxes[rate][" + index + "]", taxRate);
                return this;
            }
            public ImportCreditNoteRequest TaxAmount(int index, int taxAmount) 
            {
                m_params.AddOpt("taxes[amount][" + index + "]", taxAmount);
                return this;
            }
            public ImportCreditNoteRequest TaxDescription(int index, string taxDescription) 
            {
                m_params.AddOpt("taxes[description][" + index + "]", taxDescription);
                return this;
            }
            public ImportCreditNoteRequest TaxJurisType(int index, ChargeBee.Models.Enums.TaxJurisTypeEnum taxJurisType) 
            {
                m_params.AddOpt("taxes[juris_type][" + index + "]", taxJurisType);
                return this;
            }
            public ImportCreditNoteRequest TaxJurisName(int index, string taxJurisName) 
            {
                m_params.AddOpt("taxes[juris_name][" + index + "]", taxJurisName);
                return this;
            }
            public ImportCreditNoteRequest TaxJurisCode(int index, string taxJurisCode) 
            {
                m_params.AddOpt("taxes[juris_code][" + index + "]", taxJurisCode);
                return this;
            }
            public ImportCreditNoteRequest AllocationInvoiceId(int index, string allocationInvoiceId) 
            {
                m_params.Add("allocations[invoice_id][" + index + "]", allocationInvoiceId);
                return this;
            }
            public ImportCreditNoteRequest AllocationAllocatedAmount(int index, int allocationAllocatedAmount) 
            {
                m_params.Add("allocations[allocated_amount][" + index + "]", allocationAllocatedAmount);
                return this;
            }
            public ImportCreditNoteRequest AllocationAllocatedAt(int index, long allocationAllocatedAt) 
            {
                m_params.Add("allocations[allocated_at][" + index + "]", allocationAllocatedAt);
                return this;
            }
            public ImportCreditNoteRequest LinkedRefundAmount(int index, int linkedRefundAmount) 
            {
                m_params.Add("linked_refunds[amount][" + index + "]", linkedRefundAmount);
                return this;
            }
            public ImportCreditNoteRequest LinkedRefundPaymentMethod(int index, ChargeBee.Models.Enums.PaymentMethodEnum linkedRefundPaymentMethod) 
            {
                m_params.Add("linked_refunds[payment_method][" + index + "]", linkedRefundPaymentMethod);
                return this;
            }
            public ImportCreditNoteRequest LinkedRefundDate(int index, long linkedRefundDate) 
            {
                m_params.Add("linked_refunds[date][" + index + "]", linkedRefundDate);
                return this;
            }
            public ImportCreditNoteRequest LinkedRefundReferenceNumber(int index, string linkedRefundReferenceNumber) 
            {
                m_params.AddOpt("linked_refunds[reference_number][" + index + "]", linkedRefundReferenceNumber);
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
        public class CreditNoteEinvoice : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "scheduled")]
                Scheduled,
                [EnumMember(Value = "skipped")]
                Skipped,
                [EnumMember(Value = "in_progress")]
                InProgress,
                [EnumMember(Value = "success")]
                Success,
                [EnumMember(Value = "failed")]
                Failed,
                [EnumMember(Value = "registered")]
                Registered,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public string Message {
                get { return GetValue<string>("message", false); }
            }

        }
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

            public string ReferenceLineItemId {
                get { return GetValue<string>("reference_line_item_id", false); }
            }

            public string Description {
                get { return GetValue<string>("description", true); }
            }

            public string EntityDescription {
                get { return GetValue<string>("entity_description", false); }
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
        public class CreditNoteLineItemTier : Resource
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
        public class CreditNoteTax : Resource
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
        public class CreditNoteLineItemTax : Resource
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
        public class CreditNoteLinkedRefund : Resource
        {

            public string TxnId {
                get { return GetValue<string>("txn_id", true); }
            }

            public int AppliedAmount {
                get { return GetValue<int>("applied_amount", true); }
            }

            public DateTime AppliedAt {
                get { return (DateTime)GetDateTime("applied_at", true); }
            }

            public Transaction.StatusEnum? TxnStatus {
                get { return GetEnum<Transaction.StatusEnum>("txn_status", false); }
            }

            public DateTime? TxnDate {
                get { return GetDateTime("txn_date", false); }
            }

            public int? TxnAmount {
                get { return GetValue<int?>("txn_amount", false); }
            }

            public string RefundReasonCode {
                get { return GetValue<string>("refund_reason_code", false); }
            }

        }
        public class CreditNoteAllocation : Resource
        {

            public string InvoiceId {
                get { return GetValue<string>("invoice_id", true); }
            }

            public int AllocatedAmount {
                get { return GetValue<int>("allocated_amount", true); }
            }

            public DateTime AllocatedAt {
                get { return (DateTime)GetDateTime("allocated_at", true); }
            }

            public DateTime? InvoiceDate {
                get { return GetDateTime("invoice_date", false); }
            }

            public Invoice.StatusEnum InvoiceStatus {
                get { return GetEnum<Invoice.StatusEnum>("invoice_status", true); }
            }

        }
        public class CreditNoteShippingAddress : Resource
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
        public class CreditNoteBillingAddress : Resource
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
