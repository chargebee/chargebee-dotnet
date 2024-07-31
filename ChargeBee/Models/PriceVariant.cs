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

    public class PriceVariant : Resource 
    {
    
        public PriceVariant() { }

        public PriceVariant(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PriceVariant(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PriceVariant(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("price_variants");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("price_variants", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("price_variants", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("price_variants", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static PriceVariantListRequest List()
        {
            string url = ApiUtil.BuildUrl("price_variants");
            return new PriceVariantListRequest(url);
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
        public string ExternalName 
        {
            get { return GetValue<string>("external_name", false); }
        }
        public string VariantGroup 
        {
            get { return GetValue<string>("variant_group", false); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public List<PriceVariantAttribute> Attributes 
        {
            get { return GetResourceList<PriceVariantAttribute>("attributes"); }
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
            public CreateRequest ExternalName(string externalName) 
            {
                m_params.AddOpt("external_name", externalName);
                return this;
            }
            public CreateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateRequest VariantGroup(string variantGroup) 
            {
                m_params.AddOpt("variant_group", variantGroup);
                return this;
            }
            public CreateRequest AttributeName(int index, string attributeName) 
            {
                m_params.Add("attributes[name][" + index + "]", attributeName);
                return this;
            }
            public CreateRequest AttributeValue(int index, string attributeValue) 
            {
                m_params.Add("attributes[value][" + index + "]", attributeValue);
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
            public UpdateRequest ExternalName(string externalName) 
            {
                m_params.AddOpt("external_name", externalName);
                return this;
            }
            public UpdateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateRequest VariantGroup(string variantGroup) 
            {
                m_params.AddOpt("variant_group", variantGroup);
                return this;
            }
            public UpdateRequest Status(PriceVariant.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public UpdateRequest AttributeName(int index, string attributeName) 
            {
                m_params.Add("attributes[name][" + index + "]", attributeName);
                return this;
            }
            public UpdateRequest AttributeValue(int index, string attributeValue) 
            {
                m_params.Add("attributes[value][" + index + "]", attributeValue);
                return this;
            }
        }
        public class PriceVariantListRequest : ListRequestBase<PriceVariantListRequest> 
        {
            public PriceVariantListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<PriceVariantListRequest> Id() 
            {
                return new StringFilter<PriceVariantListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<PriceVariantListRequest> Name() 
            {
                return new StringFilter<PriceVariantListRequest>("name", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<PriceVariant.StatusEnum, PriceVariantListRequest> Status() 
            {
                return new EnumFilter<PriceVariant.StatusEnum, PriceVariantListRequest>("status", this);        
            }
            public TimestampFilter<PriceVariantListRequest> UpdatedAt() 
            {
                return new TimestampFilter<PriceVariantListRequest>("updated_at", this);        
            }
            public TimestampFilter<PriceVariantListRequest> CreatedAt() 
            {
                return new TimestampFilter<PriceVariantListRequest>("created_at", this);        
            }
            
            public PriceVariantListRequest SortByName(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","name");
                return this;
            }
            public PriceVariantListRequest SortById(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","id");
                return this;
            }
            public PriceVariantListRequest SortByStatus(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","status");
                return this;
            }
            public PriceVariantListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
            public PriceVariantListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
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
            [EnumMember(Value = "deleted")]
            Deleted,

        }

        #region Subclasses
        public class PriceVariantAttribute : Resource
        {

            public string Name {
                get { return GetValue<string>("name", true); }
            }

            public string Value {
                get { return GetValue<string>("value", true); }
            }

        }

        #endregion
    }
}
