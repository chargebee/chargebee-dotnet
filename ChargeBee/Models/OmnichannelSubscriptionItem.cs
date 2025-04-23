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

    public class OmnichannelSubscriptionItem : Resource 
    {
    
        public OmnichannelSubscriptionItem() { }

        public OmnichannelSubscriptionItem(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelSubscriptionItem(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelSubscriptionItem(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static ListRequest ListOmniSubItemScheduleChanges(string id)
        {
            string url = ApiUtil.BuildUrl("omnichannel_subscription_items", CheckNull(id), "scheduled_changes");
            return new ListRequest(url);
        }
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
        public string ItemParentIdAtSource 
        {
            get { return GetValue<string>("item_parent_id_at_source", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public AutoRenewStatusEnum? AutoRenewStatus 
        {
            get { return GetEnum<AutoRenewStatusEnum>("auto_renew_status", false); }
        }
        public DateTime? CurrentTermStart 
        {
            get { return GetDateTime("current_term_start", false); }
        }
        public DateTime? CurrentTermEnd 
        {
            get { return GetDateTime("current_term_end", false); }
        }
        public DateTime? ExpiredAt 
        {
            get { return GetDateTime("expired_at", false); }
        }
        public ExpirationReasonEnum? ExpirationReason 
        {
            get { return GetEnum<ExpirationReasonEnum>("expiration_reason", false); }
        }
        public DateTime? CancelledAt 
        {
            get { return GetDateTime("cancelled_at", false); }
        }
        public CancellationReasonEnum? CancellationReason 
        {
            get { return GetEnum<CancellationReasonEnum>("cancellation_reason", false); }
        }
        public DateTime? GracePeriodExpiresAt 
        {
            get { return GetDateTime("grace_period_expires_at", false); }
        }
        public bool HasScheduledChanges 
        {
            get { return GetValue<bool>("has_scheduled_changes", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public OmnichannelSubscriptionItemUpcomingRenewal UpcomingRenewal 
        {
            get { return GetSubResource<OmnichannelSubscriptionItemUpcomingRenewal>("upcoming_renewal"); }
        }
        
        #endregion
        

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
            [EnumMember(Value = "in_dunning")]
            InDunning,
            [EnumMember(Value = "in_grace_period")]
            InGracePeriod,

        }
        public enum AutoRenewStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "off")]
            Off,
            [EnumMember(Value = "on")]
            On,

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
            [EnumMember(Value = "refunded_due_to_app_issue")]
            RefundedDueToAppIssue,
            [EnumMember(Value = "refunded_for_other_reason")]
            RefundedForOtherReason,

        }

        #region Subclasses
        public class OmnichannelSubscriptionItemUpcomingRenewal : Resource
        {

            public string PriceCurrency {
                get { return GetValue<string>("price_currency", false); }
            }

            public long? PriceUnits {
                get { return GetValue<long?>("price_units", false); }
            }

            public long? PriceNanos {
                get { return GetValue<long?>("price_nanos", false); }
            }

        }

        #endregion
    }
}
