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

    public class PreferenceVariant : Resource 
    {
    
        public PreferenceVariant() { }

        public PreferenceVariant(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PreferenceVariant(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PreferenceVariant(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        [Obsolete]
        public string Value 
        {
            get { return GetValue<string>("value", true); }
        }
        [Obsolete]
        public bool? AllowOverrideInInterface 
        {
            get { return GetValue<bool?>("allow_override_in_interface", false); }
        }
        [Obsolete]
        public bool? AllowOverrideInApi 
        {
            get { return GetValue<bool?>("allow_override_in_api", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
