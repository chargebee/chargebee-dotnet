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
using System.Threading.Tasks;
using System.Net;

namespace ChargeBee.Models
{

    public class TimeMachine : Resource 
    {
    
        public TimeMachine() { }

        public TimeMachine(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public TimeMachine(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public TimeMachine(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("time_machines", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static StartAfreshRequest StartAfresh(string id)
        {
            string url = ApiUtil.BuildUrl("time_machines", CheckNull(id), "start_afresh");
            return new StartAfreshRequest(url, HttpMethod.POST);
        }
        public static TravelForwardRequest TravelForward(string id)
        {
            string url = ApiUtil.BuildUrl("time_machines", CheckNull(id), "travel_forward");
            return new TravelForwardRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Name 
        {
            get { return GetValue<string>("name", true); }
        }
        public TimeTravelStatusEnum TimeTravelStatus 
        {
            get { return GetEnum<TimeTravelStatusEnum>("time_travel_status", true); }
        }
        public DateTime GenesisTime 
        {
            get { return (DateTime)GetDateTime("genesis_time", true); }
        }
        public DateTime DestinationTime 
        {
            get { return (DateTime)GetDateTime("destination_time", true); }
        }
        public string FailureCode 
        {
            get { return GetValue<string>("failure_code", false); }
        }
        public string FailureReason 
        {
            get { return GetValue<string>("failure_reason", false); }
        }
        public string ErrorJson 
        {
            get { return GetValue<string>("error_json", false); }
        }
                public TimeMachine WaitForTimeTravelCompletion() {
            return WaitForTimeTravelCompletion(null);
        }

        public TimeMachine WaitForTimeTravelCompletion(ApiConfig config)
        {
            int count = 0;
            while (this.TimeTravelStatus == TimeTravelStatusEnum.InProgress)
            {
                if (count++ > 30)
                {
                    throw new Exception("Time travel is taking too much time");
                }
                var t = Task.Factory.StartNew(() =>
                {
                    Task.Delay(ApiConfig.TimeTravelMillis).Wait();
                });
                t.Wait();
                EntityRequest<Type> req = Retrieve(this.Name);
                this.JObj = ((config == null) ? req.Request() : req.Request(config)).TimeMachine.JObj;
            }
            if (this.TimeTravelStatus == TimeTravelStatusEnum.Failed)
            {
                Dictionary<String, String> errorJson = JsonConvert.DeserializeObject<Dictionary<String, String>>(this.ErrorJson
                );
                HttpStatusCode httpStatusCode = (HttpStatusCode)Convert.ToInt32(errorJson["http_code"]);
                throw new Exceptions.OperationFailedException(httpStatusCode, errorJson);
            }
            if (this.TimeTravelStatus == TimeTravelStatusEnum.NotEnabled || this.TimeTravelStatus == TimeTravelStatusEnum.UnKnown)
            {
                throw new Exception("Time travel is in wrong state : " + this.TimeTravelStatus);
            }
            return this;
        }
        #endregion
        
        #region Requests
        public class StartAfreshRequest : EntityRequest<StartAfreshRequest> 
        {
            public StartAfreshRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StartAfreshRequest GenesisTime(long genesisTime) 
            {
                m_params.AddOpt("genesis_time", genesisTime);
                return this;
            }
        }
        public class TravelForwardRequest : EntityRequest<TravelForwardRequest> 
        {
            public TravelForwardRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public TravelForwardRequest DestinationTime(long destinationTime) 
            {
                m_params.AddOpt("destination_time", destinationTime);
                return this;
            }
        }
        #endregion

        public enum TimeTravelStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "not_enabled")]
            NotEnabled,
            [EnumMember(Value = "in_progress")]
            InProgress,
            [EnumMember(Value = "succeeded")]
            Succeeded,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses

        #endregion
    }
}
