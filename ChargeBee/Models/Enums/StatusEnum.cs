using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum StatusEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "scheduled")]
         Scheduled,

        [EnumMember(Value = "rescheduled")]
         Rescheduled,

        [EnumMember(Value = "succeeded")]
         Succeeded,

        [EnumMember(Value = "failed")]
         Failed,

        [EnumMember(Value = "deferred")]
         Deferred,

        [EnumMember(Value = "delivered")]
         Delivered,

        [EnumMember(Value = "opened")]
         Opened,

        [EnumMember(Value = "bounced")]
         Bounced,

        [EnumMember(Value = "dropped")]
         Dropped,

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

        [EnumMember(Value = "in_grace_period")]
         InGracePeriod,

    }
}