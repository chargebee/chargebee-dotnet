using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum CreditTypeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "loyalty_credits")]
         LoyaltyCredits,

        [EnumMember(Value = "referral_rewards")]
         ReferralRewards,

        [EnumMember(Value = "general")]
         General,

    }
}