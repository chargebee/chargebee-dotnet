using System;
using System.Collections.Generic;

namespace ChargeBee.Api
{
	public class EntityRequest<T>
    {
		protected string m_url;
        protected HttpMethod m_method;
        protected Params m_params = new Params();
		protected Dictionary<string, string> headers = new Dictionary<string, string>();

		public EntityRequest(string url, HttpMethod method)
		{
			m_url = url;
			m_method = method;
		}

		public Params Params() {
			return m_params;
		}

		public T Param(String paramName, Object value){
			m_params.AddOpt(paramName, value);
			return (T)Convert.ChangeType (this, typeof(T));
		}

		public T Header(string headerName, string headerValue){
			headers.Add (headerName, headerValue);
			return (T)Convert.ChangeType (this, typeof(T));
		}

		public EntityResult Request()
        {
            return Request(ApiConfig.Instance);
        }

        public EntityResult Request(ApiConfig env)
        {
            switch (m_method)
            {
                case HttpMethod.GET:
					return ApiUtil.Get(m_url, m_params, headers, env);
                case HttpMethod.POST:
					return ApiUtil.Post(m_url, m_params, headers, env);
                default:
                    throw new NotImplementedException(String.Format(
                        "HTTP method {0} is not implemented",
                        Enum.GetName(typeof(HttpMethod), m_method)));
            }

        }
    }
}
