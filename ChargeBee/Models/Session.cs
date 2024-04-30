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

    public class Session : Resource 
    {
    
        public Session() { }

        public Session(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Session(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Session(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("sessions");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("sessions", CheckNull(id));
            return new RetrieveRequest(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ExpiresAt 
        {
            get { return (DateTime)GetDateTime("expires_at", true); }
        }
        public SessionContent Content
        {
            get
            {
                if(GetValue<JToken>("content", false) == null)
                {
                    return null;
                }
                return new SessionContent(GetValue<JToken>("content"));
            }
        }
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public CreateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
        }
        #endregion


        #region Subclasses
        public class SessionContent : ResultBase
        {

            public SessionContent () { }

            internal SessionContent(JToken jobj)
            {
                m_jobj = jobj;
            }
        }

        #endregion
    }
}
