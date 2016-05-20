using System;
using ChargeBee.Api;

namespace ChargeBee
{
	public class NumberFilter<T,U> where U : ListRequestBase<U>
	{
		private U req;
		private String paramName;
		private bool supportsPresenceOperator;

		public NumberFilter(String paramName, U req) {
			this.paramName = paramName;
			this.req = req;
		}

		public NumberFilter<T,U> SupportsPresenceOperator(bool supportsPresenceOperator) {
			this.supportsPresenceOperator = supportsPresenceOperator;
			return this;
		}

		public U Gt(T value) {
			req.Params().AddOpt(paramName+"[gt]" , value);
			return req;
		}

		public U Lt(T value) {
			req.Params().AddOpt(paramName+"[lt]" , value);
			return req;
		}

		public U Gte(T value) {
			req.Params().AddOpt(paramName+"[gte]" , value);
			return req;
		}

		public U Lte(T value) {
			req.Params().AddOpt(paramName+"[lte]" , value);
			return req;
		}

		public U Between(T val1, T val2){
			req.Params().AddOpt(paramName+"[between]" , new T[]{val1,val2});
			return req;
		}

		public U Is(T value) {
			req.Params().AddOpt(paramName+"[is]" , value);
			return req;
		}

		public U IsNot(T value) {
			req.Params().AddOpt(paramName+"[is_not]" , value);
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

