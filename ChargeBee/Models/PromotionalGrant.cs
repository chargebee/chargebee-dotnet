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

    public class PromotionalGrant : Resource 
    {
    
        public PromotionalGrant() { }

        public PromotionalGrant(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PromotionalGrant(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PromotionalGrant(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static PromotionalGrantsRequest PromotionalGrants()
        {
            string url = ApiUtil.BuildUrl("promotional_grants");
            return new PromotionalGrantsRequest(url, HttpMethod.POST).IsJsonRequest(true);
        }
        #endregion
        
        #region Properties
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string UnitId 
        {
            get { return GetValue<string>("unit_id", true); }
        }
        public string Amount 
        {
            get { return GetValue<string>("amount", true); }
        }
        public DateTime ExpiresAt 
        {
            get { return (DateTime)GetDateTime("expires_at", true); }
        }
        public string Metadata 
        {
            get { return GetValue<string>("metadata", false); }
        }
        
        #endregion
        
        #region Requests
        public class PromotionalGrantsRequest : EntityRequest<PromotionalGrantsRequest> 
        {
            public PromotionalGrantsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PromotionalGrantsRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public PromotionalGrantsRequest UnitId(string unitId) 
            {
                m_params.Add("unit_id", unitId);
                return this;
            }
            public PromotionalGrantsRequest Amount(string amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public PromotionalGrantsRequest ExpiresAt(long expiresAt) 
            {
                m_params.Add("expires_at", expiresAt);
                return this;
            }
            public PromotionalGrantsRequest Metadata(Dictionary<String, Object> metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
        
        }
        #endregion


        #region Subclasses

        
        #endregion
    }
}
