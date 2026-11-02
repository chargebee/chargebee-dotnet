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

    public class RetrySegment : Resource 
    {
    
        public RetrySegment() { }

        public RetrySegment(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public RetrySegment(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public RetrySegment(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("retry_segments", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("retrySegment");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", false); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", false); }
        }
        public bool Enabled 
        {
            get { return GetValue<bool>("enabled", true); }
        }
        public int? Priority 
        {
            get { return GetValue<int?>("priority", false); }
        }
        public ConditionLogicEnum? ConditionLogic 
        {
            get { return GetEnum<ConditionLogicEnum>("condition_logic", false); }
        }
        public JArray Criteria 
        {
            get { return GetJArray("criteria", false); }
        }
        public JToken RetrySettings 
        {
            get { return GetJToken("retry_settings", false); }
        }
        
        #endregion
        
        #region Requests
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveRequest InvoiceId(string invoiceId) 
            {
                m_params.AddOpt("invoice_id", invoiceId);
                return this;
            }
        }
        #endregion

        public enum ConditionLogicEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "and")]
            And,
            [EnumMember(Value = "or")]
            Or,

        }

        #region Subclasses

        #endregion
    }
}
