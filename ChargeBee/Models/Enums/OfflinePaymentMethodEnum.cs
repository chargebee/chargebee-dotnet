using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum OfflinePaymentMethodEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "no_preference")]
         NoPreference,

        [EnumMember(Value = "cash")]
         Cash,

        [EnumMember(Value = "check")]
         Check,

        [EnumMember(Value = "bank_transfer")]
         BankTransfer,

        [EnumMember(Value = "ach_credit")]
         AchCredit,

        [EnumMember(Value = "sepa_credit")]
         SepaCredit,

        [EnumMember(Value = "boleto")]
         Boleto,

    }
}