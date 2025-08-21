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

    public class OmnichannelOneTimeOrder : Resource 
    {
    
        public OmnichannelOneTimeOrder() { }

        public OmnichannelOneTimeOrder(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelOneTimeOrder(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelOneTimeOrder(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("omnichannel_one_time_orders", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static OmnichannelOneTimeOrderListRequest List()
        {
            string url = ApiUtil.BuildUrl("omnichannel_one_time_orders");
            return new OmnichannelOneTimeOrderListRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string AppId 
        {
            get { return GetValue<string>("app_id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string IdAtSource 
        {
            get { return GetValue<string>("id_at_source", true); }
        }
        public string Origin 
        {
            get { return GetValue<string>("origin", false); }
        }
        public SourceEnum Source 
        {
            get { return GetEnum<SourceEnum>("source", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public List<OmnichannelOneTimeOrderItem> OmnichannelOneTimeOrderItems 
        {
            get { return GetResourceList<OmnichannelOneTimeOrderItem>("omnichannel_one_time_order_items"); }
        }
        public OmnichannelOneTimeOrderOmnichannelTransaction PurchaseTransaction 
        {
            get { return GetSubResource<OmnichannelOneTimeOrderOmnichannelTransaction>("purchase_transaction"); }
        }
        
        #endregion
        
        #region Requests
        public class OmnichannelOneTimeOrderListRequest : ListRequestBase<OmnichannelOneTimeOrderListRequest> 
        {
            public OmnichannelOneTimeOrderListRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<OmnichannelOneTimeOrder.SourceEnum, OmnichannelOneTimeOrderListRequest> Source() 
            {
                return new EnumFilter<OmnichannelOneTimeOrder.SourceEnum, OmnichannelOneTimeOrderListRequest>("source", this);        
            }
            public StringFilter<OmnichannelOneTimeOrderListRequest> CustomerId() 
            {
                return new StringFilter<OmnichannelOneTimeOrderListRequest>("customer_id", this);        
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
        public class OmnichannelOneTimeOrderOmnichannelTransaction : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "purchase")]
                Purchase,
                [EnumMember(Value = "renewal")]
                Renewal,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string IdAtSource {
                get { return GetValue<string>("id_at_source", true); }
            }

            public string AppId {
                get { return GetValue<string>("app_id", true); }
            }

            public string PriceCurrency {
                get { return GetValue<string>("price_currency", false); }
            }

            public long? PriceUnits {
                get { return GetValue<long?>("price_units", false); }
            }

            public long? PriceNanos {
                get { return GetValue<long?>("price_nanos", false); }
            }

            public TypeEnum PurchaseTransactionType {
                get { return GetEnum<TypeEnum>("type", true); }
            }

            public DateTime? TransactedAt {
                get { return GetDateTime("transacted_at", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public long? ResourceVersion {
                get { return GetValue<long?>("resource_version", false); }
            }

        }

        #endregion
    }
}
