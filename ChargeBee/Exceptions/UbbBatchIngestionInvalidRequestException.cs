using System;
using System.Collections.Generic;
using System.Net;

using ChargeBee.Api;
using Newtonsoft.Json.Linq;

namespace ChargeBee.Exceptions
{
    public class UbbBatchIngestionInvalidRequestException : ApiException
    {
        private JObject ErrorJson;
    
        public string BatchId { get; set;}
    
        public JArray FailedEvents { get; set;}
    

        public UbbBatchIngestionInvalidRequestException(HttpStatusCode httpStatusCode, JObject errorJson)
            : base(httpStatusCode, errorJson)
        {
            this.ErrorJson = errorJson;
            
            this.BatchId = GetValue<string>("batch_id", false);
            
            this.FailedEvents = GetJArray("failed_events", false);
            
        }

        private T GetValue<T>(string key, bool required = true)
        {
            if(ErrorJson[key] == null){
                return default(T);
            }
            return ErrorJson[key].ToObject<T>();
        }

        private JArray GetJArray(String key, bool required = true)
        {
            if(ErrorJson[key] == null) {
                return null;
            }
            return JArray.Parse(ErrorJson[key].ToString());
        }
    }
}