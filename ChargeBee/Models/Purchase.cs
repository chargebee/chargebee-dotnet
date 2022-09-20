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

    public class Purchase : Resource 
    {
    
        public Purchase() { }

        public Purchase(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Purchase(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Purchase(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("purchases");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EstimateRequest Estimate()
        {
            string url = ApiUtil.BuildUrl("purchases", "estimate");
            return new EstimateRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public DateTime? CreatedAt 
        {
            get { return GetDateTime("created_at", false); }
        }
        public DateTime? ModifiedAt 
        {
            get { return GetDateTime("modified_at", false); }
        }
        public List<string> SubscriptionIds 
        {
            get { return GetList<string>("subscription_ids"); }
        }
        public List<string> InvoiceIds 
        {
            get { return GetList<string>("invoice_ids"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateRequest InvoiceInfoPoNumber(string invoiceInfoPoNumber) 
            {
                m_params.AddOpt("invoice_info[po_number]", invoiceInfoPoNumber);
                return this;
            }
            public CreateRequest InvoiceInfoNotes(string invoiceInfoNotes) 
            {
                m_params.AddOpt("invoice_info[notes]", invoiceInfoNotes);
                return this;
            }
            public CreateRequest PurchaseItemIndex(int index, int purchaseItemIndex) 
            {
                m_params.Add("purchase_items[index][" + index + "]", purchaseItemIndex);
                return this;
            }
            public CreateRequest PurchaseItemItemPriceId(int index, string purchaseItemItemPriceId) 
            {
                m_params.Add("purchase_items[item_price_id][" + index + "]", purchaseItemItemPriceId);
                return this;
            }
            public CreateRequest PurchaseItemQuantity(int index, int purchaseItemQuantity) 
            {
                m_params.AddOpt("purchase_items[quantity][" + index + "]", purchaseItemQuantity);
                return this;
            }
            public CreateRequest PurchaseItemUnitAmount(int index, int purchaseItemUnitAmount) 
            {
                m_params.AddOpt("purchase_items[unit_amount][" + index + "]", purchaseItemUnitAmount);
                return this;
            }
            public CreateRequest PurchaseItemUnitAmountInDecimal(int index, string purchaseItemUnitAmountInDecimal) 
            {
                m_params.AddOpt("purchase_items[unit_amount_in_decimal][" + index + "]", purchaseItemUnitAmountInDecimal);
                return this;
            }
            public CreateRequest PurchaseItemQuantityInDecimal(int index, string purchaseItemQuantityInDecimal) 
            {
                m_params.AddOpt("purchase_items[quantity_in_decimal][" + index + "]", purchaseItemQuantityInDecimal);
                return this;
            }
            public CreateRequest ItemTierIndex(int index, int itemTierIndex) 
            {
                m_params.Add("item_tiers[index][" + index + "]", itemTierIndex);
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
            public CreateRequest ItemTierPrice(int index, int itemTierPrice) 
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
            public CreateRequest ShippingAddressFirstName(int index, string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_addresses[first_name][" + index + "]", shippingAddressFirstName);
                return this;
            }
            public CreateRequest ShippingAddressLastName(int index, string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_addresses[last_name][" + index + "]", shippingAddressLastName);
                return this;
            }
            public CreateRequest ShippingAddressEmail(int index, string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_addresses[email][" + index + "]", shippingAddressEmail);
                return this;
            }
            public CreateRequest ShippingAddressCompany(int index, string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_addresses[company][" + index + "]", shippingAddressCompany);
                return this;
            }
            public CreateRequest ShippingAddressPhone(int index, string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_addresses[phone][" + index + "]", shippingAddressPhone);
                return this;
            }
            public CreateRequest ShippingAddressLine1(int index, string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_addresses[line1][" + index + "]", shippingAddressLine1);
                return this;
            }
            public CreateRequest ShippingAddressLine2(int index, string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_addresses[line2][" + index + "]", shippingAddressLine2);
                return this;
            }
            public CreateRequest ShippingAddressLine3(int index, string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_addresses[line3][" + index + "]", shippingAddressLine3);
                return this;
            }
            public CreateRequest ShippingAddressCity(int index, string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_addresses[city][" + index + "]", shippingAddressCity);
                return this;
            }
            public CreateRequest ShippingAddressState(int index, string shippingAddressState) 
            {
                m_params.AddOpt("shipping_addresses[state][" + index + "]", shippingAddressState);
                return this;
            }
            public CreateRequest ShippingAddressStateCode(int index, string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_addresses[state_code][" + index + "]", shippingAddressStateCode);
                return this;
            }
            public CreateRequest ShippingAddressCountry(int index, string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_addresses[country][" + index + "]", shippingAddressCountry);
                return this;
            }
            public CreateRequest ShippingAddressZip(int index, string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_addresses[zip][" + index + "]", shippingAddressZip);
                return this;
            }
            public CreateRequest ShippingAddressValidationStatus(int index, ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_addresses[validation_status][" + index + "]", shippingAddressValidationStatus);
                return this;
            }
            public CreateRequest DiscountIndex(int index, int discountIndex) 
            {
                m_params.AddOpt("discounts[index][" + index + "]", discountIndex);
                return this;
            }
            public CreateRequest DiscountCouponId(int index, string discountCouponId) 
            {
                m_params.AddOpt("discounts[coupon_id][" + index + "]", discountCouponId);
                return this;
            }
            public CreateRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateRequest DiscountAmount(int index, int discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CreateRequest SubscriptionInfoIndex(int index, int subscriptionInfoIndex) 
            {
                m_params.Add("subscription_info[index][" + index + "]", subscriptionInfoIndex);
                return this;
            }
            public CreateRequest SubscriptionInfoSubscriptionId(int index, string subscriptionInfoSubscriptionId) 
            {
                m_params.AddOpt("subscription_info[subscription_id][" + index + "]", subscriptionInfoSubscriptionId);
                return this;
            }
            public CreateRequest SubscriptionInfoBillingCycles(int index, int subscriptionInfoBillingCycles) 
            {
                m_params.AddOpt("subscription_info[billing_cycles][" + index + "]", subscriptionInfoBillingCycles);
                return this;
            }
        }
        public class EstimateRequest : EntityRequest<EstimateRequest> 
        {
            public EstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EstimateRequest ClientProfileId(string clientProfileId) 
            {
                m_params.AddOpt("client_profile_id", clientProfileId);
                return this;
            }
            public EstimateRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public EstimateRequest InvoiceInfoPoNumber(string invoiceInfoPoNumber) 
            {
                m_params.AddOpt("invoice_info[po_number]", invoiceInfoPoNumber);
                return this;
            }
            public EstimateRequest InvoiceInfoNotes(string invoiceInfoNotes) 
            {
                m_params.AddOpt("invoice_info[notes]", invoiceInfoNotes);
                return this;
            }
            public EstimateRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public EstimateRequest CustomerVatNumberPrefix(string customerVatNumberPrefix) 
            {
                m_params.AddOpt("customer[vat_number_prefix]", customerVatNumberPrefix);
                return this;
            }
            public EstimateRequest CustomerRegisteredForGst(bool customerRegisteredForGst) 
            {
                m_params.AddOpt("customer[registered_for_gst]", customerRegisteredForGst);
                return this;
            }
            public EstimateRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public EstimateRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public EstimateRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public EstimateRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public EstimateRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public EstimateRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public EstimateRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public EstimateRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public EstimateRequest CustomerTaxability(ChargeBee.Models.Enums.TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public EstimateRequest CustomerEntityCode(ChargeBee.Models.Enums.EntityCodeEnum customerEntityCode) 
            {
                m_params.AddOpt("customer[entity_code]", customerEntityCode);
                return this;
            }
            public EstimateRequest CustomerExemptNumber(string customerExemptNumber) 
            {
                m_params.AddOpt("customer[exempt_number]", customerExemptNumber);
                return this;
            }
            public EstimateRequest CustomerExemptionDetails(JArray customerExemptionDetails) 
            {
                m_params.AddOpt("customer[exemption_details]", customerExemptionDetails);
                return this;
            }
            public EstimateRequest CustomerCustomerType(ChargeBee.Models.Enums.CustomerTypeEnum customerCustomerType) 
            {
                m_params.AddOpt("customer[customer_type]", customerCustomerType);
                return this;
            }
            public EstimateRequest PurchaseItemIndex(int index, int purchaseItemIndex) 
            {
                m_params.Add("purchase_items[index][" + index + "]", purchaseItemIndex);
                return this;
            }
            public EstimateRequest PurchaseItemItemPriceId(int index, string purchaseItemItemPriceId) 
            {
                m_params.Add("purchase_items[item_price_id][" + index + "]", purchaseItemItemPriceId);
                return this;
            }
            public EstimateRequest PurchaseItemQuantity(int index, int purchaseItemQuantity) 
            {
                m_params.AddOpt("purchase_items[quantity][" + index + "]", purchaseItemQuantity);
                return this;
            }
            public EstimateRequest PurchaseItemUnitAmount(int index, int purchaseItemUnitAmount) 
            {
                m_params.AddOpt("purchase_items[unit_amount][" + index + "]", purchaseItemUnitAmount);
                return this;
            }
            public EstimateRequest PurchaseItemUnitAmountInDecimal(int index, string purchaseItemUnitAmountInDecimal) 
            {
                m_params.AddOpt("purchase_items[unit_amount_in_decimal][" + index + "]", purchaseItemUnitAmountInDecimal);
                return this;
            }
            public EstimateRequest PurchaseItemQuantityInDecimal(int index, string purchaseItemQuantityInDecimal) 
            {
                m_params.AddOpt("purchase_items[quantity_in_decimal][" + index + "]", purchaseItemQuantityInDecimal);
                return this;
            }
            public EstimateRequest ItemTierIndex(int index, int itemTierIndex) 
            {
                m_params.Add("item_tiers[index][" + index + "]", itemTierIndex);
                return this;
            }
            public EstimateRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public EstimateRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public EstimateRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public EstimateRequest ItemTierPrice(int index, int itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public EstimateRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public EstimateRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public EstimateRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public EstimateRequest ShippingAddressFirstName(int index, string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_addresses[first_name][" + index + "]", shippingAddressFirstName);
                return this;
            }
            public EstimateRequest ShippingAddressLastName(int index, string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_addresses[last_name][" + index + "]", shippingAddressLastName);
                return this;
            }
            public EstimateRequest ShippingAddressEmail(int index, string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_addresses[email][" + index + "]", shippingAddressEmail);
                return this;
            }
            public EstimateRequest ShippingAddressCompany(int index, string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_addresses[company][" + index + "]", shippingAddressCompany);
                return this;
            }
            public EstimateRequest ShippingAddressPhone(int index, string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_addresses[phone][" + index + "]", shippingAddressPhone);
                return this;
            }
            public EstimateRequest ShippingAddressLine1(int index, string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_addresses[line1][" + index + "]", shippingAddressLine1);
                return this;
            }
            public EstimateRequest ShippingAddressLine2(int index, string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_addresses[line2][" + index + "]", shippingAddressLine2);
                return this;
            }
            public EstimateRequest ShippingAddressLine3(int index, string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_addresses[line3][" + index + "]", shippingAddressLine3);
                return this;
            }
            public EstimateRequest ShippingAddressCity(int index, string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_addresses[city][" + index + "]", shippingAddressCity);
                return this;
            }
            public EstimateRequest ShippingAddressState(int index, string shippingAddressState) 
            {
                m_params.AddOpt("shipping_addresses[state][" + index + "]", shippingAddressState);
                return this;
            }
            public EstimateRequest ShippingAddressStateCode(int index, string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_addresses[state_code][" + index + "]", shippingAddressStateCode);
                return this;
            }
            public EstimateRequest ShippingAddressCountry(int index, string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_addresses[country][" + index + "]", shippingAddressCountry);
                return this;
            }
            public EstimateRequest ShippingAddressZip(int index, string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_addresses[zip][" + index + "]", shippingAddressZip);
                return this;
            }
            public EstimateRequest ShippingAddressValidationStatus(int index, ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_addresses[validation_status][" + index + "]", shippingAddressValidationStatus);
                return this;
            }
            public EstimateRequest DiscountIndex(int index, int discountIndex) 
            {
                m_params.AddOpt("discounts[index][" + index + "]", discountIndex);
                return this;
            }
            public EstimateRequest DiscountCouponId(int index, string discountCouponId) 
            {
                m_params.AddOpt("discounts[coupon_id][" + index + "]", discountCouponId);
                return this;
            }
            public EstimateRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public EstimateRequest DiscountAmount(int index, int discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public EstimateRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public EstimateRequest SubscriptionInfoIndex(int index, int subscriptionInfoIndex) 
            {
                m_params.Add("subscription_info[index][" + index + "]", subscriptionInfoIndex);
                return this;
            }
            public EstimateRequest SubscriptionInfoSubscriptionId(int index, string subscriptionInfoSubscriptionId) 
            {
                m_params.AddOpt("subscription_info[subscription_id][" + index + "]", subscriptionInfoSubscriptionId);
                return this;
            }
            public EstimateRequest SubscriptionInfoBillingCycles(int index, int subscriptionInfoBillingCycles) 
            {
                m_params.AddOpt("subscription_info[billing_cycles][" + index + "]", subscriptionInfoBillingCycles);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
