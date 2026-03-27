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

    public class AlertStatus : Resource 
    {
    
        public AlertStatus() { }

        public AlertStatus(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public AlertStatus(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public AlertStatus(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string AlertId 
        {
            get { return GetValue<string>("alert_id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public AlertStatusEnum AlertStatusAlertStatus 
        {
            get { return GetEnum<AlertStatusEnum>("alert_status", true); }
        }
        public DateTime? AlarmTriggeredAt 
        {
            get { return GetDateTime("alarm_triggered_at", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
