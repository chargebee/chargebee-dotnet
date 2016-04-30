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

    public class Customer : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("customers");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("customers");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static UpdatePaymentMethodRequest UpdatePaymentMethod(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "update_payment_method");
            return new UpdatePaymentMethodRequest(url, HttpMethod.POST);
        }
        public static UpdateBillingInfoRequest UpdateBillingInfo(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "update_billing_info");
            return new UpdateBillingInfoRequest(url, HttpMethod.POST);
        }
        public static AddContactRequest AddContact(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "add_contact");
            return new AddContactRequest(url, HttpMethod.POST);
        }
        public static UpdateContactRequest UpdateContact(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "update_contact");
            return new UpdateContactRequest(url, HttpMethod.POST);
        }
        public static DeleteContactRequest DeleteContact(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "delete_contact");
            return new DeleteContactRequest(url, HttpMethod.POST);
        }
        public static AddPromotionalCreditsRequest AddPromotionalCredits(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "add_promotional_credits");
            return new AddPromotionalCreditsRequest(url, HttpMethod.POST);
        }
        public static DeductPromotionalCreditsRequest DeductPromotionalCredits(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "deduct_promotional_credits");
            return new DeductPromotionalCreditsRequest(url, HttpMethod.POST);
        }
        public static SetPromotionalCreditsRequest SetPromotionalCredits(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "set_promotional_credits");
            return new SetPromotionalCreditsRequest(url, HttpMethod.POST);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string FirstName 
        {
            get { return GetValue<string>("first_name", false); }
        }
        public string LastName 
        {
            get { return GetValue<string>("last_name", false); }
        }
        public string Email 
        {
            get { return GetValue<string>("email", false); }
        }
        public string Phone 
        {
            get { return GetValue<string>("phone", false); }
        }
        public string Company 
        {
            get { return GetValue<string>("company", false); }
        }
        public string VatNumber 
        {
            get { return GetValue<string>("vat_number", false); }
        }
        public AutoCollectionEnum AutoCollection 
        {
            get { return GetEnum<AutoCollectionEnum>("auto_collection", true); }
        }
        public bool AllowDirectDebit 
        {
            get { return GetValue<bool>("allow_direct_debit", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public string CreatedFromIp 
        {
            get { return GetValue<string>("created_from_ip", false); }
        }
        public TaxabilityEnum? Taxability 
        {
            get { return GetEnum<TaxabilityEnum>("taxability", false); }
        }
        public EntityCodeEnum? EntityCode 
        {
            get { return GetEnum<EntityCodeEnum>("entity_code", false); }
        }
        public string ExemptNumber 
        {
            get { return GetValue<string>("exempt_number", false); }
        }
        [Obsolete]
        public CardStatusEnum? CardStatus 
        {
            get { return GetEnum<CardStatusEnum>("card_status", false); }
        }
        public CustomerBillingAddress BillingAddress 
        {
            get { return GetSubResource<CustomerBillingAddress>("billing_address"); }
        }
        public List<CustomerContact> Contacts 
        {
            get { return GetResourceList<CustomerContact>("contacts"); }
        }
        public CustomerPaymentMethod PaymentMethod 
        {
            get { return GetSubResource<CustomerPaymentMethod>("payment_method"); }
        }
        public string InvoiceNotes 
        {
            get { return GetValue<string>("invoice_notes", false); }
        }
        public int PromotionalCredits 
        {
            get { return GetValue<int>("promotional_credits", true); }
        }
        public int RefundableCredits 
        {
            get { return GetValue<int>("refundable_credits", true); }
        }
        public int ExcessPayments 
        {
            get { return GetValue<int>("excess_payments", true); }
        }
        public JToken MetaData 
        {
            get { return GetJToken("meta_data", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CreateRequest FirstName(string firstName) 
            {
                m_params.AddOpt("first_name", firstName);
                return this;
            }
            public CreateRequest LastName(string lastName) 
            {
                m_params.AddOpt("last_name", lastName);
                return this;
            }
            public CreateRequest Email(string email) 
            {
                m_params.AddOpt("email", email);
                return this;
            }
            public CreateRequest Phone(string phone) 
            {
                m_params.AddOpt("phone", phone);
                return this;
            }
            public CreateRequest Company(string company) 
            {
                m_params.AddOpt("company", company);
                return this;
            }
            public CreateRequest AutoCollection(AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateRequest AllowDirectDebit(bool allowDirectDebit) 
            {
                m_params.AddOpt("allow_direct_debit", allowDirectDebit);
                return this;
            }
            public CreateRequest VatNumber(string vatNumber) 
            {
                m_params.AddOpt("vat_number", vatNumber);
                return this;
            }
            public CreateRequest Taxability(TaxabilityEnum taxability) 
            {
                m_params.AddOpt("taxability", taxability);
                return this;
            }
            public CreateRequest EntityCode(EntityCodeEnum entityCode) 
            {
                m_params.AddOpt("entity_code", entityCode);
                return this;
            }
            public CreateRequest ExemptNumber(string exemptNumber) 
            {
                m_params.AddOpt("exempt_number", exemptNumber);
                return this;
            }
            public CreateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public CreateRequest CreatedFromIp(string createdFromIp) 
            {
                m_params.AddOpt("created_from_ip", createdFromIp);
                return this;
            }
            public CreateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateRequest CardGateway(GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CreateRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public CreateRequest PaymentMethodType(TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            public CreateRequest PaymentMethodGateway(GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public CreateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public CreateRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public CreateRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public CreateRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public CreateRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public CreateRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public CreateRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public CreateRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public CreateRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public CreateRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public CreateRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public CreateRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public CreateRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public CreateRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            public CreateRequest CardIpAddress(string cardIpAddress) 
            {
                m_params.AddOpt("card[ip_address]", cardIpAddress);
                return this;
            }
            public CreateRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public CreateRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public CreateRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public CreateRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public CreateRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public CreateRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public CreateRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public CreateRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public CreateRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public CreateRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public CreateRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest FirstName(string firstName) 
            {
                m_params.AddOpt("first_name", firstName);
                return this;
            }
            public UpdateRequest LastName(string lastName) 
            {
                m_params.AddOpt("last_name", lastName);
                return this;
            }
            public UpdateRequest Email(string email) 
            {
                m_params.AddOpt("email", email);
                return this;
            }
            public UpdateRequest Phone(string phone) 
            {
                m_params.AddOpt("phone", phone);
                return this;
            }
            public UpdateRequest Company(string company) 
            {
                m_params.AddOpt("company", company);
                return this;
            }
            public UpdateRequest AutoCollection(AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public UpdateRequest AllowDirectDebit(bool allowDirectDebit) 
            {
                m_params.AddOpt("allow_direct_debit", allowDirectDebit);
                return this;
            }
            public UpdateRequest Taxability(TaxabilityEnum taxability) 
            {
                m_params.AddOpt("taxability", taxability);
                return this;
            }
            public UpdateRequest EntityCode(EntityCodeEnum entityCode) 
            {
                m_params.AddOpt("entity_code", entityCode);
                return this;
            }
            public UpdateRequest ExemptNumber(string exemptNumber) 
            {
                m_params.AddOpt("exempt_number", exemptNumber);
                return this;
            }
            public UpdateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public UpdateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
        }
        public class UpdatePaymentMethodRequest : EntityRequest<UpdatePaymentMethodRequest> 
        {
            public UpdatePaymentMethodRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdatePaymentMethodRequest PaymentMethodType(TypeEnum paymentMethodType) 
            {
                m_params.Add("payment_method[type]", paymentMethodType);
                return this;
            }
            public UpdatePaymentMethodRequest PaymentMethodGateway(GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public UpdatePaymentMethodRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.Add("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
        }
        public class UpdateBillingInfoRequest : EntityRequest<UpdateBillingInfoRequest> 
        {
            public UpdateBillingInfoRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateBillingInfoRequest VatNumber(string vatNumber) 
            {
                m_params.AddOpt("vat_number", vatNumber);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateBillingInfoRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
        }
        public class AddContactRequest : EntityRequest<AddContactRequest> 
        {
            public AddContactRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddContactRequest ContactId(string contactId) 
            {
                m_params.AddOpt("contact[id]", contactId);
                return this;
            }
            public AddContactRequest ContactFirstName(string contactFirstName) 
            {
                m_params.AddOpt("contact[first_name]", contactFirstName);
                return this;
            }
            public AddContactRequest ContactLastName(string contactLastName) 
            {
                m_params.AddOpt("contact[last_name]", contactLastName);
                return this;
            }
            public AddContactRequest ContactEmail(string contactEmail) 
            {
                m_params.Add("contact[email]", contactEmail);
                return this;
            }
            public AddContactRequest ContactPhone(string contactPhone) 
            {
                m_params.AddOpt("contact[phone]", contactPhone);
                return this;
            }
            public AddContactRequest ContactLabel(string contactLabel) 
            {
                m_params.AddOpt("contact[label]", contactLabel);
                return this;
            }
            public AddContactRequest ContactEnabled(bool contactEnabled) 
            {
                m_params.AddOpt("contact[enabled]", contactEnabled);
                return this;
            }
            public AddContactRequest ContactSendBillingEmail(bool contactSendBillingEmail) 
            {
                m_params.AddOpt("contact[send_billing_email]", contactSendBillingEmail);
                return this;
            }
            public AddContactRequest ContactSendAccountEmail(bool contactSendAccountEmail) 
            {
                m_params.AddOpt("contact[send_account_email]", contactSendAccountEmail);
                return this;
            }
        }
        public class UpdateContactRequest : EntityRequest<UpdateContactRequest> 
        {
            public UpdateContactRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateContactRequest ContactId(string contactId) 
            {
                m_params.Add("contact[id]", contactId);
                return this;
            }
            public UpdateContactRequest ContactFirstName(string contactFirstName) 
            {
                m_params.AddOpt("contact[first_name]", contactFirstName);
                return this;
            }
            public UpdateContactRequest ContactLastName(string contactLastName) 
            {
                m_params.AddOpt("contact[last_name]", contactLastName);
                return this;
            }
            public UpdateContactRequest ContactEmail(string contactEmail) 
            {
                m_params.AddOpt("contact[email]", contactEmail);
                return this;
            }
            public UpdateContactRequest ContactPhone(string contactPhone) 
            {
                m_params.AddOpt("contact[phone]", contactPhone);
                return this;
            }
            public UpdateContactRequest ContactLabel(string contactLabel) 
            {
                m_params.AddOpt("contact[label]", contactLabel);
                return this;
            }
            public UpdateContactRequest ContactEnabled(bool contactEnabled) 
            {
                m_params.AddOpt("contact[enabled]", contactEnabled);
                return this;
            }
            public UpdateContactRequest ContactSendBillingEmail(bool contactSendBillingEmail) 
            {
                m_params.AddOpt("contact[send_billing_email]", contactSendBillingEmail);
                return this;
            }
            public UpdateContactRequest ContactSendAccountEmail(bool contactSendAccountEmail) 
            {
                m_params.AddOpt("contact[send_account_email]", contactSendAccountEmail);
                return this;
            }
        }
        public class DeleteContactRequest : EntityRequest<DeleteContactRequest> 
        {
            public DeleteContactRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteContactRequest ContactId(string contactId) 
            {
                m_params.Add("contact[id]", contactId);
                return this;
            }
        }
        public class AddPromotionalCreditsRequest : EntityRequest<AddPromotionalCreditsRequest> 
        {
            public AddPromotionalCreditsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddPromotionalCreditsRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public AddPromotionalCreditsRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
        }
        public class DeductPromotionalCreditsRequest : EntityRequest<DeductPromotionalCreditsRequest> 
        {
            public DeductPromotionalCreditsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeductPromotionalCreditsRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public DeductPromotionalCreditsRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
        }
        public class SetPromotionalCreditsRequest : EntityRequest<SetPromotionalCreditsRequest> 
        {
            public SetPromotionalCreditsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public SetPromotionalCreditsRequest Amount(int amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public SetPromotionalCreditsRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteRequest DeletePaymentMethod(bool deletePaymentMethod) 
            {
                m_params.AddOpt("delete_payment_method", deletePaymentMethod);
                return this;
            }
        }
        #endregion

        [Obsolete]
        public enum CardStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("no_card")]
            NoCard,
            [Description("valid")]
            Valid,
            [Description("expiring")]
            Expiring,
            [Description("expired")]
            Expired,

        }

        #region Subclasses
        public class CustomerBillingAddress : Resource
        {

            public string FirstName() {
                return GetValue<string>("first_name", false);
            }

            public string LastName() {
                return GetValue<string>("last_name", false);
            }

            public string Email() {
                return GetValue<string>("email", false);
            }

            public string Company() {
                return GetValue<string>("company", false);
            }

            public string Phone() {
                return GetValue<string>("phone", false);
            }

            public string Line1() {
                return GetValue<string>("line1", false);
            }

            public string Line2() {
                return GetValue<string>("line2", false);
            }

            public string Line3() {
                return GetValue<string>("line3", false);
            }

            public string City() {
                return GetValue<string>("city", false);
            }

            public string StateCode() {
                return GetValue<string>("state_code", false);
            }

            public string State() {
                return GetValue<string>("state", false);
            }

            public string Country() {
                return GetValue<string>("country", false);
            }

            public string Zip() {
                return GetValue<string>("zip", false);
            }

        }
        public class CustomerContact : Resource
        {

            public string Id() {
                return GetValue<string>("id", true);
            }

            public string FirstName() {
                return GetValue<string>("first_name", false);
            }

            public string LastName() {
                return GetValue<string>("last_name", false);
            }

            public string Email() {
                return GetValue<string>("email", true);
            }

            public string Phone() {
                return GetValue<string>("phone", false);
            }

            public string Label() {
                return GetValue<string>("label", false);
            }

            public bool Enabled() {
                return GetValue<bool>("enabled", true);
            }

            public bool SendAccountEmail() {
                return GetValue<bool>("send_account_email", true);
            }

            public bool SendBillingEmail() {
                return GetValue<bool>("send_billing_email", true);
            }

        }
        public class CustomerPaymentMethod : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("card")]
                Card,
                [Description("paypal_express_checkout")]
                PaypalExpressCheckout,
                [Description("amazon_payments")]
                AmazonPayments,
                [Description("direct_debit")]
                DirectDebit,
            }
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
                [Description("invalid")]
                Invalid,
            }

            public TypeEnum PaymentMethodType() {
                return GetEnum<TypeEnum>("type", true);
            }

            public GatewayEnum Gateway() {
                return GetEnum<GatewayEnum>("gateway", true);
            }

            public StatusEnum Status() {
                return GetEnum<StatusEnum>("status", true);
            }

            public string ReferenceId() {
                return GetValue<string>("reference_id", false);
            }

        }

        #endregion
    }
}
