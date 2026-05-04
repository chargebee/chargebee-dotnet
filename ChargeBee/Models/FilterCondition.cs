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

    public class FilterCondition : Resource 
    {
    
        public FilterCondition() { }

        public FilterCondition(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public FilterCondition(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public FilterCondition(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public FieldEnum Field 
        {
            get { return GetEnum<FieldEnum>("field", true); }
        }
        public OperatorEnum Operator 
        {
            get { return GetEnum<OperatorEnum>("operator", true); }
        }
        public string Value 
        {
            get { return GetValue<string>("value", true); }
        }
        
        #endregion
        

        public enum FieldEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "plan_price_id")]
            PlanPriceId,

        }
        public enum OperatorEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "equals")]
            Equals,
            [EnumMember(Value = "not_equals")]
            NotEquals,

        }

        #region Subclasses

        #endregion
    }
}
