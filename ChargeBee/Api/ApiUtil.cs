using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using Newtonsoft.Json;

using ChargeBee.Exceptions;
using System.Net.Http;
using System.Threading.Tasks;
using ChargeBee.Internal;
using Newtonsoft.Json.Linq;

namespace ChargeBee.Api
{
    public static class ApiUtil
    {
        private static DateTime m_unixTime = new DateTime(1970, 1, 1);
        private static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromMilliseconds(0 < ApiConfig.ConnectTimeout ? ApiConfig.ConnectTimeout : 30000) };

        public static string BuildUrl(params string[] paths)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var path in paths)
            {
                if(path.Contains("/"))
                    sb.Append('/').Append(Uri.EscapeUriString(path));
                else
                    sb.Append('/').Append(Uri.EscapeDataString(path));
            }
            return sb.ToString();
        }
        private static HttpRequestMessage BuildRequest(string uri, HttpMethod method, Params parameters, ApiConfig env, bool supportsFilter, string subDomain)
        {
            HttpRequestMessage request;
            System.Net.Http.HttpMethod meth = new System.Net.Http.HttpMethod(method.ToString());
            if (method.Equals(HttpMethod.POST))
            {
                byte[] paramBytes = Encoding.GetEncoding(env.Charset).GetBytes(parameters.GetQuery(supportsFilter));
                string postData = Encoding.GetEncoding(env.Charset).GetString(paramBytes, 0, paramBytes.Length);
                string baseUrl;
                if(subDomain != null) {
                    baseUrl  = env.ApiBaseUrlWithSubDomain(subDomain);
                }
                else {
                    baseUrl = env.ApiBaseUrl;
                }
                request = new HttpRequestMessage(meth, new Uri($"{baseUrl}{uri}"))
                {
                    Content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")
                };
            }
            else
            {
                string baseUrl;
                if(subDomain != null) {
                    baseUrl  = env.ApiBaseUrlWithSubDomain(subDomain);
                }
                else {
                    baseUrl = env.ApiBaseUrl;
                }
                request = new HttpRequestMessage(meth, new Uri($"{baseUrl}{uri}"));
            }
            return request;
        }
        
        private static HttpRequestMessage BuildContentTypeJsonRequest(string uri, HttpMethod method, Params parameters, ApiConfig env, bool supportsFilter, string subDomain)
        {
            HttpRequestMessage request;
            System.Net.Http.HttpMethod meth = new System.Net.Http.HttpMethod(method.ToString());
            if (method.Equals(HttpMethod.POST))
            {
                string baseUrl;
                if(subDomain != null) {
                    baseUrl  = env.ApiBaseUrlWithSubDomain(subDomain);
                }
                else {
                    baseUrl = env.ApiBaseUrl;
                }
                request = new HttpRequestMessage(meth, new Uri($"{baseUrl}{uri}"))
                {
                    Content = new StringContent(parameters.ToJsonString(), Encoding.UTF8, "application/json")
                };
            }
            else
            {
                string baseUrl;
                if(subDomain != null) {
                    baseUrl  = env.ApiBaseUrlWithSubDomain(subDomain);
                }
                else {
                    baseUrl = env.ApiBaseUrl;
                }
                request = new HttpRequestMessage(meth, new Uri($"{baseUrl}{uri}"));
            }
            return request;
        }
        private static HttpRequestMessage GetRequestMessage(string url, HttpMethod method, Params parameters,
            Dictionary<string, string> headers, ApiConfig env, bool supportsFilter = false, string subDomain = null,
            bool isJsonRequest = false, Dictionary<string, dynamic> options = null)
        {
            HttpRequestMessage request = isJsonRequest ? BuildContentTypeJsonRequest(url, method, parameters, env, supportsFilter, subDomain) : BuildRequest(url, method, parameters, env, supportsFilter, subDomain);
            AddHeaders(request, env);
            AddCustomHeaders(request, headers,env, options);
            return request;
        }
        private static void AddHeaders(HttpRequestMessage request, ApiConfig env)
        {
            request.Headers.Add("Accept-Charset", env.Charset);
            request.Headers.Add("Authorization", env.AuthValue);
            request.Headers.Add("Accept", "application/json");
            request.Headers.UserAgent.ParseAdd("ChargeBee-DotNet-Client v" + ApiConfig.Version);
#if NET45
            request.Headers.Add("Lang-Version",Environment.Version.ToString());
            request.Headers.Add("OS-Version",Environment.OSVersion.ToString());

#else
            request.Headers.Add("Lang-Version", RuntimeInformation.FrameworkDescription);
            request.Headers.Add("OS-Version", RuntimeInformation.OSDescription);

#endif
        }

        private static void AddCustomHeaders(HttpRequestMessage request, Dictionary<string, string> headers,
            ApiConfig env,
            Dictionary<string, dynamic> options)
        {
            foreach (KeyValuePair<string, string> entry in headers)
            {
                AddHeader(request, entry.Key, entry.Value);
            }

            if (request.Method != System.Net.Http.HttpMethod.Post ||
                headers.ContainsKey(IdempotencyConstants.IDEMPOTENCY_HEADER))
            {
                return;
            }
            var shouldAddIdempotencyKey = true;
            if (options != null && options.TryGetValue(EntityRequestConstants.IdempotencyOption, out var option))
            {
                if (option is bool optBool)
                {
                    shouldAddIdempotencyKey = optBool;
                }
            }
            if (shouldAddIdempotencyKey && env.RetryConfig.Enabled)
            {
                AddHeader(request, IdempotencyConstants.IDEMPOTENCY_HEADER, Guid.NewGuid().ToString());
            }
        }

        private static void AddHeader(HttpRequestMessage request, String headerName, String value)
        {
            request.Headers.Add(headerName, value);
        }

        private static void HandleException(HttpResponseMessage response)
        {
            string content = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            JObject errorJson = null;
            try
            {
                errorJson = JsonConvert.DeserializeObject<JObject>(content);
            }
            catch (JsonException e)
            {
                if (content.Contains("503"))
                {
                    throw new ArgumentException("Sorry, the server is currently unable to handle the request due to a temporary overload or scheduled maintenance. Please retry after sometime. \n type: internal_temporary_error, \n http_status_code: 503, \n error_code: internal_temporary_error,\n content: " + content, e);
                }
                else if (content.Contains("504"))
                {
                    throw new ArgumentException("The server did not receive a timely response from an upstream server, request aborted. If this problem persists, contact us at support@chargebee.com. \n type: gateway_timeout, \n http_status_code: 504, \n error_code: gateway_timeout,\n content: " + content, e);
                }
                else
                {
                    throw new ArgumentException("Sorry, something went wrong when trying to process the request. If this problem persists, contact us at support@chargebee.com. \n type: internal_error, \n http_status_code: 500, \n error_code: internal_error,\n content: " + content, e);
                }
            }
            string type = (string)errorJson["type"];
            if ("payment".Equals(type))
            {
                throw new PaymentException(response.StatusCode, errorJson);
            }
            else if ("operation_failed".Equals(type))
            {
                throw new OperationFailedException(response.StatusCode, errorJson);
            }
            else if ("invalid_request".Equals(type))
            {
                throw new InvalidRequestException(response.StatusCode, errorJson);
            }
            else if ("ubb_batch_ingestion_invalid_request".Equals(type))
            {
                throw new UbbBatchIngestionInvalidRequestException(response.StatusCode, errorJson);
            }
            else
            {
                throw new ApiException(response.StatusCode, errorJson);
            }

        }
        private static EntityResult GetEntityResult(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env, HttpMethod meth, bool supportsFilter, string subDomain = null, bool isJsonRequest = false,
            Dictionary<string, dynamic> options = null)
        {

            return GetEntityResultAsync(url, parameters, headers, env, meth, supportsFilter, subDomain, isJsonRequest, options).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        private static async Task<EntityResult> GetEntityResultAsync(string url, Params parameters,
            Dictionary<string, string> headers, ApiConfig env, HttpMethod meth, bool supportsFilter,
            string subDomain = null, bool isJsonRequest = false, Dictionary<string, dynamic> options = null)
        {
            int attempt = 0;
            string idempotentKey = null;
            int lastRetryAfterDelay = 0;
            Random rng = new Random();
            while (true)
            {
                if (idempotentKey != null && !headers.ContainsKey(IdempotencyConstants.IDEMPOTENCY_HEADER))
                {
                    headers[IdempotencyConstants.IDEMPOTENCY_HEADER] = idempotentKey;
                }
                HttpRequestMessage request = GetRequestMessage(url, meth, parameters, headers, env, supportsFilter, subDomain, isJsonRequest,options);
                HttpResponseMessage response = null;
                try
                {
                    if (idempotentKey == null  && request.Headers.TryGetValues(IdempotencyConstants.IDEMPOTENCY_HEADER, out var values))
                    {
                        idempotentKey = values.First();
                    }
                    if (attempt > 0)
                    {
                        request.Headers.Remove("X-CB-Retry-Attempt"); // Ensure no duplicates
                        request.Headers.Add("X-CB-Retry-Attempt", attempt.ToString());
                    }
                    response = await httpClient.SendAsync(request).ConfigureAwait(false);
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        return new EntityResult(response.StatusCode, json, response.Headers);
                    }
                    else
                    {
                        int statusCode = (int)response.StatusCode;
                        if (env.RetryConfig != null && env.RetryConfig.ShouldRetry(statusCode, attempt))
                        {
                            int retryAfterDelay = ParseRetryAfterHeader(response);
                            int delay = GetRetryDelay(env.RetryConfig, attempt,
                                retryAfterDelay > 0 ? retryAfterDelay : lastRetryAfterDelay, rng);
                            await Task.Delay(delay).ConfigureAwait(false);
                            attempt++;
                            lastRetryAfterDelay = retryAfterDelay > 0 ? retryAfterDelay : lastRetryAfterDelay;
                            continue;
                        }

                        HandleException(response);
                        return null;
                    }
                }
                catch (ApiException exception)
                {
                    int statusCode = (int)exception.HttpStatusCode;
                    if (env.RetryConfig == null || !env.RetryConfig.ShouldRetry(statusCode, attempt)) throw;
                    int delay = GetRetryDelay(env.RetryConfig, attempt, lastRetryAfterDelay, rng);
                    await Task.Delay(delay).ConfigureAwait(false);
                    attempt++;
                }
                finally
                {
                    response?.Dispose();
                    request.Dispose();
                }
            }
        }
        public static EntityResult Post(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env, bool supportsFilter = false, string subDomain = null, bool isJsonRequest = false,
            Dictionary<string, dynamic> options= null)
        {
            return GetEntityResult(url, parameters, headers, env, HttpMethod.POST, supportsFilter, subDomain, isJsonRequest,options);
        }

        public static Task<EntityResult> PostAsync(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env, bool supportsFilter = false, string subDomain = null, bool isJsonRequest = false,
            Dictionary<string, dynamic> options= null)
        {
            return GetEntityResultAsync(url, parameters, headers, env, HttpMethod.POST, supportsFilter, subDomain, isJsonRequest,options);
        }

        public static EntityResult Get(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env,
            bool supportsFilter = false, string subDomain = null, bool isJsonRequest = false,
            Dictionary<string, dynamic> options = null)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery(false));
            return GetEntityResult(url, parameters, headers, env, HttpMethod.GET, supportsFilter, subDomain, isJsonRequest,options);
        }

        public static Task<EntityResult> GetAsync(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env, bool supportsFilter = false, string subDomain = null, bool isJsonRequest = false,
            Dictionary<string, dynamic> options= null)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery(supportsFilter));
            return GetEntityResultAsync(url, parameters, headers, env, HttpMethod.GET, supportsFilter, subDomain, isJsonRequest,options);
        }

        public static ListResult GetList(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env, string subDomain = null)
        {
            return GetListAsync(url, parameters, headers, env,subDomain).GetAwaiter().GetResult();
        }

        public static async Task<ListResult> GetListAsync(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env, string subDomain = null)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery(true));
            int attempt = 0;
            int lastRetryAfterDelay = 0;
            Random rng = new Random();
            while (true)
            {
                HttpRequestMessage request = GetRequestMessage(url, HttpMethod.GET, parameters, headers, env, false, subDomain);
                HttpResponseMessage response = null;
                try
                {
                    response = await httpClient.SendAsync(request).ConfigureAwait(false);
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        return new ListResult(response.StatusCode, json, response.Headers);
                    }
                    else
                    {
                        int statusCode = (int)response.StatusCode;
                        if (env.RetryConfig != null && env.RetryConfig.ShouldRetry(statusCode, attempt))
                        {
                            int retryAfterDelay = ParseRetryAfterHeader(response);
                            int delay = GetRetryDelay(env.RetryConfig, attempt, retryAfterDelay > 0 ? retryAfterDelay : lastRetryAfterDelay, rng);
                            await Task.Delay(delay).ConfigureAwait(false);
                            attempt++;
                            lastRetryAfterDelay = retryAfterDelay > 0 ? retryAfterDelay : lastRetryAfterDelay;
                            continue;
                        }
                        HandleException(response);
                        return null;
                    }
                }
                catch (Exception)
                {
                    if (env.RetryConfig == null || !env.RetryConfig.ShouldRetry(0, attempt)) throw;
                    int delay = GetRetryDelay(env.RetryConfig, attempt, lastRetryAfterDelay, rng);
                    await Task.Delay(delay).ConfigureAwait(false);
                    attempt++;
                }
                finally
                {
                    response?.Dispose();
                    request.Dispose();
                }
            }
        }

        private static int ParseRetryAfterHeader(HttpResponseMessage response)
        {
            if (response.Headers.TryGetValues("Retry-After", out var values))
            {
                var retryAfter = values.GetEnumerator();
                if (retryAfter.MoveNext())
                {
                    string val = retryAfter.Current;
                    if (int.TryParse(val, out int seconds))
                    {
                        return seconds * 1000;
                    }
                    if (DateTimeOffset.TryParse(val, out var date))
                    {
                        var delay = (int)(date - DateTimeOffset.UtcNow).TotalMilliseconds;
                        return delay > 0 ? delay : 0;
                    }
                }
            }
            return 0;
        }

        private static int GetRetryDelay(RetryConfig config, int attempt, int retryAfterDelay, Random rng)
        {
            if (retryAfterDelay > 0) return retryAfterDelay;
            int jitter = rng.Next(100);
            return config.BaseDelayMs * (int)Math.Pow(2, attempt) + jitter;
        }

        public static DateTime ConvertFromTimestamp(long timestamp)
        {
            return m_unixTime.AddSeconds(timestamp).ToLocalTime();
        }

        public static long? ConvertToTimestamp(DateTime? t)
        {
            if (t == null) return null;

            DateTime dtutc = ((DateTime)t).ToUniversalTime();

            if (dtutc < m_unixTime) throw new ArgumentException("Time can't be before 1970, January 1!");

            return (long)(dtutc - m_unixTime).TotalSeconds;
        }

        public static String SerializeObject(Object obj)
        {
            return JsonConvert.SerializeObject(obj);

        }
    }

    /// <summary>
    /// HTTP method
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// DELETE
        /// </summary>
        DELETE,
        /// <summary>
        /// GET
        /// </summary>
        GET,
        /// <summary>
        /// POST
        /// </summary>
        POST,
        /// <summary>
        /// PUT
        /// </summary>
        PUT
    }
}