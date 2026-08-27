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

        [Theory]
        [InlineData("GET retrieve")]
        [InlineData("POST delete")]
        public void EntityRequestType_Operations_FluentMutators_DoNotThrow(string label)
        {
            // The fix must apply to every request whose static factory returns
            // EntityRequest<Type>, regardless of the underlying HTTP verb.
            _ = label;
            var get = Customer.Retrieve("cust_1");
            get.Header("X-Custom-Header", "v");
            get.SetIdempotencyKey("idem-key");
            get.Param("extra", "1");

            var post = PaymentSource.Delete("ps_1");
            post.Header("X-Custom-Header", "v");
            post.SetIdempotencyKey("idem-key");
            post.Param("comment", "removing card");
        }

        [Fact]
        public void EntityRequestType_FluentMutators_ReturnNull_DocumentingChainingLimitation()
        {
            // EntityRequest<Type> closes T over System.Type, so `this as T` is null.
            // The mutation is still applied (see the HTTP tests), but the return value
            // cannot be chained. This is the design limitation the runtime fix does NOT
            // solve (that would require changing the return types = breaking change).
            var request = PaymentSource.Delete("ps_1");

            Assert.Null(request.Header("X-Custom-Header", "v"));
            Assert.Null(request.SetIdempotencyKey("idem-key"));
            Assert.Null(request.Param("comment", "removing card"));
            Assert.Null(request.SetIdempotent(true));
            Assert.Null(request.SetSubDomain("sub"));
            Assert.Null(request.IsJsonRequest(true));
        }

        [Fact]
        public void CrtpRequest_FluentMutator_ReturnsSameInstance()
        {
            // For CRTP request classes, `this as T` returns the very same object, so
            // fluent methods are true builders (chaining mutates one instance).
            var request = Customer.Create();

            var afterHeader = request.Header("X-Custom-Header", "v");
            var afterParam = request.Param("cf_custom", "x");

            Assert.Same(request, afterHeader);
            Assert.Same(request, afterParam);
        }

        [Fact]
        public void ListRequest_Header_ReturnsListRequestForChaining()
        {
            // List requests derive from ListRequestBase<T> : EntityRequest<T> (CRTP), so fluent
            // methods keep the typed list request and list-specific methods remain chainable.
            var request = Customer.List()
                .Header("X-Custom-Header", "v")
                .Limit(5);

            Assert.NotNull(request);
            Assert.IsType<Customer.CustomerListRequest>(request);
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
        private string? _capturedBody;

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

        [Fact]
        public void CustomerRetrieve_Header_IsSentOnRequest()
        {
            // GET request whose factory returns EntityRequest<Type>: header must be applied.
            SetupSuccessResponse("{\"customer\":{\"id\":\"cust_1\"}}");

            var request = Customer.Retrieve("cust_1");
            request.Header("X-Custom-Header", "custom-value");
            var result = request.Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(System.Net.Http.HttpMethod.Get, _capturedRequest!.Method);
            Assert.Equal("custom-value", GetRequestHeader("X-Custom-Header"));
        }

        [Fact]
        public void PaymentSourceDelete_Param_IsSentInRequestBody()
        {
            // POST request whose factory returns EntityRequest<Type>: Param() must reach the body.
            SetupSuccessResponse("{\"payment_source\":{\"id\":\"ps_1\"}}");

            var request = PaymentSource.Delete("ps_1");
            request.Param("comment", "removing card");
            var result = request.Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(System.Net.Http.HttpMethod.Post, _capturedRequest!.Method);
            Assert.NotNull(_capturedBody);
            Assert.Contains("comment", _capturedBody);
        }

        [Fact]
        public void EntityRequestType_HeaderIdempotencyAndParam_AreAllAppliedOnRequest()
        {
            // End-to-end for the fix: on an EntityRequest<Type> request, header, idempotency
            // key and param are all applied even though the mutators return null.
            SetupSuccessResponse("{\"payment_source\":{\"id\":\"ps_1\"}}");

            var request = PaymentSource.Delete("ps_1");
            request.Header("X-Custom-Header", "custom-value");
            request.SetIdempotencyKey("idem-key");
            request.Param("comment", "removing card");
            var result = request.Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("custom-value", GetRequestHeader("X-Custom-Header"));
            Assert.Equal("idem-key", GetRequestHeader(IdempotencyConstants.IDEMPOTENCY_HEADER));
            Assert.Contains("comment", _capturedBody);
        }

        [Fact]
        public void CustomerCreate_MultipleHeaders_AreAllSentOnRequest()
        {
            SetupSuccessResponse("{\"customer\":{\"id\":\"cust_1\"}}");

            var result = Customer.Create()
                .Header("X-Header-One", "one")
                .Header("X-Header-Two", "two")
                .FirstName("Jane")
                .Request(_testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("one", GetRequestHeader("X-Header-One"));
            Assert.Equal("two", GetRequestHeader("X-Header-Two"));
        }

        private void SetupSuccessResponse(string json)
        {
            _mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>((request, _) =>
                {
                    _capturedRequest = request;
                    _capturedBody = request.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                })
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
