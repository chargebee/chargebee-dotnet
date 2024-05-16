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

    public class SubscriptionEstimate : Resource 
    {
    
        public SubscriptionEstimate() { }

        public SubscriptionEstimate(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public SubscriptionEstimate(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public SubscriptionEstimate(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public TrialEndActionEnum? TrialEndAction 
        {
            get { return GetEnum<TrialEndActionEnum>("trial_end_action", false); }
        }
        public DateTime? NextBillingAt 
        {
            get { return GetDateTime("next_billing_at", false); }
        }
        public DateTime? PauseDate 
        {
            get { return GetDateTime("pause_date", false); }
        }
        public DateTime? ResumeDate 
        {
            get { return GetDateTime("resume_date", false); }
        }
        public SubscriptionEstimateShippingAddress ShippingAddress 
        {
            get { return GetSubResource<SubscriptionEstimateShippingAddress>("shipping_address"); }
        }
        public SubscriptionEstimateContractTerm ContractTerm 
        {
            get { return GetSubResource<SubscriptionEstimateContractTerm>("contract_term"); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "future")]
            Future,
            [EnumMember(Value = "in_trial")]
            InTrial,
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "non_renewing")]
            NonRenewing,
            [EnumMember(Value = "paused")]
            Paused,
            [EnumMember(Value = "cancelled")]
            Cancelled,
            [EnumMember(Value = "transferred")]
            Transferred,

        }

        #region Subclasses
        public class SubscriptionEstimateShippingAddress : Resource
        {

            public string FirstName {
                get { return GetValue<string>("first_name", false); }
            }

            public string LastName {
                get { return GetValue<string>("last_name", false); }
            }

            public string Email {
                get { return GetValue<string>("email", false); }
            }

            public string Company {
                get { return GetValue<string>("company", false); }
            }

            public string Phone {
                get { return GetValue<string>("phone", false); }
            }

            public string Line1 {
                get { return GetValue<string>("line1", false); }
            }

            public string Line2 {
                get { return GetValue<string>("line2", false); }
            }

            public string Line3 {
                get { return GetValue<string>("line3", false); }
            }

            public string City {
                get { return GetValue<string>("city", false); }
            }

            public string StateCode {
                get { return GetValue<string>("state_code", false); }
            }

            public string State {
                get { return GetValue<string>("state", false); }
            }

            public string Country {
                get { return GetValue<string>("country", false); }
            }

            public string Zip {
                get { return GetValue<string>("zip", false); }
            }

            public ValidationStatusEnum? ValidationStatus {
                get { return GetEnum<ValidationStatusEnum>("validation_status", false); }
            }

            public int Index {
                get { return GetValue<int>("index", true); }
            }

        }
        public class SubscriptionEstimateContractTerm : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "active")]
                Active,
                [EnumMember(Value = "completed")]
                Completed,
                [EnumMember(Value = "cancelled")]
                Cancelled,
                [EnumMember(Value = "terminated")]
                Terminated,
            }
            public enum ActionAtTermEndEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "renew")]
                Renew,
                [EnumMember(Value = "evergreen")]
                Evergreen,
                [EnumMember(Value = "cancel")]
                Cancel,
                [EnumMember(Value = "renew_once")]
                RenewOnce,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public DateTime ContractStart {
                get { return (DateTime)GetDateTime("contract_start", true); }
            }

            public DateTime ContractEnd {
                get { return (DateTime)GetDateTime("contract_end", true); }
            }

            public int BillingCycle {
                get { return GetValue<int>("billing_cycle", true); }
            }

            public ActionAtTermEndEnum ActionAtTermEnd {
                get { return GetEnum<ActionAtTermEndEnum>("action_at_term_end", true); }
            }

            public long TotalContractValue {
                get { return GetValue<long>("total_contract_value", true); }
            }

            public long TotalContractValueBeforeTax {
                get { return GetValue<long>("total_contract_value_before_tax", true); }
            }

            public int? CancellationCutoffPeriod {
                get { return GetValue<int?>("cancellation_cutoff_period", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public string SubscriptionId {
                get { return GetValue<string>("subscription_id", true); }
            }

            public int? RemainingBillingCycles {
                get { return GetValue<int?>("remaining_billing_cycles", false); }
            }

        }

        #endregion
    }
}
