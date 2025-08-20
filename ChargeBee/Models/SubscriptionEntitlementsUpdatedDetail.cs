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

    public class SubscriptionEntitlementsUpdatedDetail : Resource 
    {
    
        public SubscriptionEntitlementsUpdatedDetail() { }

        public SubscriptionEntitlementsUpdatedDetail(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public SubscriptionEntitlementsUpdatedDetail(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public SubscriptionEntitlementsUpdatedDetail(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public bool HasNext 
        {
            get { return GetValue<bool>("has_next", true); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
