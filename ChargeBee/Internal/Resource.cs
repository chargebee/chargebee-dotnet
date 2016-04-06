using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json.Linq;

using ChargeBee.Api;

namespace ChargeBee.Internal
{
	public class Resource : JSONSupport
	{
		public Resource() { }

		internal Resource(string json)
		{
			if (!String.IsNullOrEmpty(json))
				m_jobj = JToken.Parse(json);
		}
		
		internal Resource(JToken jobj)
		{
			m_jobj = jobj;
		}

		public T GetValue<T>(string key, bool required = true)
		{
			if (required)
				ThrowIfKeyMissed(key);
			
			if (m_jobj[key] == null) return default(T);
			
			return m_jobj[key].ToObject<T>();
		}

		public DateTime? GetDateTime(string key, bool required = true)
		{
			long? ts = GetValue<long?>(key, required);
			if (ts == null) return null;
			return ApiUtil.ConvertFromTimestamp((long)ts);
		}

		public JToken GetJToken(string key, bool required = true)
		{
			if (required)
				ThrowIfKeyMissed (key);

			if (m_jobj [key] == null)
				return null;

			return JToken.Parse(m_jobj[key].ToString());
		}
		
		public T GetEnum<T>(string key, bool required = true)
		{
			string value = GetValue<string>(key, required);
			if (String.IsNullOrEmpty(value)) return default(T);
			
			Type eType = typeof(T);
			
			// Handle nullable enum
			if (eType.IsGenericType)
				eType = eType.GetGenericArguments()[0];
			
			foreach (var fi in eType.GetFields())
			{
				DescriptionAttribute[] attrs = 
					(DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
				
				if (attrs.Length == 0)
					continue;
				
				if (value == attrs[0].Description)
					return (T)fi.GetValue(null);
			}
			
			return default(T);
		}
		
		protected void ThrowIfKeyMissed(string key)
		{
			if (m_jobj[key] == null)
				throw new ArgumentException(String.Format("The property {0} is not present!", key));
		}

		protected static string CheckNull(string id)
		{
			if (String.IsNullOrEmpty(id))
				throw new ArgumentException("ID can't be null or emtpy!");
			
			return id;
		}

		protected List<T> GetResourceList<T>(string property) where T : Resource, new()
		{
			if (m_jobj == null)
				return null;
			
			JToken jobj = m_jobj[property];
			if (jobj == null)
				return null;
			
			List<T> list = new List<T>();
			foreach (var item in jobj.Children())
			{
				T t = new T();
				t.JObj = item;
				list.Add(t);
			}
			
			return list;
		}


		protected List<T> GetList<T>(string property) 
		{
			if (m_jobj == null)
				return null;
			
			JToken jobj = m_jobj[property];
			if (jobj == null)
				return null;
			
			List<T> list = new List<T>();
			foreach (var item in jobj.Children())
			{
				list.Add(item.ToObject<T>());
			}
			
			return list;
		}

		protected T GetSubResource<T>(string property) where T : Resource, new()
		{
			if (m_jobj == null)
				return null;
			
			JToken jobj = m_jobj[property];
			if (jobj == null)
				return null;
			T t = new T();
			t.JObj = jobj;
			return t;
		}

		protected static void apiVersionCheck(JToken jObj){
			if (jObj ["api_version"] == null) {
				return;
			}
			string apiVersion =  jObj ["api_version"].ToString ().ToUpper();
			if(!apiVersion.Equals(ApiConfig.API_VERSION, StringComparison.OrdinalIgnoreCase)) {
				throw new ArgumentException ("API version [" + apiVersion + "] in response does not match "
					+ "with client library API version [" + ApiConfig.API_VERSION.ToUpper() + "]");
			}
		}

	}
}

