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

    public class Discount : Resource 
    {
    
        public Discount() { }

        public Discount(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Discount(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Discount(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string InvoiceName 
        {
            get { return GetValue<string>("invoice_name", false); }
        }
        public double? Percentage 
        {
            get { return GetValue<double?>("percentage", false); }
        }
        public int? Amount 
        {
            get { return GetValue<int?>("amount", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public DurationTypeEnum DurationType 
        {
            get { return GetEnum<DurationTypeEnum>("duration_type", true); }
        }
        public int? Period 
        {
            get { return GetValue<int?>("period", false); }
        }
        public PeriodUnitEnum? PeriodUnit 
        {
            get { return GetEnum<PeriodUnitEnum>("period_unit", false); }
        }
        public bool IncludedInMrr 
        {
            get { return GetValue<bool>("included_in_mrr", true); }
        }
        public ApplyOnEnum ApplyOn 
        {
            get { return GetEnum<ApplyOnEnum>("apply_on", true); }
        }
        public string ItemPriceId 
        {
            get { return GetValue<string>("item_price_id", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? ApplyTill 
        {
            get { return GetDateTime("apply_till", false); }
        }
        public int? AppliedCount 
        {
            get { return GetValue<int?>("applied_count", false); }
        }
        public string CouponId 
        {
            get { return GetValue<string>("coupon_id", true); }
        }
        public int Index 
        {
            get { return GetValue<int>("index", true); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
