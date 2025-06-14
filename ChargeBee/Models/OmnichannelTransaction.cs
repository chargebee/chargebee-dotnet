using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class OmnichannelTransaction : Resource 
    {
    
        public OmnichannelTransaction() { }

        public OmnichannelTransaction(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OmnichannelTransaction(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OmnichannelTransaction(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string IdAtSource 
        {
            get { return GetValue<string>("id_at_source", true); }
        }
        public string AppId 
        {
            get { return GetValue<string>("app_id", true); }
        }
        public string PriceCurrency 
        {
            get { return GetValue<string>("price_currency", false); }
        }
        public long? PriceUnits 
        {
            get { return GetValue<long?>("price_units", false); }
        }
        public long? PriceNanos 
        {
            get { return GetValue<long?>("price_nanos", false); }
        }
        public TypeEnum OmnichannelTransactionType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public DateTime? TransactedAt 
        {
            get { return GetDateTime("transacted_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        
        #endregion
        

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "purchase")]
            Purchase,
            [EnumMember(Value = "renewal")]
            Renewal,

        }

        #region Subclasses

        #endregion
    }
}
