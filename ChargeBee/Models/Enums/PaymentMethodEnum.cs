using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum PaymentMethodEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("card")]
         Card,

        [Description("cash")]
         Cash,

        [Description("check")]
         Check,

        [Description("chargeback")]
         Chargeback,

        [Description("bank_transfer")]
         BankTransfer,

        [Description("amazon_payments")]
         AmazonPayments,

        [Description("paypal_express_checkout")]
         PaypalExpressCheckout,

        [Description("direct_debit")]
         DirectDebit,

        [Description("alipay")]
         Alipay,

        [Description("unionpay")]
         Unionpay,

        [Description("other")]
         Other,

    }
}