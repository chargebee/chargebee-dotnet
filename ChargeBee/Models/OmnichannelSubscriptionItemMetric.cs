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

    public class OmnichannelSubscriptionItemMetric : Resource 
    {
    
        public OmnichannelSubscriptionItemMetric() { }

        public OmnichannelSubscriptionItemMetric(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelSubscriptionItemMetric(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelSubscriptionItemMetric(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string OmnichannelSubscriptionId 
        {
            get { return GetValue<string>("omnichannel_subscription_id", false); }
        }
        public string OmnichannelSubscriptionItemId 
        {
            get { return GetValue<string>("omnichannel_subscription_item_id", false); }
        }
        public string ItemIdAtSource 
        {
            get { return GetValue<string>("item_id_at_source", true); }
        }
        public string MrrCurrency 
        {
            get { return GetValue<string>("mrr_currency", false); }
        }
        public long? MrrUnits 
        {
            get { return GetValue<long?>("mrr_units", false); }
        }
        public long? MrrNanos 
        {
            get { return GetValue<long?>("mrr_nanos", false); }
        }
        public DateTime EffectiveFrom 
        {
            get { return (DateTime)GetDateTime("effective_from", true); }
        }
        public DateTime? CalculatedAt 
        {
            get { return GetDateTime("calculated_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
