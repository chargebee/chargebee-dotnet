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

    public class BillingMetadata : Resource 
    {
    
        public BillingMetadata() { }

        public BillingMetadata(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public BillingMetadata(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public BillingMetadata(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string ItemPriceId 
        {
            get { return GetValue<string>("item_price_id", false); }
        }
        public List<BillingLineItem> LineItems 
        {
            get { return GetResourceList<BillingLineItem>("line_items"); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
