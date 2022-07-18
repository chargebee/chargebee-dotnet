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

    public class SubscriptionEntitlement : Resource 
    {
    
        public SubscriptionEntitlement() { }

        public SubscriptionEntitlement(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public SubscriptionEntitlement(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public SubscriptionEntitlement(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static SubscriptionEntitlementSubscriptionEntitlementsForSubscriptionRequest SubscriptionEntitlementsForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "subscription_entitlements");
            return new SubscriptionEntitlementSubscriptionEntitlementsForSubscriptionRequest(url);
        }
        public static SetSubscriptionEntitlementAvailabilityRequest SetSubscriptionEntitlementAvailability(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "subscription_entitlements/set_availability");
            return new SetSubscriptionEntitlementAvailabilityRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string FeatureId 
        {
            get { return GetValue<string>("feature_id", false); }
        }
        public string FeatureName 
        {
            get { return GetValue<string>("feature_name", false); }
        }
        public string FeatureUnit 
        {
            get { return GetValue<string>("feature_unit", false); }
        }
        public string Value 
        {
            get { return GetValue<string>("value", false); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", false); }
        }
        public bool IsOverridden 
        {
            get { return GetValue<bool>("is_overridden", true); }
        }
        public bool IsEnabled 
        {
            get { return GetValue<bool>("is_enabled", true); }
        }
        public DateTime? ExpiresAt 
        {
            get { return GetDateTime("expires_at", false); }
        }
        public SubscriptionEntitlementComponent Components 
        {
            get { return GetSubResource<SubscriptionEntitlementComponent>("components"); }
        }
        
        #endregion
        
        #region Requests
        public class SubscriptionEntitlementSubscriptionEntitlementsForSubscriptionRequest : ListRequestBase<SubscriptionEntitlementSubscriptionEntitlementsForSubscriptionRequest> 
        {
            public SubscriptionEntitlementSubscriptionEntitlementsForSubscriptionRequest(string url) 
                    : base(url)
            {
            }

            [Obsolete]
            public SubscriptionEntitlementSubscriptionEntitlementsForSubscriptionRequest IncludeDrafts(bool includeDrafts) 
            {
                m_params.AddOpt("include_drafts", includeDrafts);
                return this;
            }
            [Obsolete]
            public SubscriptionEntitlementSubscriptionEntitlementsForSubscriptionRequest Embed(string embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
        }
        public class SetSubscriptionEntitlementAvailabilityRequest : EntityRequest<SetSubscriptionEntitlementAvailabilityRequest> 
        {
            public SetSubscriptionEntitlementAvailabilityRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public SetSubscriptionEntitlementAvailabilityRequest IsEnabled(bool isEnabled) 
            {
                m_params.Add("is_enabled", isEnabled);
                return this;
            }
            public SetSubscriptionEntitlementAvailabilityRequest SubscriptionEntitlementFeatureId(int index, string subscriptionEntitlementFeatureId) 
            {
                m_params.Add("subscription_entitlements[feature_id][" + index + "]", subscriptionEntitlementFeatureId);
                return this;
            }
        }
        #endregion


        #region Subclasses
        public class SubscriptionEntitlementComponent : Resource
        {

        }

        #endregion
    }
}
