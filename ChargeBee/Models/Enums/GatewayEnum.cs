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

        [Description("authorize_net")]
        AuthorizeNet,

        [Description("balanced_payments")]
        BalancedPayments,

        [Description("beanstream")]
        Beanstream,

        [Description("braintree")]
        Braintree,

        [Description("elavon")]
        Elavon,

        [Description("eway")]
        Eway,

        [Description("first_data_global")]
        FirstDataGlobal,

        [Description("hdfc")]
        Hdfc,

        [Description("migs")]
        Migs,

        [Description("nmi")]
        Nmi,

        [Description("ogone")]
        Ogone,

        [Description("paymill")]
        Paymill,

        [Description("paypal_pro")]
        PaypalPro,

        [Description("paypal_payflow_pro")]
        PaypalPayflowPro,

        [Description("pin")]
        Pin,

        [Description("sage_pay")]
        SagePay,

        [Description("stripe")]
        Stripe,

        [Description("tco")]
        Tco,

        [Description("worldpay")]
        Worldpay,

        [Description("wirecard")]
        Wirecard,

        [Description("not_applicable")]
        NotApplicable,

    }
}