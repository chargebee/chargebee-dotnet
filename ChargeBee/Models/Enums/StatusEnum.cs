using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum StatusEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "future")]
         Future,

        [EnumMember(Value = "in_trial")]
         InTrial,

        [EnumMember(Value = "active")]
         Active,

        [EnumMember(Value = "non_renewing")]
         NonRenewing,

        [EnumMember(Value = "paused")]
         Paused,

        [EnumMember(Value = "cancelled")]
         Cancelled,

    }
}