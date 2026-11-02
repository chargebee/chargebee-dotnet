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

    public class GroupByRecommendation : Resource 
    {
    
        public GroupByRecommendation() { }

        public GroupByRecommendation(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public GroupByRecommendation(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public GroupByRecommendation(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string AttributeName 
        {
            get { return GetValue<string>("attribute_name", true); }
        }
        public int Rank 
        {
            get { return GetValue<int>("rank", true); }
        }
        public string Reason 
        {
            get { return GetValue<string>("reason", true); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
