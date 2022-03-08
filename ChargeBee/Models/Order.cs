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

    public class Order : Resource 
    {
    
        public Order() { }

        public Order(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Order(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Order(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("orders");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static ImportOrderRequest ImportOrder()
        {
            string url = ApiUtil.BuildUrl("orders", "import_order");
            return new ImportOrderRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> AssignOrderNumber(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id), "assign_order_number");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static CancelRequest Cancel(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id), "cancel");
            return new CancelRequest(url, HttpMethod.POST);
        }
        public static CreateRefundableCreditNoteRequest CreateRefundableCreditNote(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id), "create_refundable_credit_note");
            return new CreateRefundableCreditNoteRequest(url, HttpMethod.POST);
        }
        public static ReopenRequest Reopen(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id), "reopen");
            return new ReopenRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static OrderListRequest List()
        {
            string url = ApiUtil.BuildUrl("orders");
            return new OrderListRequest(url);
        }
        [Obsolete]
        public static ListRequest OrdersForInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "orders");
            return new ListRequest(url);
        }
        public static ResendRequest Resend(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id), "resend");
            return new ResendRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string DocumentNumber 
        {
            get { return GetValue<string>("document_number", false); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public CancellationReasonEnum? CancellationReason 
        {
            get { return GetEnum<CancellationReasonEnum>("cancellation_reason", false); }
        }
        public PaymentStatusEnum? PaymentStatus 
        {
            get { return GetEnum<PaymentStatusEnum>("payment_status", false); }
        }
        public OrderTypeEnum? OrderType 
        {
            get { return GetEnum<OrderTypeEnum>("order_type", false); }
        }
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public string ReferenceId 
        {
            get { return GetValue<string>("reference_id", false); }
        }
        public string FulfillmentStatus 
        {
            get { return GetValue<string>("fulfillment_status", false); }
        }
        public DateTime? OrderDate 
        {
            get { return GetDateTime("order_date", false); }
        }
        public DateTime? ShippingDate 
        {
            get { return GetDateTime("shipping_date", false); }
        }
        public string Note 
        {
            get { return GetValue<string>("note", false); }
        }
        public string TrackingId 
        {
            get { return GetValue<string>("tracking_id", false); }
        }
        public string TrackingUrl 
        {
            get { return GetValue<string>("tracking_url", false); }
        }
        public string BatchId 
        {
            get { return GetValue<string>("batch_id", false); }
        }
        public string CreatedBy 
        {
            get { return GetValue<string>("created_by", false); }
        }
        public string ShipmentCarrier 
        {
            get { return GetValue<string>("shipment_carrier", false); }
        }
        public int? InvoiceRoundOffAmount 
        {
            get { return GetValue<int?>("invoice_round_off_amount", false); }
        }
        public int? Tax 
        {
            get { return GetValue<int?>("tax", false); }
        }
        public int? AmountPaid 
        {
            get { return GetValue<int?>("amount_paid", false); }
        }
        public int? AmountAdjusted 
        {
            get { return GetValue<int?>("amount_adjusted", false); }
        }
        public int? RefundableCreditsIssued 
        {
            get { return GetValue<int?>("refundable_credits_issued", false); }
        }
        public int? RefundableCredits 
        {
            get { return GetValue<int?>("refundable_credits", false); }
        }
        public int? RoundingAdjustement 
        {
            get { return GetValue<int?>("rounding_adjustement", false); }
        }
        public DateTime? PaidOn 
        {
            get { return GetDateTime("paid_on", false); }
        }
        public DateTime? ShippingCutOffDate 
        {
            get { return GetDateTime("shipping_cut_off_date", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? StatusUpdateAt 
        {
            get { return GetDateTime("status_update_at", false); }
        }
        public DateTime? DeliveredAt 
        {
            get { return GetDateTime("delivered_at", false); }
        }
        public DateTime? ShippedAt 
        {
            get { return GetDateTime("shipped_at", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public DateTime? CancelledAt 
        {
            get { return GetDateTime("cancelled_at", false); }
        }
        public ResentStatusEnum? ResentStatus 
        {
            get { return GetEnum<ResentStatusEnum>("resent_status", false); }
        }
        public bool IsResent 
        {
            get { return GetValue<bool>("is_resent", true); }
        }
        public string OriginalOrderId 
        {
            get { return GetValue<string>("original_order_id", false); }
        }
        public List<OrderOrderLineItem> OrderLineItems 
        {
            get { return GetResourceList<OrderOrderLineItem>("order_line_items"); }
        }
        public OrderShippingAddress ShippingAddress 
        {
            get { return GetSubResource<OrderShippingAddress>("shipping_address"); }
        }
        public OrderBillingAddress BillingAddress 
        {
            get { return GetSubResource<OrderBillingAddress>("billing_address"); }
        }
        public int? Discount 
        {
            get { return GetValue<int?>("discount", false); }
        }
        public int? SubTotal 
        {
            get { return GetValue<int?>("sub_total", false); }
        }
        public int? Total 
        {
            get { return GetValue<int?>("total", false); }
        }
        public List<OrderLineItemTax> LineItemTaxes 
        {
            get { return GetResourceList<OrderLineItemTax>("line_item_taxes"); }
        }
        public List<OrderLineItemDiscount> LineItemDiscounts 
        {
            get { return GetResourceList<OrderLineItemDiscount>("line_item_discounts"); }
        }
        public List<OrderLinkedCreditNote> LinkedCreditNotes 
        {
            get { return GetResourceList<OrderLinkedCreditNote>("linked_credit_notes"); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public bool? IsGifted 
        {
            get { return GetValue<bool?>("is_gifted", false); }
        }
        public string GiftNote 
        {
            get { return GetValue<string>("gift_note", false); }
        }
        public string GiftId 
        {
            get { return GetValue<string>("gift_id", false); }
        }
        public string ResendReason 
        {
            get { return GetValue<string>("resend_reason", false); }
        }
        public List<OrderResentOrder> ResentOrders 
        {
            get { return GetResourceList<OrderResentOrder>("resent_orders"); }
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
            public CreateRequest InvoiceId(string invoiceId) 
            {
                m_params.Add("invoice_id", invoiceId);
                return this;
            }
            public CreateRequest Status(StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public CreateRequest ReferenceId(string referenceId) 
            {
                m_params.AddOpt("reference_id", referenceId);
                return this;
            }
            public CreateRequest FulfillmentStatus(string fulfillmentStatus) 
            {
                m_params.AddOpt("fulfillment_status", fulfillmentStatus);
                return this;
            }
            public CreateRequest Note(string note) 
            {
                m_params.AddOpt("note", note);
                return this;
            }
            public CreateRequest TrackingId(string trackingId) 
            {
                m_params.AddOpt("tracking_id", trackingId);
                return this;
            }
            public CreateRequest TrackingUrl(string trackingUrl) 
            {
                m_params.AddOpt("tracking_url", trackingUrl);
                return this;
            }
            public CreateRequest BatchId(string batchId) 
            {
                m_params.AddOpt("batch_id", batchId);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest ReferenceId(string referenceId) 
            {
                m_params.AddOpt("reference_id", referenceId);
                return this;
            }
            public UpdateRequest BatchId(string batchId) 
            {
                m_params.AddOpt("batch_id", batchId);
                return this;
            }
            public UpdateRequest Note(string note) 
            {
                m_params.AddOpt("note", note);
                return this;
            }
            public UpdateRequest ShippingDate(long shippingDate) 
            {
                m_params.AddOpt("shipping_date", shippingDate);
                return this;
            }
            public UpdateRequest OrderDate(long orderDate) 
            {
                m_params.AddOpt("order_date", orderDate);
                return this;
            }
            public UpdateRequest CancelledAt(long cancelledAt) 
            {
                m_params.AddOpt("cancelled_at", cancelledAt);
                return this;
            }
            public UpdateRequest CancellationReason(Order.CancellationReasonEnum cancellationReason) 
            {
                m_params.AddOpt("cancellation_reason", cancellationReason);
                return this;
            }
            public UpdateRequest ShippedAt(long shippedAt) 
            {
                m_params.AddOpt("shipped_at", shippedAt);
                return this;
            }
            public UpdateRequest DeliveredAt(long deliveredAt) 
            {
                m_params.AddOpt("delivered_at", deliveredAt);
                return this;
            }
            public UpdateRequest TrackingUrl(string trackingUrl) 
            {
                m_params.AddOpt("tracking_url", trackingUrl);
                return this;
            }
            public UpdateRequest TrackingId(string trackingId) 
            {
                m_params.AddOpt("tracking_id", trackingId);
                return this;
            }
            public UpdateRequest ShipmentCarrier(string shipmentCarrier) 
            {
                m_params.AddOpt("shipment_carrier", shipmentCarrier);
                return this;
            }
            public UpdateRequest FulfillmentStatus(string fulfillmentStatus) 
            {
                m_params.AddOpt("fulfillment_status", fulfillmentStatus);
                return this;
            }
            public UpdateRequest Status(Order.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public UpdateRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public UpdateRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public UpdateRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public UpdateRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public UpdateRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public UpdateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public UpdateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public UpdateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public UpdateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public UpdateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public UpdateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public UpdateRequest OrderLineItemId(int index, string orderLineItemId) 
            {
                m_params.AddOpt("order_line_items[id][" + index + "]", orderLineItemId);
                return this;
            }
            public UpdateRequest OrderLineItemStatus(int index, OrderOrderLineItem.StatusEnum orderLineItemStatus) 
            {
                m_params.AddOpt("order_line_items[status][" + index + "]", orderLineItemStatus);
                return this;
            }
            public UpdateRequest OrderLineItemSku(int index, string orderLineItemSku) 
            {
                m_params.AddOpt("order_line_items[sku][" + index + "]", orderLineItemSku);
                return this;
            }
        }
        public class ImportOrderRequest : EntityRequest<ImportOrderRequest> 
        {
            public ImportOrderRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportOrderRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public ImportOrderRequest DocumentNumber(string documentNumber) 
            {
                m_params.AddOpt("document_number", documentNumber);
                return this;
            }
            public ImportOrderRequest InvoiceId(string invoiceId) 
            {
                m_params.Add("invoice_id", invoiceId);
                return this;
            }
            public ImportOrderRequest Status(Order.StatusEnum status) 
            {
                m_params.Add("status", status);
                return this;
            }
            public ImportOrderRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public ImportOrderRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
            public ImportOrderRequest CreatedAt(long createdAt) 
            {
                m_params.Add("created_at", createdAt);
                return this;
            }
            public ImportOrderRequest OrderDate(long orderDate) 
            {
                m_params.Add("order_date", orderDate);
                return this;
            }
            public ImportOrderRequest ShippingDate(long shippingDate) 
            {
                m_params.Add("shipping_date", shippingDate);
                return this;
            }
            public ImportOrderRequest ReferenceId(string referenceId) 
            {
                m_params.AddOpt("reference_id", referenceId);
                return this;
            }
            public ImportOrderRequest FulfillmentStatus(string fulfillmentStatus) 
            {
                m_params.AddOpt("fulfillment_status", fulfillmentStatus);
                return this;
            }
            public ImportOrderRequest Note(string note) 
            {
                m_params.AddOpt("note", note);
                return this;
            }
            public ImportOrderRequest TrackingId(string trackingId) 
            {
                m_params.AddOpt("tracking_id", trackingId);
                return this;
            }
            public ImportOrderRequest TrackingUrl(string trackingUrl) 
            {
                m_params.AddOpt("tracking_url", trackingUrl);
                return this;
            }
            public ImportOrderRequest BatchId(string batchId) 
            {
                m_params.AddOpt("batch_id", batchId);
                return this;
            }
            public ImportOrderRequest ShipmentCarrier(string shipmentCarrier) 
            {
                m_params.AddOpt("shipment_carrier", shipmentCarrier);
                return this;
            }
            public ImportOrderRequest ShippingCutOffDate(long shippingCutOffDate) 
            {
                m_params.AddOpt("shipping_cut_off_date", shippingCutOffDate);
                return this;
            }
            public ImportOrderRequest DeliveredAt(long deliveredAt) 
            {
                m_params.AddOpt("delivered_at", deliveredAt);
                return this;
            }
            public ImportOrderRequest ShippedAt(long shippedAt) 
            {
                m_params.AddOpt("shipped_at", shippedAt);
                return this;
            }
            public ImportOrderRequest CancelledAt(long cancelledAt) 
            {
                m_params.AddOpt("cancelled_at", cancelledAt);
                return this;
            }
            public ImportOrderRequest CancellationReason(Order.CancellationReasonEnum cancellationReason) 
            {
                m_params.AddOpt("cancellation_reason", cancellationReason);
                return this;
            }
            public ImportOrderRequest RefundableCreditsIssued(int refundableCreditsIssued) 
            {
                m_params.AddOpt("refundable_credits_issued", refundableCreditsIssued);
                return this;
            }
            public ImportOrderRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public ImportOrderRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public ImportOrderRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public ImportOrderRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public ImportOrderRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public ImportOrderRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public ImportOrderRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public ImportOrderRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public ImportOrderRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public ImportOrderRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public ImportOrderRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public ImportOrderRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public ImportOrderRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public ImportOrderRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public ImportOrderRequest BillingAddressFirstName(string billingAddressFirstName) 
            {
                m_params.AddOpt("billing_address[first_name]", billingAddressFirstName);
                return this;
            }
            public ImportOrderRequest BillingAddressLastName(string billingAddressLastName) 
            {
                m_params.AddOpt("billing_address[last_name]", billingAddressLastName);
                return this;
            }
            public ImportOrderRequest BillingAddressEmail(string billingAddressEmail) 
            {
                m_params.AddOpt("billing_address[email]", billingAddressEmail);
                return this;
            }
            public ImportOrderRequest BillingAddressCompany(string billingAddressCompany) 
            {
                m_params.AddOpt("billing_address[company]", billingAddressCompany);
                return this;
            }
            public ImportOrderRequest BillingAddressPhone(string billingAddressPhone) 
            {
                m_params.AddOpt("billing_address[phone]", billingAddressPhone);
                return this;
            }
            public ImportOrderRequest BillingAddressLine1(string billingAddressLine1) 
            {
                m_params.AddOpt("billing_address[line1]", billingAddressLine1);
                return this;
            }
            public ImportOrderRequest BillingAddressLine2(string billingAddressLine2) 
            {
                m_params.AddOpt("billing_address[line2]", billingAddressLine2);
                return this;
            }
            public ImportOrderRequest BillingAddressLine3(string billingAddressLine3) 
            {
                m_params.AddOpt("billing_address[line3]", billingAddressLine3);
                return this;
            }
            public ImportOrderRequest BillingAddressCity(string billingAddressCity) 
            {
                m_params.AddOpt("billing_address[city]", billingAddressCity);
                return this;
            }
            public ImportOrderRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public ImportOrderRequest BillingAddressState(string billingAddressState) 
            {
                m_params.AddOpt("billing_address[state]", billingAddressState);
                return this;
            }
            public ImportOrderRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public ImportOrderRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public ImportOrderRequest BillingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum billingAddressValidationStatus) 
            {
                m_params.AddOpt("billing_address[validation_status]", billingAddressValidationStatus);
                return this;
            }
        }
        public class CancelRequest : EntityRequest<CancelRequest> 
        {
            public CancelRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CancelRequest CancellationReason(Order.CancellationReasonEnum cancellationReason) 
            {
                m_params.Add("cancellation_reason", cancellationReason);
                return this;
            }
            public CancelRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public CancelRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public CancelRequest CancelledAt(long cancelledAt) 
            {
                m_params.AddOpt("cancelled_at", cancelledAt);
                return this;
            }
            public CancelRequest CreditNoteTotal(int creditNoteTotal) 
            {
                m_params.AddOpt("credit_note[total]", creditNoteTotal);
                return this;
            }
        }
        public class CreateRefundableCreditNoteRequest : EntityRequest<CreateRefundableCreditNoteRequest> 
        {
            public CreateRefundableCreditNoteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRefundableCreditNoteRequest CustomerNotes(string customerNotes) 
            {
                m_params.AddOpt("customer_notes", customerNotes);
                return this;
            }
            public CreateRefundableCreditNoteRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
            public CreateRefundableCreditNoteRequest CreditNoteReasonCode(CreditNote.ReasonCodeEnum creditNoteReasonCode) 
            {
                m_params.Add("credit_note[reason_code]", creditNoteReasonCode);
                return this;
            }
            public CreateRefundableCreditNoteRequest CreditNoteTotal(int creditNoteTotal) 
            {
                m_params.Add("credit_note[total]", creditNoteTotal);
                return this;
            }
        }
        public class ReopenRequest : EntityRequest<ReopenRequest> 
        {
            public ReopenRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ReopenRequest VoidCancellationCreditNotes(bool voidCancellationCreditNotes) 
            {
                m_params.AddOpt("void_cancellation_credit_notes", voidCancellationCreditNotes);
                return this;
            }
        }
        public class OrderListRequest : ListRequestBase<OrderListRequest> 
        {
            public OrderListRequest(string url) 
                    : base(url)
            {
            }

            public OrderListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public OrderListRequest ExcludeDeletedCreditNotes(bool excludeDeletedCreditNotes) 
            {
                m_params.AddOpt("exclude_deleted_credit_notes", excludeDeletedCreditNotes);
                return this;
            }
            public StringFilter<OrderListRequest> Id() 
            {
                return new StringFilter<OrderListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<OrderListRequest> InvoiceId() 
            {
                return new StringFilter<OrderListRequest>("invoice_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<OrderListRequest> SubscriptionId() 
            {
                return new StringFilter<OrderListRequest>("subscription_id", this);        
            }
            public EnumFilter<Order.StatusEnum, OrderListRequest> Status() 
            {
                return new EnumFilter<Order.StatusEnum, OrderListRequest>("status", this);        
            }
            public TimestampFilter<OrderListRequest> ShippingDate() 
            {
                return new TimestampFilter<OrderListRequest>("shipping_date", this);        
            }
            public EnumFilter<Order.OrderTypeEnum, OrderListRequest> OrderType() 
            {
                return new EnumFilter<Order.OrderTypeEnum, OrderListRequest>("order_type", this);        
            }
            public TimestampFilter<OrderListRequest> OrderDate() 
            {
                return new TimestampFilter<OrderListRequest>("order_date", this);        
            }
            public TimestampFilter<OrderListRequest> PaidOn() 
            {
                return new TimestampFilter<OrderListRequest>("paid_on", this);        
            }
            public TimestampFilter<OrderListRequest> UpdatedAt() 
            {
                return new TimestampFilter<OrderListRequest>("updated_at", this);        
            }
            public TimestampFilter<OrderListRequest> CreatedAt() 
            {
                return new TimestampFilter<OrderListRequest>("created_at", this);        
            }
            public EnumFilter<Order.ResentStatusEnum, OrderListRequest> ResentStatus() 
            {
                return new EnumFilter<Order.ResentStatusEnum, OrderListRequest>("resent_status", this);        
            }
            public BooleanFilter<OrderListRequest> IsResent() 
            {
                return new BooleanFilter<OrderListRequest>("is_resent", this);        
            }
            public StringFilter<OrderListRequest> OriginalOrderId() 
            {
                return new StringFilter<OrderListRequest>("original_order_id", this);        
            }
            public OrderListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
            public OrderListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
                return this;
            }
        }
        public class ResendRequest : EntityRequest<ResendRequest> 
        {
            public ResendRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ResendRequest ShippingDate(long shippingDate) 
            {
                m_params.AddOpt("shipping_date", shippingDate);
                return this;
            }
            public ResendRequest ResendReason(string resendReason) 
            {
                m_params.AddOpt("resend_reason", resendReason);
                return this;
            }
            public ResendRequest OrderLineItemId(int index, string orderLineItemId) 
            {
                m_params.AddOpt("order_line_items[id][" + index + "]", orderLineItemId);
                return this;
            }
            public ResendRequest OrderLineItemFulfillmentQuantity(int index, int orderLineItemFulfillmentQuantity) 
            {
                m_params.AddOpt("order_line_items[fulfillment_quantity][" + index + "]", orderLineItemFulfillmentQuantity);
                return this;
            }
        }
        #endregion

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
        public enum CancellationReasonEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "shipping_cut_off_passed")]
            ShippingCutOffPassed,
            [EnumMember(Value = "product_unsatisfactory")]
            ProductUnsatisfactory,
            [EnumMember(Value = "third_party_cancellation")]
            ThirdPartyCancellation,
            [EnumMember(Value = "product_not_required")]
            ProductNotRequired,
            [EnumMember(Value = "delivery_date_missed")]
            DeliveryDateMissed,
            [EnumMember(Value = "alternative_found")]
            AlternativeFound,
            [EnumMember(Value = "invoice_written_off")]
            InvoiceWrittenOff,
            [EnumMember(Value = "invoice_voided")]
            InvoiceVoided,
            [EnumMember(Value = "fraudulent_transaction")]
            FraudulentTransaction,
            [EnumMember(Value = "payment_declined")]
            PaymentDeclined,
            [EnumMember(Value = "subscription_cancelled")]
            SubscriptionCancelled,
            [EnumMember(Value = "product_not_available")]
            ProductNotAvailable,
            [EnumMember(Value = "others")]
            Others,
            [EnumMember(Value = "order_resent")]
            OrderResent,

        }
        public enum PaymentStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "not_paid")]
            NotPaid,
            [EnumMember(Value = "paid")]
            Paid,

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
        public enum ResentStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "fully_resent")]
            FullyResent,
            [EnumMember(Value = "partially_resent")]
            PartiallyResent,

        }

        #region Subclasses
        public class OrderOrderLineItem : Resource
        {
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
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
                [EnumMember(Value = "cancelled")]
                Cancelled,
            }
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
                get { return GetValue<string>("id", true); }
            }

            public string InvoiceId {
                get { return GetValue<string>("invoice_id", true); }
            }

            public string InvoiceLineItemId {
                get { return GetValue<string>("invoice_line_item_id", true); }
            }

            public int? UnitPrice {
                get { return GetValue<int?>("unit_price", false); }
            }

            public string Description {
                get { return GetValue<string>("description", false); }
            }

            public int? Amount {
                get { return GetValue<int?>("amount", false); }
            }

            public int? FulfillmentQuantity {
                get { return GetValue<int?>("fulfillment_quantity", false); }
            }

            public int? FulfillmentAmount {
                get { return GetValue<int?>("fulfillment_amount", false); }
            }

            public int? TaxAmount {
                get { return GetValue<int?>("tax_amount", false); }
            }

            public int? AmountPaid {
                get { return GetValue<int?>("amount_paid", false); }
            }

            public int? AmountAdjusted {
                get { return GetValue<int?>("amount_adjusted", false); }
            }

            public int? RefundableCreditsIssued {
                get { return GetValue<int?>("refundable_credits_issued", false); }
            }

            public int? RefundableCredits {
                get { return GetValue<int?>("refundable_credits", false); }
            }

            public bool IsShippable {
                get { return GetValue<bool>("is_shippable", true); }
            }

            public string Sku {
                get { return GetValue<string>("sku", false); }
            }

            public StatusEnum? Status {
                get { return GetEnum<StatusEnum>("status", false); }
            }

            public EntityTypeEnum EntityType {
                get { return GetEnum<EntityTypeEnum>("entity_type", true); }
            }

            public int? ItemLevelDiscountAmount {
                get { return GetValue<int?>("item_level_discount_amount", false); }
            }

            public int? DiscountAmount {
                get { return GetValue<int?>("discount_amount", false); }
            }

            public string EntityId {
                get { return GetValue<string>("entity_id", false); }
            }

        }
        public class OrderShippingAddress : Resource
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
        public class OrderBillingAddress : Resource
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
        public class OrderLineItemTax : Resource
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

            public int TaxableAmount {
                get { return GetValue<int>("taxable_amount", true); }
            }

            public int TaxAmount {
                get { return GetValue<int>("tax_amount", true); }
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

            public int? TaxAmountInLocalCurrency {
                get { return GetValue<int?>("tax_amount_in_local_currency", false); }
            }

            public string LocalCurrencyCode {
                get { return GetValue<string>("local_currency_code", false); }
            }

        }
        public class OrderLineItemDiscount : Resource
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
                [EnumMember(Value = "custom_discount")]
                CustomDiscount,
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

            public int DiscountAmount {
                get { return GetValue<int>("discount_amount", true); }
            }

        }
        public class OrderLinkedCreditNote : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "adjustment")]
                Adjustment,
                [EnumMember(Value = "refundable")]
                Refundable,
            }
            public enum StatusEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "adjusted")]
                Adjusted,
                [EnumMember(Value = "refunded")]
                Refunded,
                [EnumMember(Value = "refund_due")]
                RefundDue,
                [EnumMember(Value = "voided")]
                Voided,
            }

            public int? Amount {
                get { return GetValue<int?>("amount", false); }
            }

            public TypeEnum LinkedCreditNoteType {
                get { return GetEnum<TypeEnum>("type", true); }
            }

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

            public int? AmountAdjusted {
                get { return GetValue<int?>("amount_adjusted", false); }
            }

            public int? AmountRefunded {
                get { return GetValue<int?>("amount_refunded", false); }
            }

        }
        public class OrderResentOrder : Resource
        {

            public string OrderId {
                get { return GetValue<string>("order_id", true); }
            }

            public string Reason {
                get { return GetValue<string>("reason", false); }
            }

            public int? Amount {
                get { return GetValue<int?>("amount", false); }
            }

        }

        #endregion
    }
}
