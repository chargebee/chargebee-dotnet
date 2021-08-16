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

    public class QuotedSubscription : Resource 
    {
    
        public QuotedSubscription() { }

        public QuotedSubscription(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public QuotedSubscription(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public QuotedSubscription(String jsonString)
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
        public string PlanId 
        {
            get { return GetValue<string>("plan_id", true); }
        }
        public int PlanQuantity 
        {
            get { return GetValue<int>("plan_quantity", true); }
        }
        public int? PlanUnitPrice 
        {
            get { return GetValue<int?>("plan_unit_price", false); }
        }
        public int? SetupFee 
        {
            get { return GetValue<int?>("setup_fee", false); }
        }
        public int? BillingPeriod 
        {
            get { return GetValue<int?>("billing_period", false); }
        }
        public BillingPeriodUnitEnum? BillingPeriodUnit 
        {
            get { return GetEnum<BillingPeriodUnitEnum>("billing_period_unit", false); }
        }
        public DateTime? StartDate 
        {
            get { return GetDateTime("start_date", false); }
        }
        public DateTime? TrialEnd 
        {
            get { return GetDateTime("trial_end", false); }
        }
        public int? RemainingBillingCycles 
        {
            get { return GetValue<int?>("remaining_billing_cycles", false); }
        }
        public string PoNumber 
        {
            get { return GetValue<string>("po_number", false); }
        }
        public AutoCollectionEnum? AutoCollection 
        {
            get { return GetEnum<AutoCollectionEnum>("auto_collection", false); }
        }
        public string PlanQuantityInDecimal 
        {
            get { return GetValue<string>("plan_quantity_in_decimal", false); }
        }
        public string PlanUnitPriceInDecimal 
        {
            get { return GetValue<string>("plan_unit_price_in_decimal", false); }
        }
        public DateTime? ChangesScheduledAt 
        {
            get { return GetDateTime("changes_scheduled_at", false); }
        }
        public ChangeOptionEnum? ChangeOption 
        {
            get { return GetEnum<ChangeOptionEnum>("change_option", false); }
        }
        public int? ContractTermBillingCycleOnRenewal 
        {
            get { return GetValue<int?>("contract_term_billing_cycle_on_renewal", false); }
        }
        public List<QuotedSubscriptionAddon> Addons 
        {
            get { return GetResourceList<QuotedSubscriptionAddon>("addons"); }
        }
        public List<QuotedSubscriptionEventBasedAddon> EventBasedAddons 
        {
            get { return GetResourceList<QuotedSubscriptionEventBasedAddon>("event_based_addons"); }
        }
        public List<QuotedSubscriptionCoupon> Coupons 
        {
            get { return GetResourceList<QuotedSubscriptionCoupon>("coupons"); }
        }
        public List<QuotedSubscriptionSubscriptionItem> SubscriptionItems 
        {
            get { return GetResourceList<QuotedSubscriptionSubscriptionItem>("subscription_items"); }
        }
        public List<QuotedSubscriptionItemTier> ItemTiers 
        {
            get { return GetResourceList<QuotedSubscriptionItemTier>("item_tiers"); }
        }
        public QuotedSubscriptionQuotedContractTerm QuotedContractTerm 
        {
            get { return GetSubResource<QuotedSubscriptionQuotedContractTerm>("quoted_contract_term"); }
        }
        
        #endregion
        

        public enum BillingPeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "day")]
            Day,
            [EnumMember(Value = "week")]
            Week,
            [EnumMember(Value = "month")]
            Month,
            [EnumMember(Value = "year")]
            Year,

        }
        public enum ChangeOptionEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "end_of_term")]
            EndOfTerm,
            [EnumMember(Value = "specific_date")]
            SpecificDate,
            [EnumMember(Value = "immediately")]
            Immediately,

        }

        #region Subclasses
        public class QuotedSubscriptionAddon : Resource
        {

            public string Id() {
                return GetValue<string>("id", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public int? UnitPrice() {
                return GetValue<int?>("unit_price", false);
            }

            public int? Amount() {
                return GetValue<int?>("amount", false);
            }

            public DateTime? TrialEnd() {
                return GetDateTime("trial_end", false);
            }

            public int? RemainingBillingCycles() {
                return GetValue<int?>("remaining_billing_cycles", false);
            }

            public string QuantityInDecimal() {
                return GetValue<string>("quantity_in_decimal", false);
            }

            public string UnitPriceInDecimal() {
                return GetValue<string>("unit_price_in_decimal", false);
            }

            public string AmountInDecimal() {
                return GetValue<string>("amount_in_decimal", false);
            }

        }
        public class QuotedSubscriptionEventBasedAddon : Resource
        {
            public enum OnEventEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "subscription_creation")]
                SubscriptionCreation,
                [EnumMember(Value = "subscription_trial_start")]
                SubscriptionTrialStart,
                [EnumMember(Value = "plan_activation")]
                PlanActivation,
                [EnumMember(Value = "subscription_activation")]
                SubscriptionActivation,
                [EnumMember(Value = "contract_termination")]
                ContractTermination,
            }

            public string Id() {
                return GetValue<string>("id", true);
            }

            public int Quantity() {
                return GetValue<int>("quantity", true);
            }

            public int UnitPrice() {
                return GetValue<int>("unit_price", true);
            }

            public int? ServicePeriodInDays() {
                return GetValue<int?>("service_period_in_days", false);
            }

            public OnEventEnum OnEvent() {
                return GetEnum<OnEventEnum>("on_event", true);
            }

            public bool ChargeOnce() {
                return GetValue<bool>("charge_once", true);
            }

            public string QuantityInDecimal() {
                return GetValue<string>("quantity_in_decimal", false);
            }

            public string UnitPriceInDecimal() {
                return GetValue<string>("unit_price_in_decimal", false);
            }

        }
        public class QuotedSubscriptionCoupon : Resource
        {

            public string CouponId() {
                return GetValue<string>("coupon_id", true);
            }

        }
        public class QuotedSubscriptionSubscriptionItem : Resource
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

            public string ItemPriceId() {
                return GetValue<string>("item_price_id", true);
            }

            public ItemTypeEnum ItemType() {
                return GetEnum<ItemTypeEnum>("item_type", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public string QuantityInDecimal() {
                return GetValue<string>("quantity_in_decimal", false);
            }

            public string MeteredQuantity() {
                return GetValue<string>("metered_quantity", false);
            }

            public DateTime? LastCalculatedAt() {
                return GetDateTime("last_calculated_at", false);
            }

            public int? UnitPrice() {
                return GetValue<int?>("unit_price", false);
            }

            public string UnitPriceInDecimal() {
                return GetValue<string>("unit_price_in_decimal", false);
            }

            public int? Amount() {
                return GetValue<int?>("amount", false);
            }

            public string AmountInDecimal() {
                return GetValue<string>("amount_in_decimal", false);
            }

            public int? FreeQuantity() {
                return GetValue<int?>("free_quantity", false);
            }

            public string FreeQuantityInDecimal() {
                return GetValue<string>("free_quantity_in_decimal", false);
            }

            public DateTime? TrialEnd() {
                return GetDateTime("trial_end", false);
            }

            public int? BillingCycles() {
                return GetValue<int?>("billing_cycles", false);
            }

            public int? ServicePeriodDays() {
                return GetValue<int?>("service_period_days", false);
            }

            public ChargeOnEventEnum? ChargeOnEvent() {
                return GetEnum<ChargeOnEventEnum>("charge_on_event", false);
            }

            public bool? ChargeOnce() {
                return GetValue<bool?>("charge_once", false);
            }

            public ChargeOnOptionEnum? ChargeOnOption() {
                return GetEnum<ChargeOnOptionEnum>("charge_on_option", false);
            }

        }
        public class QuotedSubscriptionItemTier : Resource
        {

            public string ItemPriceId() {
                return GetValue<string>("item_price_id", true);
            }

            public int StartingUnit() {
                return GetValue<int>("starting_unit", true);
            }

            public int? EndingUnit() {
                return GetValue<int?>("ending_unit", false);
            }

            public int Price() {
                return GetValue<int>("price", true);
            }

            public string StartingUnitInDecimal() {
                return GetValue<string>("starting_unit_in_decimal", false);
            }

            public string EndingUnitInDecimal() {
                return GetValue<string>("ending_unit_in_decimal", false);
            }

            public string PriceInDecimal() {
                return GetValue<string>("price_in_decimal", false);
            }

        }
        public class QuotedSubscriptionQuotedContractTerm : Resource
        {
            public enum ActionAtTermEndEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "renew")]
                Renew,
                [EnumMember(Value = "evergreen")]
                Evergreen,
                [EnumMember(Value = "cancel")]
                Cancel,
                [EnumMember(Value = "renew_once")]
                RenewOnce,
            }

            public DateTime ContractStart() {
                return (DateTime)GetDateTime("contract_start", true);
            }

            public DateTime ContractEnd() {
                return (DateTime)GetDateTime("contract_end", true);
            }

            public int BillingCycle() {
                return GetValue<int>("billing_cycle", true);
            }

            public ActionAtTermEndEnum ActionAtTermEnd() {
                return GetEnum<ActionAtTermEndEnum>("action_at_term_end", true);
            }

            public long TotalContractValue() {
                return GetValue<long>("total_contract_value", true);
            }

            public int? CancellationCutoffPeriod() {
                return GetValue<int?>("cancellation_cutoff_period", false);
            }

        }

        #endregion
    }
}
