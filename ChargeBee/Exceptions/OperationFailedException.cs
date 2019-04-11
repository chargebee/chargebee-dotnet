using System;
using System.Collections.Generic;
using System.Net;

using ChargeBee.Api;

namespace ChargeBee.Exceptions
{
	public class OperationFailedException : ApiException
	{
		public OperationFailedException (HttpStatusCode httpStatusCode, Dictionary<string, string> errorJson)
			:base(httpStatusCode, errorJson)
		{
		}
	}
}

