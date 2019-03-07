using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum EntityCodeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "a")]
         A,

        [EnumMember(Value = "b")]
         B,

        [EnumMember(Value = "c")]
         C,

        [EnumMember(Value = "d")]
         D,

        [EnumMember(Value = "e")]
         E,

        [EnumMember(Value = "f")]
         F,

        [EnumMember(Value = "g")]
         G,

        [EnumMember(Value = "h")]
         H,

        [EnumMember(Value = "i")]
         I,

        [EnumMember(Value = "j")]
         J,

        [EnumMember(Value = "k")]
         K,

        [EnumMember(Value = "l")]
         L,

        [EnumMember(Value = "m")]
         M,

        [EnumMember(Value = "n")]
         N,

        [EnumMember(Value = "p")]
         P,

        [EnumMember(Value = "q")]
         Q,

        [EnumMember(Value = "r")]
         R,

        [EnumMember(Value = "med1")]
         Med1,

        [EnumMember(Value = "med2")]
         Med2,

    }
}