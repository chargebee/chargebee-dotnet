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

    public class OmnichannelOneTimeOrderItem : Resource 
    {
    
        public OmnichannelOneTimeOrderItem() { }

        public OmnichannelOneTimeOrderItem(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelOneTimeOrderItem(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelOneTimeOrderItem(String jsonString)
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
        public string ItemIdAtSource 
        {
            get { return GetValue<string>("item_id_at_source", true); }
        }
        public string ItemTypeAtSource 
        {
            get { return GetValue<string>("item_type_at_source", false); }
        }
        public int? Quantity 
        {
            get { return GetValue<int?>("quantity", false); }
        }
        public DateTime? CancelledAt 
        {
            get { return GetDateTime("cancelled_at", false); }
        }
        public CancellationReasonEnum? CancellationReason 
        {
            get { return GetEnum<CancellationReasonEnum>("cancellation_reason", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        
        #endregion
        

        public enum CancellationReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "customer_cancelled")]
            CustomerCancelled,
            [EnumMember(Value = "customer_did_not_consent_to_price_increase")]
            CustomerDidNotConsentToPriceIncrease,
            [EnumMember(Value = "refunded_due_to_app_issue")]
            RefundedDueToAppIssue,
            [EnumMember(Value = "refunded_for_other_reason")]
            RefundedForOtherReason,
            [EnumMember(Value = "merchant_revoked")]
            MerchantRevoked,

        }

        #region Subclasses

        #endregion
    }
}
