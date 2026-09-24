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

    public class Dispute : Resource 
    {
    
        public Dispute() { }

        public Dispute(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Dispute(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Dispute(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("disputes", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("dispute");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static DisputeListRequest List()
        {
            string url = ApiUtil.BuildUrl("disputes");
            var request = new DisputeListRequest(url);
            request.SetTelemetryResource("dispute");
            request.SetTelemetryOperation("list");
            return request;
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
        public string TransactionId 
        {
            get { return GetValue<string>("transaction_id", true); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", true); }
        }
        public string IdAtGateway 
        {
            get { return GetValue<string>("id_at_gateway", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public long Amount 
        {
            get { return GetValue<long>("amount", true); }
        }
        public string Reason 
        {
            get { return GetValue<string>("reason", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public TypeEnum DisputeType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public bool IsPartialDispute 
        {
            get { return GetValue<bool>("is_partial_dispute", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        
        #endregion
        
        #region Requests
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class DisputeListRequest : ListRequestBase<DisputeListRequest> 
        {
            public DisputeListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<DisputeListRequest> Id() 
            {
                return new StringFilter<DisputeListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Dispute.StatusEnum, DisputeListRequest> Status() 
            {
                return new EnumFilter<Dispute.StatusEnum, DisputeListRequest>("status", this);        
            }
            public EnumFilter<Dispute.TypeEnum, DisputeListRequest> Type() 
            {
                return new EnumFilter<Dispute.TypeEnum, DisputeListRequest>("type", this);        
            }
            public StringFilter<DisputeListRequest> CustomerId() 
            {
                return new StringFilter<DisputeListRequest>("customer_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DisputeListRequest> TransactionId() 
            {
                return new StringFilter<DisputeListRequest>("transaction_id", this).SupportsMultiOperators(true);        
            }
            public NumberFilter<long, DisputeListRequest> Amount() 
            {
                return new NumberFilter<long, DisputeListRequest>("amount", this);        
            }
            public TimestampFilter<DisputeListRequest> CreatedAt() 
            {
                return new TimestampFilter<DisputeListRequest>("created_at", this);        
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "initiated")]
            Initiated,
            [EnumMember(Value = "funds_withdrawn")]
            FundsWithdrawn,
            [EnumMember(Value = "in_review")]
            InReview,
            [EnumMember(Value = "cancelled")]
            Cancelled,
            [EnumMember(Value = "lost")]
            Lost,
            [EnumMember(Value = "won")]
            Won,

        }
        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "chargeback")]
            Chargeback,
            [EnumMember(Value = "inquiry")]
            Inquiry,

        }

        #region Subclasses

        #endregion
    }
}
