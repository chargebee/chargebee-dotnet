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

    public class InvoiceEstimate : Resource 
    {
    
        public InvoiceEstimate() { }

        public InvoiceEstimate(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public InvoiceEstimate(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public InvoiceEstimate(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public bool Recurring 
        {
            get { return GetValue<bool>("recurring", true); }
        }
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public long SubTotal 
        {
            get { return GetValue<long>("sub_total", true); }
        }
        public long? Total 
        {
            get { return GetValue<long?>("total", false); }
        }
        public long? CreditsApplied 
        {
            get { return GetValue<long?>("credits_applied", false); }
        }
        public long? AmountPaid 
        {
            get { return GetValue<long?>("amount_paid", false); }
        }
        public long? AmountDue 
        {
            get { return GetValue<long?>("amount_due", false); }
        }
        public List<InvoiceEstimateLineItem> LineItems 
        {
            get { return GetResourceList<InvoiceEstimateLineItem>("line_items"); }
        }
        public List<InvoiceEstimateDiscount> Discounts 
        {
            get { return GetResourceList<InvoiceEstimateDiscount>("discounts"); }
        }
        public List<InvoiceEstimateTax> Taxes 
        {
            get { return GetResourceList<InvoiceEstimateTax>("taxes"); }
        }
        public List<InvoiceEstimateLineItemTax> LineItemTaxes 
        {
            get { return GetResourceList<InvoiceEstimateLineItemTax>("line_item_taxes"); }
        }
        public List<InvoiceEstimateLineItemTier> LineItemTiers 
        {
            get { return GetResourceList<InvoiceEstimateLineItemTier>("line_item_tiers"); }
        }
        public List<InvoiceEstimateLineItemDiscount> LineItemDiscounts 
        {
            get { return GetResourceList<InvoiceEstimateLineItemDiscount>("line_item_discounts"); }
        }
        public long? RoundOffAmount 
        {
            get { return GetValue<long?>("round_off_amount", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        
        #endregion
        


        #region Subclasses
        public class InvoiceEstimateLineItem : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan_setup")]
                PlanSetup,
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "adhoc")]
                Adhoc,
                [EnumMember(Value = "plan_item_price")]
                PlanItemPrice,
                [EnumMember(Value = "addon_item_price")]
                AddonItemPrice,
                [EnumMember(Value = "charge_item_price")]
                ChargeItemPrice,
            }

            public string Id {
                get { return GetValue<string>("id", false); }
            }

            public string SubscriptionId {
                get { return GetValue<string>("subscription_id", false); }
            }

            public DateTime DateFrom {
                get { return (DateTime)GetDateTime("date_from", true); }
            }

            public DateTime DateTo {
                get { return (DateTime)GetDateTime("date_to", true); }
            }

            public long UnitAmount {
                get { return GetValue<long>("unit_amount", true); }
            }

            public int? Quantity {
                get { return GetValue<int?>("quantity", false); }
            }

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public PricingModelEnum? PricingModel {
                get { return GetEnum<PricingModelEnum>("pricing_model", false); }
            }

            public bool IsTaxed {
                get { return GetValue<bool>("is_taxed", true); }
            }

            public long? TaxAmount {
                get { return GetValue<long?>("tax_amount", false); }
            }

            public double? TaxRate {
                get { return GetValue<double?>("tax_rate", false); }
            }

            public string UnitAmountInDecimal {
                get { return GetValue<string>("unit_amount_in_decimal", false); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string AmountInDecimal {
                get { return GetValue<string>("amount_in_decimal", false); }
            }

            public long? DiscountAmount {
                get { return GetValue<long?>("discount_amount", false); }
            }

            public long? ItemLevelDiscountAmount {
                get { return GetValue<long?>("item_level_discount_amount", false); }
            }

            public string ReferenceLineItemId {
                get { return GetValue<string>("reference_line_item_id", false); }
            }

            public string Description {
                get { return GetValue<string>("description", true); }
            }

            public string EntityDescription {
                get { return GetValue<string>("entity_description", false); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public TaxExemptReasonEnum? TaxExemptReason {
                get { return GetEnum<TaxExemptReasonEnum>("tax_exempt_reason", false); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public string CustomerId {
                get { return GetValue<string>("customer_id", false); }
            }

        }
        public class InvoiceEstimateDiscount : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
                [EnumMember(Value = "item_level_discount")]
                ItemLevelDiscount,
                [EnumMember(Value = "document_level_discount")]
                DocumentLevelDiscount,
            }

            public long Amount {
                get { return GetValue<long>("amount", true); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public string CouponSetCode {
                get { return GetValue<string>("coupon_set_code", false); }
            }

        }
        public class InvoiceEstimateTax : Resource
        {

            public string Name {
                get { return GetValue<string>("name", true); }
            }

            public long Amount {
                get { return GetValue<long>("amount", true); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

        }
        public class InvoiceEstimateLineItemTax : Resource
        {

            public string LineItemId {
                get { return GetValue<string>("line_item_id", false); }
            }

            public string TaxName {
                get { return GetValue<string>("tax_name", true); }
            }

            public double TaxRate {
                get { return GetValue<double>("tax_rate", true); }
            }

            public bool? IsPartialTaxApplied {
                get { return GetValue<bool?>("is_partial_tax_applied", false); }
            }

            public bool? IsNonComplianceTax {
                get { return GetValue<bool?>("is_non_compliance_tax", false); }
            }

            public long TaxableAmount {
                get { return GetValue<long>("taxable_amount", true); }
            }

            public long TaxAmount {
                get { return GetValue<long>("tax_amount", true); }
            }

            public TaxJurisTypeEnum? TaxJurisType {
                get { return GetEnum<TaxJurisTypeEnum>("tax_juris_type", false); }
            }

            public string TaxJurisName {
                get { return GetValue<string>("tax_juris_name", false); }
            }

            public string TaxJurisCode {
                get { return GetValue<string>("tax_juris_code", false); }
            }

            public long? TaxAmountInLocalCurrency {
                get { return GetValue<long?>("tax_amount_in_local_currency", false); }
            }

            public string LocalCurrencyCode {
                get { return GetValue<string>("local_currency_code", false); }
            }

        }
        public class InvoiceEstimateLineItemTier : Resource
        {

            public string LineItemId {
                get { return GetValue<string>("line_item_id", false); }
            }

            public int StartingUnit {
                get { return GetValue<int>("starting_unit", true); }
            }

            public int? EndingUnit {
                get { return GetValue<int?>("ending_unit", false); }
            }

            public int QuantityUsed {
                get { return GetValue<int>("quantity_used", true); }
            }

            public long UnitAmount {
                get { return GetValue<long>("unit_amount", true); }
            }

            public string StartingUnitInDecimal {
                get { return GetValue<string>("starting_unit_in_decimal", false); }
            }

            public string EndingUnitInDecimal {
                get { return GetValue<string>("ending_unit_in_decimal", false); }
            }

            public string QuantityUsedInDecimal {
                get { return GetValue<string>("quantity_used_in_decimal", false); }
            }

            public string UnitAmountInDecimal {
                get { return GetValue<string>("unit_amount_in_decimal", false); }
            }

        }
        public class InvoiceEstimateLineItemDiscount : Resource
        {
            public enum DiscountTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
                [EnumMember(Value = "item_level_discount")]
                ItemLevelDiscount,
                [EnumMember(Value = "document_level_discount")]
                DocumentLevelDiscount,
            }

            public string LineItemId {
                get { return GetValue<string>("line_item_id", true); }
            }

            public DiscountTypeEnum DiscountType {
                get { return GetEnum<DiscountTypeEnum>("discount_type", true); }
            }

            public string CouponId {
                get { return GetValue<string>("coupon_id", false); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public long DiscountAmount {
                get { return GetValue<long>("discount_amount", true); }
            }

        }

        #endregion
    }
}
