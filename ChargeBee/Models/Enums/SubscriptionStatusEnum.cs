using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum SubscriptionStatusEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("in_trial")]
        InTrial,

        [Description("active")]
        Active,

        [Description("non_renewing")]
        NonRenewing,

        [Description("cancelled")]
        Cancelled,

    }
}