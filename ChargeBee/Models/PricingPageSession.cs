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

    public class PricingPageSession : Resource 
    {
    
        public PricingPageSession() { }

        public PricingPageSession(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PricingPageSession(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PricingPageSession(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateForNewSubscriptionRequest CreateForNewSubscription()
        {
            string url = ApiUtil.BuildUrl("pricing_page_sessions", "create_for_new_subscription");
            return new CreateForNewSubscriptionRequest(url, HttpMethod.POST);
        }
        public static CreateForExistingSubscriptionRequest CreateForExistingSubscription()
        {
            string url = ApiUtil.BuildUrl("pricing_page_sessions", "create_for_existing_subscription");
            return new CreateForExistingSubscriptionRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public string Url 
        {
            get { return GetValue<string>("url", false); }
        }
        public DateTime? CreatedAt 
        {
            get { return GetDateTime("created_at", false); }
        }
        public DateTime? ExpiresAt 
        {
            get { return GetDateTime("expires_at", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateForNewSubscriptionRequest : EntityRequest<CreateForNewSubscriptionRequest> 
        {
            public CreateForNewSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForNewSubscriptionRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CreateForNewSubscriptionRequest BusinessEntityId(string businessEntityId) 
            {
                m_params.AddOpt("business_entity_id", businessEntityId);
                return this;
            }
            public CreateForNewSubscriptionRequest PricingPageId(string pricingPageId) 
            {
                m_params.Add("pricing_page[id]", pricingPageId);
                return this;
            }
            public CreateForNewSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateForNewSubscriptionRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public CreateForNewSubscriptionRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public CreateForNewSubscriptionRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public CreateForNewSubscriptionRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public CreateForNewSubscriptionRequest CustomerCompany(string customerCompany) 
            {
                m_params.AddOpt("customer[company]", customerCompany);
                return this;
            }
            public CreateForNewSubscriptionRequest CustomerPhone(string customerPhone) 
            {
                m_params.AddOpt("customer[phone]", customerPhone);
                return this;
            }
            public CreateForNewSubscriptionRequest CustomerLocale(string customerLocale) 
            {
                m_params.AddOpt("customer[locale]", customerLocale);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CreateForNewSubscriptionRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateForNewSubscriptionRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.AddOpt("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CreateForNewSubscriptionRequest DiscountLabel(int index, string discountLabel) 
            {
                m_params.AddOpt("discounts[label][" + index + "]", discountLabel);
                return this;
            }
        }
        public class CreateForExistingSubscriptionRequest : EntityRequest<CreateForExistingSubscriptionRequest> 
        {
            public CreateForExistingSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForExistingSubscriptionRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CreateForExistingSubscriptionRequest PricingPageId(string pricingPageId) 
            {
                m_params.Add("pricing_page[id]", pricingPageId);
                return this;
            }
            public CreateForExistingSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.AddOpt("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountDurationType(int index, ChargeBee.Models.Enums.DurationTypeEnum discountDurationType) 
            {
                m_params.Add("discounts[duration_type][" + index + "]", discountDurationType);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountPeriod(int index, int discountPeriod) 
            {
                m_params.AddOpt("discounts[period][" + index + "]", discountPeriod);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountPeriodUnit(int index, ChargeBee.Models.Enums.PeriodUnitEnum discountPeriodUnit) 
            {
                m_params.AddOpt("discounts[period_unit][" + index + "]", discountPeriodUnit);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountIncludedInMrr(int index, bool discountIncludedInMrr) 
            {
                m_params.AddOpt("discounts[included_in_mrr][" + index + "]", discountIncludedInMrr);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
            public CreateForExistingSubscriptionRequest DiscountLabel(int index, string discountLabel) 
            {
                m_params.AddOpt("discounts[label][" + index + "]", discountLabel);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
