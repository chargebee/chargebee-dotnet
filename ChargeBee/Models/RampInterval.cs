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

    public class RampInterval : Resource 
    {
    
        public RampInterval() { }

        public RampInterval(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public RampInterval(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public RampInterval(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public int StartingBillingCycle 
        {
            get { return GetValue<int>("starting_billing_cycle", true); }
        }
        public int? EndingBillingCycle 
        {
            get { return GetValue<int?>("ending_billing_cycle", false); }
        }
        public bool? ApplyCatalogPrice 
        {
            get { return GetValue<bool?>("apply_catalog_price", false); }
        }
        public long? Price 
        {
            get { return GetValue<long?>("price", false); }
        }
        public string PriceInDecimal 
        {
            get { return GetValue<string>("price_in_decimal", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
