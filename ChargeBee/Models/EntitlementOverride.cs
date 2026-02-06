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

    public class EntitlementOverride : Resource 
    {
    
        public EntitlementOverride() { }

        public EntitlementOverride(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public EntitlementOverride(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public EntitlementOverride(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static AddEntitlementOverrideForSubscriptionRequest AddEntitlementOverrideForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "entitlement_overrides");
            return new AddEntitlementOverrideForSubscriptionRequest(url, HttpMethod.POST);
        }
        public static EntitlementOverrideListEntitlementOverrideForSubscriptionRequest ListEntitlementOverrideForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "entitlement_overrides");
            return new EntitlementOverrideListEntitlementOverrideForSubscriptionRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", false); }
        }
        public string EntityType 
        {
            get { return GetValue<string>("entity_type", false); }
        }
        public string FeatureId 
        {
            get { return GetValue<string>("feature_id", false); }
        }
        public string FeatureName 
        {
            get { return GetValue<string>("feature_name", false); }
        }
        public string Value 
        {
            get { return GetValue<string>("value", false); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", false); }
        }
        public DateTime? ExpiresAt 
        {
            get { return GetDateTime("expires_at", false); }
        }
        public DateTime? EffectiveFrom 
        {
            get { return GetDateTime("effective_from", false); }
        }
        public bool IsEnabled 
        {
            get { return GetValue<bool>("is_enabled", true); }
        }
        [Obsolete]
        public ScheduleStatusEnum? ScheduleStatus 
        {
            get { return GetEnum<ScheduleStatusEnum>("schedule_status", false); }
        }
        
        #endregion
        
        #region Requests
        public class AddEntitlementOverrideForSubscriptionRequest : EntityRequest<AddEntitlementOverrideForSubscriptionRequest> 
        {
            public AddEntitlementOverrideForSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddEntitlementOverrideForSubscriptionRequest Action(ChargeBee.Models.Enums.ActionEnum action) 
            {
                m_params.AddOpt("action", action);
                return this;
            }
            public AddEntitlementOverrideForSubscriptionRequest EntitlementOverrideFeatureId(int index, string entitlementOverrideFeatureId) 
            {
                m_params.Add("entitlement_overrides[feature_id][" + index + "]", entitlementOverrideFeatureId);
                return this;
            }
            public AddEntitlementOverrideForSubscriptionRequest EntitlementOverrideEntityId(int index, string entitlementOverrideEntityId) 
            {
                m_params.AddOpt("entitlement_overrides[entity_id][" + index + "]", entitlementOverrideEntityId);
                return this;
            }
            public AddEntitlementOverrideForSubscriptionRequest EntitlementOverrideEntityType(int index, ChargeBee.Models.Enums.EntityTypeEnum entitlementOverrideEntityType) 
            {
                m_params.AddOpt("entitlement_overrides[entity_type][" + index + "]", entitlementOverrideEntityType);
                return this;
            }
            public AddEntitlementOverrideForSubscriptionRequest EntitlementOverrideValue(int index, string entitlementOverrideValue) 
            {
                m_params.AddOpt("entitlement_overrides[value][" + index + "]", entitlementOverrideValue);
                return this;
            }
            public AddEntitlementOverrideForSubscriptionRequest EntitlementOverrideExpiresAt(int index, long entitlementOverrideExpiresAt) 
            {
                m_params.AddOpt("entitlement_overrides[expires_at][" + index + "]", entitlementOverrideExpiresAt);
                return this;
            }
            public AddEntitlementOverrideForSubscriptionRequest EntitlementOverrideEffectiveFrom(int index, long entitlementOverrideEffectiveFrom) 
            {
                m_params.AddOpt("entitlement_overrides[effective_from][" + index + "]", entitlementOverrideEffectiveFrom);
                return this;
            }
            public AddEntitlementOverrideForSubscriptionRequest EntitlementOverrideIsEnabled(int index, bool entitlementOverrideIsEnabled) 
            {
                m_params.AddOpt("entitlement_overrides[is_enabled][" + index + "]", entitlementOverrideIsEnabled);
                return this;
            }
        }
        public class EntitlementOverrideListEntitlementOverrideForSubscriptionRequest : ListRequestBase<EntitlementOverrideListEntitlementOverrideForSubscriptionRequest> 
        {
            public EntitlementOverrideListEntitlementOverrideForSubscriptionRequest(string url) 
                    : base(url)
            {
            }

            [Obsolete]
            public EntitlementOverrideListEntitlementOverrideForSubscriptionRequest Embed(string embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
            [Obsolete]
            public EntitlementOverrideListEntitlementOverrideForSubscriptionRequest IncludeDrafts(bool includeDrafts) 
            {
                m_params.AddOpt("include_drafts", includeDrafts);
                return this;
            }
            [Obsolete]
            public EntitlementOverrideListEntitlementOverrideForSubscriptionRequest IncludeScheduledOverrides(bool includeScheduledOverrides) 
            {
                m_params.AddOpt("include_scheduled_overrides", includeScheduledOverrides);
                return this;
            }
        }
        #endregion

        [Obsolete]
        public enum ScheduleStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "activated")]
            Activated,
            [EnumMember(Value = "scheduled")]
            Scheduled,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses

        #endregion
    }
}
