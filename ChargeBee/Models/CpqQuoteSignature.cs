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

    public class CpqQuoteSignature : Resource 
    {
    
        public CpqQuoteSignature() { }

        public CpqQuoteSignature(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CpqQuoteSignature(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CpqQuoteSignature(String jsonString)
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
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", false); }
        }
        public string DocumentName 
        {
            get { return GetValue<string>("document_name", false); }
        }
        public CustomerAcceptanceMethodEnum CustomerAcceptanceMethod 
        {
            get { return GetEnum<CustomerAcceptanceMethodEnum>("customer_acceptance_method", true); }
        }
        public QuoteTypeEnum QuoteType 
        {
            get { return GetEnum<QuoteTypeEnum>("quote_type", true); }
        }
        public DateTime? ExpiresAt 
        {
            get { return GetDateTime("expires_at", false); }
        }
        public string Timezone 
        {
            get { return GetValue<string>("timezone", false); }
        }
        public string ProviderRequestId 
        {
            get { return GetValue<string>("provider_request_id", false); }
        }
        public string ProviderDocumentId 
        {
            get { return GetValue<string>("provider_document_id", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "draft")]
            Draft,
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "signed")]
            Signed,
            [EnumMember(Value = "expired")]
            Expired,
            [EnumMember(Value = "cancelled")]
            Cancelled,
            [EnumMember(Value = "declined")]
            Declined,

        }
        public enum CustomerAcceptanceMethodEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "esign_and_pay")]
            EsignAndPay,
            [EnumMember(Value = "esign")]
            Esign,
            [EnumMember(Value = "pay")]
            Pay,

        }
        public enum QuoteTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "consolidated")]
            Consolidated,
            [EnumMember(Value = "detailed")]
            Detailed,

        }

        #region Subclasses

        #endregion
    }
}
