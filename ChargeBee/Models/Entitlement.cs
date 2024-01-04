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

    public class Entitlement : Resource 
    {
    
        public Entitlement() { }

        public Entitlement(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Entitlement(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Entitlement(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntitlementListRequest List()
        {
            string url = ApiUtil.BuildUrl("entitlements");
            return new EntitlementListRequest(url);
        }
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("entitlements");
            return new CreateRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", false); }
        }
        public EntityTypeEnum? EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", false); }
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
        
        #endregion
        
        #region Requests
        public class EntitlementListRequest : ListRequestBase<EntitlementListRequest> 
        {
            public EntitlementListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<EntitlementListRequest> FeatureId() 
            {
                return new StringFilter<EntitlementListRequest>("feature_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Entitlement.EntityTypeEnum, EntitlementListRequest> EntityType() 
            {
                return new EnumFilter<Entitlement.EntityTypeEnum, EntitlementListRequest>("entity_type", this).SupportsMultiOperators(true);        
            }
            public StringFilter<EntitlementListRequest> EntityId() 
            {
                return new StringFilter<EntitlementListRequest>("entity_id", this).SupportsMultiOperators(true);        
            }
            [Obsolete]
            public EntitlementListRequest IncludeDrafts(bool includeDrafts) 
            {
                m_params.AddOpt("include_drafts", includeDrafts);
                return this;
            }
            [Obsolete]
            public EntitlementListRequest Embed(string embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
        }
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Action(ChargeBee.Models.Enums.ActionEnum action) 
            {
                m_params.Add("action", action);
                return this;
            }
            public CreateRequest EntitlementEntityId(int index, string entitlementEntityId) 
            {
                m_params.Add("entitlements[entity_id][" + index + "]", entitlementEntityId);
                return this;
            }
            public CreateRequest EntitlementFeatureId(int index, string entitlementFeatureId) 
            {
                m_params.Add("entitlements[feature_id][" + index + "]", entitlementFeatureId);
                return this;
            }
            public CreateRequest EntitlementEntityType(int index, Entitlement.EntityTypeEnum entitlementEntityType) 
            {
                m_params.AddOpt("entitlements[entity_type][" + index + "]", entitlementEntityType);
                return this;
            }
            public CreateRequest EntitlementValue(int index, string entitlementValue) 
            {
                m_params.AddOpt("entitlements[value][" + index + "]", entitlementValue);
                return this;
            }
        }
        #endregion

        public enum EntityTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "plan")]
            Plan,
            [EnumMember(Value = "addon")]
            Addon,
            [EnumMember(Value = "charge")]
            Charge,
            [EnumMember(Value = "plan_price")]
            PlanPrice,
            [EnumMember(Value = "addon_price")]
            AddonPrice,

        }

        #region Subclasses

        #endregion
    }
}
