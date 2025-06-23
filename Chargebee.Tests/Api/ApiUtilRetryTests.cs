using System.Net;
using System.Text;
using Moq;
using Moq.Protected;
using ChargeBee.Api;
using ChargeBee.Exceptions;

namespace ChargeBee.Tests.Api
{
    public class ApiUtilRetryTests : IDisposable
    {
        private Mock<HttpMessageHandler> _mockHttpHandler;
        private HttpClient _mockHttpClient;
        private ApiConfig _testConfig;

        public ApiUtilRetryTests()
        {
            _mockHttpHandler = new Mock<HttpMessageHandler>();
            _mockHttpClient = new HttpClient(_mockHttpHandler.Object);
            _testConfig = new ApiConfig("test-site", "test-key");

            var httpClientField = typeof(ApiUtil).GetField("httpClient",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            httpClientField?.SetValue(null, _mockHttpClient);
        }

        public void Dispose()
        {
            _mockHttpClient?.Dispose();
        }

        [Fact]
        public async Task GetAsync_RetryDisabled_DoesNotRetry()
        {
            _testConfig.RetryConfig = new RetryConfig { Enabled = false };

            var errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("{\n  \"message\" : \"Sorry,Something went wrong when trying to process the request.\",\n  \"type\" : \"operation_failed\",\n  \"api_error_code\" : \"internal_error\",\n  \"error_code\" : \"internal_error\",\n  \"error_msg\" : \"Sorry,Something went wrong when trying to process the request.\",\n  \"http_status_code\" : 500\n}")
            };

            _mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(errorResponse);

            await Assert.ThrowsAsync<OperationFailedException>(() =>
                ApiUtil.GetAsync("/test", new Params(), new Dictionary<string, string>(), _testConfig));

            _mockHttpHandler.Protected().Verify("SendAsync", Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetListAsync_NonRetryableStatusCode_DoesNotRetry()
        {
            _testConfig.RetryConfig = new RetryConfig
            {
                MaxRetries = 3,
                RetryOnStatus = new HashSet<int> { 429, 500, 502, 503, 504 }
            };

            var errorResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("{\n  \"message\" : \"Sorry,Something went wrong when trying to process the request.\",\n  \"type\" : \"invalid_request\",\n  \"api_error_code\" : \"internal_error\",\n  \"error_code\" : \"internal_error\",\n  \"error_msg\" : \"Sorry,Something went wrong when trying to process the request.\",\n  \"http_status_code\" : 500\n}")
            };

            _mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(errorResponse);

            await Assert.ThrowsAsync<InvalidRequestException>(() =>
                ApiUtil.GetListAsync("/customers", new Params(), new Dictionary<string, string>(), _testConfig));

            _mockHttpHandler.Protected().Verify("SendAsync", Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task PostAsync_ExponentialBackoff_DelaysIncreaseAcrossAttempts()
        {
            _testConfig.RetryConfig = new RetryConfig
            {
                Enabled = true,
                MaxRetries = 3,
                BaseDelayMs = 100,
                RetryOnStatus = new HashSet<int> { 503 }
            };

            var timestamps = new List<DateTime>();
            int callCount = 0;

            _mockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(() =>
                {
                    timestamps.Add(DateTime.UtcNow);
                    callCount++;
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                    {
                        Content = new StringContent(
                        """
                        {
                            "type": "operation_failed",
                            "message": "Service unavailable"
                        }
                        """, Encoding.UTF8, "application/json")
                    });
                });

            var startTime = DateTime.UtcNow;

            try
            {
                await ApiUtil.PostAsync("/test", new Params(), new Dictionary<string, string>(), _testConfig);
            }
            catch { /* Expected */ }

            Assert.Equal(4, callCount);
            Assert.Equal(4, timestamps.Count);

            var totalElapsed = (DateTime.UtcNow - startTime).TotalMilliseconds;
            Assert.True(totalElapsed >= 650, $"Expected delay ≥ 650ms but was {totalElapsed}ms");

            var delay1 = (timestamps[1] - timestamps[0]).TotalMilliseconds;
            var delay2 = (timestamps[2] - timestamps[1]).TotalMilliseconds;
            var delay3 = (timestamps[3] - timestamps[2]).TotalMilliseconds;

            Assert.InRange(delay1, 80, 300);
            Assert.InRange(delay2, 150, 450);
            Assert.InRange(delay3, 300, 800);
        }

        [Fact]
        public async Task GetAsync_RespectsRetryAfterHeaderInSeconds()
        {
            _testConfig.RetryConfig = new RetryConfig
            {
                Enabled = true,
                MaxRetries = 2,
                BaseDelayMs = 1000,
                RetryOnStatus = new HashSet<int> { 429 }
            };

            var retryAfterSeconds = 2;
            var expectedDelay = retryAfterSeconds * 1000;

            var errorResponse = new HttpResponseMessage(HttpStatusCode.TooManyRequests);
            errorResponse.Headers.Add("Retry-After", retryAfterSeconds.ToString());
            errorResponse.Content = new StringContent(
                """
                {
                    "type": "rate_limit",
                    "message": "Too many requests"
                }
                """, Encoding.UTF8, "application/json");

            var successResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"success\":true}")
            };

            _mockHttpHandler.Protected()
                .SetupSequence<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(errorResponse)
                .ReturnsAsync(successResponse);

            var start = DateTime.UtcNow;
            var result = await ApiUtil.GetAsync("/test", new Params(), new Dictionary<string, string>(), _testConfig);
            var actualDelay = (DateTime.UtcNow - start).TotalMilliseconds;

            Assert.InRange(actualDelay, expectedDelay - 200, expectedDelay + 500);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task GetListAsync_CustomStatusCodes_RetriesSuccessfully()
        {
            _testConfig.RetryConfig = new RetryConfig
            {
                Enabled = true,
                MaxRetries = 2,
                BaseDelayMs = 10,
                RetryOnStatus = new HashSet<int> { 418 } // I'm a teapot
            };

            var errorResponse = new HttpResponseMessage((HttpStatusCode)418)
            {
                Content = new StringContent("{\"type\":\"api_error\",\"message\":\"I'm a teapot\"}")
            };

            var successResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"list\":[]}")
            };

            _mockHttpHandler.Protected()
                .SetupSequence<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(errorResponse)
                .ReturnsAsync(successResponse);

            var result = await ApiUtil.GetListAsync("/test", new Params(), new Dictionary<string, string>(), _testConfig);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            _mockHttpHandler.Protected().Verify("SendAsync", Times.Exactly(2),
                ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }
}
