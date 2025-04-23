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

    public class OmnichannelSubscriptionItemScheduledChange : Resource 
    {
    
        public OmnichannelSubscriptionItemScheduledChange() { }

        public OmnichannelSubscriptionItemScheduledChange(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelSubscriptionItemScheduledChange(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelSubscriptionItemScheduledChange(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public string OmnichannelSubscriptionItemId 
        {
            get { return GetValue<string>("omnichannel_subscription_item_id", false); }
        }
        public DateTime ScheduledAt 
        {
            get { return (DateTime)GetDateTime("scheduled_at", true); }
        }
        public ChangeTypeEnum ChangeType 
        {
            get { return GetEnum<ChangeTypeEnum>("change_type", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public OmnichannelSubscriptionItemScheduledChangeCurrentState CurrentState 
        {
            get { return GetSubResource<OmnichannelSubscriptionItemScheduledChangeCurrentState>("current_state"); }
        }
        public OmnichannelSubscriptionItemScheduledChangeScheduledState ScheduledState 
        {
            get { return GetSubResource<OmnichannelSubscriptionItemScheduledChangeScheduledState>("scheduled_state"); }
        }
        
        #endregion
        

        public enum ChangeTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "downgrade")]
            Downgrade,

        }

        #region Subclasses
        public class OmnichannelSubscriptionItemScheduledChangeCurrentState : Resource
        {

            public string ItemIdAtSource {
                get { return GetValue<string>("item_id_at_source", false); }
            }

        }
        public class OmnichannelSubscriptionItemScheduledChangeScheduledState : Resource
        {

            public string ItemIdAtSource {
                get { return GetValue<string>("item_id_at_source", false); }
            }

        }

        #endregion
    }
}
