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

    public class SiteMigrationDetail : Resource 
    {
    

        #region Methods
        public static SiteMigrationDetailListRequest List()
        {
            string url = ApiUtil.BuildUrl("site_migration_details");
            return new SiteMigrationDetailListRequest(url);
        }
        #endregion
        
        #region Properties
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", true); }
        }
        public string OtherSiteName 
        {
            get { return GetValue<string>("other_site_name", true); }
        }
        public string EntityIdAtOtherSite 
        {
            get { return GetValue<string>("entity_id_at_other_site", true); }
        }
        public DateTime MigratedAt 
        {
            get { return (DateTime)GetDateTime("migrated_at", true); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        
        #endregion
        
        #region Requests
        public class SiteMigrationDetailListRequest : ListRequestBase<SiteMigrationDetailListRequest> 
        {
            public SiteMigrationDetailListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<SiteMigrationDetailListRequest> EntityIdAtOtherSite() 
            {
                return new StringFilter<SiteMigrationDetailListRequest>("entity_id_at_other_site", this);        
            }
            public StringFilter<SiteMigrationDetailListRequest> OtherSiteName() 
            {
                return new StringFilter<SiteMigrationDetailListRequest>("other_site_name", this);        
            }
            public StringFilter<SiteMigrationDetailListRequest> EntityId() 
            {
                return new StringFilter<SiteMigrationDetailListRequest>("entity_id", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.EntityTypeEnum, SiteMigrationDetailListRequest> EntityType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.EntityTypeEnum, SiteMigrationDetailListRequest>("entity_type", this);        
            }
            public EnumFilter<StatusEnum, SiteMigrationDetailListRequest> Status() 
            {
                return new EnumFilter<StatusEnum, SiteMigrationDetailListRequest>("status", this);        
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("moved_in")]
            MovedIn,
            [Description("moved_out")]
            MovedOut,
            [Description("moving_out")]
            MovingOut,

        }

        #region Subclasses

        #endregion
    }
}
