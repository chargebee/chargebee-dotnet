using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum ReferralSystemEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("referral_candy")]
         ReferralCandy,

        [Description("referral_saasquatch")]
         ReferralSaasquatch,

        [Description("friendbuy")]
         Friendbuy,

    }
}