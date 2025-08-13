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

    public class Currency : Resource 
    {
    
        public Currency() { }

        public Currency(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Currency(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Currency(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("currencies", "list");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("currencies", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("currencies");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("currencies", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static AddScheduleRequest AddSchedule(string id)
        {
            string url = ApiUtil.BuildUrl("currencies", CheckNull(id), "add_schedule");
            return new AddScheduleRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> RemoveSchedule(string id)
        {
            string url = ApiUtil.BuildUrl("currencies", CheckNull(id), "remove_schedule");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public bool Enabled 
        {
            get { return GetValue<bool>("enabled", true); }
        }
        public ForexTypeEnum? ForexType 
        {
            get { return GetEnum<ForexTypeEnum>("forex_type", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public bool IsBaseCurrency 
        {
            get { return GetValue<bool>("is_base_currency", true); }
        }
        public string ManualExchangeRate 
        {
            get { return GetValue<string>("manual_exchange_rate", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.Add("currency_code", currencyCode);
                return this;
            }
            public CreateRequest ForexType(Currency.ForexTypeEnum forexType) 
            {
                m_params.Add("forex_type", forexType);
                return this;
            }
            public CreateRequest ManualExchangeRate(string manualExchangeRate) 
            {
                m_params.AddOpt("manual_exchange_rate", manualExchangeRate);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest ForexType(Currency.ForexTypeEnum forexType) 
            {
                m_params.Add("forex_type", forexType);
                return this;
            }
            public UpdateRequest ManualExchangeRate(string manualExchangeRate) 
            {
                m_params.AddOpt("manual_exchange_rate", manualExchangeRate);
                return this;
            }
        }
        public class AddScheduleRequest : EntityRequest<AddScheduleRequest> 
        {
            public AddScheduleRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddScheduleRequest ManualExchangeRate(string manualExchangeRate) 
            {
                m_params.Add("manual_exchange_rate", manualExchangeRate);
                return this;
            }
            public AddScheduleRequest ScheduleAt(long scheduleAt) 
            {
                m_params.Add("schedule_at", scheduleAt);
                return this;
            }
        }
        #endregion

        public enum ForexTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "manual")]
            Manual,
            [EnumMember(Value = "auto")]
            Auto,

        }

        #region Subclasses

        #endregion
    }
}
