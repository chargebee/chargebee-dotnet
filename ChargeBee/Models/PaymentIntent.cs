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

    public class PaymentIntent : Resource 
    {
    
        public PaymentIntent() { }

        public PaymentIntent(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PaymentIntent(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PaymentIntent(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("payment_intents");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("payment_intents", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("payment_intents", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public int Amount 
        {
            get { return GetValue<int>("amount", true); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", true); }
        }
        public DateTime ExpiresAt 
        {
            get { return (DateTime)GetDateTime("expires_at", true); }
        }
        public string ReferenceId 
        {
            get { return GetValue<string>("reference_id", false); }
        }
        public PaymentMethodTypeEnum? PaymentMethodType 
        {
            get { return GetEnum<PaymentMethodTypeEnum>("payment_method_type", false); }
        }
        public string SuccessUrl 
        {
            get { return GetValue<string>("success_url", false); }
        }
        public string FailureUrl 
        {
            get { return GetValue<string>("failure_url", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string Gateway 
        {
            get { return GetValue<string>("gateway", false); }
        }
        public PaymentIntentPaymentAttempt ActivePaymentAttempt 
        {
            get { return GetSubResource<PaymentIntentPaymentAttempt>("active_payment_attempt"); }
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

            public CreateRequest BusinessEntityId(string businessEntityId) 
            {
                m_params.AddOpt("business_entity_id", businessEntityId);
                return this;
            }
            public CreateRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public CreateRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.Add("currency_code", currencyCode);
                return this;
            }
            public CreateRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.AddOpt("gateway_account_id", gatewayAccountId);
                return this;
            }
            public CreateRequest ReferenceId(string referenceId) 
            {
                m_params.AddOpt("reference_id", referenceId);
                return this;
            }
            public CreateRequest PaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method_type", paymentMethodType);
                return this;
            }
            public CreateRequest SuccessUrl(string successUrl) 
            {
                m_params.AddOpt("success_url", successUrl);
                return this;
            }
            public CreateRequest FailureUrl(string failureUrl) 
            {
                m_params.AddOpt("failure_url", failureUrl);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public UpdateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public UpdateRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.AddOpt("gateway_account_id", gatewayAccountId);
                return this;
            }
            public UpdateRequest PaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method_type", paymentMethodType);
                return this;
            }
            public UpdateRequest SuccessUrl(string successUrl) 
            {
                m_params.AddOpt("success_url", successUrl);
                return this;
            }
            public UpdateRequest FailureUrl(string failureUrl) 
            {
                m_params.AddOpt("failure_url", failureUrl);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "inited")]
            Inited,
            [EnumMember(Value = "in_progress")]
            InProgress,
            [EnumMember(Value = "authorized")]
            Authorized,
            [EnumMember(Value = "consumed")]
            Consumed,
            [EnumMember(Value = "expired")]
            Expired,

        }
        public enum PaymentMethodTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "card")]
            Card,
            [EnumMember(Value = "ideal")]
            Ideal,
            [EnumMember(Value = "sofort")]
            Sofort,
            [EnumMember(Value = "bancontact")]
            Bancontact,
            [EnumMember(Value = "google_pay")]
            GooglePay,
            [EnumMember(Value = "dotpay")]
            Dotpay,
            [EnumMember(Value = "giropay")]
            Giropay,
            [EnumMember(Value = "apple_pay")]
            ApplePay,
            [EnumMember(Value = "upi")]
            Upi,
            [EnumMember(Value = "netbanking_emandates")]
            NetbankingEmandates,
            [EnumMember(Value = "paypal_express_checkout")]
            PaypalExpressCheckout,
            [EnumMember(Value = "direct_debit")]
            DirectDebit,

        }

        #region Subclasses
        public class PaymentIntentPaymentAttempt : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "inited")]
                Inited,
                [EnumMember(Value = "requires_identification")]
                RequiresIdentification,
                [EnumMember(Value = "requires_challenge")]
                RequiresChallenge,
                [EnumMember(Value = "requires_redirection")]
                RequiresRedirection,
                [EnumMember(Value = "authorized")]
                Authorized,
                [EnumMember(Value = "refused")]
                Refused,
                [EnumMember(Value = "pending_authorization")]
                PendingAuthorization,
            }

            public string Id {
                get { return GetValue<string>("id", false); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public PaymentMethodTypeEnum? PaymentMethodType {
                get { return GetEnum<PaymentMethodTypeEnum>("payment_method_type", false); }
            }

            public string IdAtGateway {
                get { return GetValue<string>("id_at_gateway", false); }
            }

            public string ErrorCode {
                get { return GetValue<string>("error_code", false); }
            }

            public string ErrorText {
                get { return GetValue<string>("error_text", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public DateTime ModifiedAt {
                get { return (DateTime)GetDateTime("modified_at", true); }
            }

        }

        #endregion
    }
}
