using System.Net;
using System.Text;
using ChargeBee.Api;
using ChargeBee.Models;
using ChargeBee.Tests.Api;
using Moq;
using Moq.Protected;

namespace ChargeBee.Tests.Telemetry
{
    [Collection(ApiUtilTestCollection.Name)]
    public class EntityRequestNoTelemetryTests : IDisposable
    {
        private readonly Mock<HttpMessageHandler> _mockHttpHandler;
        private readonly HttpClient _mockHttpClient;
        private readonly HttpClient? _originalHttpClient;
        private readonly ApiConfig _testConfig;
        private HttpRequestMessage? _capturedRequest;

        public EntityRequestNoTelemetryTests()
        {
            _mockHttpHandler = new Mock<HttpMessageHandler>();
            _mockHttpClient = new HttpClient(_mockHttpHandler.Object);
            _testConfig = new ApiConfig("test-site", "test-key");

            var httpClientField = typeof(ApiUtil).GetField(
                "httpClient",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            _originalHttpClient = (HttpClient?)httpClientField?.GetValue(null);
            httpClientField?.SetValue(null, _mockHttpClient);
        }

        public void Dispose()
        {
            var httpClientField = typeof(ApiUtil).GetField(
                "httpClient",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            httpClientField?.SetValue(null, _originalHttpClient);
            _mockHttpClient.Dispose();
        }

        [Fact]
        public void CustomerList_RequestWithoutAdapter_SendsUnchangedHttpRequest()
        {
            SetupSuccessResponse("{\"list\":[]}");

            var result = Customer.List()
                .Limit(1)
                .Header("X-Custom-Header", "custom-value")
                .Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(_capturedRequest);
            Assert.Equal(
                new Uri("https://test-site.chargebee.com/api/v2/customers?limit=1"),
                _capturedRequest!.RequestUri);
            Assert.Equal("custom-value", GetRequestHeader("X-Custom-Header"));
            Assert.False(HasRequestHeader("traceparent"));
            Assert.False(HasRequestHeader("tracestate"));
            Assert.NotNull(GetRequestHeader("Authorization"));
        }

        [Fact]
        public async Task CustomerList_RequestAsyncWithoutAdapter_SendsUnchangedHttpRequest()
        {
            SetupSuccessResponse("{\"list\":[]}");

            var result = await Customer.List()
                .Limit(1)
                .RequestAsync(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(_capturedRequest);
            Assert.Equal(
                new Uri("https://test-site.chargebee.com/api/v2/customers?limit=1"),
                _capturedRequest!.RequestUri);
            Assert.False(HasRequestHeader("traceparent"));
            Assert.False(HasRequestHeader("tracestate"));
        }

        [Fact]
        public void CustomerCreate_RequestWithoutAdapter_SendsUnchangedHttpRequest()
        {
            SetupSuccessResponse("{\"customer\":{\"id\":\"cust_1\",\"first_name\":\"Jane\"}}");

            var result = Customer.Create()
                .FirstName("Jane")
                .LastName("Doe")
                .Email("jane@example.com")
                .Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(_capturedRequest);
            Assert.Equal(System.Net.Http.HttpMethod.Post, _capturedRequest!.Method);
            Assert.Equal(
                new Uri("https://test-site.chargebee.com/api/v2/customers"),
                _capturedRequest.RequestUri);
            Assert.False(HasRequestHeader("traceparent"));
            Assert.False(HasRequestHeader("tracestate"));
        }

        private void SetupSuccessResponse(string json)
        {
            _mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((request, _) => _capturedRequest = request)
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                });
        }

        private string? GetRequestHeader(string name)
        {
            if (_capturedRequest == null)
            {
                return null;
            }

            if (_capturedRequest.Headers.TryGetValues(name, out var values))
            {
                return values.FirstOrDefault();
            }

            return null;
        }

        private bool HasRequestHeader(string name)
        {
            return GetRequestHeader(name) != null;
        }
    }
}
