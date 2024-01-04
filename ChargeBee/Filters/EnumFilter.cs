using System;
using ChargeBee.Api;

namespace ChargeBee
{
	public class EnumFilter<T, U> where U : EntityRequest<U>
	{

		private U req;
		private String paramName;
		private bool supportsPresenceOperator;
		private bool supportsMultiOperator = true;

		public EnumFilter(String paramName, U req) {
			this.paramName = paramName;
			this.req = req;
		}

		public EnumFilter<T,U> SupportsPresenceOperator(bool supportsPresenceOperator) {
			this.supportsPresenceOperator = supportsPresenceOperator;
			return this;
		}

		public U Is(T value) {
			req.Params().AddOpt(paramName + "[is]",value);
			return req;
		}

		public U IsNot(T value) {
			req.Params().AddOpt(paramName + "[is_not]",value);
			return req;
		}

		public U In(params T[] value) {
			if(!supportsMultiOperator) {
				throw new NotSupportedException("operator '[in]' is not supported for this filter-parameter");
			}

			req.Params().AddOpt(paramName + "[in]", value);
			return req;
		} 

		public U NotIn(params T[] value) {
			if(!supportsMultiOperator) {
				throw new NotSupportedException("operator '[not_in]' is not supported for this filter-parameter");
			}

			req.Params().AddOpt(paramName + "[not_in]", value);
			return req;
		}

		public U IsPresent(bool value) {
			if(!supportsPresenceOperator) {
				throw new NotSupportedException("operator '[is_present]' is not supported for this filter-parameter");
			}
			req.Params().AddOpt(paramName + "[is_present]", value);
			return req;
		}

		public EnumFilter<T,U> SupportsMultiOperators(bool supportsMultiOperators) {
			this.supportsMultiOperator = supportsMultiOperators;
			return this;
		}
	}
}

