using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum OnEventEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("subscription_creation")]
         SubscriptionCreation,

        [Description("subscription_trial_start")]
         SubscriptionTrialStart,

        [Description("plan_activation")]
         PlanActivation,

        [Description("subscription_activation")]
         SubscriptionActivation,

    }
}