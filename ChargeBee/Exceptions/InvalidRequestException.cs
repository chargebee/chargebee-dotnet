﻿using System;
using System.Collections.Generic;
using System.Net;

using ChargeBee.Api;
using Newtonsoft.Json.Linq;

namespace ChargeBee.Exceptions
{
	public class InvalidRequestException : ApiException
	{
		public InvalidRequestException(HttpStatusCode httpStatusCode, Dictionary<string, string> errorJson)
			: base(httpStatusCode, errorJson)
		{
		}
		
		public InvalidRequestException (HttpStatusCode httpStatusCode, JObject errorJson)
			: base(httpStatusCode, errorJson)
		{
		}
	}
}

