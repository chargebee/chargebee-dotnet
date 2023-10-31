using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum PaymentMethodTypeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "card")]
         Card,

        [EnumMember(Value = "paypal_express_checkout")]
         PaypalExpressCheckout,

        [EnumMember(Value = "amazon_payments")]
         AmazonPayments,

        [EnumMember(Value = "direct_debit")]
         DirectDebit,

        [EnumMember(Value = "generic")]
         Generic,

        [EnumMember(Value = "alipay")]
         Alipay,

        [EnumMember(Value = "unionpay")]
         Unionpay,

        [EnumMember(Value = "apple_pay")]
         ApplePay,

        [EnumMember(Value = "wechat_pay")]
         WechatPay,

        [EnumMember(Value = "ideal")]
         Ideal,

        [EnumMember(Value = "google_pay")]
         GooglePay,

        [EnumMember(Value = "sofort")]
         Sofort,

        [EnumMember(Value = "bancontact")]
         Bancontact,

        [EnumMember(Value = "giropay")]
         Giropay,

        [EnumMember(Value = "dotpay")]
         Dotpay,

        [EnumMember(Value = "upi")]
         Upi,

        [EnumMember(Value = "netbanking_emandates")]
         NetbankingEmandates,

        [EnumMember(Value = "venmo")]
         Venmo,

        [EnumMember(Value = "pay_to")]
         PayTo,

        [EnumMember(Value = "faster_payments")]
         FasterPayments,

        [EnumMember(Value = "sepa_instant_transfer")]
         SepaInstantTransfer,

    }
}