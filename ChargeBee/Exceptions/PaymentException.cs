using System;
using System.Collections.Generic;
using System.Net;

using ChargeBee.Api;
using Newtonsoft.Json.Linq;

namespace ChargeBee.Exceptions
{
	public class PaymentException : ApiException
	{
		public PaymentException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorJson)
			: base(httpStatusCode, errorJson)
		{
		}
		
		public PaymentException (HttpStatusCode httpStatusCode, JObject errorJson)
			: base(httpStatusCode, errorJson)
		{
		}
	}
}

