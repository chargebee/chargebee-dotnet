using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;

namespace ChargeBee.Api
{
    public class ListResult
    {
        public ListResult(HttpStatusCode statusCode, string json)
            : this(statusCode, json, null)
        {
        }

        public ListResult(HttpStatusCode statusCode, string json, HttpResponseHeaders responseHeaders)
        {
            List = new List<Entry>();

            JObject jobj = JObject.Parse(json);

            foreach (var item in jobj["list"].Children())
            {
                List.Add(new Entry(item));
            }

            JToken t = jobj["next_offset"];
            if (t != null)
            {
                NextOffset = t.ToString();
            }

            StatusCode = statusCode;
            ResponseHeaders = responseHeaders;

        }

        public HttpStatusCode StatusCode { get; private set; }

        public HttpResponseHeaders ResponseHeaders { get; private set; }

        public List<Entry> List { get; private set; }

        public string NextOffset { get; private set; }

		public class Entry : ResultBase
		{
			public Entry() { }
			
			internal Entry(string json)
			{
				if (!String.IsNullOrEmpty(json))
					m_jobj = JToken.Parse(json);
			}
			
			internal Entry(JToken jobj)
			{
				m_jobj = jobj;
			}
		}
    }
}
