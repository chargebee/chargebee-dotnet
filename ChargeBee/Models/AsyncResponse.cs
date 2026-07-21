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

    public class AsyncResponse : Resource 
    {
    
        public AsyncResponse() { }

        public AsyncResponse(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public AsyncResponse(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public AsyncResponse(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string ApiVersion 
        {
            get { return GetValue<string>("api_version", false); }
        }
        public DateTime? CreatedAt 
        {
            get { return GetDateTime("created_at", false); }
        }
        public DateTime? CompletedAt 
        {
            get { return GetDateTime("completed_at", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public AsyncResponseRequestAsyncApi Request 
        {
            get { return GetSubResource<AsyncResponseRequestAsyncApi>("request"); }
        }
        public AsyncResponseError ErrorDetail 
        {
            get { return GetSubResource<AsyncResponseError>("error_detail"); }
        }
        public JToken Result 
        {
            get { return GetJToken("result", false); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "success")]
            Success,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class AsyncResponseRequestAsyncApi : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string Resource {
                get { return GetValue<string>("resource", false); }
            }

            public string OperationType {
                get { return GetValue<string>("operation_type", false); }
            }

            public string Method {
                get { return GetValue<string>("method", false); }
            }

            public string Uri {
                get { return GetValue<string>("uri", false); }
            }

            public string IdempotencyKey {
                get { return GetValue<string>("idempotency_key", false); }
            }

        }
        public class AsyncResponseError : Resource
        {

            public string Message {
                get { return GetValue<string>("message", false); }
            }

            public string ErrorDetailType {
                get { return GetValue<string>("type", false); }
            }

            public string ApiErrorCode {
                get { return GetValue<string>("api_error_code", false); }
            }

            public string ErrorCode {
                get { return GetValue<string>("error_code", false); }
            }

            public string ErrorMsg {
                get { return GetValue<string>("error_msg", false); }
            }

            public string HttpStatusCode {
                get { return GetValue<string>("http_status_code", false); }
            }

        }

        #endregion
    }
}
