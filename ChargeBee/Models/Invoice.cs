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

    public class Invoice : Resource 
    {
    
        public Invoice() { }

        public Invoice(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Invoice(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Invoice(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("invoices");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static CreateForChargeItemsAndChargesRequest CreateForChargeItemsAndCharges()
        {
            string url = ApiUtil.BuildUrl("invoices", "create_for_charge_items_and_charges");
            return new CreateForChargeItemsAndChargesRequest(url, HttpMethod.POST);
        }
        public static ChargeRequest Charge()
        {
            string url = ApiUtil.BuildUrl("invoices", "charge");
            return new ChargeRequest(url, HttpMethod.POST);
        }
        public static ChargeAddonRequest ChargeAddon()
        {
            string url = ApiUtil.BuildUrl("invoices", "charge_addon");
            return new ChargeAddonRequest(url, HttpMethod.POST);
        }
        [Obsolete]
        public static CreateForChargeItemRequest CreateForChargeItem()
        {
            string url = ApiUtil.BuildUrl("invoices", "create_for_charge_item");
            return new CreateForChargeItemRequest(url, HttpMethod.POST);
        }
        public static StopDunningRequest StopDunning(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "stop_dunning");
            return new StopDunningRequest(url, HttpMethod.POST);
        }
        public static ImportInvoiceRequest ImportInvoice()
        {
            string url = ApiUtil.BuildUrl("invoices", "import_invoice");
            return new ImportInvoiceRequest(url, HttpMethod.POST);
        }
        public static ApplyPaymentsRequest ApplyPayments(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "apply_payments");
            return new ApplyPaymentsRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> SyncUsages(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "sync_usages");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static DeleteLineItemsRequest DeleteLineItems(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "delete_line_items");
            return new DeleteLineItemsRequest(url, HttpMethod.POST);
        }
        public static ApplyCreditsRequest ApplyCredits(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "apply_credits");
            return new ApplyCreditsRequest(url, HttpMethod.POST);
        }
        public static InvoiceListRequest List()
        {
            string url = ApiUtil.BuildUrl("invoices");
            return new InvoiceListRequest(url);
        }
        [Obsolete]
        public static ListRequest InvoicesForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "invoices");
            return new ListRequest(url);
        }
        [Obsolete]
        public static ListRequest InvoicesForSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "invoices");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static PdfRequest Pdf(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "pdf");
            return new PdfRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> DownloadEinvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "download_einvoice");
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static AddChargeRequest AddCharge(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "add_charge");
            return new AddChargeRequest(url, HttpMethod.POST);
        }
        public static AddAddonChargeRequest AddAddonCharge(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "add_addon_charge");
            return new AddAddonChargeRequest(url, HttpMethod.POST);
        }
        public static AddChargeItemRequest AddChargeItem(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "add_charge_item");
            return new AddChargeItemRequest(url, HttpMethod.POST);
        }
        public static CloseRequest Close(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "close");
            return new CloseRequest(url, HttpMethod.POST);
        }
        public static CollectPaymentRequest CollectPayment(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "collect_payment");
            return new CollectPaymentRequest(url, HttpMethod.POST);
        }
        public static RecordPaymentRequest RecordPayment(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "record_payment");
            return new RecordPaymentRequest(url, HttpMethod.POST);
        }
        public static RecordTaxWithheldRequest RecordTaxWithheld(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "record_tax_withheld");
            return new RecordTaxWithheldRequest(url, HttpMethod.POST);
        }
        public static RemoveTaxWithheldRequest RemoveTaxWithheld(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "remove_tax_withheld");
            return new RemoveTaxWithheldRequest(url, HttpMethod.POST);
        }
        public static RefundRequest Refund(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "refund");
            return new RefundRequest(url, HttpMethod.POST);
        }
        public static RecordRefundRequest RecordRefund(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "record_refund");
            return new RecordRefundRequest(url, HttpMethod.POST);
        }
        public static RemovePaymentRequest RemovePayment(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "remove_payment");
            return new RemovePaymentRequest(url, HttpMethod.POST);
        }
        public static RemoveCreditNoteRequest RemoveCreditNote(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "remove_credit_note");
            return new RemoveCreditNoteRequest(url, HttpMethod.POST);
        }
        public static VoidInvoiceRequest VoidInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "void");
            return new VoidInvoiceRequest(url, HttpMethod.POST);
        }
        public static WriteOffRequest WriteOff(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "write_off");
            return new WriteOffRequest(url, HttpMethod.POST);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
        }
        public static UpdateDetailsRequest UpdateDetails(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "update_details");
            return new UpdateDetailsRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> ResendEinvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "resend_einvoice");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string PoNumber 
        {
            get { return GetValue<string>("po_number", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public bool Recurring 
        {
            get { return GetValue<bool>("recurring", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string VatNumber 
        {
            get { return GetValue<string>("vat_number", false); }
        }
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public DateTime? Date 
        {
            get { return GetDateTime("date", false); }
        }
        public DateTime? DueDate 
        {
            get { return GetDateTime("due_date", false); }
        }
        public int? NetTermDays 
        {
            get { return GetValue<int?>("net_term_days", false); }
        }
        public decimal? ExchangeRate 
        {
            get { return GetValue<decimal?>("exchange_rate", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public long? Total 
        {
            get { return GetValue<long?>("total", false); }
        }
        public long? AmountPaid 
        {
            get { return GetValue<long?>("amount_paid", false); }
        }
        public long? AmountAdjusted 
        {
            get { return GetValue<long?>("amount_adjusted", false); }
        }
        public long? WriteOffAmount 
        {
            get { return GetValue<long?>("write_off_amount", false); }
        }
        public long? CreditsApplied 
        {
            get { return GetValue<long?>("credits_applied", false); }
        }
        public long? AmountDue 
        {
            get { return GetValue<long?>("amount_due", false); }
        }
        public DateTime? PaidAt 
        {
            get { return GetDateTime("paid_at", false); }
        }
        public DunningStatusEnum? DunningStatus 
        {
            get { return GetEnum<DunningStatusEnum>("dunning_status", false); }
        }
        public DateTime? NextRetryAt 
        {
            get { return GetDateTime("next_retry_at", false); }
        }
        public DateTime? VoidedAt 
        {
            get { return GetDateTime("voided_at", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public long SubTotal 
        {
            get { return GetValue<long>("sub_total", true); }
        }
        public long? SubTotalInLocalCurrency 
        {
            get { return GetValue<long?>("sub_total_in_local_currency", false); }
        }
        public long? TotalInLocalCurrency 
        {
            get { return GetValue<long?>("total_in_local_currency", false); }
        }
        public string LocalCurrencyCode 
        {
            get { return GetValue<string>("local_currency_code", false); }
        }
        public long Tax 
        {
            get { return GetValue<long>("tax", true); }
        }
        public bool? FirstInvoice 
        {
            get { return GetValue<bool?>("first_invoice", false); }
        }
        public long? NewSalesAmount 
        {
            get { return GetValue<long?>("new_sales_amount", false); }
        }
        public bool? HasAdvanceCharges 
        {
            get { return GetValue<bool?>("has_advance_charges", false); }
        }
        public bool TermFinalized 
        {
            get { return GetValue<bool>("term_finalized", true); }
        }
        public bool IsGifted 
        {
            get { return GetValue<bool>("is_gifted", true); }
        }
        public DateTime? GeneratedAt 
        {
            get { return GetDateTime("generated_at", false); }
        }
        public DateTime? ExpectedPaymentDate 
        {
            get { return GetDateTime("expected_payment_date", false); }
        }
        public long? AmountToCollect 
        {
            get { return GetValue<long?>("amount_to_collect", false); }
        }
        public long? RoundOffAmount 
        {
            get { return GetValue<long?>("round_off_amount", false); }
        }
        public List<InvoiceLineItem> LineItems 
        {
            get { return GetResourceList<InvoiceLineItem>("line_items"); }
        }
        public List<InvoiceDiscount> Discounts 
        {
            get { return GetResourceList<InvoiceDiscount>("discounts"); }
        }
        public List<InvoiceLineItemDiscount> LineItemDiscounts 
        {
            get { return GetResourceList<InvoiceLineItemDiscount>("line_item_discounts"); }
        }
        public List<InvoiceTax> Taxes 
        {
            get { return GetResourceList<InvoiceTax>("taxes"); }
        }
        public List<InvoiceLineItemTax> LineItemTaxes 
        {
            get { return GetResourceList<InvoiceLineItemTax>("line_item_taxes"); }
        }
        public List<InvoiceLineItemTier> LineItemTiers 
        {
            get { return GetResourceList<InvoiceLineItemTier>("line_item_tiers"); }
        }
        public List<InvoiceLinkedPayment> LinkedPayments 
        {
            get { return GetResourceList<InvoiceLinkedPayment>("linked_payments"); }
        }
        public List<InvoiceDunningAttempt> DunningAttempts 
        {
            get { return GetResourceList<InvoiceDunningAttempt>("dunning_attempts"); }
        }
        public List<InvoiceAppliedCredit> AppliedCredits 
        {
            get { return GetResourceList<InvoiceAppliedCredit>("applied_credits"); }
        }
        public List<InvoiceAdjustmentCreditNote> AdjustmentCreditNotes 
        {
            get { return GetResourceList<InvoiceAdjustmentCreditNote>("adjustment_credit_notes"); }
        }
        public List<InvoiceIssuedCreditNote> IssuedCreditNotes 
        {
            get { return GetResourceList<InvoiceIssuedCreditNote>("issued_credit_notes"); }
        }
        public List<InvoiceLinkedOrder> LinkedOrders 
        {
            get { return GetResourceList<InvoiceLinkedOrder>("linked_orders"); }
        }
        public List<InvoiceNote> Notes 
        {
            get { return GetResourceList<InvoiceNote>("notes"); }
        }
        public InvoiceShippingAddress ShippingAddress 
        {
            get { return GetSubResource<InvoiceShippingAddress>("shipping_address"); }
        }
        public InvoiceBillingAddress BillingAddress 
        {
            get { return GetSubResource<InvoiceBillingAddress>("billing_address"); }
        }
        public InvoiceEinvoice Einvoice 
        {
            get { return GetSubResource<InvoiceEinvoice>("einvoice"); }
        }
        public string PaymentOwner 
        {
            get { return GetValue<string>("payment_owner", false); }
        }
        public string VoidReasonCode 
        {
            get { return GetValue<string>("void_reason_code", false); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        public string VatNumberPrefix 
        {
            get { return GetValue<string>("vat_number_prefix", false); }
        }
        public ChannelEnum? Channel 
        {
            get { return GetEnum<ChannelEnum>("channel", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public CreateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateRequest InvoiceNote(string invoiceNote) 
            {
                m_params.AddOpt("invoice_note", invoiceNote);
                return this;
            }
            public CreateRequest RemoveGeneralNote(bool removeGeneralNote) 
            {
                m_params.AddOpt("remove_general_note", removeGeneralNote);
                return this;
            }
            public CreateRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            [Obsolete]
            public CreateRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateRequest AuthorizationTransactionId(string authorizationTransactionId) 
            {
                m_params.AddOpt("authorization_transaction_id", authorizationTransactionId);
                return this;
            }
            public CreateRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateRequest TokenId(string tokenId) 
            {
                m_params.AddOpt("token_id", tokenId);
                return this;
            }
            public CreateRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateRequest RetainPaymentSource(bool retainPaymentSource) 
            {
                m_params.AddOpt("retain_payment_source", retainPaymentSource);
                return this;
            }
            public CreateRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
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
            public CreateRequest BankAccountPhone(string bankAccountPhone) 
            {
                m_params.AddOpt("bank_account[phone]", bankAccountPhone);
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
            public CreateRequest BankAccountBillingAddress(JToken bankAccountBillingAddress) 
            {
                m_params.AddOpt("bank_account[billing_address]", bankAccountBillingAddress);
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
            public CreateRequest PaymentMethodAdditionalInformation(JToken paymentMethodAdditionalInformation) 
            {
                m_params.AddOpt("payment_method[additional_information]", paymentMethodAdditionalInformation);
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
            public CreateRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
                return this;
            }
            public CreateRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
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
            public CreateRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public CreateRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public CreateRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateRequest AddonUnitPrice(int index, long addonUnitPrice) 
            {
                m_params.AddOpt("addons[unit_price][" + index + "]", addonUnitPrice);
                return this;
            }
            public CreateRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
            public CreateRequest AddonUnitPriceInDecimal(int index, string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addons[unit_price_in_decimal][" + index + "]", addonUnitPriceInDecimal);
                return this;
            }
            public CreateRequest AddonDateFrom(int index, long addonDateFrom) 
            {
                m_params.AddOpt("addons[date_from][" + index + "]", addonDateFrom);
                return this;
            }
            public CreateRequest AddonDateTo(int index, long addonDateTo) 
            {
                m_params.AddOpt("addons[date_to][" + index + "]", addonDateTo);
                return this;
            }
            public CreateRequest ChargeAmount(int index, long chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CreateRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CreateRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CreateRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CreateRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CreateRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CreateRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CreateRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
            public CreateRequest NotesToRemoveEntityType(int index, ChargeBee.Models.Enums.EntityTypeEnum notesToRemoveEntityType) 
            {
                m_params.AddOpt("notes_to_remove[entity_type][" + index + "]", notesToRemoveEntityType);
                return this;
            }
            public CreateRequest NotesToRemoveEntityId(int index, string notesToRemoveEntityId) 
            {
                m_params.AddOpt("notes_to_remove[entity_id][" + index + "]", notesToRemoveEntityId);
                return this;
            }
        }
        public class CreateForChargeItemsAndChargesRequest : EntityRequest<CreateForChargeItemsAndChargesRequest> 
        {
            public CreateForChargeItemsAndChargesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForChargeItemsAndChargesRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest InvoiceNote(string invoiceNote) 
            {
                m_params.AddOpt("invoice_note", invoiceNote);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest RemoveGeneralNote(bool removeGeneralNote) 
            {
                m_params.AddOpt("remove_general_note", removeGeneralNote);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            [Obsolete]
            public CreateForChargeItemsAndChargesRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest AuthorizationTransactionId(string authorizationTransactionId) 
            {
                m_params.AddOpt("authorization_transaction_id", authorizationTransactionId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest AutoCollection(ChargeBee.Models.Enums.AutoCollectionEnum autoCollection) 
            {
                m_params.AddOpt("auto_collection", autoCollection);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest TokenId(string tokenId) 
            {
                m_params.AddOpt("token_id", tokenId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ReplacePrimaryPaymentSource(bool replacePrimaryPaymentSource) 
            {
                m_params.AddOpt("replace_primary_payment_source", replacePrimaryPaymentSource);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest RetainPaymentSource(bool retainPaymentSource) 
            {
                m_params.AddOpt("retain_payment_source", retainPaymentSource);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            [Obsolete]
            public CreateForChargeItemsAndChargesRequest CardGateway(ChargeBee.Models.Enums.GatewayEnum cardGateway) 
            {
                m_params.AddOpt("card[gateway]", cardGateway);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardGatewayAccountId(string cardGatewayAccountId) 
            {
                m_params.AddOpt("card[gateway_account_id]", cardGatewayAccountId);
                return this;
            }
            [Obsolete]
            public CreateForChargeItemsAndChargesRequest CardTmpToken(string cardTmpToken) 
            {
                m_params.AddOpt("card[tmp_token]", cardTmpToken);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountGatewayAccountId(string bankAccountGatewayAccountId) 
            {
                m_params.AddOpt("bank_account[gateway_account_id]", bankAccountGatewayAccountId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountIban(string bankAccountIban) 
            {
                m_params.AddOpt("bank_account[iban]", bankAccountIban);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountFirstName(string bankAccountFirstName) 
            {
                m_params.AddOpt("bank_account[first_name]", bankAccountFirstName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountLastName(string bankAccountLastName) 
            {
                m_params.AddOpt("bank_account[last_name]", bankAccountLastName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountCompany(string bankAccountCompany) 
            {
                m_params.AddOpt("bank_account[company]", bankAccountCompany);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountEmail(string bankAccountEmail) 
            {
                m_params.AddOpt("bank_account[email]", bankAccountEmail);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountPhone(string bankAccountPhone) 
            {
                m_params.AddOpt("bank_account[phone]", bankAccountPhone);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountBankName(string bankAccountBankName) 
            {
                m_params.AddOpt("bank_account[bank_name]", bankAccountBankName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountAccountNumber(string bankAccountAccountNumber) 
            {
                m_params.AddOpt("bank_account[account_number]", bankAccountAccountNumber);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountRoutingNumber(string bankAccountRoutingNumber) 
            {
                m_params.AddOpt("bank_account[routing_number]", bankAccountRoutingNumber);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountBankCode(string bankAccountBankCode) 
            {
                m_params.AddOpt("bank_account[bank_code]", bankAccountBankCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountAccountType(ChargeBee.Models.Enums.AccountTypeEnum bankAccountAccountType) 
            {
                m_params.AddOpt("bank_account[account_type]", bankAccountAccountType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountAccountHolderType(ChargeBee.Models.Enums.AccountHolderTypeEnum bankAccountAccountHolderType) 
            {
                m_params.AddOpt("bank_account[account_holder_type]", bankAccountAccountHolderType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountEcheckType(ChargeBee.Models.Enums.EcheckTypeEnum bankAccountEcheckType) 
            {
                m_params.AddOpt("bank_account[echeck_type]", bankAccountEcheckType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountIssuingCountry(string bankAccountIssuingCountry) 
            {
                m_params.AddOpt("bank_account[issuing_country]", bankAccountIssuingCountry);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountSwedishIdentityNumber(string bankAccountSwedishIdentityNumber) 
            {
                m_params.AddOpt("bank_account[swedish_identity_number]", bankAccountSwedishIdentityNumber);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest BankAccountBillingAddress(JToken bankAccountBillingAddress) 
            {
                m_params.AddOpt("bank_account[billing_address]", bankAccountBillingAddress);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentMethodType(ChargeBee.Models.Enums.TypeEnum paymentMethodType) 
            {
                m_params.AddOpt("payment_method[type]", paymentMethodType);
                return this;
            }
            [Obsolete]
            public CreateForChargeItemsAndChargesRequest PaymentMethodGateway(ChargeBee.Models.Enums.GatewayEnum paymentMethodGateway) 
            {
                m_params.AddOpt("payment_method[gateway]", paymentMethodGateway);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentMethodGatewayAccountId(string paymentMethodGatewayAccountId) 
            {
                m_params.AddOpt("payment_method[gateway_account_id]", paymentMethodGatewayAccountId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentMethodReferenceId(string paymentMethodReferenceId) 
            {
                m_params.AddOpt("payment_method[reference_id]", paymentMethodReferenceId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentMethodTmpToken(string paymentMethodTmpToken) 
            {
                m_params.AddOpt("payment_method[tmp_token]", paymentMethodTmpToken);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentMethodIssuingCountry(string paymentMethodIssuingCountry) 
            {
                m_params.AddOpt("payment_method[issuing_country]", paymentMethodIssuingCountry);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentMethodAdditionalInformation(JToken paymentMethodAdditionalInformation) 
            {
                m_params.AddOpt("payment_method[additional_information]", paymentMethodAdditionalInformation);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardFirstName(string cardFirstName) 
            {
                m_params.AddOpt("card[first_name]", cardFirstName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardLastName(string cardLastName) 
            {
                m_params.AddOpt("card[last_name]", cardLastName);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardNumber(string cardNumber) 
            {
                m_params.AddOpt("card[number]", cardNumber);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardExpiryMonth(int cardExpiryMonth) 
            {
                m_params.AddOpt("card[expiry_month]", cardExpiryMonth);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardExpiryYear(int cardExpiryYear) 
            {
                m_params.AddOpt("card[expiry_year]", cardExpiryYear);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardCvv(string cardCvv) 
            {
                m_params.AddOpt("card[cvv]", cardCvv);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardBillingAddr1(string cardBillingAddr1) 
            {
                m_params.AddOpt("card[billing_addr1]", cardBillingAddr1);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardBillingAddr2(string cardBillingAddr2) 
            {
                m_params.AddOpt("card[billing_addr2]", cardBillingAddr2);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardBillingCity(string cardBillingCity) 
            {
                m_params.AddOpt("card[billing_city]", cardBillingCity);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardBillingStateCode(string cardBillingStateCode) 
            {
                m_params.AddOpt("card[billing_state_code]", cardBillingStateCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardBillingState(string cardBillingState) 
            {
                m_params.AddOpt("card[billing_state]", cardBillingState);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardBillingZip(string cardBillingZip) 
            {
                m_params.AddOpt("card[billing_zip]", cardBillingZip);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardBillingCountry(string cardBillingCountry) 
            {
                m_params.AddOpt("card[billing_country]", cardBillingCountry);
                return this;
            }
            [Obsolete]
            public CreateForChargeItemsAndChargesRequest CardIpAddress(string cardIpAddress) 
            {
                m_params.AddOpt("card[ip_address]", cardIpAddress);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest CardAdditionalInformation(JToken cardAdditionalInformation) 
            {
                m_params.AddOpt("card[additional_information]", cardAdditionalInformation);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentIntentPaymentMethodType(PaymentIntent.PaymentMethodTypeEnum paymentIntentPaymentMethodType) 
            {
                m_params.AddOpt("payment_intent[payment_method_type]", paymentIntentPaymentMethodType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateForChargeItemsAndChargesRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceItemPriceId(int index, string itemPriceItemPriceId) 
            {
                m_params.AddOpt("item_prices[item_price_id][" + index + "]", itemPriceItemPriceId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceQuantity(int index, int itemPriceQuantity) 
            {
                m_params.AddOpt("item_prices[quantity][" + index + "]", itemPriceQuantity);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceQuantityInDecimal(int index, string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_prices[quantity_in_decimal][" + index + "]", itemPriceQuantityInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceUnitPrice(int index, long itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_prices[unit_price][" + index + "]", itemPriceUnitPrice);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceUnitPriceInDecimal(int index, string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_prices[unit_price_in_decimal][" + index + "]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceDateFrom(int index, long itemPriceDateFrom) 
            {
                m_params.AddOpt("item_prices[date_from][" + index + "]", itemPriceDateFrom);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemPriceDateTo(int index, long itemPriceDateTo) 
            {
                m_params.AddOpt("item_prices[date_to][" + index + "]", itemPriceDateTo);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierItemPriceId(int index, string itemTierItemPriceId) 
            {
                m_params.AddOpt("item_tiers[item_price_id][" + index + "]", itemTierItemPriceId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAmount(int index, long chargeAmount) 
            {
                m_params.AddOpt("charges[amount][" + index + "]", chargeAmount);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAmountInDecimal(int index, string chargeAmountInDecimal) 
            {
                m_params.AddOpt("charges[amount_in_decimal][" + index + "]", chargeAmountInDecimal);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeDescription(int index, string chargeDescription) 
            {
                m_params.AddOpt("charges[description][" + index + "]", chargeDescription);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeTaxable(int index, bool chargeTaxable) 
            {
                m_params.AddOpt("charges[taxable][" + index + "]", chargeTaxable);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeTaxProfileId(int index, string chargeTaxProfileId) 
            {
                m_params.AddOpt("charges[tax_profile_id][" + index + "]", chargeTaxProfileId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAvalaraTaxCode(int index, string chargeAvalaraTaxCode) 
            {
                m_params.AddOpt("charges[avalara_tax_code][" + index + "]", chargeAvalaraTaxCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeHsnCode(int index, string chargeHsnCode) 
            {
                m_params.AddOpt("charges[hsn_code][" + index + "]", chargeHsnCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeTaxjarProductCode(int index, string chargeTaxjarProductCode) 
            {
                m_params.AddOpt("charges[taxjar_product_code][" + index + "]", chargeTaxjarProductCode);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAvalaraSaleType(int index, ChargeBee.Models.Enums.AvalaraSaleTypeEnum chargeAvalaraSaleType) 
            {
                m_params.AddOpt("charges[avalara_sale_type][" + index + "]", chargeAvalaraSaleType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAvalaraTransactionType(int index, int chargeAvalaraTransactionType) 
            {
                m_params.AddOpt("charges[avalara_transaction_type][" + index + "]", chargeAvalaraTransactionType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeAvalaraServiceType(int index, int chargeAvalaraServiceType) 
            {
                m_params.AddOpt("charges[avalara_service_type][" + index + "]", chargeAvalaraServiceType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeDateFrom(int index, long chargeDateFrom) 
            {
                m_params.AddOpt("charges[date_from][" + index + "]", chargeDateFrom);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest ChargeDateTo(int index, long chargeDateTo) 
            {
                m_params.AddOpt("charges[date_to][" + index + "]", chargeDateTo);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest NotesToRemoveEntityType(int index, ChargeBee.Models.Enums.EntityTypeEnum notesToRemoveEntityType) 
            {
                m_params.AddOpt("notes_to_remove[entity_type][" + index + "]", notesToRemoveEntityType);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest NotesToRemoveEntityId(int index, string notesToRemoveEntityId) 
            {
                m_params.AddOpt("notes_to_remove[entity_id][" + index + "]", notesToRemoveEntityId);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest DiscountPercentage(int index, double discountPercentage) 
            {
                m_params.AddOpt("discounts[percentage][" + index + "]", discountPercentage);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.AddOpt("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest DiscountApplyOn(int index, ChargeBee.Models.Enums.ApplyOnEnum discountApplyOn) 
            {
                m_params.Add("discounts[apply_on][" + index + "]", discountApplyOn);
                return this;
            }
            public CreateForChargeItemsAndChargesRequest DiscountItemPriceId(int index, string discountItemPriceId) 
            {
                m_params.AddOpt("discounts[item_price_id][" + index + "]", discountItemPriceId);
                return this;
            }
        }
        public class ChargeRequest : EntityRequest<ChargeRequest> 
        {
            public ChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public ChargeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public ChargeRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public ChargeRequest Amount(long amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public ChargeRequest AmountInDecimal(string amountInDecimal) 
            {
                m_params.AddOpt("amount_in_decimal", amountInDecimal);
                return this;
            }
            public ChargeRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public ChargeRequest DateFrom(long dateFrom) 
            {
                m_params.AddOpt("date_from", dateFrom);
                return this;
            }
            public ChargeRequest DateTo(long dateTo) 
            {
                m_params.AddOpt("date_to", dateTo);
                return this;
            }
            public ChargeRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            [Obsolete]
            public ChargeRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public ChargeRequest AvalaraSaleType(ChargeBee.Models.Enums.AvalaraSaleTypeEnum avalaraSaleType) 
            {
                m_params.AddOpt("avalara_sale_type", avalaraSaleType);
                return this;
            }
            public ChargeRequest AvalaraTransactionType(int avalaraTransactionType) 
            {
                m_params.AddOpt("avalara_transaction_type", avalaraTransactionType);
                return this;
            }
            public ChargeRequest AvalaraServiceType(int avalaraServiceType) 
            {
                m_params.AddOpt("avalara_service_type", avalaraServiceType);
                return this;
            }
            public ChargeRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public ChargeRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public ChargeRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
        }
        public class ChargeAddonRequest : EntityRequest<ChargeAddonRequest> 
        {
            public ChargeAddonRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ChargeAddonRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public ChargeAddonRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public ChargeAddonRequest AddonId(string addonId) 
            {
                m_params.Add("addon_id", addonId);
                return this;
            }
            public ChargeAddonRequest AddonQuantity(int addonQuantity) 
            {
                m_params.AddOpt("addon_quantity", addonQuantity);
                return this;
            }
            public ChargeAddonRequest AddonUnitPrice(long addonUnitPrice) 
            {
                m_params.AddOpt("addon_unit_price", addonUnitPrice);
                return this;
            }
            public ChargeAddonRequest AddonQuantityInDecimal(string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addon_quantity_in_decimal", addonQuantityInDecimal);
                return this;
            }
            public ChargeAddonRequest AddonUnitPriceInDecimal(string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addon_unit_price_in_decimal", addonUnitPriceInDecimal);
                return this;
            }
            public ChargeAddonRequest DateFrom(long dateFrom) 
            {
                m_params.AddOpt("date_from", dateFrom);
                return this;
            }
            public ChargeAddonRequest DateTo(long dateTo) 
            {
                m_params.AddOpt("date_to", dateTo);
                return this;
            }
            public ChargeAddonRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            [Obsolete]
            public ChargeAddonRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public ChargeAddonRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public ChargeAddonRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public ChargeAddonRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
        }
        public class CreateForChargeItemRequest : EntityRequest<CreateForChargeItemRequest> 
        {
            public CreateForChargeItemRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForChargeItemRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public CreateForChargeItemRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public CreateForChargeItemRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public CreateForChargeItemRequest Coupon(string coupon) 
            {
                m_params.AddOpt("coupon", coupon);
                return this;
            }
            public CreateForChargeItemRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateForChargeItemRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CreateForChargeItemRequest ItemPriceItemPriceId(string itemPriceItemPriceId) 
            {
                m_params.Add("item_price[item_price_id]", itemPriceItemPriceId);
                return this;
            }
            public CreateForChargeItemRequest ItemPriceQuantity(int itemPriceQuantity) 
            {
                m_params.AddOpt("item_price[quantity]", itemPriceQuantity);
                return this;
            }
            public CreateForChargeItemRequest ItemPriceQuantityInDecimal(string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_price[quantity_in_decimal]", itemPriceQuantityInDecimal);
                return this;
            }
            public CreateForChargeItemRequest ItemPriceUnitPrice(long itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_price[unit_price]", itemPriceUnitPrice);
                return this;
            }
            public CreateForChargeItemRequest ItemPriceUnitPriceInDecimal(string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_price[unit_price_in_decimal]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public CreateForChargeItemRequest ItemPriceDateFrom(long itemPriceDateFrom) 
            {
                m_params.AddOpt("item_price[date_from]", itemPriceDateFrom);
                return this;
            }
            public CreateForChargeItemRequest ItemPriceDateTo(long itemPriceDateTo) 
            {
                m_params.AddOpt("item_price[date_to]", itemPriceDateTo);
                return this;
            }
            public CreateForChargeItemRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public CreateForChargeItemRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public CreateForChargeItemRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public CreateForChargeItemRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public CreateForChargeItemRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public CreateForChargeItemRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class StopDunningRequest : EntityRequest<StopDunningRequest> 
        {
            public StopDunningRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StopDunningRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        public class ImportInvoiceRequest : EntityRequest<ImportInvoiceRequest> 
        {
            public ImportInvoiceRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportInvoiceRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
            public ImportInvoiceRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public ImportInvoiceRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public ImportInvoiceRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public ImportInvoiceRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public ImportInvoiceRequest PriceType(ChargeBee.Models.Enums.PriceTypeEnum priceType) 
            {
                m_params.AddOpt("price_type", priceType);
                return this;
            }
            public ImportInvoiceRequest TaxOverrideReason(ChargeBee.Models.Enums.TaxOverrideReasonEnum taxOverrideReason) 
            {
                m_params.AddOpt("tax_override_reason", taxOverrideReason);
                return this;
            }
            public ImportInvoiceRequest VatNumber(string vatNumber) 
            {
                m_params.AddOpt("vat_number", vatNumber);
                return this;
            }
            public ImportInvoiceRequest VatNumberPrefix(string vatNumberPrefix) 
            {
                m_params.AddOpt("vat_number_prefix", vatNumberPrefix);
                return this;
            }
            public ImportInvoiceRequest Date(long date) 
            {
                m_params.Add("date", date);
                return this;
            }
            public ImportInvoiceRequest Total(long total) 
            {
                m_params.Add("total", total);
                return this;
            }
            public ImportInvoiceRequest RoundOff(long roundOff) 
            {
                m_params.AddOpt("round_off", roundOff);
                return this;
            }
            public ImportInvoiceRequest Status(Invoice.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public ImportInvoiceRequest VoidedAt(long voidedAt) 
            {
                m_params.AddOpt("voided_at", voidedAt);
                return this;
            }
            public ImportInvoiceRequest VoidReasonCode(string voidReasonCode) 
            {
                m_params.AddOpt("void_reason_code", voidReasonCode);
                return this;
            }
            public ImportInvoiceRequest IsWrittenOff(bool isWrittenOff) 
            {
                m_params.AddOpt("is_written_off", isWrittenOff);
                return this;
            }
            public ImportInvoiceRequest WriteOffAmount(long writeOffAmount) 
            {
                m_params.AddOpt("write_off_amount", writeOffAmount);
                return this;
            }
            public ImportInvoiceRequest WriteOffDate(long writeOffDate) 
            {
                m_params.AddOpt("write_off_date", writeOffDate);
                return this;
            }
            public ImportInvoiceRequest DueDate(long dueDate) 
            {
                m_params.AddOpt("due_date", dueDate);
                return this;
            }
            public ImportInvoiceRequest NetTermDays(int netTermDays) 
            {
                m_params.AddOpt("net_term_days", netTermDays);
                return this;
            }
            public ImportInvoiceRequest HasAdvanceCharges(bool hasAdvanceCharges) 
            {
                m_params.AddOpt("has_advance_charges", hasAdvanceCharges);
                return this;
            }
            public ImportInvoiceRequest UseForProration(bool useForProration) 
            {
                m_params.AddOpt("use_for_proration", useForProration);
                return this;
            }
            public ImportInvoiceRequest CreditNoteId(string creditNoteId) 
            {
                m_params.AddOpt("credit_note[id]", creditNoteId);
                return this;
            }
            public ImportInvoiceRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public ImportInvoiceRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public ImportInvoiceRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public ImportInvoiceRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public ImportInvoiceRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public ImportInvoiceRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public ImportInvoiceRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public ImportInvoiceRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public ImportInvoiceRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public ImportInvoiceRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public ImportInvoiceRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public ImportInvoiceRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public ImportInvoiceRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public ImportInvoiceRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public ImportInvoiceRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public ImportInvoiceRequest LineItemId(int index, string lineItemId) 
            {
                m_params.AddOpt("line_items[id][" + index + "]", lineItemId);
                return this;
            }
            public ImportInvoiceRequest LineItemDateFrom(int index, long lineItemDateFrom) 
            {
                m_params.AddOpt("line_items[date_from][" + index + "]", lineItemDateFrom);
                return this;
            }
            public ImportInvoiceRequest LineItemDateTo(int index, long lineItemDateTo) 
            {
                m_params.AddOpt("line_items[date_to][" + index + "]", lineItemDateTo);
                return this;
            }
            public ImportInvoiceRequest LineItemSubscriptionId(int index, string lineItemSubscriptionId) 
            {
                m_params.AddOpt("line_items[subscription_id][" + index + "]", lineItemSubscriptionId);
                return this;
            }
            public ImportInvoiceRequest LineItemDescription(int index, string lineItemDescription) 
            {
                m_params.Add("line_items[description][" + index + "]", lineItemDescription);
                return this;
            }
            public ImportInvoiceRequest LineItemUnitAmount(int index, long lineItemUnitAmount) 
            {
                m_params.AddOpt("line_items[unit_amount][" + index + "]", lineItemUnitAmount);
                return this;
            }
            public ImportInvoiceRequest LineItemQuantity(int index, int lineItemQuantity) 
            {
                m_params.AddOpt("line_items[quantity][" + index + "]", lineItemQuantity);
                return this;
            }
            public ImportInvoiceRequest LineItemAmount(int index, long lineItemAmount) 
            {
                m_params.AddOpt("line_items[amount][" + index + "]", lineItemAmount);
                return this;
            }
            public ImportInvoiceRequest LineItemUnitAmountInDecimal(int index, string lineItemUnitAmountInDecimal) 
            {
                m_params.AddOpt("line_items[unit_amount_in_decimal][" + index + "]", lineItemUnitAmountInDecimal);
                return this;
            }
            public ImportInvoiceRequest LineItemQuantityInDecimal(int index, string lineItemQuantityInDecimal) 
            {
                m_params.AddOpt("line_items[quantity_in_decimal][" + index + "]", lineItemQuantityInDecimal);
                return this;
            }
            public ImportInvoiceRequest LineItemAmountInDecimal(int index, string lineItemAmountInDecimal) 
            {
                m_params.AddOpt("line_items[amount_in_decimal][" + index + "]", lineItemAmountInDecimal);
                return this;
            }
            public ImportInvoiceRequest LineItemEntityType(int index, InvoiceLineItem.EntityTypeEnum lineItemEntityType) 
            {
                m_params.AddOpt("line_items[entity_type][" + index + "]", lineItemEntityType);
                return this;
            }
            public ImportInvoiceRequest LineItemEntityId(int index, string lineItemEntityId) 
            {
                m_params.AddOpt("line_items[entity_id][" + index + "]", lineItemEntityId);
                return this;
            }
            public ImportInvoiceRequest LineItemItemLevelDiscount1EntityId(int index, string lineItemItemLevelDiscount1EntityId) 
            {
                m_params.AddOpt("line_items[item_level_discount1_entity_id][" + index + "]", lineItemItemLevelDiscount1EntityId);
                return this;
            }
            public ImportInvoiceRequest LineItemItemLevelDiscount1Amount(int index, long lineItemItemLevelDiscount1Amount) 
            {
                m_params.AddOpt("line_items[item_level_discount1_amount][" + index + "]", lineItemItemLevelDiscount1Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemItemLevelDiscount2EntityId(int index, string lineItemItemLevelDiscount2EntityId) 
            {
                m_params.AddOpt("line_items[item_level_discount2_entity_id][" + index + "]", lineItemItemLevelDiscount2EntityId);
                return this;
            }
            public ImportInvoiceRequest LineItemItemLevelDiscount2Amount(int index, long lineItemItemLevelDiscount2Amount) 
            {
                m_params.AddOpt("line_items[item_level_discount2_amount][" + index + "]", lineItemItemLevelDiscount2Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax1Name(int index, string lineItemTax1Name) 
            {
                m_params.AddOpt("line_items[tax1_name][" + index + "]", lineItemTax1Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax1Amount(int index, long lineItemTax1Amount) 
            {
                m_params.AddOpt("line_items[tax1_amount][" + index + "]", lineItemTax1Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax2Name(int index, string lineItemTax2Name) 
            {
                m_params.AddOpt("line_items[tax2_name][" + index + "]", lineItemTax2Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax2Amount(int index, long lineItemTax2Amount) 
            {
                m_params.AddOpt("line_items[tax2_amount][" + index + "]", lineItemTax2Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax3Name(int index, string lineItemTax3Name) 
            {
                m_params.AddOpt("line_items[tax3_name][" + index + "]", lineItemTax3Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax3Amount(int index, long lineItemTax3Amount) 
            {
                m_params.AddOpt("line_items[tax3_amount][" + index + "]", lineItemTax3Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax4Name(int index, string lineItemTax4Name) 
            {
                m_params.AddOpt("line_items[tax4_name][" + index + "]", lineItemTax4Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax4Amount(int index, long lineItemTax4Amount) 
            {
                m_params.AddOpt("line_items[tax4_amount][" + index + "]", lineItemTax4Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax5Name(int index, string lineItemTax5Name) 
            {
                m_params.AddOpt("line_items[tax5_name][" + index + "]", lineItemTax5Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax5Amount(int index, long lineItemTax5Amount) 
            {
                m_params.AddOpt("line_items[tax5_amount][" + index + "]", lineItemTax5Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax6Name(int index, string lineItemTax6Name) 
            {
                m_params.AddOpt("line_items[tax6_name][" + index + "]", lineItemTax6Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax6Amount(int index, long lineItemTax6Amount) 
            {
                m_params.AddOpt("line_items[tax6_amount][" + index + "]", lineItemTax6Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax7Name(int index, string lineItemTax7Name) 
            {
                m_params.AddOpt("line_items[tax7_name][" + index + "]", lineItemTax7Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax7Amount(int index, long lineItemTax7Amount) 
            {
                m_params.AddOpt("line_items[tax7_amount][" + index + "]", lineItemTax7Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax8Name(int index, string lineItemTax8Name) 
            {
                m_params.AddOpt("line_items[tax8_name][" + index + "]", lineItemTax8Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax8Amount(int index, long lineItemTax8Amount) 
            {
                m_params.AddOpt("line_items[tax8_amount][" + index + "]", lineItemTax8Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax9Name(int index, string lineItemTax9Name) 
            {
                m_params.AddOpt("line_items[tax9_name][" + index + "]", lineItemTax9Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax9Amount(int index, long lineItemTax9Amount) 
            {
                m_params.AddOpt("line_items[tax9_amount][" + index + "]", lineItemTax9Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTax10Name(int index, string lineItemTax10Name) 
            {
                m_params.AddOpt("line_items[tax10_name][" + index + "]", lineItemTax10Name);
                return this;
            }
            public ImportInvoiceRequest LineItemTax10Amount(int index, long lineItemTax10Amount) 
            {
                m_params.AddOpt("line_items[tax10_amount][" + index + "]", lineItemTax10Amount);
                return this;
            }
            public ImportInvoiceRequest LineItemTierLineItemId(int index, string lineItemTierLineItemId) 
            {
                m_params.Add("line_item_tiers[line_item_id][" + index + "]", lineItemTierLineItemId);
                return this;
            }
            public ImportInvoiceRequest LineItemTierStartingUnit(int index, int lineItemTierStartingUnit) 
            {
                m_params.AddOpt("line_item_tiers[starting_unit][" + index + "]", lineItemTierStartingUnit);
                return this;
            }
            public ImportInvoiceRequest LineItemTierEndingUnit(int index, int lineItemTierEndingUnit) 
            {
                m_params.AddOpt("line_item_tiers[ending_unit][" + index + "]", lineItemTierEndingUnit);
                return this;
            }
            public ImportInvoiceRequest LineItemTierQuantityUsed(int index, int lineItemTierQuantityUsed) 
            {
                m_params.AddOpt("line_item_tiers[quantity_used][" + index + "]", lineItemTierQuantityUsed);
                return this;
            }
            public ImportInvoiceRequest LineItemTierUnitAmount(int index, long lineItemTierUnitAmount) 
            {
                m_params.AddOpt("line_item_tiers[unit_amount][" + index + "]", lineItemTierUnitAmount);
                return this;
            }
            public ImportInvoiceRequest LineItemTierStartingUnitInDecimal(int index, string lineItemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[starting_unit_in_decimal][" + index + "]", lineItemTierStartingUnitInDecimal);
                return this;
            }
            public ImportInvoiceRequest LineItemTierEndingUnitInDecimal(int index, string lineItemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[ending_unit_in_decimal][" + index + "]", lineItemTierEndingUnitInDecimal);
                return this;
            }
            public ImportInvoiceRequest LineItemTierQuantityUsedInDecimal(int index, string lineItemTierQuantityUsedInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[quantity_used_in_decimal][" + index + "]", lineItemTierQuantityUsedInDecimal);
                return this;
            }
            public ImportInvoiceRequest LineItemTierUnitAmountInDecimal(int index, string lineItemTierUnitAmountInDecimal) 
            {
                m_params.AddOpt("line_item_tiers[unit_amount_in_decimal][" + index + "]", lineItemTierUnitAmountInDecimal);
                return this;
            }
            public ImportInvoiceRequest DiscountLineItemId(int index, string discountLineItemId) 
            {
                m_params.AddOpt("discounts[line_item_id][" + index + "]", discountLineItemId);
                return this;
            }
            public ImportInvoiceRequest DiscountEntityType(int index, InvoiceDiscount.EntityTypeEnum discountEntityType) 
            {
                m_params.Add("discounts[entity_type][" + index + "]", discountEntityType);
                return this;
            }
            public ImportInvoiceRequest DiscountEntityId(int index, string discountEntityId) 
            {
                m_params.AddOpt("discounts[entity_id][" + index + "]", discountEntityId);
                return this;
            }
            public ImportInvoiceRequest DiscountDescription(int index, string discountDescription) 
            {
                m_params.AddOpt("discounts[description][" + index + "]", discountDescription);
                return this;
            }
            public ImportInvoiceRequest DiscountAmount(int index, long discountAmount) 
            {
                m_params.Add("discounts[amount][" + index + "]", discountAmount);
                return this;
            }
            public ImportInvoiceRequest TaxName(int index, string taxName) 
            {
                m_params.Add("taxes[name][" + index + "]", taxName);
                return this;
            }
            public ImportInvoiceRequest TaxRate(int index, double taxRate) 
            {
                m_params.Add("taxes[rate][" + index + "]", taxRate);
                return this;
            }
            public ImportInvoiceRequest TaxAmount(int index, long taxAmount) 
            {
                m_params.AddOpt("taxes[amount][" + index + "]", taxAmount);
                return this;
            }
            public ImportInvoiceRequest TaxDescription(int index, string taxDescription) 
            {
                m_params.AddOpt("taxes[description][" + index + "]", taxDescription);
                return this;
            }
            public ImportInvoiceRequest TaxJurisType(int index, ChargeBee.Models.Enums.TaxJurisTypeEnum taxJurisType) 
            {
                m_params.AddOpt("taxes[juris_type][" + index + "]", taxJurisType);
                return this;
            }
            public ImportInvoiceRequest TaxJurisName(int index, string taxJurisName) 
            {
                m_params.AddOpt("taxes[juris_name][" + index + "]", taxJurisName);
                return this;
            }
            public ImportInvoiceRequest TaxJurisCode(int index, string taxJurisCode) 
            {
                m_params.AddOpt("taxes[juris_code][" + index + "]", taxJurisCode);
                return this;
            }
            public ImportInvoiceRequest PaymentAmount(int index, long paymentAmount) 
            {
                m_params.Add("payments[amount][" + index + "]", paymentAmount);
                return this;
            }
            public ImportInvoiceRequest PaymentPaymentMethod(int index, ChargeBee.Models.Enums.PaymentMethodEnum paymentPaymentMethod) 
            {
                m_params.Add("payments[payment_method][" + index + "]", paymentPaymentMethod);
                return this;
            }
            public ImportInvoiceRequest PaymentDate(int index, long paymentDate) 
            {
                m_params.AddOpt("payments[date][" + index + "]", paymentDate);
                return this;
            }
            public ImportInvoiceRequest PaymentReferenceNumber(int index, string paymentReferenceNumber) 
            {
                m_params.AddOpt("payments[reference_number][" + index + "]", paymentReferenceNumber);
                return this;
            }
            public ImportInvoiceRequest NoteEntityType(int index, InvoiceNote.EntityTypeEnum noteEntityType) 
            {
                m_params.AddOpt("notes[entity_type][" + index + "]", noteEntityType);
                return this;
            }
            public ImportInvoiceRequest NoteEntityId(int index, string noteEntityId) 
            {
                m_params.AddOpt("notes[entity_id][" + index + "]", noteEntityId);
                return this;
            }
            public ImportInvoiceRequest NoteNote(int index, string noteNote) 
            {
                m_params.AddOpt("notes[note][" + index + "]", noteNote);
                return this;
            }
        }
        public class ApplyPaymentsRequest : EntityRequest<ApplyPaymentsRequest> 
        {
            public ApplyPaymentsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ApplyPaymentsRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public ApplyPaymentsRequest TransactionId(int index, string transactionId) 
            {
                m_params.AddOpt("transactions[id][" + index + "]", transactionId);
                return this;
            }
        }
        public class DeleteLineItemsRequest : EntityRequest<DeleteLineItemsRequest> 
        {
            public DeleteLineItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteLineItemsRequest LineItemId(int index, string lineItemId) 
            {
                m_params.AddOpt("line_items[id][" + index + "]", lineItemId);
                return this;
            }
        }
        public class ApplyCreditsRequest : EntityRequest<ApplyCreditsRequest> 
        {
            public ApplyCreditsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ApplyCreditsRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public ApplyCreditsRequest CreditNoteId(int index, string creditNoteId) 
            {
                m_params.AddOpt("credit_notes[id][" + index + "]", creditNoteId);
                return this;
            }
        }
        public class InvoiceListRequest : ListRequestBase<InvoiceListRequest> 
        {
            public InvoiceListRequest(string url) 
                    : base(url)
            {
            }

            [Obsolete]
            public InvoiceListRequest PaidOnAfter(long paidOnAfter) 
            {
                m_params.AddOpt("paid_on_after", paidOnAfter);
                return this;
            }
            public InvoiceListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public StringFilter<InvoiceListRequest> Id() 
            {
                return new StringFilter<InvoiceListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<InvoiceListRequest> SubscriptionId() 
            {
                return new StringFilter<InvoiceListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public StringFilter<InvoiceListRequest> CustomerId() 
            {
                return new StringFilter<InvoiceListRequest>("customer_id", this).SupportsMultiOperators(true);        
            }
            public BooleanFilter<InvoiceListRequest> Recurring() 
            {
                return new BooleanFilter<InvoiceListRequest>("recurring", this);        
            }
            public EnumFilter<Invoice.StatusEnum, InvoiceListRequest> Status() 
            {
                return new EnumFilter<Invoice.StatusEnum, InvoiceListRequest>("status", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, InvoiceListRequest> PriceType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, InvoiceListRequest>("price_type", this);        
            }
            public TimestampFilter<InvoiceListRequest> Date() 
            {
                return new TimestampFilter<InvoiceListRequest>("date", this);        
            }
            public TimestampFilter<InvoiceListRequest> PaidAt() 
            {
                return new TimestampFilter<InvoiceListRequest>("paid_at", this);        
            }
            public NumberFilter<long, InvoiceListRequest> Total() 
            {
                return new NumberFilter<long, InvoiceListRequest>("total", this);        
            }
            public NumberFilter<long, InvoiceListRequest> AmountPaid() 
            {
                return new NumberFilter<long, InvoiceListRequest>("amount_paid", this);        
            }
            public NumberFilter<long, InvoiceListRequest> AmountAdjusted() 
            {
                return new NumberFilter<long, InvoiceListRequest>("amount_adjusted", this);        
            }
            public NumberFilter<long, InvoiceListRequest> CreditsApplied() 
            {
                return new NumberFilter<long, InvoiceListRequest>("credits_applied", this);        
            }
            public NumberFilter<long, InvoiceListRequest> AmountDue() 
            {
                return new NumberFilter<long, InvoiceListRequest>("amount_due", this);        
            }
            public EnumFilter<Invoice.DunningStatusEnum, InvoiceListRequest> DunningStatus() 
            {
                return new EnumFilter<Invoice.DunningStatusEnum, InvoiceListRequest>("dunning_status", this).SupportsPresenceOperator(true);        
            }
            public StringFilter<InvoiceListRequest> PaymentOwner() 
            {
                return new StringFilter<InvoiceListRequest>("payment_owner", this).SupportsMultiOperators(true);        
            }
            public TimestampFilter<InvoiceListRequest> UpdatedAt() 
            {
                return new TimestampFilter<InvoiceListRequest>("updated_at", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, InvoiceListRequest> Channel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, InvoiceListRequest>("channel", this);        
            }
            public TimestampFilter<InvoiceListRequest> VoidedAt() 
            {
                return new TimestampFilter<InvoiceListRequest>("voided_at", this);        
            }
            public StringFilter<InvoiceListRequest> VoidReasonCode() 
            {
                return new StringFilter<InvoiceListRequest>("void_reason_code", this).SupportsMultiOperators(true);        
            }
            public InvoiceListRequest SortByDate(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","date");
                return this;
            }
            public InvoiceListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
            public EnumFilter<InvoiceEinvoice.StatusEnum, InvoiceListRequest> EinvoiceStatus() 
            {
                return new EnumFilter<InvoiceEinvoice.StatusEnum, InvoiceListRequest>("einvoice[status]", this);        
            }

        }
        public class PdfRequest : EntityRequest<PdfRequest> 
        {
            public PdfRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PdfRequest DispositionType(ChargeBee.Models.Enums.DispositionTypeEnum dispositionType) 
            {
                m_params.AddOpt("disposition_type", dispositionType);
                return this;
            }
        }
        public class AddChargeRequest : EntityRequest<AddChargeRequest> 
        {
            public AddChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddChargeRequest Amount(long amount) 
            {
                m_params.Add("amount", amount);
                return this;
            }
            public AddChargeRequest Description(string description) 
            {
                m_params.Add("description", description);
                return this;
            }
            public AddChargeRequest AvalaraSaleType(ChargeBee.Models.Enums.AvalaraSaleTypeEnum avalaraSaleType) 
            {
                m_params.AddOpt("avalara_sale_type", avalaraSaleType);
                return this;
            }
            public AddChargeRequest AvalaraTransactionType(int avalaraTransactionType) 
            {
                m_params.AddOpt("avalara_transaction_type", avalaraTransactionType);
                return this;
            }
            public AddChargeRequest AvalaraServiceType(int avalaraServiceType) 
            {
                m_params.AddOpt("avalara_service_type", avalaraServiceType);
                return this;
            }
            public AddChargeRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public AddChargeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public AddChargeRequest LineItemDateFrom(long lineItemDateFrom) 
            {
                m_params.AddOpt("line_item[date_from]", lineItemDateFrom);
                return this;
            }
            public AddChargeRequest LineItemDateTo(long lineItemDateTo) 
            {
                m_params.AddOpt("line_item[date_to]", lineItemDateTo);
                return this;
            }
        }
        public class AddAddonChargeRequest : EntityRequest<AddAddonChargeRequest> 
        {
            public AddAddonChargeRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddAddonChargeRequest AddonId(string addonId) 
            {
                m_params.Add("addon_id", addonId);
                return this;
            }
            public AddAddonChargeRequest AddonQuantity(int addonQuantity) 
            {
                m_params.AddOpt("addon_quantity", addonQuantity);
                return this;
            }
            public AddAddonChargeRequest AddonUnitPrice(long addonUnitPrice) 
            {
                m_params.AddOpt("addon_unit_price", addonUnitPrice);
                return this;
            }
            public AddAddonChargeRequest AddonQuantityInDecimal(string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addon_quantity_in_decimal", addonQuantityInDecimal);
                return this;
            }
            public AddAddonChargeRequest AddonUnitPriceInDecimal(string addonUnitPriceInDecimal) 
            {
                m_params.AddOpt("addon_unit_price_in_decimal", addonUnitPriceInDecimal);
                return this;
            }
            public AddAddonChargeRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public AddAddonChargeRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public AddAddonChargeRequest LineItemDateFrom(long lineItemDateFrom) 
            {
                m_params.AddOpt("line_item[date_from]", lineItemDateFrom);
                return this;
            }
            public AddAddonChargeRequest LineItemDateTo(long lineItemDateTo) 
            {
                m_params.AddOpt("line_item[date_to]", lineItemDateTo);
                return this;
            }
        }
        public class AddChargeItemRequest : EntityRequest<AddChargeItemRequest> 
        {
            public AddChargeItemRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddChargeItemRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public AddChargeItemRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public AddChargeItemRequest ItemPriceItemPriceId(string itemPriceItemPriceId) 
            {
                m_params.Add("item_price[item_price_id]", itemPriceItemPriceId);
                return this;
            }
            public AddChargeItemRequest ItemPriceQuantity(int itemPriceQuantity) 
            {
                m_params.AddOpt("item_price[quantity]", itemPriceQuantity);
                return this;
            }
            public AddChargeItemRequest ItemPriceQuantityInDecimal(string itemPriceQuantityInDecimal) 
            {
                m_params.AddOpt("item_price[quantity_in_decimal]", itemPriceQuantityInDecimal);
                return this;
            }
            public AddChargeItemRequest ItemPriceUnitPrice(long itemPriceUnitPrice) 
            {
                m_params.AddOpt("item_price[unit_price]", itemPriceUnitPrice);
                return this;
            }
            public AddChargeItemRequest ItemPriceUnitPriceInDecimal(string itemPriceUnitPriceInDecimal) 
            {
                m_params.AddOpt("item_price[unit_price_in_decimal]", itemPriceUnitPriceInDecimal);
                return this;
            }
            public AddChargeItemRequest ItemPriceDateFrom(long itemPriceDateFrom) 
            {
                m_params.AddOpt("item_price[date_from]", itemPriceDateFrom);
                return this;
            }
            public AddChargeItemRequest ItemPriceDateTo(long itemPriceDateTo) 
            {
                m_params.AddOpt("item_price[date_to]", itemPriceDateTo);
                return this;
            }
            public AddChargeItemRequest ItemTierStartingUnit(int index, int itemTierStartingUnit) 
            {
                m_params.AddOpt("item_tiers[starting_unit][" + index + "]", itemTierStartingUnit);
                return this;
            }
            public AddChargeItemRequest ItemTierEndingUnit(int index, int itemTierEndingUnit) 
            {
                m_params.AddOpt("item_tiers[ending_unit][" + index + "]", itemTierEndingUnit);
                return this;
            }
            public AddChargeItemRequest ItemTierPrice(int index, long itemTierPrice) 
            {
                m_params.AddOpt("item_tiers[price][" + index + "]", itemTierPrice);
                return this;
            }
            public AddChargeItemRequest ItemTierStartingUnitInDecimal(int index, string itemTierStartingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[starting_unit_in_decimal][" + index + "]", itemTierStartingUnitInDecimal);
                return this;
            }
            public AddChargeItemRequest ItemTierEndingUnitInDecimal(int index, string itemTierEndingUnitInDecimal) 
            {
                m_params.AddOpt("item_tiers[ending_unit_in_decimal][" + index + "]", itemTierEndingUnitInDecimal);
                return this;
            }
            public AddChargeItemRequest ItemTierPriceInDecimal(int index, string itemTierPriceInDecimal) 
            {
                m_params.AddOpt("item_tiers[price_in_decimal][" + index + "]", itemTierPriceInDecimal);
                return this;
            }
        }
        public class CloseRequest : EntityRequest<CloseRequest> 
        {
            public CloseRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CloseRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public CloseRequest InvoiceNote(string invoiceNote) 
            {
                m_params.AddOpt("invoice_note", invoiceNote);
                return this;
            }
            public CloseRequest RemoveGeneralNote(bool removeGeneralNote) 
            {
                m_params.AddOpt("remove_general_note", removeGeneralNote);
                return this;
            }
            public CloseRequest InvoiceDate(long invoiceDate) 
            {
                m_params.AddOpt("invoice_date", invoiceDate);
                return this;
            }
            public CloseRequest NotesToRemoveEntityType(int index, ChargeBee.Models.Enums.EntityTypeEnum notesToRemoveEntityType) 
            {
                m_params.AddOpt("notes_to_remove[entity_type][" + index + "]", notesToRemoveEntityType);
                return this;
            }
            public CloseRequest NotesToRemoveEntityId(int index, string notesToRemoveEntityId) 
            {
                m_params.AddOpt("notes_to_remove[entity_id][" + index + "]", notesToRemoveEntityId);
                return this;
            }
        }
        public class CollectPaymentRequest : EntityRequest<CollectPaymentRequest> 
        {
            public CollectPaymentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CollectPaymentRequest Amount(long amount) 
            {
                m_params.AddOpt("amount", amount);
                return this;
            }
            public CollectPaymentRequest AuthorizationTransactionId(string authorizationTransactionId) 
            {
                m_params.AddOpt("authorization_transaction_id", authorizationTransactionId);
                return this;
            }
            public CollectPaymentRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CollectPaymentRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        public class RecordPaymentRequest : EntityRequest<RecordPaymentRequest> 
        {
            public RecordPaymentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordPaymentRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public RecordPaymentRequest TransactionAmount(long transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public RecordPaymentRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.Add("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public RecordPaymentRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
            public RecordPaymentRequest TransactionIdAtGateway(string transactionIdAtGateway) 
            {
                m_params.AddOpt("transaction[id_at_gateway]", transactionIdAtGateway);
                return this;
            }
            public RecordPaymentRequest TransactionStatus(Transaction.StatusEnum transactionStatus) 
            {
                m_params.AddOpt("transaction[status]", transactionStatus);
                return this;
            }
            public RecordPaymentRequest TransactionDate(long transactionDate) 
            {
                m_params.AddOpt("transaction[date]", transactionDate);
                return this;
            }
            public RecordPaymentRequest TransactionErrorCode(string transactionErrorCode) 
            {
                m_params.AddOpt("transaction[error_code]", transactionErrorCode);
                return this;
            }
            public RecordPaymentRequest TransactionErrorText(string transactionErrorText) 
            {
                m_params.AddOpt("transaction[error_text]", transactionErrorText);
                return this;
            }
        }
        public class RecordTaxWithheldRequest : EntityRequest<RecordTaxWithheldRequest> 
        {
            public RecordTaxWithheldRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordTaxWithheldRequest TaxWithheldAmount(long taxWithheldAmount) 
            {
                m_params.Add("tax_withheld[amount]", taxWithheldAmount);
                return this;
            }
            public RecordTaxWithheldRequest TaxWithheldReferenceNumber(string taxWithheldReferenceNumber) 
            {
                m_params.AddOpt("tax_withheld[reference_number]", taxWithheldReferenceNumber);
                return this;
            }
            public RecordTaxWithheldRequest TaxWithheldDate(long taxWithheldDate) 
            {
                m_params.AddOpt("tax_withheld[date]", taxWithheldDate);
                return this;
            }
            public RecordTaxWithheldRequest TaxWithheldDescription(string taxWithheldDescription) 
            {
                m_params.AddOpt("tax_withheld[description]", taxWithheldDescription);
                return this;
            }
        }
        public class RemoveTaxWithheldRequest : EntityRequest<RemoveTaxWithheldRequest> 
        {
            public RemoveTaxWithheldRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemoveTaxWithheldRequest TaxWithheldId(string taxWithheldId) 
            {
                m_params.Add("tax_withheld[id]", taxWithheldId);
                return this;
            }
        }
        public class RefundRequest : EntityRequest<RefundRequest> 
        {
            public RefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RefundRequest RefundAmount(long refundAmount) 
            {
                m_params.AddOpt("refund_amount", refundAmount);
                return this;
            }
            public RefundRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public RefundRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public RefundRequest CreditNoteReasonCode(CreditNote.ReasonCodeEnum creditNoteReasonCode) 
            {
                m_params.AddOpt("credit_note[reason_code]", creditNoteReasonCode);
                return this;
            }
            public RefundRequest CreditNoteCreateReasonCode(string creditNoteCreateReasonCode) 
            {
                m_params.AddOpt("credit_note[create_reason_code]", creditNoteCreateReasonCode);
                return this;
            }
        }
        public class RecordRefundRequest : EntityRequest<RecordRefundRequest> 
        {
            public RecordRefundRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RecordRefundRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public RecordRefundRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public RecordRefundRequest TransactionAmount(long transactionAmount) 
            {
                m_params.AddOpt("transaction[amount]", transactionAmount);
                return this;
            }
            public RecordRefundRequest TransactionPaymentMethod(ChargeBee.Models.Enums.PaymentMethodEnum transactionPaymentMethod) 
            {
                m_params.Add("transaction[payment_method]", transactionPaymentMethod);
                return this;
            }
            public RecordRefundRequest TransactionReferenceNumber(string transactionReferenceNumber) 
            {
                m_params.AddOpt("transaction[reference_number]", transactionReferenceNumber);
                return this;
            }
            public RecordRefundRequest TransactionDate(long transactionDate) 
            {
                m_params.Add("transaction[date]", transactionDate);
                return this;
            }
            public RecordRefundRequest CreditNoteReasonCode(CreditNote.ReasonCodeEnum creditNoteReasonCode) 
            {
                m_params.AddOpt("credit_note[reason_code]", creditNoteReasonCode);
                return this;
            }
            public RecordRefundRequest CreditNoteCreateReasonCode(string creditNoteCreateReasonCode) 
            {
                m_params.AddOpt("credit_note[create_reason_code]", creditNoteCreateReasonCode);
                return this;
            }
        }
        public class RemovePaymentRequest : EntityRequest<RemovePaymentRequest> 
        {
            public RemovePaymentRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemovePaymentRequest TransactionId(string transactionId) 
            {
                m_params.Add("transaction[id]", transactionId);
                return this;
            }
        }
        public class RemoveCreditNoteRequest : EntityRequest<RemoveCreditNoteRequest> 
        {
            public RemoveCreditNoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RemoveCreditNoteRequest CreditNoteId(string creditNoteId) 
            {
                m_params.Add("credit_note[id]", creditNoteId);
                return this;
            }
        }
        public class VoidInvoiceRequest : EntityRequest<VoidInvoiceRequest> 
        {
            public VoidInvoiceRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public VoidInvoiceRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public VoidInvoiceRequest VoidReasonCode(string voidReasonCode) 
            {
                m_params.AddOpt("void_reason_code", voidReasonCode);
                return this;
            }
            [Obsolete]
            public VoidInvoiceRequest CreateCreditNote(bool createCreditNote) 
            {
                m_params.AddOpt("create_credit_note", createCreditNote);
                return this;
            }
        }
        public class WriteOffRequest : EntityRequest<WriteOffRequest> 
        {
            public WriteOffRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public WriteOffRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public DeleteRequest ClaimCredits(bool claimCredits) 
            {
                m_params.AddOpt("claim_credits", claimCredits);
                return this;
            }
        }
        public class UpdateDetailsRequest : EntityRequest<UpdateDetailsRequest> 
        {
            public UpdateDetailsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateDetailsRequest VatNumber(string vatNumber) 
            {
                m_params.AddOpt("vat_number", vatNumber);
                return this;
            }
            public UpdateDetailsRequest VatNumberPrefix(string vatNumberPrefix) 
            {
                m_params.AddOpt("vat_number_prefix", vatNumberPrefix);
                return this;
            }
            public UpdateDetailsRequest PoNumber(string poNumber) 
            {
                m_params.AddOpt("po_number", poNumber);
                return this;
            }
            public UpdateDetailsRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public UpdateDetailsRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public UpdateDetailsRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public UpdateDetailsRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public UpdateDetailsRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public UpdateDetailsRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public UpdateDetailsRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public UpdateDetailsRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public UpdateDetailsRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public UpdateDetailsRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public UpdateDetailsRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateDetailsRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public UpdateDetailsRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateDetailsRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateDetailsRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateDetailsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "paid")]
            Paid,
            [EnumMember(Value = "posted")]
            Posted,
            [EnumMember(Value = "payment_due")]
            PaymentDue,
            [EnumMember(Value = "not_paid")]
            NotPaid,
            [EnumMember(Value = "voided")]
            Voided,
            [EnumMember(Value = "pending")]
            Pending,

        }
        public enum DunningStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "in_progress")]
            InProgress,
            [EnumMember(Value = "exhausted")]
            Exhausted,
            [EnumMember(Value = "stopped")]
            Stopped,
            [EnumMember(Value = "success")]
            Success,

        }

        #region Subclasses
        public class InvoiceLineItem : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan_setup")]
                PlanSetup,
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "adhoc")]
                Adhoc,
                [EnumMember(Value = "plan_item_price")]
                PlanItemPrice,
                [EnumMember(Value = "addon_item_price")]
                AddonItemPrice,
                [EnumMember(Value = "charge_item_price")]
                ChargeItemPrice,
            }

            public string Id {
                get { return GetValue<string>("id", false); }
            }

            public string SubscriptionId {
                get { return GetValue<string>("subscription_id", false); }
            }

            public DateTime DateFrom {
                get { return (DateTime)GetDateTime("date_from", true); }
            }

            public DateTime DateTo {
                get { return (DateTime)GetDateTime("date_to", true); }
            }

            public long UnitAmount {
                get { return GetValue<long>("unit_amount", true); }
            }

            public int? Quantity {
                get { return GetValue<int?>("quantity", false); }
            }

            public long? Amount {
                get { return GetValue<long?>("amount", false); }
            }

            public PricingModelEnum? PricingModel {
                get { return GetEnum<PricingModelEnum>("pricing_model", false); }
            }

            public bool IsTaxed {
                get { return GetValue<bool>("is_taxed", true); }
            }

            public long? TaxAmount {
                get { return GetValue<long?>("tax_amount", false); }
            }

            public double? TaxRate {
                get { return GetValue<double?>("tax_rate", false); }
            }

            public string UnitAmountInDecimal {
                get { return GetValue<string>("unit_amount_in_decimal", false); }
            }

            public string QuantityInDecimal {
                get { return GetValue<string>("quantity_in_decimal", false); }
            }

            public string AmountInDecimal {
                get { return GetValue<string>("amount_in_decimal", false); }
            }

            public long? DiscountAmount {
                get { return GetValue<long?>("discount_amount", false); }
            }

            public long? ItemLevelDiscountAmount {
                get { return GetValue<long?>("item_level_discount_amount", false); }
            }

            public string ReferenceLineItemId {
                get { return GetValue<string>("reference_line_item_id", false); }
            }

            public string Description {
                get { return GetValue<string>("description", true); }
            }

            public string EntityDescription {
                get { return GetValue<string>("entity_description", false); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public TaxExemptReasonEnum? TaxExemptReason {
                get { return GetEnum<TaxExemptReasonEnum>("tax_exempt_reason", false); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public string CustomerId {
                get { return GetValue<string>("customer_id", false); }
            }

        }
        public class InvoiceDiscount : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
                [EnumMember(Value = "item_level_discount")]
                ItemLevelDiscount,
                [EnumMember(Value = "document_level_discount")]
                DocumentLevelDiscount,
            }

            public long Amount {
                get { return GetValue<long>("amount", true); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public string CouponSetCode {
                get { return GetValue<string>("coupon_set_code", false); }
            }

        }
        public class InvoiceLineItemDiscount : Resource
        {
            public enum DiscountTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
                [EnumMember(Value = "item_level_discount")]
                ItemLevelDiscount,
                [EnumMember(Value = "document_level_discount")]
                DocumentLevelDiscount,
            }

            public string LineItemId {
                get { return GetValue<string>("line_item_id", true); }
            }

            public DiscountTypeEnum DiscountType {
                get { return GetEnum<DiscountTypeEnum>("discount_type", true); }
            }

            public string CouponId {
                get { return GetValue<string>("coupon_id", false); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

            public long DiscountAmount {
                get { return GetValue<long>("discount_amount", true); }
            }

        }
        public class InvoiceTax : Resource
        {

            public string Name {
                get { return GetValue<string>("name", true); }
            }

            public long Amount {
                get { return GetValue<long>("amount", true); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

        }
        public class InvoiceLineItemTax : Resource
        {

            public string LineItemId {
                get { return GetValue<string>("line_item_id", false); }
            }

            public string TaxName {
                get { return GetValue<string>("tax_name", true); }
            }

            public double TaxRate {
                get { return GetValue<double>("tax_rate", true); }
            }

            public bool? IsPartialTaxApplied {
                get { return GetValue<bool?>("is_partial_tax_applied", false); }
            }

            public bool? IsNonComplianceTax {
                get { return GetValue<bool?>("is_non_compliance_tax", false); }
            }

            public long TaxableAmount {
                get { return GetValue<long>("taxable_amount", true); }
            }

            public long TaxAmount {
                get { return GetValue<long>("tax_amount", true); }
            }

            public TaxJurisTypeEnum? TaxJurisType {
                get { return GetEnum<TaxJurisTypeEnum>("tax_juris_type", false); }
            }

            public string TaxJurisName {
                get { return GetValue<string>("tax_juris_name", false); }
            }

            public string TaxJurisCode {
                get { return GetValue<string>("tax_juris_code", false); }
            }

            public long? TaxAmountInLocalCurrency {
                get { return GetValue<long?>("tax_amount_in_local_currency", false); }
            }

            public string LocalCurrencyCode {
                get { return GetValue<string>("local_currency_code", false); }
            }

        }
        public class InvoiceLineItemTier : Resource
        {

            public string LineItemId {
                get { return GetValue<string>("line_item_id", false); }
            }

            public int StartingUnit {
                get { return GetValue<int>("starting_unit", true); }
            }

            public int? EndingUnit {
                get { return GetValue<int?>("ending_unit", false); }
            }

            public int QuantityUsed {
                get { return GetValue<int>("quantity_used", true); }
            }

            public long UnitAmount {
                get { return GetValue<long>("unit_amount", true); }
            }

            public string StartingUnitInDecimal {
                get { return GetValue<string>("starting_unit_in_decimal", false); }
            }

            public string EndingUnitInDecimal {
                get { return GetValue<string>("ending_unit_in_decimal", false); }
            }

            public string QuantityUsedInDecimal {
                get { return GetValue<string>("quantity_used_in_decimal", false); }
            }

            public string UnitAmountInDecimal {
                get { return GetValue<string>("unit_amount_in_decimal", false); }
            }

        }
        public class InvoiceLinkedPayment : Resource
        {

            public string TxnId {
                get { return GetValue<string>("txn_id", true); }
            }

            public long AppliedAmount {
                get { return GetValue<long>("applied_amount", true); }
            }

            public DateTime AppliedAt {
                get { return (DateTime)GetDateTime("applied_at", true); }
            }

            public Transaction.StatusEnum? TxnStatus {
                get { return GetEnum<Transaction.StatusEnum>("txn_status", false); }
            }

            public DateTime? TxnDate {
                get { return GetDateTime("txn_date", false); }
            }

            public long? TxnAmount {
                get { return GetValue<long?>("txn_amount", false); }
            }

        }
        public class InvoiceDunningAttempt : Resource
        {

            public int Attempt {
                get { return GetValue<int>("attempt", true); }
            }

            public string TransactionId {
                get { return GetValue<string>("transaction_id", false); }
            }

            public DunningTypeEnum DunningType {
                get { return GetEnum<DunningTypeEnum>("dunning_type", true); }
            }

            public DateTime? CreatedAt {
                get { return GetDateTime("created_at", false); }
            }

            public Transaction.StatusEnum? TxnStatus {
                get { return GetEnum<Transaction.StatusEnum>("txn_status", false); }
            }

            public long? TxnAmount {
                get { return GetValue<long?>("txn_amount", false); }
            }

        }
        public class InvoiceAppliedCredit : Resource
        {

            public string CnId {
                get { return GetValue<string>("cn_id", true); }
            }

            public long AppliedAmount {
                get { return GetValue<long>("applied_amount", true); }
            }

            public DateTime AppliedAt {
                get { return (DateTime)GetDateTime("applied_at", true); }
            }

            public CreditNote.ReasonCodeEnum? CnReasonCode {
                get { return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", false); }
            }

            public string CnCreateReasonCode {
                get { return GetValue<string>("cn_create_reason_code", false); }
            }

            public DateTime? CnDate {
                get { return GetDateTime("cn_date", false); }
            }

            public CreditNote.StatusEnum CnStatus {
                get { return GetEnum<CreditNote.StatusEnum>("cn_status", true); }
            }

        }
        public class InvoiceAdjustmentCreditNote : Resource
        {

            public string CnId {
                get { return GetValue<string>("cn_id", true); }
            }

            public CreditNote.ReasonCodeEnum? CnReasonCode {
                get { return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", false); }
            }

            public string CnCreateReasonCode {
                get { return GetValue<string>("cn_create_reason_code", false); }
            }

            public DateTime? CnDate {
                get { return GetDateTime("cn_date", false); }
            }

            public long? CnTotal {
                get { return GetValue<long?>("cn_total", false); }
            }

            public CreditNote.StatusEnum CnStatus {
                get { return GetEnum<CreditNote.StatusEnum>("cn_status", true); }
            }

        }
        public class InvoiceIssuedCreditNote : Resource
        {

            public string CnId {
                get { return GetValue<string>("cn_id", true); }
            }

            public CreditNote.ReasonCodeEnum? CnReasonCode {
                get { return GetEnum<CreditNote.ReasonCodeEnum>("cn_reason_code", false); }
            }

            public string CnCreateReasonCode {
                get { return GetValue<string>("cn_create_reason_code", false); }
            }

            public DateTime? CnDate {
                get { return GetDateTime("cn_date", false); }
            }

            public long? CnTotal {
                get { return GetValue<long?>("cn_total", false); }
            }

            public CreditNote.StatusEnum CnStatus {
                get { return GetEnum<CreditNote.StatusEnum>("cn_status", true); }
            }

        }
        public class InvoiceLinkedOrder : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "new")]
                New,
                [EnumMember(Value = "processing")]
                Processing,
                [EnumMember(Value = "complete")]
                Complete,
                [EnumMember(Value = "cancelled")]
                Cancelled,
                [EnumMember(Value = "voided")]
                Voided,
                [EnumMember(Value = "queued")]
                Queued,
                [EnumMember(Value = "awaiting_shipment")]
                AwaitingShipment,
                [EnumMember(Value = "on_hold")]
                OnHold,
                [EnumMember(Value = "delivered")]
                Delivered,
                [EnumMember(Value = "shipped")]
                Shipped,
                [EnumMember(Value = "partially_delivered")]
                PartiallyDelivered,
                [EnumMember(Value = "returned")]
                Returned,
            }
            public enum OrderTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "manual")]
                Manual,
                [EnumMember(Value = "system_generated")]
                SystemGenerated,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public string DocumentNumber {
                get { return GetValue<string>("document_number", false); }
            }

            public StatusEnum? Status {
                get { return GetEnum<StatusEnum>("status", false); }
            }

            public OrderTypeEnum? OrderType {
                get { return GetEnum<OrderTypeEnum>("order_type", false); }
            }

            public string ReferenceId {
                get { return GetValue<string>("reference_id", false); }
            }

            public string FulfillmentStatus {
                get { return GetValue<string>("fulfillment_status", false); }
            }

            public string BatchId {
                get { return GetValue<string>("batch_id", false); }
            }

            public DateTime CreatedAt {
                get { return (DateTime)GetDateTime("created_at", true); }
            }

        }
        public class InvoiceNote : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "coupon")]
                Coupon,
                [EnumMember(Value = "subscription")]
                Subscription,
                [EnumMember(Value = "customer")]
                Customer,
                [EnumMember(Value = "plan_item_price")]
                PlanItemPrice,
                [EnumMember(Value = "addon_item_price")]
                AddonItemPrice,
                [EnumMember(Value = "charge_item_price")]
                ChargeItemPrice,
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public string Note {
                get { return GetValue<string>("note", true); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

        }
        public class InvoiceShippingAddress : Resource
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

            public int Index {
                get { return GetValue<int>("index", true); }
            }

        }
        public class InvoiceBillingAddress : Resource
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
        public class InvoiceEinvoice : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "scheduled")]
                Scheduled,
                [EnumMember(Value = "skipped")]
                Skipped,
                [EnumMember(Value = "in_progress")]
                InProgress,
                [EnumMember(Value = "success")]
                Success,
                [EnumMember(Value = "failed")]
                Failed,
                [EnumMember(Value = "registered")]
                Registered,
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public string Message {
                get { return GetValue<string>("message", false); }
            }

        }

        #endregion
    }
}
