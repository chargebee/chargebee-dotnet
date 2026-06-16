using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ChargeBee.Api;
using ChargeBee.Telemetry;

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
        }
    }
}
