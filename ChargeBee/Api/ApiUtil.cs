using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using ChargeBee.Exceptions;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChargeBee.Api
{
    public static class ApiUtil
    {
        private static DateTime m_unixTime = new DateTime(1970, 1, 1);

        private static readonly HttpClient httpClient =
            new HttpClient(ApiConfig.HttpMessageHandler ?? new HttpClientHandler())
            {
                Timeout = TimeSpan.FromMilliseconds(0 < ApiConfig.ConnectTimeout ? ApiConfig.ConnectTimeout : 30000)
            };

        public static string BuildUrl(params string[] paths)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var path in paths)
            {
                sb.Append('/').Append(Uri.EscapeDataString(path));
            }

            return sb.ToString();
        }

        private static HttpRequestMessage BuildRequest(string uri, HttpMethod method, Params parameters, ApiConfig env)
        {
            HttpRequestMessage request;
            System.Net.Http.HttpMethod meth = new System.Net.Http.HttpMethod(method.ToString());
            if (method.Equals(HttpMethod.POST))
            {
                byte[] paramBytes = Encoding.GetEncoding(env.Charset).GetBytes(parameters.GetQuery(false));
                string postData = Encoding.GetEncoding(env.Charset).GetString(paramBytes, 0, paramBytes.Length);
                request = new HttpRequestMessage(meth, new Uri($"{env.ApiBaseUrl}{uri}"))
                {
                    Content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")
                };
            }
            else
            {
                request = new HttpRequestMessage(meth, new Uri($"{env.ApiBaseUrl}{uri}"));
            }

            return request;
        }

        private static HttpRequestMessage GetRequestMessage(string url, HttpMethod method, Params parameters,
            Dictionary<string, string> headers, ApiConfig env)
        {
            HttpRequestMessage request = BuildRequest(url, method, parameters, env);
            AddHeaders(request, env);
            AddCustomHeaders(request, headers);
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

        private static void AddCustomHeaders(HttpRequestMessage request, Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> entry in headers)
            {
                AddHeader(request, entry.Key, entry.Value);
            }
        }

        private static void AddHeader(HttpRequestMessage request, String headerName, String value)
        {
            request.Headers.Add(headerName, value);
        }

        private static void HandleException(HttpResponseMessage response)
        {
            string content = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Dictionary<string, string> errorJson = null;
            try
            {
                errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            }
            catch (JsonException e)
            {
                if (content.Contains("503"))
                {
                    throw new ArgumentException(
                        "Sorry, the server is currently unable to handle the request due to a temporary overload or scheduled maintenance. Please retry after sometime. \n type: internal_temporary_error, \n http_status_code: 503, \n error_code: internal_temporary_error,\n content: " +
                        content, e);
                }
                else if (content.Contains("504"))
                {
                    throw new ArgumentException(
                        "The server did not receive a timely response from an upstream server, request aborted. If this problem persists, contact us at support@chargebee.com. \n type: gateway_timeout, \n http_status_code: 504, \n error_code: gateway_timeout,\n content: " +
                        content, e);
                }
                else
                {
                    throw new ArgumentException(
                        "Sorry, something went wrong when trying to process the request. If this problem persists, contact us at support@chargebee.com. \n type: internal_error, \n http_status_code: 500, \n error_code: internal_error,\n content: " +
                        content, e);
                }
            }

            string type = "";
            errorJson.TryGetValue("type", out type);
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
            else
            {
                throw new ApiException(response.StatusCode, errorJson);
            }
        }

        private static EntityResult GetEntityResult(String url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env, HttpMethod meth)
        {
            return GetEntityResultAsync(url, parameters, headers, env, meth).ConfigureAwait(false).GetAwaiter()
                .GetResult();
        }

        private static async Task<EntityResult> GetEntityResultAsync(String url, Params parameters,
            Dictionary<string, string> headers, ApiConfig env, HttpMethod meth)
        {
            HttpRequestMessage request = GetRequestMessage(url, meth, parameters, headers, env);
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                EntityResult result = new EntityResult(response.StatusCode, json);
                return result;
            }
            else
            {
                HandleException(response);
                return null;
            }
        }

        public static EntityResult Post(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env)
        {
            return GetEntityResult(url, parameters, headers, env, HttpMethod.POST);
        }

        public static Task<EntityResult> PostAsync(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env)
        {
            return GetEntityResultAsync(url, parameters, headers, env, HttpMethod.POST);
        }

        public static EntityResult Get(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery(false));
            return GetEntityResult(url, parameters, headers, env, HttpMethod.GET);
        }

        public static Task<EntityResult> GetAsync(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery(false));
            return GetEntityResultAsync(url, parameters, headers, env, HttpMethod.GET);
        }

        public static ListResult GetList(string url, Params parameters, Dictionary<string, string> headers,
            ApiConfig env)
        {
            return GetListAsync(url, parameters, headers, env).GetAwaiter().GetResult();
        }

        public static async Task<ListResult> GetListAsync(string url, Params parameters,
            Dictionary<string, string> headers, ApiConfig env)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery(true));
            HttpRequestMessage request = GetRequestMessage(url, HttpMethod.GET, parameters, headers, env);
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                ListResult result = new ListResult(response.StatusCode, json);
                return result;
            }
            else
            {
                HandleException(response);
                return null;
            }
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