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

    public class BusinessRule : Resource 
    {
    
        public BusinessRule() { }

        public BusinessRule(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public BusinessRule(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public BusinessRule(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("business_rules");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id), "delete");
            var request = new DeleteRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("delete");
            return request;
        }
        public static UpdateDraftRequest UpdateDraft(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id), "draft");
            var request = new UpdateDraftRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("updateDraft");
            return request;
        }
        public static BusinessRuleListRequest List()
        {
            string url = ApiUtil.BuildUrl("business_rules");
            var request = new BusinessRuleListRequest(url);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("list");
            return request;
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static RetrieveDraftRequest RetrieveDraft(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id), "draft");
            var request = new RetrieveDraftRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("retrieveDraft");
            return request;
        }
        public static DeleteDraftRequest DeleteDraft(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id), "delete_draft");
            var request = new DeleteDraftRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("deleteDraft");
            return request;
        }
        public static ActivateRuleRequest ActivateRule(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id), "activate");
            var request = new ActivateRuleRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("activateRule");
            return request;
        }
        public static DeactivateRuleRequest DeactivateRule(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id), "deactivate");
            var request = new DeactivateRuleRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("deactivateRule");
            return request;
        }
        public static ReleaseRuleRequest ReleaseRule(string id)
        {
            string url = ApiUtil.BuildUrl("business_rules", CheckNull(id), "release");
            var request = new ReleaseRuleRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("releaseRule");
            return request;
        }
        public static ApplyRulesRequest ApplyRules()
        {
            string url = ApiUtil.BuildUrl("business_rules", "apply_rules");
            var request = new ApplyRulesRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("businessRule");
            request.SetTelemetryOperation("applyRules");
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
        public int? LatestVersion 
        {
            get { return GetValue<int?>("latest_version", false); }
        }
        public bool Active 
        {
            get { return GetValue<bool>("active", true); }
        }
        public DateTime? ReleasedAt 
        {
            get { return GetDateTime("released_at", false); }
        }
        public string ReleasedBy 
        {
            get { return GetValue<string>("released_by", false); }
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
        public JArray Tags 
        {
            get { return GetJArray("tags", false); }
        }
        public JToken StructuredExpression 
        {
            get { return GetJToken("structured_expression", false); }
        }
        public JArray ActionsOnSuccess 
        {
            get { return GetJArray("actions_on_success", false); }
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
            public CreateRequest Tags(JArray tags) 
            {
                m_params.AddOpt("tags", tags);
                return this;
            }
            public CreateRequest StructuredExpression(JToken structuredExpression) 
            {
                m_params.Add("structured_expression", structuredExpression);
                return this;
            }
            public CreateRequest ActionsOnSuccess(JArray actionsOnSuccess) 
            {
                m_params.AddOpt("actions_on_success", actionsOnSuccess);
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
        public class UpdateDraftRequest : EntityRequest<UpdateDraftRequest> 
        {
            public UpdateDraftRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateDraftRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public UpdateDraftRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateDraftRequest Tags(JArray tags) 
            {
                m_params.AddOpt("tags", tags);
                return this;
            }
            public UpdateDraftRequest StructuredExpression(JToken structuredExpression) 
            {
                m_params.Add("structured_expression", structuredExpression);
                return this;
            }
            public UpdateDraftRequest ActionsOnSuccess(JArray actionsOnSuccess) 
            {
                m_params.AddOpt("actions_on_success", actionsOnSuccess);
                return this;
            }
        }
        public class BusinessRuleListRequest : ListRequestBase<BusinessRuleListRequest> 
        {
            public BusinessRuleListRequest(string url) 
                    : base(url)
            {
            }

            public BooleanFilter<BusinessRuleListRequest> Draft() 
            {
                return new BooleanFilter<BusinessRuleListRequest>("draft", this);        
            }
            public BooleanFilter<BusinessRuleListRequest> Active() 
            {
                return new BooleanFilter<BusinessRuleListRequest>("active", this);        
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class RetrieveDraftRequest : EntityRequest<RetrieveDraftRequest> 
        {
            public RetrieveDraftRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class DeleteDraftRequest : EntityRequest<DeleteDraftRequest> 
        {
            public DeleteDraftRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class ActivateRuleRequest : EntityRequest<ActivateRuleRequest> 
        {
            public ActivateRuleRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class DeactivateRuleRequest : EntityRequest<DeactivateRuleRequest> 
        {
            public DeactivateRuleRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class ReleaseRuleRequest : EntityRequest<ReleaseRuleRequest> 
        {
            public ReleaseRuleRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class ApplyRulesRequest : EntityRequest<ApplyRulesRequest> 
        {
            public ApplyRulesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ApplyRulesRequest Evaluate(bool evaluate) 
            {
                m_params.AddOpt("evaluate", evaluate);
                return this;
            }
            public ApplyRulesRequest RuleId(string ruleId) 
            {
                m_params.AddOpt("rule_id", ruleId);
                return this;
            }
            public ApplyRulesRequest RulesetId(string rulesetId) 
            {
                m_params.AddOpt("ruleset_id", rulesetId);
                return this;
            }
            public ApplyRulesRequest SkipFailedRules(bool skipFailedRules) 
            {
                m_params.AddOpt("skip_failed_rules", skipFailedRules);
                return this;
            }
            public ApplyRulesRequest StructuredExpression(JToken structuredExpression) 
            {
                m_params.AddOpt("structured_expression", structuredExpression);
                return this;
            }
            public ApplyRulesRequest Context(JToken context) 
            {
                m_params.AddOpt("context", context);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
