using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum EntityTypeEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("customer")]
         Customer,

        [Description("subscription")]
         Subscription,

        [Description("invoice")]
         Invoice,

        [Description("credit_note")]
         CreditNote,

        [Description("transaction")]
         Transaction,

        [Description("plan")]
         Plan,

        [Description("addon")]
         Addon,

        [Description("coupon")]
         Coupon,

    }
}