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

    public class Token : Resource 
    {
    
        public Token() { }

        public Token(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Token(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Token(String jsonString)
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
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", true); }
        }
        public PaymentMethodTypeEnum PaymentMethodType 
        {
            get { return GetEnum<PaymentMethodTypeEnum>("payment_method_type", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string IdAtVault 
        {
            get { return GetValue<string>("id_at_vault", true); }
        }
        public VaultEnum Vault 
        {
            get { return GetEnum<VaultEnum>("vault", true); }
        }
        public string IpAddress 
        {
            get { return GetValue<string>("ip_address", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? ExpiredAt 
        {
            get { return GetDateTime("expired_at", false); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "new")]
            New,
            [EnumMember(Value = "expired")]
            Expired,
            [EnumMember(Value = "consumed")]
            Consumed,

        }
        public enum VaultEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "spreedly")]
            Spreedly,
            [EnumMember(Value = "gateway")]
            Gateway,

        }

        #region Subclasses

        #endregion
    }
}
