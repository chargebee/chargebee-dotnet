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

    public class BillingLineItem : Resource 
    {
    
        public BillingLineItem() { }

        public BillingLineItem(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public BillingLineItem(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public BillingLineItem(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public string InvoiceNumber 
        {
            get { return GetValue<string>("invoice_number", false); }
        }
        public decimal? Quantity 
        {
            get { return GetValue<decimal?>("quantity", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
