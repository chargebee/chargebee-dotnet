using System;
using ChargeBee.Api;

namespace ChargeBee
{
	public class TimestampFilter<U> where U : EntityRequest<U> {
		
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

		public U Between(DateTime value1, DateTime value2)
		{
			String serializedObject = Serialize(value1, value2);
			req.Params().AddOpt(paramName + "[between]", serializedObject);
			return req;
		}

		public U IsPresent(bool value) {
			if(!supportsPresenceOperator) {
				throw new NotSupportedException("operator '[is_present]' is not supported for this filter-parameter");
			}
			req.Params().AddOpt(paramName + "[is_present]", value);
			return req;
		}

		private String Serialize(DateTime value1, DateTime value2)
        	{
			return ApiUtil.SerializeObject(new Int64[] { (Int64)ApiUtil.ConvertToTimestamp(value1), (Int64)ApiUtil.ConvertToTimestamp(value2) });

		}

	}
}

