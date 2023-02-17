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

    public class TaxWithheld : Resource 
    {
    
        public TaxWithheld() { }

        public TaxWithheld(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public TaxWithheld(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public TaxWithheld(String jsonString)
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
        [Obsolete]
        public string User 
        {
            get { return GetValue<string>("user", false); }
        }
        public string ReferenceNumber 
        {
            get { return GetValue<string>("reference_number", false); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        [Obsolete]
        public TypeEnum TaxWithheldType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        [Obsolete]
        public PaymentMethodEnum PaymentMethod 
        {
            get { return GetEnum<PaymentMethodEnum>("payment_method", true); }
        }
        public DateTime? Date 
        {
            get { return GetDateTime("date", false); }
        }
        [Obsolete]
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public int? Amount 
        {
            get { return GetValue<int?>("amount", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        [Obsolete]
        public decimal? ExchangeRate 
        {
            get { return GetValue<decimal?>("exchange_rate", false); }
        }
        
        #endregion
        

        [Obsolete]
        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "payment")]
            Payment,
            [EnumMember(Value = "refund")]
            Refund,

        }
        [Obsolete]
        public enum PaymentMethodEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "cash")]
            Cash,
            [EnumMember(Value = "check")]
            Check,
            [EnumMember(Value = "chargeback")]
            Chargeback,
            [EnumMember(Value = "bank_transfer")]
            BankTransfer,
            [EnumMember(Value = "other")]
            Other,

        }

        #region Subclasses

        #endregion
    }
}
