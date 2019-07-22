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

    public class Customer : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("customers");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static CustomerListRequest List()
        {
            string url = ApiUtil.BuildUrl("customers");
            return new CustomerListRequest(url);
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
        public static ListRequest ContactsForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "contacts");
            return new ListRequest(url);
        }
        public static AssignPaymentRoleRequest AssignPaymentRole(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "assign_payment_role");
            return new AssignPaymentRoleRequest(url, HttpMethod.POST);
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
        [Obsolete]
        public static AddPromotionalCreditsRequest AddPromotionalCredits(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "add_promotional_credits");
            return new AddPromotionalCreditsRequest(url, HttpMethod.POST);
        }
        [Obsolete]
        public static DeductPromotionalCreditsRequest DeductPromotionalCredits(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "deduct_promotional_credits");
            return new DeductPromotionalCreditsRequest(url, HttpMethod.POST);
        }
        [Obsolete]
        public static SetPromotionalCreditsRequest SetPromotionalCredits(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "set_promotional_credits");
            return new SetPromotionalCreditsRequest(url, HttpMethod.POST);
        }
        public static RecordExcessPaymentRequest RecordExcessPayment(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "record_excess_payment");
            return new RecordExcessPaymentRequest(url, HttpMethod.POST);
        }
        public static CollectPaymentRequest CollectPayment(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "collect_payment");
            return new CollectPaymentRequest(url, HttpMethod.POST);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
        }
        public static MoveRequest Move()
        {
            string url = ApiUtil.BuildUrl("customers", "move");
            return new MoveRequest(url, HttpMethod.POST);
        }
        public static ChangeBillingDateRequest ChangeBillingDate(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "change_billing_date");
            return new ChangeBillingDateRequest(url, HttpMethod.POST);
        }
        public static MergeRequest Merge()
        {
            string url = ApiUtil.BuildUrl("customers", "merge");
            return new MergeRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> ClearPersonalData(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "clear_personal_data");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static RelationshipsRequest Relationships(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "relationships");
            return new RelationshipsRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> DeleteRelationship(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "delete_relationship");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static HierarchyRequest Hierarchy(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "hierarchy");
            return new HierarchyRequest(url, HttpMethod.GET);
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
        public int NetTermDays 
        {
            get { return GetValue<int>("net_term_days", true); }
        }
        public DateTime? VatNumberValidatedTime 
        {
            get { return GetDateTime("vat_number_validated_time", false); }
        }
        public VatNumberStatusEnum? VatNumberStatus 
        {
            get { return GetEnum<VatNumberStatusEnum>("vat_number_status", false); }
        }
        public bool AllowDirectDebit 
        {
            get { return GetValue<bool>("allow_direct_debit", true); }
        }
        public bool? IsLocationValid 
        {
            get { return GetValue<bool?>("is_location_valid", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public string CreatedFromIp 
        {
            get { return GetValue<string>("created_from_ip", false); }
        }
        public JArray ExemptionDetails 
        {
            get { return GetJArray("exemption_details", false); }
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
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string Locale 
        {
            get { return GetValue<string>("locale", false); }
        }
        public bool? ConsolidatedInvoicing 
        {
            get { return GetValue<bool?>("consolidated_invoicing", false); }
        }
        public int? BillingDate 
        {
            get { return GetValue<int?>("billing_date", false); }
        }
        public BillingDateModeEnum? BillingDateMode 
        {
            get { return GetEnum<BillingDateModeEnum>("billing_date_mode", false); }
        }
        public BillingDayOfWeekEnum? BillingDayOfWeek 
        {
            get { return GetEnum<BillingDayOfWeekEnum>("billing_day_of_week", false); }
        }
        public BillingDayOfWeekModeEnum? BillingDayOfWeekMode 
        {
            get { return GetEnum<BillingDayOfWeekModeEnum>("billing_day_of_week_mode", false); }
        }
        public PiiClearedEnum? PiiCleared 
        {
            get { return GetEnum<PiiClearedEnum>("pii_cleared", false); }
        }
        [Obsolete]
        public CardStatusEnum? CardStatus 
        {
            get { return GetEnum<CardStatusEnum>("card_status", false); }
        }
        public FraudFlagEnum? FraudFlag 
        {
            get { return GetEnum<FraudFlagEnum>("fraud_flag", false); }
        }
        public string PrimaryPaymentSourceId 
        {
            get { return GetValue<string>("primary_payment_source_id", false); }
        }
        public string BackupPaymentSourceId 
        {
            get { return GetValue<string>("backup_payment_source_id", false); }
        }
        public CustomerBillingAddress BillingAddress 
        {
            get { return GetSubResource<CustomerBillingAddress>("billing_address"); }
        }
        public List<CustomerReferralUrl> ReferralUrls 
        {
            get { return GetResourceList<CustomerReferralUrl>("referral_urls"); }
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
        public string PreferredCurrencyCode 
        {
            get { return GetValue<string>("preferred_currency_code", false); }
        }
        public int PromotionalCredits 
        {
            get { return GetValue<int>("promotional_credits", true); }
        }
        public int UnbilledCharges 
        {
            get { return GetValue<int>("unbilled_charges", true); }
        }
        public int RefundableCredits 
        {
            get { return GetValue<int>("refundable_credits", true); }
        }
        public int ExcessPayments 
        {
            get { return GetValue<int>("excess_payments", true); }
        }
        public List<CustomerBalance> Balances 
        {
            get { return GetResourceList<CustomerBalance>("balances"); }
        }
        public JToken MetaData 
        {
            get { return GetJToken("meta_data", false); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        public bool? RegisteredForGst 
        {
            get { return GetValue<bool?>("registered_for_gst", false); }
        }
        public bool? BusinessCustomerWithoutVatNumber 
        {
            get { return GetValue<bool?>("business_customer_without_vat_number", false); }
        }
        public CustomerTypeEnum? CustomerType 
        {
            get { return GetEnum<CustomerTypeEnum>("customer_type", false); }
        }
        public CustomerRelationship Relationship 
        {
            get { return GetSubResource<CustomerRelationship>("relationship"); }
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
            public CreateRequest PreferredCurrencyCode(string preferredCurrencyCode) 
            {
                m_params.AddOpt("preferred_currency_code", preferredCurrencyCode);
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
            public CreateRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateRequest NetTermDays(int netTermDays) 
            {
                m_params.AddOpt("net_term_days", netTermDays);
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
            public CreateRequest RegisteredForGst(bool registeredForGst) 
            {
                m_params.AddOpt("registered_for_gst", registeredForGst);
                return this;
            }
            public CreateRequest Taxability(ChargeBee.Models.Enums.TaxabilityEnum taxability) 
            {
                m_params.AddOpt("taxability", taxability);
                return this;
            }
            public CreateRequest ExemptionDetails(JArray exemptionDetails) 
            {
                m_params.AddOpt("exemption_details", exemptionDetails);
                return this;
            }
            public CreateRequest CustomerType(ChargeBee.Models.Enums.CustomerTypeEnum customerType) 
            {
                m_params.AddOpt("customer_type", customerType);
                return this;
            }
            public CreateRequest Locale(string locale) 
            {
                m_params.AddOpt("locale", locale);
                return this;
            }
            public CreateRequest EntityCode(ChargeBee.Models.Enums.EntityCodeEnum entityCode) 
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
            public CreateRequest ConsolidatedInvoicing(bool consolidatedInvoicing) 
            {
                m_params.AddOpt("consolidated_invoicing", consolidatedInvoicing);
                return this;
            }
            public CreateRequest TokenId(string tokenId) 
            {
                m_params.AddOpt("token_id", tokenId);
                return this;
            }
            [Obsolete]
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
            [Obsolete]
            public CreateRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CreateRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            [Obsolete]
            public CreateRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public CreateRequest BankAccountGatewayAccountId(string bankAccountGatewayAccountId) 
            {
                m_params.AddOpt("bank_account[gateway_account_id]", bankAccountGatewayAccountId);
                return this;
            }
            public CreateRequest BankAccountIban(string bankAccountIban) 
            {
                m_params.AddOpt("bank_account[iban]", bankAccountIban);
                return this;
            }
            public CreateRequest BankAccountFirstName(string bankAccountFirstName) 
            {
                m_params.AddOpt("bank_account[first_name]", bankAccountFirstName);
                return this;
            }
            public CreateRequest BankAccountLastName(string bankAccountLastName) 
            {
                m_params.AddOpt("bank_account[last_name]", bankAccountLastName);
                return this;
            }
            public CreateRequest BankAccountCompany(string bankAccountCompany) 
            {
                m_params.AddOpt("bank_account[company]", bankAccountCompany);
                return this;
            }
            public CreateRequest BankAccountEmail(string bankAccountEmail) 
            {
                m_params.AddOpt("bank_account[email]", bankAccountEmail);
                return this;
            }
            public CreateRequest BankAccountBankName(string bankAccountBankName) 
            {
                m_params.AddOpt("bank_account[bank_name]", bankAccountBankName);
                return this;
            }
            public CreateRequest BankAccountAccountNumber(string bankAccountAccountNumber) 
            {
                m_params.AddOpt("bank_account[account_number]", bankAccountAccountNumber);
                return this;
            }
            public CreateRequest BankAccountRoutingNumber(string bankAccountRoutingNumber) 
            {
                m_params.AddOpt("bank_account[routing_number]", bankAccountRoutingNumber);
                return this;
            }
            public CreateRequest BankAccountBankCode(string bankAccountBankCode) 
            {
                m_params.AddOpt("bank_account[bank_code]", bankAccountBankCode);
                return this;
            }
            public CreateRequest BankAccountAccountType(ChargeBee.Models.Enums.AccountTypeEnum bankAccountAccountType) 
            {
                m_params.AddOpt("bank_account[account_type]", bankAccountAccountType);
                return this;
            }
            public CreateRequest BankAccountAccountHolderType(ChargeBee.Models.Enums.AccountHolderTypeEnum bankAccountAccountHolderType) 
            {
                m_params.AddOpt("bank_account[account_holder_type]", bankAccountAccountHolderType);
                return this;
            }
            public CreateRequest BankAccountEcheckType(ChargeBee.Models.Enums.EcheckTypeEnum bankAccountEcheckType) 
            {
                m_params.AddOpt("bank_account[echeck_type]", bankAccountEcheckType);
                return this;
            }
            public CreateRequest BankAccountIssuingCountry(string bankAccountIssuingCountry) 
            {
                m_params.AddOpt("bank_account[issuing_country]", bankAccountIssuingCountry);
                return this;
            }
            public CreateRequest BankAccountSwedishIdentityNumber(string bankAccountSwedishIdentityNumber) 
            {
                m_params.AddOpt("bank_account[swedish_identity_number]", bankAccountSwedishIdentityNumber);
                return this;
            }
            public CreateRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            [Obsolete]
            public CreateRequest PaymentMethodGateway(ChargeBee.Models.Enums.GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public CreateRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public CreateRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public CreateRequest PaymentMethodTmpToken(string paymentMethodTmpToken) 
            {
                m_params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
                return this;
            }
            public CreateRequest PaymentMethodIssuingCountry(string paymentMethodIssuingCountry) 
            {
                m_params.AddOpt("payment_method[issuing_country]", paymentMethodIssuingCountry);
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
            [Obsolete]
            public CreateRequest CardIpAddress(string cardIpAddress) 
            {
                m_params.AddOpt("card[ip_address]", cardIpAddress);
                return this;
            }
            public CreateRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
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
            public CreateRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
        }
        public class CustomerListRequest : ListRequestBase<CustomerListRequest> 
        {
            public CustomerListRequest(string url) 
                    : base(url)
            {
            }

            public CustomerListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public StringFilter<CustomerListRequest> Id() 
            {
                return new StringFilter<CustomerListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CustomerListRequest> FirstName() 
            {
                return new StringFilter<CustomerListRequest>("first_name", this).SupportsPresenceOperator(true);        
            }
            public StringFilter<CustomerListRequest> LastName() 
            {
                return new StringFilter<CustomerListRequest>("last_name", this).SupportsPresenceOperator(true);        
            }
            public StringFilter<CustomerListRequest> Email() 
            {
                return new StringFilter<CustomerListRequest>("email", this).SupportsPresenceOperator(true);        
            }
            public StringFilter<CustomerListRequest> Company() 
            {
                return new StringFilter<CustomerListRequest>("company", this).SupportsPresenceOperator(true);        
            }
            public StringFilter<CustomerListRequest> Phone() 
            {
                return new StringFilter<CustomerListRequest>("phone", this).SupportsPresenceOperator(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, CustomerListRequest> AutoCollection() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, CustomerListRequest>("auto_collection", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, CustomerListRequest> Taxability() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, CustomerListRequest>("taxability", this);        
            }
            public TimestampFilter<CustomerListRequest> CreatedAt() 
            {
                return new TimestampFilter<CustomerListRequest>("created_at", this);        
            }
            public TimestampFilter<CustomerListRequest> UpdatedAt() 
            {
                return new TimestampFilter<CustomerListRequest>("updated_at", this);        
            }
            public CustomerListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
            public CustomerListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
            public StringFilter<CustomerListRequest> RelationshipParentId() 
            {
                return new StringFilter<CustomerListRequest>("relationship[parent_id]", this);        
            }

            public StringFilter<CustomerListRequest> RelationshipPaymentOwnerId() 
            {
                return new StringFilter<CustomerListRequest>("relationship[payment_owner_id]", this);        
            }

            public StringFilter<CustomerListRequest> RelationshipInvoiceOwnerId() 
            {
                return new StringFilter<CustomerListRequest>("relationship[invoice_owner_id]", this);        
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
            public UpdateRequest PreferredCurrencyCode(string preferredCurrencyCode) 
            {
                m_params.AddOpt("preferred_currency_code", preferredCurrencyCode);
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
            public UpdateRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public UpdateRequest AllowDirectDebit(bool allowDirectDebit) 
            {
                m_params.AddOpt("allow_direct_debit", allowDirectDebit);
                return this;
            }
            public UpdateRequest NetTermDays(int netTermDays) 
            {
                m_params.AddOpt("net_term_days", netTermDays);
                return this;
            }
            public UpdateRequest Taxability(ChargeBee.Models.Enums.TaxabilityEnum taxability) 
            {
                m_params.AddOpt("taxability", taxability);
                return this;
            }
            public UpdateRequest ExemptionDetails(JArray exemptionDetails) 
            {
                m_params.AddOpt("exemption_details", exemptionDetails);
                return this;
            }
            public UpdateRequest CustomerType(ChargeBee.Models.Enums.CustomerTypeEnum customerType) 
            {
                m_params.AddOpt("customer_type", customerType);
                return this;
            }
            public UpdateRequest Locale(string locale) 
            {
                m_params.AddOpt("locale", locale);
                return this;
            }
            public UpdateRequest EntityCode(ChargeBee.Models.Enums.EntityCodeEnum entityCode) 
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
            public UpdateRequest FraudFlag(FraudFlagEnum fraudFlag) 
            {
                m_params.AddOpt("fraud_flag", fraudFlag);
                return this;
            }
            public UpdateRequest ConsolidatedInvoicing(bool consolidatedInvoicing) 
            {
                m_params.AddOpt("consolidated_invoicing", consolidatedInvoicing);
                return this;
            }
        }
        public class UpdatePaymentMethodRequest : EntityRequest<UpdatePaymentMethodRequest> 
        {
            public UpdatePaymentMethodRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdatePaymentMethodRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.Add("payment_method[type]", paymentMethodType);
                return this;
            }
            [Obsolete]
            public UpdatePaymentMethodRequest PaymentMethodGateway(ChargeBee.Models.Enums.GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public UpdatePaymentMethodRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public UpdatePaymentMethodRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public UpdatePaymentMethodRequest PaymentMethodTmpToken(string paymentMethodTmpToken) 
            {
                m_params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
                return this;
            }
            public UpdatePaymentMethodRequest PaymentMethodIssuingCountry(string paymentMethodIssuingCountry) 
            {
                m_params.AddOpt("payment_method[issuing_country]", paymentMethodIssuingCountry);
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
            public UpdateBillingInfoRequest RegisteredForGst(bool registeredForGst) 
            {
                m_params.AddOpt("registered_for_gst", registeredForGst);
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
            public UpdateBillingInfoRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
        }
        public class AssignPaymentRoleRequest : EntityRequest<AssignPaymentRoleRequest> 
        {
            public AssignPaymentRoleRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AssignPaymentRoleRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.Add("payment_source_id", paymentSourceId);
                return this;
            }
            public AssignPaymentRoleRequest Role(ChargeBee.Models.Enums.RoleEnum role) 
            {
                m_params.Add("role", role);
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
            public AddPromotionalCreditsRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public AddPromotionalCreditsRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public AddPromotionalCreditsRequest CreditType(ChargeBee.Models.Enums.CreditTypeEnum creditType) 
            {
                m_params.AddOpt("credit_type", creditType);
                return this;
            }
            public AddPromotionalCreditsRequest Reference(string reference) 
            {
                m_params.AddOpt("reference", reference);
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
            public DeductPromotionalCreditsRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public DeductPromotionalCreditsRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public DeductPromotionalCreditsRequest CreditType(ChargeBee.Models.Enums.CreditTypeEnum creditType) 
            {
                m_params.AddOpt("credit_type", creditType);
                return this;
            }
            public DeductPromotionalCreditsRequest Reference(string reference) 
            {
                m_params.AddOpt("reference", reference);
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
            public SetPromotionalCreditsRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public SetPromotionalCreditsRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public SetPromotionalCreditsRequest CreditType(ChargeBee.Models.Enums.CreditTypeEnum creditType) 
            {
                m_params.AddOpt("credit_type", creditType);
                return this;
            }
            public SetPromotionalCreditsRequest Reference(string reference) 
            {
                m_params.AddOpt("reference", reference);
                return this;
            }
        }
        public class RecordExcessPaymentRequest : EntityRequest<RecordExcessPaymentRequest> 
        {
            public RecordExcessPaymentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordExcessPaymentRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public RecordExcessPaymentRequest TransactionAmount(int transactionAmount) 
            {
                m_params.Add("transaction[amount]", transactionAmount);
                return this;
            }
            public RecordExcessPaymentRequest TransactionCurrencyCode(string transactionCurrencyCode) 
            {
                m_params.AddOpt("transaction[currency_code]", transactionCurrencyCode);
                return this;
            }
            public RecordExcessPaymentRequest TransactionDate(long transactionDate) 
            {
                m_params.Add("transaction[date]", transactionDate);
                return this;
            }
            public RecordExcessPaymentRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.Add("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public RecordExcessPaymentRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
        }
        public class CollectPaymentRequest : EntityRequest<CollectPaymentRequest> 
        {
            public CollectPaymentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CollectPaymentRequest Amount(int amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public CollectPaymentRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CollectPaymentRequest TokenId(string tokenId) 
            {
                m_params.AddOpt("token_id", tokenId);
                return this;
            }
            public CollectPaymentRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CollectPaymentRequest RetainPaymentSource(bool retainPaymentSource) 
            {
                m_params.AddOpt("retain_payment_source", retainPaymentSource);
                return this;
            }
            public CollectPaymentRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            public CollectPaymentRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public CollectPaymentRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public CollectPaymentRequest PaymentMethodTmpToken(string paymentMethodTmpToken) 
            {
                m_params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
                return this;
            }
            public CollectPaymentRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            public CollectPaymentRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public CollectPaymentRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public CollectPaymentRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public CollectPaymentRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public CollectPaymentRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public CollectPaymentRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public CollectPaymentRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public CollectPaymentRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public CollectPaymentRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public CollectPaymentRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public CollectPaymentRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public CollectPaymentRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public CollectPaymentRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            public CollectPaymentRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CollectPaymentRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CollectPaymentRequest InvoiceAllocationInvoiceId(int index, string invoiceAllocationInvoiceId) 
            {
                m_params.AddOpt("invoice_allocations[invoice_id][" + index + "]", invoiceAllocationInvoiceId);
                return this;
            }
            public CollectPaymentRequest InvoiceAllocationAllocationAmount(int index, int invoiceAllocationAllocationAmount) 
            {
                m_params.AddOpt("invoice_allocations[allocation_amount][" + index + "]", invoiceAllocationAllocationAmount);
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
        public class MoveRequest : EntityRequest<MoveRequest> 
        {
            public MoveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public MoveRequest IdAtFromSite(string idAtFromSite) 
            {
                m_params.Add("id_at_from_site", idAtFromSite);
                return this;
            }
            public MoveRequest FromSite(string fromSite) 
            {
                m_params.Add("from_site", fromSite);
                return this;
            }
        }
        public class ChangeBillingDateRequest : EntityRequest<ChangeBillingDateRequest> 
        {
            public ChangeBillingDateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChangeBillingDateRequest BillingDate(int billingDate) 
            {
                m_params.AddOpt("billing_date", billingDate);
                return this;
            }
            public ChangeBillingDateRequest BillingDateMode(ChargeBee.Models.Enums.BillingDateModeEnum billingDateMode) 
            {
                m_params.AddOpt("billing_date_mode", billingDateMode);
                return this;
            }
            public ChangeBillingDateRequest BillingDayOfWeek(Customer.BillingDayOfWeekEnum billingDayOfWeek) 
            {
                m_params.AddOpt("billing_day_of_week", billingDayOfWeek);
                return this;
            }
            public ChangeBillingDateRequest BillingDayOfWeekMode(ChargeBee.Models.Enums.BillingDayOfWeekModeEnum billingDayOfWeekMode) 
            {
                m_params.AddOpt("billing_day_of_week_mode", billingDayOfWeekMode);
                return this;
            }
        }
        public class MergeRequest : EntityRequest<MergeRequest> 
        {
            public MergeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public MergeRequest FromCustomerId(string fromCustomerId) 
            {
                m_params.Add("from_customer_id", fromCustomerId);
                return this;
            }
            public MergeRequest ToCustomerId(string toCustomerId) 
            {
                m_params.Add("to_customer_id", toCustomerId);
                return this;
            }
        }
        public class RelationshipsRequest : EntityRequest<RelationshipsRequest> 
        {
            public RelationshipsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RelationshipsRequest ParentId(string parentId) 
            {
                m_params.AddOpt("parent_id", parentId);
                return this;
            }
            public RelationshipsRequest PaymentOwnerId(string paymentOwnerId) 
            {
                m_params.AddOpt("payment_owner_id", paymentOwnerId);
                return this;
            }
            public RelationshipsRequest InvoiceOwnerId(string invoiceOwnerId) 
            {
                m_params.AddOpt("invoice_owner_id", invoiceOwnerId);
                return this;
            }
        }
        public class HierarchyRequest : EntityRequest<HierarchyRequest> 
        {
            public HierarchyRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public HierarchyRequest HierarchyOperationType(ChargeBee.Models.Enums.HierarchyOperationTypeEnum hierarchyOperationType) 
            {
                m_params.AddOpt("hierarchy_operation_type", hierarchyOperationType);
                return this;
            }
        }
        #endregion

        public enum VatNumberStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "valid")]
            Valid,
            [EnumMember(Value = "invalid")]
            Invalid,
            [EnumMember(Value = "not_validated")]
            NotValidated,
            [EnumMember(Value = "undetermined")]
            Undetermined,

        }
        public enum BillingDayOfWeekEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "sunday")]
            Sunday,
            [EnumMember(Value = "monday")]
            Monday,
            [EnumMember(Value = "tuesday")]
            Tuesday,
            [EnumMember(Value = "wednesday")]
            Wednesday,
            [EnumMember(Value = "thursday")]
            Thursday,
            [EnumMember(Value = "friday")]
            Friday,
            [EnumMember(Value = "saturday")]
            Saturday,

        }
        public enum PiiClearedEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "scheduled_for_clear")]
            ScheduledForClear,
            [EnumMember(Value = "cleared")]
            Cleared,

        }
        [Obsolete]
        public enum CardStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "no_card")]
            NoCard,
            [EnumMember(Value = "valid")]
            Valid,
            [EnumMember(Value = "expiring")]
            Expiring,
            [EnumMember(Value = "expired")]
            Expired,
            [EnumMember(Value = "pending_verification")]
            PendingVerification,
            [EnumMember(Value = "invalid")]
            Invalid,

        }
        public enum FraudFlagEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "safe")]
            Safe,
            [EnumMember(Value = "suspicious")]
            Suspicious,
            [EnumMember(Value = "fraudulent")]
            Fraudulent,

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

            public ValidationStatusEnum? ValidationStatus() {
                return GetEnum<ValidationStatusEnum>("validation_status", false);
            }

        }
        public class CustomerReferralUrl : Resource
        {

            public string ExternalCustomerId() {
                return GetValue<string>("external_customer_id", false);
            }

            public string ReferralSharingUrl() {
                return GetValue<string>("referral_sharing_url", true);
            }

            public DateTime CreatedAt() {
                return (DateTime)GetDateTime("created_at", true);
            }

            public DateTime UpdatedAt() {
                return (DateTime)GetDateTime("updated_at", true);
            }

            public string ReferralCampaignId() {
                return GetValue<string>("referral_campaign_id", true);
            }

            public string ReferralAccountId() {
                return GetValue<string>("referral_account_id", true);
            }

            public string ReferralExternalCampaignId() {
                return GetValue<string>("referral_external_campaign_id", false);
            }

            public ReferralSystemEnum ReferralSystem() {
                return GetEnum<ReferralSystemEnum>("referral_system", true);
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
                [EnumMember(Value = "card")]
                Card,
                [EnumMember(Value = "paypal_express_checkout")]
                PaypalExpressCheckout,
                [EnumMember(Value = "amazon_payments")]
                AmazonPayments,
                [EnumMember(Value = "direct_debit")]
                DirectDebit,
                [EnumMember(Value = "generic")]
                Generic,
                [EnumMember(Value = "alipay")]
                Alipay,
                [EnumMember(Value = "unionpay")]
                Unionpay,
                [EnumMember(Value = "apple_pay")]
                ApplePay,
                [EnumMember(Value = "wechat_pay")]
                WechatPay,
            }
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

            public TypeEnum PaymentMethodType() {
                return GetEnum<TypeEnum>("type", true);
            }

            public GatewayEnum Gateway() {
                return GetEnum<GatewayEnum>("gateway", true);
            }

            public string GatewayAccountId() {
                return GetValue<string>("gateway_account_id", false);
            }

            public StatusEnum Status() {
                return GetEnum<StatusEnum>("status", true);
            }

            public string ReferenceId() {
                return GetValue<string>("reference_id", true);
            }

        }
        public class CustomerBalance : Resource
        {

            public int PromotionalCredits() {
                return GetValue<int>("promotional_credits", true);
            }

            public int ExcessPayments() {
                return GetValue<int>("excess_payments", true);
            }

            public int RefundableCredits() {
                return GetValue<int>("refundable_credits", true);
            }

            public int UnbilledCharges() {
                return GetValue<int>("unbilled_charges", true);
            }

            public string CurrencyCode() {
                return GetValue<string>("currency_code", true);
            }
			[Obsolete]
            public string BalanceCurrencyCode() {
                return GetValue<string>("balance_currency_code", true);
            }

        }
        public class CustomerRelationship : Resource
        {

            public string ParentId() {
                return GetValue<string>("parent_id", false);
            }

            public string PaymentOwnerId() {
                return GetValue<string>("payment_owner_id", true);
            }

            public string InvoiceOwnerId() {
                return GetValue<string>("invoice_owner_id", true);
            }

        }

        #endregion
    }
}
