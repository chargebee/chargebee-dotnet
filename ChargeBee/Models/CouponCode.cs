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

    public class CouponCode : Resource 
    {
    
        public CouponCode() { }

        public CouponCode(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CouponCode(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CouponCode(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        [Obsolete]
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("coupon_codes");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("couponCode");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_codes", CheckNull(id));
            var request = new EntityRequest<Type>(url, HttpMethod.GET);
            request.SetTelemetryResource("couponCode");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static CouponCodeListRequest List()
        {
            string url = ApiUtil.BuildUrl("coupon_codes");
            var request = new CouponCodeListRequest(url);
            request.SetTelemetryResource("couponCode");
            request.SetTelemetryOperation("list");
            return request;
        }
        public static EntityRequest<Type> Archive(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_codes", CheckNull(id), "archive");
            var request = new EntityRequest<Type>(url, HttpMethod.POST);
            request.SetTelemetryResource("couponCode");
            request.SetTelemetryOperation("archive");
            return request;
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
        public string CouponSetId 
        {
            get { return GetValue<string>("coupon_set_id", true); }
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
            [EnumMember(Value = "not_redeemed")]
            NotRedeemed,
            [EnumMember(Value = "redeemed")]
            Redeemed,
            [EnumMember(Value = "archived")]
            Archived,

        }

        #region Subclasses

        #endregion
    }
}
