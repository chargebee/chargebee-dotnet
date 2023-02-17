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
        #endregion
        
        #region Properties
        [Obsolete]
        public string AppId 
        {
            get { return GetValue<string>("app_id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string PlanId 
        {
            get { return GetValue<string>("plan_id", false); }
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
            public ProcessReceiptRequest ProductName(string productName) 
            {
                m_params.AddOpt("product[name]", productName);
                return this;
            }
            public ProcessReceiptRequest ProductCurrencyCode(string productCurrencyCode) 
            {
                m_params.Add("product[currency_code]", productCurrencyCode);
                return this;
            }
            public ProcessReceiptRequest ProductPrice(long productPrice) 
            {
                m_params.Add("product[price]", productPrice);
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
        #endregion


        #region Subclasses

        #endregion
    }
}
