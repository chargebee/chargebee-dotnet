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

    public class CollectionsReminderSequence : Resource 
    {
    
        public CollectionsReminderSequence() { }

        public CollectionsReminderSequence(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CollectionsReminderSequence(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CollectionsReminderSequence(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? PausedUntil 
        {
            get { return GetDateTime("paused_until", false); }
        }
        public string PauseNote 
        {
            get { return GetValue<string>("pause_note", false); }
        }
        public DateTime? StartedAt 
        {
            get { return GetDateTime("started_at", false); }
        }
        public DateTime? CompletedAt 
        {
            get { return GetDateTime("completed_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public List<CollectionsReminderSequenceActionLog> ActionLogs 
        {
            get { return GetResourceList<CollectionsReminderSequenceActionLog>("action_logs"); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "completed")]
            Completed,
            [EnumMember(Value = "paused")]
            Paused,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class CollectionsReminderSequenceActionLog : Resource
        {
            public enum ActionTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "send_email")]
                SendEmail,
            }
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "completed")]
                Completed,
                [EnumMember(Value = "scheduled")]
                Scheduled,
                [EnumMember(Value = "skipped")]
                Skipped,
            }
            public enum ReasonCodeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "date_already_passed")]
                DateAlreadyPassed,
                [EnumMember(Value = "before_invoice_date")]
                BeforeInvoiceDate,
                [EnumMember(Value = "trigger_event_not_received")]
                TriggerEventNotReceived,
                [EnumMember(Value = "sequence_paused")]
                SequencePaused,
            }

            public ActionTypeEnum ActionType {
                get { return GetEnum<ActionTypeEnum>("action_type", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public ReasonCodeEnum? ReasonCode {
                get { return GetEnum<ReasonCodeEnum>("reason_code", false); }
            }

            public DateTime? ExecutedAt {
                get { return GetDateTime("executed_at", false); }
            }

            public DateTime? ScheduledAt {
                get { return GetDateTime("scheduled_at", false); }
            }

        }

        #endregion
    }
}
