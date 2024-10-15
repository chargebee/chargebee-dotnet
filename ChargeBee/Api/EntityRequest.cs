using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChargeBee.Internal;

namespace ChargeBee.Api
{
	public class EntityRequest<T>
    {
		protected string m_url;
        protected HttpMethod m_method;
        protected Params m_params = new Params();
		protected Dictionary<string, string> headers = new Dictionary<string, string>();
		protected bool m_supportsFilter;

		public EntityRequest(string url, HttpMethod method, bool supportsFilter = false)
		{
			m_url = url;
			m_method = method; 
			m_supportsFilter = supportsFilter;
		}
		
		public T SetIdempotencyKey(string idempotencyKey){
			headers.Add (IdempotencyConstants.IDEMPOTENCY_HEADER, idempotencyKey);
			return (T)Convert.ChangeType (this, typeof(T));
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

        public Task<EntityResult> RequestAsync()
        {
            return RequestAsync(ApiConfig.Instance);
        }

        public EntityResult Request(ApiConfig env)
        {
            switch (m_method)
            {
                case HttpMethod.GET:
					return ApiUtil.Get(m_url, m_params, headers, env, m_supportsFilter);
                case HttpMethod.POST:
					return ApiUtil.Post(m_url, m_params, headers, env, m_supportsFilter);
                default:
                    throw new NotImplementedException(String.Format(
                        "HTTP method {0} is not implemented",
                        Enum.GetName(typeof(HttpMethod), m_method)));
            }

        }

        public Task<EntityResult> RequestAsync(ApiConfig env)
        {
            switch (m_method)
            {
                case HttpMethod.GET:
                    return ApiUtil.GetAsync(m_url, m_params, headers, env, m_supportsFilter);
                case HttpMethod.POST:
                    return ApiUtil.PostAsync(m_url, m_params, headers, env, m_supportsFilter);
                default:
                    throw new NotImplementedException(String.Format(
                        "HTTP method {0} is not implemented",
                        Enum.GetName(typeof(HttpMethod), m_method)));
            }

        }
    }
}
