using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class ResourceMigration : Resource 
    {
    

        #region Methods
        public static RetrieveLatestRequest RetrieveLatest()
        {
            string url = ApiUtil.BuildUrl("resource_migrations", "retrieve_latest");
            return new RetrieveLatestRequest(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string FromSite 
        {
            get { return GetValue<string>("from_site", true); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string Errors 
        {
            get { return GetValue<string>("errors", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        
        #endregion
        
        #region Requests
        public class RetrieveLatestRequest : EntityRequest<RetrieveLatestRequest> 
        {
            public RetrieveLatestRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveLatestRequest FromSite(string fromSite) 
            {
                m_params.Add("from_site", fromSite);
                return this;
            }
            public RetrieveLatestRequest EntityType(ChargeBee.Models.Enums.EntityTypeEnum entityType) 
            {
                m_params.Add("entity_type", entityType);
                return this;
            }
            public RetrieveLatestRequest EntityId(string entityId) 
            {
                m_params.Add("entity_id", entityId);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("scheduled")]
            Scheduled,
            [Description("failed")]
            Failed,
            [Description("succeeded")]
            Succeeded,

        }

        #region Subclasses

        #endregion
    }
}
