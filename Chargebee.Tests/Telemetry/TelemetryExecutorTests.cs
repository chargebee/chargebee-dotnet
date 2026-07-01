using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ChargeBee.Api;
using ChargeBee.Telemetry;
using HttpMethod = ChargeBee.Api.HttpMethod;

namespace ChargeBee.Tests.Telemetry
{
    public class TelemetryExecutorTests
    {
        private sealed class RecordingAdapter : ITelemetryAdapter
        {
            public readonly List<string> Events = new List<string>();
            public RequestTelemetryContext StartContext { get; private set; }
            public RequestTelemetryResult EndResult { get; private set; }

            public object OnRequestStart(RequestTelemetryContext context, Dictionary<string, string> requestHeaders)
            {
                Events.Add("start");
                StartContext = context;
                requestHeaders["traceparent"] = "00-test-trace";
                return "span-1";
            }

            public void OnRequestEnd(object handle, RequestTelemetryResult result)
            {
                Events.Add("end");
                EndResult = result;
            }
        }

        [Fact]
        public void ExecuteEntityRequest_SkipsWithoutAdapter()
        {
            var env = new ApiConfig("acme", "test_key");

            var response = TelemetryExecutor.ExecuteEntityRequest(
                env,
                "customer",
                "list",
                HttpMethod.GET,
                "/customers",
                null,
                new Dictionary<string, string>(),
                telemetryHeaders =>
                {
                    Assert.Null(telemetryHeaders);
                    return new EntityResult(HttpStatusCode.OK, "{}");
                });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void ExecuteEntityRequest_CallsAdapterOnceAndInjectsHeaders()
        {
            var adapter = new RecordingAdapter();
            var env = new ApiConfig("acme", "test_key") { TelemetryAdapter = adapter };

            var response = TelemetryExecutor.ExecuteEntityRequest(
                env,
                "customer",
                "list",
                HttpMethod.GET,
                "/customers",
                null,
                new Dictionary<string, string>(),
                telemetryHeaders =>
                {
                    Assert.Equal("00-test-trace", telemetryHeaders["traceparent"]);
                    return new EntityResult(HttpStatusCode.OK, "{}");
                });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(new[] { "start", "end" }, adapter.Events);
            Assert.Equal("chargebee.customer.list", adapter.StartContext.SpanName);
            Assert.Equal(200, adapter.EndResult.HttpStatusCode);
        }

        [Fact]
        public void ExecuteEntityRequest_CapturesChargebeeRequestHeaders()
        {
            var adapter = new RecordingAdapter();
            var env = new ApiConfig("acme", "test_key") { TelemetryAdapter = adapter };
            var requestHeaders = new Dictionary<string, string>
            {
                { "chargebee-foo", "bar" },
                { "chargebee-request-origin-ip", "202.170.207.70" },
                { "Authorization", "Basic super-secret" },
            };

            var response = TelemetryExecutor.ExecuteEntityRequest(
                env,
                "customer",
                "list",
                HttpMethod.GET,
                "/customers",
                null,
                requestHeaders,
                _ => new EntityResult(HttpStatusCode.OK, "{}"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var attrs = adapter.StartContext.StartAttributes;
            Assert.Equal("bar", attrs["http.request.header.chargebee-foo"]);
            Assert.False(attrs.ContainsKey("http.request.header.chargebee-request-origin-ip"));
            Assert.False(attrs.ContainsKey("http.request.header.authorization"));
        }

        [Fact]
        public void EntityRequestSystemTypeTelemetrySettersDoNotThrow()
        {
            var request = new EntityRequest<Type>("/webhook_endpoints/wh_123", HttpMethod.GET);

            var exception = Record.Exception(() =>
            {
                request.SetTelemetryResource("webhookEndpoint");
                request.SetTelemetryOperation("retrieve");
            });

            Assert.Null(exception);
        }

        [Fact]
        public void TypedRequestTelemetrySettersSupportChaining()
        {
            var request = new ChargeBee.Models.WebhookEndpoint.CreateRequest("/webhook_endpoints", HttpMethod.POST)
                .SetTelemetryResource("webhookEndpoint")
                .SetTelemetryOperation("create");

            Assert.NotNull(request);
        }

        [Fact]
        public async Task ExecuteEntityRequestAsync_RecordsChargebeeError()
        {
            var adapter = new RecordingAdapter();
            var env = new ApiConfig("acme", "test_key") { TelemetryAdapter = adapter };
            var err = new ApiException(
                HttpStatusCode.NotFound,
                new Dictionary<string, string>
                {
                    { "message", "Not found" },
                    { "type", "invalid_request" },
                    { "api_error_code", "resource_not_found" },
                    { "error_code", "resource_not_found" },
                    { "error_msg", "Not found" },
                    { "param", "customer_id" },
                });

            await Assert.ThrowsAsync<ApiException>(() =>
                TelemetryExecutor.ExecuteEntityRequestAsync(
                    env,
                    "customer",
                    "retrieve",
                    HttpMethod.GET,
                    "/customers/1",
                    null,
                    new Dictionary<string, string>(),
                    _ => Task.FromException<EntityResult>(err)));

            Assert.Equal(new[] { "start", "end" }, adapter.Events);
            Assert.Equal(404, adapter.EndResult.HttpStatusCode);
            Assert.Equal("resource_not_found", adapter.EndResult.Error.ChargebeeErrorCode);
            Assert.Equal("invalid_request", adapter.EndResult.EndAttributes[TelemetryAttributeKeys.ERROR_TYPE]);
            Assert.Equal("invalid_request", adapter.EndResult.EndAttributes[TelemetryAttributeKeys.CHARGEBEE_ERROR_TYPE]);
        }
    }
}
