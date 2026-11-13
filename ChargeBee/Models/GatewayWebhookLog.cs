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

    public class GatewayWebhookLog : Resource 
    {
    
        public GatewayWebhookLog() { }

        public GatewayWebhookLog(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public GatewayWebhookLog(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public GatewayWebhookLog(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static GatewayWebhookLogListRequest List()
        {
            string url = ApiUtil.BuildUrl("gateway_webhook_logs");
            var request = new GatewayWebhookLogListRequest(url);
            request.SetTelemetryResource("gatewayWebhookLog");
            request.SetTelemetryOperation("list");
            return request;
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("gateway_webhook_logs", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("gatewayWebhookLog");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        #endregion
        
        #region Properties
        public string WebhookId 
        {
            get { return GetValue<string>("webhook_id", false); }
        }
        public string Url 
        {
            get { return GetValue<string>("url", false); }
        }
        public string Method 
        {
            get { return GetValue<string>("method", false); }
        }
        public string StatusCode 
        {
            get { return GetValue<string>("status_code", false); }
        }
        public string Gateway 
        {
            get { return GetValue<string>("gateway", false); }
        }
        public string IdAtGateway 
        {
            get { return GetValue<string>("id_at_gateway", false); }
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
        public DateTime? ReceivedAt 
        {
            get { return GetDateTime("received_at", false); }
        }
        public long? ResponseTime 
        {
            get { return GetValue<long?>("response_time", false); }
        }
        
        #endregion
        
        #region Requests
        public class GatewayWebhookLogListRequest : ListRequestBase<GatewayWebhookLogListRequest> 
        {
            public GatewayWebhookLogListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<GatewayWebhookLogListRequest> WebhookId() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("webhook_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> Gateway() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("gateway", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> StatusCode() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("status_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> Method() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("method", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> Url() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("url", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> IdAtGateway() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("id_at_gateway", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> CustomerHandle() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("customer_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> InvoiceHandle() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("invoice_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> TransactionHandle() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("transaction_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> PaymentMethodHandle() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("payment_method_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> GatewayCredentialHandle() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("gateway_credential_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> PaymentAttemptHandle() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("payment_attempt_handle", this).SupportsMultiOperators(true);        
            }
            public StringFilter<GatewayWebhookLogListRequest> PaymentIntentHandle() 
            {
                return new StringFilter<GatewayWebhookLogListRequest>("payment_intent_handle", this).SupportsMultiOperators(true);        
            }
            public TimestampFilter<GatewayWebhookLogListRequest> ReceivedAt() 
            {
                return new TimestampFilter<GatewayWebhookLogListRequest>("received_at", this);        
            }
            
            public GatewayWebhookLogListRequest SortByReceivedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","received_at");
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
