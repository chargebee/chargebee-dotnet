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

    public class ItemPrice : Resource 
    {
    
        public ItemPrice() { }

        public ItemPrice(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public ItemPrice(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public ItemPrice(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("item_prices");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("item_prices", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("item_prices", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static ItemPriceListRequest List()
        {
            string url = ApiUtil.BuildUrl("item_prices");
            return new ItemPriceListRequest(url);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("item_prices", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static ItemPriceFindApplicableItemsRequest FindApplicableItems(string id)
        {
            string url = ApiUtil.BuildUrl("item_prices", CheckNull(id), "applicable_items");
            return new ItemPriceFindApplicableItemsRequest(url);
        }
        public static ItemPriceFindApplicableItemPricesRequest FindApplicableItemPrices(string id)
        {
            string url = ApiUtil.BuildUrl("item_prices", CheckNull(id), "applicable_item_prices");
            return new ItemPriceFindApplicableItemPricesRequest(url);
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
        public string ItemFamilyId 
        {
            get { return GetValue<string>("item_family_id", false); }
        }
        public string ItemId 
        {
            get { return GetValue<string>("item_id", false); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string ExternalName 
        {
            get { return GetValue<string>("external_name", false); }
        }
        public PricingModelEnum PricingModel 
        {
            get { return GetEnum<PricingModelEnum>("pricing_model", true); }
        }
        public long? Price 
        {
            get { return GetValue<long?>("price", false); }
        }
        public string PriceInDecimal 
        {
            get { return GetValue<string>("price_in_decimal", false); }
        }
        public int? Period 
        {
            get { return GetValue<int?>("period", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public PeriodUnitEnum? PeriodUnit 
        {
            get { return GetEnum<PeriodUnitEnum>("period_unit", false); }
        }
        public int? TrialPeriod 
        {
            get { return GetValue<int?>("trial_period", false); }
        }
        public TrialPeriodUnitEnum? TrialPeriodUnit 
        {
            get { return GetEnum<TrialPeriodUnitEnum>("trial_period_unit", false); }
        }
        public TrialEndActionEnum? TrialEndAction 
        {
            get { return GetEnum<TrialEndActionEnum>("trial_end_action", false); }
        }
        public int? ShippingPeriod 
        {
            get { return GetValue<int?>("shipping_period", false); }
        }
        public ShippingPeriodUnitEnum? ShippingPeriodUnit 
        {
            get { return GetEnum<ShippingPeriodUnitEnum>("shipping_period_unit", false); }
        }
        public int? BillingCycles 
        {
            get { return GetValue<int?>("billing_cycles", false); }
        }
        public int FreeQuantity 
        {
            get { return GetValue<int>("free_quantity", true); }
        }
        public string FreeQuantityInDecimal 
        {
            get { return GetValue<string>("free_quantity_in_decimal", false); }
        }
        public ChannelEnum? Channel 
        {
            get { return GetEnum<ChannelEnum>("channel", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public string InvoiceNotes 
        {
            get { return GetValue<string>("invoice_notes", false); }
        }
        public List<ItemPriceTier> Tiers 
        {
            get { return GetResourceList<ItemPriceTier>("tiers"); }
        }
        public bool? IsTaxable 
        {
            get { return GetValue<bool?>("is_taxable", false); }
        }
        public ItemPriceTaxDetail TaxDetail 
        {
            get { return GetSubResource<ItemPriceTaxDetail>("tax_detail"); }
        }
        public ItemPriceAccountingDetail AccountingDetail 
        {
            get { return GetSubResource<ItemPriceAccountingDetail>("accounting_detail"); }
        }
        public JToken Metadata 
        {
            get { return GetJToken("metadata", false); }
        }
        public ItemTypeEnum? ItemType 
        {
            get { return GetEnum<ItemTypeEnum>("item_type", false); }
        }
        [Obsolete]
        public bool? Archivable 
        {
            get { return GetValue<bool?>("archivable", false); }
        }
        [Obsolete]
        public string ParentItemId 
        {
            get { return GetValue<string>("parent_item_id", false); }
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
            public CreateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateRequest ItemId(string itemId) 
            {
                m_params.Add("item_id", itemId);
                return this;
            }
            public CreateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateRequest ExternalName(string externalName) 
            {
                m_params.AddOpt("external_name", externalName);
                return this;
            }
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateRequest IsTaxable(bool isTaxable) 
            {
                m_params.AddOpt("is_taxable", isTaxable);
                return this;
            }
            public CreateRequest FreeQuantity(int freeQuantity) 
            {
                m_params.AddOpt("free_quantity", freeQuantity);
                return this;
            }
            public CreateRequest FreeQuantityInDecimal(string freeQuantityInDecimal) 
            {
                m_params.AddOpt("free_quantity_in_decimal", freeQuantityInDecimal);
                return this;
            }
            public CreateRequest Metadata(JToken metadata) 
            {
                m_params.AddOpt("metadata", metadata);
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
            public CreateRequest PricingModel(ChargeBee.Models.Enums.PricingModelEnum pricingModel) 
            {
                m_params.AddOpt("pricing_model", pricingModel);
                return this;
            }
            public CreateRequest Price(long price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public CreateRequest PriceInDecimal(string priceInDecimal) 
            {
                m_params.AddOpt("price_in_decimal", priceInDecimal);
                return this;
            }
            public CreateRequest PeriodUnit(ItemPrice.PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public CreateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public CreateRequest TrialPeriodUnit(ItemPrice.TrialPeriodUnitEnum trialPeriodUnit) 
            {
                m_params.AddOpt("trial_period_unit", trialPeriodUnit);
                return this;
            }
            public CreateRequest TrialPeriod(int trialPeriod) 
            {
                m_params.AddOpt("trial_period", trialPeriod);
                return this;
            }
            public CreateRequest ShippingPeriod(int shippingPeriod) 
            {
                m_params.AddOpt("shipping_period", shippingPeriod);
                return this;
            }
            public CreateRequest ShippingPeriodUnit(ItemPrice.ShippingPeriodUnitEnum shippingPeriodUnit) 
            {
                m_params.AddOpt("shipping_period_unit", shippingPeriodUnit);
                return this;
            }
            public CreateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateRequest TrialEndAction(ItemPrice.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
                return this;
            }
            public CreateRequest TaxDetailTaxProfileId(string taxDetailTaxProfileId) 
            {
                m_params.AddOpt("tax_detail[tax_profile_id]", taxDetailTaxProfileId);
                return this;
            }
            public CreateRequest TaxDetailAvalaraTaxCode(string taxDetailAvalaraTaxCode) 
            {
                m_params.AddOpt("tax_detail[avalara_tax_code]", taxDetailAvalaraTaxCode);
                return this;
            }
            public CreateRequest TaxDetailHsnCode(string taxDetailHsnCode) 
            {
                m_params.AddOpt("tax_detail[hsn_code]", taxDetailHsnCode);
                return this;
            }
            public CreateRequest TaxDetailAvalaraSaleType(ChargeBee.Models.Enums.AvalaraSaleTypeEnum taxDetailAvalaraSaleType) 
            {
                m_params.AddOpt("tax_detail[avalara_sale_type]", taxDetailAvalaraSaleType);
                return this;
            }
            public CreateRequest TaxDetailAvalaraTransactionType(int taxDetailAvalaraTransactionType) 
            {
                m_params.AddOpt("tax_detail[avalara_transaction_type]", taxDetailAvalaraTransactionType);
                return this;
            }
            public CreateRequest TaxDetailAvalaraServiceType(int taxDetailAvalaraServiceType) 
            {
                m_params.AddOpt("tax_detail[avalara_service_type]", taxDetailAvalaraServiceType);
                return this;
            }
            public CreateRequest TaxDetailTaxjarProductCode(string taxDetailTaxjarProductCode) 
            {
                m_params.AddOpt("tax_detail[taxjar_product_code]", taxDetailTaxjarProductCode);
                return this;
            }
            public CreateRequest AccountingDetailSku(string accountingDetailSku) 
            {
                m_params.AddOpt("accounting_detail[sku]", accountingDetailSku);
                return this;
            }
            public CreateRequest AccountingDetailAccountingCode(string accountingDetailAccountingCode) 
            {
                m_params.AddOpt("accounting_detail[accounting_code]", accountingDetailAccountingCode);
                return this;
            }
            public CreateRequest AccountingDetailAccountingCategory1(string accountingDetailAccountingCategory1) 
            {
                m_params.AddOpt("accounting_detail[accounting_category1]", accountingDetailAccountingCategory1);
                return this;
            }
            public CreateRequest AccountingDetailAccountingCategory2(string accountingDetailAccountingCategory2) 
            {
                m_params.AddOpt("accounting_detail[accounting_category2]", accountingDetailAccountingCategory2);
                return this;
            }
            public CreateRequest AccountingDetailAccountingCategory3(string accountingDetailAccountingCategory3) 
            {
                m_params.AddOpt("accounting_detail[accounting_category3]", accountingDetailAccountingCategory3);
                return this;
            }
            public CreateRequest AccountingDetailAccountingCategory4(string accountingDetailAccountingCategory4) 
            {
                m_params.AddOpt("accounting_detail[accounting_category4]", accountingDetailAccountingCategory4);
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
            public CreateRequest TierPrice(int index, long tierPrice) 
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
            public UpdateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateRequest Status(ItemPrice.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public UpdateRequest ExternalName(string externalName) 
            {
                m_params.AddOpt("external_name", externalName);
                return this;
            }
            public UpdateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public UpdateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public UpdateRequest IsTaxable(bool isTaxable) 
            {
                m_params.AddOpt("is_taxable", isTaxable);
                return this;
            }
            public UpdateRequest FreeQuantity(int freeQuantity) 
            {
                m_params.AddOpt("free_quantity", freeQuantity);
                return this;
            }
            public UpdateRequest FreeQuantityInDecimal(string freeQuantityInDecimal) 
            {
                m_params.AddOpt("free_quantity_in_decimal", freeQuantityInDecimal);
                return this;
            }
            public UpdateRequest Metadata(JToken metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
            public UpdateRequest PricingModel(ChargeBee.Models.Enums.PricingModelEnum pricingModel) 
            {
                m_params.AddOpt("pricing_model", pricingModel);
                return this;
            }
            public UpdateRequest Price(long price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public UpdateRequest PriceInDecimal(string priceInDecimal) 
            {
                m_params.AddOpt("price_in_decimal", priceInDecimal);
                return this;
            }
            public UpdateRequest PeriodUnit(ItemPrice.PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public UpdateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public UpdateRequest TrialPeriodUnit(ItemPrice.TrialPeriodUnitEnum trialPeriodUnit) 
            {
                m_params.AddOpt("trial_period_unit", trialPeriodUnit);
                return this;
            }
            public UpdateRequest TrialPeriod(int trialPeriod) 
            {
                m_params.AddOpt("trial_period", trialPeriod);
                return this;
            }
            public UpdateRequest ShippingPeriod(int shippingPeriod) 
            {
                m_params.AddOpt("shipping_period", shippingPeriod);
                return this;
            }
            public UpdateRequest ShippingPeriodUnit(ItemPrice.ShippingPeriodUnitEnum shippingPeriodUnit) 
            {
                m_params.AddOpt("shipping_period_unit", shippingPeriodUnit);
                return this;
            }
            public UpdateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateRequest TrialEndAction(ItemPrice.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
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
            public UpdateRequest TaxDetailTaxProfileId(string taxDetailTaxProfileId) 
            {
                m_params.AddOpt("tax_detail[tax_profile_id]", taxDetailTaxProfileId);
                return this;
            }
            public UpdateRequest TaxDetailAvalaraTaxCode(string taxDetailAvalaraTaxCode) 
            {
                m_params.AddOpt("tax_detail[avalara_tax_code]", taxDetailAvalaraTaxCode);
                return this;
            }
            public UpdateRequest TaxDetailHsnCode(string taxDetailHsnCode) 
            {
                m_params.AddOpt("tax_detail[hsn_code]", taxDetailHsnCode);
                return this;
            }
            public UpdateRequest TaxDetailAvalaraSaleType(ChargeBee.Models.Enums.AvalaraSaleTypeEnum taxDetailAvalaraSaleType) 
            {
                m_params.AddOpt("tax_detail[avalara_sale_type]", taxDetailAvalaraSaleType);
                return this;
            }
            public UpdateRequest TaxDetailAvalaraTransactionType(int taxDetailAvalaraTransactionType) 
            {
                m_params.AddOpt("tax_detail[avalara_transaction_type]", taxDetailAvalaraTransactionType);
                return this;
            }
            public UpdateRequest TaxDetailAvalaraServiceType(int taxDetailAvalaraServiceType) 
            {
                m_params.AddOpt("tax_detail[avalara_service_type]", taxDetailAvalaraServiceType);
                return this;
            }
            public UpdateRequest TaxDetailTaxjarProductCode(string taxDetailTaxjarProductCode) 
            {
                m_params.AddOpt("tax_detail[taxjar_product_code]", taxDetailTaxjarProductCode);
                return this;
            }
            public UpdateRequest AccountingDetailSku(string accountingDetailSku) 
            {
                m_params.AddOpt("accounting_detail[sku]", accountingDetailSku);
                return this;
            }
            public UpdateRequest AccountingDetailAccountingCode(string accountingDetailAccountingCode) 
            {
                m_params.AddOpt("accounting_detail[accounting_code]", accountingDetailAccountingCode);
                return this;
            }
            public UpdateRequest AccountingDetailAccountingCategory1(string accountingDetailAccountingCategory1) 
            {
                m_params.AddOpt("accounting_detail[accounting_category1]", accountingDetailAccountingCategory1);
                return this;
            }
            public UpdateRequest AccountingDetailAccountingCategory2(string accountingDetailAccountingCategory2) 
            {
                m_params.AddOpt("accounting_detail[accounting_category2]", accountingDetailAccountingCategory2);
                return this;
            }
            public UpdateRequest AccountingDetailAccountingCategory3(string accountingDetailAccountingCategory3) 
            {
                m_params.AddOpt("accounting_detail[accounting_category3]", accountingDetailAccountingCategory3);
                return this;
            }
            public UpdateRequest AccountingDetailAccountingCategory4(string accountingDetailAccountingCategory4) 
            {
                m_params.AddOpt("accounting_detail[accounting_category4]", accountingDetailAccountingCategory4);
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
            public UpdateRequest TierPrice(int index, long tierPrice) 
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
        public class ItemPriceListRequest : ListRequestBase<ItemPriceListRequest> 
        {
            public ItemPriceListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<ItemPriceListRequest> Id() 
            {
                return new StringFilter<ItemPriceListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<ItemPriceListRequest> Name() 
            {
                return new StringFilter<ItemPriceListRequest>("name", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, ItemPriceListRequest> PricingModel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, ItemPriceListRequest>("pricing_model", this);        
            }
            public StringFilter<ItemPriceListRequest> ItemId() 
            {
                return new StringFilter<ItemPriceListRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<ItemPriceListRequest> ItemFamilyId() 
            {
                return new StringFilter<ItemPriceListRequest>("item_family_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, ItemPriceListRequest> ItemType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, ItemPriceListRequest>("item_type", this);        
            }
            public StringFilter<ItemPriceListRequest> CurrencyCode() 
            {
                return new StringFilter<ItemPriceListRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
            public NumberFilter<int, ItemPriceListRequest> TrialPeriod() 
            {
                return new NumberFilter<int, ItemPriceListRequest>("trial_period", this);        
            }
            public EnumFilter<ItemPrice.TrialPeriodUnitEnum, ItemPriceListRequest> TrialPeriodUnit() 
            {
                return new EnumFilter<ItemPrice.TrialPeriodUnitEnum, ItemPriceListRequest>("trial_period_unit", this);        
            }
            public EnumFilter<ItemPrice.StatusEnum, ItemPriceListRequest> Status() 
            {
                return new EnumFilter<ItemPrice.StatusEnum, ItemPriceListRequest>("status", this);        
            }
            public TimestampFilter<ItemPriceListRequest> UpdatedAt() 
            {
                return new TimestampFilter<ItemPriceListRequest>("updated_at", this);        
            }
            public EnumFilter<ItemPrice.PeriodUnitEnum, ItemPriceListRequest> PeriodUnit() 
            {
                return new EnumFilter<ItemPrice.PeriodUnitEnum, ItemPriceListRequest>("period_unit", this);        
            }
            public NumberFilter<int, ItemPriceListRequest> Period() 
            {
                return new NumberFilter<int, ItemPriceListRequest>("period", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, ItemPriceListRequest> Channel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, ItemPriceListRequest>("channel", this);        
            }
            public ItemPriceListRequest SortByName(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","name");
                return this;
            }
            public ItemPriceListRequest SortById(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","id");
                return this;
            }
            public ItemPriceListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        public class ItemPriceFindApplicableItemsRequest : ListRequestBase<ItemPriceFindApplicableItemsRequest> 
        {
            public ItemPriceFindApplicableItemsRequest(string url) 
                    : base(url)
            {
            }

            public ItemPriceFindApplicableItemsRequest SortByName(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","name");
                return this;
            }
            public ItemPriceFindApplicableItemsRequest SortById(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","id");
                return this;
            }
            public ItemPriceFindApplicableItemsRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        public class ItemPriceFindApplicableItemPricesRequest : ListRequestBase<ItemPriceFindApplicableItemPricesRequest> 
        {
            public ItemPriceFindApplicableItemPricesRequest(string url) 
                    : base(url)
            {
            }

            public ItemPriceFindApplicableItemPricesRequest ItemId(string itemId) 
            {
                m_params.AddOpt("item_id", itemId);
                return this;
            }
            public ItemPriceFindApplicableItemPricesRequest SortByName(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","name");
                return this;
            }
            public ItemPriceFindApplicableItemPricesRequest SortById(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","id");
                return this;
            }
            public ItemPriceFindApplicableItemPricesRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        #endregion

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

        }
        public enum TrialPeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "day")]
            Day,
            [EnumMember(Value = "month")]
            Month,

        }
        public enum TrialEndActionEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "site_default")]
            SiteDefault,
            [EnumMember(Value = "activate_subscription")]
            ActivateSubscription,
            [EnumMember(Value = "cancel_subscription")]
            CancelSubscription,

        }
        public enum ShippingPeriodUnitEnum
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

        #region Subclasses
        public class ItemPriceTier : Resource
        {

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

        }
        public class ItemPriceTaxDetail : Resource
        {

            public string TaxProfileId {
                get { return GetValue<string>("tax_profile_id", false); }
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

            public string AvalaraTaxCode {
                get { return GetValue<string>("avalara_tax_code", false); }
            }

            public string HsnCode {
                get { return GetValue<string>("hsn_code", false); }
            }

            public string TaxjarProductCode {
                get { return GetValue<string>("taxjar_product_code", false); }
            }

        }
        public class ItemPriceAccountingDetail : Resource
        {

            public string Sku {
                get { return GetValue<string>("sku", false); }
            }

            public string AccountingCode {
                get { return GetValue<string>("accounting_code", false); }
            }

            public string AccountingCategory1 {
                get { return GetValue<string>("accounting_category1", false); }
            }

            public string AccountingCategory2 {
                get { return GetValue<string>("accounting_category2", false); }
            }

            public string AccountingCategory3 {
                get { return GetValue<string>("accounting_category3", false); }
            }

            public string AccountingCategory4 {
                get { return GetValue<string>("accounting_category4", false); }
            }

        }

        #endregion
    }
}
