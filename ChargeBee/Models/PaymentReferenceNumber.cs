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

    public class PaymentReferenceNumber : Resource 
    {
    
        public PaymentReferenceNumber() { }

        public PaymentReferenceNumber(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PaymentReferenceNumber(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PaymentReferenceNumber(String jsonString)
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
        public TypeEnum PaymentReferenceNumberType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public string Number 
        {
            get { return GetValue<string>("number", true); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", false); }
        }
        
        #endregion
        

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "kid")]
            Kid,
            [EnumMember(Value = "ocr")]
            Ocr,
            [EnumMember(Value = "frn")]
            Frn,
            [EnumMember(Value = "fik")]
            Fik,

        }

        #region Subclasses

        #endregion
    }
}
