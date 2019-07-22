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

    public class PaymentSource : Resource 
    {
    

        #region Methods
        public static CreateUsingTempTokenRequest CreateUsingTempToken()
        {
            string url = ApiUtil.BuildUrl("payment_sources", "create_using_temp_token");
            return new CreateUsingTempTokenRequest(url, HttpMethod.POST);
        }
        public static CreateUsingPermanentTokenRequest CreateUsingPermanentToken()
        {
            string url = ApiUtil.BuildUrl("payment_sources", "create_using_permanent_token");
            return new CreateUsingPermanentTokenRequest(url, HttpMethod.POST);
        }
        public static CreateUsingTokenRequest CreateUsingToken()
        {
            string url = ApiUtil.BuildUrl("payment_sources", "create_using_token");
            return new CreateUsingTokenRequest(url, HttpMethod.POST);
        }
        public static CreateUsingPaymentIntentRequest CreateUsingPaymentIntent()
        {
            string url = ApiUtil.BuildUrl("payment_sources", "create_using_payment_intent");
            return new CreateUsingPaymentIntentRequest(url, HttpMethod.POST);
        }
        public static CreateCardRequest CreateCard()
        {
            string url = ApiUtil.BuildUrl("payment_sources", "create_card");
            return new CreateCardRequest(url, HttpMethod.POST);
        }
        public static CreateBankAccountRequest CreateBankAccount()
        {
            string url = ApiUtil.BuildUrl("payment_sources", "create_bank_account");
            return new CreateBankAccountRequest(url, HttpMethod.POST);
        }
        public static UpdateCardRequest UpdateCard(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id), "update_card");
            return new UpdateCardRequest(url, HttpMethod.POST);
        }
        public static VerifyBankAccountRequest VerifyBankAccount(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id), "verify_bank_account");
            return new VerifyBankAccountRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static PaymentSourceListRequest List()
        {
            string url = ApiUtil.BuildUrl("payment_sources");
            return new PaymentSourceListRequest(url);
        }
        public static SwitchGatewayAccountRequest SwitchGatewayAccount(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id), "switch_gateway_account");
            return new SwitchGatewayAccountRequest(url, HttpMethod.POST);
        }
        public static ExportPaymentSourceRequest ExportPaymentSource(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id), "export_payment_source");
            return new ExportPaymentSourceRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> DeleteLocal(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id), "delete_local");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
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
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public TypeEnum PaymentSourceType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public string ReferenceId 
        {
            get { return GetValue<string>("reference_id", true); }
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
        public string IpAddress 
        {
            get { return GetValue<string>("ip_address", false); }
        }
        public string IssuingCountry 
        {
            get { return GetValue<string>("issuing_country", false); }
        }
        public PaymentSourceCard Card 
        {
            get { return GetSubResource<PaymentSourceCard>("card"); }
        }
        public PaymentSourceBankAccount BankAccount 
        {
            get { return GetSubResource<PaymentSourceBankAccount>("bank_account"); }
        }
        public PaymentSourceAmazonPayment AmazonPayment 
        {
            get { return GetSubResource<PaymentSourceAmazonPayment>("amazon_payment"); }
        }
        public PaymentSourcePaypal Paypal 
        {
            get { return GetSubResource<PaymentSourcePaypal>("paypal"); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateUsingTempTokenRequest : EntityRequest<CreateUsingTempTokenRequest> 
        {
            public CreateUsingTempTokenRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateUsingTempTokenRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateUsingTempTokenRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.AddOpt("gateway_account_id", gatewayAccountId);
                return this;
            }
            public CreateUsingTempTokenRequest Type(ChargeBee.Models.Enums.TypeEnum type) 
            {
                m_params.Add("type", type);
                return this;
            }
            public CreateUsingTempTokenRequest TmpToken(string tmpToken) 
            {
                m_params.Add("tmp_token", tmpToken);
                return this;
            }
            public CreateUsingTempTokenRequest IssuingCountry(string issuingCountry) 
            {
                m_params.AddOpt("issuing_country", issuingCountry);
                return this;
            }
            public CreateUsingTempTokenRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
        }
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
            public CreateUsingPermanentTokenRequest Type(ChargeBee.Models.Enums.TypeEnum type) 
            {
                m_params.Add("type", type);
                return this;
            }
            public CreateUsingPermanentTokenRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.AddOpt("gateway_account_id", gatewayAccountId);
                return this;
            }
            public CreateUsingPermanentTokenRequest ReferenceId(string referenceId) 
            {
                m_params.Add("reference_id", referenceId);
                return this;
            }
            public CreateUsingPermanentTokenRequest IssuingCountry(string issuingCountry) 
            {
                m_params.AddOpt("issuing_country", issuingCountry);
                return this;
            }
            public CreateUsingPermanentTokenRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
        }
        public class CreateUsingTokenRequest : EntityRequest<CreateUsingTokenRequest> 
        {
            public CreateUsingTokenRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateUsingTokenRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateUsingTokenRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateUsingTokenRequest TokenId(string tokenId) 
            {
                m_params.Add("token_id", tokenId);
                return this;
            }
        }
        public class CreateUsingPaymentIntentRequest : EntityRequest<CreateUsingPaymentIntentRequest> 
        {
            public CreateUsingPaymentIntentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateUsingPaymentIntentRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateUsingPaymentIntentRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.Add("gateway_account_id", gatewayAccountId);
                return this;
            }
            public CreateUsingPaymentIntentRequest GwToken(string gwToken) 
            {
                m_params.Add("gw_token", gwToken);
                return this;
            }
            public CreateUsingPaymentIntentRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
        }
        public class CreateCardRequest : EntityRequest<CreateCardRequest> 
        {
            public CreateCardRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateCardRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateCardRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateCardRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            public CreateCardRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public CreateCardRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public CreateCardRequest CardNumber(string cardNumber) 
            {
                m_params.Add("card[number]", cardNumber);
                return this;
            }
            public CreateCardRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.Add("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public CreateCardRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.Add("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public CreateCardRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public CreateCardRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public CreateCardRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public CreateCardRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public CreateCardRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public CreateCardRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public CreateCardRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public CreateCardRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
        }
        public class CreateBankAccountRequest : EntityRequest<CreateBankAccountRequest> 
        {
            public CreateBankAccountRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateBankAccountRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateBankAccountRequest IssuingCountry(string issuingCountry) 
            {
                m_params.AddOpt("issuing_country", issuingCountry);
                return this;
            }
            public CreateBankAccountRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateBankAccountRequest BankAccountGatewayAccountId(string bankAccountGatewayAccountId) 
            {
                m_params.AddOpt("bank_account[gateway_account_id]", bankAccountGatewayAccountId);
                return this;
            }
            public CreateBankAccountRequest BankAccountIban(string bankAccountIban) 
            {
                m_params.AddOpt("bank_account[iban]", bankAccountIban);
                return this;
            }
            public CreateBankAccountRequest BankAccountFirstName(string bankAccountFirstName) 
            {
                m_params.AddOpt("bank_account[first_name]", bankAccountFirstName);
                return this;
            }
            public CreateBankAccountRequest BankAccountLastName(string bankAccountLastName) 
            {
                m_params.AddOpt("bank_account[last_name]", bankAccountLastName);
                return this;
            }
            public CreateBankAccountRequest BankAccountCompany(string bankAccountCompany) 
            {
                m_params.AddOpt("bank_account[company]", bankAccountCompany);
                return this;
            }
            public CreateBankAccountRequest BankAccountEmail(string bankAccountEmail) 
            {
                m_params.AddOpt("bank_account[email]", bankAccountEmail);
                return this;
            }
            public CreateBankAccountRequest BankAccountBankName(string bankAccountBankName) 
            {
                m_params.AddOpt("bank_account[bank_name]", bankAccountBankName);
                return this;
            }
            public CreateBankAccountRequest BankAccountAccountNumber(string bankAccountAccountNumber) 
            {
                m_params.AddOpt("bank_account[account_number]", bankAccountAccountNumber);
                return this;
            }
            public CreateBankAccountRequest BankAccountRoutingNumber(string bankAccountRoutingNumber) 
            {
                m_params.AddOpt("bank_account[routing_number]", bankAccountRoutingNumber);
                return this;
            }
            public CreateBankAccountRequest BankAccountBankCode(string bankAccountBankCode) 
            {
                m_params.AddOpt("bank_account[bank_code]", bankAccountBankCode);
                return this;
            }
            public CreateBankAccountRequest BankAccountAccountType(ChargeBee.Models.Enums.AccountTypeEnum bankAccountAccountType) 
            {
                m_params.AddOpt("bank_account[account_type]", bankAccountAccountType);
                return this;
            }
            public CreateBankAccountRequest BankAccountAccountHolderType(ChargeBee.Models.Enums.AccountHolderTypeEnum bankAccountAccountHolderType) 
            {
                m_params.AddOpt("bank_account[account_holder_type]", bankAccountAccountHolderType);
                return this;
            }
            public CreateBankAccountRequest BankAccountEcheckType(ChargeBee.Models.Enums.EcheckTypeEnum bankAccountEcheckType) 
            {
                m_params.AddOpt("bank_account[echeck_type]", bankAccountEcheckType);
                return this;
            }
            public CreateBankAccountRequest BankAccountSwedishIdentityNumber(string bankAccountSwedishIdentityNumber) 
            {
                m_params.AddOpt("bank_account[swedish_identity_number]", bankAccountSwedishIdentityNumber);
                return this;
            }
        }
        public class UpdateCardRequest : EntityRequest<UpdateCardRequest> 
        {
            public UpdateCardRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateCardRequest GatewayMetaData(JToken gatewayMetaData) 
            {
                m_params.AddOpt("gateway_meta_data", gatewayMetaData);
                return this;
            }
            public UpdateCardRequest ReferenceTransaction(string referenceTransaction) 
            {
                m_params.AddOpt("reference_transaction", referenceTransaction);
                return this;
            }
            public UpdateCardRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public UpdateCardRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public UpdateCardRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public UpdateCardRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public UpdateCardRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public UpdateCardRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public UpdateCardRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public UpdateCardRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public UpdateCardRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public UpdateCardRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public UpdateCardRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
        }
        public class VerifyBankAccountRequest : EntityRequest<VerifyBankAccountRequest> 
        {
            public VerifyBankAccountRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public VerifyBankAccountRequest Amount1(int amount1) 
            {
                m_params.Add("amount1", amount1);
                return this;
            }
            public VerifyBankAccountRequest Amount2(int amount2) 
            {
                m_params.Add("amount2", amount2);
                return this;
            }
        }
        public class PaymentSourceListRequest : ListRequestBase<PaymentSourceListRequest> 
        {
            public PaymentSourceListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<PaymentSourceListRequest> CustomerId() 
            {
                return new StringFilter<PaymentSourceListRequest>("customer_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.TypeEnum, PaymentSourceListRequest> Type() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.TypeEnum, PaymentSourceListRequest>("type", this);        
            }
            public EnumFilter<PaymentSource.StatusEnum, PaymentSourceListRequest> Status() 
            {
                return new EnumFilter<PaymentSource.StatusEnum, PaymentSourceListRequest>("status", this);        
            }
            public TimestampFilter<PaymentSourceListRequest> UpdatedAt() 
            {
                return new TimestampFilter<PaymentSourceListRequest>("updated_at", this);        
            }
            public TimestampFilter<PaymentSourceListRequest> CreatedAt() 
            {
                return new TimestampFilter<PaymentSourceListRequest>("created_at", this);        
            }
        }
        public class SwitchGatewayAccountRequest : EntityRequest<SwitchGatewayAccountRequest> 
        {
            public SwitchGatewayAccountRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public SwitchGatewayAccountRequest GatewayAccountId(string gatewayAccountId) 
            {
                m_params.Add("gateway_account_id", gatewayAccountId);
                return this;
            }
        }
        public class ExportPaymentSourceRequest : EntityRequest<ExportPaymentSourceRequest> 
        {
            public ExportPaymentSourceRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ExportPaymentSourceRequest GatewayAccountId(string gatewayAccountId) 
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
            [EnumMember(Value = "invalid")]
            Invalid,
            [EnumMember(Value = "pending_verification")]
            PendingVerification,

        }

        #region Subclasses
        public class PaymentSourceCard : Resource
        {
            public enum BrandEnum
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
                [EnumMember(Value = "other")]
                Other,
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

            public string FirstName() {
                return GetValue<string>("first_name", false);
            }

            public string LastName() {
                return GetValue<string>("last_name", false);
            }

            public string Iin() {
                return GetValue<string>("iin", true);
            }

            public string Last4() {
                return GetValue<string>("last4", true);
            }

            public BrandEnum Brand() {
                return GetEnum<BrandEnum>("brand", true);
            }

            public FundingTypeEnum FundingType() {
                return GetEnum<FundingTypeEnum>("funding_type", true);
            }

            public int ExpiryMonth() {
                return GetValue<int>("expiry_month", true);
            }

            public int ExpiryYear() {
                return GetValue<int>("expiry_year", true);
            }

            public string BillingAddr1() {
                return GetValue<string>("billing_addr1", false);
            }

            public string BillingAddr2() {
                return GetValue<string>("billing_addr2", false);
            }

            public string BillingCity() {
                return GetValue<string>("billing_city", false);
            }

            public string BillingStateCode() {
                return GetValue<string>("billing_state_code", false);
            }

            public string BillingState() {
                return GetValue<string>("billing_state", false);
            }

            public string BillingCountry() {
                return GetValue<string>("billing_country", false);
            }

            public string BillingZip() {
                return GetValue<string>("billing_zip", false);
            }

            public string MaskedNumber() {
                return GetValue<string>("masked_number", false);
            }

        }
        public class PaymentSourceBankAccount : Resource
        {
            public enum AccountTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "checking")]
                Checking,
                [EnumMember(Value = "savings")]
                Savings,
            }
            public enum EcheckTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "web")]
                Web,
                [EnumMember(Value = "ppd")]
                Ppd,
            }
            public enum AccountHolderTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "individual")]
                Individual,
                [EnumMember(Value = "company")]
                Company,
            }

            public string Last4() {
                return GetValue<string>("last4", true);
            }

            public string NameOnAccount() {
                return GetValue<string>("name_on_account", false);
            }

            public string BankName() {
                return GetValue<string>("bank_name", false);
            }

            public string MandateId() {
                return GetValue<string>("mandate_id", false);
            }

            public AccountTypeEnum? AccountType() {
                return GetEnum<AccountTypeEnum>("account_type", false);
            }

            public EcheckTypeEnum? EcheckType() {
                return GetEnum<EcheckTypeEnum>("echeck_type", false);
            }

            public AccountHolderTypeEnum? AccountHolderType() {
                return GetEnum<AccountHolderTypeEnum>("account_holder_type", false);
            }

        }
        public class PaymentSourceAmazonPayment : Resource
        {

            public string Email() {
                return GetValue<string>("email", false);
            }

            public string AgreementId() {
                return GetValue<string>("agreement_id", false);
            }

        }
        public class PaymentSourcePaypal : Resource
        {

            public string Email() {
                return GetValue<string>("email", false);
            }

            public string AgreementId() {
                return GetValue<string>("agreement_id", false);
            }

        }

        #endregion
    }
}
