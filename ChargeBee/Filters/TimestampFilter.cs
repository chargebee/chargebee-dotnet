using System;
using ChargeBee.Api;

namespace ChargeBee
{
	public class TimestampFilter<U> where U : ListRequestBase<U> {
		
		private U req;
		private String paramName;
		private bool supportsPresenceOperator;

		public TimestampFilter(String paramName, U req) {
			this.paramName = paramName;
			this.req = req;
		}

		public TimestampFilter<U> SupportsPresenceOperator(bool supportsPresenceOperator) {
			this.supportsPresenceOperator = supportsPresenceOperator;
			return this;
		}

		public U On(DateTime value) {
			req.Params().AddOpt(paramName + "[on]",value);
			return req;
		}

		public U Before(DateTime value) {
			req.Params().AddOpt(paramName + "[before]",value);
			return req;
		}

		public U After(DateTime value) {
			req.Params().AddOpt(paramName + "[after]",value);
			return req;
		}

		public U Between(DateTime value1, DateTime value2) {
			req.Params().AddOpt(paramName + "[between]", new DateTime[]{value1,value2});
			return req;
		}

		public U IsPresent(bool value) {
			if(!supportsPresenceOperator) {
				throw new NotSupportedException("operator '[is_present]' is not supported for this filter-parameter");
			}
			req.Params().AddOpt(paramName + "[is_present]", value);
			return req;
		}    
	}
}

