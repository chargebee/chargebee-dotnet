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

    public class ItemEntitlement : Resource 
    {
    
        public ItemEntitlement() { }

        public ItemEntitlement(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public ItemEntitlement(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public ItemEntitlement(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static ItemEntitlementItemEntitlementsForItemRequest ItemEntitlementsForItem(string id)
        {
            string url = ApiUtil.BuildUrl("items", CheckNull(id), "item_entitlements");
            return new ItemEntitlementItemEntitlementsForItemRequest(url);
        }
        public static ItemEntitlementItemEntitlementsForFeatureRequest ItemEntitlementsForFeature(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id), "item_entitlements");
            return new ItemEntitlementItemEntitlementsForFeatureRequest(url);
        }
        public static AddItemEntitlementsRequest AddItemEntitlements(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id), "item_entitlements");
            return new AddItemEntitlementsRequest(url, HttpMethod.POST);
        }
        public static UpsertOrRemoveItemEntitlementsForItemRequest UpsertOrRemoveItemEntitlementsForItem(string id)
        {
            string url = ApiUtil.BuildUrl("items", CheckNull(id), "item_entitlements");
            return new UpsertOrRemoveItemEntitlementsForItemRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string ItemId 
        {
            get { return GetValue<string>("item_id", false); }
        }
        public ItemTypeEnum? ItemType 
        {
            get { return GetEnum<ItemTypeEnum>("item_type", false); }
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
        [Obsolete]
        public ItemEntitlementEmbeddedResource Embedded 
        {
            get { return GetSubResource<ItemEntitlementEmbeddedResource>("embedded"); }
        }
        
        #endregion
        
        #region Requests
        public class ItemEntitlementItemEntitlementsForItemRequest : ListRequestBase<ItemEntitlementItemEntitlementsForItemRequest> 
        {
            public ItemEntitlementItemEntitlementsForItemRequest(string url) 
                    : base(url)
            {
            }

            [Obsolete]
            public ItemEntitlementItemEntitlementsForItemRequest IncludeDrafts(bool includeDrafts) 
            {
                m_params.AddOpt("include_drafts", includeDrafts);
                return this;
            }
            [Obsolete]
            public ItemEntitlementItemEntitlementsForItemRequest Embed(string embed) 
            {
                m_params.AddOpt("embed", embed);
                return this;
            }
        }
        public class ItemEntitlementItemEntitlementsForFeatureRequest : ListRequestBase<ItemEntitlementItemEntitlementsForFeatureRequest> 
        {
            public ItemEntitlementItemEntitlementsForFeatureRequest(string url) 
                    : base(url)
            {
            }

            [Obsolete]
            public ItemEntitlementItemEntitlementsForFeatureRequest IncludeDrafts(bool includeDrafts) 
            {
                m_params.AddOpt("include_drafts", includeDrafts);
                return this;
            }
        }
        public class AddItemEntitlementsRequest : EntityRequest<AddItemEntitlementsRequest> 
        {
            public AddItemEntitlementsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddItemEntitlementsRequest Action(ChargeBee.Models.Enums.ActionEnum action) 
            {
                m_params.Add("action", action);
                return this;
            }
            public AddItemEntitlementsRequest ItemEntitlementItemId(int index, string itemEntitlementItemId) 
            {
                m_params.Add("item_entitlements[item_id][" + index + "]", itemEntitlementItemId);
                return this;
            }
            public AddItemEntitlementsRequest ItemEntitlementItemType(int index, ItemEntitlement.ItemTypeEnum itemEntitlementItemType) 
            {
                m_params.AddOpt("item_entitlements[item_type][" + index + "]", itemEntitlementItemType);
                return this;
            }
            public AddItemEntitlementsRequest ItemEntitlementValue(int index, string itemEntitlementValue) 
            {
                m_params.AddOpt("item_entitlements[value][" + index + "]", itemEntitlementValue);
                return this;
            }
        }
        public class UpsertOrRemoveItemEntitlementsForItemRequest : EntityRequest<UpsertOrRemoveItemEntitlementsForItemRequest> 
        {
            public UpsertOrRemoveItemEntitlementsForItemRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpsertOrRemoveItemEntitlementsForItemRequest Action(ChargeBee.Models.Enums.ActionEnum action) 
            {
                m_params.Add("action", action);
                return this;
            }
            public UpsertOrRemoveItemEntitlementsForItemRequest ItemEntitlementFeatureId(int index, string itemEntitlementFeatureId) 
            {
                m_params.Add("item_entitlements[feature_id][" + index + "]", itemEntitlementFeatureId);
                return this;
            }
            public UpsertOrRemoveItemEntitlementsForItemRequest ItemEntitlementValue(int index, string itemEntitlementValue) 
            {
                m_params.AddOpt("item_entitlements[value][" + index + "]", itemEntitlementValue);
                return this;
            }
        }
        #endregion

        public enum ItemTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "plan")]
            Plan,
            [EnumMember(Value = "addon")]
            Addon,
            [EnumMember(Value = "charge")]
            Charge,
            [EnumMember(Value = "subscription")]
            Subscription,
            [EnumMember(Value = "item")]
            Item,

        }

        #region Subclasses
        public class ItemEntitlementEmbeddedResource : Resource
        {

        }

        #endregion
    }
}
