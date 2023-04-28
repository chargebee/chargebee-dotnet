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

    public class InAppSubscription : Resource 
    {
    
        public InAppSubscription() { }

        public InAppSubscription(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public InAppSubscription(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public InAppSubscription(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static ProcessReceiptRequest ProcessReceipt(string id)
        {
            string url = ApiUtil.BuildUrl("in_app_subscriptions", CheckNull(id), "process_purchase_command");
            return new ProcessReceiptRequest(url, HttpMethod.POST);
        }
        public static ImportReceiptRequest ImportReceipt(string id)
        {
            string url = ApiUtil.BuildUrl("in_app_subscriptions", CheckNull(id), "import_receipt");
            return new ImportReceiptRequest(url, HttpMethod.POST);
        }
        public static ImportSubscriptionRequest ImportSubscription(string id)
        {
            string url = ApiUtil.BuildUrl("in_app_subscriptions", CheckNull(id), "import_subscription");
            return new ImportSubscriptionRequest(url, HttpMethod.POST);
        }
        public static RetrieveStoreSubsRequest RetrieveStoreSubs(string id)
        {
            string url = ApiUtil.BuildUrl("in_app_subscriptions", CheckNull(id), "retrieve");
            return new RetrieveStoreSubsRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        [Obsolete]
        public string AppId 
        {
            get { return GetValue<string>("app_id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string PlanId 
        {
            get { return GetValue<string>("plan_id", false); }
        }
        public StoreStatusEnum? StoreStatus 
        {
            get { return GetEnum<StoreStatusEnum>("store_status", false); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", false); }
        }
        
        #endregion
        
        #region Requests
        public class ProcessReceiptRequest : EntityRequest<ProcessReceiptRequest> 
        {
            public ProcessReceiptRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ProcessReceiptRequest Receipt(string receipt) 
            {
                m_params.Add("receipt", receipt);
                return this;
            }
            public ProcessReceiptRequest ProductId(string productId) 
            {
                m_params.Add("product[id]", productId);
                return this;
            }
            public ProcessReceiptRequest ProductCurrencyCode(string productCurrencyCode) 
            {
                m_params.Add("product[currency_code]", productCurrencyCode);
                return this;
            }
            public ProcessReceiptRequest ProductPrice(int productPrice) 
            {
                m_params.Add("product[price]", productPrice);
                return this;
            }
            public ProcessReceiptRequest ProductName(string productName) 
            {
                m_params.AddOpt("product[name]", productName);
                return this;
            }
            public ProcessReceiptRequest ProductPriceInDecimal(string productPriceInDecimal) 
            {
                m_params.AddOpt("product[price_in_decimal]", productPriceInDecimal);
                return this;
            }
            public ProcessReceiptRequest ProductPeriod(string productPeriod) 
            {
                m_params.AddOpt("product[period]", productPeriod);
                return this;
            }
            public ProcessReceiptRequest ProductPeriodUnit(string productPeriodUnit) 
            {
                m_params.AddOpt("product[period_unit]", productPeriodUnit);
                return this;
            }
            public ProcessReceiptRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public ProcessReceiptRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
            public ProcessReceiptRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public ProcessReceiptRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
        }
        public class ImportReceiptRequest : EntityRequest<ImportReceiptRequest> 
        {
            public ImportReceiptRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportReceiptRequest Receipt(string receipt) 
            {
                m_params.Add("receipt", receipt);
                return this;
            }
            public ImportReceiptRequest ProductCurrencyCode(string productCurrencyCode) 
            {
                m_params.Add("product[currency_code]", productCurrencyCode);
                return this;
            }
            public ImportReceiptRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public ImportReceiptRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
        }
        public class ImportSubscriptionRequest : EntityRequest<ImportSubscriptionRequest> 
        {
            public ImportSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ImportSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public ImportSubscriptionRequest SubscriptionStartedAt(long subscriptionStartedAt) 
            {
                m_params.Add("subscription[started_at]", subscriptionStartedAt);
                return this;
            }
            public ImportSubscriptionRequest SubscriptionTermStart(long subscriptionTermStart) 
            {
                m_params.Add("subscription[term_start]", subscriptionTermStart);
                return this;
            }
            public ImportSubscriptionRequest SubscriptionTermEnd(long subscriptionTermEnd) 
            {
                m_params.Add("subscription[term_end]", subscriptionTermEnd);
                return this;
            }
            public ImportSubscriptionRequest SubscriptionProductId(string subscriptionProductId) 
            {
                m_params.Add("subscription[product_id]", subscriptionProductId);
                return this;
            }
            public ImportSubscriptionRequest SubscriptionCurrencyCode(string subscriptionCurrencyCode) 
            {
                m_params.Add("subscription[currency_code]", subscriptionCurrencyCode);
                return this;
            }
            public ImportSubscriptionRequest SubscriptionTransactionId(string subscriptionTransactionId) 
            {
                m_params.Add("subscription[transaction_id]", subscriptionTransactionId);
                return this;
            }
            public ImportSubscriptionRequest SubscriptionIsTrial(bool subscriptionIsTrial) 
            {
                m_params.AddOpt("subscription[is_trial]", subscriptionIsTrial);
                return this;
            }
            public ImportSubscriptionRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer[id]", customerId);
                return this;
            }
            public ImportSubscriptionRequest CustomerEmail(string customerEmail) 
            {
                m_params.AddOpt("customer[email]", customerEmail);
                return this;
            }
        }
        public class RetrieveStoreSubsRequest : EntityRequest<RetrieveStoreSubsRequest> 
        {
            public RetrieveStoreSubsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveStoreSubsRequest Receipt(string receipt) 
            {
                m_params.Add("receipt", receipt);
                return this;
            }
        }
        #endregion

        public enum StoreStatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "in_trial")]
            InTrial,
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "cancelled")]
            Cancelled,

        }

        #region Subclasses

        #endregion
    }
}
