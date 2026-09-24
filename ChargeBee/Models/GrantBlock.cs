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
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string UnitId 
        {
            get { return GetValue<string>("unit_id", true); }
        }
        public UnitTypeEnum UnitType 
        {
            get { return GetEnum<UnitTypeEnum>("unit_type", true); }
        }
        public AccountTypeEnum AccountType 
        {
            get { return GetEnum<AccountTypeEnum>("account_type", true); }
        }
        [Obsolete]
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
        [Obsolete]
        public string Balance 
        {
            get { return GetValue<string>("balance", true); }
        }
        [Obsolete]
        public string HoldAmount 
        {
            get { return GetValue<string>("hold_amount", true); }
        }
        [Obsolete]
        public string UsedAmount 
        {
            get { return GetValue<string>("used_amount", true); }
        }
        [Obsolete]
        public string ExpiredAmount 
        {
            get { return GetValue<string>("expired_amount", false); }
        }
        [Obsolete]
        public string RolledOverAmount 
        {
            get { return GetValue<string>("rolled_over_amount", false); }
        }
        [Obsolete]
        public string VoidedAmount 
        {
            get { return GetValue<string>("voided_amount", false); }
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
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public GrantBlockProvisionedBlockBalance ProvisionedBlockBalance 
        {
            get { return GetSubResource<GrantBlockProvisionedBlockBalance>("provisioned_block_balance"); }
        }
        public GrantBlockOverdraftBlockBalance OverdraftBlockBalance 
        {
            get { return GetSubResource<GrantBlockOverdraftBlockBalance>("overdraft_block_balance"); }
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
            public EnumFilter<AccountTypeEnum, GrantBlockListGrantBlocksRequest> AccountType() 
            {
                return new EnumFilter<AccountTypeEnum, GrantBlockListGrantBlocksRequest>("account_type", this);        
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

        public enum UnitTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "credit_unit")]
            CreditUnit,

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
            [EnumMember(Value = "grant_renewal")]
            GrantRenewal,
            [EnumMember(Value = "subscription_renewed")]
            SubscriptionRenewed,

        }

        #region Subclasses
        public class GrantBlockProvisionedBlockBalance : Resource
        {

            public string GrantedAmount {
                get { return GetValue<string>("granted_amount", false); }
            }

            public string TotalBalance {
                get { return GetValue<string>("total_balance", false); }
            }

            public string UsableBalance {
                get { return GetValue<string>("usable_balance", false); }
            }

            public string HoldAmount {
                get { return GetValue<string>("hold_amount", false); }
            }

            public string UsedAmount {
                get { return GetValue<string>("used_amount", false); }
            }

            public string ExpiredAmount {
                get { return GetValue<string>("expired_amount", false); }
            }

            public string RolledOverAmount {
                get { return GetValue<string>("rolled_over_amount", false); }
            }

            public string VoidedAmount {
                get { return GetValue<string>("voided_amount", false); }
            }

        }
        public class GrantBlockOverdraftBlockBalance : Resource
        {

            public bool IsUnlimited {
                get { return GetValue<bool>("is_unlimited", true); }
            }

            public string Limit {
                get { return GetValue<string>("limit", false); }
            }

            public string TotalBalance {
                get { return GetValue<string>("total_balance", false); }
            }

            public string UsableBalance {
                get { return GetValue<string>("usable_balance", false); }
            }

            public string UsedAmount {
                get { return GetValue<string>("used_amount", false); }
            }

        }

        #endregion
    }
}
