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

    public class CustomDataSchema : Resource 
    {
    
        public CustomDataSchema() { }

        public CustomDataSchema(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CustomDataSchema(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CustomDataSchema(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string DisplayName 
        {
            get { return GetValue<string>("display_name", true); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public string SchemaDefinition 
        {
            get { return GetValue<string>("schema_definition", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
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

        }

        #region Subclasses

        #endregion
    }
}
