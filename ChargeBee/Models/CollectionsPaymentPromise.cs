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

    public class CollectionsPaymentPromise : Resource 
    {
    
        public CollectionsPaymentPromise() { }

        public CollectionsPaymentPromise(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CollectionsPaymentPromise(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CollectionsPaymentPromise(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("collections_payment_promises", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("collectionsPaymentPromise");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest ListCollectionsPaymentPromises()
        {
            string url = ApiUtil.BuildUrl("collections_payment_promises");
            var request = new CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest(url);
            request.SetTelemetryResource("collectionsPaymentPromise");
            request.SetTelemetryOperation("listCollectionsPaymentPromises");
            return request;
        }
        public static CreateCollectionsPaymentPromiseRequest CreateCollectionsPaymentPromise()
        {
            string url = ApiUtil.BuildUrl("collections_payment_promises");
            var request = new CreateCollectionsPaymentPromiseRequest(url, HttpMethod.POST).SetIdempotent(false);
            request.SetTelemetryResource("collectionsPaymentPromise");
            request.SetTelemetryOperation("createCollectionsPaymentPromise");
            return request;
        }
        public static UpdateCollectionsPaymentPromiseRequest UpdateCollectionsPaymentPromise(string id)
        {
            string url = ApiUtil.BuildUrl("collections_payment_promises", CheckNull(id));
            var request = new UpdateCollectionsPaymentPromiseRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("collectionsPaymentPromise");
            request.SetTelemetryOperation("updateCollectionsPaymentPromise");
            return request;
        }
        public static CancelRequest Cancel(string id)
        {
            string url = ApiUtil.BuildUrl("collections_payment_promises", CheckNull(id), "cancel");
            var request = new CancelRequest(url, HttpMethod.POST).SetIdempotent(false);
            request.SetTelemetryResource("collectionsPaymentPromise");
            request.SetTelemetryOperation("cancel");
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
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string Reason 
        {
            get { return GetValue<string>("reason", false); }
        }
        public string PromisedBy 
        {
            get { return GetValue<string>("promised_by", false); }
        }
        public DateTime PromisedOn 
        {
            get { return (DateTime)GetDateTime("promised_on", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public long? Amount 
        {
            get { return GetValue<long?>("amount", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
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
        public class CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest : ListRequestBase<CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest> 
        {
            public CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest> CustomerId() 
            {
                return new StringFilter<CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest>("customer_id", this);        
            }
            public StringFilter<CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest> InvoiceId() 
            {
                return new StringFilter<CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest>("invoice_id", this);        
            }
            public EnumFilter<CollectionsPaymentPromise.StatusEnum, CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest> Status() 
            {
                return new EnumFilter<CollectionsPaymentPromise.StatusEnum, CollectionsPaymentPromiseListCollectionsPaymentPromisesRequest>("status", this);        
            }
        }
        public class CreateCollectionsPaymentPromiseRequest : EntityRequest<CreateCollectionsPaymentPromiseRequest> 
        {
            public CreateCollectionsPaymentPromiseRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateCollectionsPaymentPromiseRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateCollectionsPaymentPromiseRequest InvoiceId(string invoiceId) 
            {
                m_params.AddOpt("invoice_id", invoiceId);
                return this;
            }
            public CreateCollectionsPaymentPromiseRequest Amount(long amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public CreateCollectionsPaymentPromiseRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateCollectionsPaymentPromiseRequest PromisedOn(long promisedOn) 
            {
                m_params.Add("promised_on", promisedOn);
                return this;
            }
            public CreateCollectionsPaymentPromiseRequest Reason(string reason) 
            {
                m_params.AddOpt("reason", reason);
                return this;
            }
            public CreateCollectionsPaymentPromiseRequest PromisedBy(string promisedBy) 
            {
                m_params.AddOpt("promised_by", promisedBy);
                return this;
            }
        }
        public class UpdateCollectionsPaymentPromiseRequest : EntityRequest<UpdateCollectionsPaymentPromiseRequest> 
        {
            public UpdateCollectionsPaymentPromiseRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateCollectionsPaymentPromiseRequest PromisedOn(long promisedOn) 
            {
                m_params.AddOpt("promised_on", promisedOn);
                return this;
            }
            public UpdateCollectionsPaymentPromiseRequest Reason(string reason) 
            {
                m_params.AddOpt("reason", reason);
                return this;
            }
            public UpdateCollectionsPaymentPromiseRequest PromisedBy(string promisedBy) 
            {
                m_params.AddOpt("promised_by", promisedBy);
                return this;
            }
        }
        public class CancelRequest : EntityRequest<CancelRequest> 
        {
            public CancelRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "fulfilled")]
            Fulfilled,
            [EnumMember(Value = "broken")]
            Broken,
            [EnumMember(Value = "cancelled")]
            Cancelled,

        }

        #region Subclasses

        #endregion
    }
}
