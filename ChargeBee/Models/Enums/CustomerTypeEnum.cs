using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum CustomerTypeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "residential")]
         Residential,

        [EnumMember(Value = "business")]
         Business,

        [EnumMember(Value = "senior_citizen")]
         SeniorCitizen,

        [EnumMember(Value = "industrial")]
         Industrial,

    }
}