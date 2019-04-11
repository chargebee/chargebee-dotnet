using System;
using System.Collections.Generic;
using System.Net;

using ChargeBee.Api;

namespace ChargeBee.Exceptions
{
	public class PaymentException : ApiException
	{
		public PaymentException (HttpStatusCode httpStatusCode, Dictionary<string, string> errorJson)
			: base(httpStatusCode, errorJson)
		{
		}
	}
}

