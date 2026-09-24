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

    public class BusinessRuleset : Resource 
    {
    
        public BusinessRuleset() { }

        public BusinessRuleset(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public BusinessRuleset(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public BusinessRuleset(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("business_rulesets");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id));
            var request = new UpdateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("update");
            return request;
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id), "delete");
            var request = new DeleteRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("delete");
            return request;
        }
        public static ActivateRequest Activate(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id), "activate");
            var request = new ActivateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("activate");
            return request;
        }
        public static DeactivateRequest Deactivate(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id), "deactivate");
            var request = new DeactivateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("deactivate");
            return request;
        }
        public static AddRulesRequest AddRules(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id), "add_rules");
            var request = new AddRulesRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("addRules");
            return request;
        }
        public static RemoveRulesRequest RemoveRules(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id), "remove_rules");
            var request = new RemoveRulesRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("removeRules");
            return request;
        }
        public static ListRulesRequest ListRules(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id), "rules");
            var request = new ListRulesRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("listRules");
            return request;
        }
        public static BusinessRulesetListRequest List()
        {
            string url = ApiUtil.BuildUrl("business_rulesets");
            var request = new BusinessRulesetListRequest(url);
            request.SetTelemetryResource("businessRuleset");
            request.SetTelemetryOperation("list");
            return request;
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("business_rulesets", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("businessRuleset");
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
            get { return GetValue<string>("name", true); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public bool Active 
        {
            get { return GetValue<bool>("active", true); }
        }
        public ExecuteModeEnum ExecuteMode 
        {
            get { return GetEnum<ExecuteModeEnum>("execute_mode", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public string UpdatedBy 
        {
            get { return GetValue<string>("updated_by", false); }
        }
        public string CreatedBy 
        {
            get { return GetValue<string>("created_by", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public JArray Rules 
        {
            get { return GetJArray("rules", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CreateRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public CreateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateRequest ExecuteMode(BusinessRuleset.ExecuteModeEnum executeMode) 
            {
                m_params.AddOpt("execute_mode", executeMode);
                return this;
            }
            public CreateRequest Rules(JArray rules) 
            {
                m_params.AddOpt("rules", rules);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public UpdateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateRequest ExecuteMode(BusinessRuleset.ExecuteModeEnum executeMode) 
            {
                m_params.AddOpt("execute_mode", executeMode);
                return this;
            }
            public UpdateRequest Rules(JArray rules) 
            {
                m_params.AddOpt("rules", rules);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class ActivateRequest : EntityRequest<ActivateRequest> 
        {
            public ActivateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class DeactivateRequest : EntityRequest<DeactivateRequest> 
        {
            public DeactivateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class AddRulesRequest : EntityRequest<AddRulesRequest> 
        {
            public AddRulesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddRulesRequest Rules(JArray rules) 
            {
                m_params.AddOpt("rules", rules);
                return this;
            }
        }
        public class RemoveRulesRequest : EntityRequest<RemoveRulesRequest> 
        {
            public RemoveRulesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemoveRulesRequest Rules(JArray rules) 
            {
                m_params.AddOpt("rules", rules);
                return this;
            }
        }
        public class ListRulesRequest : EntityRequest<ListRulesRequest> 
        {
            public ListRulesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ListRulesRequest Limit(int limit) 
            {
                m_params.AddOpt("limit", limit);
                return this;
            }
            public ListRulesRequest Offset(string offset) 
            {
                m_params.AddOpt("offset", offset);
                return this;
            }
            public BooleanFilter<ListRulesRequest> Active() 
            {
                return new BooleanFilter<ListRulesRequest>("active", this);        
            }
        }
        public class BusinessRulesetListRequest : ListRequestBase<BusinessRulesetListRequest> 
        {
            public BusinessRulesetListRequest(string url) 
                    : base(url)
            {
            }

            public BooleanFilter<BusinessRulesetListRequest> Active() 
            {
                return new BooleanFilter<BusinessRulesetListRequest>("active", this);        
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        #endregion

        public enum ExecuteModeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "stop_on_first_true")]
            StopOnFirstTrue,
            [EnumMember(Value = "stop_on_first_false")]
            StopOnFirstFalse,
            [EnumMember(Value = "execute_all")]
            ExecuteAll,
            [EnumMember(Value = "execute_all_true")]
            ExecuteAllTrue,

        }

        #region Subclasses

        #endregion
    }
}
