using System;
using ChargeBee.Api;

namespace ChargeBee
{
	public class BooleanFilter<U> where U : ListRequestBase<U>
	{
		private U req;
		private String paramName;

		public BooleanFilter(String paramName, U req) {
			this.paramName = paramName;
			this.req = req;
		}

		public U Is(bool value) {
			req.Params().AddOpt(paramName + "[is]", value);
			return req;
		}

	}
}

