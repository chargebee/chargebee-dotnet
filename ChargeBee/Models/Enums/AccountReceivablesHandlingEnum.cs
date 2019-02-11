using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum AccountReceivablesHandlingEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "no_action")]
         NoAction,

        [EnumMember(Value = "schedule_payment_collection")]
         SchedulePaymentCollection,

        [EnumMember(Value = "write_off")]
         WriteOff,

    }
}