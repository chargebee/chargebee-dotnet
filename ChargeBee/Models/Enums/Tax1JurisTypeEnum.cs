using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum Tax1JurisTypeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "country")]
         Country,

        [EnumMember(Value = "federal")]
         Federal,

        [EnumMember(Value = "state")]
         State,

        [EnumMember(Value = "county")]
         County,

        [EnumMember(Value = "city")]
         City,

        [EnumMember(Value = "special")]
         Special,

        [EnumMember(Value = "unincorporated")]
         Unincorporated,

        [EnumMember(Value = "other")]
         Other,

    }
}