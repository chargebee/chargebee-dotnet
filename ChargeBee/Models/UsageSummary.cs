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

    public class UsageSummary : Resource 
    {
    
        public UsageSummary() { }

        public UsageSummary(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public UsageSummary(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public UsageSummary(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static UsageSummaryRetrieveUsageSummaryForSubscriptionRequest RetrieveUsageSummaryForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "usage_summary");
            return new UsageSummaryRetrieveUsageSummaryForSubscriptionRequest(url);
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
        public string AggregatedValue 
        {
            get { return GetValue<string>("aggregated_value", true); }
        }
        public DateTime AggregatedFrom 
        {
            get { return (DateTime)GetDateTime("aggregated_from", true); }
        }
        public DateTime AggregatedTo 
        {
            get { return (DateTime)GetDateTime("aggregated_to", true); }
        }
        
        #endregion
        
        #region Requests
        public class UsageSummaryRetrieveUsageSummaryForSubscriptionRequest : ListRequestBase<UsageSummaryRetrieveUsageSummaryForSubscriptionRequest> 
        {
            public UsageSummaryRetrieveUsageSummaryForSubscriptionRequest(string url) 
                    : base(url)
            {
            }

            public UsageSummaryRetrieveUsageSummaryForSubscriptionRequest FeatureId(string featureId) 
            {
                m_params.Add("feature_id", featureId);
                return this;
            }
            public UsageSummaryRetrieveUsageSummaryForSubscriptionRequest WindowSize(ChargeBee.Models.Enums.WindowSizeEnum windowSize) 
            {
                m_params.AddOpt("window_size", windowSize);
                return this;
            }
            public UsageSummaryRetrieveUsageSummaryForSubscriptionRequest TimeframeStart(long timeframeStart) 
            {
                m_params.AddOpt("timeframe_start", timeframeStart);
                return this;
            }
            public UsageSummaryRetrieveUsageSummaryForSubscriptionRequest TimeframeEnd(long timeframeEnd) 
            {
                m_params.AddOpt("timeframe_end", timeframeEnd);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
