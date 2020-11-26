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

    public class Coupon : Resource 
    {
    
        public Coupon() { }

        public Coupon(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Coupon(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Coupon(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("coupons");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static CreateForItemsRequest CreateForItems()
        {
            string url = ApiUtil.BuildUrl("coupons", "create_for_items");
            return new CreateForItemsRequest(url, HttpMethod.POST);
        }
        public static UpdateForItemsRequest UpdateForItems(string id)
        {
            string url = ApiUtil.BuildUrl("coupons", CheckNull(id), "update_for_items");
            return new UpdateForItemsRequest(url, HttpMethod.POST);
        }
        public static CouponListRequest List()
        {
            string url = ApiUtil.BuildUrl("coupons");
            return new CouponListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("coupons", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("coupons", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("coupons", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static CopyRequest Copy()
        {
            string url = ApiUtil.BuildUrl("coupons", "copy");
            return new CopyRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Unarchive(string id)
        {
            string url = ApiUtil.BuildUrl("coupons", CheckNull(id), "unarchive");
            return new EntityRequest<Type>(url, HttpMethod.POST);
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
        [Obsolete]
        public int? DiscountQuantity 
        {
            get { return GetValue<int?>("discount_quantity", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public DurationTypeEnum DurationType 
        {
            get { return GetEnum<DurationTypeEnum>("duration_type", true); }
        }
        public int? DurationMonth 
        {
            get { return GetValue<int?>("duration_month", false); }
        }
        public DateTime? ValidTill 
        {
            get { return GetDateTime("valid_till", false); }
        }
        public int? MaxRedemptions 
        {
            get { return GetValue<int?>("max_redemptions", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        [Obsolete]
        public ApplyDiscountOnEnum ApplyDiscountOn 
        {
            get { return GetEnum<ApplyDiscountOnEnum>("apply_discount_on", true); }
        }
        public ApplyOnEnum ApplyOn 
        {
            get { return GetEnum<ApplyOnEnum>("apply_on", true); }
        }
        public PlanConstraintEnum PlanConstraint 
        {
            get { return GetEnum<PlanConstraintEnum>("plan_constraint", true); }
        }
        public AddonConstraintEnum AddonConstraint 
        {
            get { return GetEnum<AddonConstraintEnum>("addon_constraint", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public bool? IncludedInMrr 
        {
            get { return GetValue<bool?>("included_in_mrr", false); }
        }
        public List<string> PlanIds 
        {
            get { return GetList<string>("plan_ids"); }
        }
        public List<string> AddonIds 
        {
            get { return GetList<string>("addon_ids"); }
        }
        public List<CouponItemConstraint> ItemConstraints 
        {
            get { return GetResourceList<CouponItemConstraint>("item_constraints"); }
        }
        public List<CouponItemConstraintCriteria> ItemConstraintCriteria 
        {
            get { return GetResourceList<CouponItemConstraintCriteria>("item_constraint_criteria"); }
        }
        public int? Redemptions 
        {
            get { return GetValue<int?>("redemptions", false); }
        }
        public string InvoiceNotes 
        {
            get { return GetValue<string>("invoice_notes", false); }
        }
        public JToken MetaData 
        {
            get { return GetJToken("meta_data", false); }
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
                m_params.Add("id", id);
                return this;
            }
            public CreateRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public CreateRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public CreateRequest DiscountType(Coupon.DiscountTypeEnum discountType) 
            {
                m_params.Add("discount_type", discountType);
                return this;
            }
            public CreateRequest DiscountAmount(int discountAmount) 
            {
                m_params.AddOpt("discount_amount", discountAmount);
                return this;
            }
            public CreateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateRequest DiscountPercentage(double discountPercentage) 
            {
                m_params.AddOpt("discount_percentage", discountPercentage);
                return this;
            }
            [Obsolete]
            public CreateRequest DiscountQuantity(int discountQuantity) 
            {
                m_params.AddOpt("discount_quantity", discountQuantity);
                return this;
            }
            public CreateRequest ApplyOn(Coupon.ApplyOnEnum applyOn) 
            {
                m_params.Add("apply_on", applyOn);
                return this;
            }
            public CreateRequest DurationType(Coupon.DurationTypeEnum durationType) 
            {
                m_params.Add("duration_type", durationType);
                return this;
            }
            public CreateRequest DurationMonth(int durationMonth) 
            {
                m_params.AddOpt("duration_month", durationMonth);
                return this;
            }
            public CreateRequest ValidTill(long validTill) 
            {
                m_params.AddOpt("valid_till", validTill);
                return this;
            }
            public CreateRequest MaxRedemptions(int maxRedemptions) 
            {
                m_params.AddOpt("max_redemptions", maxRedemptions);
                return this;
            }
            public CreateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public CreateRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public CreateRequest PlanConstraint(PlanConstraintEnum planConstraint) 
            {
                m_params.AddOpt("plan_constraint", planConstraint);
                return this;
            }
            public CreateRequest AddonConstraint(AddonConstraintEnum addonConstraint) 
            {
                m_params.AddOpt("addon_constraint", addonConstraint);
                return this;
            }
            public CreateRequest PlanIds(List<string> planIds) 
            {
                m_params.AddOpt("plan_ids", planIds);
                return this;
            }
            public CreateRequest AddonIds(List<string> addonIds) 
            {
                m_params.AddOpt("addon_ids", addonIds);
                return this;
            }
            public CreateRequest Status(Coupon.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
        }
        public class CreateForItemsRequest : EntityRequest<CreateForItemsRequest> 
        {
            public CreateForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForItemsRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
            public CreateForItemsRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public CreateForItemsRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public CreateForItemsRequest DiscountType(Coupon.DiscountTypeEnum discountType) 
            {
                m_params.Add("discount_type", discountType);
                return this;
            }
            public CreateForItemsRequest DiscountAmount(int discountAmount) 
            {
                m_params.AddOpt("discount_amount", discountAmount);
                return this;
            }
            public CreateForItemsRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public CreateForItemsRequest DiscountPercentage(double discountPercentage) 
            {
                m_params.AddOpt("discount_percentage", discountPercentage);
                return this;
            }
            [Obsolete]
            public CreateForItemsRequest DiscountQuantity(int discountQuantity) 
            {
                m_params.AddOpt("discount_quantity", discountQuantity);
                return this;
            }
            public CreateForItemsRequest ApplyOn(Coupon.ApplyOnEnum applyOn) 
            {
                m_params.Add("apply_on", applyOn);
                return this;
            }
            public CreateForItemsRequest DurationType(Coupon.DurationTypeEnum durationType) 
            {
                m_params.Add("duration_type", durationType);
                return this;
            }
            public CreateForItemsRequest DurationMonth(int durationMonth) 
            {
                m_params.AddOpt("duration_month", durationMonth);
                return this;
            }
            public CreateForItemsRequest ValidTill(long validTill) 
            {
                m_params.AddOpt("valid_till", validTill);
                return this;
            }
            public CreateForItemsRequest MaxRedemptions(int maxRedemptions) 
            {
                m_params.AddOpt("max_redemptions", maxRedemptions);
                return this;
            }
            public CreateForItemsRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public CreateForItemsRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public CreateForItemsRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public CreateForItemsRequest Status(Coupon.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public CreateForItemsRequest ItemConstraintConstraint(int index, CouponItemConstraint.ConstraintEnum itemConstraintConstraint) 
            {
                m_params.Add("item_constraints[constraint][" + index + "]", itemConstraintConstraint);
                return this;
            }
            public CreateForItemsRequest ItemConstraintItemType(int index, CouponItemConstraint.ItemTypeEnum itemConstraintItemType) 
            {
                m_params.Add("item_constraints[item_type][" + index + "]", itemConstraintItemType);
                return this;
            }
            public CreateForItemsRequest ItemConstraintItemPriceIds(int index, JArray itemConstraintItemPriceIds) 
            {
                m_params.AddOpt("item_constraints[item_price_ids][" + index + "]", itemConstraintItemPriceIds);
                return this;
            }
            public CreateForItemsRequest ItemConstraintCriteriaItemType(int index, CouponItemConstraintCriteria.ItemTypeEnum itemConstraintCriteriaItemType) 
            {
                m_params.AddOpt("item_constraint_criteria[item_type][" + index + "]", itemConstraintCriteriaItemType);
                return this;
            }
            public CreateForItemsRequest ItemConstraintCriteriaItemFamilyIds(int index, JArray itemConstraintCriteriaItemFamilyIds) 
            {
                m_params.AddOpt("item_constraint_criteria[item_family_ids][" + index + "]", itemConstraintCriteriaItemFamilyIds);
                return this;
            }
            public CreateForItemsRequest ItemConstraintCriteriaCurrencies(int index, JArray itemConstraintCriteriaCurrencies) 
            {
                m_params.AddOpt("item_constraint_criteria[currencies][" + index + "]", itemConstraintCriteriaCurrencies);
                return this;
            }
            public CreateForItemsRequest ItemConstraintCriteriaItemPricePeriods(int index, JArray itemConstraintCriteriaItemPricePeriods) 
            {
                m_params.AddOpt("item_constraint_criteria[item_price_periods][" + index + "]", itemConstraintCriteriaItemPricePeriods);
                return this;
            }
        }
        public class UpdateForItemsRequest : EntityRequest<UpdateForItemsRequest> 
        {
            public UpdateForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateForItemsRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateForItemsRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public UpdateForItemsRequest DiscountType(Coupon.DiscountTypeEnum discountType) 
            {
                m_params.AddOpt("discount_type", discountType);
                return this;
            }
            public UpdateForItemsRequest DiscountAmount(int discountAmount) 
            {
                m_params.AddOpt("discount_amount", discountAmount);
                return this;
            }
            public UpdateForItemsRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public UpdateForItemsRequest DiscountPercentage(double discountPercentage) 
            {
                m_params.AddOpt("discount_percentage", discountPercentage);
                return this;
            }
            public UpdateForItemsRequest ApplyOn(Coupon.ApplyOnEnum applyOn) 
            {
                m_params.AddOpt("apply_on", applyOn);
                return this;
            }
            public UpdateForItemsRequest DurationType(Coupon.DurationTypeEnum durationType) 
            {
                m_params.AddOpt("duration_type", durationType);
                return this;
            }
            public UpdateForItemsRequest DurationMonth(int durationMonth) 
            {
                m_params.AddOpt("duration_month", durationMonth);
                return this;
            }
            public UpdateForItemsRequest ValidTill(long validTill) 
            {
                m_params.AddOpt("valid_till", validTill);
                return this;
            }
            public UpdateForItemsRequest MaxRedemptions(int maxRedemptions) 
            {
                m_params.AddOpt("max_redemptions", maxRedemptions);
                return this;
            }
            public UpdateForItemsRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
            public UpdateForItemsRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
            public UpdateForItemsRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public UpdateForItemsRequest ItemConstraintConstraint(int index, CouponItemConstraint.ConstraintEnum itemConstraintConstraint) 
            {
                m_params.Add("item_constraints[constraint][" + index + "]", itemConstraintConstraint);
                return this;
            }
            public UpdateForItemsRequest ItemConstraintItemType(int index, CouponItemConstraint.ItemTypeEnum itemConstraintItemType) 
            {
                m_params.Add("item_constraints[item_type][" + index + "]", itemConstraintItemType);
                return this;
            }
            public UpdateForItemsRequest ItemConstraintItemPriceIds(int index, JArray itemConstraintItemPriceIds) 
            {
                m_params.AddOpt("item_constraints[item_price_ids][" + index + "]", itemConstraintItemPriceIds);
                return this;
            }
            public UpdateForItemsRequest ItemConstraintCriteriaItemType(int index, CouponItemConstraintCriteria.ItemTypeEnum itemConstraintCriteriaItemType) 
            {
                m_params.AddOpt("item_constraint_criteria[item_type][" + index + "]", itemConstraintCriteriaItemType);
                return this;
            }
            public UpdateForItemsRequest ItemConstraintCriteriaItemFamilyIds(int index, JArray itemConstraintCriteriaItemFamilyIds) 
            {
                m_params.AddOpt("item_constraint_criteria[item_family_ids][" + index + "]", itemConstraintCriteriaItemFamilyIds);
                return this;
            }
            public UpdateForItemsRequest ItemConstraintCriteriaCurrencies(int index, JArray itemConstraintCriteriaCurrencies) 
            {
                m_params.AddOpt("item_constraint_criteria[currencies][" + index + "]", itemConstraintCriteriaCurrencies);
                return this;
            }
            public UpdateForItemsRequest ItemConstraintCriteriaItemPricePeriods(int index, JArray itemConstraintCriteriaItemPricePeriods) 
            {
                m_params.AddOpt("item_constraint_criteria[item_price_periods][" + index + "]", itemConstraintCriteriaItemPricePeriods);
                return this;
            }
        }
        public class CouponListRequest : ListRequestBase<CouponListRequest> 
        {
            public CouponListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<CouponListRequest> Id() 
            {
                return new StringFilter<CouponListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CouponListRequest> Name() 
            {
                return new StringFilter<CouponListRequest>("name", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Coupon.DiscountTypeEnum, CouponListRequest> DiscountType() 
            {
                return new EnumFilter<Coupon.DiscountTypeEnum, CouponListRequest>("discount_type", this);        
            }
            public EnumFilter<Coupon.DurationTypeEnum, CouponListRequest> DurationType() 
            {
                return new EnumFilter<Coupon.DurationTypeEnum, CouponListRequest>("duration_type", this);        
            }
            public EnumFilter<Coupon.StatusEnum, CouponListRequest> Status() 
            {
                return new EnumFilter<Coupon.StatusEnum, CouponListRequest>("status", this);        
            }
            public EnumFilter<Coupon.ApplyOnEnum, CouponListRequest> ApplyOn() 
            {
                return new EnumFilter<Coupon.ApplyOnEnum, CouponListRequest>("apply_on", this);        
            }
            public TimestampFilter<CouponListRequest> CreatedAt() 
            {
                return new TimestampFilter<CouponListRequest>("created_at", this);        
            }
            public TimestampFilter<CouponListRequest> UpdatedAt() 
            {
                return new TimestampFilter<CouponListRequest>("updated_at", this);        
            }
            public CouponListRequest SortByCreatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","created_at");
                return this;
            }
            public StringFilter<CouponListRequest> CurrencyCode() 
            {
                return new StringFilter<CouponListRequest>("currency_code", this).SupportsMultiOperators(true);        
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public UpdateRequest DiscountType(Coupon.DiscountTypeEnum discountType) 
            {
                m_params.AddOpt("discount_type", discountType);
                return this;
            }
            public UpdateRequest DiscountAmount(int discountAmount) 
            {
                m_params.AddOpt("discount_amount", discountAmount);
                return this;
            }
            public UpdateRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public UpdateRequest DiscountPercentage(double discountPercentage) 
            {
                m_params.AddOpt("discount_percentage", discountPercentage);
                return this;
            }
            public UpdateRequest ApplyOn(Coupon.ApplyOnEnum applyOn) 
            {
                m_params.AddOpt("apply_on", applyOn);
                return this;
            }
            public UpdateRequest DurationType(Coupon.DurationTypeEnum durationType) 
            {
                m_params.AddOpt("duration_type", durationType);
                return this;
            }
            public UpdateRequest DurationMonth(int durationMonth) 
            {
                m_params.AddOpt("duration_month", durationMonth);
                return this;
            }
            public UpdateRequest ValidTill(long validTill) 
            {
                m_params.AddOpt("valid_till", validTill);
                return this;
            }
            public UpdateRequest MaxRedemptions(int maxRedemptions) 
            {
                m_params.AddOpt("max_redemptions", maxRedemptions);
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
            public UpdateRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public UpdateRequest PlanConstraint(PlanConstraintEnum planConstraint) 
            {
                m_params.AddOpt("plan_constraint", planConstraint);
                return this;
            }
            public UpdateRequest AddonConstraint(AddonConstraintEnum addonConstraint) 
            {
                m_params.AddOpt("addon_constraint", addonConstraint);
                return this;
            }
            public UpdateRequest PlanIds(List<string> planIds) 
            {
                m_params.AddOpt("plan_ids", planIds);
                return this;
            }
            public UpdateRequest AddonIds(List<string> addonIds) 
            {
                m_params.AddOpt("addon_ids", addonIds);
                return this;
            }
        }
        public class CopyRequest : EntityRequest<CopyRequest> 
        {
            public CopyRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CopyRequest FromSite(string fromSite) 
            {
                m_params.Add("from_site", fromSite);
                return this;
            }
            public CopyRequest IdAtFromSite(string idAtFromSite) 
            {
                m_params.Add("id_at_from_site", idAtFromSite);
                return this;
            }
            public CopyRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CopyRequest ForSiteMerging(bool forSiteMerging) 
            {
                m_params.AddOpt("for_site_merging", forSiteMerging);
                return this;
            }
        }
        #endregion

        public enum DiscountTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "fixed_amount")]
            FixedAmount,
            [EnumMember(Value = "percentage")]
            Percentage,
            [EnumMember(Value = "offer_quantity")]
            [Obsolete]
            OfferQuantity,

        }
        public enum DurationTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "one_time")]
            OneTime,
            [EnumMember(Value = "forever")]
            Forever,
            [EnumMember(Value = "limited_period")]
            LimitedPeriod,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "expired")]
            Expired,
            [EnumMember(Value = "archived")]
            Archived,
            [EnumMember(Value = "deleted")]
            Deleted,

        }
        [Obsolete]
        public enum ApplyDiscountOnEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "plans")]
            Plans,
            [EnumMember(Value = "plans_and_addons")]
            PlansAndAddons,
            [EnumMember(Value = "plans_with_quantity")]
            PlansWithQuantity,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }
        public enum ApplyOnEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "invoice_amount")]
            InvoiceAmount,
            [EnumMember(Value = "specified_items_total")]
            [Obsolete]
            SpecifiedItemsTotal,
            [EnumMember(Value = "each_specified_item")]
            EachSpecifiedItem,
            [EnumMember(Value = "each_unit_of_specified_items")]
            [Obsolete]
            EachUnitOfSpecifiedItems,

        }
        public enum PlanConstraintEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "all")]
            All,
            [EnumMember(Value = "specific")]
            Specific,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }
        public enum AddonConstraintEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "all")]
            All,
            [EnumMember(Value = "specific")]
            Specific,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }

        #region Subclasses
        public class CouponItemConstraint : Resource
        {
            public enum ItemTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "charge")]
                Charge,
            }
            public enum ConstraintEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "none")]
                None,
                [EnumMember(Value = "all")]
                All,
                [EnumMember(Value = "specific")]
                Specific,
                [EnumMember(Value = "criteria")]
                Criteria,
            }

            public ItemTypeEnum ItemType() {
                return GetEnum<ItemTypeEnum>("item_type", true);
            }

            public ConstraintEnum Constraint() {
                return GetEnum<ConstraintEnum>("constraint", true);
            }

            public JArray ItemPriceIds() {
                return GetJArray("item_price_ids", false);
            }

        }
        public class CouponItemConstraintCriteria : Resource
        {
            public enum ItemTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "charge")]
                Charge,
            }

            public ItemTypeEnum ItemType() {
                return GetEnum<ItemTypeEnum>("item_type", true);
            }

            public JArray Currencies() {
                return GetJArray("currencies", false);
            }

            public JArray ItemFamilyIds() {
                return GetJArray("item_family_ids", false);
            }

            public JArray ItemPricePeriods() {
                return GetJArray("item_price_periods", false);
            }

        }

        #endregion
    }
}
