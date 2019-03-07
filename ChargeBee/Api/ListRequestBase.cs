using System.Collections.Generic;

namespace ChargeBee.Api
{
	public class ListRequestBase<U> : EntityRequest<U> where U : ListRequestBase<U> 
	{
		public ListRequestBase(string url) : base(url, HttpMethod.GET)
		{
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

		public new ListResult Request(ApiConfig env)
		{
			return ApiUtil.GetList(m_url, m_params, headers, ApiConfig.Instance);
		}

		public new ListResult Request()
		{
			return Request(ApiConfig.Instance);
		}

	}
}
