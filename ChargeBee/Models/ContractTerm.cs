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

    public class ContractTerm : Resource 
    {
    

        #region Methods
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
        public DateTime ContractStart 
        {
            get { return (DateTime)GetDateTime("contract_start", true); }
        }
        public DateTime ContractEnd 
        {
            get { return (DateTime)GetDateTime("contract_end", true); }
        }
        public int BillingCycle 
        {
            get { return GetValue<int>("billing_cycle", true); }
        }
        public ActionAtTermEndEnum ActionAtTermEnd 
        {
            get { return GetEnum<ActionAtTermEndEnum>("action_at_term_end", true); }
        }
        public long TotalContractValue 
        {
            get { return GetValue<long>("total_contract_value", true); }
        }
        public int? CancellationCutoffPeriod 
        {
            get { return GetValue<int?>("cancellation_cutoff_period", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public int? RemainingBillingCycles 
        {
            get { return GetValue<int?>("remaining_billing_cycles", false); }
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

        #region Subclasses

        #endregion
    }
}
