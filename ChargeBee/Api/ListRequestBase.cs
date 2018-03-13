using System.Collections.Generic;

namespace ChargeBee.Api
{
	public class ListRequestBase<U> where U : ListRequestBase<U>
	{
		string m_url;
		protected HttpMethod m_method = HttpMethod.GET;
		protected Params m_params = new Params();
		protected Dictionary<string, string> headers = new Dictionary<string, string>();

		public ListRequestBase(string url)
		{
			m_url = url;
		}

		public U Limit(int limit)
		{
			m_params.AddOpt("limit", limit);
			return (U)this;
		}

		public U Offset(string offset)
		{
			m_params.AddOpt("offset", offset);
			return (U)this;
		}

		public StringFilter<U> StringFilterParam(string paranName){
			return new StringFilter<U>(paranName, (U)this).SupportsMultiOperators(true).SupportsPresenceOperator(true);
		}

		public BooleanFilter<U> BooleanFilterParam(string paramName){
			return new BooleanFilter<U>(paramName, (U)this).SupportsPresenceOperator(true);
    	}
    
		public NumberFilter<long, U> LongFilterParam(string paramName) {
			return new NumberFilter<long, U>(paramName, (U)this).SupportsPresenceOperator(true);
    	}
    	
    	
    	public TimestampFilter<U> TimestampFilterParam(string paramName){
			return new TimestampFilter<U>(paramName, (U)this).SupportsPresenceOperator(true);
    	}

		public DateFilter<U> DateFilterParam(string paramName){
			return new DateFilter<U>(paramName, (U)this).SupportsPresenceOperator(true);
		}
    
		public U Header(string headerName, string headerValue){
			headers[headerName] = headerValue;
			return (U)this;
		}

		public ListResult Request(ApiConfig env)
		{
			return ApiUtil.GetList(m_url, m_params, headers, env);
		}

		public ListResult Request()
		{
			return Request(ApiConfig.Instance);
		}

		public Params Params() {
			return m_params;
		}

	}
}
