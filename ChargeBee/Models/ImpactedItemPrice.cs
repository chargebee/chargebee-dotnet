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

    public class ImpactedItemPrice : Resource 
    {
    
        public ImpactedItemPrice() { }

        public ImpactedItemPrice(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public ImpactedItemPrice(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public ImpactedItemPrice(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public int? Count 
        {
            get { return GetValue<int?>("count", false); }
        }
        public ImpactedItemPriceDownload Download 
        {
            get { return GetSubResource<ImpactedItemPriceDownload>("download"); }
        }
        public JArray ItemPrices 
        {
            get { return GetJArray("item_prices", false); }
        }
        
        #endregion
        


        #region Subclasses
        public class ImpactedItemPriceDownload : Resource
        {

            public string DownloadUrl {
                get { return GetValue<string>("download_url", true); }
            }

            public DateTime ValidTill {
                get { return (DateTime)GetDateTime("valid_till", true); }
            }

            public string MimeType {
                get { return GetValue<string>("mime_type", false); }
            }

        }

        #endregion
    }
}
