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

    public class Addon : Resource 
    {
    
        public Addon() { }

        public Addon(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Addon(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Addon(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("addons");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("addons", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static AddonListRequest List()
        {
            string url = ApiUtil.BuildUrl("addons");
            return new AddonListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("addons", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("addons", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static CopyRequest Copy()
        {
            string url = ApiUtil.BuildUrl("addons", "copy");
            return new CopyRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Unarchive(string id)
        {
            string url = ApiUtil.BuildUrl("addons", CheckNull(id), "unarchive");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", true); }
        }
        public string InvoiceName 
        {
            get { return GetValue<string>("invoice_name", false); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public PricingModelEnum PricingModel 
        {
            get { return GetEnum<PricingModelEnum>("pricing_model", true); }
        }
        [Obsolete]
        public TypeEnum AddonType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public ChargeTypeEnum ChargeType 
        {
            get { return GetEnum<ChargeTypeEnum>("charge_type", true); }
        }
        public int? Price 
        {
            get { return GetValue<int?>("price", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public int? Period 
        {
            get { return GetValue<int?>("period", false); }
        }
        public PeriodUnitEnum PeriodUnit 
        {
            get { return GetEnum<PeriodUnitEnum>("period_unit", true); }
        }
        public string Unit 
        {
            get { return GetValue<string>("unit", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public bool EnabledInPortal 
        {
            get { return GetValue<bool>("enabled_in_portal", true); }
        }
        public string TaxCode 
        {
            get { return GetValue<string>("tax_code", false); }
        }
        public string HsnCode 
        {
            get { return GetValue<string>("hsn_code", false); }
        }
        public string TaxjarProductCode 
        {
            get { return GetValue<string>("taxjar_product_code", false); }
        }
        public AvalaraSaleTypeEnum? AvalaraSaleType 
        {
            get { return GetEnum<AvalaraSaleTypeEnum>("avalara_sale_type", false); }
        }
        public int? AvalaraTransactionType 
        {
            get { return GetValue<int?>("avalara_transaction_type", false); }
        }
        public int? AvalaraServiceType 
        {
            get { return GetValue<int?>("avalara_service_type", false); }
        }
        public string Sku 
        {
            get { return GetValue<string>("sku", false); }
        }
        public string AccountingCode 
        {
            get { return GetValue<string>("accounting_code", false); }
        }
        public string AccountingCategory1 
        {
            get { return GetValue<string>("accounting_category1", false); }
        }
        public string AccountingCategory2 
        {
            get { return GetValue<string>("accounting_category2", false); }
        }
        public string AccountingCategory3 
        {
            get { return GetValue<string>("accounting_category3", false); }
        }
        public string AccountingCategory4 
        {
            get { return GetValue<string>("accounting_category4", false); }
        }
        public bool? IsShippable 
        {
            get { return GetValue<bool?>("is_shippable", false); }
        }
        public int? ShippingFrequencyPeriod 
        {
            get { return GetValue<int?>("shipping_frequency_period", false); }
        }
        public ShippingFrequencyPeriodUnitEnum? ShippingFrequencyPeriodUnit 
        {
            get { return GetEnum<ShippingFrequencyPeriodUnitEnum>("shipping_frequency_period_unit", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string PriceInDecimal 
        {
            get { return GetValue<string>("price_in_decimal", false); }
        }
        public bool? IncludedInMrr 
        {
            get { return GetValue<bool?>("included_in_mrr", false); }
        }
        public ChannelEnum? Channel 
        {
            get { return GetEnum<ChannelEnum>("channel", false); }
        }
        public ProrationTypeEnum? ProrationType 
        {
            get { return GetEnum<ProrationTypeEnum>("proration_type", false); }
        }
        public string InvoiceNotes 
        {
            get { return GetValue<string>("invoice_notes", false); }
        }
        public bool? Taxable 
        {
            get { return GetValue<bool?>("taxable", false); }
        }
        public string TaxProfileId 
        {
            get { return GetValue<string>("tax_profile_id", false); }
        }
        public JToken MetaData 
        {
            get { return GetJToken("meta_data", false); }
        }
        public List<AddonTier> Tiers 
        {
            get { return GetResourceList<AddonTier>("tiers"); }
        }
        public bool? ShowDescriptionInInvoices 
        {
            get { return GetValue<bool?>("show_description_in_invoices", false); }
        }
        public bool? ShowDescriptionInQuotes 
        {
            get { return GetValue<bool?>("show_description_in_quotes", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
            public CreateRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public CreateRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public CreateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateRequest ChargeType(Addon.ChargeTypeEnum chargeType) 
            {
                m_params.Add("charge_type", chargeType);
                return this;
            }
            public CreateRequest Price(int price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public CreateRequest PeriodUnit(Addon.PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public CreateRequest PricingModel(ChargeBee.Models.Enums.PricingModelEnum pricingModel) 
            {
                m_params.AddOpt("pricing_model", pricingModel);
                return this;
            }
            [Obsolete]
            public CreateRequest Type(TypeEnum type) 
            {
                m_params.AddOpt("type", type);
                return this;
            }
            public CreateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public CreateRequest EnabledInPortal(bool enabledInPortal) 
            {
                m_params.AddOpt("enabled_in_portal", enabledInPortal);
                return this;
            }
            public CreateRequest Taxable(bool taxable) 
            {
                m_params.AddOpt("taxable", taxable);
                return this;
            }
            public CreateRequest TaxProfileId(string taxProfileId) 
            {
                m_params.AddOpt("tax_profile_id", taxProfileId);
                return this;
            }
            public CreateRequest AvalaraSaleType(ChargeBee.Models.Enums.AvalaraSaleTypeEnum avalaraSaleType) 
            {
                m_params.AddOpt("avalara_sale_type", avalaraSaleType);
                return this;
            }
            public CreateRequest AvalaraTransactionType(int avalaraTransactionType) 
            {
                m_params.AddOpt("avalara_transaction_type", avalaraTransactionType);
                return this;
            }
            public CreateRequest AvalaraServiceType(int avalaraServiceType) 
            {
                m_params.AddOpt("avalara_service_type", avalaraServiceType);
                return this;
            }
            public CreateRequest TaxCode(string taxCode) 
            {
                m_params.AddOpt("tax_code", taxCode);
                return this;
            }
            public CreateRequest HsnCode(string hsnCode) 
            {
                m_params.AddOpt("hsn_code", hsnCode);
                return this;
            }
            public CreateRequest TaxjarProductCode(string taxjarProductCode) 
            {
                m_params.AddOpt("taxjar_product_code", taxjarProductCode);
                return this;
            }
            public CreateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public CreateRequest Sku(string sku) 
            {
                m_params.AddOpt("sku", sku);
                return this;
            }
            public CreateRequest AccountingCode(string accountingCode) 
            {
                m_params.AddOpt("accounting_code", accountingCode);
                return this;
            }
            public CreateRequest AccountingCategory1(string accountingCategory1) 
            {
                m_params.AddOpt("accounting_category1", accountingCategory1);
                return this;
            }
            public CreateRequest AccountingCategory2(string accountingCategory2) 
            {
                m_params.AddOpt("accounting_category2", accountingCategory2);
                return this;
            }
            public CreateRequest AccountingCategory3(string accountingCategory3) 
            {
                m_params.AddOpt("accounting_category3", accountingCategory3);
                return this;
            }
            public CreateRequest AccountingCategory4(string accountingCategory4) 
            {
                m_params.AddOpt("accounting_category4", accountingCategory4);
                return this;
            }
            public CreateRequest IsShippable(bool isShippable) 
            {
                m_params.AddOpt("is_shippable", isShippable);
                return this;
            }
            public CreateRequest ShippingFrequencyPeriod(int shippingFrequencyPeriod) 
            {
                m_params.AddOpt("shipping_frequency_period", shippingFrequencyPeriod);
                return this;
            }
            public CreateRequest ShippingFrequencyPeriodUnit(Addon.ShippingFrequencyPeriodUnitEnum shippingFrequencyPeriodUnit) 
            {
                m_params.AddOpt("shipping_frequency_period_unit", shippingFrequencyPeriodUnit);
                return this;
            }
            public CreateRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public CreateRequest ShowDescriptionInInvoices(bool showDescriptionInInvoices) 
            {
                m_params.AddOpt("show_description_in_invoices", showDescriptionInInvoices);
                return this;
            }
            public CreateRequest ShowDescriptionInQuotes(bool showDescriptionInQuotes) 
            {
                m_params.AddOpt("show_description_in_quotes", showDescriptionInQuotes);
                return this;
            }
            public CreateRequest PriceInDecimal(string priceInDecimal) 
            {
                m_params.AddOpt("price_in_decimal", priceInDecimal);
                return this;
            }
            public CreateRequest ProrationType(Addon.ProrationTypeEnum prorationType) 
            {
                m_params.AddOpt("proration_type", prorationType);
                return this;
            }
            public CreateRequest Status(Addon.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public CreateRequest TierStartingUnit(int index, int tierStartingUnit) 
            {
                m_params.AddOpt("tiers[starting_unit][" + index + "]", tierStartingUnit);
                return this;
            }
            public CreateRequest TierEndingUnit(int index, int tierEndingUnit) 
            {
                m_params.AddOpt("tiers[ending_unit][" + index + "]", tierEndingUnit);
                return this;
            }
            public CreateRequest TierPrice(int index, int tierPrice) 
            {
                m_params.AddOpt("tiers[price][" + index + "]", tierPrice);
                return this;
            }
            public CreateRequest TierStartingUnitInDecimal(int index, string tierStartingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[starting_unit_in_decimal][" + index + "]", tierStartingUnitInDecimal);
                return this;
            }
            public CreateRequest TierEndingUnitInDecimal(int index, string tierEndingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[ending_unit_in_decimal][" + index + "]", tierEndingUnitInDecimal);
                return this;
            }
            public CreateRequest TierPriceInDecimal(int index, string tierPriceInDecimal) 
            {
                m_params.AddOpt("tiers[price_in_decimal][" + index + "]", tierPriceInDecimal);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public UpdateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateRequest ChargeType(Addon.ChargeTypeEnum chargeType) 
            {
                m_params.AddOpt("charge_type", chargeType);
                return this;
            }
            public UpdateRequest Price(int price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public UpdateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public UpdateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public UpdateRequest PeriodUnit(Addon.PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public UpdateRequest PricingModel(ChargeBee.Models.Enums.PricingModelEnum pricingModel) 
            {
                m_params.AddOpt("pricing_model", pricingModel);
                return this;
            }
            [Obsolete]
            public UpdateRequest Type(TypeEnum type) 
            {
                m_params.AddOpt("type", type);
                return this;
            }
            public UpdateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public UpdateRequest EnabledInPortal(bool enabledInPortal) 
            {
                m_params.AddOpt("enabled_in_portal", enabledInPortal);
                return this;
            }
            public UpdateRequest Taxable(bool taxable) 
            {
                m_params.AddOpt("taxable", taxable);
                return this;
            }
            public UpdateRequest TaxProfileId(string taxProfileId) 
            {
                m_params.AddOpt("tax_profile_id", taxProfileId);
                return this;
            }
            public UpdateRequest AvalaraSaleType(ChargeBee.Models.Enums.AvalaraSaleTypeEnum avalaraSaleType) 
            {
                m_params.AddOpt("avalara_sale_type", avalaraSaleType);
                return this;
            }
            public UpdateRequest AvalaraTransactionType(int avalaraTransactionType) 
            {
                m_params.AddOpt("avalara_transaction_type", avalaraTransactionType);
                return this;
            }
            public UpdateRequest AvalaraServiceType(int avalaraServiceType) 
            {
                m_params.AddOpt("avalara_service_type", avalaraServiceType);
                return this;
            }
            public UpdateRequest TaxCode(string taxCode) 
            {
                m_params.AddOpt("tax_code", taxCode);
                return this;
            }
            public UpdateRequest HsnCode(string hsnCode) 
            {
                m_params.AddOpt("hsn_code", hsnCode);
                return this;
            }
            public UpdateRequest TaxjarProductCode(string taxjarProductCode) 
            {
                m_params.AddOpt("taxjar_product_code", taxjarProductCode);
                return this;
            }
            public UpdateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public UpdateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public UpdateRequest Sku(string sku) 
            {
                m_params.AddOpt("sku", sku);
                return this;
            }
            public UpdateRequest AccountingCode(string accountingCode) 
            {
                m_params.AddOpt("accounting_code", accountingCode);
                return this;
            }
            public UpdateRequest AccountingCategory1(string accountingCategory1) 
            {
                m_params.AddOpt("accounting_category1", accountingCategory1);
                return this;
            }
            public UpdateRequest AccountingCategory2(string accountingCategory2) 
            {
                m_params.AddOpt("accounting_category2", accountingCategory2);
                return this;
            }
            public UpdateRequest AccountingCategory3(string accountingCategory3) 
            {
                m_params.AddOpt("accounting_category3", accountingCategory3);
                return this;
            }
            public UpdateRequest AccountingCategory4(string accountingCategory4) 
            {
                m_params.AddOpt("accounting_category4", accountingCategory4);
                return this;
            }
            public UpdateRequest IsShippable(bool isShippable) 
            {
                m_params.AddOpt("is_shippable", isShippable);
                return this;
            }
            public UpdateRequest ShippingFrequencyPeriod(int shippingFrequencyPeriod) 
            {
                m_params.AddOpt("shipping_frequency_period", shippingFrequencyPeriod);
                return this;
            }
            public UpdateRequest ShippingFrequencyPeriodUnit(Addon.ShippingFrequencyPeriodUnitEnum shippingFrequencyPeriodUnit) 
            {
                m_params.AddOpt("shipping_frequency_period_unit", shippingFrequencyPeriodUnit);
                return this;
            }
            public UpdateRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public UpdateRequest ShowDescriptionInInvoices(bool showDescriptionInInvoices) 
            {
                m_params.AddOpt("show_description_in_invoices", showDescriptionInInvoices);
                return this;
            }
            public UpdateRequest ShowDescriptionInQuotes(bool showDescriptionInQuotes) 
            {
                m_params.AddOpt("show_description_in_quotes", showDescriptionInQuotes);
                return this;
            }
            public UpdateRequest PriceInDecimal(string priceInDecimal) 
            {
                m_params.AddOpt("price_in_decimal", priceInDecimal);
                return this;
            }
            public UpdateRequest ProrationType(Addon.ProrationTypeEnum prorationType) 
            {
                m_params.AddOpt("proration_type", prorationType);
                return this;
            }
            public UpdateRequest TierStartingUnit(int index, int tierStartingUnit) 
            {
                m_params.AddOpt("tiers[starting_unit][" + index + "]", tierStartingUnit);
                return this;
            }
            public UpdateRequest TierEndingUnit(int index, int tierEndingUnit) 
            {
                m_params.AddOpt("tiers[ending_unit][" + index + "]", tierEndingUnit);
                return this;
            }
            public UpdateRequest TierPrice(int index, int tierPrice) 
            {
                m_params.AddOpt("tiers[price][" + index + "]", tierPrice);
                return this;
            }
            public UpdateRequest TierStartingUnitInDecimal(int index, string tierStartingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[starting_unit_in_decimal][" + index + "]", tierStartingUnitInDecimal);
                return this;
            }
            public UpdateRequest TierEndingUnitInDecimal(int index, string tierEndingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[ending_unit_in_decimal][" + index + "]", tierEndingUnitInDecimal);
                return this;
            }
            public UpdateRequest TierPriceInDecimal(int index, string tierPriceInDecimal) 
            {
                m_params.AddOpt("tiers[price_in_decimal][" + index + "]", tierPriceInDecimal);
                return this;
            }
        }
        public class AddonListRequest : ListRequestBase<AddonListRequest> 
        {
            public AddonListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<AddonListRequest> Id() 
            {
                return new StringFilter<AddonListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<AddonListRequest> Name() 
            {
                return new StringFilter<AddonListRequest>("name", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, AddonListRequest> PricingModel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, AddonListRequest>("pricing_model", this);        
            }
            [Obsolete]
            public EnumFilter<TypeEnum, AddonListRequest> Type() 
            {
                return new EnumFilter<TypeEnum, AddonListRequest>("type", this);        
            }
            public EnumFilter<Addon.ChargeTypeEnum, AddonListRequest> ChargeType() 
            {
                return new EnumFilter<Addon.ChargeTypeEnum, AddonListRequest>("charge_type", this);        
            }
            public NumberFilter<int, AddonListRequest> Price() 
            {
                return new NumberFilter<int, AddonListRequest>("price", this);        
            }
            public NumberFilter<int, AddonListRequest> Period() 
            {
                return new NumberFilter<int, AddonListRequest>("period", this);        
            }
            public EnumFilter<Addon.PeriodUnitEnum, AddonListRequest> PeriodUnit() 
            {
                return new EnumFilter<Addon.PeriodUnitEnum, AddonListRequest>("period_unit", this);        
            }
            public EnumFilter<Addon.StatusEnum, AddonListRequest> Status() 
            {
                return new EnumFilter<Addon.StatusEnum, AddonListRequest>("status", this);        
            }
            public TimestampFilter<AddonListRequest> UpdatedAt() 
            {
                return new TimestampFilter<AddonListRequest>("updated_at", this);        
            }
            public StringFilter<AddonListRequest> CurrencyCode() 
            {
                return new StringFilter<AddonListRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, AddonListRequest> Channel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, AddonListRequest>("channel", this);        
            }
            public AddonListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
        }
        public class CopyRequest : EntityRequest<CopyRequest> 
        {
            public CopyRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CopyRequest FromSite(string fromSite) 
            {
                m_params.Add("from_site", fromSite);
                return this;
            }
            public CopyRequest IdAtFromSite(string idAtFromSite) 
            {
                m_params.Add("id_at_from_site", idAtFromSite);
                return this;
            }
            public CopyRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CopyRequest ForSiteMerging(bool forSiteMerging) 
            {
                m_params.AddOpt("for_site_merging", forSiteMerging);
                return this;
            }
        }
        #endregion

        [Obsolete]
        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "on_off")]
            OnOff,
            [EnumMember(Value = "quantity")]
            Quantity,
            [EnumMember(Value = "tiered")]
            Tiered,
            [EnumMember(Value = "volume")]
            Volume,
            [EnumMember(Value = "stairstep")]
            Stairstep,

        }
        public enum ChargeTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "recurring")]
            Recurring,
            [EnumMember(Value = "non_recurring")]
            NonRecurring,

        }
        public enum PeriodUnitEnum
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
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "archived")]
            Archived,
            [EnumMember(Value = "deleted")]
            Deleted,

        }
        public enum ShippingFrequencyPeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "year")]
            Year,
            [EnumMember(Value = "month")]
            Month,
            [EnumMember(Value = "week")]
            Week,
            [EnumMember(Value = "day")]
            Day,

        }
        public enum ProrationTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "site_default")]
            SiteDefault,
            [EnumMember(Value = "partial_term")]
            PartialTerm,
            [EnumMember(Value = "full_term")]
            FullTerm,

        }

        #region Subclasses
        public class AddonTier : Resource
        {

            public int StartingUnit {
                get { return GetValue<int>("starting_unit", true); }
            }

            public int? EndingUnit {
                get { return GetValue<int?>("ending_unit", false); }
            }

            public int Price {
                get { return GetValue<int>("price", true); }
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

        }

        #endregion
    }
}
