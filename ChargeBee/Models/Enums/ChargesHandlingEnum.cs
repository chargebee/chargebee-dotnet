using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum ChargesHandlingEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("invoice_immediately")]
         InvoiceImmediately,

        [Description("add_to_unbilled_charges")]
         AddToUnbilledCharges,

    }
}