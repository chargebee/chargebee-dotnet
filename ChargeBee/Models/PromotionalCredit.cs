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

    public class PromotionalCredit : Resource 
    {
    
        public PromotionalCredit() { }

        public PromotionalCredit(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PromotionalCredit(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PromotionalCredit(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static AddRequest Add()
        {
            string url = ApiUtil.BuildUrl("promotional_credits", "add");
            return new AddRequest(url, HttpMethod.POST);
        }
        public static DeductRequest Deduct()
        {
            string url = ApiUtil.BuildUrl("promotional_credits", "deduct");
            return new DeductRequest(url, HttpMethod.POST);
        }
        public static SetRequest Set()
        {
            string url = ApiUtil.BuildUrl("promotional_credits", "set");
            return new SetRequest(url, HttpMethod.POST);
        }
        public static PromotionalCreditListRequest List()
        {
            string url = ApiUtil.BuildUrl("promotional_credits");
            return new PromotionalCreditListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("promotional_credits", CheckNull(id));
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
            get { return GetValue<string>("customer_id", true); }
        }
        public TypeEnum PromotionalCreditType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public string AmountInDecimal 
        {
            get { return GetValue<string>("amount_in_decimal", false); }
        }
        public int Amount 
        {
            get { return GetValue<int>("amount", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", true); }
        }
        public CreditTypeEnum CreditType 
        {
            get { return GetEnum<CreditTypeEnum>("credit_type", true); }
        }
        public string Reference 
        {
            get { return GetValue<string>("reference", false); }
        }
        public int ClosingBalance 
        {
            get { return GetValue<int>("closing_balance", true); }
        }
        public string DoneBy 
        {
            get { return GetValue<string>("done_by", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        
        #endregion
        
        #region Requests
        public class AddRequest : EntityRequest<AddRequest> 
        {
            public AddRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public AddRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public AddRequest AmountInDecimal(string amountInDecimal) 
            {
                m_params.AddOpt("amount_in_decimal", amountInDecimal);
                return this;
            }
            public AddRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public AddRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public AddRequest CreditType(ChargeBee.Models.Enums.CreditTypeEnum creditType) 
            {
                m_params.AddOpt("credit_type", creditType);
                return this;
            }
            public AddRequest Reference(string reference) 
            {
                m_params.AddOpt("reference", reference);
                return this;
            }
        }
        public class DeductRequest : EntityRequest<DeductRequest> 
        {
            public DeductRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeductRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public DeductRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public DeductRequest AmountInDecimal(string amountInDecimal) 
            {
                m_params.AddOpt("amount_in_decimal", amountInDecimal);
                return this;
            }
            public DeductRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public DeductRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public DeductRequest CreditType(ChargeBee.Models.Enums.CreditTypeEnum creditType) 
            {
                m_params.AddOpt("credit_type", creditType);
                return this;
            }
            public DeductRequest Reference(string reference) 
            {
                m_params.AddOpt("reference", reference);
                return this;
            }
        }
        public class SetRequest : EntityRequest<SetRequest> 
        {
            public SetRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public SetRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public SetRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public SetRequest AmountInDecimal(string amountInDecimal) 
            {
                m_params.AddOpt("amount_in_decimal", amountInDecimal);
                return this;
            }
            public SetRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public SetRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public SetRequest CreditType(ChargeBee.Models.Enums.CreditTypeEnum creditType) 
            {
                m_params.AddOpt("credit_type", creditType);
                return this;
            }
            public SetRequest Reference(string reference) 
            {
                m_params.AddOpt("reference", reference);
                return this;
            }
        }
        public class PromotionalCreditListRequest : ListRequestBase<PromotionalCreditListRequest> 
        {
            public PromotionalCreditListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<PromotionalCreditListRequest> Id() 
            {
                return new StringFilter<PromotionalCreditListRequest>("id", this);        
            }
            public TimestampFilter<PromotionalCreditListRequest> CreatedAt() 
            {
                return new TimestampFilter<PromotionalCreditListRequest>("created_at", this);        
            }
            public EnumFilter<PromotionalCredit.TypeEnum, PromotionalCreditListRequest> Type() 
            {
                return new EnumFilter<PromotionalCredit.TypeEnum, PromotionalCreditListRequest>("type", this);        
            }
            public StringFilter<PromotionalCreditListRequest> CustomerId() 
            {
                return new StringFilter<PromotionalCreditListRequest>("customer_id", this);        
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "increment")]
            Increment,
            [EnumMember(Value = "decrement")]
            Decrement,

        }

        #region Subclasses

        #endregion
    }
}
