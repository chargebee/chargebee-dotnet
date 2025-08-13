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

    public class OmnichannelSubscriptionItemOffer : Resource 
    {
    
        public OmnichannelSubscriptionItemOffer() { }

        public OmnichannelSubscriptionItemOffer(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelSubscriptionItemOffer(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelSubscriptionItemOffer(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string OfferIdAtSource 
        {
            get { return GetValue<string>("offer_id_at_source", false); }
        }
        public CategoryEnum Category 
        {
            get { return GetEnum<CategoryEnum>("category", true); }
        }
        public string CategoryAtSource 
        {
            get { return GetValue<string>("category_at_source", false); }
        }
        public TypeEnum OmnichannelSubscriptionItemOfferType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public string TypeAtSource 
        {
            get { return GetValue<string>("type_at_source", false); }
        }
        public DiscountTypeEnum? DiscountType 
        {
            get { return GetEnum<DiscountTypeEnum>("discount_type", false); }
        }
        public string Duration 
        {
            get { return GetValue<string>("duration", true); }
        }
        public double? Percentage 
        {
            get { return GetValue<double?>("percentage", false); }
        }
        public string PriceCurrency 
        {
            get { return GetValue<string>("price_currency", false); }
        }
        public long? PriceUnits 
        {
            get { return GetValue<long?>("price_units", false); }
        }
        public long? PriceNanos 
        {
            get { return GetValue<long?>("price_nanos", false); }
        }
        public DateTime? OfferTermStart 
        {
            get { return GetDateTime("offer_term_start", false); }
        }
        public DateTime? OfferTermEnd 
        {
            get { return GetDateTime("offer_term_end", false); }
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
