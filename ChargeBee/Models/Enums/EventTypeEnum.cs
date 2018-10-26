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

        [Description("coupon_set_created")]
         CouponSetCreated,

        [Description("coupon_set_updated")]
         CouponSetUpdated,

        [Description("coupon_set_deleted")]
         CouponSetDeleted,

        [Description("coupon_codes_added")]
         CouponCodesAdded,

        [Description("coupon_codes_deleted")]
         CouponCodesDeleted,

        [Description("coupon_codes_updated")]
         CouponCodesUpdated,

        [Description("customer_created")]
         CustomerCreated,

        [Description("customer_changed")]
         CustomerChanged,

        [Description("customer_deleted")]
         CustomerDeleted,

        [Description("customer_moved_out")]
         CustomerMovedOut,

        [Description("customer_moved_in")]
         CustomerMovedIn,

        [Description("promotional_credits_added")]
         PromotionalCreditsAdded,

        [Description("promotional_credits_deducted")]
         PromotionalCreditsDeducted,

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

        [Description("subscription_changes_scheduled")]
         SubscriptionChangesScheduled,

        [Description("subscription_scheduled_changes_removed")]
         SubscriptionScheduledChangesRemoved,

        [Description("subscription_shipping_address_updated")]
         SubscriptionShippingAddressUpdated,

        [Description("subscription_deleted")]
         SubscriptionDeleted,

        [Description("subscription_paused")]
         SubscriptionPaused,

        [Description("subscription_pause_scheduled")]
         SubscriptionPauseScheduled,

        [Description("subscription_scheduled_pause_removed")]
         SubscriptionScheduledPauseRemoved,

        [Description("subscription_resumed")]
         SubscriptionResumed,

        [Description("subscription_resumption_scheduled")]
         SubscriptionResumptionScheduled,

        [Description("subscription_scheduled_resumption_removed")]
         SubscriptionScheduledResumptionRemoved,

        [Description("pending_invoice_created")]
         PendingInvoiceCreated,

        [Description("pending_invoice_updated")]
         PendingInvoiceUpdated,

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

        [Description("authorization_succeeded")]
         AuthorizationSucceeded,

        [Description("authorization_voided")]
         AuthorizationVoided,

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

        [Description("payment_source_added")]
         PaymentSourceAdded,

        [Description("payment_source_updated")]
         PaymentSourceUpdated,

        [Description("payment_source_deleted")]
         PaymentSourceDeleted,

        [Description("virtual_bank_account_added")]
         VirtualBankAccountAdded,

        [Description("virtual_bank_account_updated")]
         VirtualBankAccountUpdated,

        [Description("virtual_bank_account_deleted")]
         VirtualBankAccountDeleted,

        [Description("unbilled_charges_created")]
         UnbilledChargesCreated,

        [Description("unbilled_charges_voided")]
         UnbilledChargesVoided,

        [Description("unbilled_charges_deleted")]
         UnbilledChargesDeleted,

        [Description("unbilled_charges_invoiced")]
         UnbilledChargesInvoiced,

        [Description("order_created")]
         OrderCreated,

        [Description("order_updated")]
         OrderUpdated,

        [Description("order_cancelled")]
         OrderCancelled,

        [Description("order_delivered")]
         OrderDelivered,

        [Description("order_returned")]
         OrderReturned,

        [Description("order_ready_to_process")]
         OrderReadyToProcess,

        [Description("order_ready_to_ship")]
         OrderReadyToShip,

    }
}