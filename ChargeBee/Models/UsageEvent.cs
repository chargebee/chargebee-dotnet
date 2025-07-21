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

    public class UsageEvent : Resource 
    {
    
        public UsageEvent() { }

        public UsageEvent(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public UsageEvent(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public UsageEvent(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("usage_events");
            return new CreateRequest(url, HttpMethod.POST).SetSubDomain("ingest").IsJsonRequest(true).SetIdempotent(false);
        }
        public static BatchIngestRequest BatchIngest()
        {
            string url = ApiUtil.BuildUrl("batch", "usage_events");
            return new BatchIngestRequest(url, HttpMethod.POST).SetSubDomain("ingest").IsJsonRequest(true).SetIdempotent(false);
        }
        #endregion
        
        #region Properties
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string DeduplicationId 
        {
            get { return GetValue<string>("deduplication_id", true); }
        }
        public long UsageTimestamp 
        {
            get { return GetValue<long>("usage_timestamp", true); }
        }
        public Dictionary<String, Object> Properties 
        {
            get { return GetMap("properties", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest DeduplicationId(string deduplicationId) 
            {
                m_params.Add("deduplication_id", deduplicationId);
                return this;
            }
            public CreateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public CreateRequest UsageTimestamp(long usageTimestamp) 
            {
                m_params.Add("usage_timestamp", usageTimestamp);
                return this;
            }
            public CreateRequest Properties(Dictionary<String, Object> properties) 
            {
                m_params.Add("properties", properties);
                return this;
            }
        }
        public class BatchIngestRequest : EntityRequest<BatchIngestRequest> 
        {
            public BatchIngestRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        public BatchIngestRequest Events(List<EventBatchIngestInputParams> array){
            JArray jArray = new JArray();
            foreach (var item in array){
                jArray.Add(item.ToJObject());
            }
            m_params.Add("events", jArray);
            return this;
        }
        
        }
        #endregion


        #region Subclasses

        public class EventBatchIngestInputParams { 
            public  string DeduplicationId { get; }
            public  string SubscriptionId { get; }
            public  long UsageTimestamp { get; }
            public  Dictionary<String, Object> Properties { get; }
            public EventBatchIngestInputParams(EventBatchIngestInputParamsBuilder builder){
                this.DeduplicationId = builder.GetDeduplicationId();
                this.SubscriptionId = builder.GetSubscriptionId();
                this.UsageTimestamp = builder.GetUsageTimestamp();
                this.Properties = builder.GetProperties();
                
            }
            public JObject ToJObject()
            {
                return new JObject
                {
                    ["deduplication_id"] =  JToken.FromObject(this.DeduplicationId),
                    ["subscription_id"] =  JToken.FromObject(this.SubscriptionId),
                    ["usage_timestamp"] =  JToken.FromObject(this.UsageTimestamp),
                    ["properties"] =  JToken.FromObject(this.Properties),
                    
                };
            }
        }
        public class EventBatchIngestInputParamsBuilder
        { 
            private string DeduplicationId; 
            private string SubscriptionId; 
            private long UsageTimestamp; 
            private Dictionary<String, Object> Properties; 
            
            public EventBatchIngestInputParamsBuilder SetDeduplicationId ( string DeduplicationId )
            {
                this.DeduplicationId = DeduplicationId;
                return this;
            } 
            public EventBatchIngestInputParamsBuilder SetSubscriptionId ( string SubscriptionId )
            {
                this.SubscriptionId = SubscriptionId;
                return this;
            } 
            public EventBatchIngestInputParamsBuilder SetUsageTimestamp ( long UsageTimestamp )
            {
                this.UsageTimestamp = UsageTimestamp;
                return this;
            } 
            public EventBatchIngestInputParamsBuilder SetProperties ( Dictionary<String, Object> Properties )
            {
                this.Properties = Properties;
                return this;
            } 

            
            public string GetDeduplicationId ()
            {
                return this.DeduplicationId;
            } 
            public string GetSubscriptionId ()
            {
                return this.SubscriptionId;
            } 
            public long GetUsageTimestamp ()
            {
                return this.UsageTimestamp;
            } 
            public Dictionary<String, Object> GetProperties ()
            {
                return this.Properties;
            } 

            public EventBatchIngestInputParams Build() {
                return new EventBatchIngestInputParams(this);
            }

        }
        
        #endregion
    }
}
