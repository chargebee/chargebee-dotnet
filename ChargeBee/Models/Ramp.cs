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

    public class Ramp : Resource 
    {
    
        public Ramp() { }

        public Ramp(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Ramp(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Ramp(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateForSubscriptionRequest CreateForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "create_ramp");
            return new CreateForSubscriptionRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("ramps", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("ramps", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static RampListRequest List()
        {
            string url = ApiUtil.BuildUrl("ramps");
            return new RampListRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public DateTime EffectiveFrom 
        {
            get { return (DateTime)GetDateTime("effective_from", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public List<RampItemsToAdd> ItemsToAdd 
        {
            get { return GetResourceList<RampItemsToAdd>("items_to_add"); }
        }
        public List<RampItemsToUpdate> ItemsToUpdate 
        {
            get { return GetResourceList<RampItemsToUpdate>("items_to_update"); }
        }
        public List<RampCouponsToAdd> CouponsToAdd 
        {
            get { return GetResourceList<RampCouponsToAdd>("coupons_to_add"); }
        }
        public List<RampDiscountsToAdd> DiscountsToAdd 
        {
            get { return GetResourceList<RampDiscountsToAdd>("discounts_to_add"); }
        }
        public List<RampItemTier> ItemTiers 
        {
            get { return GetResourceList<RampItemTier>("item_tiers"); }
        }
        public List<string> ItemsToRemove 
        {
            get { return GetList<string>("items_to_remove"); }
        }
        public List<string> CouponsToRemove 
        {
            get { return GetList<string>("coupons_to_remove"); }
        }
        public List<string> DiscountsToRemove 
        {
            get { return GetList<string>("discounts_to_remove"); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateForSubscriptionRequest : EntityRequest<CreateForSubscriptionRequest> 
        {
            public CreateForSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForSubscriptionRequest EffectiveFrom(long effectiveFrom) 
            {
                m_params.Add("effective_from", effectiveFrom);
                return this;
            }
            public CreateForSubscriptionRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateForSubscriptionRequest CouponsToRemove(List<string> couponsToRemove) 
            {
                m_params.AddOpt("coupons_to_remove", couponsToRemove);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToRemove(List<string> discountsToRemove) 
            {
                m_params.AddOpt("discounts_to_remove", discountsToRemove);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToRemove(List<string> itemsToRemove) 
            {
                m_params.AddOpt("items_to_remove", itemsToRemove);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToAddItemPriceId(int index, string itemsToAddItemPriceId) 
            {
                m_params.Add("items_to_add[item_price_id][" + index + "]", itemsToAddItemPriceId);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToAddQuantity(int index, int itemsToAddQuantity) 
            {
                m_params.AddOpt("items_to_add[quantity][" + index + "]", itemsToAddQuantity);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToAddQuantityInDecimal(int index, string itemsToAddQuantityInDecimal) 
            {
                m_params.AddOpt("items_to_add[quantity_in_decimal][" + index + "]", itemsToAddQuantityInDecimal);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToAddUnitPrice(int index, long itemsToAddUnitPrice) 
            {
                m_params.AddOpt("items_to_add[unit_price][" + index + "]", itemsToAddUnitPrice);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToAddUnitPriceInDecimal(int index, string itemsToAddUnitPriceInDecimal) 
            {
                m_params.AddOpt("items_to_add[unit_price_in_decimal][" + index + "]", itemsToAddUnitPriceInDecimal);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToAddBillingCycles(int index, int itemsToAddBillingCycles) 
            {
                m_params.AddOpt("items_to_add[billing_cycles][" + index + "]", itemsToAddBillingCycles);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToAddServicePeriodDays(int index, int itemsToAddServicePeriodDays) 
            {
                m_params.AddOpt("items_to_add[service_period_days][" + index + "]", itemsToAddServicePeriodDays);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToUpdateItemPriceId(int index, string itemsToUpdateItemPriceId) 
            {
                m_params.Add("items_to_update[item_price_id][" + index + "]", itemsToUpdateItemPriceId);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToUpdateQuantity(int index, int itemsToUpdateQuantity) 
            {
                m_params.AddOpt("items_to_update[quantity][" + index + "]", itemsToUpdateQuantity);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToUpdateQuantityInDecimal(int index, string itemsToUpdateQuantityInDecimal) 
            {
                m_params.AddOpt("items_to_update[quantity_in_decimal][" + index + "]", itemsToUpdateQuantityInDecimal);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToUpdateUnitPrice(int index, long itemsToUpdateUnitPrice) 
            {
                m_params.AddOpt("items_to_update[unit_price][" + index + "]", itemsToUpdateUnitPrice);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToUpdateUnitPriceInDecimal(int index, string itemsToUpdateUnitPriceInDecimal) 
            {
                m_params.AddOpt("items_to_update[unit_price_in_decimal][" + index + "]", itemsToUpdateUnitPriceInDecimal);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToUpdateBillingCycles(int index, int itemsToUpdateBillingCycles) 
            {
                m_params.AddOpt("items_to_update[billing_cycles][" + index + "]", itemsToUpdateBillingCycles);
                return this;
            }
            public CreateForSubscriptionRequest ItemsToUpdateServicePeriodDays(int index, int itemsToUpdateServicePeriodDays) 
            {
                m_params.AddOpt("items_to_update[service_period_days][" + index + "]", itemsToUpdateServicePeriodDays);
                return this;
            }
            public CreateForSubscriptionRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateForSubscriptionRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateForSubscriptionRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateForSubscriptionRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateForSubscriptionRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateForSubscriptionRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateForSubscriptionRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CreateForSubscriptionRequest CouponsToAddCouponId(int index, string couponsToAddCouponId) 
            {
                m_params.AddOpt("coupons_to_add[coupon_id][" + index + "]", couponsToAddCouponId);
                return this;
            }
            public CreateForSubscriptionRequest CouponsToAddApplyTill(int index, long couponsToAddApplyTill) 
            {
                m_params.AddOpt("coupons_to_add[apply_till][" + index + "]", couponsToAddApplyTill);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountsToAddApplyOn) 
            {
                m_params.Add("discounts_to_add[apply_on][" + index + "]", discountsToAddApplyOn);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountsToAddDurationType) 
            {
                m_params.Add("discounts_to_add[duration_type][" + index + "]", discountsToAddDurationType);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddPercentage(int index, double discountsToAddPercentage) 
            {
                m_params.AddOpt("discounts_to_add[percentage][" + index + "]", discountsToAddPercentage);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddAmount(int index, long discountsToAddAmount) 
            {
                m_params.AddOpt("discounts_to_add[amount][" + index + "]", discountsToAddAmount);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddPeriod(int index, int discountsToAddPeriod) 
            {
                m_params.AddOpt("discounts_to_add[period][" + index + "]", discountsToAddPeriod);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountsToAddPeriodUnit) 
            {
                m_params.AddOpt("discounts_to_add[period_unit][" + index + "]", discountsToAddPeriodUnit);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddIncludedInMrr(int index, bool discountsToAddIncludedInMrr) 
            {
                m_params.AddOpt("discounts_to_add[included_in_mrr][" + index + "]", discountsToAddIncludedInMrr);
                return this;
            }
            public CreateForSubscriptionRequest DiscountsToAddItemPriceId(int index, string discountsToAddItemPriceId) 
            {
                m_params.AddOpt("discounts_to_add[item_price_id][" + index + "]", discountsToAddItemPriceId);
                return this;
            }
        }
        public class RampListRequest : ListRequestBase<RampListRequest> 
        {
            public RampListRequest(string url) 
                    : base(url)
            {
            }

            public RampListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public EnumFilter<Ramp.StatusEnum, RampListRequest> Status() 
            {
                return new EnumFilter<Ramp.StatusEnum, RampListRequest>("status", this);        
            }
            public StringFilter<RampListRequest> SubscriptionId() 
            {
                return new StringFilter<RampListRequest>("subscription_id", this).SupportsMultiOperators(true);        
            }
            public TimestampFilter<RampListRequest> EffectiveFrom() 
            {
                return new TimestampFilter<RampListRequest>("effective_from", this);        
            }
            public TimestampFilter<RampListRequest> UpdatedAt() 
            {
                return new TimestampFilter<RampListRequest>("updated_at", this);        
            }
            public RampListRequest SortByEffectiveFrom(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","effective_from");
                return this;
            }
            public RampListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "scheduled")]
            Scheduled,
            [EnumMember(Value = "succeeded")]
            Succeeded,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class RampItemsToAdd : Resource
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

            public string MeteredQuantity {
                get { return GetValue<string>("metered_quantity", false); }
            }

        }
        public class RampItemsToUpdate : Resource
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

            public string MeteredQuantity {
                get { return GetValue<string>("metered_quantity", false); }
            }

        }
        public class RampCouponsToAdd : Resource
        {

            public string CouponId {
                get { return GetValue<string>("coupon_id", true); }
            }

            public DateTime? ApplyTill {
                get { return GetDateTime("apply_till", false); }
            }

        }
        public class RampDiscountsToAdd : Resource
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
            public enum ApplyOnEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "invoice_amount")]
                InvoiceAmount,
                [EnumMember(Value = "specific_item_price")]
                SpecificItemPrice,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string InvoiceName {
                get { return GetValue<string>("invoice_name", false); }
            }

            public TypeEnum DiscountsToAddType {
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

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

        }
        public class RampItemTier : Resource
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

            public int Index {
                get { return GetValue<int>("index", true); }
            }

        }

        #endregion
    }
}
