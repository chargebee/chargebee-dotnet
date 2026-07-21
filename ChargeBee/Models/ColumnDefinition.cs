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

    public class ColumnDefinition : Resource 
    {
    
        public ColumnDefinition() { }

        public ColumnDefinition(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public ColumnDefinition(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public ColumnDefinition(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string ColumnName 
        {
            get { return GetValue<string>("column_name", true); }
        }
        public DataTypeEnum DataType 
        {
            get { return GetEnum<DataTypeEnum>("data_type", true); }
        }
        
        #endregion
        

        public enum DataTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "number")]
            Number,
            [EnumMember(Value = "string")]
            String,

        }

        #region Subclasses

        #endregion
    }
}
