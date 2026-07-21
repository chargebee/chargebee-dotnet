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

    public class MeteredFeature : Resource 
    {
    
        public MeteredFeature() { }

        public MeteredFeature(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public MeteredFeature(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public MeteredFeature(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("metered_features");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("meteredFeature");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static EntityRequest<Type> Archive(string id)
        {
            string url = ApiUtil.BuildUrl("metered_features", CheckNull(id), "archive_command");
            var request = new EntityRequest<Type>(url, HttpMethod.POST);
            request.SetTelemetryResource("meteredFeature");
            request.SetTelemetryOperation("archive");
            return request;
        }
        public static EntityRequest<Type> Reactivate(string id)
        {
            string url = ApiUtil.BuildUrl("metered_features", CheckNull(id), "reactivate_command");
            var request = new EntityRequest<Type>(url, HttpMethod.POST);
            request.SetTelemetryResource("meteredFeature");
            request.SetTelemetryOperation("reactivate");
            return request;
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("metered_features", CheckNull(id), "delete");
            var request = new EntityRequest<Type>(url, HttpMethod.POST);
            request.SetTelemetryResource("meteredFeature");
            request.SetTelemetryOperation("delete");
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
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public TypeEnum? MeteredFeatureType 
        {
            get { return GetEnum<TypeEnum>("type", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string Query 
        {
            get { return GetValue<string>("query", false); }
        }
        public List<ColumnDefinition> ColumnDefinitions 
        {
            get { return GetResourceList<ColumnDefinition>("column_definitions"); }
        }
        public List<Feature> Features 
        {
            get { return GetResourceList<Feature>("features"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
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
            public CreateRequest FeatureUnit(string featureUnit) 
            {
                m_params.Add("feature_unit", featureUnit);
                return this;
            }
            public CreateRequest Query(string query) 
            {
                m_params.Add("query", query);
                return this;
            }
            public CreateRequest ColumnDefinitionColumnName(int index, string columnDefinitionColumnName) 
            {
                m_params.Add("column_definitions[column_name][" + index + "]", columnDefinitionColumnName);
                return this;
            }
            public CreateRequest ColumnDefinitionDataType(int index, ColumnDefinition.DataTypeEnum columnDefinitionDataType) 
            {
                m_params.Add("column_definitions[data_type][" + index + "]", columnDefinitionDataType);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
