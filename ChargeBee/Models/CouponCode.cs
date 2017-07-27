using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class CouponCode : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildRelativeUrl("coupon_codes");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildRelativeUrl("coupon_codes", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static CouponCodeListRequest List()
        {
            string url = ApiUtil.BuildRelativeUrl("coupon_codes");
            return new CouponCodeListRequest(url);
        }
        public static EntityRequest<Type> Archive(string id)
        {
            string url = ApiUtil.BuildRelativeUrl("coupon_codes", CheckNull(id), "archive");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Code 
        {
            get { return GetValue<string>("code", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string CouponId 
        {
            get { return GetValue<string>("coupon_id", true); }
        }
        public string CouponSetName 
        {
            get { return GetValue<string>("coupon_set_name", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest CouponId(string couponId) 
            {
                m_params.Add("coupon_id", couponId);
                return this;
            }
            public CreateRequest CouponSetName(string couponSetName) 
            {
                m_params.Add("coupon_set_name", couponSetName);
                return this;
            }
            public CreateRequest Code(string code) 
            {
                m_params.Add("code", code);
                return this;
            }
        }
        public class CouponCodeListRequest : ListRequestBase<CouponCodeListRequest> 
        {
            public CouponCodeListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<CouponCodeListRequest> Code() 
            {
                return new StringFilter<CouponCodeListRequest>("code", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CouponCodeListRequest> CouponId() 
            {
                return new StringFilter<CouponCodeListRequest>("coupon_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CouponCodeListRequest> CouponSetName() 
            {
                return new StringFilter<CouponCodeListRequest>("coupon_set_name", this);        
            }
            public EnumFilter<CouponCode.StatusEnum, CouponCodeListRequest> Status() 
            {
                return new EnumFilter<CouponCode.StatusEnum, CouponCodeListRequest>("status", this);        
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("not_redeemed")]
            NotRedeemed,
            [Description("redeemed")]
            Redeemed,
            [Description("archived")]
            Archived,

        }

        #region Subclasses

        #endregion
    }
}
