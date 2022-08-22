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

    public class Transaction : Resource 
    {
    
        public Transaction() { }

        public Transaction(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Transaction(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Transaction(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateAuthorizationRequest CreateAuthorization()
        {
            string url = ApiUtil.BuildUrl("transactions", "create_authorization");
            return new CreateAuthorizationRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> VoidTransaction(string id)
        {
            string url = ApiUtil.BuildUrl("transactions", CheckNull(id), "void");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static RecordRefundRequest RecordRefund(string id)
        {
            string url = ApiUtil.BuildUrl("transactions", CheckNull(id), "record_refund");
            return new RecordRefundRequest(url, HttpMethod.POST);
        }
        public static RefundRequest Refund(string id)
        {
            string url = ApiUtil.BuildUrl("transactions", CheckNull(id), "refund");
            return new RefundRequest(url, HttpMethod.POST);
        }
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
        public static DeleteOfflineTransactionRequest DeleteOfflineTransaction(string id)
        {
            string url = ApiUtil.BuildUrl("transactions", CheckNull(id), "delete_offline_transaction");
            return new DeleteOfflineTransactionRequest(url, HttpMethod.POST);
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
        public string PaymentSourceId 
        {
            get { return GetValue<string>("payment_source_id", false); }
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
        public DateTime? SettledAt 
        {
            get { return GetDateTime("settled_at", false); }
        }
        public decimal? ExchangeRate 
        {
            get { return GetValue<decimal?>("exchange_rate", false); }
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
        public FraudFlagEnum? FraudFlag 
        {
            get { return GetEnum<FraudFlagEnum>("fraud_flag", false); }
        }
        public InitiatorTypeEnum? InitiatorType 
        {
            get { return GetEnum<InitiatorTypeEnum>("initiator_type", false); }
        }
        public bool? ThreeDSecure 
        {
            get { return GetValue<bool?>("three_d_secure", false); }
        }
        public AuthorizationReasonEnum? AuthorizationReason 
        {
            get { return GetEnum<AuthorizationReasonEnum>("authorization_reason", false); }
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
        public string FraudReason 
        {
            get { return GetValue<string>("fraud_reason", false); }
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
        public string ReferenceAuthorizationId 
        {
            get { return GetValue<string>("reference_authorization_id", false); }
        }
        public int? AmountCapturable 
        {
            get { return GetValue<int?>("amount_capturable", false); }
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
        public List<TransactionLinkedPayment> LinkedPayments 
        {
            get { return GetResourceList<TransactionLinkedPayment>("linked_payments"); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        public string Iin 
        {
            get { return GetValue<string>("iin", false); }
        }
        public string Last4 
        {
            get { return GetValue<string>("last4", false); }
        }
        public string MerchantReferenceId 
        {
            get { return GetValue<string>("merchant_reference_id", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
        }
        public string PaymentMethodDetails 
        {
            get { return GetValue<string>("payment_method_details", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateAuthorizationRequest : EntityRequest<CreateAuthorizationRequest> 
        {
            public CreateAuthorizationRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateAuthorizationRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateAuthorizationRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateAuthorizationRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateAuthorizationRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
        }
        public class RecordRefundRequest : EntityRequest<RecordRefundRequest> 
        {
            public RecordRefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordRefundRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public RecordRefundRequest PaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum paymentMethod) 
            {
                m_params.Add("payment_method", paymentMethod);
                return this;
            }
            public RecordRefundRequest Date(long date) 
            {
                m_params.Add("date", date);
                return this;
            }
            public RecordRefundRequest ReferenceNumber(string referenceNumber) 
            {
                m_params.AddOpt("reference_number", referenceNumber);
                return this;
            }
            public RecordRefundRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        public class RefundRequest : EntityRequest<RefundRequest> 
        {
            public RefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RefundRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public RefundRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
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
            public StringFilter<TransactionListRequest> PaymentSourceId() 
            {
                return new StringFilter<TransactionListRequest>("payment_source_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.PaymentMethodEnum, TransactionListRequest> PaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PaymentMethodEnum, TransactionListRequest>("payment_method", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.GatewayEnum, TransactionListRequest> Gateway() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.GatewayEnum, TransactionListRequest>("gateway", this);        
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
            public EnumFilter<Transaction.TypeEnum, TransactionListRequest> Type() 
            {
                return new EnumFilter<Transaction.TypeEnum, TransactionListRequest>("type", this);        
            }
            public TimestampFilter<TransactionListRequest> Date() 
            {
                return new TimestampFilter<TransactionListRequest>("date", this);        
            }
            public NumberFilter<int, TransactionListRequest> Amount() 
            {
                return new NumberFilter<int, TransactionListRequest>("amount", this);        
            }
            public NumberFilter<int, TransactionListRequest> AmountCapturable() 
            {
                return new NumberFilter<int, TransactionListRequest>("amount_capturable", this);        
            }
            public EnumFilter<Transaction.StatusEnum, TransactionListRequest> Status() 
            {
                return new EnumFilter<Transaction.StatusEnum, TransactionListRequest>("status", this);        
            }
            public TimestampFilter<TransactionListRequest> UpdatedAt() 
            {
                return new TimestampFilter<TransactionListRequest>("updated_at", this);        
            }
            public TransactionListRequest SortByDate(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","date");
                return this;
            }
            public TransactionListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        public class DeleteOfflineTransactionRequest : EntityRequest<DeleteOfflineTransactionRequest> 
        {
            public DeleteOfflineTransactionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteOfflineTransactionRequest Comment(string comment) 
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
            [EnumMember(Value = "authorization")]
            Authorization,
            [EnumMember(Value = "payment")]
            Payment,
            [EnumMember(Value = "refund")]
            Refund,
            [EnumMember(Value = "payment_reversal")]
            PaymentReversal,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "in_progress")]
            InProgress,
            [EnumMember(Value = "success")]
            Success,
            [EnumMember(Value = "voided")]
            Voided,
            [EnumMember(Value = "failure")]
            Failure,
            [EnumMember(Value = "timeout")]
            Timeout,
            [EnumMember(Value = "needs_attention")]
            NeedsAttention,

        }
        public enum FraudFlagEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "safe")]
            Safe,
            [EnumMember(Value = "suspicious")]
            Suspicious,
            [EnumMember(Value = "fraudulent")]
            Fraudulent,

        }
        public enum InitiatorTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "customer")]
            Customer,
            [EnumMember(Value = "merchant")]
            Merchant,

        }
        public enum AuthorizationReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "blocking_funds")]
            BlockingFunds,
            [EnumMember(Value = "verification")]
            Verification,

        }

        #region Subclasses
        public class TransactionLinkedInvoice : Resource
        {

            public string InvoiceId {
                get { return GetValue<string>("invoice_id", true); }
            }

            public int AppliedAmount {
                get { return GetValue<int>("applied_amount", true); }
            }

            public DateTime AppliedAt {
                get { return (DateTime)GetDateTime("applied_at", true); }
            }

            public DateTime? InvoiceDate {
                get { return GetDateTime("invoice_date", false); }
            }

            public int? InvoiceTotal {
                get { return GetValue<int?>("invoice_total", false); }
            }

            public Invoice.StatusEnum InvoiceStatus {
                get { return GetEnum<Invoice.StatusEnum>("invoice_status", true); }
            }

        }
        public class TransactionLinkedCreditNote : Resource
        {

            public string CnId {
                get { return GetValue<string>("cn_id", true); }
            }

            public int AppliedAmount {
                get { return GetValue<int>("applied_amount", true); }
            }

            public DateTime AppliedAt {
                get { return (DateTime)GetDateTime("applied_at", true); }
            }

            public CreditNote.ReasonCodeEnum? CnReasonCode {
                get { return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", false); }
            }

            public string CnCreateReasonCode {
                get { return GetValue<string>("cn_create_reason_code", false); }
            }

            public DateTime? CnDate {
                get { return GetDateTime("cn_date", false); }
            }

            public int? CnTotal {
                get { return GetValue<int?>("cn_total", false); }
            }

            public CreditNote.StatusEnum CnStatus {
                get { return GetEnum<CreditNote.StatusEnum>("cn_status", true); }
            }

            public string CnReferenceInvoiceId {
                get { return GetValue<string>("cn_reference_invoice_id", true); }
            }

        }
        public class TransactionLinkedRefund : Resource
        {

            public string TxnId {
                get { return GetValue<string>("txn_id", true); }
            }

            public Transaction.StatusEnum TxnStatus {
                get { return GetEnum<Transaction.StatusEnum>("txn_status", true); }
            }

            public DateTime TxnDate {
                get { return (DateTime)GetDateTime("txn_date", true); }
            }

            public int TxnAmount {
                get { return GetValue<int>("txn_amount", true); }
            }

        }
        public class TransactionLinkedPayment : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "in_progress")]
                InProgress,
                [EnumMember(Value = "success")]
                Success,
                [EnumMember(Value = "voided")]
                Voided,
                [EnumMember(Value = "failure")]
                Failure,
                [EnumMember(Value = "timeout")]
                Timeout,
                [EnumMember(Value = "needs_attention")]
                NeedsAttention,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public StatusEnum? Status {
                get { return GetEnum<StatusEnum>("status", false); }
            }

            public int? Amount {
                get { return GetValue<int?>("amount", false); }
            }

            public DateTime? Date {
                get { return GetDateTime("date", false); }
            }

        }

        #endregion
    }
}
