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

    public class BusinessEntity : Resource 
    {
    
        public BusinessEntity() { }

        public BusinessEntity(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public BusinessEntity(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public BusinessEntity(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateTransfersRequest CreateTransfers()
        {
            string url = ApiUtil.BuildUrl("business_entities", "transfers");
            return new CreateTransfersRequest(url, HttpMethod.POST);
        }
        public static BusinessEntityGetTransfersRequest GetTransfers()
        {
            string url = ApiUtil.BuildUrl("business_entities", "transfers");
            return new BusinessEntityGetTransfersRequest(url);
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
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
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
        
        #endregion
        
        #region Requests
        public class CreateTransfersRequest : EntityRequest<CreateTransfersRequest> 
        {
            public CreateTransfersRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateTransfersRequest ActiveResourceIds(List<string> activeResourceIds) 
            {
                m_params.Add("active_resource_ids", activeResourceIds);
                return this;
            }
            public CreateTransfersRequest DestinationBusinessEntityIds(List<string> destinationBusinessEntityIds) 
            {
                m_params.Add("destination_business_entity_ids", destinationBusinessEntityIds);
                return this;
            }
            [Obsolete]
            public CreateTransfersRequest SourceBusinessEntityIds(List<string> sourceBusinessEntityIds) 
            {
                m_params.AddOpt("source_business_entity_ids", sourceBusinessEntityIds);
                return this;
            }
            [Obsolete]
            public CreateTransfersRequest ResourceTypes(List<string> resourceTypes) 
            {
                m_params.Add("resource_types", resourceTypes);
                return this;
            }
            public CreateTransfersRequest ReasonCodes(List<string> reasonCodes) 
            {
                m_params.Add("reason_codes", reasonCodes);
                return this;
            }
        }
        public class BusinessEntityGetTransfersRequest : ListRequestBase<BusinessEntityGetTransfersRequest> 
        {
            public BusinessEntityGetTransfersRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<BusinessEntityGetTransfersRequest> ResourceType() 
            {
                return new StringFilter<BusinessEntityGetTransfersRequest>("resource_type", this);        
            }
            public StringFilter<BusinessEntityGetTransfersRequest> ResourceId() 
            {
                return new StringFilter<BusinessEntityGetTransfersRequest>("resource_id", this);        
            }
            public StringFilter<BusinessEntityGetTransfersRequest> ActiveResourceId() 
            {
                return new StringFilter<BusinessEntityGetTransfersRequest>("active_resource_id", this);        
            }
            public TimestampFilter<BusinessEntityGetTransfersRequest> CreatedAt() 
            {
                return new TimestampFilter<BusinessEntityGetTransfersRequest>("created_at", this);        
            }
            
            public BusinessEntityGetTransfersRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
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
            [EnumMember(Value = "inactive")]
            Inactive,

        }

        #region Subclasses

        #endregion
    }
}
