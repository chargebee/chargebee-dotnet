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

    public class PrivateNote : Resource 
    {
    
        public PrivateNote() { }

        public PrivateNote(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PrivateNote(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PrivateNote(String jsonString)
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
            get { return GetValue<string>("email_conversation_id", true); }
        }
        public AuthorTypeEnum? AuthorType 
        {
            get { return GetEnum<AuthorTypeEnum>("author_type", false); }
        }
        public string AuthorId 
        {
            get { return GetValue<string>("author_id", false); }
        }
        public string AuthorName 
        {
            get { return GetValue<string>("author_name", false); }
        }
        public string ContentHtml 
        {
            get { return GetValue<string>("content_html", true); }
        }
        public string ContentText 
        {
            get { return GetValue<string>("content_text", false); }
        }
        public string MetaData 
        {
            get { return GetValue<string>("meta_data", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        
        #endregion
        

        public enum AuthorTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "site_user")]
            SiteUser,
            [EnumMember(Value = "agent")]
            Agent,
            [EnumMember(Value = "other")]
            Other,

        }

        #region Subclasses

        #endregion
    }
}
