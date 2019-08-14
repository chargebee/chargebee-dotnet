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
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
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
            }

            public string Id() {
                return GetValue<string>("id", false);
            }

            public StatusEnum Status() {
                return GetEnum<StatusEnum>("status", true);
            }

            public string IdAtGateway() {
                return GetValue<string>("id_at_gateway", false);
            }

            public string ErrorCode() {
                return GetValue<string>("error_code", false);
            }

            public string ErrorText() {
                return GetValue<string>("error_text", false);
            }

            public DateTime CreatedAt() {
                return (DateTime)GetDateTime("created_at", true);
            }

            public DateTime ModifiedAt() {
                return (DateTime)GetDateTime("modified_at", true);
            }

        }

        #endregion
    }
}
