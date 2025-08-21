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

    public class CustomerEntitlement : Resource 
    {
    
        public CustomerEntitlement() { }

        public CustomerEntitlement(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CustomerEntitlement(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CustomerEntitlement(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CustomerEntitlementEntitlementsForCustomerRequest EntitlementsForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "customer_entitlements");
            return new CustomerEntitlementEntitlementsForCustomerRequest(url);
        }
        #endregion
        
        #region Properties
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string FeatureId 
        {
            get { return GetValue<string>("feature_id", false); }
        }
        public string Value 
        {
            get { return GetValue<string>("value", false); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", false); }
        }
        public bool IsEnabled 
        {
            get { return GetValue<bool>("is_enabled", true); }
        }
        
        #endregion
        
        #region Requests
        public class CustomerEntitlementEntitlementsForCustomerRequest : ListRequestBase<CustomerEntitlementEntitlementsForCustomerRequest> 
        {
            public CustomerEntitlementEntitlementsForCustomerRequest(string url) 
                    : base(url)
            {
            }

            public CustomerEntitlementEntitlementsForCustomerRequest ConsolidateEntitlements(bool consolidateEntitlements) 
            {
                m_params.AddOpt("consolidate_entitlements", consolidateEntitlements);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
