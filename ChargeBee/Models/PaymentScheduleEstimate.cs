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

    public class PaymentScheduleEstimate : Resource 
    {
    
        public PaymentScheduleEstimate() { }

        public PaymentScheduleEstimate(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PaymentScheduleEstimate(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PaymentScheduleEstimate(String jsonString)
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
        public string SchemeId 
        {
            get { return GetValue<string>("scheme_id", true); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", false); }
        }
        public long Amount 
        {
            get { return GetValue<long>("amount", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public List<PaymentScheduleEstimateScheduleEntry> ScheduleEntries 
        {
            get { return GetResourceList<PaymentScheduleEstimateScheduleEntry>("schedule_entries"); }
        }
        
        #endregion
        

        public enum EntityTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "invoice")]
            Invoice,

        }

        #region Subclasses
        public class PaymentScheduleEstimateScheduleEntry : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "posted")]
                Posted,
                [EnumMember(Value = "payment_due")]
                PaymentDue,
                [EnumMember(Value = "paid")]
                Paid,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public DateTime Date {
                get { return (DateTime)GetDateTime("date", true); }
            }

            public long Amount {
                get { return GetValue<long>("amount", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

        }

        #endregion
    }
}
