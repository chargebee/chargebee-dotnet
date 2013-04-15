using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum GatewayEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("chargebee")]
        Chargebee,

        [Description("braintree")]
        Braintree,

        [Description("authorize_net")]
        AuthorizeNet,

        [Description("stripe")]
        Stripe,

        [Description("balanced_payments")]
        BalancedPayments,

        [Description("tco")]
        Tco,

        [Description("worldpay")]
        Worldpay,

        [Description("paypal_pro")]
        PaypalPro,

        [Description("paymill")]
        Paymill,

        [Description("pin")]
        Pin,

        [Description("wirecard")]
        Wirecard,

        [Description("ogone")]
        Ogone,

        [Description("beanstream")]
        Beanstream,

        [Description("eway")]
        Eway,

        [Description("hdfc")]
        Hdfc,

        [Description("not_applicable")]
        NotApplicable,

    }
}