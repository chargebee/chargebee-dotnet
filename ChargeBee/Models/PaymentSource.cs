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
    
        public PaymentSource() { }

        public PaymentSource(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PaymentSource(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PaymentSource(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

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
        public static CreateVoucherPaymentSourceRequest CreateVoucherPaymentSource()
        {
            string url = ApiUtil.BuildUrl("payment_sources", "create_voucher_payment_source");
            return new CreateVoucherPaymentSourceRequest(url, HttpMethod.POST);
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
        public static UpdateBankAccountRequest UpdateBankAccount(string id)
        {
            string url = ApiUtil.BuildUrl("payment_sources", CheckNull(id), "update_bank_account");
            return new UpdateBankAccountRequest(url, HttpMethod.POST);
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
        public PaymentSourceCustVoucherSource Boleto 
        {
            get { return GetSubResource<PaymentSourceCustVoucherSource>("boleto"); }
        }
        public PaymentSourceBillingAddress BillingAddress 
        {
            get { return GetSubResource<PaymentSourceBillingAddress>("billing_address"); }
        }
        public PaymentSourceAmazonPayment AmazonPayment 
        {
            get { return GetSubResource<PaymentSourceAmazonPayment>("amazon_payment"); }
        }
        public PaymentSourceUpi Upi 
        {
            get { return GetSubResource<PaymentSourceUpi>("upi"); }
        }
        public PaymentSourcePaypal Paypal 
        {
            get { return GetSubResource<PaymentSourcePaypal>("paypal"); }
        }
        public PaymentSourceVenmo Venmo 
        {
            get { return GetSubResource<PaymentSourceVenmo>("venmo"); }
        }
        public PaymentSourceKlarnaPayNow KlarnaPayNow 
        {
            get { return GetSubResource<PaymentSourceKlarnaPayNow>("klarna_pay_now"); }
        }
        public List<PaymentSourceMandate> Mandates 
        {
            get { return GetResourceList<PaymentSourceMandate>("mandates"); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
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
            public CreateUsingTempTokenRequest AdditionalInformation(JToken additionalInformation) 
            {
                m_params.AddOpt("additional_information", additionalInformation);
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
                m_params.AddOpt("reference_id", referenceId);
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
            public CreateUsingPermanentTokenRequest PaymentMethodToken(string paymentMethodToken) 
            {
                m_params.AddOpt("payment_method_token", paymentMethodToken);
                return this;
            }
            public CreateUsingPermanentTokenRequest CustomerProfileToken(string customerProfileToken) 
            {
                m_params.AddOpt("customer_profile_token", customerProfileToken);
                return this;
            }
            public CreateUsingPermanentTokenRequest NetworkTransactionId(string networkTransactionId) 
            {
                m_params.AddOpt("network_transaction_id", networkTransactionId);
                return this;
            }
            public CreateUsingPermanentTokenRequest MandateId(string mandateId) 
            {
                m_params.AddOpt("mandate_id", mandateId);
                return this;
            }
            public CreateUsingPermanentTokenRequest SkipRetrieval(bool skipRetrieval) 
            {
                m_params.AddOpt("skip_retrieval", skipRetrieval);
                return this;
            }
            public CreateUsingPermanentTokenRequest AdditionalInformation(JToken additionalInformation) 
            {
                m_params.AddOpt("additional_information", additionalInformation);
                return this;
            }
            public CreateUsingPermanentTokenRequest CardLast4(string cardLast4) 
            {
                m_params.AddOpt("card[last4]", cardLast4);
                return this;
            }
            public CreateUsingPermanentTokenRequest CardIin(string cardIin) 
            {
                m_params.AddOpt("card[iin]", cardIin);
                return this;
            }
            public CreateUsingPermanentTokenRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public CreateUsingPermanentTokenRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public CreateUsingPermanentTokenRequest CardBrand(PaymentSourceCard.BrandEnum cardBrand) 
            {
                m_params.AddOpt("card[brand]", cardBrand);
                return this;
            }
            public CreateUsingPermanentTokenRequest CardFundingType(PaymentSourceCard.FundingTypeEnum cardFundingType) 
            {
                m_params.AddOpt("card[funding_type]", cardFundingType);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateUsingPermanentTokenRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
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
            public CreateUsingPaymentIntentRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateUsingPaymentIntentRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public CreateUsingPaymentIntentRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateUsingPaymentIntentRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CreateUsingPaymentIntentRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public CreateUsingPaymentIntentRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateUsingPaymentIntentRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateUsingPaymentIntentRequest PaymentIntentAdditionalInfo(JToken paymentIntentAdditionalInfo) 
            {
                m_params.AddOpt("payment_intent[additional_info]", paymentIntentAdditionalInfo);
                return this;
            }
            public CreateUsingPaymentIntentRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
        }
        public class CreateVoucherPaymentSourceRequest : EntityRequest<CreateVoucherPaymentSourceRequest> 
        {
            public CreateVoucherPaymentSourceRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateVoucherPaymentSourceRequest CustomerId(string customerId) 
            {
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateVoucherPaymentSourceRequest VoucherPaymentSourceVoucherType(ChargeBee.Models.Enums.VoucherTypeEnum voucherPaymentSourceVoucherType) 
            {
                m_params.Add("voucher_payment_source[voucher_type]", voucherPaymentSourceVoucherType);
                return this;
            }
            public CreateVoucherPaymentSourceRequest VoucherPaymentSourceGatewayAccountId(string voucherPaymentSourceGatewayAccountId) 
            {
                m_params.AddOpt("voucher_payment_source[gateway_account_id]", voucherPaymentSourceGatewayAccountId);
                return this;
            }
            public CreateVoucherPaymentSourceRequest VoucherPaymentSourceTaxId(string voucherPaymentSourceTaxId) 
            {
                m_params.AddOpt("voucher_payment_source[tax_id]", voucherPaymentSourceTaxId);
                return this;
            }
            public CreateVoucherPaymentSourceRequest VoucherPaymentSourceBillingAddress(JToken voucherPaymentSourceBillingAddress) 
            {
                m_params.AddOpt("voucher_payment_source[billing_address]", voucherPaymentSourceBillingAddress);
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
            public CreateCardRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
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
            public CreateBankAccountRequest BankAccountPhone(string bankAccountPhone) 
            {
                m_params.AddOpt("bank_account[phone]", bankAccountPhone);
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
            public CreateBankAccountRequest BankAccountBillingAddress(JToken bankAccountBillingAddress) 
            {
                m_params.AddOpt("bank_account[billing_address]", bankAccountBillingAddress);
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
            public UpdateCardRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
                return this;
            }
        }
        public class UpdateBankAccountRequest : EntityRequest<UpdateBankAccountRequest> 
        {
            public UpdateBankAccountRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateBankAccountRequest BankAccountFirstName(string bankAccountFirstName) 
            {
                m_params.AddOpt("bank_account[first_name]", bankAccountFirstName);
                return this;
            }
            public UpdateBankAccountRequest BankAccountLastName(string bankAccountLastName) 
            {
                m_params.AddOpt("bank_account[last_name]", bankAccountLastName);
                return this;
            }
            public UpdateBankAccountRequest BankAccountEmail(string bankAccountEmail) 
            {
                m_params.AddOpt("bank_account[email]", bankAccountEmail);
                return this;
            }
        }
        public class VerifyBankAccountRequest : EntityRequest<VerifyBankAccountRequest> 
        {
            public VerifyBankAccountRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public VerifyBankAccountRequest Amount1(long amount1) 
            {
                m_params.Add("amount1", amount1);
                return this;
            }
            public VerifyBankAccountRequest Amount2(long amount2) 
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

            public PaymentSourceListRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
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
            
            public PaymentSourceListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
            public PaymentSourceListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
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

            public string FirstName {
                get { return GetValue<string>("first_name", false); }
            }

            public string LastName {
                get { return GetValue<string>("last_name", false); }
            }

            public string Iin {
                get { return GetValue<string>("iin", true); }
            }

            public string Last4 {
                get { return GetValue<string>("last4", true); }
            }

            public BrandEnum Brand {
                get { return GetEnum<BrandEnum>("brand", true); }
            }

            public FundingTypeEnum FundingType {
                get { return GetEnum<FundingTypeEnum>("funding_type", true); }
            }

            public int ExpiryMonth {
                get { return GetValue<int>("expiry_month", true); }
            }

            public int ExpiryYear {
                get { return GetValue<int>("expiry_year", true); }
            }

            public string BillingAddr1 {
                get { return GetValue<string>("billing_addr1", false); }
            }

            public string BillingAddr2 {
                get { return GetValue<string>("billing_addr2", false); }
            }

            public string BillingCity {
                get { return GetValue<string>("billing_city", false); }
            }

            public string BillingStateCode {
                get { return GetValue<string>("billing_state_code", false); }
            }

            public string BillingState {
                get { return GetValue<string>("billing_state", false); }
            }

            public string BillingCountry {
                get { return GetValue<string>("billing_country", false); }
            }

            public string BillingZip {
                get { return GetValue<string>("billing_zip", false); }
            }

            public string MaskedNumber {
                get { return GetValue<string>("masked_number", false); }
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
                [EnumMember(Value = "business_checking")]
                BusinessChecking,
                [EnumMember(Value = "current")]
                Current,
            }
            public enum EcheckTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "web")]
                Web,
                [EnumMember(Value = "ppd")]
                Ppd,
                [EnumMember(Value = "ccd")]
                Ccd,
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

            public string Last4 {
                get { return GetValue<string>("last4", true); }
            }

            public string NameOnAccount {
                get { return GetValue<string>("name_on_account", false); }
            }

            public string FirstName {
                get { return GetValue<string>("first_name", false); }
            }

            public string LastName {
                get { return GetValue<string>("last_name", false); }
            }

            public DirectDebitSchemeEnum? DirectDebitScheme {
                get { return GetEnum<DirectDebitSchemeEnum>("direct_debit_scheme", false); }
            }

            public string BankName {
                get { return GetValue<string>("bank_name", false); }
            }

            public string MandateId {
                get { return GetValue<string>("mandate_id", false); }
            }

            public AccountTypeEnum? AccountType {
                get { return GetEnum<AccountTypeEnum>("account_type", false); }
            }

            public EcheckTypeEnum? EcheckType {
                get { return GetEnum<EcheckTypeEnum>("echeck_type", false); }
            }

            public AccountHolderTypeEnum? AccountHolderType {
                get { return GetEnum<AccountHolderTypeEnum>("account_holder_type", false); }
            }

            public string Email {
                get { return GetValue<string>("email", false); }
            }

        }
        public class PaymentSourceCustVoucherSource : Resource
        {

            public string Last4 {
                get { return GetValue<string>("last4", true); }
            }

            public string FirstName {
                get { return GetValue<string>("first_name", false); }
            }

            public string LastName {
                get { return GetValue<string>("last_name", false); }
            }

            public string Email {
                get { return GetValue<string>("email", false); }
            }

        }
        public class PaymentSourceBillingAddress : Resource
        {

            public string FirstName {
                get { return GetValue<string>("first_name", false); }
            }

            public string LastName {
                get { return GetValue<string>("last_name", false); }
            }

            public string Email {
                get { return GetValue<string>("email", false); }
            }

            public string Company {
                get { return GetValue<string>("company", false); }
            }

            public string Phone {
                get { return GetValue<string>("phone", false); }
            }

            public string Line1 {
                get { return GetValue<string>("line1", false); }
            }

            public string Line2 {
                get { return GetValue<string>("line2", false); }
            }

            public string Line3 {
                get { return GetValue<string>("line3", false); }
            }

            public string City {
                get { return GetValue<string>("city", false); }
            }

            public string StateCode {
                get { return GetValue<string>("state_code", false); }
            }

            public string State {
                get { return GetValue<string>("state", false); }
            }

            public string Country {
                get { return GetValue<string>("country", false); }
            }

            public string Zip {
                get { return GetValue<string>("zip", false); }
            }

            public ValidationStatusEnum? ValidationStatus {
                get { return GetEnum<ValidationStatusEnum>("validation_status", false); }
            }

        }
        public class PaymentSourceAmazonPayment : Resource
        {

            public string Email {
                get { return GetValue<string>("email", false); }
            }

            public string AgreementId {
                get { return GetValue<string>("agreement_id", false); }
            }

        }
        public class PaymentSourceUpi : Resource
        {

            public string Vpa {
                get { return GetValue<string>("vpa", false); }
            }

        }
        public class PaymentSourcePaypal : Resource
        {

            public string Email {
                get { return GetValue<string>("email", false); }
            }

            public string AgreementId {
                get { return GetValue<string>("agreement_id", false); }
            }

        }
        public class PaymentSourceVenmo : Resource
        {

            public string UserName {
                get { return GetValue<string>("user_name", false); }
            }

        }
        public class PaymentSourceKlarnaPayNow : Resource
        {

            public string Email {
                get { return GetValue<string>("email", false); }
            }

        }
        public class PaymentSourceMandate : Resource
        {

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string SubscriptionId {
                get { return GetValue<string>("subscription_id", true); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

        }

        #endregion
    }
}
