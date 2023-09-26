using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum DirectDebitSchemeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "ach")]
         Ach,

        [EnumMember(Value = "bacs")]
         Bacs,

        [EnumMember(Value = "sepa_core")]
         SepaCore,

        [EnumMember(Value = "autogiro")]
         Autogiro,

        [EnumMember(Value = "becs")]
         Becs,

        [EnumMember(Value = "becs_nz")]
         BecsNz,

        [EnumMember(Value = "pad")]
         Pad,

        [EnumMember(Value = "not_applicable")]
         NotApplicable,

    }
}