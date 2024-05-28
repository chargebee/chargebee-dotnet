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

    public class BusinessEntityTransfer : Resource 
    {
    
        public BusinessEntityTransfer() { }

        public BusinessEntityTransfer(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public BusinessEntityTransfer(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public BusinessEntityTransfer(String jsonString)
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
        public ResourceTypeEnum ResourceType 
        {
            get { return GetEnum<ResourceTypeEnum>("resource_type", true); }
        }
        public string ResourceId 
        {
            get { return GetValue<string>("resource_id", true); }
        }
        public string ActiveResourceId 
        {
            get { return GetValue<string>("active_resource_id", true); }
        }
        public string DestinationBusinessEntityId 
        {
            get { return GetValue<string>("destination_business_entity_id", true); }
        }
        public string SourceBusinessEntityId 
        {
            get { return GetValue<string>("source_business_entity_id", true); }
        }
        public ReasonCodeEnum ReasonCode 
        {
            get { return GetEnum<ReasonCodeEnum>("reason_code", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        
        #endregion
        

        public enum ResourceTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "customer")]
            Customer,
            [EnumMember(Value = "subscription")]
            Subscription,

        }
        public enum ReasonCodeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "correction")]
            Correction,

        }

        #region Subclasses

        #endregion
    }
}
