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

    public class Plan : Resource 
    {
    
        public Plan() { }

        public Plan(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Plan(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Plan(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("plans");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("plans", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static PlanListRequest List()
        {
            string url = ApiUtil.BuildUrl("plans");
            return new PlanListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("plans", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("plans", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static CopyRequest Copy()
        {
            string url = ApiUtil.BuildUrl("plans", "copy");
            return new CopyRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Unarchive(string id)
        {
            string url = ApiUtil.BuildUrl("plans", CheckNull(id), "unarchive");
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
        public long? Price 
        {
            get { return GetValue<long?>("price", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public int Period 
        {
            get { return GetValue<int>("period", true); }
        }
        public PeriodUnitEnum PeriodUnit 
        {
            get { return GetEnum<PeriodUnitEnum>("period_unit", true); }
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
        public PricingModelEnum PricingModel 
        {
            get { return GetEnum<PricingModelEnum>("pricing_model", true); }
        }
        [Obsolete]
        public ChargeModelEnum ChargeModel 
        {
            get { return GetEnum<ChargeModelEnum>("charge_model", true); }
        }
        public int FreeQuantity 
        {
            get { return GetValue<int>("free_quantity", true); }
        }
        public long? SetupCost 
        {
            get { return GetValue<long?>("setup_cost", false); }
        }
        [Obsolete]
        public double? DowngradePenalty 
        {
            get { return GetValue<double?>("downgrade_penalty", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public int? BillingCycles 
        {
            get { return GetValue<int?>("billing_cycles", false); }
        }
        public string RedirectUrl 
        {
            get { return GetValue<string>("redirect_url", false); }
        }
        public bool EnabledInHostedPages 
        {
            get { return GetValue<bool>("enabled_in_hosted_pages", true); }
        }
        public bool EnabledInPortal 
        {
            get { return GetValue<bool>("enabled_in_portal", true); }
        }
        public AddonApplicabilityEnum AddonApplicability 
        {
            get { return GetEnum<AddonApplicabilityEnum>("addon_applicability", true); }
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
        public bool Giftable 
        {
            get { return GetValue<bool>("giftable", true); }
        }
        public string ClaimUrl 
        {
            get { return GetValue<string>("claim_url", false); }
        }
        public string FreeQuantityInDecimal 
        {
            get { return GetValue<string>("free_quantity_in_decimal", false); }
        }
        public string PriceInDecimal 
        {
            get { return GetValue<string>("price_in_decimal", false); }
        }
        public ChannelEnum? Channel 
        {
            get { return GetEnum<ChannelEnum>("channel", false); }
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
        public List<PlanTier> Tiers 
        {
            get { return GetResourceList<PlanTier>("tiers"); }
        }
        public List<PlanTaxProvidersField> TaxProvidersFields 
        {
            get { return GetResourceList<PlanTaxProvidersField>("tax_providers_fields"); }
        }
        public List<PlanApplicableAddon> ApplicableAddons 
        {
            get { return GetResourceList<PlanApplicableAddon>("applicable_addons"); }
        }
        public List<PlanAttachedAddon> AttachedAddons 
        {
            get { return GetResourceList<PlanAttachedAddon>("attached_addons"); }
        }
        public List<PlanEventBasedAddon> EventBasedAddons 
        {
            get { return GetResourceList<PlanEventBasedAddon>("event_based_addons"); }
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
            public CreateRequest TrialPeriod(int trialPeriod) 
            {
                m_params.AddOpt("trial_period", trialPeriod);
                return this;
            }
            public CreateRequest TrialPeriodUnit(Plan.TrialPeriodUnitEnum trialPeriodUnit) 
            {
                m_params.AddOpt("trial_period_unit", trialPeriodUnit);
                return this;
            }
            public CreateRequest TrialEndAction(Plan.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
                return this;
            }
            public CreateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public CreateRequest PeriodUnit(Plan.PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public CreateRequest SetupCost(long setupCost) 
            {
                m_params.AddOpt("setup_cost", setupCost);
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
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateRequest PricingModel(ChargeBee.Models.Enums.PricingModelEnum pricingModel) 
            {
                m_params.AddOpt("pricing_model", pricingModel);
                return this;
            }
            [Obsolete]
            public CreateRequest ChargeModel(ChargeModelEnum chargeModel) 
            {
                m_params.AddOpt("charge_model", chargeModel);
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
            public CreateRequest AddonApplicability(Plan.AddonApplicabilityEnum addonApplicability) 
            {
                m_params.AddOpt("addon_applicability", addonApplicability);
                return this;
            }
            [Obsolete]
            public CreateRequest DowngradePenalty(double downgradePenalty) 
            {
                m_params.AddOpt("downgrade_penalty", downgradePenalty);
                return this;
            }
            public CreateRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CreateRequest EnabledInHostedPages(bool enabledInHostedPages) 
            {
                m_params.AddOpt("enabled_in_hosted_pages", enabledInHostedPages);
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
            public CreateRequest ShippingFrequencyPeriodUnit(Plan.ShippingFrequencyPeriodUnitEnum shippingFrequencyPeriodUnit) 
            {
                m_params.AddOpt("shipping_frequency_period_unit", shippingFrequencyPeriodUnit);
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
            public CreateRequest Giftable(bool giftable) 
            {
                m_params.AddOpt("giftable", giftable);
                return this;
            }
            public CreateRequest Status(Plan.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public CreateRequest ClaimUrl(string claimUrl) 
            {
                m_params.AddOpt("claim_url", claimUrl);
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
            public CreateRequest ApplicableAddonId(int index, string applicableAddonId) 
            {
                m_params.AddOpt("applicable_addons[id][" + index + "]", applicableAddonId);
                return this;
            }
            public CreateRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public CreateRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public CreateRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public CreateRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public CreateRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public CreateRequest AttachedAddonId(int index, string attachedAddonId) 
            {
                m_params.AddOpt("attached_addons[id][" + index + "]", attachedAddonId);
                return this;
            }
            public CreateRequest AttachedAddonQuantity(int index, int attachedAddonQuantity) 
            {
                m_params.AddOpt("attached_addons[quantity][" + index + "]", attachedAddonQuantity);
                return this;
            }
            public CreateRequest AttachedAddonQuantityInDecimal(int index, string attachedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("attached_addons[quantity_in_decimal][" + index + "]", attachedAddonQuantityInDecimal);
                return this;
            }
            public CreateRequest AttachedAddonBillingCycles(int index, int attachedAddonBillingCycles) 
            {
                m_params.AddOpt("attached_addons[billing_cycles][" + index + "]", attachedAddonBillingCycles);
                return this;
            }
            public CreateRequest AttachedAddonType(int index, PlanAttachedAddon.TypeEnum attachedAddonType) 
            {
                m_params.AddOpt("attached_addons[type][" + index + "]", attachedAddonType);
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
            public UpdateRequest TrialPeriod(int trialPeriod) 
            {
                m_params.AddOpt("trial_period", trialPeriod);
                return this;
            }
            public UpdateRequest TrialPeriodUnit(Plan.TrialPeriodUnitEnum trialPeriodUnit) 
            {
                m_params.AddOpt("trial_period_unit", trialPeriodUnit);
                return this;
            }
            public UpdateRequest TrialEndAction(Plan.TrialEndActionEnum trialEndAction) 
            {
                m_params.AddOpt("trial_end_action", trialEndAction);
                return this;
            }
            public UpdateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public UpdateRequest PeriodUnit(Plan.PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public UpdateRequest SetupCost(long setupCost) 
            {
                m_params.AddOpt("setup_cost", setupCost);
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
            public UpdateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public UpdateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateRequest PricingModel(ChargeBee.Models.Enums.PricingModelEnum pricingModel) 
            {
                m_params.AddOpt("pricing_model", pricingModel);
                return this;
            }
            [Obsolete]
            public UpdateRequest ChargeModel(ChargeModelEnum chargeModel) 
            {
                m_params.AddOpt("charge_model", chargeModel);
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
            public UpdateRequest AddonApplicability(Plan.AddonApplicabilityEnum addonApplicability) 
            {
                m_params.AddOpt("addon_applicability", addonApplicability);
                return this;
            }
            [Obsolete]
            public UpdateRequest DowngradePenalty(double downgradePenalty) 
            {
                m_params.AddOpt("downgrade_penalty", downgradePenalty);
                return this;
            }
            public UpdateRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public UpdateRequest EnabledInHostedPages(bool enabledInHostedPages) 
            {
                m_params.AddOpt("enabled_in_hosted_pages", enabledInHostedPages);
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
            public UpdateRequest ShippingFrequencyPeriodUnit(Plan.ShippingFrequencyPeriodUnitEnum shippingFrequencyPeriodUnit) 
            {
                m_params.AddOpt("shipping_frequency_period_unit", shippingFrequencyPeriodUnit);
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
            public UpdateRequest ApplicableAddonId(int index, string applicableAddonId) 
            {
                m_params.AddOpt("applicable_addons[id][" + index + "]", applicableAddonId);
                return this;
            }
            public UpdateRequest EventBasedAddonId(int index, string eventBasedAddonId) 
            {
                m_params.AddOpt("event_based_addons[id][" + index + "]", eventBasedAddonId);
                return this;
            }
            public UpdateRequest EventBasedAddonQuantity(int index, int eventBasedAddonQuantity) 
            {
                m_params.AddOpt("event_based_addons[quantity][" + index + "]", eventBasedAddonQuantity);
                return this;
            }
            public UpdateRequest EventBasedAddonQuantityInDecimal(int index, string eventBasedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("event_based_addons[quantity_in_decimal][" + index + "]", eventBasedAddonQuantityInDecimal);
                return this;
            }
            public UpdateRequest EventBasedAddonOnEvent(int index, ChargeBee.Models.Enums.OnEventEnum eventBasedAddonOnEvent) 
            {
                m_params.AddOpt("event_based_addons[on_event][" + index + "]", eventBasedAddonOnEvent);
                return this;
            }
            public UpdateRequest EventBasedAddonChargeOnce(int index, bool eventBasedAddonChargeOnce) 
            {
                m_params.AddOpt("event_based_addons[charge_once][" + index + "]", eventBasedAddonChargeOnce);
                return this;
            }
            public UpdateRequest AttachedAddonId(int index, string attachedAddonId) 
            {
                m_params.AddOpt("attached_addons[id][" + index + "]", attachedAddonId);
                return this;
            }
            public UpdateRequest AttachedAddonQuantity(int index, int attachedAddonQuantity) 
            {
                m_params.AddOpt("attached_addons[quantity][" + index + "]", attachedAddonQuantity);
                return this;
            }
            public UpdateRequest AttachedAddonQuantityInDecimal(int index, string attachedAddonQuantityInDecimal) 
            {
                m_params.AddOpt("attached_addons[quantity_in_decimal][" + index + "]", attachedAddonQuantityInDecimal);
                return this;
            }
            public UpdateRequest AttachedAddonBillingCycles(int index, int attachedAddonBillingCycles) 
            {
                m_params.AddOpt("attached_addons[billing_cycles][" + index + "]", attachedAddonBillingCycles);
                return this;
            }
            public UpdateRequest AttachedAddonType(int index, PlanAttachedAddon.TypeEnum attachedAddonType) 
            {
                m_params.AddOpt("attached_addons[type][" + index + "]", attachedAddonType);
                return this;
            }
        }
        public class PlanListRequest : ListRequestBase<PlanListRequest> 
        {
            public PlanListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<PlanListRequest> Id() 
            {
                return new StringFilter<PlanListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<PlanListRequest> Name() 
            {
                return new StringFilter<PlanListRequest>("name", this).SupportsMultiOperators(true);        
            }
            public NumberFilter<long, PlanListRequest> Price() 
            {
                return new NumberFilter<long, PlanListRequest>("price", this);        
            }
            public NumberFilter<int, PlanListRequest> Period() 
            {
                return new NumberFilter<int, PlanListRequest>("period", this);        
            }
            public EnumFilter<Plan.PeriodUnitEnum, PlanListRequest> PeriodUnit() 
            {
                return new EnumFilter<Plan.PeriodUnitEnum, PlanListRequest>("period_unit", this);        
            }
            public NumberFilter<int, PlanListRequest> TrialPeriod() 
            {
                return new NumberFilter<int, PlanListRequest>("trial_period", this).SupportsPresenceOperator(true);        
            }
            public EnumFilter<Plan.TrialPeriodUnitEnum, PlanListRequest> TrialPeriodUnit() 
            {
                return new EnumFilter<Plan.TrialPeriodUnitEnum, PlanListRequest>("trial_period_unit", this);        
            }
            public EnumFilter<Plan.AddonApplicabilityEnum, PlanListRequest> AddonApplicability() 
            {
                return new EnumFilter<Plan.AddonApplicabilityEnum, PlanListRequest>("addon_applicability", this);        
            }
            public BooleanFilter<PlanListRequest> Giftable() 
            {
                return new BooleanFilter<PlanListRequest>("giftable", this);        
            }
            [Obsolete]
            public EnumFilter<ChargeModelEnum, PlanListRequest> ChargeModel() 
            {
                return new EnumFilter<ChargeModelEnum, PlanListRequest>("charge_model", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, PlanListRequest> PricingModel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, PlanListRequest>("pricing_model", this);        
            }
            public EnumFilter<Plan.StatusEnum, PlanListRequest> Status() 
            {
                return new EnumFilter<Plan.StatusEnum, PlanListRequest>("status", this);        
            }
            public TimestampFilter<PlanListRequest> UpdatedAt() 
            {
                return new TimestampFilter<PlanListRequest>("updated_at", this);        
            }
            public StringFilter<PlanListRequest> CurrencyCode() 
            {
                return new StringFilter<PlanListRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, PlanListRequest> Channel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, PlanListRequest>("channel", this);        
            }
            public PlanListRequest IncludeDeleted(bool includeDeleted) 
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
        [Obsolete]
        public enum ChargeModelEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "flat_fee")]
            FlatFee,
            [EnumMember(Value = "per_unit")]
            PerUnit,
            [EnumMember(Value = "tiered")]
            Tiered,
            [EnumMember(Value = "volume")]
            Volume,
            [EnumMember(Value = "stairstep")]
            Stairstep,

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
        public enum AddonApplicabilityEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "all")]
            All,
            [EnumMember(Value = "restricted")]
            Restricted,

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

        #region Subclasses
        public class PlanTier : Resource
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
        public class PlanTaxProvidersField : Resource
        {

            public string ProviderName {
                get { return GetValue<string>("provider_name", true); }
            }

            public string FieldId {
                get { return GetValue<string>("field_id", true); }
            }

            public string FieldValue {
                get { return GetValue<string>("field_value", true); }
            }

        }
        public class PlanApplicableAddon : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

        }
        public class PlanAttachedAddon : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "recommended")]
                Recommended,
                [EnumMember(Value = "mandatory")]
                Mandatory,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public int Quantity {
                get { return GetValue<int>("quantity", true); }
            }

            public int? BillingCycles {
                get { return GetValue<int?>("billing_cycles", false); }
            }

            public TypeEnum AttachedAddonType {
                get { return GetEnum<TypeEnum>("type", true); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

        }
        public class PlanEventBasedAddon : Resource
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

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public int Quantity {
                get { return GetValue<int>("quantity", true); }
            }

            public OnEventEnum OnEvent {
                get { return GetEnum<OnEventEnum>("on_event", true); }
            }

            public bool ChargeOnce {
                get { return GetValue<bool>("charge_once", true); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

        }

        #endregion
    }
}
