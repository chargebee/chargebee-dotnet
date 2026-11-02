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

    public class Citation : Resource 
    {
    
        public Citation() { }

        public Citation(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Citation(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Citation(String jsonString)
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
        public string ParamName 
        {
            get { return GetValue<string>("param_name", false); }
        }
        public string AuthorName 
        {
            get { return GetValue<string>("author_name", true); }
        }
        public ConfidenceLevelEnum? ConfidenceLevel 
        {
            get { return GetEnum<ConfidenceLevelEnum>("confidence_level", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        
        #endregion
        

        public enum ConfidenceLevelEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "low")]
            Low,
            [EnumMember(Value = "medium")]
            Medium,
            [EnumMember(Value = "high")]
            High,
            [EnumMember(Value = "not_provided")]
            NotProvided,

        }

        #region Subclasses
        public class CitationContent : ResultBase
        {

            public CitationContent () { }

            internal CitationContent(JToken jobj)
            {
                m_jobj = jobj;
            }
        }

        #endregion
    }
}
