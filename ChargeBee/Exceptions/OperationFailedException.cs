using System;
using System.Collections.Generic;
using System.Net;

using ChargeBee.Api;
using Newtonsoft.Json.Linq;

namespace ChargeBee.Exceptions
{
	public class OperationFailedException : ApiException
	{
		public OperationFailedException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorJson)
			: base(httpStatusCode, errorJson)
		{
		}
		
		public OperationFailedException (HttpStatusCode httpStatusCode, JObject errorJson)
			:base(httpStatusCode, errorJson)
		{
		}
	}
}

