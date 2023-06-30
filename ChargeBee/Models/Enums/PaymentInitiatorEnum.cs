using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum PaymentInitiatorEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "customer")]
         Customer,

        [EnumMember(Value = "merchant")]
         Merchant,

    }
}