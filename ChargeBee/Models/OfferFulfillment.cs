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

    public class OfferFulfillment : Resource 
    {
    
        public OfferFulfillment() { }

        public OfferFulfillment(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OfferFulfillment(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OfferFulfillment(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static OfferFulfillmentsRequest OfferFulfillments()
        {
            string url = ApiUtil.BuildUrl("offer_fulfillments");
            return new OfferFulfillmentsRequest(url, HttpMethod.POST).SetSubDomain("grow").IsJsonRequest(true).SetIdempotent(false);
        }
        public static OfferFulfillmentsGetRequest OfferFulfillmentsGet(string id)
        {
            string url = ApiUtil.BuildUrl("offer_fulfillments", CheckNull(id));
            return new OfferFulfillmentsGetRequest(url, HttpMethod.GET).SetSubDomain("grow").IsJsonRequest(true);
        }
        public static OfferFulfillmentsUpdateRequest OfferFulfillmentsUpdate(string id)
        {
            string url = ApiUtil.BuildUrl("offer_fulfillments", CheckNull(id));
            return new OfferFulfillmentsUpdateRequest(url, HttpMethod.POST).SetSubDomain("grow").IsJsonRequest(true).SetIdempotent(false);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string PersonalizedOfferId 
        {
            get { return GetValue<string>("personalized_offer_id", true); }
        }
        public string OptionId 
        {
            get { return GetValue<string>("option_id", true); }
        }
        public ProcessingTypeEnum ProcessingType 
        {
            get { return GetEnum<ProcessingTypeEnum>("processing_type", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string RedirectUrl 
        {
            get { return GetValue<string>("redirect_url", false); }
        }
        public DateTime? FailedAt 
        {
            get { return GetDateTime("failed_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? CompletedAt 
        {
            get { return GetDateTime("completed_at", false); }
        }
        public OfferFulfillmentError Error 
        {
            get { return GetSubResource<OfferFulfillmentError>("error"); }
        }
        
        #endregion
        
        #region Requests
        public class OfferFulfillmentsRequest : EntityRequest<OfferFulfillmentsRequest> 
        {
            public OfferFulfillmentsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public OfferFulfillmentsRequest PersonalizedOfferId(string personalizedOfferId) 
            {
                m_params.Add("personalized_offer_id", personalizedOfferId);
                return this;
            }
            public OfferFulfillmentsRequest OptionId(string optionId) 
            {
                m_params.Add("option_id", optionId);
                return this;
            }
        
        }
        public class OfferFulfillmentsGetRequest : EntityRequest<OfferFulfillmentsGetRequest> 
        {
            public OfferFulfillmentsGetRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        
        }
        public class OfferFulfillmentsUpdateRequest : EntityRequest<OfferFulfillmentsUpdateRequest> 
        {
            public OfferFulfillmentsUpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public OfferFulfillmentsUpdateRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
            public OfferFulfillmentsUpdateRequest Status(OfferFulfillment.StatusEnum status) 
            {
                m_params.Add("status", status);
                return this;
            }
            public OfferFulfillmentsUpdateRequest FailureReason(string failureReason) 
            {
                m_params.AddOpt("failure_reason", failureReason);
                return this;
            }
        
        }
        #endregion

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
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "in_progress")]
            InProgress,
            [EnumMember(Value = "completed")]
            Completed,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class OfferFulfillmentError : Resource
        {
            public enum CodeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "billing_update_failed")]
                BillingUpdateFailed,
                [EnumMember(Value = "checkout_abandoned")]
                CheckoutAbandoned,
                [EnumMember(Value = "external_fulfillment_failed")]
                ExternalFulfillmentFailed,
                [EnumMember(Value = "internal_error")]
                InternalError,
                [EnumMember(Value = "fulfillment_expired")]
                FulfillmentExpired,
            }

            public CodeEnum Code {
                get { return GetEnum<CodeEnum>("code", true); }
            }

            public string Message {
                get { return GetValue<string>("message", true); }
            }

        }

        
        
        
        #endregion
    }
}
