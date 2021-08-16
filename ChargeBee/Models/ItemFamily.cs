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

    public class ItemFamily : Resource 
    {
    
        public ItemFamily() { }

        public ItemFamily(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public ItemFamily(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public ItemFamily(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("item_families");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("item_families", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static ItemFamilyListRequest List()
        {
            string url = ApiUtil.BuildUrl("item_families");
            return new ItemFamilyListRequest(url);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("item_families", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("item_families", CheckNull(id), "delete");
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
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
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
                m_params.Add("id", id);
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
        }
        public class ItemFamilyListRequest : ListRequestBase<ItemFamilyListRequest> 
        {
            public ItemFamilyListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<ItemFamilyListRequest> Id() 
            {
                return new StringFilter<ItemFamilyListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<ItemFamilyListRequest> Name() 
            {
                return new StringFilter<ItemFamilyListRequest>("name", this);        
            }
            public TimestampFilter<ItemFamilyListRequest> UpdatedAt() 
            {
                return new TimestampFilter<ItemFamilyListRequest>("updated_at", this);        
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
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "deleted")]
            Deleted,

        }

        #region Subclasses

        #endregion
    }
}
