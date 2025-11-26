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

    public class QuotedDeltaRamp : Resource 
    {
    
        public QuotedDeltaRamp() { }

        public QuotedDeltaRamp(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public QuotedDeltaRamp(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public QuotedDeltaRamp(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public List<QuotedDeltaRampLineItem> LineItems 
        {
            get { return GetResourceList<QuotedDeltaRampLineItem>("line_items"); }
        }
        
        #endregion
        


        #region Subclasses
        public class QuotedDeltaRampLineItem : Resource
        {

            public string ItemLevelDiscountPerBillingCycleInDecimal {
                get { return GetValue<string>("item_level_discount_per_billing_cycle_in_decimal", false); }
            }

        }

        #endregion
    }
}
