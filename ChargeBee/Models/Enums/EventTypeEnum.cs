using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum EventTypeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "coupon_created")]
         CouponCreated,

        [EnumMember(Value = "coupon_updated")]
         CouponUpdated,

        [EnumMember(Value = "coupon_deleted")]
         CouponDeleted,

        [EnumMember(Value = "coupon_set_created")]
         CouponSetCreated,

        [EnumMember(Value = "coupon_set_updated")]
         CouponSetUpdated,

        [EnumMember(Value = "coupon_set_deleted")]
         CouponSetDeleted,

        [EnumMember(Value = "coupon_codes_added")]
         CouponCodesAdded,

        [EnumMember(Value = "coupon_codes_deleted")]
         CouponCodesDeleted,

        [EnumMember(Value = "coupon_codes_updated")]
         CouponCodesUpdated,

        [EnumMember(Value = "customer_created")]
         CustomerCreated,

        [EnumMember(Value = "customer_changed")]
         CustomerChanged,

        [EnumMember(Value = "customer_deleted")]
         CustomerDeleted,

        [EnumMember(Value = "customer_moved_out")]
         CustomerMovedOut,

        [EnumMember(Value = "customer_moved_in")]
         CustomerMovedIn,

        [EnumMember(Value = "promotional_credits_added")]
         PromotionalCreditsAdded,

        [EnumMember(Value = "promotional_credits_deducted")]
         PromotionalCreditsDeducted,

        [EnumMember(Value = "subscription_created")]
         SubscriptionCreated,

        [EnumMember(Value = "subscription_created_with_backdating")]
         SubscriptionCreatedWithBackdating,

        [EnumMember(Value = "subscription_started")]
         SubscriptionStarted,

        [EnumMember(Value = "subscription_trial_end_reminder")]
         SubscriptionTrialEndReminder,

        [EnumMember(Value = "subscription_activated")]
         SubscriptionActivated,

        [EnumMember(Value = "subscription_activated_with_backdating")]
         SubscriptionActivatedWithBackdating,

        [EnumMember(Value = "subscription_changed")]
         SubscriptionChanged,

        [EnumMember(Value = "subscription_trial_extended")]
         SubscriptionTrialExtended,

        [EnumMember(Value = "mrr_updated")]
         MrrUpdated,

        [EnumMember(Value = "subscription_changed_with_backdating")]
         SubscriptionChangedWithBackdating,

        [EnumMember(Value = "subscription_cancellation_scheduled")]
         SubscriptionCancellationScheduled,

        [EnumMember(Value = "subscription_cancellation_reminder")]
         SubscriptionCancellationReminder,

        [EnumMember(Value = "subscription_cancelled")]
         SubscriptionCancelled,

        [EnumMember(Value = "subscription_canceled_with_backdating")]
         SubscriptionCanceledWithBackdating,

        [EnumMember(Value = "subscription_reactivated")]
         SubscriptionReactivated,

        [EnumMember(Value = "subscription_reactivated_with_backdating")]
         SubscriptionReactivatedWithBackdating,

        [EnumMember(Value = "subscription_renewed")]
         SubscriptionRenewed,

        [EnumMember(Value = "subscription_items_renewed")]
         SubscriptionItemsRenewed,

        [EnumMember(Value = "subscription_scheduled_cancellation_removed")]
         SubscriptionScheduledCancellationRemoved,

        [EnumMember(Value = "subscription_changes_scheduled")]
         SubscriptionChangesScheduled,

        [EnumMember(Value = "subscription_scheduled_changes_removed")]
         SubscriptionScheduledChangesRemoved,

        [EnumMember(Value = "subscription_shipping_address_updated")]
         SubscriptionShippingAddressUpdated,

        [EnumMember(Value = "subscription_deleted")]
         SubscriptionDeleted,

        [EnumMember(Value = "subscription_paused")]
         SubscriptionPaused,

        [EnumMember(Value = "subscription_pause_scheduled")]
         SubscriptionPauseScheduled,

        [EnumMember(Value = "subscription_scheduled_pause_removed")]
         SubscriptionScheduledPauseRemoved,

        [EnumMember(Value = "subscription_resumed")]
         SubscriptionResumed,

        [EnumMember(Value = "subscription_resumption_scheduled")]
         SubscriptionResumptionScheduled,

        [EnumMember(Value = "subscription_scheduled_resumption_removed")]
         SubscriptionScheduledResumptionRemoved,

        [EnumMember(Value = "subscription_advance_invoice_schedule_added")]
         SubscriptionAdvanceInvoiceScheduleAdded,

        [EnumMember(Value = "subscription_advance_invoice_schedule_updated")]
         SubscriptionAdvanceInvoiceScheduleUpdated,

        [EnumMember(Value = "subscription_advance_invoice_schedule_removed")]
         SubscriptionAdvanceInvoiceScheduleRemoved,

        [EnumMember(Value = "pending_invoice_created")]
         PendingInvoiceCreated,

        [EnumMember(Value = "pending_invoice_updated")]
         PendingInvoiceUpdated,

        [EnumMember(Value = "invoice_generated")]
         InvoiceGenerated,

        [EnumMember(Value = "invoice_generated_with_backdating")]
         InvoiceGeneratedWithBackdating,

        [EnumMember(Value = "invoice_updated")]
         InvoiceUpdated,

        [EnumMember(Value = "invoice_deleted")]
         InvoiceDeleted,

        [EnumMember(Value = "credit_note_created")]
         CreditNoteCreated,

        [EnumMember(Value = "credit_note_created_with_backdating")]
         CreditNoteCreatedWithBackdating,

        [EnumMember(Value = "credit_note_updated")]
         CreditNoteUpdated,

        [EnumMember(Value = "credit_note_deleted")]
         CreditNoteDeleted,

        [EnumMember(Value = "payment_schedules_created")]
         PaymentSchedulesCreated,

        [EnumMember(Value = "payment_schedules_updated")]
         PaymentSchedulesUpdated,

        [EnumMember(Value = "payment_schedule_scheme_created")]
         PaymentScheduleSchemeCreated,

        [EnumMember(Value = "payment_schedule_scheme_deleted")]
         PaymentScheduleSchemeDeleted,

        [EnumMember(Value = "subscription_renewal_reminder")]
         SubscriptionRenewalReminder,

        [EnumMember(Value = "add_usages_reminder")]
         AddUsagesReminder,

        [EnumMember(Value = "transaction_created")]
         TransactionCreated,

        [EnumMember(Value = "transaction_updated")]
         TransactionUpdated,

        [EnumMember(Value = "transaction_deleted")]
         TransactionDeleted,

        [EnumMember(Value = "payment_succeeded")]
         PaymentSucceeded,

        [EnumMember(Value = "payment_failed")]
         PaymentFailed,

        [EnumMember(Value = "payment_refunded")]
         PaymentRefunded,

        [EnumMember(Value = "payment_initiated")]
         PaymentInitiated,

        [EnumMember(Value = "refund_initiated")]
         RefundInitiated,

        [EnumMember(Value = "authorization_succeeded")]
         AuthorizationSucceeded,

        [EnumMember(Value = "authorization_voided")]
         AuthorizationVoided,

        [EnumMember(Value = "card_added")]
         CardAdded,

        [EnumMember(Value = "card_updated")]
         CardUpdated,

        [EnumMember(Value = "card_expiry_reminder")]
         CardExpiryReminder,

        [EnumMember(Value = "card_expired")]
         CardExpired,

        [EnumMember(Value = "card_deleted")]
         CardDeleted,

        [EnumMember(Value = "payment_source_added")]
         PaymentSourceAdded,

        [EnumMember(Value = "payment_source_updated")]
         PaymentSourceUpdated,

        [EnumMember(Value = "payment_source_deleted")]
         PaymentSourceDeleted,

        [EnumMember(Value = "payment_source_expiring")]
         PaymentSourceExpiring,

        [EnumMember(Value = "payment_source_expired")]
         PaymentSourceExpired,

        [EnumMember(Value = "payment_source_locally_deleted")]
         PaymentSourceLocallyDeleted,

        [EnumMember(Value = "virtual_bank_account_added")]
         VirtualBankAccountAdded,

        [EnumMember(Value = "virtual_bank_account_updated")]
         VirtualBankAccountUpdated,

        [EnumMember(Value = "virtual_bank_account_deleted")]
         VirtualBankAccountDeleted,

        [EnumMember(Value = "token_created")]
         TokenCreated,

        [EnumMember(Value = "token_consumed")]
         TokenConsumed,

        [EnumMember(Value = "token_expired")]
         TokenExpired,

        [EnumMember(Value = "unbilled_charges_created")]
         UnbilledChargesCreated,

        [EnumMember(Value = "unbilled_charges_voided")]
         UnbilledChargesVoided,

        [EnumMember(Value = "unbilled_charges_deleted")]
         UnbilledChargesDeleted,

        [EnumMember(Value = "unbilled_charges_invoiced")]
         UnbilledChargesInvoiced,

        [EnumMember(Value = "order_created")]
         OrderCreated,

        [EnumMember(Value = "order_updated")]
         OrderUpdated,

        [EnumMember(Value = "order_cancelled")]
         OrderCancelled,

        [EnumMember(Value = "order_delivered")]
         OrderDelivered,

        [EnumMember(Value = "order_returned")]
         OrderReturned,

        [EnumMember(Value = "order_ready_to_process")]
         OrderReadyToProcess,

        [EnumMember(Value = "order_ready_to_ship")]
         OrderReadyToShip,

        [EnumMember(Value = "order_deleted")]
         OrderDeleted,

        [EnumMember(Value = "order_resent")]
         OrderResent,

        [EnumMember(Value = "quote_created")]
         QuoteCreated,

        [EnumMember(Value = "quote_updated")]
         QuoteUpdated,

        [EnumMember(Value = "quote_deleted")]
         QuoteDeleted,

        [EnumMember(Value = "tax_withheld_recorded")]
         TaxWithheldRecorded,

        [EnumMember(Value = "tax_withheld_deleted")]
         TaxWithheldDeleted,

        [EnumMember(Value = "tax_withheld_refunded")]
         TaxWithheldRefunded,

        [EnumMember(Value = "gift_scheduled")]
         GiftScheduled,

        [EnumMember(Value = "gift_unclaimed")]
         GiftUnclaimed,

        [EnumMember(Value = "gift_claimed")]
         GiftClaimed,

        [EnumMember(Value = "gift_expired")]
         GiftExpired,

        [EnumMember(Value = "gift_cancelled")]
         GiftCancelled,

        [EnumMember(Value = "gift_updated")]
         GiftUpdated,

        [EnumMember(Value = "hierarchy_created")]
         HierarchyCreated,

        [EnumMember(Value = "hierarchy_deleted")]
         HierarchyDeleted,

        [EnumMember(Value = "payment_intent_created")]
         PaymentIntentCreated,

        [EnumMember(Value = "payment_intent_updated")]
         PaymentIntentUpdated,

        [EnumMember(Value = "contract_term_created")]
         ContractTermCreated,

        [EnumMember(Value = "contract_term_renewed")]
         ContractTermRenewed,

        [EnumMember(Value = "contract_term_terminated")]
         ContractTermTerminated,

        [EnumMember(Value = "contract_term_completed")]
         ContractTermCompleted,

        [EnumMember(Value = "contract_term_cancelled")]
         ContractTermCancelled,

        [EnumMember(Value = "item_family_created")]
         ItemFamilyCreated,

        [EnumMember(Value = "item_family_updated")]
         ItemFamilyUpdated,

        [EnumMember(Value = "item_family_deleted")]
         ItemFamilyDeleted,

        [EnumMember(Value = "item_created")]
         ItemCreated,

        [EnumMember(Value = "item_updated")]
         ItemUpdated,

        [EnumMember(Value = "item_deleted")]
         ItemDeleted,

        [EnumMember(Value = "item_price_created")]
         ItemPriceCreated,

        [EnumMember(Value = "item_price_updated")]
         ItemPriceUpdated,

        [EnumMember(Value = "item_price_deleted")]
         ItemPriceDeleted,

        [EnumMember(Value = "attached_item_created")]
         AttachedItemCreated,

        [EnumMember(Value = "attached_item_updated")]
         AttachedItemUpdated,

        [EnumMember(Value = "attached_item_deleted")]
         AttachedItemDeleted,

        [EnumMember(Value = "differential_price_created")]
         DifferentialPriceCreated,

        [EnumMember(Value = "differential_price_updated")]
         DifferentialPriceUpdated,

        [EnumMember(Value = "differential_price_deleted")]
         DifferentialPriceDeleted,

        [EnumMember(Value = "feature_created")]
         FeatureCreated,

        [EnumMember(Value = "feature_updated")]
         FeatureUpdated,

        [EnumMember(Value = "feature_deleted")]
         FeatureDeleted,

        [EnumMember(Value = "feature_activated")]
         FeatureActivated,

        [EnumMember(Value = "feature_reactivated")]
         FeatureReactivated,

        [EnumMember(Value = "feature_archived")]
         FeatureArchived,

        [EnumMember(Value = "item_entitlements_updated")]
         ItemEntitlementsUpdated,

        [EnumMember(Value = "entitlement_overrides_updated")]
         EntitlementOverridesUpdated,

        [EnumMember(Value = "entitlement_overrides_removed")]
         EntitlementOverridesRemoved,

        [EnumMember(Value = "item_entitlements_removed")]
         ItemEntitlementsRemoved,

        [EnumMember(Value = "entitlement_overrides_auto_removed")]
         EntitlementOverridesAutoRemoved,

        [EnumMember(Value = "subscription_entitlements_created")]
         SubscriptionEntitlementsCreated,

        [EnumMember(Value = "business_entity_created")]
         BusinessEntityCreated,

        [EnumMember(Value = "business_entity_updated")]
         BusinessEntityUpdated,

        [EnumMember(Value = "business_entity_deleted")]
         BusinessEntityDeleted,

        [EnumMember(Value = "customer_business_entity_changed")]
         CustomerBusinessEntityChanged,

        [EnumMember(Value = "subscription_business_entity_changed")]
         SubscriptionBusinessEntityChanged,

        [EnumMember(Value = "purchase_created")]
         PurchaseCreated,

        [EnumMember(Value = "voucher_created")]
         VoucherCreated,

        [EnumMember(Value = "voucher_expired")]
         VoucherExpired,

        [EnumMember(Value = "voucher_create_failed")]
         VoucherCreateFailed,

        [EnumMember(Value = "item_price_entitlements_updated")]
         ItemPriceEntitlementsUpdated,

        [EnumMember(Value = "item_price_entitlements_removed")]
         ItemPriceEntitlementsRemoved,

        [EnumMember(Value = "subscription_ramp_created")]
         SubscriptionRampCreated,

        [EnumMember(Value = "subscription_ramp_deleted")]
         SubscriptionRampDeleted,

        [EnumMember(Value = "subscription_ramp_applied")]
         SubscriptionRampApplied,

        [EnumMember(Value = "subscription_ramp_drafted")]
         SubscriptionRampDrafted,

        [EnumMember(Value = "subscription_ramp_updated")]
         SubscriptionRampUpdated,

        [EnumMember(Value = "price_variant_created")]
         PriceVariantCreated,

        [EnumMember(Value = "price_variant_updated")]
         PriceVariantUpdated,

        [EnumMember(Value = "price_variant_deleted")]
         PriceVariantDeleted,

        [EnumMember(Value = "customer_entitlements_updated")]
         CustomerEntitlementsUpdated,

        [EnumMember(Value = "subscription_moved_in")]
         SubscriptionMovedIn,

        [EnumMember(Value = "subscription_moved_out")]
         SubscriptionMovedOut,

        [EnumMember(Value = "subscription_movement_failed")]
         SubscriptionMovementFailed,

        [EnumMember(Value = "omnichannel_subscription_created")]
         OmnichannelSubscriptionCreated,

        [EnumMember(Value = "omnichannel_subscription_item_renewed")]
         OmnichannelSubscriptionItemRenewed,

        [EnumMember(Value = "omnichannel_subscription_item_downgrade_scheduled")]
         OmnichannelSubscriptionItemDowngradeScheduled,

        [EnumMember(Value = "omnichannel_subscription_item_scheduled_downgrade_removed")]
         OmnichannelSubscriptionItemScheduledDowngradeRemoved,

        [EnumMember(Value = "omnichannel_subscription_item_downgraded")]
         OmnichannelSubscriptionItemDowngraded,

        [EnumMember(Value = "omnichannel_subscription_item_expired")]
         OmnichannelSubscriptionItemExpired,

        [EnumMember(Value = "omnichannel_subscription_item_cancellation_scheduled")]
         OmnichannelSubscriptionItemCancellationScheduled,

        [EnumMember(Value = "omnichannel_subscription_item_scheduled_cancellation_removed")]
         OmnichannelSubscriptionItemScheduledCancellationRemoved,

        [EnumMember(Value = "omnichannel_subscription_item_resubscribed")]
         OmnichannelSubscriptionItemResubscribed,

        [EnumMember(Value = "omnichannel_subscription_item_upgraded")]
         OmnichannelSubscriptionItemUpgraded,

        [EnumMember(Value = "omnichannel_subscription_item_cancelled")]
         OmnichannelSubscriptionItemCancelled,

        [EnumMember(Value = "plan_created")]
         PlanCreated,

        [EnumMember(Value = "plan_updated")]
         PlanUpdated,

        [EnumMember(Value = "plan_deleted")]
         PlanDeleted,

        [EnumMember(Value = "addon_created")]
         AddonCreated,

        [EnumMember(Value = "addon_updated")]
         AddonUpdated,

        [EnumMember(Value = "addon_deleted")]
         AddonDeleted,

    }
}