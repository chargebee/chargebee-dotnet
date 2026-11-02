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

    public class EmailMessage : Resource 
    {
    
        public EmailMessage() { }

        public EmailMessage(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public EmailMessage(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public EmailMessage(String jsonString)
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
        public string EmailConversationId 
        {
            get { return GetValue<string>("email_conversation_id", false); }
        }
        public string MessageType 
        {
            get { return GetValue<string>("message_type", false); }
        }
        public AuthorTypeEnum? AuthorType 
        {
            get { return GetEnum<AuthorTypeEnum>("author_type", false); }
        }
        public SendStatusEnum? SendStatus 
        {
            get { return GetEnum<SendStatusEnum>("send_status", false); }
        }
        public string ContentHtml 
        {
            get { return GetValue<string>("content_html", false); }
        }
        public string ContentText 
        {
            get { return GetValue<string>("content_text", false); }
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
        public string MailboxId 
        {
            get { return GetValue<string>("mailbox_id", false); }
        }
        public string AuthorId 
        {
            get { return GetValue<string>("author_id", false); }
        }
        public string AuthorName 
        {
            get { return GetValue<string>("author_name", false); }
        }
        public string FromEmail 
        {
            get { return GetValue<string>("from_email", false); }
        }
        public List<string> ToEmails 
        {
            get { return GetList<string>("to_emails"); }
        }
        public List<string> CcEmails 
        {
            get { return GetList<string>("cc_emails"); }
        }
        public List<EmailMessageAttachment> Attachments 
        {
            get { return GetResourceList<EmailMessageAttachment>("attachments"); }
        }
        
        #endregion
        

        public enum AuthorTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "contact")]
            Contact,
            [EnumMember(Value = "site_user")]
            SiteUser,
            [EnumMember(Value = "agent")]
            Agent,
            [EnumMember(Value = "other")]
            Other,

        }
        public enum SendStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "pending")]
            Pending,
            [EnumMember(Value = "sent")]
            Sent,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class EmailMessageAttachment : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string EmailMessageId {
                get { return GetValue<string>("email_message_id", false); }
            }

            public string FileName {
                get { return GetValue<string>("file_name", false); }
            }

            public string ContentType {
                get { return GetValue<string>("content_type", false); }
            }

            public long? SizeBytes {
                get { return GetValue<long?>("size_bytes", false); }
            }

            public string ContentDisposition {
                get { return GetValue<string>("content_disposition", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public DateTime UpdatedAt {
                get { return (DateTime)GetDateTime("updated_at", true); }
            }

            public long? ResourceVersion {
                get { return GetValue<long?>("resource_version", false); }
            }

        }

        #endregion
    }
}
