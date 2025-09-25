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

    public class PersonalizedOffer : Resource 
    {
    
        public PersonalizedOffer() { }

        public PersonalizedOffer(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PersonalizedOffer(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PersonalizedOffer(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static PersonalizedOffersRequest PersonalizedOffers()
        {
            string url = ApiUtil.BuildUrl("personalized_offers");
            return new PersonalizedOffersRequest(url, HttpMethod.POST).SetSubDomain("grow").IsJsonRequest(true).SetIdempotent(false);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string OfferId 
        {
            get { return GetValue<string>("offer_id", true); }
        }
        public PersonalizedOfferContent Content 
        {
            get { return GetSubResource<PersonalizedOfferContent>("content"); }
        }
        public List<PersonalizedOfferOption> Options 
        {
            get { return GetResourceList<PersonalizedOfferOption>("options"); }
        }
        
        #endregion
        
        #region Requests
        public class PersonalizedOffersRequest : EntityRequest<PersonalizedOffersRequest> 
        {
            public PersonalizedOffersRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PersonalizedOffersRequest FirstName(string firstName) 
            {
                m_params.AddOpt("first_name", firstName);
                return this;
            }
            public PersonalizedOffersRequest LastName(string lastName) 
            {
                m_params.AddOpt("last_name", lastName);
                return this;
            }
            public PersonalizedOffersRequest Email(string email) 
            {
                m_params.AddOpt("email", email);
                return this;
            }
            public PersonalizedOffersRequest Roles(List<string> roles) 
            {
                m_params.AddOpt("roles", roles);
                return this;
            }
            public PersonalizedOffersRequest ExternalUserId(string externalUserId) 
            {
                m_params.AddOpt("external_user_id", externalUserId);
                return this;
            }
            public PersonalizedOffersRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public PersonalizedOffersRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public PersonalizedOffersRequest Custom(Dictionary<String, Object> custom) 
            {
                m_params.AddOpt("custom", custom);
                return this;
            }
            public PersonalizedOffersRequest RequestContext(RequestContextPersonalizedOffersInputParams data){
                m_params.Add("request_context", data.ToJObject(), false, true);
                return this;
            }
        
        }
        #endregion


        #region Subclasses
        public class PersonalizedOfferContent : Resource
        {

            public string Title {
                get { return GetValue<string>("title", true); }
            }

            public string Description {
                get { return GetValue<string>("description", true); }
            }

        }
        public class PersonalizedOfferOption : Resource
        {
            public enum ProcessingTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "billing_update")]
                BillingUpdate,
                [EnumMember(Value = "checkout")]
                Checkout,
                [EnumMember(Value = "url_redirect")]
                UrlRedirect,
                [EnumMember(Value = "webhook")]
                Webhook,
                [EnumMember(Value = "email")]
                Email,
            }
            public enum ProcessingLayoutEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "in_app")]
                InApp,
                [EnumMember(Value = "full_page")]
                FullPage,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string Label {
                get { return GetValue<string>("label", true); }
            }

            public ProcessingTypeEnum ProcessingType {
                get { return GetEnum<ProcessingTypeEnum>("processing_type", true); }
            }

            public ProcessingLayoutEnum ProcessingLayout {
                get { return GetEnum<ProcessingLayoutEnum>("processing_layout", true); }
            }

            public string RedirectUrl {
                get { return GetValue<string>("redirect_url", true); }
            }

        }

        public class RequestContextPersonalizedOffersInputParams { 
            public  string UserAgent { get; }
            public  string Locale { get; }
            public  string Timezone { get; }
            public  string Url { get; }
            public  string ReferrerUrl { get; }
            public RequestContextPersonalizedOffersInputParams(RequestContextPersonalizedOffersInputParamsBuilder builder){
                this.UserAgent = builder.GetUserAgent();
                this.Locale = builder.GetLocale();
                this.Timezone = builder.GetTimezone();
                this.Url = builder.GetUrl();
                this.ReferrerUrl = builder.GetReferrerUrl();
                
            }
            public JObject ToJObject()
            {
                return new JObject
                {
                    ["user_agent"] =  JToken.FromObject(this.UserAgent),
                    ["locale"] =  JToken.FromObject(this.Locale),
                    ["timezone"] =  JToken.FromObject(this.Timezone),
                    ["url"] =  JToken.FromObject(this.Url),
                    ["referrer_url"] =  JToken.FromObject(this.ReferrerUrl),
                    
                };
            }
        }
        public class RequestContextPersonalizedOffersInputParamsBuilder
        { 
            private string UserAgent; 
            private string Locale; 
            private string Timezone; 
            private string Url; 
            private string ReferrerUrl; 
    
            public RequestContextPersonalizedOffersInputParamsBuilder SetUserAgent (string UserAgent)
            {
                this.UserAgent = UserAgent;
                return this;
            } 
            public RequestContextPersonalizedOffersInputParamsBuilder SetLocale (string Locale)
            {
                this.Locale = Locale;
                return this;
            } 
            public RequestContextPersonalizedOffersInputParamsBuilder SetTimezone (string Timezone)
            {
                this.Timezone = Timezone;
                return this;
            } 
            public RequestContextPersonalizedOffersInputParamsBuilder SetUrl (string Url)
            {
                this.Url = Url;
                return this;
            } 
            public RequestContextPersonalizedOffersInputParamsBuilder SetReferrerUrl (string ReferrerUrl)
            {
                this.ReferrerUrl = ReferrerUrl;
                return this;
            } 

    
            public string GetUserAgent ()
            {
                return this.UserAgent;
            } 
            public string GetLocale ()
            {
                return this.Locale;
            } 
            public string GetTimezone ()
            {
                return this.Timezone;
            } 
            public string GetUrl ()
            {
                return this.Url;
            } 
            public string GetReferrerUrl ()
            {
                return this.ReferrerUrl;
            } 

            public RequestContextPersonalizedOffersInputParams Build() {
                return new RequestContextPersonalizedOffersInputParams(this);
            }

        }

        
        #endregion
    }
}
