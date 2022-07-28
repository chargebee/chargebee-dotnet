using ChargeBee.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace ChargeBee.Api
{
    public sealed class ApiConfig
    {
        public static string DomainSuffix = "chargebee.com";
        public static string Proto = "https";
        public static string Version = "2.18.0";
        public static readonly string API_VERSION = "v2";
        public static int TimeTravelMillis { get; set; }
        public static int ExportSleepMillis { get; set; }

        public string ApiKey { get; set; }
        public string SiteName { get; set; }
        public string Charset { get; set; }
        public int ConnectTimeout
        {
            get
            {
                return HttpClient.Timeout.Milliseconds;
            }
            set
            {
                HttpClient.Timeout = TimeSpan.FromMilliseconds(0 < value ? value : 30000);
            }
        }

        internal HttpClient HttpClient { get; }

        public string ApiBaseUrl
        {
            get
            {
                return String.Format("{0}://{1}.{2}/api/{3}",
                    Proto,
                    SiteName,
                    DomainSuffix,
                    API_VERSION);
            }
        }

        public string AuthValue
        {
            get
            {
                return String.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    String.Format("{0}:", ApiKey))));
            }
        }

        public ApiConfig(string siteName, string apiKey, HttpClient client = null)
        {
            if (String.IsNullOrEmpty(siteName))
                throw new ArgumentException("Site name can't be empty!");

            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Api key can't be empty!");

            Charset = Encoding.UTF8.WebName;
            TimeTravelMillis = 3000;
            ExportSleepMillis = 10000;
            SiteName = siteName;
            ApiKey = apiKey;

            if (client == null)
            {
                HttpClient = new HttpClient
                {
                    Timeout = TimeSpan.FromMilliseconds(30000)
                };
            }
            else
            {
                client.Timeout = TimeSpan.FromMilliseconds(30000);
                HttpClient = client;
            }
        }

        private static volatile ApiConfig m_instance;

        public static void Configure(string siteName, string apiKey, HttpClient client = null)
        {
            m_instance = new ApiConfig(siteName, apiKey, client);
        }

        public static string SerializeObject<T>(T t) where T : Resource
        {
            return t.GetJToken().ToString();
        }

        public static T DeserializeObject<T>(string str) where T : Resource, new()
        {
            JToken JObj = JToken.Parse(str);
            T t = new T();
            t.JObj = JObj;
            return t;
        }

        public static ApiConfig Instance
        {
            get
            {
                if (m_instance == null)
                    throw new Exception("Not yet configured!");

                return m_instance;
            }
        }

        public void updateConnectTimeoutInMillis(int timeout)
        {
            ConnectTimeout = timeout;
        }
    }
}
