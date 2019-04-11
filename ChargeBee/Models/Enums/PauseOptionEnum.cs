using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum PauseOptionEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "immediately")]
         Immediately,

        [EnumMember(Value = "end_of_term")]
         EndOfTerm,

        [EnumMember(Value = "specific_date")]
         SpecificDate,

    }
}