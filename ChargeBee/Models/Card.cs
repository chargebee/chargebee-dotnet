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

    public class Card : Resource 
    {
    
        public Card() { }

        public Card(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Card(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Card(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("cards", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateCardForCustomerRequest UpdateCardForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "credit_card");
            return new UpdateCardForCustomerRequest(url, HttpMethod.POST);
        }
        public static SwitchGatewayForCustomerRequest SwitchGatewayForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "switch_gateway");
            return new SwitchGatewayForCustomerRequest(url, HttpMethod.POST);
        }
        public static CopyCardForCustomerRequest CopyCardForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "copy_card");
            return new CopyCardForCustomerRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> DeleteCardForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "delete_card");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string PaymentSourceId 
        {
            get { return GetValue<string>("payment_source_id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", false); }
        }
        public string RefTxId 
        {
            get { return GetValue<string>("ref_tx_id", false); }
        }
        public string FirstName 
        {
            get { return GetValue<string>("first_name", false); }
        }
        public string LastName 
        {
            get { return GetValue<string>("last_name", false); }
        }
        public string Iin 
        {
            get { return GetValue<string>("iin", true); }
        }
        public string Last4 
        {
            get { return GetValue<string>("last4", true); }
        }
        public CardTypeEnum? CardType 
        {
            get { return GetEnum<CardTypeEnum>("card_type", false); }
        }
        public FundingTypeEnum FundingType 
        {
            get { return GetEnum<FundingTypeEnum>("funding_type", true); }
        }
        public int ExpiryMonth 
        {
            get { return GetValue<int>("expiry_month", true); }
        }
        public int ExpiryYear 
        {
            get { return GetValue<int>("expiry_year", true); }
        }
        public string IssuingCountry 
        {
            get { return GetValue<string>("issuing_country", false); }
        }
        public string BillingAddr1 
        {
            get { return GetValue<string>("billing_addr1", false); }
        }
        public string BillingAddr2 
        {
            get { return GetValue<string>("billing_addr2", false); }
        }
        public string BillingCity 
        {
            get { return GetValue<string>("billing_city", false); }
        }
        public string BillingStateCode 
        {
            get { return GetValue<string>("billing_state_code", false); }
        }
        public string BillingState 
        {
            get { return GetValue<string>("billing_state", false); }
        }
        public string BillingCountry 
        {
            get { return GetValue<string>("billing_country", false); }
        }
        public string BillingZip 
        {
            get { return GetValue<string>("billing_zip", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string IpAddress 
        {
            get { return GetValue<string>("ip_address", false); }
        }
        public PoweredByEnum? PoweredBy 
        {
            get { return GetEnum<PoweredByEnum>("powered_by", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string MaskedNumber 
        {
            get { return GetValue<string>("masked_number", false); }
        }
        
        #endregion
        
        #region Requests
        public class UpdateCardForCustomerRequest : EntityRequest<UpdateCardForCustomerRequest> 
        {
            public UpdateCardForCustomerRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            [Obsolete]
            public UpdateCardForCustomerRequest Gateway(ChargeBee.Models.Enums.GatewayEnum gateway) 
            {
                m_params.AddOpt("gateway", gateway);
                return this;
            }
            public UpdateCardForCustomerRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.AddOpt("gateway_account_id", gatewayAccountId);
                return this;
            }
            public UpdateCardForCustomerRequest TmpToken(string tmpToken) 
            {
                m_params.AddOpt("tmp_token", tmpToken);
                return this;
            }
            public UpdateCardForCustomerRequest FirstName(string firstName) 
            {
                m_params.AddOpt("first_name", firstName);
                return this;
            }
            public UpdateCardForCustomerRequest LastName(string lastName) 
            {
                m_params.AddOpt("last_name", lastName);
                return this;
            }
            public UpdateCardForCustomerRequest Number(string number) 
            {
                m_params.Add("number", number);
                return this;
            }
            public UpdateCardForCustomerRequest ExpiryMonth(int expiryMonth) 
            {
                m_params.Add("expiry_month", expiryMonth);
                return this;
            }
            public UpdateCardForCustomerRequest ExpiryYear(int expiryYear) 
            {
                m_params.Add("expiry_year", expiryYear);
                return this;
            }
            public UpdateCardForCustomerRequest Cvv(string cvv) 
            {
                m_params.AddOpt("cvv", cvv);
                return this;
            }
            public UpdateCardForCustomerRequest BillingAddr1(string billingAddr1) 
            {
                m_params.AddOpt("billing_addr1", billingAddr1);
                return this;
            }
            public UpdateCardForCustomerRequest BillingAddr2(string billingAddr2) 
            {
                m_params.AddOpt("billing_addr2", billingAddr2);
                return this;
            }
            public UpdateCardForCustomerRequest BillingCity(string billingCity) 
            {
                m_params.AddOpt("billing_city", billingCity);
                return this;
            }
            public UpdateCardForCustomerRequest BillingStateCode(string billingStateCode) 
            {
                m_params.AddOpt("billing_state_code", billingStateCode);
                return this;
            }
            public UpdateCardForCustomerRequest BillingState(string billingState) 
            {
                m_params.AddOpt("billing_state", billingState);
                return this;
            }
            public UpdateCardForCustomerRequest BillingZip(string billingZip) 
            {
                m_params.AddOpt("billing_zip", billingZip);
                return this;
            }
            public UpdateCardForCustomerRequest BillingCountry(string billingCountry) 
            {
                m_params.AddOpt("billing_country", billingCountry);
                return this;
            }
            [Obsolete]
            public UpdateCardForCustomerRequest IpAddress(string ipAddress) 
            {
                m_params.AddOpt("ip_address", ipAddress);
                return this;
            }
            [Obsolete]
            public UpdateCardForCustomerRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
        }
        public class SwitchGatewayForCustomerRequest : EntityRequest<SwitchGatewayForCustomerRequest> 
        {
            public SwitchGatewayForCustomerRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            [Obsolete]
            public SwitchGatewayForCustomerRequest Gateway(ChargeBee.Models.Enums.GatewayEnum gateway) 
            {
                m_params.AddOpt("gateway", gateway);
                return this;
            }
            public SwitchGatewayForCustomerRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.Add("gateway_account_id", gatewayAccountId);
                return this;
            }
        }
        public class CopyCardForCustomerRequest : EntityRequest<CopyCardForCustomerRequest> 
        {
            public CopyCardForCustomerRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CopyCardForCustomerRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.Add("gateway_account_id", gatewayAccountId);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "valid")]
            Valid,
            [EnumMember(Value = "expiring")]
            Expiring,
            [EnumMember(Value = "expired")]
            Expired,

        }
        public enum CardTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "visa")]
            Visa,
            [EnumMember(Value = "mastercard")]
            Mastercard,
            [EnumMember(Value = "american_express")]
            AmericanExpress,
            [EnumMember(Value = "discover")]
            Discover,
            [EnumMember(Value = "jcb")]
            Jcb,
            [EnumMember(Value = "diners_club")]
            DinersClub,
            [EnumMember(Value = "bancontact")]
            Bancontact,
            [EnumMember(Value = "cmr_falabella")]
            CmrFalabella,
            [EnumMember(Value = "tarjeta_naranja")]
            TarjetaNaranja,
            [EnumMember(Value = "nativa")]
            Nativa,
            [EnumMember(Value = "cencosud")]
            Cencosud,
            [EnumMember(Value = "cabal")]
            Cabal,
            [EnumMember(Value = "argencard")]
            Argencard,
            [EnumMember(Value = "elo")]
            Elo,
            [EnumMember(Value = "hipercard")]
            Hipercard,
            [EnumMember(Value = "carnet")]
            Carnet,
            [EnumMember(Value = "rupay")]
            Rupay,
            [EnumMember(Value = "maestro")]
            Maestro,
            [EnumMember(Value = "other")]
            Other,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }
        public enum FundingTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "credit")]
            Credit,
            [EnumMember(Value = "debit")]
            Debit,
            [EnumMember(Value = "prepaid")]
            Prepaid,
            [EnumMember(Value = "not_known")]
            NotKnown,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }
        public enum PoweredByEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "ideal")]
            Ideal,
            [EnumMember(Value = "sofort")]
            Sofort,
            [EnumMember(Value = "bancontact")]
            Bancontact,
            [EnumMember(Value = "giropay")]
            Giropay,
            [EnumMember(Value = "card")]
            Card,
            [EnumMember(Value = "latam_local_card")]
            LatamLocalCard,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }

        #region Subclasses

        #endregion
    }
}
