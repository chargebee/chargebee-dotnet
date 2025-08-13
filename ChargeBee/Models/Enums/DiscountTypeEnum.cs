using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum DiscountTypeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "fixed_amount")]
         FixedAmount,

        [EnumMember(Value = "percentage")]
         Percentage,

        [EnumMember(Value = "price")]
         Price,

    }
}