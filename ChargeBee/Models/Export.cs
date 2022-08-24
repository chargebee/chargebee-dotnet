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
using System.Threading.Tasks;
using System.Net;

namespace ChargeBee.Models
{

    public class Export : Resource 
    {
    
        public Export() { }

        public Export(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Export(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Export(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("exports", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static RevenueRecognitionRequest RevenueRecognition()
        {
            string url = ApiUtil.BuildUrl("exports", "revenue_recognition");
            return new RevenueRecognitionRequest(url, HttpMethod.POST);
        }
        public static DeferredRevenueRequest DeferredRevenue()
        {
            string url = ApiUtil.BuildUrl("exports", "deferred_revenue");
            return new DeferredRevenueRequest(url, HttpMethod.POST);
        }
        public static PlansRequest Plans()
        {
            string url = ApiUtil.BuildUrl("exports", "plans");
            return new PlansRequest(url, HttpMethod.POST);
        }
        public static AddonsRequest Addons()
        {
            string url = ApiUtil.BuildUrl("exports", "addons");
            return new AddonsRequest(url, HttpMethod.POST);
        }
        public static CouponsRequest Coupons()
        {
            string url = ApiUtil.BuildUrl("exports", "coupons");
            return new CouponsRequest(url, HttpMethod.POST);
        }
        public static CustomersRequest Customers()
        {
            string url = ApiUtil.BuildUrl("exports", "customers");
            return new CustomersRequest(url, HttpMethod.POST);
        }
        public static SubscriptionsRequest Subscriptions()
        {
            string url = ApiUtil.BuildUrl("exports", "subscriptions");
            return new SubscriptionsRequest(url, HttpMethod.POST);
        }
        public static InvoicesRequest Invoices()
        {
            string url = ApiUtil.BuildUrl("exports", "invoices");
            return new InvoicesRequest(url, HttpMethod.POST);
        }
        public static CreditNotesRequest CreditNotes()
        {
            string url = ApiUtil.BuildUrl("exports", "credit_notes");
            return new CreditNotesRequest(url, HttpMethod.POST);
        }
        public static TransactionsRequest Transactions()
        {
            string url = ApiUtil.BuildUrl("exports", "transactions");
            return new TransactionsRequest(url, HttpMethod.POST);
        }
        public static OrdersRequest Orders()
        {
            string url = ApiUtil.BuildUrl("exports", "orders");
            return new OrdersRequest(url, HttpMethod.POST);
        }
        public static ItemFamiliesRequest ItemFamilies()
        {
            string url = ApiUtil.BuildUrl("exports", "item_families");
            return new ItemFamiliesRequest(url, HttpMethod.POST);
        }
        public static ItemsRequest Items()
        {
            string url = ApiUtil.BuildUrl("exports", "items");
            return new ItemsRequest(url, HttpMethod.POST);
        }
        public static ItemPricesRequest ItemPrices()
        {
            string url = ApiUtil.BuildUrl("exports", "item_prices");
            return new ItemPricesRequest(url, HttpMethod.POST);
        }
        public static AttachedItemsRequest AttachedItems()
        {
            string url = ApiUtil.BuildUrl("exports", "attached_items");
            return new AttachedItemsRequest(url, HttpMethod.POST);
        }
        public static DifferentialPricesRequest DifferentialPrices()
        {
            string url = ApiUtil.BuildUrl("exports", "differential_prices");
            return new DifferentialPricesRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string OperationType 
        {
            get { return GetValue<string>("operation_type", true); }
        }
        public MimeTypeEnum MimeType 
        {
            get { return GetEnum<MimeTypeEnum>("mime_type", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public ExportDownload Download 
        {
            get { return GetSubResource<ExportDownload>("download"); }
        }
         public Export WaitForExportCompletion()
        {
            int count = 0;
            while (this.Status == Export.StatusEnum.InProcess)
            {
                if (count++ > 50)
                {
                    throw new Exception("Export is taking too long");
                }
                var t = Task.Factory.StartNew(() =>
                {
                    Task.Delay(ApiConfig.ExportSleepMillis).Wait();
                });
                t.Wait();
                EntityRequest<Type> req = Retrieve(Id);
                this.JObj = req.Request().Export.JObj;
            }
            return this;
        }
        #endregion
        
        #region Requests
        public class RevenueRecognitionRequest : EntityRequest<RevenueRecognitionRequest> 
        {
            public RevenueRecognitionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RevenueRecognitionRequest ReportBy(ChargeBee.Models.Enums.ReportByEnum reportBy) 
            {
                m_params.Add("report_by", reportBy);
                return this;
            }
            public RevenueRecognitionRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public RevenueRecognitionRequest ReportFromMonth(int reportFromMonth) 
            {
                m_params.Add("report_from_month", reportFromMonth);
                return this;
            }
            public RevenueRecognitionRequest ReportFromYear(int reportFromYear) 
            {
                m_params.Add("report_from_year", reportFromYear);
                return this;
            }
            public RevenueRecognitionRequest ReportToMonth(int reportToMonth) 
            {
                m_params.Add("report_to_month", reportToMonth);
                return this;
            }
            public RevenueRecognitionRequest ReportToYear(int reportToYear) 
            {
                m_params.Add("report_to_year", reportToYear);
                return this;
            }
            public RevenueRecognitionRequest IncludeDiscounts(bool includeDiscounts) 
            {
                m_params.AddOpt("include_discounts", includeDiscounts);
                return this;
            }
            public StringFilter<RevenueRecognitionRequest> PaymentOwner() 
            {
                return new StringFilter<RevenueRecognitionRequest>("payment_owner", this).SupportsMultiOperators(true);        
            }
            public StringFilter<RevenueRecognitionRequest> ItemId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<RevenueRecognitionRequest> ItemPriceId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("item_price_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<RevenueRecognitionRequest> CancelReasonCode() 
            {
                return new StringFilter<RevenueRecognitionRequest>("cancel_reason_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<RevenueRecognitionRequest> InvoiceId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("invoice[id]", this).SupportsMultiOperators(true);        
            }

            public BooleanFilter<RevenueRecognitionRequest> InvoiceRecurring() 
            {
                return new BooleanFilter<RevenueRecognitionRequest>("invoice[recurring]", this);        
            }

            public EnumFilter<Invoice.StatusEnum, RevenueRecognitionRequest> InvoiceStatus() 
            {
                return new EnumFilter<Invoice.StatusEnum, RevenueRecognitionRequest>("invoice[status]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, RevenueRecognitionRequest> InvoicePriceType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, RevenueRecognitionRequest>("invoice[price_type]", this);        
            }

            public TimestampFilter<RevenueRecognitionRequest> InvoiceDate() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("invoice[date]", this);        
            }

            public TimestampFilter<RevenueRecognitionRequest> InvoicePaidAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("invoice[paid_at]", this);        
            }

            public NumberFilter<int, RevenueRecognitionRequest> InvoiceTotal() 
            {
                return new NumberFilter<int, RevenueRecognitionRequest>("invoice[total]", this);        
            }

            public NumberFilter<int, RevenueRecognitionRequest> InvoiceAmountPaid() 
            {
                return new NumberFilter<int, RevenueRecognitionRequest>("invoice[amount_paid]", this);        
            }

            public NumberFilter<int, RevenueRecognitionRequest> InvoiceAmountAdjusted() 
            {
                return new NumberFilter<int, RevenueRecognitionRequest>("invoice[amount_adjusted]", this);        
            }

            public NumberFilter<int, RevenueRecognitionRequest> InvoiceCreditsApplied() 
            {
                return new NumberFilter<int, RevenueRecognitionRequest>("invoice[credits_applied]", this);        
            }

            public NumberFilter<int, RevenueRecognitionRequest> InvoiceAmountDue() 
            {
                return new NumberFilter<int, RevenueRecognitionRequest>("invoice[amount_due]", this);        
            }

            public EnumFilter<Invoice.DunningStatusEnum, RevenueRecognitionRequest> InvoiceDunningStatus() 
            {
                return new EnumFilter<Invoice.DunningStatusEnum, RevenueRecognitionRequest>("invoice[dunning_status]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<RevenueRecognitionRequest> InvoiceUpdatedAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("invoice[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, RevenueRecognitionRequest> InvoiceChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, RevenueRecognitionRequest>("invoice[channel]", this);        
            }

            public StringFilter<RevenueRecognitionRequest> SubscriptionId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("subscription[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<RevenueRecognitionRequest> SubscriptionCustomerId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("subscription[customer_id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<RevenueRecognitionRequest> SubscriptionPlanId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("subscription[plan_id]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<Subscription.StatusEnum, RevenueRecognitionRequest> SubscriptionStatus() 
            {
                return new EnumFilter<Subscription.StatusEnum, RevenueRecognitionRequest>("subscription[status]", this);        
            }

            public EnumFilter<Subscription.CancelReasonEnum, RevenueRecognitionRequest> SubscriptionCancelReason() 
            {
                return new EnumFilter<Subscription.CancelReasonEnum, RevenueRecognitionRequest>("subscription[cancel_reason]", this).SupportsPresenceOperator(true);        
            }

            public NumberFilter<int, RevenueRecognitionRequest> SubscriptionRemainingBillingCycles() 
            {
                return new NumberFilter<int, RevenueRecognitionRequest>("subscription[remaining_billing_cycles]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<RevenueRecognitionRequest> SubscriptionCreatedAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("subscription[created_at]", this);        
            }

            public TimestampFilter<RevenueRecognitionRequest> SubscriptionActivatedAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("subscription[activated_at]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<RevenueRecognitionRequest> SubscriptionNextBillingAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("subscription[next_billing_at]", this);        
            }

            public TimestampFilter<RevenueRecognitionRequest> SubscriptionCancelledAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("subscription[cancelled_at]", this);        
            }

            public BooleanFilter<RevenueRecognitionRequest> SubscriptionHasScheduledChanges() 
            {
                return new BooleanFilter<RevenueRecognitionRequest>("subscription[has_scheduled_changes]", this);        
            }

            public TimestampFilter<RevenueRecognitionRequest> SubscriptionUpdatedAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("subscription[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, RevenueRecognitionRequest> SubscriptionOfflinePaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, RevenueRecognitionRequest>("subscription[offline_payment_method]", this);        
            }

            public BooleanFilter<RevenueRecognitionRequest> SubscriptionAutoCloseInvoices() 
            {
                return new BooleanFilter<RevenueRecognitionRequest>("subscription[auto_close_invoices]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, RevenueRecognitionRequest> SubscriptionChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, RevenueRecognitionRequest>("subscription[channel]", this);        
            }

            public StringFilter<RevenueRecognitionRequest> CustomerId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("customer[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<RevenueRecognitionRequest> CustomerFirstName() 
            {
                return new StringFilter<RevenueRecognitionRequest>("customer[first_name]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<RevenueRecognitionRequest> CustomerLastName() 
            {
                return new StringFilter<RevenueRecognitionRequest>("customer[last_name]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<RevenueRecognitionRequest> CustomerEmail() 
            {
                return new StringFilter<RevenueRecognitionRequest>("customer[email]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<RevenueRecognitionRequest> CustomerCompany() 
            {
                return new StringFilter<RevenueRecognitionRequest>("customer[company]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<RevenueRecognitionRequest> CustomerPhone() 
            {
                return new StringFilter<RevenueRecognitionRequest>("customer[phone]", this).SupportsPresenceOperator(true);        
            }

            public EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, RevenueRecognitionRequest> CustomerAutoCollection() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, RevenueRecognitionRequest>("customer[auto_collection]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, RevenueRecognitionRequest> CustomerTaxability() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, RevenueRecognitionRequest>("customer[taxability]", this);        
            }

            public TimestampFilter<RevenueRecognitionRequest> CustomerCreatedAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("customer[created_at]", this);        
            }

            public TimestampFilter<RevenueRecognitionRequest> CustomerUpdatedAt() 
            {
                return new TimestampFilter<RevenueRecognitionRequest>("customer[updated_at]", this);        
            }

            public StringFilter<RevenueRecognitionRequest> RelationshipParentId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("relationship[parent_id]", this);        
            }

            public StringFilter<RevenueRecognitionRequest> RelationshipPaymentOwnerId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("relationship[payment_owner_id]", this);        
            }

            public StringFilter<RevenueRecognitionRequest> RelationshipInvoiceOwnerId() 
            {
                return new StringFilter<RevenueRecognitionRequest>("relationship[invoice_owner_id]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, RevenueRecognitionRequest> CustomerOfflinePaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, RevenueRecognitionRequest>("customer[offline_payment_method]", this);        
            }

            public BooleanFilter<RevenueRecognitionRequest> CustomerAutoCloseInvoices() 
            {
                return new BooleanFilter<RevenueRecognitionRequest>("customer[auto_close_invoices]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, RevenueRecognitionRequest> CustomerChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, RevenueRecognitionRequest>("customer[channel]", this);        
            }

        }
        public class DeferredRevenueRequest : EntityRequest<DeferredRevenueRequest> 
        {
            public DeferredRevenueRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeferredRevenueRequest ReportBy(ChargeBee.Models.Enums.ReportByEnum reportBy) 
            {
                m_params.Add("report_by", reportBy);
                return this;
            }
            public DeferredRevenueRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public DeferredRevenueRequest ReportFromMonth(int reportFromMonth) 
            {
                m_params.Add("report_from_month", reportFromMonth);
                return this;
            }
            public DeferredRevenueRequest ReportFromYear(int reportFromYear) 
            {
                m_params.Add("report_from_year", reportFromYear);
                return this;
            }
            public DeferredRevenueRequest ReportToMonth(int reportToMonth) 
            {
                m_params.Add("report_to_month", reportToMonth);
                return this;
            }
            public DeferredRevenueRequest ReportToYear(int reportToYear) 
            {
                m_params.Add("report_to_year", reportToYear);
                return this;
            }
            public DeferredRevenueRequest IncludeDiscounts(bool includeDiscounts) 
            {
                m_params.AddOpt("include_discounts", includeDiscounts);
                return this;
            }
            public StringFilter<DeferredRevenueRequest> PaymentOwner() 
            {
                return new StringFilter<DeferredRevenueRequest>("payment_owner", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DeferredRevenueRequest> ItemId() 
            {
                return new StringFilter<DeferredRevenueRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DeferredRevenueRequest> ItemPriceId() 
            {
                return new StringFilter<DeferredRevenueRequest>("item_price_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DeferredRevenueRequest> CancelReasonCode() 
            {
                return new StringFilter<DeferredRevenueRequest>("cancel_reason_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DeferredRevenueRequest> InvoiceId() 
            {
                return new StringFilter<DeferredRevenueRequest>("invoice[id]", this).SupportsMultiOperators(true);        
            }

            public BooleanFilter<DeferredRevenueRequest> InvoiceRecurring() 
            {
                return new BooleanFilter<DeferredRevenueRequest>("invoice[recurring]", this);        
            }

            public EnumFilter<Invoice.StatusEnum, DeferredRevenueRequest> InvoiceStatus() 
            {
                return new EnumFilter<Invoice.StatusEnum, DeferredRevenueRequest>("invoice[status]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, DeferredRevenueRequest> InvoicePriceType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, DeferredRevenueRequest>("invoice[price_type]", this);        
            }

            public TimestampFilter<DeferredRevenueRequest> InvoiceDate() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("invoice[date]", this);        
            }

            public TimestampFilter<DeferredRevenueRequest> InvoicePaidAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("invoice[paid_at]", this);        
            }

            public NumberFilter<int, DeferredRevenueRequest> InvoiceTotal() 
            {
                return new NumberFilter<int, DeferredRevenueRequest>("invoice[total]", this);        
            }

            public NumberFilter<int, DeferredRevenueRequest> InvoiceAmountPaid() 
            {
                return new NumberFilter<int, DeferredRevenueRequest>("invoice[amount_paid]", this);        
            }

            public NumberFilter<int, DeferredRevenueRequest> InvoiceAmountAdjusted() 
            {
                return new NumberFilter<int, DeferredRevenueRequest>("invoice[amount_adjusted]", this);        
            }

            public NumberFilter<int, DeferredRevenueRequest> InvoiceCreditsApplied() 
            {
                return new NumberFilter<int, DeferredRevenueRequest>("invoice[credits_applied]", this);        
            }

            public NumberFilter<int, DeferredRevenueRequest> InvoiceAmountDue() 
            {
                return new NumberFilter<int, DeferredRevenueRequest>("invoice[amount_due]", this);        
            }

            public EnumFilter<Invoice.DunningStatusEnum, DeferredRevenueRequest> InvoiceDunningStatus() 
            {
                return new EnumFilter<Invoice.DunningStatusEnum, DeferredRevenueRequest>("invoice[dunning_status]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<DeferredRevenueRequest> InvoiceUpdatedAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("invoice[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, DeferredRevenueRequest> InvoiceChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, DeferredRevenueRequest>("invoice[channel]", this);        
            }

            public StringFilter<DeferredRevenueRequest> SubscriptionId() 
            {
                return new StringFilter<DeferredRevenueRequest>("subscription[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<DeferredRevenueRequest> SubscriptionCustomerId() 
            {
                return new StringFilter<DeferredRevenueRequest>("subscription[customer_id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<DeferredRevenueRequest> SubscriptionPlanId() 
            {
                return new StringFilter<DeferredRevenueRequest>("subscription[plan_id]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<Subscription.StatusEnum, DeferredRevenueRequest> SubscriptionStatus() 
            {
                return new EnumFilter<Subscription.StatusEnum, DeferredRevenueRequest>("subscription[status]", this);        
            }

            public EnumFilter<Subscription.CancelReasonEnum, DeferredRevenueRequest> SubscriptionCancelReason() 
            {
                return new EnumFilter<Subscription.CancelReasonEnum, DeferredRevenueRequest>("subscription[cancel_reason]", this).SupportsPresenceOperator(true);        
            }

            public NumberFilter<int, DeferredRevenueRequest> SubscriptionRemainingBillingCycles() 
            {
                return new NumberFilter<int, DeferredRevenueRequest>("subscription[remaining_billing_cycles]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<DeferredRevenueRequest> SubscriptionCreatedAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("subscription[created_at]", this);        
            }

            public TimestampFilter<DeferredRevenueRequest> SubscriptionActivatedAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("subscription[activated_at]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<DeferredRevenueRequest> SubscriptionNextBillingAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("subscription[next_billing_at]", this);        
            }

            public TimestampFilter<DeferredRevenueRequest> SubscriptionCancelledAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("subscription[cancelled_at]", this);        
            }

            public BooleanFilter<DeferredRevenueRequest> SubscriptionHasScheduledChanges() 
            {
                return new BooleanFilter<DeferredRevenueRequest>("subscription[has_scheduled_changes]", this);        
            }

            public TimestampFilter<DeferredRevenueRequest> SubscriptionUpdatedAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("subscription[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, DeferredRevenueRequest> SubscriptionOfflinePaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, DeferredRevenueRequest>("subscription[offline_payment_method]", this);        
            }

            public BooleanFilter<DeferredRevenueRequest> SubscriptionAutoCloseInvoices() 
            {
                return new BooleanFilter<DeferredRevenueRequest>("subscription[auto_close_invoices]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, DeferredRevenueRequest> SubscriptionChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, DeferredRevenueRequest>("subscription[channel]", this);        
            }

            public StringFilter<DeferredRevenueRequest> CustomerId() 
            {
                return new StringFilter<DeferredRevenueRequest>("customer[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<DeferredRevenueRequest> CustomerFirstName() 
            {
                return new StringFilter<DeferredRevenueRequest>("customer[first_name]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<DeferredRevenueRequest> CustomerLastName() 
            {
                return new StringFilter<DeferredRevenueRequest>("customer[last_name]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<DeferredRevenueRequest> CustomerEmail() 
            {
                return new StringFilter<DeferredRevenueRequest>("customer[email]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<DeferredRevenueRequest> CustomerCompany() 
            {
                return new StringFilter<DeferredRevenueRequest>("customer[company]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<DeferredRevenueRequest> CustomerPhone() 
            {
                return new StringFilter<DeferredRevenueRequest>("customer[phone]", this).SupportsPresenceOperator(true);        
            }

            public EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, DeferredRevenueRequest> CustomerAutoCollection() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, DeferredRevenueRequest>("customer[auto_collection]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, DeferredRevenueRequest> CustomerTaxability() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, DeferredRevenueRequest>("customer[taxability]", this);        
            }

            public TimestampFilter<DeferredRevenueRequest> CustomerCreatedAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("customer[created_at]", this);        
            }

            public TimestampFilter<DeferredRevenueRequest> CustomerUpdatedAt() 
            {
                return new TimestampFilter<DeferredRevenueRequest>("customer[updated_at]", this);        
            }

            public StringFilter<DeferredRevenueRequest> RelationshipParentId() 
            {
                return new StringFilter<DeferredRevenueRequest>("relationship[parent_id]", this);        
            }

            public StringFilter<DeferredRevenueRequest> RelationshipPaymentOwnerId() 
            {
                return new StringFilter<DeferredRevenueRequest>("relationship[payment_owner_id]", this);        
            }

            public StringFilter<DeferredRevenueRequest> RelationshipInvoiceOwnerId() 
            {
                return new StringFilter<DeferredRevenueRequest>("relationship[invoice_owner_id]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, DeferredRevenueRequest> CustomerOfflinePaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, DeferredRevenueRequest>("customer[offline_payment_method]", this);        
            }

            public BooleanFilter<DeferredRevenueRequest> CustomerAutoCloseInvoices() 
            {
                return new BooleanFilter<DeferredRevenueRequest>("customer[auto_close_invoices]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, DeferredRevenueRequest> CustomerChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, DeferredRevenueRequest>("customer[channel]", this);        
            }

        }
        public class PlansRequest : EntityRequest<PlansRequest> 
        {
            public PlansRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<PlansRequest> CurrencyCode() 
            {
                return new StringFilter<PlansRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<PlansRequest> PlanId() 
            {
                return new StringFilter<PlansRequest>("plan[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<PlansRequest> PlanName() 
            {
                return new StringFilter<PlansRequest>("plan[name]", this).SupportsMultiOperators(true);        
            }

            public NumberFilter<int, PlansRequest> PlanPrice() 
            {
                return new NumberFilter<int, PlansRequest>("plan[price]", this);        
            }

            public NumberFilter<int, PlansRequest> PlanPeriod() 
            {
                return new NumberFilter<int, PlansRequest>("plan[period]", this);        
            }

            public EnumFilter<Plan.PeriodUnitEnum, PlansRequest> PlanPeriodUnit() 
            {
                return new EnumFilter<Plan.PeriodUnitEnum, PlansRequest>("plan[period_unit]", this);        
            }

            public NumberFilter<int, PlansRequest> PlanTrialPeriod() 
            {
                return new NumberFilter<int, PlansRequest>("plan[trial_period]", this).SupportsPresenceOperator(true);        
            }

            public EnumFilter<Plan.TrialPeriodUnitEnum, PlansRequest> PlanTrialPeriodUnit() 
            {
                return new EnumFilter<Plan.TrialPeriodUnitEnum, PlansRequest>("plan[trial_period_unit]", this);        
            }

            public EnumFilter<Plan.AddonApplicabilityEnum, PlansRequest> PlanAddonApplicability() 
            {
                return new EnumFilter<Plan.AddonApplicabilityEnum, PlansRequest>("plan[addon_applicability]", this);        
            }

            public BooleanFilter<PlansRequest> PlanGiftable() 
            {
                return new BooleanFilter<PlansRequest>("plan[giftable]", this);        
            }

            public EnumFilter<Plan.StatusEnum, PlansRequest> PlanStatus() 
            {
                return new EnumFilter<Plan.StatusEnum, PlansRequest>("plan[status]", this);        
            }

            public TimestampFilter<PlansRequest> PlanUpdatedAt() 
            {
                return new TimestampFilter<PlansRequest>("plan[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, PlansRequest> PlanChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, PlansRequest>("plan[channel]", this);        
            }

        }
        public class AddonsRequest : EntityRequest<AddonsRequest> 
        {
            public AddonsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<AddonsRequest> CurrencyCode() 
            {
                return new StringFilter<AddonsRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<AddonsRequest> AddonId() 
            {
                return new StringFilter<AddonsRequest>("addon[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<AddonsRequest> AddonName() 
            {
                return new StringFilter<AddonsRequest>("addon[name]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<Addon.ChargeTypeEnum, AddonsRequest> AddonChargeType() 
            {
                return new EnumFilter<Addon.ChargeTypeEnum, AddonsRequest>("addon[charge_type]", this);        
            }

            public NumberFilter<int, AddonsRequest> AddonPrice() 
            {
                return new NumberFilter<int, AddonsRequest>("addon[price]", this);        
            }

            public NumberFilter<int, AddonsRequest> AddonPeriod() 
            {
                return new NumberFilter<int, AddonsRequest>("addon[period]", this);        
            }

            public EnumFilter<Addon.PeriodUnitEnum, AddonsRequest> AddonPeriodUnit() 
            {
                return new EnumFilter<Addon.PeriodUnitEnum, AddonsRequest>("addon[period_unit]", this);        
            }

            public EnumFilter<Addon.StatusEnum, AddonsRequest> AddonStatus() 
            {
                return new EnumFilter<Addon.StatusEnum, AddonsRequest>("addon[status]", this);        
            }

            public TimestampFilter<AddonsRequest> AddonUpdatedAt() 
            {
                return new TimestampFilter<AddonsRequest>("addon[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, AddonsRequest> AddonChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, AddonsRequest>("addon[channel]", this);        
            }

        }
        public class CouponsRequest : EntityRequest<CouponsRequest> 
        {
            public CouponsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<CouponsRequest> CurrencyCode() 
            {
                return new StringFilter<CouponsRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CouponsRequest> CouponId() 
            {
                return new StringFilter<CouponsRequest>("coupon[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<CouponsRequest> CouponName() 
            {
                return new StringFilter<CouponsRequest>("coupon[name]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<Coupon.DiscountTypeEnum, CouponsRequest> CouponDiscountType() 
            {
                return new EnumFilter<Coupon.DiscountTypeEnum, CouponsRequest>("coupon[discount_type]", this);        
            }

            public EnumFilter<Coupon.DurationTypeEnum, CouponsRequest> CouponDurationType() 
            {
                return new EnumFilter<Coupon.DurationTypeEnum, CouponsRequest>("coupon[duration_type]", this);        
            }

            public EnumFilter<Coupon.StatusEnum, CouponsRequest> CouponStatus() 
            {
                return new EnumFilter<Coupon.StatusEnum, CouponsRequest>("coupon[status]", this);        
            }

            public EnumFilter<Coupon.ApplyOnEnum, CouponsRequest> CouponApplyOn() 
            {
                return new EnumFilter<Coupon.ApplyOnEnum, CouponsRequest>("coupon[apply_on]", this);        
            }

            public TimestampFilter<CouponsRequest> CouponCreatedAt() 
            {
                return new TimestampFilter<CouponsRequest>("coupon[created_at]", this);        
            }

            public TimestampFilter<CouponsRequest> CouponUpdatedAt() 
            {
                return new TimestampFilter<CouponsRequest>("coupon[updated_at]", this);        
            }

        }
        public class CustomersRequest : EntityRequest<CustomersRequest> 
        {
            public CustomersRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<CustomersRequest> CustomerId() 
            {
                return new StringFilter<CustomersRequest>("customer[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<CustomersRequest> CustomerFirstName() 
            {
                return new StringFilter<CustomersRequest>("customer[first_name]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<CustomersRequest> CustomerLastName() 
            {
                return new StringFilter<CustomersRequest>("customer[last_name]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<CustomersRequest> CustomerEmail() 
            {
                return new StringFilter<CustomersRequest>("customer[email]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<CustomersRequest> CustomerCompany() 
            {
                return new StringFilter<CustomersRequest>("customer[company]", this).SupportsPresenceOperator(true);        
            }

            public StringFilter<CustomersRequest> CustomerPhone() 
            {
                return new StringFilter<CustomersRequest>("customer[phone]", this).SupportsPresenceOperator(true);        
            }

            public EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, CustomersRequest> CustomerAutoCollection() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.AutoCollectionEnum, CustomersRequest>("customer[auto_collection]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, CustomersRequest> CustomerTaxability() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.TaxabilityEnum, CustomersRequest>("customer[taxability]", this);        
            }

            public TimestampFilter<CustomersRequest> CustomerCreatedAt() 
            {
                return new TimestampFilter<CustomersRequest>("customer[created_at]", this);        
            }

            public TimestampFilter<CustomersRequest> CustomerUpdatedAt() 
            {
                return new TimestampFilter<CustomersRequest>("customer[updated_at]", this);        
            }

            public StringFilter<CustomersRequest> RelationshipParentId() 
            {
                return new StringFilter<CustomersRequest>("relationship[parent_id]", this);        
            }

            public StringFilter<CustomersRequest> RelationshipPaymentOwnerId() 
            {
                return new StringFilter<CustomersRequest>("relationship[payment_owner_id]", this);        
            }

            public StringFilter<CustomersRequest> RelationshipInvoiceOwnerId() 
            {
                return new StringFilter<CustomersRequest>("relationship[invoice_owner_id]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, CustomersRequest> CustomerOfflinePaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, CustomersRequest>("customer[offline_payment_method]", this);        
            }

            public BooleanFilter<CustomersRequest> CustomerAutoCloseInvoices() 
            {
                return new BooleanFilter<CustomersRequest>("customer[auto_close_invoices]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, CustomersRequest> CustomerChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, CustomersRequest>("customer[channel]", this);        
            }

        }
        public class SubscriptionsRequest : EntityRequest<SubscriptionsRequest> 
        {
            public SubscriptionsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<SubscriptionsRequest> ItemId() 
            {
                return new StringFilter<SubscriptionsRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<SubscriptionsRequest> ItemPriceId() 
            {
                return new StringFilter<SubscriptionsRequest>("item_price_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<SubscriptionsRequest> CancelReasonCode() 
            {
                return new StringFilter<SubscriptionsRequest>("cancel_reason_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<SubscriptionsRequest> SubscriptionId() 
            {
                return new StringFilter<SubscriptionsRequest>("subscription[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<SubscriptionsRequest> SubscriptionCustomerId() 
            {
                return new StringFilter<SubscriptionsRequest>("subscription[customer_id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<SubscriptionsRequest> SubscriptionPlanId() 
            {
                return new StringFilter<SubscriptionsRequest>("subscription[plan_id]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<Subscription.StatusEnum, SubscriptionsRequest> SubscriptionStatus() 
            {
                return new EnumFilter<Subscription.StatusEnum, SubscriptionsRequest>("subscription[status]", this);        
            }

            public EnumFilter<Subscription.CancelReasonEnum, SubscriptionsRequest> SubscriptionCancelReason() 
            {
                return new EnumFilter<Subscription.CancelReasonEnum, SubscriptionsRequest>("subscription[cancel_reason]", this).SupportsPresenceOperator(true);        
            }

            public NumberFilter<int, SubscriptionsRequest> SubscriptionRemainingBillingCycles() 
            {
                return new NumberFilter<int, SubscriptionsRequest>("subscription[remaining_billing_cycles]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<SubscriptionsRequest> SubscriptionCreatedAt() 
            {
                return new TimestampFilter<SubscriptionsRequest>("subscription[created_at]", this);        
            }

            public TimestampFilter<SubscriptionsRequest> SubscriptionActivatedAt() 
            {
                return new TimestampFilter<SubscriptionsRequest>("subscription[activated_at]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<SubscriptionsRequest> SubscriptionNextBillingAt() 
            {
                return new TimestampFilter<SubscriptionsRequest>("subscription[next_billing_at]", this);        
            }

            public TimestampFilter<SubscriptionsRequest> SubscriptionCancelledAt() 
            {
                return new TimestampFilter<SubscriptionsRequest>("subscription[cancelled_at]", this);        
            }

            public BooleanFilter<SubscriptionsRequest> SubscriptionHasScheduledChanges() 
            {
                return new BooleanFilter<SubscriptionsRequest>("subscription[has_scheduled_changes]", this);        
            }

            public TimestampFilter<SubscriptionsRequest> SubscriptionUpdatedAt() 
            {
                return new TimestampFilter<SubscriptionsRequest>("subscription[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, SubscriptionsRequest> SubscriptionOfflinePaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.OfflinePaymentMethodEnum, SubscriptionsRequest>("subscription[offline_payment_method]", this);        
            }

            public BooleanFilter<SubscriptionsRequest> SubscriptionAutoCloseInvoices() 
            {
                return new BooleanFilter<SubscriptionsRequest>("subscription[auto_close_invoices]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, SubscriptionsRequest> SubscriptionChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, SubscriptionsRequest>("subscription[channel]", this);        
            }

        }
        public class InvoicesRequest : EntityRequest<InvoicesRequest> 
        {
            public InvoicesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<InvoicesRequest> PaymentOwner() 
            {
                return new StringFilter<InvoicesRequest>("payment_owner", this).SupportsMultiOperators(true);        
            }
            public StringFilter<InvoicesRequest> InvoiceId() 
            {
                return new StringFilter<InvoicesRequest>("invoice[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<InvoicesRequest> InvoiceSubscriptionId() 
            {
                return new StringFilter<InvoicesRequest>("invoice[subscription_id]", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }

            public StringFilter<InvoicesRequest> InvoiceCustomerId() 
            {
                return new StringFilter<InvoicesRequest>("invoice[customer_id]", this).SupportsMultiOperators(true);        
            }

            public BooleanFilter<InvoicesRequest> InvoiceRecurring() 
            {
                return new BooleanFilter<InvoicesRequest>("invoice[recurring]", this);        
            }

            public EnumFilter<Invoice.StatusEnum, InvoicesRequest> InvoiceStatus() 
            {
                return new EnumFilter<Invoice.StatusEnum, InvoicesRequest>("invoice[status]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, InvoicesRequest> InvoicePriceType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, InvoicesRequest>("invoice[price_type]", this);        
            }

            public TimestampFilter<InvoicesRequest> InvoiceDate() 
            {
                return new TimestampFilter<InvoicesRequest>("invoice[date]", this);        
            }

            public TimestampFilter<InvoicesRequest> InvoicePaidAt() 
            {
                return new TimestampFilter<InvoicesRequest>("invoice[paid_at]", this);        
            }

            public NumberFilter<int, InvoicesRequest> InvoiceTotal() 
            {
                return new NumberFilter<int, InvoicesRequest>("invoice[total]", this);        
            }

            public NumberFilter<int, InvoicesRequest> InvoiceAmountPaid() 
            {
                return new NumberFilter<int, InvoicesRequest>("invoice[amount_paid]", this);        
            }

            public NumberFilter<int, InvoicesRequest> InvoiceAmountAdjusted() 
            {
                return new NumberFilter<int, InvoicesRequest>("invoice[amount_adjusted]", this);        
            }

            public NumberFilter<int, InvoicesRequest> InvoiceCreditsApplied() 
            {
                return new NumberFilter<int, InvoicesRequest>("invoice[credits_applied]", this);        
            }

            public NumberFilter<int, InvoicesRequest> InvoiceAmountDue() 
            {
                return new NumberFilter<int, InvoicesRequest>("invoice[amount_due]", this);        
            }

            public EnumFilter<Invoice.DunningStatusEnum, InvoicesRequest> InvoiceDunningStatus() 
            {
                return new EnumFilter<Invoice.DunningStatusEnum, InvoicesRequest>("invoice[dunning_status]", this).SupportsPresenceOperator(true);        
            }

            public TimestampFilter<InvoicesRequest> InvoiceUpdatedAt() 
            {
                return new TimestampFilter<InvoicesRequest>("invoice[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, InvoicesRequest> InvoiceChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, InvoicesRequest>("invoice[channel]", this);        
            }

        }
        public class CreditNotesRequest : EntityRequest<CreditNotesRequest> 
        {
            public CreditNotesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<CreditNotesRequest> CreditNoteId() 
            {
                return new StringFilter<CreditNotesRequest>("credit_note[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<CreditNotesRequest> CreditNoteCustomerId() 
            {
                return new StringFilter<CreditNotesRequest>("credit_note[customer_id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<CreditNotesRequest> CreditNoteSubscriptionId() 
            {
                return new StringFilter<CreditNotesRequest>("credit_note[subscription_id]", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }

            public StringFilter<CreditNotesRequest> CreditNoteReferenceInvoiceId() 
            {
                return new StringFilter<CreditNotesRequest>("credit_note[reference_invoice_id]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<CreditNote.TypeEnum, CreditNotesRequest> CreditNoteType() 
            {
                return new EnumFilter<CreditNote.TypeEnum, CreditNotesRequest>("credit_note[type]", this);        
            }

            public EnumFilter<CreditNote.ReasonCodeEnum, CreditNotesRequest> CreditNoteReasonCode() 
            {
                return new EnumFilter<CreditNote.ReasonCodeEnum, CreditNotesRequest>("credit_note[reason_code]", this);        
            }

            public StringFilter<CreditNotesRequest> CreditNoteCreateReasonCode() 
            {
                return new StringFilter<CreditNotesRequest>("credit_note[create_reason_code]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<CreditNote.StatusEnum, CreditNotesRequest> CreditNoteStatus() 
            {
                return new EnumFilter<CreditNote.StatusEnum, CreditNotesRequest>("credit_note[status]", this);        
            }

            public TimestampFilter<CreditNotesRequest> CreditNoteDate() 
            {
                return new TimestampFilter<CreditNotesRequest>("credit_note[date]", this);        
            }

            public NumberFilter<int, CreditNotesRequest> CreditNoteTotal() 
            {
                return new NumberFilter<int, CreditNotesRequest>("credit_note[total]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, CreditNotesRequest> CreditNotePriceType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, CreditNotesRequest>("credit_note[price_type]", this);        
            }

            public NumberFilter<int, CreditNotesRequest> CreditNoteAmountAllocated() 
            {
                return new NumberFilter<int, CreditNotesRequest>("credit_note[amount_allocated]", this);        
            }

            public NumberFilter<int, CreditNotesRequest> CreditNoteAmountRefunded() 
            {
                return new NumberFilter<int, CreditNotesRequest>("credit_note[amount_refunded]", this);        
            }

            public NumberFilter<int, CreditNotesRequest> CreditNoteAmountAvailable() 
            {
                return new NumberFilter<int, CreditNotesRequest>("credit_note[amount_available]", this);        
            }

            public TimestampFilter<CreditNotesRequest> CreditNoteVoidedAt() 
            {
                return new TimestampFilter<CreditNotesRequest>("credit_note[voided_at]", this);        
            }

            public TimestampFilter<CreditNotesRequest> CreditNoteUpdatedAt() 
            {
                return new TimestampFilter<CreditNotesRequest>("credit_note[updated_at]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, CreditNotesRequest> CreditNoteChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, CreditNotesRequest>("credit_note[channel]", this);        
            }

        }
        public class TransactionsRequest : EntityRequest<TransactionsRequest> 
        {
            public TransactionsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<TransactionsRequest> TransactionId() 
            {
                return new StringFilter<TransactionsRequest>("transaction[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<TransactionsRequest> TransactionCustomerId() 
            {
                return new StringFilter<TransactionsRequest>("transaction[customer_id]", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }

            public StringFilter<TransactionsRequest> TransactionSubscriptionId() 
            {
                return new StringFilter<TransactionsRequest>("transaction[subscription_id]", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }

            public StringFilter<TransactionsRequest> TransactionPaymentSourceId() 
            {
                return new StringFilter<TransactionsRequest>("transaction[payment_source_id]", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }

            public EnumFilter<ChargeBee.Models.Enums.PaymentMethodEnum, TransactionsRequest> TransactionPaymentMethod() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PaymentMethodEnum, TransactionsRequest>("transaction[payment_method]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.GatewayEnum, TransactionsRequest> TransactionGateway() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.GatewayEnum, TransactionsRequest>("transaction[gateway]", this);        
            }

            public StringFilter<TransactionsRequest> TransactionGatewayAccountId() 
            {
                return new StringFilter<TransactionsRequest>("transaction[gateway_account_id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<TransactionsRequest> TransactionIdAtGateway() 
            {
                return new StringFilter<TransactionsRequest>("transaction[id_at_gateway]", this);        
            }

            public StringFilter<TransactionsRequest> TransactionReferenceNumber() 
            {
                return new StringFilter<TransactionsRequest>("transaction[reference_number]", this).SupportsPresenceOperator(true);        
            }

            public EnumFilter<Transaction.TypeEnum, TransactionsRequest> TransactionType() 
            {
                return new EnumFilter<Transaction.TypeEnum, TransactionsRequest>("transaction[type]", this);        
            }

            public TimestampFilter<TransactionsRequest> TransactionDate() 
            {
                return new TimestampFilter<TransactionsRequest>("transaction[date]", this);        
            }

            public NumberFilter<int, TransactionsRequest> TransactionAmount() 
            {
                return new NumberFilter<int, TransactionsRequest>("transaction[amount]", this);        
            }

            public NumberFilter<int, TransactionsRequest> TransactionAmountCapturable() 
            {
                return new NumberFilter<int, TransactionsRequest>("transaction[amount_capturable]", this);        
            }

            public EnumFilter<Transaction.StatusEnum, TransactionsRequest> TransactionStatus() 
            {
                return new EnumFilter<Transaction.StatusEnum, TransactionsRequest>("transaction[status]", this);        
            }

            public TimestampFilter<TransactionsRequest> TransactionUpdatedAt() 
            {
                return new TimestampFilter<TransactionsRequest>("transaction[updated_at]", this);        
            }

        }
        public class OrdersRequest : EntityRequest<OrdersRequest> 
        {
            public OrdersRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public NumberFilter<int, OrdersRequest> Total() 
            {
                return new NumberFilter<int, OrdersRequest>("total", this);        
            }
            public StringFilter<OrdersRequest> OrderId() 
            {
                return new StringFilter<OrdersRequest>("order[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<OrdersRequest> OrderSubscriptionId() 
            {
                return new StringFilter<OrdersRequest>("order[subscription_id]", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }

            public StringFilter<OrdersRequest> OrderCustomerId() 
            {
                return new StringFilter<OrdersRequest>("order[customer_id]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<Order.StatusEnum, OrdersRequest> OrderStatus() 
            {
                return new EnumFilter<Order.StatusEnum, OrdersRequest>("order[status]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, OrdersRequest> OrderPriceType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PriceTypeEnum, OrdersRequest>("order[price_type]", this);        
            }

            public TimestampFilter<OrdersRequest> OrderOrderDate() 
            {
                return new TimestampFilter<OrdersRequest>("order[order_date]", this);        
            }

            public TimestampFilter<OrdersRequest> OrderShippingDate() 
            {
                return new TimestampFilter<OrdersRequest>("order[shipping_date]", this);        
            }

            public TimestampFilter<OrdersRequest> OrderShippedAt() 
            {
                return new TimestampFilter<OrdersRequest>("order[shipped_at]", this);        
            }

            public TimestampFilter<OrdersRequest> OrderDeliveredAt() 
            {
                return new TimestampFilter<OrdersRequest>("order[delivered_at]", this);        
            }

            public TimestampFilter<OrdersRequest> OrderCancelledAt() 
            {
                return new TimestampFilter<OrdersRequest>("order[cancelled_at]", this);        
            }

            public NumberFilter<int, OrdersRequest> OrderAmountPaid() 
            {
                return new NumberFilter<int, OrdersRequest>("order[amount_paid]", this);        
            }

            public NumberFilter<int, OrdersRequest> OrderRefundableCredits() 
            {
                return new NumberFilter<int, OrdersRequest>("order[refundable_credits]", this);        
            }

            public NumberFilter<int, OrdersRequest> OrderRefundableCreditsIssued() 
            {
                return new NumberFilter<int, OrdersRequest>("order[refundable_credits_issued]", this);        
            }

            public TimestampFilter<OrdersRequest> OrderUpdatedAt() 
            {
                return new TimestampFilter<OrdersRequest>("order[updated_at]", this);        
            }

            public EnumFilter<Order.ResentStatusEnum, OrdersRequest> OrderResentStatus() 
            {
                return new EnumFilter<Order.ResentStatusEnum, OrdersRequest>("order[resent_status]", this);        
            }

            public BooleanFilter<OrdersRequest> OrderIsResent() 
            {
                return new BooleanFilter<OrdersRequest>("order[is_resent]", this);        
            }

            public StringFilter<OrdersRequest> OrderOriginalOrderId() 
            {
                return new StringFilter<OrdersRequest>("order[original_order_id]", this);        
            }

        }
        public class ItemFamiliesRequest : EntityRequest<ItemFamiliesRequest> 
        {
            public ItemFamiliesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<ItemFamiliesRequest> ItemFamilyId() 
            {
                return new StringFilter<ItemFamiliesRequest>("item_family[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<ItemFamiliesRequest> ItemFamilyName() 
            {
                return new StringFilter<ItemFamiliesRequest>("item_family[name]", this);        
            }

            public TimestampFilter<ItemFamiliesRequest> ItemFamilyUpdatedAt() 
            {
                return new TimestampFilter<ItemFamiliesRequest>("item_family[updated_at]", this);        
            }

        }
        public class ItemsRequest : EntityRequest<ItemsRequest> 
        {
            public ItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<ItemsRequest> ItemId() 
            {
                return new StringFilter<ItemsRequest>("item[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<ItemsRequest> ItemItemFamilyId() 
            {
                return new StringFilter<ItemsRequest>("item[item_family_id]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<Item.TypeEnum, ItemsRequest> ItemType() 
            {
                return new EnumFilter<Item.TypeEnum, ItemsRequest>("item[type]", this);        
            }

            public StringFilter<ItemsRequest> ItemName() 
            {
                return new StringFilter<ItemsRequest>("item[name]", this);        
            }

            public EnumFilter<Item.ItemApplicabilityEnum, ItemsRequest> ItemItemApplicability() 
            {
                return new EnumFilter<Item.ItemApplicabilityEnum, ItemsRequest>("item[item_applicability]", this);        
            }

            public EnumFilter<Item.StatusEnum, ItemsRequest> ItemStatus() 
            {
                return new EnumFilter<Item.StatusEnum, ItemsRequest>("item[status]", this);        
            }

            public BooleanFilter<ItemsRequest> ItemIsGiftable() 
            {
                return new BooleanFilter<ItemsRequest>("item[is_giftable]", this);        
            }

            public TimestampFilter<ItemsRequest> ItemUpdatedAt() 
            {
                return new TimestampFilter<ItemsRequest>("item[updated_at]", this);        
            }

            public BooleanFilter<ItemsRequest> ItemEnabledForCheckout() 
            {
                return new BooleanFilter<ItemsRequest>("item[enabled_for_checkout]", this);        
            }

            public BooleanFilter<ItemsRequest> ItemEnabledInPortal() 
            {
                return new BooleanFilter<ItemsRequest>("item[enabled_in_portal]", this);        
            }

            public BooleanFilter<ItemsRequest> ItemMetered() 
            {
                return new BooleanFilter<ItemsRequest>("item[metered]", this);        
            }

            public EnumFilter<Item.UsageCalculationEnum, ItemsRequest> ItemUsageCalculation() 
            {
                return new EnumFilter<Item.UsageCalculationEnum, ItemsRequest>("item[usage_calculation]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, ItemsRequest> ItemChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, ItemsRequest>("item[channel]", this);        
            }

        }
        public class ItemPricesRequest : EntityRequest<ItemPricesRequest> 
        {
            public ItemPricesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<ItemPricesRequest> ItemFamilyId() 
            {
                return new StringFilter<ItemPricesRequest>("item_family_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, ItemPricesRequest> ItemType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, ItemPricesRequest>("item_type", this);        
            }
            public StringFilter<ItemPricesRequest> CurrencyCode() 
            {
                return new StringFilter<ItemPricesRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<ItemPricesRequest> ItemPriceId() 
            {
                return new StringFilter<ItemPricesRequest>("item_price[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<ItemPricesRequest> ItemPriceName() 
            {
                return new StringFilter<ItemPricesRequest>("item_price[name]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, ItemPricesRequest> ItemPricePricingModel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.PricingModelEnum, ItemPricesRequest>("item_price[pricing_model]", this);        
            }

            public StringFilter<ItemPricesRequest> ItemPriceItemId() 
            {
                return new StringFilter<ItemPricesRequest>("item_price[item_id]", this).SupportsMultiOperators(true);        
            }

            public NumberFilter<int, ItemPricesRequest> ItemPriceTrialPeriod() 
            {
                return new NumberFilter<int, ItemPricesRequest>("item_price[trial_period]", this);        
            }

            public EnumFilter<ItemPrice.TrialPeriodUnitEnum, ItemPricesRequest> ItemPriceTrialPeriodUnit() 
            {
                return new EnumFilter<ItemPrice.TrialPeriodUnitEnum, ItemPricesRequest>("item_price[trial_period_unit]", this);        
            }

            public EnumFilter<ItemPrice.StatusEnum, ItemPricesRequest> ItemPriceStatus() 
            {
                return new EnumFilter<ItemPrice.StatusEnum, ItemPricesRequest>("item_price[status]", this);        
            }

            public TimestampFilter<ItemPricesRequest> ItemPriceUpdatedAt() 
            {
                return new TimestampFilter<ItemPricesRequest>("item_price[updated_at]", this);        
            }

            public EnumFilter<ItemPrice.PeriodUnitEnum, ItemPricesRequest> ItemPricePeriodUnit() 
            {
                return new EnumFilter<ItemPrice.PeriodUnitEnum, ItemPricesRequest>("item_price[period_unit]", this);        
            }

            public NumberFilter<int, ItemPricesRequest> ItemPricePeriod() 
            {
                return new NumberFilter<int, ItemPricesRequest>("item_price[period]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChannelEnum, ItemPricesRequest> ItemPriceChannel() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChannelEnum, ItemPricesRequest>("item_price[channel]", this);        
            }

        }
        public class AttachedItemsRequest : EntityRequest<AttachedItemsRequest> 
        {
            public AttachedItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, AttachedItemsRequest> ItemType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, AttachedItemsRequest>("item_type", this);        
            }
            public StringFilter<AttachedItemsRequest> AttachedItemId() 
            {
                return new StringFilter<AttachedItemsRequest>("attached_item[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<AttachedItemsRequest> AttachedItemItemId() 
            {
                return new StringFilter<AttachedItemsRequest>("attached_item[item_id]", this).SupportsMultiOperators(true);        
            }

            public EnumFilter<AttachedItem.TypeEnum, AttachedItemsRequest> AttachedItemType() 
            {
                return new EnumFilter<AttachedItem.TypeEnum, AttachedItemsRequest>("attached_item[type]", this);        
            }

            public EnumFilter<ChargeBee.Models.Enums.ChargeOnEventEnum, AttachedItemsRequest> AttachedItemChargeOnEvent() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChargeOnEventEnum, AttachedItemsRequest>("attached_item[charge_on_event]", this);        
            }

            public StringFilter<AttachedItemsRequest> AttachedItemParentItemId() 
            {
                return new StringFilter<AttachedItemsRequest>("attached_item[parent_item_id]", this).SupportsMultiOperators(true);        
            }

        }
        public class DifferentialPricesRequest : EntityRequest<DifferentialPricesRequest> 
        {
            public DifferentialPricesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public StringFilter<DifferentialPricesRequest> ItemId() 
            {
                return new StringFilter<DifferentialPricesRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DifferentialPricesRequest> DifferentialPriceItemPriceId() 
            {
                return new StringFilter<DifferentialPricesRequest>("differential_price[item_price_id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<DifferentialPricesRequest> DifferentialPriceId() 
            {
                return new StringFilter<DifferentialPricesRequest>("differential_price[id]", this).SupportsMultiOperators(true);        
            }

            public StringFilter<DifferentialPricesRequest> DifferentialPriceParentItemId() 
            {
                return new StringFilter<DifferentialPricesRequest>("differential_price[parent_item_id]", this).SupportsMultiOperators(true);        
            }

        }
        #endregion

        public enum MimeTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "pdf")]
            Pdf,
            [EnumMember(Value = "zip")]
            Zip,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "in_process")]
            InProcess,
            [EnumMember(Value = "completed")]
            Completed,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class ExportDownload : Resource
        {

            public string DownloadUrl {
                get { return GetValue<string>("download_url", true); }
            }

            public DateTime ValidTill {
                get { return (DateTime)GetDateTime("valid_till", true); }
            }

            public string MimeType {
                get { return GetValue<string>("mime_type", false); }
            }

        }

        #endregion
    }
}
