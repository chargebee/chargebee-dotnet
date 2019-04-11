using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum ValidationStatusEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "not_validated")]
         NotValidated,

        [EnumMember(Value = "valid")]
         Valid,

        [EnumMember(Value = "partially_valid")]
         PartiallyValid,

        [EnumMember(Value = "invalid")]
         Invalid,

    }
}