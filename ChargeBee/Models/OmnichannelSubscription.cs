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

    public class OmnichannelSubscription : Resource 
    {
    
        public OmnichannelSubscription() { }

        public OmnichannelSubscription(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelSubscription(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelSubscription(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("omnichannel_subscriptions", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("omnichannel_subscriptions");
            return new ListRequest(url);
        }
        public static ListRequest OmnichannelTransactionsForOmnichannelSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("omnichannel_subscriptions", CheckNull(id), "omnichannel_transactions");
            return new ListRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string IdAtSource 
        {
            get { return GetValue<string>("id_at_source", true); }
        }
        public string AppId 
        {
            get { return GetValue<string>("app_id", true); }
        }
        public SourceEnum Source 
        {
            get { return GetEnum<SourceEnum>("source", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public List<OmnichannelSubscriptionOmnichannelSubscriptionItem> OmnichannelSubscriptionItems 
        {
            get { return GetResourceList<OmnichannelSubscriptionOmnichannelSubscriptionItem>("omnichannel_subscription_items"); }
        }
        
        #endregion
        

        public enum SourceEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "apple_app_store")]
            AppleAppStore,

        }

        #region Subclasses
        public class OmnichannelSubscriptionOmnichannelSubscriptionItem : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "active")]
                Active,
                [EnumMember(Value = "expired")]
                Expired,
                [EnumMember(Value = "cancelled")]
                Cancelled,
            }
            public enum ExpirationReasonEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "billing_error")]
                BillingError,
                [EnumMember(Value = "product_not_available")]
                ProductNotAvailable,
                [EnumMember(Value = "other")]
                Other,
            }
            public enum CancellationReasonEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "customer_cancelled")]
                CustomerCancelled,
                [EnumMember(Value = "customer_did_not_consent_to_price_increase")]
                CustomerDidNotConsentToPriceIncrease,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string IdAtSource {
                get { return GetValue<string>("id_at_source", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public DateTime? CurrentTermStart {
                get { return GetDateTime("current_term_start", false); }
            }

            public DateTime? CurrentTermEnd {
                get { return GetDateTime("current_term_end", false); }
            }

            public DateTime? ExpiredAt {
                get { return GetDateTime("expired_at", false); }
            }

            public ExpirationReasonEnum? ExpirationReason {
                get { return GetEnum<ExpirationReasonEnum>("expiration_reason", false); }
            }

            public DateTime? CancelledAt {
                get { return GetDateTime("cancelled_at", false); }
            }

            public CancellationReasonEnum? CancellationReason {
                get { return GetEnum<CancellationReasonEnum>("cancellation_reason", false); }
            }

        }

        #endregion
    }
}
