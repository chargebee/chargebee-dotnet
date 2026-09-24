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

    public class Einvoice : Resource 
    {
    
        public Einvoice() { }

        public Einvoice(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Einvoice(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Einvoice(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("einvoices", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("einvoice");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static EinvoiceListEinvoicesRequest ListEinvoices()
        {
            string url = ApiUtil.BuildUrl("einvoices");
            var request = new EinvoiceListEinvoicesRequest(url);
            request.SetTelemetryResource("einvoice");
            request.SetTelemetryOperation("listEinvoices");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", true); }
        }
        public string ReferenceId 
        {
            get { return GetValue<string>("reference_id", false); }
        }
        public string ReferenceNumber 
        {
            get { return GetValue<string>("reference_number", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string Message 
        {
            get { return GetValue<string>("message", false); }
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
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        public JArray ProviderReferences 
        {
            get { return GetJArray("provider_references", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
        }
        public List<EinvoiceArtifact> Artifacts 
        {
            get { return GetResourceList<EinvoiceArtifact>("artifacts"); }
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
        public class EinvoiceListEinvoicesRequest : ListRequestBase<EinvoiceListEinvoicesRequest> 
        {
            public EinvoiceListEinvoicesRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<EinvoiceListEinvoicesRequest> Id() 
            {
                return new StringFilter<EinvoiceListEinvoicesRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<EinvoiceListEinvoicesRequest> ReferenceId() 
            {
                return new StringFilter<EinvoiceListEinvoicesRequest>("reference_id", this).SupportsMultiOperators(true);        
            }
            public TimestampFilter<EinvoiceListEinvoicesRequest> UpdatedAt() 
            {
                return new TimestampFilter<EinvoiceListEinvoicesRequest>("updated_at", this);        
            }
            
            public EinvoiceListEinvoicesRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
            public EinvoiceListEinvoicesRequest InvoiceId(string invoiceId) 
            {
                m_params.AddOpt("invoice_id", invoiceId);
                return this;
            }
            public EinvoiceListEinvoicesRequest CreditNoteId(string creditNoteId) 
            {
                m_params.AddOpt("credit_note_id", creditNoteId);
                return this;
            }
        }
        #endregion

        public enum EntityTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "invoice")]
            Invoice,
            [EnumMember(Value = "credit_note")]
            CreditNote,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "scheduled")]
            Scheduled,
            [EnumMember(Value = "skipped")]
            Skipped,
            [EnumMember(Value = "in_progress")]
            InProgress,
            [EnumMember(Value = "success")]
            Success,
            [EnumMember(Value = "failed")]
            Failed,
            [EnumMember(Value = "registered")]
            Registered,
            [EnumMember(Value = "accepted")]
            Accepted,
            [EnumMember(Value = "rejected")]
            Rejected,
            [EnumMember(Value = "message_acknowledgement")]
            MessageAcknowledgement,
            [EnumMember(Value = "in_process")]
            InProcess,
            [EnumMember(Value = "under_query")]
            UnderQuery,
            [EnumMember(Value = "conditionally_accepted")]
            ConditionallyAccepted,
            [EnumMember(Value = "paid")]
            Paid,

        }

        #region Subclasses
        public class EinvoiceArtifact : Resource
        {
            public enum DirectionEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "outbound")]
                Outbound,
                [EnumMember(Value = "inbound")]
                Inbound,
            }
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "scheduled")]
                Scheduled,
                [EnumMember(Value = "skipped")]
                Skipped,
                [EnumMember(Value = "in_progress")]
                InProgress,
                [EnumMember(Value = "success")]
                Success,
                [EnumMember(Value = "failed")]
                Failed,
                [EnumMember(Value = "registered")]
                Registered,
            }

            public string ArtifactType {
                get { return GetValue<string>("artifact_type", true); }
            }

            public DirectionEnum Direction {
                get { return GetEnum<DirectionEnum>("direction", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public string Code {
                get { return GetValue<string>("code", false); }
            }

            public string ExternalArtifactId {
                get { return GetValue<string>("external_artifact_id", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

            public long? ResourceVersion {
                get { return GetValue<long?>("resource_version", false); }
            }

            public DateTime? UpdatedAt {
                get { return GetDateTime("updated_at", false); }
            }

            public bool Deleted {
                get { return GetValue<bool>("deleted", true); }
            }

        }

        #endregion
    }
}
