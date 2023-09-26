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

        [EnumMember(Value = "coupon")]
         Coupon,

        [EnumMember(Value = "order")]
         Order,

        [EnumMember(Value = "business_entity")]
         BusinessEntity,

        [EnumMember(Value = "item_family")]
         ItemFamily,

        [EnumMember(Value = "item")]
         Item,

        [EnumMember(Value = "item_price")]
         ItemPrice,

        [EnumMember(Value = "product")]
         Product,

        [EnumMember(Value = "variant")]
         Variant,

    }
}