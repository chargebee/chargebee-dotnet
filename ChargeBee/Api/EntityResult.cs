using System.Net;
using ChargeBee.Internal;

namespace ChargeBee.Api
{
    public class EntityResult : ResultBase
    {

        public EntityResult(HttpStatusCode statusCode, string json)
            : base(json)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; private set; }

    }
}
