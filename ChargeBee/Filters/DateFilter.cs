using System;
using ChargeBee.Api;

namespace ChargeBee
{
	public class DateFilter<U> where U : EntityRequest<U> {
		
		private U req;
		private String paramName;
		private bool supportsPresenceOperator;

		public DateFilter(String paramName, U req) {
			this.paramName = paramName;
			this.req = req;
		}

		public DateFilter<U> SupportsPresenceOperator(bool supportsPresenceOperator) {
			this.supportsPresenceOperator = supportsPresenceOperator;
			return this;
		}
			
		public U On(DateTime value) {
			req.Params().AddOpt(paramName + "[on]",value, true);
			return req;
		}

		public U Before(DateTime value) {
			req.Params().AddOpt(paramName + "[before]",value, true);
			return req;
		}

		public U After(DateTime value) {
			req.Params().AddOpt(paramName + "[after]",value, true);
			return req;
		}

		public U Between(DateTime value1, DateTime value2) {
			req.Params().AddOpt(paramName + "[between]", new DateTime[]{value1, value2}, true);
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

