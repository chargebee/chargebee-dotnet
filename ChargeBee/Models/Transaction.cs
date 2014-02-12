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

    public class Transaction : Resource 
    {
    

        #region Methods
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("transactions");
            return new ListRequest(url);
        }
        public static ListRequest TransactionsForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "transactions");
            return new ListRequest(url);
        }
        public static ListRequest TransactionsForInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "transactions");
            return new ListRequest(url);
        }
        public static EntityRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("transactions", CheckNull(id));
            return new EntityRequest(url, HttpMethod.GET);
        }
        public static RefundRequest Refund(string id)
        {
            string url = ApiUtil.BuildUrl("transactions", CheckNull(id), "refund");
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
            get { return GetValue<string>("subscription_id", false); }
        }
        public PaymentMethodEnum PaymentMethod 
        {
            get { return GetEnum<PaymentMethodEnum>("payment_method", true); }
        }
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public TypeEnum TransactionType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public DateTime? Date 
        {
            get { return GetDateTime("date", false); }
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
        public string VoidDescription 
        {
            get { return GetValue<string>("void_description", false); }
        }
        public string MaskedCardNumber 
        {
            get { return GetValue<string>("masked_card_number", true); }
        }
        public string RefundedTxnId 
        {
            get { return GetValue<string>("refunded_txn_id", false); }
        }
        
        #endregion
        
        #region Requests
        public class RefundRequest : EntityRequest 
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

        public enum PaymentMethodEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("card")]
            Card,
            [Description("cash")]
            Cash,
            [Description("check")]
            Check,
            [Description("bank_transfer")]
            BankTransfer,
            [Description("other")]
            Other,

        }
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

        }
        public enum StatusEnum
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

        #region Subclasses

        #endregion
    }
}
