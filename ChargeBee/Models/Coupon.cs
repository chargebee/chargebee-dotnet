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

    public class Coupon : Resource 
    {
    

        #region Methods
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("coupons");
            return new ListRequest(url);
        }
        public static EntityRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("coupons", CheckNull(id));
            return new EntityRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", true); }
        }
        public string InvoiceName 
        {
            get { return GetValue<string>("invoice_name", false); }
        }
        public DiscountTypeEnum DiscountType 
        {
            get { return GetEnum<DiscountTypeEnum>("discount_type", true); }
        }
        public double? DiscountPercentage 
        {
            get { return GetValue<double?>("discount_percentage", false); }
        }
        public int? DiscountAmount 
        {
            get { return GetValue<int?>("discount_amount", false); }
        }
        public int? DiscountQuantity 
        {
            get { return GetValue<int?>("discount_quantity", false); }
        }
        public DurationTypeEnum DurationType 
        {
            get { return GetEnum<DurationTypeEnum>("duration_type", true); }
        }
        public int? DurationMonth 
        {
            get { return GetValue<int?>("duration_month", false); }
        }
        public int? MaxRedemptions 
        {
            get { return GetValue<int?>("max_redemptions", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public int? Redemptions 
        {
            get { return GetValue<int?>("redemptions", false); }
        }
        public ApplyDiscountOnEnum ApplyDiscountOn 
        {
            get { return GetEnum<ApplyDiscountOnEnum>("apply_discount_on", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public DateTime? ValidTill 
        {
            get { return GetDateTime("valid_till", false); }
        }

        #endregion
        

        public enum DiscountTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("fixed_amount")]
            FixedAmount,
            [Description("percentage")]
            Percentage,
            [Description("offer_quantity")]
            OfferQuantity,

        }
        public enum DurationTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("one_time")]
            OneTime,
            [Description("forever")]
            Forever,
            [Description("limited_period")]
            LimitedPeriod,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("active")]
            Active,
            [Description("expired")]
            Expired,
            [Description("archived")]
            Archived,

        }
        public enum ApplyDiscountOnEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("plans")]
            Plans,
            [Description("plans_and_addons")]
            PlansAndAddons,
            [Description("plans_with_quantity")]
            PlansWithQuantity,

        }

        #region Subclasses

        #endregion
    }
}
