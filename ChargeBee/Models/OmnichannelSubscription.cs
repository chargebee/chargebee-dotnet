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
        public static OmnichannelSubscriptionListRequest List()
        {
            string url = ApiUtil.BuildUrl("omnichannel_subscriptions");
            return new OmnichannelSubscriptionListRequest(url);
        }
        public static ListRequest OmnichannelTransactionsForOmnichannelSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("omnichannel_subscriptions", CheckNull(id), "omnichannel_transactions");
            return new ListRequest(url);
        }
        public static MoveRequest Move(string id)
        {
            string url = ApiUtil.BuildUrl("omnichannel_subscriptions", CheckNull(id), "move");
            return new MoveRequest(url, HttpMethod.POST);
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
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public List<OmnichannelSubscriptionItem> OmnichannelSubscriptionItems 
        {
            get { return GetResourceList<OmnichannelSubscriptionItem>("omnichannel_subscription_items"); }
        }
        public OmnichannelTransaction InitialPurchaseTransaction 
        {
            get { return GetSubResource<OmnichannelTransaction>("initial_purchase_transaction"); }
        }
        
        #endregion
        
        #region Requests
        public class OmnichannelSubscriptionListRequest : ListRequestBase<OmnichannelSubscriptionListRequest> 
        {
            public OmnichannelSubscriptionListRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<OmnichannelSubscriptionItem.StatusEnum, OmnichannelSubscriptionListRequest> OmnichannelSubscriptionItemStatus() 
            {
                return new EnumFilter<OmnichannelSubscriptionItem.StatusEnum, OmnichannelSubscriptionListRequest>("omnichannel_subscription_item[status]", this);        
            }
            public StringFilter<OmnichannelSubscriptionListRequest> OmnichannelSubscriptionItemItemIdAtSource() 
            {
                return new StringFilter<OmnichannelSubscriptionListRequest>("omnichannel_subscription_item[item_id_at_source]", this);        
            }
            public EnumFilter<OmnichannelSubscription.SourceEnum, OmnichannelSubscriptionListRequest> Source() 
            {
                return new EnumFilter<OmnichannelSubscription.SourceEnum, OmnichannelSubscriptionListRequest>("source", this);        
            }
            public StringFilter<OmnichannelSubscriptionListRequest> CustomerId() 
            {
                return new StringFilter<OmnichannelSubscriptionListRequest>("customer_id", this);        
            }
        }
        public class MoveRequest : EntityRequest<MoveRequest> 
        {
            public MoveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public MoveRequest ToCustomerId(string toCustomerId) 
            {
                m_params.Add("to_customer_id", toCustomerId);
                return this;
            }
        }
        #endregion

        public enum SourceEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "apple_app_store")]
            AppleAppStore,
            [EnumMember(Value = "google_play_store")]
            GooglePlayStore,

        }

        #region Subclasses

        #endregion
    }
}
