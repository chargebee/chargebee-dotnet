using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum GatewayEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "chargebee")]
         Chargebee,

        [EnumMember(Value = "chargebee_payments")]
         ChargebeePayments,

        [EnumMember(Value = "adyen")]
         Adyen,

        [EnumMember(Value = "stripe")]
         Stripe,

        [EnumMember(Value = "wepay")]
         Wepay,

        [EnumMember(Value = "braintree")]
         Braintree,

        [EnumMember(Value = "authorize_net")]
         AuthorizeNet,

        [EnumMember(Value = "paypal_pro")]
         PaypalPro,

        [EnumMember(Value = "pin")]
         Pin,

        [EnumMember(Value = "eway")]
         Eway,

        [EnumMember(Value = "eway_rapid")]
         EwayRapid,

        [EnumMember(Value = "worldpay")]
         Worldpay,

        [EnumMember(Value = "balanced_payments")]
         BalancedPayments,

        [EnumMember(Value = "beanstream")]
         Beanstream,

        [EnumMember(Value = "bluepay")]
         Bluepay,

        [EnumMember(Value = "elavon")]
         Elavon,

        [EnumMember(Value = "first_data_global")]
         FirstDataGlobal,

        [EnumMember(Value = "hdfc")]
         Hdfc,

        [EnumMember(Value = "migs")]
         Migs,

        [EnumMember(Value = "nmi")]
         Nmi,

        [EnumMember(Value = "ogone")]
         Ogone,

        [EnumMember(Value = "paymill")]
         Paymill,

        [EnumMember(Value = "paypal_payflow_pro")]
         PaypalPayflowPro,

        [EnumMember(Value = "sage_pay")]
         SagePay,

        [EnumMember(Value = "tco")]
         Tco,

        [EnumMember(Value = "wirecard")]
         Wirecard,

        [EnumMember(Value = "amazon_payments")]
         AmazonPayments,

        [EnumMember(Value = "paypal_express_checkout")]
         PaypalExpressCheckout,

        [EnumMember(Value = "orbital")]
         Orbital,

        [EnumMember(Value = "moneris_us")]
         MonerisUs,

        [EnumMember(Value = "moneris")]
         Moneris,

        [EnumMember(Value = "bluesnap")]
         Bluesnap,

        [EnumMember(Value = "cybersource")]
         Cybersource,

        [EnumMember(Value = "vantiv")]
         Vantiv,

        [EnumMember(Value = "checkout_com")]
         CheckoutCom,

        [EnumMember(Value = "paypal")]
         Paypal,

        [EnumMember(Value = "ingenico_direct")]
         IngenicoDirect,

        [EnumMember(Value = "exact")]
         Exact,

        [EnumMember(Value = "mollie")]
         Mollie,

        [EnumMember(Value = "quickbooks")]
         Quickbooks,

        [EnumMember(Value = "razorpay")]
         Razorpay,

        [EnumMember(Value = "global_payments")]
         GlobalPayments,

        [EnumMember(Value = "bank_of_america")]
         BankOfAmerica,

        [EnumMember(Value = "ecentric")]
         Ecentric,

        [EnumMember(Value = "metrics_global")]
         MetricsGlobal,

        [EnumMember(Value = "windcave")]
         Windcave,

        [EnumMember(Value = "pay_com")]
         PayCom,

        [EnumMember(Value = "ebanx")]
         Ebanx,

        [EnumMember(Value = "dlocal")]
         Dlocal,

        [EnumMember(Value = "nuvei")]
         Nuvei,

        [EnumMember(Value = "solidgate")]
         Solidgate,

        [EnumMember(Value = "paystack")]
         Paystack,

        [EnumMember(Value = "jp_morgan")]
         JpMorgan,

        [EnumMember(Value = "deutsche_bank")]
         DeutscheBank,

        [EnumMember(Value = "ezidebit")]
         Ezidebit,

        [EnumMember(Value = "twikey")]
         Twikey,

        [EnumMember(Value = "gocardless")]
         Gocardless,

        [EnumMember(Value = "not_applicable")]
         NotApplicable,

    }
}