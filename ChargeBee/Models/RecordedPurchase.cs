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

    public class RecordedPurchase : Resource 
    {
    
        public RecordedPurchase() { }

        public RecordedPurchase(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public RecordedPurchase(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public RecordedPurchase(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("recorded_purchases");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("recorded_purchases", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string AppId 
        {
            get { return GetValue<string>("app_id", true); }
        }
        public SourceEnum Source 
        {
            get { return GetEnum<SourceEnum>("source", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string OmnichannelTransactionId 
        {
            get { return GetValue<string>("omnichannel_transaction_id", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public List<RecordedPurchaseLinkedOmnichannelSubscription> LinkedOmnichannelSubscriptions 
        {
            get { return GetResourceList<RecordedPurchaseLinkedOmnichannelSubscription>("linked_omnichannel_subscriptions"); }
        }
        public RecordedPurchaseErrorDetail ErrorDetail 
        {
            get { return GetSubResource<RecordedPurchaseErrorDetail>("error_detail"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest AppId(string appId) 
            {
                m_params.Add("app_id", appId);
                return this;
            }
            public CreateRequest CustomerId(string customerId) 
            {
                m_params.Add("customer[id]", customerId);
                return this;
            }
            public CreateRequest AppleAppStoreTransactionId(string appleAppStoreTransactionId) 
            {
                m_params.AddOpt("apple_app_store[transaction_id]", appleAppStoreTransactionId);
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

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "in_process")]
            InProcess,
            [EnumMember(Value = "completed")]
            Completed,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class RecordedPurchaseLinkedOmnichannelSubscription : Resource
        {

            public string OmnichannelSubscriptionId {
                get { return GetValue<string>("omnichannel_subscription_id", false); }
            }

        }
        public class RecordedPurchaseErrorDetail : Resource
        {

            public string ErrorMessage {
                get { return GetValue<string>("error_message", false); }
            }

        }

        #endregion
    }
}
