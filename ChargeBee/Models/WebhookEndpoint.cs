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

    public class WebhookEndpoint : Resource 
    {
    
        public WebhookEndpoint() { }

        public WebhookEndpoint(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public WebhookEndpoint(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public WebhookEndpoint(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("webhook_endpoints");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("webhook_endpoints", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("webhook_endpoints", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("webhook_endpoints", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("webhook_endpoints");
            return new ListRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", true); }
        }
        public string Url 
        {
            get { return GetValue<string>("url", true); }
        }
        public bool? SendCardResource 
        {
            get { return GetValue<bool?>("send_card_resource", false); }
        }
        public bool Disabled 
        {
            get { return GetValue<bool>("disabled", true); }
        }
        public bool PrimaryUrl 
        {
            get { return GetValue<bool>("primary_url", true); }
        }
        public ApiVersionEnum ApiVersion 
        {
            get { return GetEnum<ApiVersionEnum>("api_version", true); }
        }
        public ChargebeeResponseSchemaTypeEnum? ChargebeeResponseSchemaType 
        {
            get { return GetEnum<ChargebeeResponseSchemaTypeEnum>("chargebee_response_schema_type", false); }
        }
        public List<EventTypeEnum> EnabledEvents 
        {
            get { return GetList<EventTypeEnum>("enabled_events"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public CreateRequest ApiVersion(WebhookEndpoint.ApiVersionEnum apiVersion) 
            {
                m_params.AddOpt("api_version", apiVersion);
                return this;
            }
            public CreateRequest Url(string url) 
            {
                m_params.Add("url", url);
                return this;
            }
            public CreateRequest PrimaryUrl(bool primaryUrl) 
            {
                m_params.AddOpt("primary_url", primaryUrl);
                return this;
            }
            public CreateRequest Disabled(bool disabled) 
            {
                m_params.AddOpt("disabled", disabled);
                return this;
            }
            public CreateRequest BasicAuthPassword(string basicAuthPassword) 
            {
                m_params.AddOpt("basic_auth_password", basicAuthPassword);
                return this;
            }
            public CreateRequest BasicAuthUsername(string basicAuthUsername) 
            {
                m_params.AddOpt("basic_auth_username", basicAuthUsername);
                return this;
            }
            public CreateRequest SendCardResource(bool sendCardResource) 
            {
                m_params.AddOpt("send_card_resource", sendCardResource);
                return this;
            }
            public CreateRequest ChargebeeResponseSchemaType(ChargeBee.Models.Enums.ChargebeeResponseSchemaTypeEnum chargebeeResponseSchemaType) 
            {
                m_params.AddOpt("chargebee_response_schema_type", chargebeeResponseSchemaType);
                return this;
            }
            public CreateRequest EnabledEvents(List<EventTypeEnum> enabledEvents) 
            {
                m_params.AddOpt("enabled_events", enabledEvents);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateRequest ApiVersion(WebhookEndpoint.ApiVersionEnum apiVersion) 
            {
                m_params.AddOpt("api_version", apiVersion);
                return this;
            }
            public UpdateRequest Url(string url) 
            {
                m_params.AddOpt("url", url);
                return this;
            }
            public UpdateRequest PrimaryUrl(bool primaryUrl) 
            {
                m_params.AddOpt("primary_url", primaryUrl);
                return this;
            }
            public UpdateRequest SendCardResource(bool sendCardResource) 
            {
                m_params.AddOpt("send_card_resource", sendCardResource);
                return this;
            }
            public UpdateRequest BasicAuthPassword(string basicAuthPassword) 
            {
                m_params.AddOpt("basic_auth_password", basicAuthPassword);
                return this;
            }
            public UpdateRequest BasicAuthUsername(string basicAuthUsername) 
            {
                m_params.AddOpt("basic_auth_username", basicAuthUsername);
                return this;
            }
            public UpdateRequest Disabled(bool disabled) 
            {
                m_params.AddOpt("disabled", disabled);
                return this;
            }
            public UpdateRequest EnabledEvents(List<EventTypeEnum> enabledEvents) 
            {
                m_params.AddOpt("enabled_events", enabledEvents);
                return this;
            }
        }
        #endregion

        public enum ApiVersionEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "v1")]
            V1,
            [EnumMember(Value = "v2")]
            V2,

        }

        #region Subclasses

        #endregion
    }
}
