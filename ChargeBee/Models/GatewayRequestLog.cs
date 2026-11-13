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

    public class GatewayRequestLog : Resource 
    {
    
        public GatewayRequestLog() { }

        public GatewayRequestLog(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public GatewayRequestLog(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public GatewayRequestLog(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static GatewayRequestLogListRequest List()
        {
            string url = ApiUtil.BuildUrl("gateway_request_logs");
            var request = new GatewayRequestLogListRequest(url);
            request.SetTelemetryResource("gatewayRequestLog");
            request.SetTelemetryOperation("list");
            return request;
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("gateway_request_logs", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("gatewayRequestLog");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        #endregion
        
        #region Properties
        public string LogId 
        {
            get { return GetValue<string>("log_id", false); }
        }
        public string Url 
        {
            get { return GetValue<string>("url", false); }
        }
        public string StatusCode 
        {
            get { return GetValue<string>("status_code", false); }
        }
        public string Method 
        {
            get { return GetValue<string>("method", false); }
        }
        public string RequestBody 
        {
            get { return GetValue<string>("request_body", false); }
        }
        public string ResponseBody 
        {
            get { return GetValue<string>("response_body", false); }
        }
        public string RequestHeaders 
        {
            get { return GetValue<string>("request_headers", false); }
        }
        public string ResponseHeaders 
        {
            get { return GetValue<string>("response_headers", false); }
        }
        public string Gateway 
        {
            get { return GetValue<string>("gateway", false); }
        }
        public string CustomerHandle 
        {
            get { return GetValue<string>("customer_handle", false); }
        }
        public string InvoiceHandle 
        {
            get { return GetValue<string>("invoice_handle", false); }
        }
        public string TransactionHandle 
        {
            get { return GetValue<string>("transaction_handle", false); }
        }
        public string PaymentMethodHandle 
        {
            get { return GetValue<string>("payment_method_handle", false); }
        }
        public string GatewayCredentialHandle 
        {
            get { return GetValue<string>("gateway_credential_handle", false); }
        }
        public string PaymentAttemptHandle 
        {
            get { return GetValue<string>("payment_attempt_handle", false); }
        }
        public string PaymentIntentHandle 
        {
            get { return GetValue<string>("payment_intent_handle", false); }
        }
        public string PaymentMethodName 
        {
            get { return GetValue<string>("payment_method_name", false); }
        }
        public string OperationName 
        {
            get { return GetValue<string>("operation_name", false); }
        }
        public string OperationType 
        {
            get { return GetValue<string>("operation_type", false); }
        }
        public string ActionType 
        {
            get { return GetValue<string>("action_type", false); }
        }
        public string Source 
        {
            get { return GetValue<string>("source", false); }
        }
        public string TraceIdHash 
        {
            get { return GetValue<string>("trace_id_hash", false); }
        }
        public DateTime? InvocationTime 
        {
            get { return GetDateTime("invocation_time", false); }
        }
        public DateTime? ResponseReceivedAt 
        {
            get { return GetDateTime("response_received_at", false); }
        }
        public long? ResponseTime 
        {
            get { return GetValue<long?>("response_time", false); }
        }
        
        #endregion
        
        #region Requests
        public class GatewayRequestLogListRequest : ListRequestBase<GatewayRequestLogListRequest> 
        {
            public GatewayRequestLogListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<GatewayRequestLogListRequest> LogId() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("log_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> Gateway() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("gateway", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> StatusCode() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("status_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> Method() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("method", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> Url() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("url", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> CustomerHandle() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("customer_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> InvoiceHandle() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("invoice_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> TransactionHandle() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("transaction_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> PaymentMethodHandle() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("payment_method_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> GatewayCredentialHandle() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("gateway_credential_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> PaymentAttemptHandle() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("payment_attempt_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> PaymentIntentHandle() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("payment_intent_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> OperationName() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("operation_name", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> OperationType() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("operation_type", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayRequestLogListRequest> Source() 
            {
                return new StringFilter<GatewayRequestLogListRequest>("source", this).SupportsMultiOperators(true);        
            }
            public TimestampFilter<GatewayRequestLogListRequest> InvocationTime() 
            {
                return new TimestampFilter<GatewayRequestLogListRequest>("invocation_time", this);        
            }
            public TimestampFilter<GatewayRequestLogListRequest> ResponseReceivedAt() 
            {
                return new TimestampFilter<GatewayRequestLogListRequest>("response_received_at", this);        
            }
            
            public GatewayRequestLogListRequest SortByInvocationTime(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","invocation_time");
                return this;
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        #endregion


        #region Subclasses

        #endregion
    }
}
