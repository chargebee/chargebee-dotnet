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

    public class Feature : Resource 
    {
    
        public Feature() { }

        public Feature(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Feature(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Feature(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static FeatureListRequest List()
        {
            string url = ApiUtil.BuildUrl("features");
            return new FeatureListRequest(url);
        }
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("features");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Activate(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id), "activate_command");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Archive(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id), "archive_command");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Reactivate(string id)
        {
            string url = ApiUtil.BuildUrl("features", CheckNull(id), "reactivate_command");
            return new EntityRequest<Type>(url, HttpMethod.POST);
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
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public TypeEnum? FeatureType 
        {
            get { return GetEnum<TypeEnum>("type", false); }
        }
        public string Unit 
        {
            get { return GetValue<string>("unit", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public List<FeatureLevel> Levels 
        {
            get { return GetResourceList<FeatureLevel>("levels"); }
        }
        
        #endregion
        
        #region Requests
        public class FeatureListRequest : ListRequestBase<FeatureListRequest> 
        {
            public FeatureListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<FeatureListRequest> Name() 
            {
                return new StringFilter<FeatureListRequest>("name", this).SupportsMultiOperators(true);        
            }
            public StringFilter<FeatureListRequest> Id() 
            {
                return new StringFilter<FeatureListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Feature.StatusEnum, FeatureListRequest> Status() 
            {
                return new EnumFilter<Feature.StatusEnum, FeatureListRequest>("status", this);        
            }
            public EnumFilter<Feature.TypeEnum, FeatureListRequest> Type() 
            {
                return new EnumFilter<Feature.TypeEnum, FeatureListRequest>("type", this);        
            }
        }
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
            public CreateRequest Type(Feature.TypeEnum type) 
            {
                m_params.AddOpt("type", type);
                return this;
            }
            public CreateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public CreateRequest LevelName(int index, string levelName) 
            {
                m_params.AddOpt("levels[name][" + index + "]", levelName);
                return this;
            }
            public CreateRequest LevelValue(int index, string levelValue) 
            {
                m_params.AddOpt("levels[value][" + index + "]", levelValue);
                return this;
            }
            public CreateRequest LevelIsUnlimited(int index, bool levelIsUnlimited) 
            {
                m_params.AddOpt("levels[is_unlimited][" + index + "]", levelIsUnlimited);
                return this;
            }
            public CreateRequest LevelLevel(int index, int levelLevel) 
            {
                m_params.AddOpt("levels[level][" + index + "]", levelLevel);
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
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public UpdateRequest LevelName(int index, string levelName) 
            {
                m_params.AddOpt("levels[name][" + index + "]", levelName);
                return this;
            }
            public UpdateRequest LevelValue(int index, string levelValue) 
            {
                m_params.AddOpt("levels[value][" + index + "]", levelValue);
                return this;
            }
            public UpdateRequest LevelIsUnlimited(int index, bool levelIsUnlimited) 
            {
                m_params.AddOpt("levels[is_unlimited][" + index + "]", levelIsUnlimited);
                return this;
            }
            public UpdateRequest LevelLevel(int index, int levelLevel) 
            {
                m_params.AddOpt("levels[level][" + index + "]", levelLevel);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "archived")]
            Archived,
            [EnumMember(Value = "draft")]
            Draft,

        }
        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "switch")]
            Switch,
            [EnumMember(Value = "custom")]
            Custom,
            [EnumMember(Value = "quantity")]
            Quantity,
            [EnumMember(Value = "range")]
            Range,

        }

        #region Subclasses
        public class FeatureLevel : Resource
        {

            public string Name {
                get { return GetValue<string>("name", false); }
            }

            public string Value {
                get { return GetValue<string>("value", true); }
            }

            public int Level {
                get { return GetValue<int>("level", true); }
            }

            public bool IsUnlimited {
                get { return GetValue<bool>("is_unlimited", true); }
            }

        }

        #endregion
    }
}
