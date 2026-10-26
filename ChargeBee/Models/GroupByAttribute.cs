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

    public class GroupByAttribute : Resource 
    {
    
        public GroupByAttribute() { }

        public GroupByAttribute(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public GroupByAttribute(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public GroupByAttribute(String jsonString)
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
        public int CoveragePercent 
        {
            get { return GetValue<int>("coverage_percent", true); }
        }
        public long Cardinality 
        {
            get { return GetValue<long>("cardinality", true); }
        }
        public long RemainingValueCount 
        {
            get { return GetValue<long>("remaining_value_count", true); }
        }
        public bool Warning 
        {
            get { return GetValue<bool>("warning", true); }
        }
        public List<string> SampleValues 
        {
            get { return GetList<string>("sample_values"); }
        }
        public List<WarningReasonEnum> WarningReasons 
        {
            get { return GetList<WarningReasonEnum>("warning_reasons"); }
        }
        
        #endregion
        

        public enum WarningReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "low_coverage")]
            LowCoverage,
            [EnumMember(Value = "high_cardinality")]
            HighCardinality,

        }

        #region Subclasses

        #endregion
    }
}
