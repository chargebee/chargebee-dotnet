using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum TrialEndActionEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "site_default")]
         SiteDefault,

        [EnumMember(Value = "plan_default")]
         PlanDefault,

        [EnumMember(Value = "activate_subscription")]
         ActivateSubscription,

        [EnumMember(Value = "cancel_subscription")]
         CancelSubscription,

    }
}