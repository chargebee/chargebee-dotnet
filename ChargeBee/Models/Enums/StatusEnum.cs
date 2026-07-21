using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum StatusEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "active")]
         Active,

        [EnumMember(Value = "archived")]
         Archived,

        [EnumMember(Value = "deleted")]
         Deleted,

        [EnumMember(Value = "available")]
         Available,

        [EnumMember(Value = "exhausted")]
         Exhausted,

        [EnumMember(Value = "scheduled")]
         Scheduled,

        [EnumMember(Value = "in_grace_period")]
         InGracePeriod,

    }
}