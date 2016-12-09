using System;
using System.Text;

namespace ChargeBee.Api
{
    public sealed class ApiConfig
    {
		public static string DomainSuffix = "chargebee.com";
		public static string Proto = "https";
		public static string Version = "2.2.1";
		public static readonly string API_VERSION = "v2";

		public string ApiKey { get; set; }
        public string SiteName { get; set; }
        public string Charset { get; set; }
        public int ConnectTimeout { get; set; }
        public int ReadTimeout { get; set; }

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
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(
                    String.Format("{0}:", ApiKey))));
            }
        }

        private ApiConfig(string siteName, string apiKey)
        {
            Charset = Encoding.UTF8.WebName;
            ConnectTimeout = 15000;
            ReadTimeout = 60000;

            SiteName = siteName;
            ApiKey = apiKey;
        }

        private static volatile ApiConfig m_instance;

        public static void Configure(string siteName, string apiKey)
        {
            if (String.IsNullOrEmpty(siteName))
                throw new ArgumentException("Site name can't be empty!");

            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Api key can't be empty!");

            m_instance = new ApiConfig(siteName, apiKey);
        }

        public static ApiConfig Instance
        {
            get
            {
                if (m_instance == null)
                    throw new ApplicationException("Not yet configured!");

                return m_instance;
            }
        }
    }
}
