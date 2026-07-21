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

    public class GrantBlock : Resource 
    {
    
        public GrantBlock() { }

        public GrantBlock(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public GrantBlock(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public GrantBlock(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static GrantBlockListGrantBlocksRequest ListGrantBlocks()
        {
            string url = ApiUtil.BuildUrl("grant_blocks");
            var request = new GrantBlockListGrantBlocksRequest(url);
            request.SetTelemetryResource("grantBlock");
            request.SetTelemetryOperation("listGrantBlocks");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string GrantedAmount 
        {
            get { return GetValue<string>("granted_amount", true); }
        }
        public DateTime EffectiveFrom 
        {
            get { return (DateTime)GetDateTime("effective_from", true); }
        }
        public DateTime ExpiresAt 
        {
            get { return (DateTime)GetDateTime("expires_at", true); }
        }
        public string Balance 
        {
            get { return GetValue<string>("balance", true); }
        }
        public string HoldAmount 
        {
            get { return GetValue<string>("hold_amount", true); }
        }
        public string UsedAmount 
        {
            get { return GetValue<string>("used_amount", true); }
        }
        public string ExpiredAmount 
        {
            get { return GetValue<string>("expired_amount", true); }
        }
        public string RolledOverAmount 
        {
            get { return GetValue<string>("rolled_over_amount", true); }
        }
        public string VoidedAmount 
        {
            get { return GetValue<string>("voided_amount", true); }
        }
        public string OriginGrantBlockId 
        {
            get { return GetValue<string>("origin_grant_block_id", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public GrantSourceEnum GrantSource 
        {
            get { return GetEnum<GrantSourceEnum>("grant_source", true); }
        }
        public DateTime? CreatedAt 
        {
            get { return GetDateTime("created_at", false); }
        }
        public AccountTypeEnum? AccountType 
        {
            get { return GetEnum<AccountTypeEnum>("account_type", false); }
        }
        public string UnitId 
        {
            get { return GetValue<string>("unit_id", false); }
        }
        public UnitTypeEnum? UnitType 
        {
            get { return GetEnum<UnitTypeEnum>("unit_type", false); }
        }
        public JToken Metadata 
        {
            get { return GetJToken("metadata", false); }
        }
        
        #endregion
        
        #region Requests
        public class GrantBlockListGrantBlocksRequest : ListRequestBase<GrantBlockListGrantBlocksRequest> 
        {
            public GrantBlockListGrantBlocksRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<GrantBlockListGrantBlocksRequest> SubscriptionId() 
            {
                return new StringFilter<GrantBlockListGrantBlocksRequest>("subscription_id", this);        
            }
            public StringFilter<GrantBlockListGrantBlocksRequest> UnitId() 
            {
                return new StringFilter<GrantBlockListGrantBlocksRequest>("unit_id", this);        
            }
            public TimestampFilter<GrantBlockListGrantBlocksRequest> EffectiveFrom() 
            {
                return new TimestampFilter<GrantBlockListGrantBlocksRequest>("effective_from", this);        
            }
            public TimestampFilter<GrantBlockListGrantBlocksRequest> ExpiresAt() 
            {
                return new TimestampFilter<GrantBlockListGrantBlocksRequest>("expires_at", this);        
            }
            public TimestampFilter<GrantBlockListGrantBlocksRequest> CreatedAt() 
            {
                return new TimestampFilter<GrantBlockListGrantBlocksRequest>("created_at", this);        
            }
            
            public GrantBlockListGrantBlocksRequest SortByEffectiveFrom(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","effective_from");
                return this;
            }
            public GrantBlockListGrantBlocksRequest SortByExpiresAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","expires_at");
                return this;
            }
            public GrantBlockListGrantBlocksRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
        }
        #endregion

        public enum GrantSourceEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "subscription_created")]
            SubscriptionCreated,
            [EnumMember(Value = "subscription_changed")]
            SubscriptionChanged,
            [EnumMember(Value = "top_up")]
            TopUp,
            [EnumMember(Value = "promotional_grants")]
            PromotionalGrants,
            [EnumMember(Value = "rollover")]
            Rollover,

        }
        public enum AccountTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "provisioned")]
            Provisioned,
            [EnumMember(Value = "overdraft")]
            Overdraft,

        }
        public enum UnitTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "credit_unit")]
            CreditUnit,

        }

        #region Subclasses

        #endregion
    }
}
