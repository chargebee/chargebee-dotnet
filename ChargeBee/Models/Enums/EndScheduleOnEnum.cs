using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum EndScheduleOnEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "after_number_of_intervals")]
         AfterNumberOfIntervals,

        [EnumMember(Value = "specific_date")]
         SpecificDate,

        [EnumMember(Value = "subscription_end")]
         SubscriptionEnd,

    }
}