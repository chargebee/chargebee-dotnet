using Newtonsoft.Json.Linq;

namespace ChargeBee.Internal
{
	public class JSONSupport
	{
		protected JToken m_jobj;
		
		internal JToken JObj
		{
			get { return m_jobj; }
			set { m_jobj = value; }
		}
	}
}

