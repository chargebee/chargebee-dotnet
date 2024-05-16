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

    public class UnbilledCharge : Resource 
    {
    
        public UnbilledCharge() { }

        public UnbilledCharge(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public UnbilledCharge(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public UnbilledCharge(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateUnbilledChargeRequest CreateUnbilledCharge()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges", "create");
            return new CreateUnbilledChargeRequest(url, HttpMethod.POST);
        }
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static InvoiceUnbilledChargesRequest InvoiceUnbilledCharges()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges", "invoice_unbilled_charges");
            return new InvoiceUnbilledChargesRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("unbilled_charges", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static UnbilledChargeListRequest List()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges");
            return new UnbilledChargeListRequest(url);
        }
        public static InvoiceNowEstimateRequest InvoiceNowEstimate()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges", "invoice_now_estimate");
            return new InvoiceNowEstimateRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public DateTime? DateFrom 
        {
            get { return GetDateTime("date_from", false); }
        }
        public DateTime? DateTo 
        {
            get { return GetDateTime("date_to", false); }
        }
        public long? UnitAmount 
        {
            get { return GetValue<long?>("unit_amount", false); }
        }
        public PricingModelEnum? PricingModel 
        {
            get { return GetEnum<PricingModelEnum>("pricing_model", false); }
        }
        public int? Quantity 
        {
            get { return GetValue<int?>("quantity", false); }
        }
        public long? Amount 
        {
            get { return GetValue<long?>("amount", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public long? DiscountAmount 
        {
            get { return GetValue<long?>("discount_amount", false); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", false); }
        }
        public bool IsVoided 
        {
            get { return GetValue<bool>("is_voided", true); }
        }
        public DateTime? VoidedAt 
        {
            get { return GetDateTime("voided_at", false); }
        }
        public string UnitAmountInDecimal 
        {
            get { return GetValue<string>("unit_amount_in_decimal", false); }
        }
        public string QuantityInDecimal 
        {
            get { return GetValue<string>("quantity_in_decimal", false); }
        }
        public string AmountInDecimal 
        {
            get { return GetValue<string>("amount_in_decimal", false); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public List<UnbilledChargeTier> Tiers 
        {
            get { return GetResourceList<UnbilledChargeTier>("tiers"); }
        }
        public bool? IsAdvanceCharge 
        {
            get { return GetValue<bool?>("is_advance_charge", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateUnbilledChargeRequest : EntityRequest<CreateUnbilledChargeRequest> 
        {
            public CreateUnbilledChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateUnbilledChargeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public CreateUnbilledChargeRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateUnbilledChargeRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateUnbilledChargeRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateUnbilledChargeRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateUnbilledChargeRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateUnbilledChargeRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateUnbilledChargeRequest AddonDateFrom(int index, long addonDateFrom) 
            {
                m_params.AddOpt("addons[date_from][" + index + "]", addonDateFrom);
                return this;
            }
            public CreateUnbilledChargeRequest AddonDateTo(int index, long addonDateTo) 
            {
                m_params.AddOpt("addons[date_to][" + index + "]", addonDateTo);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeAmount(int index, long chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CreateUnbilledChargeRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
        }
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateRequest ItemPriceItemPriceId(int index, string itemPriceItemPriceId) 
            {
                m_params.AddOpt("item_prices[item_price_id][" + index + "]", itemPriceItemPriceId);
                return this;
            }
            public CreateRequest ItemPriceQuantity(int index, int itemPriceQuantity) 
            {
                m_params.AddOpt("item_prices[quantity][" + index + "]", itemPriceQuantity);
                return this;
            }
            public CreateRequest ItemPriceQuantityInDecimal(int index, string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_prices[quantity_in_decimal][" + index + "]", itemPriceQuantityInDecimal);
                return this;
            }
            public CreateRequest ItemPriceUnitPrice(int index, long itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_prices[unit_price][" + index + "]", itemPriceUnitPrice);
                return this;
            }
            public CreateRequest ItemPriceUnitPriceInDecimal(int index, string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_prices[unit_price_in_decimal][" + index + "]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public CreateRequest ItemPriceDateFrom(int index, long itemPriceDateFrom) 
            {
                m_params.AddOpt("item_prices[date_from][" + index + "]", itemPriceDateFrom);
                return this;
            }
            public CreateRequest ItemPriceDateTo(int index, long itemPriceDateTo) 
            {
                m_params.AddOpt("item_prices[date_to][" + index + "]", itemPriceDateTo);
                return this;
            }
            public CreateRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CreateRequest ChargeAmount(int index, long chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CreateRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CreateRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CreateRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CreateRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CreateRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CreateRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CreateRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
        }
        public class InvoiceUnbilledChargesRequest : EntityRequest<InvoiceUnbilledChargesRequest> 
        {
            public InvoiceUnbilledChargesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public InvoiceUnbilledChargesRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public InvoiceUnbilledChargesRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
        }
        public class UnbilledChargeListRequest : ListRequestBase<UnbilledChargeListRequest> 
        {
            public UnbilledChargeListRequest(string url) 
                    : base(url)
            {
            }

            public UnbilledChargeListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public UnbilledChargeListRequest IsVoided(bool isVoided) 
            {
                m_params.AddOpt("is_voided", isVoided);
                return this;
            }
            public StringFilter<UnbilledChargeListRequest> SubscriptionId() 
            {
                return new StringFilter<UnbilledChargeListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public StringFilter<UnbilledChargeListRequest> CustomerId() 
            {
                return new StringFilter<UnbilledChargeListRequest>("customer_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
        }
        public class InvoiceNowEstimateRequest : EntityRequest<InvoiceNowEstimateRequest> 
        {
            public InvoiceNowEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public InvoiceNowEstimateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public InvoiceNowEstimateRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
        }
        #endregion

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

        #region Subclasses
        public class UnbilledChargeTier : Resource
        {

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

        #endregion
    }
}
