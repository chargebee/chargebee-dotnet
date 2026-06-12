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

    public class LedgerOperation : Resource 
    {
    
        public LedgerOperation() { }

        public LedgerOperation(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public LedgerOperation(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public LedgerOperation(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> RetrieveLedgerOperation(string id)
        {
            string url = ApiUtil.BuildUrl("ledger_operations", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static LedgerOperationListLedgerOperationsRequest ListLedgerOperations()
        {
            string url = ApiUtil.BuildUrl("ledger_operations");
            return new LedgerOperationListLedgerOperationsRequest(url).IsJsonRequest(true);
        }
        public static CaptureRequest Capture()
        {
            string url = ApiUtil.BuildUrl("ledger_operations", "capture");
            return new CaptureRequest(url, HttpMethod.POST).IsJsonRequest(true).SetIdempotent(false);
        }
        public static AuthorizeRequest Authorize()
        {
            string url = ApiUtil.BuildUrl("ledger_operations", "authorize");
            return new AuthorizeRequest(url, HttpMethod.POST).IsJsonRequest(true).SetIdempotent(false);
        }
        public static CaptureAuthorizationRequest CaptureAuthorization()
        {
            string url = ApiUtil.BuildUrl("ledger_operations", "capture_authorization");
            return new CaptureAuthorizationRequest(url, HttpMethod.POST).IsJsonRequest(true).SetIdempotent(false);
        }
        public static ReleaseAuthorizationRequest ReleaseAuthorization()
        {
            string url = ApiUtil.BuildUrl("ledger_operations", "release_authorization");
            return new ReleaseAuthorizationRequest(url, HttpMethod.POST).IsJsonRequest(true).SetIdempotent(false);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public TypeEnum LedgerOperationType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public string Amount 
        {
            get { return GetValue<string>("amount", true); }
        }
        public string StartBalance 
        {
            get { return GetValue<string>("start_balance", true); }
        }
        public string EndBalance 
        {
            get { return GetValue<string>("end_balance", true); }
        }
        public string ProvisionedStartBalance 
        {
            get { return GetValue<string>("provisioned_start_balance", true); }
        }
        public string ProvisionedEndBalance 
        {
            get { return GetValue<string>("provisioned_end_balance", true); }
        }
        public string OverdraftStartBalance 
        {
            get { return GetValue<string>("overdraft_start_balance", true); }
        }
        public string OverdraftEndBalance 
        {
            get { return GetValue<string>("overdraft_end_balance", true); }
        }
        public string ParentLedgerOperationId 
        {
            get { return GetValue<string>("parent_ledger_operation_id", false); }
        }
        public DateTime? LedgerOperationTimestamp 
        {
            get { return GetDateTime("ledger_operation_timestamp", false); }
        }
        public DateTime? AutoReleaseTimestamp 
        {
            get { return GetDateTime("auto_release_timestamp", false); }
        }
        public string Metadata 
        {
            get { return GetValue<string>("metadata", false); }
        }
        public DateTime? CreatedAt 
        {
            get { return GetDateTime("created_at", false); }
        }
        public DateTime? ModifiedAt 
        {
            get { return GetDateTime("modified_at", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string UnitId 
        {
            get { return GetValue<string>("unit_id", false); }
        }
        public UnitTypeEnum? UnitType 
        {
            get { return GetEnum<UnitTypeEnum>("unit_type", false); }
        }
        
        #endregion
        
        #region Requests
        public class LedgerOperationListLedgerOperationsRequest : ListRequestBase<LedgerOperationListLedgerOperationsRequest> 
        {
            public LedgerOperationListLedgerOperationsRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<LedgerOperationListLedgerOperationsRequest> SubscriptionId() 
            {
                return new StringFilter<LedgerOperationListLedgerOperationsRequest>("subscription_id", this);        
            }
            public StringFilter<LedgerOperationListLedgerOperationsRequest> UnitId() 
            {
                return new StringFilter<LedgerOperationListLedgerOperationsRequest>("unit_id", this);        
            }
            public TimestampFilter<LedgerOperationListLedgerOperationsRequest> CreatedAt() 
            {
                return new TimestampFilter<LedgerOperationListLedgerOperationsRequest>("created_at", this);        
            }
            public EnumFilter<LedgerOperation.TypeEnum, LedgerOperationListLedgerOperationsRequest> Type() 
            {
                return new EnumFilter<LedgerOperation.TypeEnum, LedgerOperationListLedgerOperationsRequest>("type", this).SupportsMultiOperators(true);        
            }
            
            public LedgerOperationListLedgerOperationsRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
        
        }
        public class CaptureRequest : EntityRequest<CaptureRequest> 
        {
            public CaptureRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CaptureRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CaptureRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public CaptureRequest UnitId(string unitId) 
            {
                m_params.Add("unit_id", unitId);
                return this;
            }
            public CaptureRequest Amount(string amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public CaptureRequest LedgerOperationTimestamp(long ledgerOperationTimestamp) 
            {
                m_params.Add("ledger_operation_timestamp", ledgerOperationTimestamp);
                return this;
            }
            public CaptureRequest Metadata(Dictionary<String, Object> metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
        
        }
        public class AuthorizeRequest : EntityRequest<AuthorizeRequest> 
        {
            public AuthorizeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AuthorizeRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public AuthorizeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public AuthorizeRequest UnitId(string unitId) 
            {
                m_params.Add("unit_id", unitId);
                return this;
            }
            public AuthorizeRequest Amount(string amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public AuthorizeRequest LedgerOperationTimestamp(long ledgerOperationTimestamp) 
            {
                m_params.Add("ledger_operation_timestamp", ledgerOperationTimestamp);
                return this;
            }
            public AuthorizeRequest AutoReleaseTimestamp(long autoReleaseTimestamp) 
            {
                m_params.AddOpt("auto_release_timestamp", autoReleaseTimestamp);
                return this;
            }
            public AuthorizeRequest Metadata(Dictionary<String, Object> metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
        
        }
        public class CaptureAuthorizationRequest : EntityRequest<CaptureAuthorizationRequest> 
        {
            public CaptureAuthorizationRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CaptureAuthorizationRequest AuthorizationId(string authorizationId) 
            {
                m_params.Add("authorization_id", authorizationId);
                return this;
            }
            public CaptureAuthorizationRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CaptureAuthorizationRequest Amount(string amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public CaptureAuthorizationRequest LedgerOperationTimestamp(long ledgerOperationTimestamp) 
            {
                m_params.Add("ledger_operation_timestamp", ledgerOperationTimestamp);
                return this;
            }
            public CaptureAuthorizationRequest Metadata(Dictionary<String, Object> metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
        
        }
        public class ReleaseAuthorizationRequest : EntityRequest<ReleaseAuthorizationRequest> 
        {
            public ReleaseAuthorizationRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ReleaseAuthorizationRequest AuthorizationId(string authorizationId) 
            {
                m_params.Add("authorization_id", authorizationId);
                return this;
            }
            public ReleaseAuthorizationRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public ReleaseAuthorizationRequest LedgerOperationTimestamp(long ledgerOperationTimestamp) 
            {
                m_params.Add("ledger_operation_timestamp", ledgerOperationTimestamp);
                return this;
            }
            public ReleaseAuthorizationRequest Metadata(Dictionary<String, Object> metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
        
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "allocation")]
            Allocation,
            [EnumMember(Value = "capture")]
            Capture,
            [EnumMember(Value = "authorize")]
            Authorize,
            [EnumMember(Value = "release_authorization")]
            ReleaseAuthorization,
            [EnumMember(Value = "capture_authorization")]
            CaptureAuthorization,
            [EnumMember(Value = "expiry")]
            Expiry,
            [EnumMember(Value = "void")]
            Void,
            [EnumMember(Value = "rollover")]
            Rollover,
            [EnumMember(Value = "adjustment")]
            Adjustment,

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
