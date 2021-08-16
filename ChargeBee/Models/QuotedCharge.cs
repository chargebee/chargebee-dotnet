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

    public class QuotedCharge : Resource 
    {
    
        public QuotedCharge() { }

        public QuotedCharge(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public QuotedCharge(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public QuotedCharge(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public List<QuotedChargeCharge> Charges 
        {
            get { return GetResourceList<QuotedChargeCharge>("charges"); }
        }
        public List<QuotedChargeAddon> Addons 
        {
            get { return GetResourceList<QuotedChargeAddon>("addons"); }
        }
        public List<QuotedChargeInvoiceItem> InvoiceItems 
        {
            get { return GetResourceList<QuotedChargeInvoiceItem>("invoice_items"); }
        }
        public List<QuotedChargeItemTier> ItemTiers 
        {
            get { return GetResourceList<QuotedChargeItemTier>("item_tiers"); }
        }
        public List<QuotedChargeCoupon> Coupons 
        {
            get { return GetResourceList<QuotedChargeCoupon>("coupons"); }
        }
        
        #endregion
        


        #region Subclasses
        public class QuotedChargeCharge : Resource
        {

            public int? Amount() {
                return GetValue<int?>("amount", false);
            }

            public string AmountInDecimal() {
                return GetValue<string>("amount_in_decimal", false);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

            public int? ServicePeriodInDays() {
                return GetValue<int?>("service_period_in_days", false);
            }

            public AvalaraSaleTypeEnum? AvalaraSaleType() {
                return GetEnum<AvalaraSaleTypeEnum>("avalara_sale_type", false);
            }

            public int? AvalaraTransactionType() {
                return GetValue<int?>("avalara_transaction_type", false);
            }

            public int? AvalaraServiceType() {
                return GetValue<int?>("avalara_service_type", false);
            }

        }
        public class QuotedChargeAddon : Resource
        {

            public string Id() {
                return GetValue<string>("id", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public int? UnitPrice() {
                return GetValue<int?>("unit_price", false);
            }

            public string QuantityInDecimal() {
                return GetValue<string>("quantity_in_decimal", false);
            }

            public string UnitPriceInDecimal() {
                return GetValue<string>("unit_price_in_decimal", false);
            }

            public int? ServicePeriod() {
                return GetValue<int?>("service_period", false);
            }

        }
        public class QuotedChargeInvoiceItem : Resource
        {

            public string ItemPriceId() {
                return GetValue<string>("item_price_id", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public string QuantityInDecimal() {
                return GetValue<string>("quantity_in_decimal", false);
            }

            public int? UnitPrice() {
                return GetValue<int?>("unit_price", false);
            }

            public string UnitPriceInDecimal() {
                return GetValue<string>("unit_price_in_decimal", false);
            }

            public int? ServicePeriodDays() {
                return GetValue<int?>("service_period_days", false);
            }

        }
        public class QuotedChargeItemTier : Resource
        {

            public string ItemPriceId() {
                return GetValue<string>("item_price_id", true);
            }

            public int StartingUnit() {
                return GetValue<int>("starting_unit", true);
            }

            public int? EndingUnit() {
                return GetValue<int?>("ending_unit", false);
            }

            public int Price() {
                return GetValue<int>("price", true);
            }

            public string StartingUnitInDecimal() {
                return GetValue<string>("starting_unit_in_decimal", false);
            }

            public string EndingUnitInDecimal() {
                return GetValue<string>("ending_unit_in_decimal", false);
            }

            public string PriceInDecimal() {
                return GetValue<string>("price_in_decimal", false);
            }

        }
        public class QuotedChargeCoupon : Resource
        {

            public string CouponId() {
                return GetValue<string>("coupon_id", true);
            }

        }

        #endregion
    }
}
