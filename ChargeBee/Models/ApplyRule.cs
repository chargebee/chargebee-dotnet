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

    public class ApplyRule : Resource 
    {
    
        public ApplyRule() { }

        public ApplyRule(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public ApplyRule(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public ApplyRule(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public bool? Evaluate 
        {
            get { return GetValue<bool?>("evaluate", false); }
        }
        public string RuleId 
        {
            get { return GetValue<string>("rule_id", false); }
        }
        public string RulesetId 
        {
            get { return GetValue<string>("ruleset_id", false); }
        }
        public bool? SkipFailedRules 
        {
            get { return GetValue<bool?>("skip_failed_rules", false); }
        }
        public JToken StructuredExpression 
        {
            get { return GetJToken("structured_expression", false); }
        }
        public JToken Context 
        {
            get { return GetJToken("context", false); }
        }
        public List<ApplyRuleRule> Rules 
        {
            get { return GetResourceList<ApplyRuleRule>("rules"); }
        }
        
        #endregion
        


        #region Subclasses
        public class ApplyRuleRule : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public int? Version {
                get { return GetValue<int?>("version", false); }
            }

            public string Name {
                get { return GetValue<string>("name", false); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

            public bool? EvaluationResult {
                get { return GetValue<bool?>("evaluation_result", false); }
            }

            public string ErrorMessage {
                get { return GetValue<string>("error_message", false); }
            }

            public JArray Actions {
                get { return GetJArray("actions", false); }
            }

        }

        #endregion
    }
}
