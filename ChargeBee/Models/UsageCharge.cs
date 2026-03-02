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

    public class UsageCharge : Resource 
    {
    
        public UsageCharge() { }

        public UsageCharge(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public UsageCharge(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public UsageCharge(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        [Obsolete]
        public static UsageChargeRetrieveUsageChargesForSubscriptionRequest RetrieveUsageChargesForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "usage_charges");
            return new UsageChargeRetrieveUsageChargesForSubscriptionRequest(url);
        }
        #endregion
        
        #region Properties
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string FeatureId 
        {
            get { return GetValue<string>("feature_id", true); }
        }
        public string IncludedUsage 
        {
            get { return GetValue<string>("included_usage", false); }
        }
        public string TotalUsage 
        {
            get { return GetValue<string>("total_usage", false); }
        }
        public string OnDemandUsage 
        {
            get { return GetValue<string>("on_demand_usage", false); }
        }
        public string MeteredItemPriceId 
        {
            get { return GetValue<string>("metered_item_price_id", false); }
        }
        public string Amount 
        {
            get { return GetValue<string>("amount", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public DateTime UsageFrom 
        {
            get { return (DateTime)GetDateTime("usage_from", true); }
        }
        public DateTime UsageTo 
        {
            get { return (DateTime)GetDateTime("usage_to", true); }
        }
        
        #endregion
        
        #region Requests
        public class UsageChargeRetrieveUsageChargesForSubscriptionRequest : ListRequestBase<UsageChargeRetrieveUsageChargesForSubscriptionRequest> 
        {
            public UsageChargeRetrieveUsageChargesForSubscriptionRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<UsageChargeRetrieveUsageChargesForSubscriptionRequest> FeatureId() 
            {
                return new StringFilter<UsageChargeRetrieveUsageChargesForSubscriptionRequest>("feature_id", this);        
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
