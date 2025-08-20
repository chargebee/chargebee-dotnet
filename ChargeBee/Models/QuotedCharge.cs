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

    public class QuotedCharge : Resource 
    {
    
        public QuotedCharge() { }

        public QuotedCharge(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public QuotedCharge(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public QuotedCharge(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public List<QuotedChargeCharge> Charges 
        {
            get { return GetResourceList<QuotedChargeCharge>("charges"); }
        }
        public List<QuotedChargeAddon> Addons 
        {
            get { return GetResourceList<QuotedChargeAddon>("addons"); }
        }
        public List<QuotedChargeInvoiceItem> InvoiceItems 
        {
            get { return GetResourceList<QuotedChargeInvoiceItem>("invoice_items"); }
        }
        public List<QuotedChargeItemTier> ItemTiers 
        {
            get { return GetResourceList<QuotedChargeItemTier>("item_tiers"); }
        }
        public List<QuotedChargeCoupon> Coupons 
        {
            get { return GetResourceList<QuotedChargeCoupon>("coupons"); }
        }
        public List<QuotedChargeCouponApplicabilityMapping> CouponApplicabilityMappings 
        {
            get { return GetResourceList<QuotedChargeCouponApplicabilityMapping>("coupon_applicability_mappings"); }
        }
        
        #endregion
        


        #region Subclasses
        public class QuotedChargeCharge : Resource
        {

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public string AmountInDecimal {
                get { return GetValue<string>("amount_in_decimal", false); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

            public int? ServicePeriodInDays {
                get { return GetValue<int?>("service_period_in_days", false); }
            }

            public AvalaraSaleTypeEnum? AvalaraSaleType {
                get { return GetEnum<AvalaraSaleTypeEnum>("avalara_sale_type", false); }
            }

            public int? AvalaraTransactionType {
                get { return GetValue<int?>("avalara_transaction_type", false); }
            }

            public int? AvalaraServiceType {
                get { return GetValue<int?>("avalara_service_type", false); }
            }

        }
        public class QuotedChargeAddon : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public int? Quantity {
                get { return GetValue<int?>("quantity", false); }
            }

            public long? UnitPrice {
                get { return GetValue<long?>("unit_price", false); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string UnitPriceInDecimal {
                get { return GetValue<string>("unit_price_in_decimal", false); }
            }

            public ProrationTypeEnum? ProrationType {
                get { return GetEnum<ProrationTypeEnum>("proration_type", false); }
            }

            public int? ServicePeriod {
                get { return GetValue<int?>("service_period", false); }
            }

        }
        public class QuotedChargeInvoiceItem : Resource
        {

            public string ItemPriceId {
                get { return GetValue<string>("item_price_id", true); }
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

            public int? ServicePeriodDays {
                get { return GetValue<int?>("service_period_days", false); }
            }

        }
        public class QuotedChargeItemTier : Resource
        {
            public enum PricingTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "per_unit")]
                PerUnit,
                [EnumMember(Value = "flat_fee")]
                FlatFee,
                [EnumMember(Value = "package")]
                Package,
            }

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

            public PricingTypeEnum? PricingType {
                get { return GetEnum<PricingTypeEnum>("pricing_type", false); }
            }

            public int? PackageSize {
                get { return GetValue<int?>("package_size", false); }
            }

            public int Index {
                get { return GetValue<int>("index", true); }
            }

        }
        public class QuotedChargeCoupon : Resource
        {

            public string CouponId {
                get { return GetValue<string>("coupon_id", true); }
            }

        }
        public class QuotedChargeCouponApplicabilityMapping : Resource
        {

            public string CouponId {
                get { return GetValue<string>("coupon_id", false); }
            }

            public List<string> ApplicableItemPriceIds {
                get { return GetList<string>("applicable_item_price_ids"); }
            }

        }

        #endregion
    }
}
