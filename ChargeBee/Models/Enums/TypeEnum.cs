using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum TypeEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("card")]
         Card,

        [Description("paypal_express_checkout")]
         PaypalExpressCheckout,

        [Description("amazon_payments")]
         AmazonPayments,

    }
}