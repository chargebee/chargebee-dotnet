using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;

namespace ChargeBee.Models
{

    public class Card : Resource 
    {
    

        #region Methods
        public static EntityRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("cards", CheckNull(id));
            return new EntityRequest(url, HttpMethod.GET);
        }
        public static UpdateCardForCustomerRequest UpdateCardForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "credit_card");
            return new UpdateCardForCustomerRequest(url, HttpMethod.POST);
        }
        public static EntityRequest DeleteCardForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "delete_card");
            return new EntityRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
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
        public int ExpiryMonth 
        {
            get { return GetValue<int>("expiry_month", true); }
        }
        public int ExpiryYear 
        {
            get { return GetValue<int>("expiry_year", true); }
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
        public string MaskedNumber 
        {
            get { return GetValue<string>("masked_number", false); }
        }

        #endregion
        
        #region Requests
        public class UpdateCardForCustomerRequest : EntityRequest 
        {
            public UpdateCardForCustomerRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateCardForCustomerRequest Gateway(GatewayEnum gateway) 
            {
                m_params.AddOpt("gateway", gateway);
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
            public UpdateCardForCustomerRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("valid")]
            Valid,
            [Description("expiring")]
            Expiring,
            [Description("expired")]
            Expired,

        }
        public enum CardTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("visa")]
            Visa,
            [Description("mastercard")]
            Mastercard,
            [Description("american_express")]
            AmericanExpress,
            [Description("discover")]
            Discover,
            [Description("jcb")]
            Jcb,
            [Description("diners_club")]
            DinersClub,
            [Description("other")]
            Other,
            [Description("not_applicable")]
            NotApplicable,

        }

        #region Subclasses

        #endregion
    }
}
