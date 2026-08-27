using System.Net;
using System.Text;
using ChargeBee.Api;
using ChargeBee.Internal;
using ChargeBee.Models;
using Moq;
using Moq.Protected;

namespace ChargeBee.Tests.Api
{
    public class EntityRequestFluentTests
    {
        [Fact]
        public void PaymentSourceDelete_Header_DoesNotThrow()
        {
            var request = PaymentSource.Delete("test");

            request.Header("test", "test");
        }

        [Fact]
        public void PaymentSourceDelete_FluentMutators_DoNotThrow()
        {
            var request = PaymentSource.Delete("test");

            request.Header("X-Custom-Header", "custom-value");
            request.SetIdempotencyKey("idem-key");
            request.Param("comment", "removing card");
            request.SetIdempotent(true);
            request.SetSubDomain("test-subdomain");
            request.IsJsonRequest(true);
        }

        [Fact]
        public void CustomerCreate_Header_ReturnsTypedRequestForChaining()
        {
            var request = Customer.Create()
                .Header("X-Custom-Header", "custom-value")
                .FirstName("Jane")
                .SetIdempotencyKey("idem-key")
                .LastName("Doe");

            Assert.NotNull(request);
            Assert.IsType<Customer.CreateRequest>(request);
        }
    }

    [Collection(ApiUtilTestCollection.Name)]
    public class EntityRequestFluentHttpTests : IDisposable
    {
        private readonly Mock<HttpMessageHandler> _mockHttpHandler;
        private readonly HttpClient _mockHttpClient;
        private readonly HttpClient? _originalHttpClient;
        private readonly ApiConfig _testConfig;
        private HttpRequestMessage? _capturedRequest;

        public EntityRequestFluentHttpTests()
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
        public void PaymentSourceDelete_HeaderAndIdempotencyKey_AreSentOnRequest()
        {
            SetupSuccessResponse("{\"payment_source\":{\"id\":\"test\"}}");

            var request = PaymentSource.Delete("test");
            request.Header("X-Custom-Header", "custom-value");
            request.SetIdempotencyKey("idem-key");
            var result = request.Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(_capturedRequest);
            Assert.Equal("custom-value", GetRequestHeader("X-Custom-Header"));
            Assert.Equal("idem-key", GetRequestHeader(IdempotencyConstants.IDEMPOTENCY_HEADER));
        }

        [Fact]
        public void CustomerCreate_HeaderThenFieldSetters_SendsHeaderAndParams()
        {
            SetupSuccessResponse("{\"customer\":{\"id\":\"cust_1\",\"first_name\":\"Jane\"}}");

            var result = Customer.Create()
                .Header("X-Custom-Header", "custom-value")
                .FirstName("Jane")
                .Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(_capturedRequest);
            Assert.Equal("custom-value", GetRequestHeader("X-Custom-Header"));
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
    }
}
