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

    public class OfferEvent : Resource 
    {
    
        public OfferEvent() { }

        public OfferEvent(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OfferEvent(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OfferEvent(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static OfferEventsRequest OfferEvents()
        {
            string url = ApiUtil.BuildUrl("offer_events");
            return new OfferEventsRequest(url, HttpMethod.POST).SetSubDomain("grow").IsJsonRequest(true).SetIdempotent(false);
        }
        #endregion
        
        #region Properties
        
        #endregion
        
        #region Requests
        public class OfferEventsRequest : EntityRequest<OfferEventsRequest> 
        {
            public OfferEventsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public OfferEventsRequest PersonalizedOfferId(string personalizedOfferId) 
            {
                m_params.Add("personalized_offer_id", personalizedOfferId);
                return this;
            }
            public OfferEventsRequest Type(TypeEnum type) 
            {
                m_params.Add("type", type);
                return this;
            }
        
        }
        #endregion

        public enum TypeEnum
        {
            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "viewed")]
            Viewed,
            [EnumMember(Value = "dismissed")]
            Dismissed,
        }

        #region Subclasses

        
        #endregion
    }
}
