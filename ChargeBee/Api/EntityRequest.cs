using System;

namespace ChargeBee.Api
{
	public class EntityRequest<T>
    {
        string m_url;
        protected HttpMethod m_method;
        protected Params m_params = new Params();

		public EntityRequest(string url, HttpMethod method)
		{
			m_url = url;
			m_method = method;
		}

		public T Param(String paramName, Object value){
			m_params.Add(paramName, value);
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
                    return ApiUtil.Get(m_url, m_params, env);
                case HttpMethod.POST:
                    return ApiUtil.Post(m_url, m_params, env);
                default:
                    throw new NotImplementedException(String.Format(
                        "HTTP method {0} is not implemented",
                        Enum.GetName(typeof(HttpMethod), m_method)));
            }

        }
    }
}
