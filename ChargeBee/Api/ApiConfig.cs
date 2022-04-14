using System;
using System.Net.Http;
using System.Text;

namespace ChargeBee.Api
{
    public sealed class ApiConfig
    {
		public static string DomainSuffix = "chargebee.com";
		public static string Proto = "https";
		public static string Version = "2.15.0";
		public static readonly string API_VERSION = "v2";
        public static int TimeTravelMillis { get; set; }
        public static int ExportSleepMillis { get; set;}

        public string ApiKey { get; set; }
        public string SiteName { get; set; }
        public string Charset { get; set; }
        public static int ConnectTimeout { get; set; }
        
        public static HttpMessageHandler HttpMessageHandler { get; set; }

        public string ApiBaseUrl =>
            String.Format("{0}://{1}.{2}/api/{3}",
                Proto,
                SiteName,
                DomainSuffix,
                API_VERSION);

        public string AuthValue =>
            String.Format("Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    String.Format("{0}:", ApiKey))));

        public ApiConfig(string siteName, string apiKey, HttpMessageHandler httpMessageHandler = null)
        {

            if (String.IsNullOrEmpty(siteName))
                throw new ArgumentException("Site name can't be empty!");

            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Api key can't be empty!");

            Charset = Encoding.UTF8.WebName;
            ConnectTimeout = 30000;
            TimeTravelMillis = 3000;
            ExportSleepMillis = 10000;
            SiteName = siteName;
            ApiKey = apiKey;
            HttpMessageHandler = httpMessageHandler;
        }

        private static volatile ApiConfig m_instance;

        public static void Configure(string siteName, string apiKey, HttpMessageHandler httpMessageHandler = null)
        {         
            m_instance = new ApiConfig(siteName, apiKey, httpMessageHandler);
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

        public static void updateConnectTimeoutInMillis(int timeout) {
                    ConnectTimeout = timeout;
        }
    }
}
