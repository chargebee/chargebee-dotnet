using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Web;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

using Newtonsoft.Json;

using ChargeBee.Exceptions;

namespace ChargeBee.Api
{
    public static class ApiUtil
    {
        private static DateTime m_unixTime = new DateTime(1970, 1, 1);

        public static string BuildUrl(params string[] paths)
        {
            StringBuilder sb = new StringBuilder(ApiConfig.Instance.ApiBaseUrl);

            foreach (var path in paths)
            {
				sb.Append('/').Append(HttpUtility.UrlPathEncode(path));
            }

            return sb.ToString();
        }

		private static HttpWebRequest GetRequest(string url, HttpMethod method, Dictionary<string, string> headers, ApiConfig env)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
			request.Method = Enum.GetName(typeof(HttpMethod), method);
            request.UserAgent = String.Format("ChargeBee-DotNet-Client v{0} on {1} / {2}",
                ApiConfig.Version,
                Environment.Version,
                Environment.OSVersion);

	     request.Accept = "application/json";

			AddHeaders (request, env);
			AddCustomHeaders (request, headers);

            request.Timeout = env.ConnectTimeout;
            request.ReadWriteTimeout = env.ReadTimeout;

            return request;
        }

		private static void AddHeaders(HttpWebRequest request, ApiConfig env) {
			request.Headers.Add(HttpRequestHeader.AcceptCharset, env.Charset);
			request.Headers.Add(HttpRequestHeader.Authorization, env.AuthValue);
		}

		private static void AddCustomHeaders(HttpWebRequest request, Dictionary<string, string> headers) {
			foreach (KeyValuePair<string, string> entry in headers) {
					AddHeader(request, entry.Key, entry.Value);
			}
		}

		private static void AddHeader(HttpWebRequest request, String headerName, String value) {
			request.Headers.Add(headerName, value);
		}

        private static string SendRequest(HttpWebRequest request, out HttpStatusCode code)
        {
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    code = response.StatusCode;
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                if (ex.Response == null) throw ex;
                using (HttpWebResponse response = ex.Response as HttpWebResponse)
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    code = response.StatusCode;
                    string content = reader.ReadToEnd();
					Dictionary<string, string> errorJson = null;
					try {
						errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>> (content);
					} catch(JsonException e) {
						throw new SystemException("Not in JSON format. Probably not a ChargeBee response. \n " + content, e);
					}
					string type = "";
					errorJson.TryGetValue ("type", out type);
					if ("payment".Equals (type)) {
						throw new PaymentException (response.StatusCode, errorJson);
					} else if ("operation_failed".Equals (type)) {
						throw new OperationFailedException (response.StatusCode, errorJson);
					} else if ("invalid_request".Equals(type)){
						throw new InvalidRequestException (response.StatusCode, errorJson);
					} else {
						throw new ApiException(response.StatusCode, errorJson);
					}
                }
            }
        }

		private static string GetJson(string url, Params parameters, ApiConfig env, Dictionary<string, string> headers, out HttpStatusCode code)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery());
			HttpWebRequest request = GetRequest(url, HttpMethod.GET, headers, env);
            return SendRequest(request, out code);
        }

		public static EntityResult Post(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
			HttpWebRequest request = GetRequest(url, HttpMethod.POST, headers, env);
            byte[] paramsBytes =
                Encoding.GetEncoding(env.Charset).GetBytes(parameters.GetQuery());

            request.ContentLength = paramsBytes.Length;
            request.ContentType = 
				String.Format("application/x-www-form-urlencoded;charset={0}",env.Charset);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(paramsBytes, 0, paramsBytes.Length);

                HttpStatusCode code;
                string json = SendRequest(request, out code);

                EntityResult result = new EntityResult(code, json);
                return result;
            }
        }

		public static EntityResult Get(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
            HttpStatusCode code;
			string json = GetJson(url, parameters, env, headers, out code);

            EntityResult result = new EntityResult(code, json);
            return result;
        }

		public static ListResult GetList(string url, Params parameters, Dictionary<string, string> headers, ApiConfig env)
        {
            HttpStatusCode code;
            string json = GetJson(url, parameters, env, headers, out code);

            ListResult result = new ListResult(code, json);
            return result;
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
