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

    public class DraftRequest : Resource 
    {
    
        public DraftRequest() { }

        public DraftRequest(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public DraftRequest(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public DraftRequest(String jsonString)
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
        public string PathParam 
        {
            get { return GetValue<string>("path_param", false); }
        }
        public string RequestUri 
        {
            get { return GetValue<string>("request_uri", false); }
        }
        public string OperationId 
        {
            get { return GetValue<string>("operation_id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? ExecutedAt 
        {
            get { return GetDateTime("executed_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public DraftRequestDraftRevision CurrentRevision 
        {
            get { return GetSubResource<DraftRequestDraftRevision>("current_revision"); }
        }
        public List<DraftRequestValidation> Validations 
        {
            get { return GetResourceList<DraftRequestValidation>("validations"); }
        }
        public bool? HasComments 
        {
            get { return GetValue<bool?>("has_comments", false); }
        }
        public bool? HasCitations 
        {
            get { return GetValue<bool?>("has_citations", false); }
        }
        public List<DraftRequestExecution> Executions 
        {
            get { return GetResourceList<DraftRequestExecution>("executions"); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "open")]
            Open,
            [EnumMember(Value = "executed")]
            Executed,

        }

        #region Subclasses
        public class DraftRequestDraftRevision : Resource
        {

            public DateTime Version {
                get { return (DateTime)GetDateTime("version", true); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public JToken Payload {
                get { return GetJToken("payload", false); }
            }

        }
        public class DraftRequestValidation : Resource
        {

            public string Category {
                get { return GetValue<string>("category", false); }
            }

            public string Level {
                get { return GetValue<string>("level", false); }
            }

            public string Message {
                get { return GetValue<string>("message", false); }
            }

            public string ParamName {
                get { return GetValue<string>("param_name", false); }
            }

            public string ValidationType {
                get { return GetValue<string>("type", false); }
            }

        }
        public class DraftRequestExecution : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "success")]
                Success,
                [EnumMember(Value = "failed")]
                Failed,
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public JToken Result {
                get { return GetJToken("result", false); }
            }

            public JToken ErrorDetail {
                get { return GetJToken("error_detail", false); }
            }

            public DateTime? RevisionVersion {
                get { return GetDateTime("revision_version", false); }
            }

        }

        #endregion
    }
}
