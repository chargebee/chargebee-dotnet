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

    public class ImpactedCustomer : Resource 
    {
    
        public ImpactedCustomer() { }

        public ImpactedCustomer(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public ImpactedCustomer(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public ImpactedCustomer(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string ActionType 
        {
            get { return GetValue<string>("action_type", false); }
        }
        public ImpactedCustomerDownload Download 
        {
            get { return GetSubResource<ImpactedCustomerDownload>("download"); }
        }
        
        #endregion
        


        #region Subclasses
        public class ImpactedCustomerDownload : Resource
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
