using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

using Newtonsoft.Json;

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
                sb.Append('/').Append(path);
            }

            return sb.ToString();
        }

        private static HttpWebRequest GetRequest(string url, HttpMethod method, ApiConfig env)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = Enum.GetName(typeof(HttpMethod), method);
            request.UserAgent = String.Format("ChargeBee-DotNet-Client v{0} on {1} / {2}",
                ApiConfig.Version,
                Environment.Version,
                Environment.OSVersion);

            request.Accept = "application/json";

            request.Headers.Add(HttpRequestHeader.AcceptCharset, env.Charset);
            request.Headers.Add(HttpRequestHeader.Authorization, env.AuthValue);

            request.Timeout = env.ConnectTimeout;
            request.ReadWriteTimeout = env.ReadTimeout;

            return request;
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
				Console.WriteLine("exception is {0}", ex); 
                using (HttpWebResponse response = ex.Response as HttpWebResponse)
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    code = response.StatusCode;
                    string json = reader.ReadToEnd();
					Console.WriteLine(json);
                    ApiException apiEx = JsonConvert.DeserializeObject<ApiException>(json);
                    apiEx.HttpCode = response.StatusCode;
                    throw apiEx;
                }
            }
        }

        private static string GetJson(string url, Params parameters, ApiConfig env, out HttpStatusCode code)
        {
            url = String.Format("{0}?{1}", url, parameters.GetQuery());            
			HttpWebRequest request = GetRequest(url, HttpMethod.GET, env);
            return SendRequest(request, out code);
        }

        public static EntityResult Post(string url, Params parameters, ApiConfig env)
        {
            HttpWebRequest request = GetRequest(url, HttpMethod.POST, env);
            byte[] paramsBytes =
                Encoding.GetEncoding(env.Charset).GetBytes(parameters.GetQuery());

            request.ContentLength = paramsBytes.Length;
            request.ContentType = String.Format(
                "application/x-www-form-urlencoded;charset={0}",
                env.Charset);

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(paramsBytes, 0, paramsBytes.Length);

                HttpStatusCode code;
                string json = SendRequest(request, out code);

                EntityResult result = new EntityResult(code, json);
                return result;
            }
        }

        public static EntityResult Get(string url, Params parameters, ApiConfig env)
        {
            HttpStatusCode code;
            string json = GetJson(url, parameters, env, out code);

            EntityResult result = new EntityResult(code, json);
            return result;
        }

        public static ListResult GetList(string url, Params parameters, ApiConfig env)
        {
            HttpStatusCode code;
            string json = GetJson(url, parameters, env, out code);

            ListResult result = new ListResult(code, json);
            return result;
        }

        public static string Encode(string input)
        {
            StringBuilder resultStr = new StringBuilder();
            foreach (char ch in input)
            {
                if (IsUnsafe(ch))
                {
                    resultStr.Append('%');
                    resultStr.Append(ToHex(ch / 16));
                    resultStr.Append(ToHex(ch % 16));
                }
                else
                {
                    resultStr.Append(ch);
                }
            }
            return resultStr.ToString();
        }

        private static char ToHex(int ch)
        {
            return (char)(ch < 10 ? '0' + ch : 'A' + ch - 10);
        }

        private static bool IsUnsafe(char ch)
        {
            if (ch > 128 || ch < 0)
                return true;

            return " %$&+,;=?@<>#%".IndexOf(ch) >= 0;
        }

        public static DateTime ConvertFromTimestamp(long timestamp)
        {
            return m_unixTime.AddSeconds(timestamp).ToLocalTime();
        }

        public static long? ConvertToTimestamp(DateTime? t)
        {
            if (t == null) return null;

            DateTime dt = (DateTime)t;

            if (dt < m_unixTime) throw new ArgumentException("Time can't be before 1970, January 1!");

            return (long)(dt.ToUniversalTime() - m_unixTime).TotalSeconds;
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
