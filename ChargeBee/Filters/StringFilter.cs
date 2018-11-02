using System;
using ChargeBee.Api;
using Newtonsoft.Json.Linq;

namespace ChargeBee
{
	public class StringFilter<U> where U : EntityRequest<U>
	{
		private U req;
		private String paramName;
		private bool supportsMultiOperator;
		private bool supportsPresenceOperator;

		public StringFilter(String paramName, U req) {
			this.paramName = paramName;
			this.req = req;
			this.supportsPresenceOperator = true;
		}

		public StringFilter<U> SupportsPresenceOperator(bool supportsPresenceOperators) {
			this.supportsPresenceOperator = supportsPresenceOperators;
			return this;
		}

		public StringFilter<U> SupportsMultiOperators(bool supportsMultiOperators) {
			this.supportsMultiOperator = supportsMultiOperators;
			return this;
		}

		public U Is(String value) {
			req.Params().AddOpt(paramName + "[is]",value);
			return req;
		}


		public U IsNot(String value) {
			req.Params().AddOpt(paramName + "[is_not]",value);
			return req;
		}

		public U StartsWith(String value) {
			req.Params().AddOpt(paramName + "[starts_with]", value);
			return req;
		}

		public U IsPresent(bool value) {
			if(!supportsPresenceOperator) {
				throw new NotSupportedException("operator '[is_present]' is not supported for this filter-parameter");
			}
			req.Params().AddOpt(paramName + "[is_present]", value);
			return req;
		}

		public U In(params String[] value) {
			if(!supportsMultiOperator) {
				throw new NotSupportedException("operator '[in]' is not supported for this filter-parameter");
			}

			req.Params().AddOpt(paramName + "[in]", value );
			return req;
		}

		public U NotIn(params String[] value) {
			if(!supportsMultiOperator) {
				throw new NotSupportedException("operator '[not_in]' is not supported for this filter-parameter");
			}
			req.Params().AddOpt(paramName + "[not_in]", value);
			return req;
		}
	}
}

