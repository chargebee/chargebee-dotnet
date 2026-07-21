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

    public class Meter : Resource 
    {
    
        public Meter() { }

        public Meter(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Meter(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Meter(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static MeterListRequest List()
        {
            string url = ApiUtil.BuildUrl("meters");
            var request = new MeterListRequest(url);
            request.SetTelemetryResource("meter");
            request.SetTelemetryOperation("list");
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
        public TypeEnum MeterType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string Query 
        {
            get { return GetValue<string>("query", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
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
        public class MeterListRequest : ListRequestBase<MeterListRequest> 
        {
            public MeterListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<MeterListRequest> Name() 
            {
                return new StringFilter<MeterListRequest>("name", this);        
            }
            
            public MeterListRequest SortById(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","id");
                return this;
            }
            public MeterListRequest SortByName(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","name");
                return this;
            }
            public MeterListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
            public MeterListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "simple")]
            Simple,
            [EnumMember(Value = "compound")]
            Compound,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "archived")]
            Archived,
            [EnumMember(Value = "deleted")]
            Deleted,

        }

        #region Subclasses

        #endregion
    }
}
