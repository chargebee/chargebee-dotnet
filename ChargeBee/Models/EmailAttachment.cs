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

    public class EmailAttachment : Resource 
    {
    
        public EmailAttachment() { }

        public EmailAttachment(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public EmailAttachment(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public EmailAttachment(String jsonString)
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
        public string EmailMessageId 
        {
            get { return GetValue<string>("email_message_id", false); }
        }
        public string FileName 
        {
            get { return GetValue<string>("file_name", false); }
        }
        public string ContentType 
        {
            get { return GetValue<string>("content_type", false); }
        }
        public long? SizeBytes 
        {
            get { return GetValue<long?>("size_bytes", false); }
        }
        public string ContentDisposition 
        {
            get { return GetValue<string>("content_disposition", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
