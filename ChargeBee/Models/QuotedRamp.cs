using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class QuotedRamp : Resource 
    {
    
        public QuotedRamp() { }

        public QuotedRamp(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public QuotedRamp(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public QuotedRamp(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public List<QuotedRampLineItem> LineItems 
        {
            get { return GetResourceList<QuotedRampLineItem>("line_items"); }
        }
        public List<QuotedRampDiscount> Discounts 
        {
            get { return GetResourceList<QuotedRampDiscount>("discounts"); }
        }
        public List<QuotedRampItemTier> ItemTiers 
        {
            get { return GetResourceList<QuotedRampItemTier>("item_tiers"); }
        }
        
        #endregion
        


        #region Subclasses
        public class QuotedRampLineItem : Resource
        {
            public enum ItemTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "charge")]
                Charge,
            }
            public enum ChargeOnOptionEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "immediately")]
                Immediately,
                [EnumMember(Value = "on_event")]
                OnEvent,
            }

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", true); }
            }

            public ItemTypeEnum ItemType {
                get { return GetEnum<ItemTypeEnum>("item_type", true); }
            }

            public int? Quantity {
                get { return GetValue<int?>("quantity", false); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string MeteredQuantity {
                get { return GetValue<string>("metered_quantity", false); }
            }

            public long? UnitPrice {
                get { return GetValue<long?>("unit_price", false); }
            }

            public string UnitPriceInDecimal {
                get { return GetValue<string>("unit_price_in_decimal", false); }
            }

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public string AmountInDecimal {
                get { return GetValue<string>("amount_in_decimal", false); }
            }

            public int? BillingPeriod {
                get { return GetValue<int?>("billing_period", false); }
            }

            public BillingPeriodUnitEnum? BillingPeriodUnit {
                get { return GetEnum<BillingPeriodUnitEnum>("billing_period_unit", false); }
            }

            public int? FreeQuantity {
                get { return GetValue<int?>("free_quantity", false); }
            }

            public string FreeQuantityInDecimal {
                get { return GetValue<string>("free_quantity_in_decimal", false); }
            }

            public int? BillingCycles {
                get { return GetValue<int?>("billing_cycles", false); }
            }

            public int? ServicePeriodDays {
                get { return GetValue<int?>("service_period_days", false); }
            }

            public ChargeOnEventEnum? ChargeOnEvent {
                get { return GetEnum<ChargeOnEventEnum>("charge_on_event", false); }
            }

            public bool? ChargeOnce {
                get { return GetValue<bool?>("charge_once", false); }
            }

            public ChargeOnOptionEnum? ChargeOnOption {
                get { return GetEnum<ChargeOnOptionEnum>("charge_on_option", false); }
            }

            public DateTime? StartDate {
                get { return GetDateTime("start_date", false); }
            }

            public DateTime? EndDate {
                get { return GetDateTime("end_date", false); }
            }

            public string RampTierId {
                get { return GetValue<string>("ramp_tier_id", false); }
            }

            public long? DiscountAmount {
                get { return GetValue<long?>("discount_amount", false); }
            }

            public string MdDiscountAmount {
                get { return GetValue<string>("md_discount_amount", false); }
            }

            public long? ItemLevelDiscountAmount {
                get { return GetValue<long?>("item_level_discount_amount", false); }
            }

            public string MdItemLevelDiscountAmount {
                get { return GetValue<string>("md_item_level_discount_amount", false); }
            }

            public long? DiscountPerBillingCycle {
                get { return GetValue<long?>("discount_per_billing_cycle", false); }
            }

            public string DiscountPerBillingCycleInDecimal {
                get { return GetValue<string>("discount_per_billing_cycle_in_decimal", false); }
            }

            public long? ItemLevelDiscountPerBillingCycle {
                get { return GetValue<long?>("item_level_discount_per_billing_cycle", false); }
            }

            public string ItemLevelDiscountPerBillingCycleInDecimal {
                get { return GetValue<string>("item_level_discount_per_billing_cycle_in_decimal", false); }
            }

            public long? NetAmount {
                get { return GetValue<long?>("net_amount", false); }
            }

            public string MdNetAmount {
                get { return GetValue<string>("md_net_amount", false); }
            }

            public long? AmountPerBillingCycle {
                get { return GetValue<long?>("amount_per_billing_cycle", false); }
            }

            public string AmountPerBillingCycleInDecimal {
                get { return GetValue<string>("amount_per_billing_cycle_in_decimal", false); }
            }

            public long? NetAmountPerBillingCycle {
                get { return GetValue<long?>("net_amount_per_billing_cycle", false); }
            }

            public string NetAmountPerBillingCycleInDecimal {
                get { return GetValue<string>("net_amount_per_billing_cycle_in_decimal", false); }
            }

        }
        public class QuotedRampDiscount : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "fixed_amount")]
                FixedAmount,
                [EnumMember(Value = "percentage")]
                Percentage,
            }
            public enum DurationTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "one_time")]
                OneTime,
                [EnumMember(Value = "forever")]
                Forever,
                [EnumMember(Value = "limited_period")]
                LimitedPeriod,
            }
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "item_level_discount")]
                ItemLevelDiscount,
                [EnumMember(Value = "document_level_discount")]
                DocumentLevelDiscount,
            }
            public enum ApplyOnEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "invoice_amount")]
                InvoiceAmount,
                [EnumMember(Value = "specific_item_price")]
                SpecificItemPrice,
            }
            public enum ApplyOnItemTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "charge")]
                Charge,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string Name {
                get { return GetValue<string>("name", true); }
            }

            public string InvoiceName {
                get { return GetValue<string>("invoice_name", false); }
            }

            public TypeEnum DiscountType {
                get { return GetEnum<TypeEnum>("type", true); }
            }

            public double? Percentage {
                get { return GetValue<double?>("percentage", false); }
            }

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public DurationTypeEnum DurationType {
                get { return GetEnum<DurationTypeEnum>("duration_type", true); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public int? Period {
                get { return GetValue<int?>("period", false); }
            }

            public PeriodUnitEnum? PeriodUnit {
                get { return GetEnum<PeriodUnitEnum>("period_unit", false); }
            }

            public bool IncludedInMrr {
                get { return GetValue<bool>("included_in_mrr", true); }
            }

            public ApplyOnEnum ApplyOn {
                get { return GetEnum<ApplyOnEnum>("apply_on", true); }
            }

            public ApplyOnItemTypeEnum? ApplyOnItemType {
                get { return GetEnum<ApplyOnItemTypeEnum>("apply_on_item_type", false); }
            }

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public DateTime? UpdatedAt {
                get { return GetDateTime("updated_at", false); }
            }

            public DateTime? StartDate {
                get { return GetDateTime("start_date", false); }
            }

            public DateTime? EndDate {
                get { return GetDateTime("end_date", false); }
            }

        }
        public class QuotedRampItemTier : Resource
        {

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", true); }
            }

            public int StartingUnit {
                get { return GetValue<int>("starting_unit", true); }
            }

            public int? EndingUnit {
                get { return GetValue<int?>("ending_unit", false); }
            }

            public long Price {
                get { return GetValue<long>("price", true); }
            }

            public string StartingUnitInDecimal {
                get { return GetValue<string>("starting_unit_in_decimal", false); }
            }

            public string EndingUnitInDecimal {
                get { return GetValue<string>("ending_unit_in_decimal", false); }
            }

            public string PriceInDecimal {
                get { return GetValue<string>("price_in_decimal", false); }
            }

            public string RampTierId {
                get { return GetValue<string>("ramp_tier_id", false); }
            }

        }

        #endregion
    }
}
