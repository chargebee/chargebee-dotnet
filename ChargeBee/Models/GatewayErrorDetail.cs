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

    public class GatewayErrorDetail : Resource 
    {
    
        public GatewayErrorDetail() { }

        public GatewayErrorDetail(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public GatewayErrorDetail(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public GatewayErrorDetail(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string RequestId 
        {
            get { return GetValue<string>("request_id", false); }
        }
        public string ErrorCategory 
        {
            get { return GetValue<string>("error_category", false); }
        }
        public string ErrorCode 
        {
            get { return GetValue<string>("error_code", false); }
        }
        public string ErrorMessage 
        {
            get { return GetValue<string>("error_message", false); }
        }
        public string DeclineCode 
        {
            get { return GetValue<string>("decline_code", false); }
        }
        public string DeclineMessage 
        {
            get { return GetValue<string>("decline_message", false); }
        }
        public string NetworkErrorCode 
        {
            get { return GetValue<string>("network_error_code", false); }
        }
        public string NetworkErrorMessage 
        {
            get { return GetValue<string>("network_error_message", false); }
        }
        public string ErrorField 
        {
            get { return GetValue<string>("error_field", false); }
        }
        public string RecommendationCode 
        {
            get { return GetValue<string>("recommendation_code", false); }
        }
        public string RecommendationMessage 
        {
            get { return GetValue<string>("recommendation_message", false); }
        }
        public string ProcessorErrorCode 
        {
            get { return GetValue<string>("processor_error_code", false); }
        }
        public string ProcessorErrorMessage 
        {
            get { return GetValue<string>("processor_error_message", false); }
        }
        public string ErrorCauseId 
        {
            get { return GetValue<string>("error_cause_id", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
