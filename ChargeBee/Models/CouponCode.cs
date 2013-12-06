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

    public class CouponCode : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("coupon_codes");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_codes", CheckNull(id));
            return new EntityRequest(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public string Code 
        {
            get { return GetValue<string>("code", true); }
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
        public class CreateRequest : EntityRequest 
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
        #endregion


        #region Subclasses

        #endregion
    }
}
