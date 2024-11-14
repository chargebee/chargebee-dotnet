using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum EntityTypeEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "customer")]
         Customer,

        [EnumMember(Value = "subscription")]
         Subscription,

        [EnumMember(Value = "coupon")]
         Coupon,

        [EnumMember(Value = "plan_item_price")]
         PlanItemPrice,

        [EnumMember(Value = "addon_item_price")]
         AddonItemPrice,

        [EnumMember(Value = "charge_item_price")]
         ChargeItemPrice,

        [EnumMember(Value = "invoice")]
         Invoice,

        [EnumMember(Value = "quote")]
         Quote,

        [EnumMember(Value = "credit_note")]
         CreditNote,

        [EnumMember(Value = "transaction")]
         Transaction,

        [EnumMember(Value = "plan")]
         Plan,

        [EnumMember(Value = "addon")]
         Addon,

        [EnumMember(Value = "order")]
         Order,

        [EnumMember(Value = "item_family")]
         ItemFamily,

        [EnumMember(Value = "item")]
         Item,

        [EnumMember(Value = "item_price")]
         ItemPrice,

        [EnumMember(Value = "plan_item")]
         PlanItem,

        [EnumMember(Value = "addon_item")]
         AddonItem,

        [EnumMember(Value = "charge_item")]
         ChargeItem,

        [EnumMember(Value = "plan_price")]
         PlanPrice,

        [EnumMember(Value = "addon_price")]
         AddonPrice,

        [EnumMember(Value = "charge_price")]
         ChargePrice,

        [EnumMember(Value = "differential_price")]
         DifferentialPrice,

        [EnumMember(Value = "attached_item")]
         AttachedItem,

        [EnumMember(Value = "feature")]
         Feature,

        [EnumMember(Value = "subscription_entitlement")]
         SubscriptionEntitlement,

        [EnumMember(Value = "item_entitlement")]
         ItemEntitlement,

        [EnumMember(Value = "business_entity")]
         BusinessEntity,

        [EnumMember(Value = "price_variant")]
         PriceVariant,

        [EnumMember(Value = "omnichannel_subscription")]
         OmnichannelSubscription,

        [EnumMember(Value = "omnichannel_subscription_item")]
         OmnichannelSubscriptionItem,

        [EnumMember(Value = "omnichannel_transaction")]
         OmnichannelTransaction,

    }
}