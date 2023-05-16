using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using ChargeBee.Internal;

namespace ChargeBee.Api
{
    public class EntityResult : ResultBase
    {

        public EntityResult(HttpStatusCode statusCode, string json)
            : this(statusCode, json, null)
        {
        }

        public EntityResult(HttpStatusCode statusCode, string json, HttpResponseHeaders responseHeaders)
            : base(json)
        {
            StatusCode = statusCode;
            ResponseHeaders = responseHeaders;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public HttpResponseHeaders ResponseHeaders { get; private set; }

        public bool IsIdempotencyReplayed()
        {
            HttpResponseHeaders headers = ResponseHeaders;
            if (headers != null && headers.TryGetValues(IdempotencyConstants.IDEMPOTENCY_REPLAY_HEADER, out IEnumerable<string> values))
            {
                return values.Any();
            }
            return false;
        }

    }
}