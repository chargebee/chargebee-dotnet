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

    public class EmailLog : Resource 
    {
    
        public EmailLog() { }

        public EmailLog(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public EmailLog(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public EmailLog(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EmailLogEmailLogsForCustomerRequest EmailLogsForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "email_logs");
            var request = new EmailLogEmailLogsForCustomerRequest(url);
            request.SetTelemetryResource("emailLog");
            request.SetTelemetryOperation("emailLogsForCustomer");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string TemplateName 
        {
            get { return GetValue<string>("template_name", false); }
        }
        public string FromAddress 
        {
            get { return GetValue<string>("from_address", true); }
        }
        public string ToAddress 
        {
            get { return GetValue<string>("to_address", true); }
        }
        public string Subject 
        {
            get { return GetValue<string>("subject", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? SentOn 
        {
            get { return GetDateTime("sent_on", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string SiteId 
        {
            get { return GetValue<string>("site_id", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
        }
        public string BrandId 
        {
            get { return GetValue<string>("brand_id", false); }
        }
        public string ErrorMessage 
        {
            get { return GetValue<string>("error_message", false); }
        }
        
        #endregion
        
        #region Requests
        public class EmailLogEmailLogsForCustomerRequest : ListRequestBase<EmailLogEmailLogsForCustomerRequest> 
        {
            public EmailLogEmailLogsForCustomerRequest(string url) 
                    : base(url)
            {
            }

            public TimestampFilter<EmailLogEmailLogsForCustomerRequest> SentOn() 
            {
                return new TimestampFilter<EmailLogEmailLogsForCustomerRequest>("sent_on", this);        
            }
            public StringFilter<EmailLogEmailLogsForCustomerRequest> BusinessEntityId() 
            {
                return new StringFilter<EmailLogEmailLogsForCustomerRequest>("business_entity_id", this);        
            }
            public StringFilter<EmailLogEmailLogsForCustomerRequest> BrandId() 
            {
                return new StringFilter<EmailLogEmailLogsForCustomerRequest>("brand_id", this);        
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
