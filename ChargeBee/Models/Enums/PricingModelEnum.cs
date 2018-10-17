using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum PricingModelEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("flat_fee")]
         FlatFee,

        [Description("per_unit")]
         PerUnit,

        [Description("tiered")]
         Tiered,

        [Description("volume")]
         Volume,

        [Description("stairstep")]
         Stairstep,

    }
}