using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum OnEventEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "subscription_creation")]
         SubscriptionCreation,

        [EnumMember(Value = "subscription_trial_start")]
         SubscriptionTrialStart,

        [EnumMember(Value = "plan_activation")]
         PlanActivation,

        [EnumMember(Value = "subscription_activation")]
         SubscriptionActivation,

        [EnumMember(Value = "contract_termination")]
         ContractTermination,

    }
}