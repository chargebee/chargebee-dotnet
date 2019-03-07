using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum NotifyReferralSystemEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "none")]
         None,

        [EnumMember(Value = "first_paid_conversion")]
         FirstPaidConversion,

        [EnumMember(Value = "all_invoices")]
         AllInvoices,

    }
}