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

    public class QuoteEntitlement : Resource 
    {
    
        public QuoteEntitlement() { }

        public QuoteEntitlement(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public QuoteEntitlement(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public QuoteEntitlement(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static QuoteEntitlementListQuoteEntitlementsRequest ListQuoteEntitlements(string id)
        {
            string url = ApiUtil.BuildUrl("quotes", CheckNull(id), "quote_entitlements");
            var request = new QuoteEntitlementListQuoteEntitlementsRequest(url);
            request.SetTelemetryResource("quoteEntitlement");
            request.SetTelemetryOperation("listQuoteEntitlements");
            return request;
        }
        #endregion
        
        #region Properties
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", true); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        [Obsolete]
        public ActionTypeEnum ActionType 
        {
            get { return GetEnum<ActionTypeEnum>("action_type", true); }
        }
        public string FeatureId 
        {
            get { return GetValue<string>("feature_id", true); }
        }
        public string Value 
        {
            get { return GetValue<string>("value", false); }
        }
        public bool IsEnabled 
        {
            get { return GetValue<bool>("is_enabled", true); }
        }
        public DateTime? StartDate 
        {
            get { return GetDateTime("start_date", false); }
        }
        public DateTime? EndDate 
        {
            get { return GetDateTime("end_date", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        public bool? IsOverridden 
        {
            get { return GetValue<bool?>("is_overridden", false); }
        }
        public string FeatureName 
        {
            get { return GetValue<string>("feature_name", false); }
        }
        public string FeatureUnit 
        {
            get { return GetValue<string>("feature_unit", false); }
        }
        public string FeatureType 
        {
            get { return GetValue<string>("feature_type", false); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", false); }
        }
        public bool? Metered 
        {
            get { return GetValue<bool?>("metered", false); }
        }
        
        #endregion
        
        #region Requests
        public class QuoteEntitlementListQuoteEntitlementsRequest : ListRequestBase<QuoteEntitlementListQuoteEntitlementsRequest> 
        {
            public QuoteEntitlementListQuoteEntitlementsRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<QuoteEntitlementListQuoteEntitlementsRequest> EntityId() 
            {
                return new StringFilter<QuoteEntitlementListQuoteEntitlementsRequest>("entity_id", this);        
            }
            public TimestampFilter<QuoteEntitlementListQuoteEntitlementsRequest> StartDate() 
            {
                return new TimestampFilter<QuoteEntitlementListQuoteEntitlementsRequest>("start_date", this);        
            }
            public TimestampFilter<QuoteEntitlementListQuoteEntitlementsRequest> EndDate() 
            {
                return new TimestampFilter<QuoteEntitlementListQuoteEntitlementsRequest>("end_date", this);        
            }
        }
        #endregion

        public enum EntityTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "plan_price")]
            PlanPrice,
            [EnumMember(Value = "addon_price")]
            AddonPrice,
            [EnumMember(Value = "charge_price")]
            ChargePrice,
            [EnumMember(Value = "charge")]
            [Obsolete]
            Charge,

        }
        [Obsolete]
        public enum ActionTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "upsert")]
            Upsert,
            [EnumMember(Value = "remove")]
            Remove,

        }

        #region Subclasses

        #endregion
    }
}
