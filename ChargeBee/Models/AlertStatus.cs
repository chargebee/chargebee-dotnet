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
        public static AlertStatusAlertStatusesForSubscriptionRequest AlertStatusesForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "alert_statuses");
            return new AlertStatusAlertStatusesForSubscriptionRequest(url);
        }
        public static AlertStatusAlertStatusesForAlertRequest AlertStatusesForAlert(string id)
        {
            string url = ApiUtil.BuildUrl("alerts", CheckNull(id), "alert_statuses");
            return new AlertStatusAlertStatusesForAlertRequest(url);
        }
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
        public AlarmStatusEnum AlarmStatus 
        {
            get { return GetEnum<AlarmStatusEnum>("alarm_status", true); }
        }
        public DateTime? AlarmTriggeredAt 
        {
            get { return GetDateTime("alarm_triggered_at", false); }
        }
        
        #endregion
        
        #region Requests
        public class AlertStatusAlertStatusesForSubscriptionRequest : ListRequestBase<AlertStatusAlertStatusesForSubscriptionRequest> 
        {
            public AlertStatusAlertStatusesForSubscriptionRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<ChargeBee.Models.Enums.AlarmStatusEnum, AlertStatusAlertStatusesForSubscriptionRequest> AlarmStatus() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.AlarmStatusEnum, AlertStatusAlertStatusesForSubscriptionRequest>("alarm_status", this).SupportsMultiOperators(true);        
            }
            public StringFilter<AlertStatusAlertStatusesForSubscriptionRequest> AlertId() 
            {
                return new StringFilter<AlertStatusAlertStatusesForSubscriptionRequest>("alert_id", this).SupportsMultiOperators(true);        
            }
        }
        public class AlertStatusAlertStatusesForAlertRequest : ListRequestBase<AlertStatusAlertStatusesForAlertRequest> 
        {
            public AlertStatusAlertStatusesForAlertRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<ChargeBee.Models.Enums.AlarmStatusEnum, AlertStatusAlertStatusesForAlertRequest> AlarmStatus() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.AlarmStatusEnum, AlertStatusAlertStatusesForAlertRequest>("alarm_status", this).SupportsMultiOperators(true);        
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
