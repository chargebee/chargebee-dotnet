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

    public class PaymentVoucher : Resource 
    {
    
        public PaymentVoucher() { }

        public PaymentVoucher(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PaymentVoucher(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PaymentVoucher(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("payment_vouchers");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("payment_vouchers", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static PaymentVoucherPaymentVouchersForInvoiceRequest Payment_vouchersForInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "payment_vouchers");
            return new PaymentVoucherPaymentVouchersForInvoiceRequest(url);
        }
        public static PaymentVoucherPaymentVouchersForCustomerRequest Payment_vouchersForCustomer(string id)
        {
            string url = ApiUtil.BuildUrl("customers", CheckNull(id), "payment_vouchers");
            return new PaymentVoucherPaymentVouchersForCustomerRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string IdAtGateway 
        {
            get { return GetValue<string>("id_at_gateway", false); }
        }
        public PaymentVoucherTypeEnum PaymentVoucherType 
        {
            get { return GetEnum<PaymentVoucherTypeEnum>("payment_voucher_type", true); }
        }
        public DateTime? ExpiresAt 
        {
            get { return GetDateTime("expires_at", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public long? Amount
        {
            get { return GetValue<long?>("amount", false); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", false); }
        }
        public string PaymentSourceId 
        {
            get { return GetValue<string>("payment_source_id", false); }
        }
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
        }
        public string Payload 
        {
            get { return GetValue<string>("payload", false); }
        }
        public string ErrorCode 
        {
            get { return GetValue<string>("error_code", false); }
        }
        public string ErrorText 
        {
            get { return GetValue<string>("error_text", false); }
        }
        public string Url 
        {
            get { return GetValue<string>("url", false); }
        }
        public DateTime? Date 
        {
            get { return GetDateTime("date", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public List<PaymentVoucherLinkedInvoice> LinkedInvoices 
        {
            get { return GetResourceList<PaymentVoucherLinkedInvoice>("linked_invoices"); }
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
                m_params.Add("customer_id", customerId);
                return this;
            }
            public CreateRequest PaymentSourceId(string paymentSourceId) 
            {
                m_params.AddOpt("payment_source_id", paymentSourceId);
                return this;
            }
            public CreateRequest VoucherPaymentSourceVoucherType(ChargeBee.Models.Enums.VoucherTypeEnum voucherPaymentSourceVoucherType) 
            {
                m_params.Add("voucher_payment_source[voucher_type]", voucherPaymentSourceVoucherType);
                return this;
            }
            public CreateRequest InvoiceAllocationInvoiceId(int index, string invoiceAllocationInvoiceId) 
            {
                m_params.Add("invoice_allocations[invoice_id][" + index + "]", invoiceAllocationInvoiceId);
                return this;
            }
        }
        public class PaymentVoucherPaymentVouchersForInvoiceRequest : ListRequestBase<PaymentVoucherPaymentVouchersForInvoiceRequest> 
        {
            public PaymentVoucherPaymentVouchersForInvoiceRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<PaymentVoucher.StatusEnum, PaymentVoucherPaymentVouchersForInvoiceRequest> Status() 
            {
                return new EnumFilter<PaymentVoucher.StatusEnum, PaymentVoucherPaymentVouchersForInvoiceRequest>("status", this);        
            }
            public PaymentVoucherPaymentVouchersForInvoiceRequest SortByDate(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","date");
                return this;
            }
            public PaymentVoucherPaymentVouchersForInvoiceRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        public class PaymentVoucherPaymentVouchersForCustomerRequest : ListRequestBase<PaymentVoucherPaymentVouchersForCustomerRequest> 
        {
            public PaymentVoucherPaymentVouchersForCustomerRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<PaymentVoucher.StatusEnum, PaymentVoucherPaymentVouchersForCustomerRequest> Status() 
            {
                return new EnumFilter<PaymentVoucher.StatusEnum, PaymentVoucherPaymentVouchersForCustomerRequest>("status", this);        
            }
            public PaymentVoucherPaymentVouchersForCustomerRequest SortByDate(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","date");
                return this;
            }
            public PaymentVoucherPaymentVouchersForCustomerRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "consumed")]
            Consumed,
            [EnumMember(Value = "expired")]
            Expired,
            [EnumMember(Value = "failure")]
            Failure,

        }

        #region Subclasses
        public class PaymentVoucherLinkedInvoice : Resource
        {

            public string InvoiceId {
                get { return GetValue<string>("invoice_id", true); }
            }

            public string TxnId {
                get { return GetValue<string>("txn_id", true); }
            }

            public DateTime AppliedAt {
                get { return (DateTime)GetDateTime("applied_at", true); }
            }

        }

        #endregion
    }
}
