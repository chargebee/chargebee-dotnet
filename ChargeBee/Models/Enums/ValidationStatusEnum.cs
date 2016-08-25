using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum ValidationStatusEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("not_validated")]
         NotValidated,

        [Description("valid")]
         Valid,

        [Description("partially_valid")]
         PartiallyValid,

        [Description("invalid")]
         Invalid,

    }
}