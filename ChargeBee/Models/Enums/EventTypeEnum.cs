using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum EventTypeEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("plan_created")]
         PlanCreated,

        [Description("plan_updated")]
         PlanUpdated,

        [Description("plan_deleted")]
         PlanDeleted,

        [Description("addon_created")]
         AddonCreated,

        [Description("addon_updated")]
         AddonUpdated,

        [Description("addon_deleted")]
         AddonDeleted,

        [Description("coupon_created")]
         CouponCreated,

        [Description("coupon_updated")]
         CouponUpdated,

        [Description("coupon_deleted")]
         CouponDeleted,

        [Description("customer_created")]
         CustomerCreated,

        [Description("customer_changed")]
         CustomerChanged,

        [Description("customer_deleted")]
         CustomerDeleted,

        [Description("subscription_created")]
         SubscriptionCreated,

        [Description("subscription_started")]
         SubscriptionStarted,

        [Description("subscription_trial_end_reminder")]
         SubscriptionTrialEndReminder,

        [Description("subscription_activated")]
         SubscriptionActivated,

        [Description("subscription_changed")]
         SubscriptionChanged,

        [Description("subscription_cancellation_scheduled")]
         SubscriptionCancellationScheduled,

        [Description("subscription_cancellation_reminder")]
         SubscriptionCancellationReminder,

        [Description("subscription_cancelled")]
         SubscriptionCancelled,

        [Description("subscription_reactivated")]
         SubscriptionReactivated,

        [Description("subscription_renewed")]
         SubscriptionRenewed,

        [Description("subscription_scheduled_cancellation_removed")]
         SubscriptionScheduledCancellationRemoved,

        [Description("subscription_shipping_address_updated")]
         SubscriptionShippingAddressUpdated,

        [Description("subscription_deleted")]
         SubscriptionDeleted,

        [Description("pending_invoice_created")]
         PendingInvoiceCreated,

        [Description("invoice_generated")]
         InvoiceGenerated,

        [Description("invoice_updated")]
         InvoiceUpdated,

        [Description("invoice_deleted")]
         InvoiceDeleted,

        [Description("credit_note_created")]
         CreditNoteCreated,

        [Description("credit_note_updated")]
         CreditNoteUpdated,

        [Description("credit_note_deleted")]
         CreditNoteDeleted,

        [Description("subscription_renewal_reminder")]
         SubscriptionRenewalReminder,

        [Description("transaction_created")]
         TransactionCreated,

        [Description("transaction_updated")]
         TransactionUpdated,

        [Description("transaction_deleted")]
         TransactionDeleted,

        [Description("payment_succeeded")]
         PaymentSucceeded,

        [Description("payment_failed")]
         PaymentFailed,

        [Description("payment_refunded")]
         PaymentRefunded,

        [Description("payment_initiated")]
         PaymentInitiated,

        [Description("refund_initiated")]
         RefundInitiated,

        [Description("netd_payment_due_reminder")]
         NetdPaymentDueReminder,

        [Description("card_added")]
         CardAdded,

        [Description("card_updated")]
         CardUpdated,

        [Description("card_expiry_reminder")]
         CardExpiryReminder,

        [Description("card_expired")]
         CardExpired,

        [Description("card_deleted")]
         CardDeleted,

    }
}