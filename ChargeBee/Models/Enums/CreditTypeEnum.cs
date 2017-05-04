using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum CreditTypeEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("loyalty_credits")]
         LoyaltyCredits,

        [Description("referral_rewards")]
         ReferralRewards,

        [Description("general")]
         General,

    }
}