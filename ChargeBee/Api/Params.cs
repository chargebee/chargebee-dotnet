using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ChargeBee.Api
{
    public class Params
    {
        Dictionary<string, string> m_dict = new Dictionary<string, string>();

        public void Add(string key, object value)
        {
            if (value == null || String.IsNullOrEmpty(value.ToString()))
                throw new ArgumentException(String.Format("Value for {0} can't be empty or null!", key));

            AddOpt(key, value);
        }

        public void AddOpt(string key, object value)
        {
            if (value is Enum)
            {
                Type eType = value.GetType();
                FieldInfo fi = eType.GetField(value.ToString());
                DescriptionAttribute[] attrs = (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

                if (attrs.Length == 0)
                    throw new ArgumentException("Enum fields must be decorated with DescriptionAttribute!");

                value = attrs[0].Description;
            }

            m_dict.Add(key, value == null ? String.Empty : value.ToString());
        }

        public string GetQuery()
        {
            return String.Join("&", GetPairs());
        }

        private string[] GetPairs()
        {
            List<string> pairs = new List<string>(m_dict.Keys.Count);

            foreach (var pair in m_dict)
            {
                pairs.Add(String.Format("{0}={1}", ApiUtil.Encode(pair.Key), ApiUtil.Encode(pair.Value)));
            }

            return pairs.ToArray();
        }
    }
}
