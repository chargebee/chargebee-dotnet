using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum ReferrerRewardTypeEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("none")]
         None,

        [Description("referral_direct_reward")]
         ReferralDirectReward,

        [Description("custom_promotional_credit")]
         CustomPromotionalCredit,

        [Description("custom_revenue_percent_based")]
         CustomRevenuePercentBased,

    }
}