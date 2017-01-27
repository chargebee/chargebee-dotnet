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

    public class Transaction : Resource 
    {
    

        #region Methods
        public static TransactionListRequest List()
        {
            string url = ApiUtil.BuildUrl("transactions");
            return new TransactionListRequest(url);
        }
        [Obsolete]
        public static ListRequest TransactionsForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "transactions");
            return new ListRequest(url);
        }
        [Obsolete]
        public static ListRequest TransactionsForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "transactions");
            return new ListRequest(url);
        }
        public static ListRequest PaymentsForInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "payments");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("transactions", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", false); }
        }
        public PaymentMethodEnum PaymentMethod 
        {
            get { return GetEnum<PaymentMethodEnum>("payment_method", true); }
        }
        public string ReferenceNumber 
        {
            get { return GetValue<string>("reference_number", false); }
        }
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
        }
        public TypeEnum TransactionType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public DateTime? Date 
        {
            get { return GetDateTime("date", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public int? Amount 
        {
            get { return GetValue<int?>("amount", false); }
        }
        public string IdAtGateway 
        {
            get { return GetValue<string>("id_at_gateway", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string ErrorCode 
        {
            get { return GetValue<string>("error_code", false); }
        }
        public string ErrorText 
        {
            get { return GetValue<string>("error_text", false); }
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
        public int? AmountUnused 
        {
            get { return GetValue<int?>("amount_unused", false); }
        }
        public string MaskedCardNumber 
        {
            get { return GetValue<string>("masked_card_number", false); }
        }
        public string ReferenceTransactionId 
        {
            get { return GetValue<string>("reference_transaction_id", false); }
        }
        public string RefundedTxnId 
        {
            get { return GetValue<string>("refunded_txn_id", false); }
        }
        public string ReversalTransactionId 
        {
            get { return GetValue<string>("reversal_transaction_id", false); }
        }
        public List<TransactionLinkedInvoice> LinkedInvoices 
        {
            get { return GetResourceList<TransactionLinkedInvoice>("linked_invoices"); }
        }
        public List<TransactionLinkedCreditNote> LinkedCreditNotes 
        {
            get { return GetResourceList<TransactionLinkedCreditNote>("linked_credit_notes"); }
        }
        public List<TransactionLinkedRefund> LinkedRefunds 
        {
            get { return GetResourceList<TransactionLinkedRefund>("linked_refunds"); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        
        #endregion
        
        #region Requests
        public class TransactionListRequest : ListRequestBase<TransactionListRequest> 
        {
            public TransactionListRequest(string url) 
                    : base(url)
            {
            }

            public TransactionListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public StringFilter<TransactionListRequest> Id() 
            {
                return new StringFilter<TransactionListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<TransactionListRequest> CustomerId() 
            {
                return new StringFilter<TransactionListRequest>("customer_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public StringFilter<TransactionListRequest> SubscriptionId() 
            {
                return new StringFilter<TransactionListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public EnumFilter<PaymentMethodEnum, TransactionListRequest> PaymentMethod() 
            {
                return new EnumFilter<PaymentMethodEnum, TransactionListRequest>("payment_method", this);        
            }
            public EnumFilter<GatewayEnum, TransactionListRequest> Gateway() 
            {
                return new EnumFilter<GatewayEnum, TransactionListRequest>("gateway", this);        
            }
            public StringFilter<TransactionListRequest> GatewayAccountId() 
            {
                return new StringFilter<TransactionListRequest>("gateway_account_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<TransactionListRequest> IdAtGateway() 
            {
                return new StringFilter<TransactionListRequest>("id_at_gateway", this);        
            }
            public StringFilter<TransactionListRequest> ReferenceNumber() 
            {
                return new StringFilter<TransactionListRequest>("reference_number", this).SupportsPresenceOperator(true);        
            }
            public EnumFilter<TypeEnum, TransactionListRequest> Type() 
            {
                return new EnumFilter<TypeEnum, TransactionListRequest>("type", this);        
            }
            public TimestampFilter<TransactionListRequest> Date() 
            {
                return new TimestampFilter<TransactionListRequest>("date", this);        
            }
            public NumberFilter<int, TransactionListRequest> Amount() 
            {
                return new NumberFilter<int, TransactionListRequest>("amount", this);        
            }
            public EnumFilter<StatusEnum, TransactionListRequest> Status() 
            {
                return new EnumFilter<StatusEnum, TransactionListRequest>("status", this);        
            }
            public TimestampFilter<TransactionListRequest> UpdatedAt() 
            {
                return new TimestampFilter<TransactionListRequest>("updated_at", this);        
            }
            public TransactionListRequest SortByDate(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","date");
                return this;
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("authorization")]
            Authorization,
            [Description("payment")]
            Payment,
            [Description("refund")]
            Refund,
            [Description("payment_reversal")]
            PaymentReversal,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("in_progress")]
            InProgress,
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

        #region Subclasses
        public class TransactionLinkedInvoice : Resource
        {

            public string InvoiceId() {
                return GetValue<string>("invoice_id", true);
            }

            public int AppliedAmount() {
                return GetValue<int>("applied_amount", true);
            }

            public DateTime AppliedAt() {
                return (DateTime)GetDateTime("applied_at", true);
            }

            public DateTime? InvoiceDate() {
                return GetDateTime("invoice_date", false);
            }

            public int? InvoiceTotal() {
                return GetValue<int?>("invoice_total", false);
            }

            public Invoice.StatusEnum InvoiceStatus() {
                return GetEnum<Invoice.StatusEnum>("invoice_status", true);
            }

        }
        public class TransactionLinkedCreditNote : Resource
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

            public int? CnTotal() {
                return GetValue<int?>("cn_total", false);
            }

            public CreditNote.StatusEnum CnStatus() {
                return GetEnum<CreditNote.StatusEnum>("cn_status", true);
            }

            public string CnReferenceInvoiceId() {
                return GetValue<string>("cn_reference_invoice_id", true);
            }

        }
        public class TransactionLinkedRefund : Resource
        {

            public string TxnId() {
                return GetValue<string>("txn_id", true);
            }

            public Transaction.StatusEnum TxnStatus() {
                return GetEnum<Transaction.StatusEnum>("txn_status", true);
            }

            public DateTime TxnDate() {
                return (DateTime)GetDateTime("txn_date", true);
            }

            public int TxnAmount() {
                return GetValue<int>("txn_amount", true);
            }

        }

        #endregion
    }
}
