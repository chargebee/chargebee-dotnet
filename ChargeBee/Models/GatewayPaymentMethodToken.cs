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

    public class GatewayPaymentMethodToken : Resource 
    {
    
        public GatewayPaymentMethodToken() { }

        public GatewayPaymentMethodToken(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public GatewayPaymentMethodToken(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public GatewayPaymentMethodToken(String jsonString)
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
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", true); }
        }
        public GatewayNameEnum GatewayName 
        {
            get { return GetEnum<GatewayNameEnum>("gateway_name", true); }
        }
        public string GatewayCustomerId 
        {
            get { return GetValue<string>("gateway_customer_id", false); }
        }
        public string GatewayToken 
        {
            get { return GetValue<string>("gateway_token", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "inactive")]
            Inactive,
            [EnumMember(Value = "pending_verification")]
            PendingVerification,

        }

        #region Subclasses

        #endregion
    }
}
