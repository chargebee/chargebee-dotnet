using System.Collections.Generic;

namespace ChargeBee.Api
{
    public class ListRequest
    {
        string m_url;
		protected HttpMethod m_method = HttpMethod.GET;
		protected Params m_params = new Params();
		protected Dictionary<string, string> headers = new Dictionary<string, string>();

        public ListRequest(string url)
        {
            m_url = url;
        }

        public ListRequest Limit(int limit)
        {
            m_params.AddOpt("limit", limit);
            return this;
        }

        public ListRequest Offset(string offset)
        {
            m_params.AddOpt("offset", offset);
            return this;
        }

		public ListRequest Header(string headerName, string headerValue){
			headers.Add (headerName, headerValue);
			return this;
		}

        public ListResult Request(ApiConfig env)
        {
			return ApiUtil.GetList(m_url, m_params, headers, ApiConfig.Instance);
        }

        public ListResult Request()
        {
            return Request(ApiConfig.Instance);
        }
    }
}
