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

    public class VirtualBankAccount : Resource 
    {
    
        public VirtualBankAccount() { }

        public VirtualBankAccount(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public VirtualBankAccount(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public VirtualBankAccount(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateUsingPermanentTokenRequest CreateUsingPermanentToken()
        {
            string url = ApiUtil.BuildUrl("virtual_bank_accounts", "create_using_permanent_token");
            return new CreateUsingPermanentTokenRequest(url, HttpMethod.POST);
        }
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("virtual_bank_accounts");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("virtual_bank_accounts", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static VirtualBankAccountListRequest List()
        {
            string url = ApiUtil.BuildUrl("virtual_bank_accounts");
            return new VirtualBankAccountListRequest(url);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("virtual_bank_accounts", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> DeleteLocal(string id)
        {
            string url = ApiUtil.BuildUrl("virtual_bank_accounts", CheckNull(id), "delete_local");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string Email 
        {
            get { return GetValue<string>("email", true); }
        }
        public SchemeEnum? Scheme 
        {
            get { return GetEnum<SchemeEnum>("scheme", false); }
        }
        public string BankName 
        {
            get { return GetValue<string>("bank_name", false); }
        }
        public string AccountNumber 
        {
            get { return GetValue<string>("account_number", true); }
        }
        public string RoutingNumber 
        {
            get { return GetValue<string>("routing_number", false); }
        }
        public string SwiftCode 
        {
            get { return GetValue<string>("swift_code", false); }
        }
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public string ReferenceId 
        {
            get { return GetValue<string>("reference_id", true); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateUsingPermanentTokenRequest : EntityRequest<CreateUsingPermanentTokenRequest> 
        {
            public CreateUsingPermanentTokenRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateUsingPermanentTokenRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateUsingPermanentTokenRequest ReferenceId(string referenceId) 
            {
                m_params.Add("reference_id", referenceId);
                return this;
            }
            public CreateUsingPermanentTokenRequest Scheme(VirtualBankAccount.SchemeEnum scheme) 
            {
                m_params.AddOpt("scheme", scheme);
                return this;
            }
        }
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateRequest Email(string email) 
            {
                m_params.AddOpt("email", email);
                return this;
            }
            public CreateRequest Scheme(VirtualBankAccount.SchemeEnum scheme) 
            {
                m_params.AddOpt("scheme", scheme);
                return this;
            }
        }
        public class VirtualBankAccountListRequest : ListRequestBase<VirtualBankAccountListRequest> 
        {
            public VirtualBankAccountListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<VirtualBankAccountListRequest> CustomerId() 
            {
                return new StringFilter<VirtualBankAccountListRequest>("customer_id", this).SupportsMultiOperators(true);        
            }
            public TimestampFilter<VirtualBankAccountListRequest> UpdatedAt() 
            {
                return new TimestampFilter<VirtualBankAccountListRequest>("updated_at", this);        
            }
            public TimestampFilter<VirtualBankAccountListRequest> CreatedAt() 
            {
                return new TimestampFilter<VirtualBankAccountListRequest>("created_at", this);        
            }
        }
        #endregion

        public enum SchemeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "ach_credit")]
            AchCredit,
            [EnumMember(Value = "sepa_credit")]
            SepaCredit,
            [EnumMember(Value = "us_automated_bank_transfer")]
            UsAutomatedBankTransfer,
            [EnumMember(Value = "gb_automated_bank_transfer")]
            GbAutomatedBankTransfer,
            [EnumMember(Value = "eu_automated_bank_transfer")]
            EuAutomatedBankTransfer,
            [EnumMember(Value = "jp_automated_bank_transfer")]
            JpAutomatedBankTransfer,
            [EnumMember(Value = "mx_automated_bank_transfer")]
            MxAutomatedBankTransfer,

        }

        #region Subclasses

        #endregion
    }
}
