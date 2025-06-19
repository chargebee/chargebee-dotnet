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

    public class Configuration : Resource 
    {
    
        public Configuration() { }

        public Configuration(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Configuration(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Configuration(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> List()
        {
            string url = ApiUtil.BuildUrl("configurations");
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Domain 
        {
            get { return GetValue<string>("domain", false); }
        }
        public ProductCatalogVersionEnum? ProductCatalogVersion 
        {
            get { return GetEnum<ProductCatalogVersionEnum>("product_catalog_version", false); }
        }
        public ChargebeeResponseSchemaTypeEnum? ChargebeeResponseSchemaType 
        {
            get { return GetEnum<ChargebeeResponseSchemaTypeEnum>("chargebee_response_schema_type", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
