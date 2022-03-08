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

    public class Event : Resource 
    {
    
        public Event() { }

        public Event(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Event(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Event(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EventListRequest List()
        {
            string url = ApiUtil.BuildUrl("events");
            return new EventListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("events", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public DateTime OccurredAt 
        {
            get { return (DateTime)GetDateTime("occurred_at", true); }
        }
        public SourceEnum Source 
        {
            get { return GetEnum<SourceEnum>("source", true); }
        }
        public string User 
        {
            get { return GetValue<string>("user", false); }
        }
        [Obsolete]
        public WebhookStatusEnum WebhookStatus 
        {
            get { return GetEnum<WebhookStatusEnum>("webhook_status", true); }
        }
        [Obsolete]
        public string WebhookFailureReason 
        {
            get { return GetValue<string>("webhook_failure_reason", false); }
        }
        public List<EventWebhook> Webhooks 
        {
            get { return GetResourceList<EventWebhook>("webhooks"); }
        }
        public EventTypeEnum? EventType 
        {
            get { return GetEnum<EventTypeEnum>("event_type", false); }
        }
        public ApiVersionEnum? ApiVersion 
        {
            get { return GetEnum<ApiVersionEnum>("api_version", false); }
        }
        public EventContent Content
        {
            get { return new EventContent(GetValue<JToken>("content")); }
        }
        #endregion
        
        #region Requests
        public class EventListRequest : ListRequestBase<EventListRequest> 
        {
            public EventListRequest(string url) 
                    : base(url)
            {
            }

            [Obsolete]
            public EventListRequest StartTime(long startTime) 
            {
                m_params.AddOpt("start_time", startTime);
                return this;
            }
            [Obsolete]
            public EventListRequest EndTime(long endTime) 
            {
                m_params.AddOpt("end_time", endTime);
                return this;
            }
            public StringFilter<EventListRequest> Id() 
            {
                return new StringFilter<EventListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<WebhookStatusEnum, EventListRequest> WebhookStatus() 
            {
                return new EnumFilter<WebhookStatusEnum, EventListRequest>("webhook_status", this);        
            }
            [Obsolete]
            public EventListRequest WebhookStatus(WebhookStatusEnum webhookStatus) 
            {
                m_params.AddOpt("webhook_status", webhookStatus);
                return this;
            }
            public EnumFilter<ChargeBee.Models.Enums.EventTypeEnum, EventListRequest> EventType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.EventTypeEnum, EventListRequest>("event_type", this);        
            }
            [Obsolete]
            public EventListRequest EventType(ChargeBee.Models.Enums.EventTypeEnum eventType) 
            {
                m_params.AddOpt("event_type", eventType);
                return this;
            }
            public EnumFilter<ChargeBee.Models.Enums.SourceEnum, EventListRequest> Source() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.SourceEnum, EventListRequest>("source", this);        
            }
            public TimestampFilter<EventListRequest> OccurredAt() 
            {
                return new TimestampFilter<EventListRequest>("occurred_at", this);        
            }
            public EventListRequest SortByOccurredAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","occurred_at");
                return this;
            }
        }
        #endregion

        [Obsolete]
        public enum WebhookStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "not_configured")]
            NotConfigured,
            [EnumMember(Value = "scheduled")]
            Scheduled,
            [EnumMember(Value = "succeeded")]
            Succeeded,
            [EnumMember(Value = "re_scheduled")]
            ReScheduled,
            [EnumMember(Value = "failed")]
            Failed,
            [EnumMember(Value = "skipped")]
            Skipped,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }

        #region Subclasses
        public class EventWebhook : Resource
        {
            public enum WebhookStatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "not_configured")]
                NotConfigured,
                [EnumMember(Value = "scheduled")]
                Scheduled,
                [EnumMember(Value = "succeeded")]
                Succeeded,
                [EnumMember(Value = "re_scheduled")]
                ReScheduled,
                [EnumMember(Value = "failed")]
                Failed,
                [EnumMember(Value = "skipped")]
                Skipped,
                [EnumMember(Value = "not_applicable")]
                NotApplicable,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public WebhookStatusEnum WebhookStatus {
                get { return GetEnum<WebhookStatusEnum>("webhook_status", true); }
            }

        }

        public class EventContent : ResultBase
        {

            public EventContent () { }

            internal EventContent(JToken jobj)
            {
                m_jobj = jobj;
            }
        }
        #endregion
    }
}
