﻿using System;
using System.Net;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ChargeBee.Api
{
    public class ApiException : Exception
    {

		private string ErrorType = "";
		private string ErrorParam = "";
		private string ErrorErrorCauseId = "";

		public ApiException (HttpStatusCode httpStatusCode, Dictionary<string, string> errorResp)
			: base (errorResp ["message"])
        {
			this.HttpStatusCode = httpStatusCode;
			errorResp.TryGetValue ("type", out ErrorType);
			this.ApiErrorCode = errorResp ["api_error_code"];

			errorResp.TryGetValue("param", out ErrorParam);
			errorResp.TryGetValue("error_cause_id", out ErrorErrorCauseId);

			//Deprecated fields.
			this.ApiCode = errorResp ["error_code"];
			this.ApiMessage = errorResp ["error_msg"];
        }

        public HttpStatusCode HttpStatusCode { get; set; }

		public string Type { 
			get {
				return this.ErrorType;
			}
		}

		public string ApiErrorCode { get; set; }

        public string Param { 
			get {
				return this.ErrorParam;
			}
		}

		public string ErrorCauseId { 
			get {
				return this.ErrorErrorCauseId;
			}
		}

        [System.Obsolete("Use HttpStatusCode")]
        public HttpStatusCode HttpCode { 
			get {
				return HttpStatusCode;
			}
		}

		public string ApiCode { get; set; }

        [System.Obsolete("Use Param")]
		public string Parameter { 
			get { 
				return Param;
			} 
		}

        public string ApiMessage { get; set; }

    }
}
