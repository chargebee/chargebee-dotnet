using System;
using System.Net;
using System.Runtime.Serialization;

namespace ChargeBee.Api
{
    public class ApiException : ApplicationException
    {
        public ApiException(SerializationInfo info, StreamingContext context)
        {
            if (info != null)
            {
                foreach (var item in info)
                {
                    switch (item.Name)
                    {
                        case "error_code":
                            ApiCode = item.Value.ToString();
                            break;
                        case "error_param":
                            Parameter = item.Value.ToString();
                            break;
                        case "error_msg":
                            ApiMessage = item.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("error_code", ApiCode);
                info.AddValue("error_param", Parameter);
                info.AddValue("error_msg", ApiMessage);
            }
        }

        public HttpStatusCode HttpCode { get; set; }

        public string ApiCode { get; set; }

        public string Parameter { get; set; }

        public string ApiMessage { get; set; }

        public override string Message
        {
            get
            {
                return ApiMessage;
            }
        }
    }
}
