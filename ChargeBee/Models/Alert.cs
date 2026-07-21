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

    public class Alert : Resource 
    {
    
        public Alert() { }

        public Alert(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Alert(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Alert(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("alerts");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("alert");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("alerts", CheckNull(id));
            var request = new EntityRequest<Type>(url, HttpMethod.GET);
            request.SetTelemetryResource("alert");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static AlertListRequest List()
        {
            string url = ApiUtil.BuildUrl("alerts");
            var request = new AlertListRequest(url);
            request.SetTelemetryResource("alert");
            request.SetTelemetryOperation("list");
            return request;
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("alerts", CheckNull(id));
            var request = new UpdateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("alert");
            request.SetTelemetryOperation("update");
            return request;
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("alerts", CheckNull(id), "delete");
            var request = new EntityRequest<Type>(url, HttpMethod.POST);
            request.SetTelemetryResource("alert");
            request.SetTelemetryOperation("delete");
            return request;
        }
        public static AlertApplicationAlertsForSubscriptionRequest ApplicationAlertsForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "applicable_alerts");
            var request = new AlertApplicationAlertsForSubscriptionRequest(url);
            request.SetTelemetryResource("alert");
            request.SetTelemetryOperation("applicationAlertsForSubscription");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public TypeEnum AlertType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", true); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public string MeteredFeatureId 
        {
            get { return GetValue<string>("metered_feature_id", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string Meta 
        {
            get { return GetValue<string>("meta", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public List<AlertThreshold> Threshold 
        {
            get { return GetResourceList<AlertThreshold>("threshold"); }
        }
        public List<AlertFilterCondition> FilterConditions 
        {
            get { return GetResourceList<AlertFilterCondition>("filter_conditions"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Type(ChargeBee.Models.Enums.TypeEnum type) 
            {
                m_params.Add("type", type);
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
            public CreateRequest MeteredFeatureId(string meteredFeatureId) 
            {
                m_params.AddOpt("metered_feature_id", meteredFeatureId);
                return this;
            }
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public CreateRequest Meta(string meta) 
            {
                m_params.AddOpt("meta", meta);
                return this;
            }
            public CreateRequest ThresholdMode(ChargeBee.Models.Enums.ModeEnum thresholdMode) 
            {
                m_params.AddOpt("threshold[mode]", thresholdMode);
                return this;
            }
            public CreateRequest ThresholdValue(double thresholdValue) 
            {
                m_params.Add("threshold[value]", thresholdValue);
                return this;
            }
            public CreateRequest FilterConditionField(int index, FilterCondition.FieldEnum filterConditionField) 
            {
                m_params.AddOpt("filter_conditions[field][" + index + "]", filterConditionField);
                return this;
            }
            public CreateRequest FilterConditionOperator(int index, FilterCondition.OperatorEnum filterConditionOperator) 
            {
                m_params.AddOpt("filter_conditions[operator][" + index + "]", filterConditionOperator);
                return this;
            }
            public CreateRequest FilterConditionValue(int index, string filterConditionValue) 
            {
                m_params.AddOpt("filter_conditions[value][" + index + "]", filterConditionValue);
                return this;
            }
        }
        public class AlertListRequest : ListRequestBase<AlertListRequest> 
        {
            public AlertListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<AlertListRequest> Id() 
            {
                return new StringFilter<AlertListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.TypeEnum, AlertListRequest> Type() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.TypeEnum, AlertListRequest>("type", this).SupportsMultiOperators(true);        
            }
            public StringFilter<AlertListRequest> SubscriptionId() 
            {
                return new StringFilter<AlertListRequest>("subscription_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Alert.StatusEnum, AlertListRequest> Status() 
            {
                return new EnumFilter<Alert.StatusEnum, AlertListRequest>("status", this).SupportsMultiOperators(true);        
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Status(Alert.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public UpdateRequest ThresholdMode(ChargeBee.Models.Enums.ModeEnum thresholdMode) 
            {
                m_params.AddOpt("threshold[mode]", thresholdMode);
                return this;
            }
            public UpdateRequest ThresholdValue(double thresholdValue) 
            {
                m_params.AddOpt("threshold[value]", thresholdValue);
                return this;
            }
        }
        public class AlertApplicationAlertsForSubscriptionRequest : ListRequestBase<AlertApplicationAlertsForSubscriptionRequest> 
        {
            public AlertApplicationAlertsForSubscriptionRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<Alert.StatusEnum, AlertApplicationAlertsForSubscriptionRequest> Status() 
            {
                return new EnumFilter<Alert.StatusEnum, AlertApplicationAlertsForSubscriptionRequest>("status", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.TypeEnum, AlertApplicationAlertsForSubscriptionRequest> Type() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.TypeEnum, AlertApplicationAlertsForSubscriptionRequest>("type", this).SupportsMultiOperators(true);        
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "enabled")]
            Enabled,
            [EnumMember(Value = "disabled")]
            Disabled,

        }

        #region Subclasses
        public class AlertThreshold : Resource
        {

            public ModeEnum Mode {
                get { return GetEnum<ModeEnum>("mode", true); }
            }

            public double Value {
                get { return GetValue<double>("value", true); }
            }

        }
        public class AlertFilterCondition : Resource
        {
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

            public FieldEnum Field {
                get { return GetEnum<FieldEnum>("field", true); }
            }

            public OperatorEnum Operator {
                get { return GetEnum<OperatorEnum>("operator", true); }
            }

            public string Value {
                get { return GetValue<string>("value", true); }
            }

        }

        #endregion
    }
}
