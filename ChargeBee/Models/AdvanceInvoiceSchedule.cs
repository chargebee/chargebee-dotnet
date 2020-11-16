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

    public class AdvanceInvoiceSchedule : Resource 
    {
    
        public AdvanceInvoiceSchedule() { }

        public AdvanceInvoiceSchedule(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public AdvanceInvoiceSchedule(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public AdvanceInvoiceSchedule(String jsonString)
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
        public ScheduleTypeEnum? ScheduleType 
        {
            get { return GetEnum<ScheduleTypeEnum>("schedule_type", false); }
        }
        public AdvanceInvoiceScheduleFixedIntervalSchedule FixedIntervalSchedule 
        {
            get { return GetSubResource<AdvanceInvoiceScheduleFixedIntervalSchedule>("fixed_interval_schedule"); }
        }
        public AdvanceInvoiceScheduleSpecificDatesSchedule SpecificDatesSchedule 
        {
            get { return GetSubResource<AdvanceInvoiceScheduleSpecificDatesSchedule>("specific_dates_schedule"); }
        }
        
        #endregion
        

        public enum ScheduleTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "fixed_intervals")]
            FixedIntervals,
            [EnumMember(Value = "specific_dates")]
            SpecificDates,

        }

        #region Subclasses
        public class AdvanceInvoiceScheduleFixedIntervalSchedule : Resource
        {
            public enum EndScheduleOnEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "after_number_of_intervals")]
                AfterNumberOfIntervals,
                [EnumMember(Value = "specific_date")]
                SpecificDate,
                [EnumMember(Value = "subscription_end")]
                SubscriptionEnd,
            }

            public EndScheduleOnEnum? EndScheduleOn() {
                return GetEnum<EndScheduleOnEnum>("end_schedule_on", false);
            }

            public int? NumberOfOccurrences() {
                return GetValue<int?>("number_of_occurrences", false);
            }

            public int? DaysBeforeRenewal() {
                return GetValue<int?>("days_before_renewal", false);
            }

            public DateTime? EndDate() {
                return GetDateTime("end_date", false);
            }

            public DateTime CreatedAt() {
                return (DateTime)GetDateTime("created_at", true);
            }

            public int? TermsToCharge() {
                return GetValue<int?>("terms_to_charge", false);
            }

        }
        public class AdvanceInvoiceScheduleSpecificDatesSchedule : Resource
        {

            public int? TermsToCharge() {
                return GetValue<int?>("terms_to_charge", false);
            }

            public DateTime? Date() {
                return GetDateTime("date", false);
            }

            public DateTime CreatedAt() {
                return (DateTime)GetDateTime("created_at", true);
            }

        }

        #endregion
    }
}
