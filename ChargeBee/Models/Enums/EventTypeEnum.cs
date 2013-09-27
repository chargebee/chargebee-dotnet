using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum EventTypeEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("subscription_created")]
        SubscriptionCreated,

        [Description("subscription_trial_ending")]
        SubscriptionTrialEnding,

        [Description("subscription_activated")]
        SubscriptionActivated,

        [Description("subscription_changed")]
        SubscriptionChanged,

        [Description("subscription_cancelling")]
        SubscriptionCancelling,

        [Description("subscription_cancelled")]
        SubscriptionCancelled,

        [Description("subscription_reactivated")]
        SubscriptionReactivated,

        [Description("subscription_renewed")]
        SubscriptionRenewed,

        [Description("invoice_receipt")]
        InvoiceReceipt,

        [Description("invoice_created")]
        InvoiceCreated,

        [Description("payment_succeeded")]
        PaymentSucceeded,

        [Description("payment_failed")]
        PaymentFailed,

        [Description("payment_refunded")]
        PaymentRefunded,

        [Description("card_added")]
        CardAdded,

        [Description("card_updated")]
        CardUpdated,

        [Description("card_expiring")]
        CardExpiring,

        [Description("card_expired")]
        CardExpired,

        [Description("card_deleted")]
        CardDeleted,

    }
}