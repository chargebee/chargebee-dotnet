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

    public class CouponSet : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("coupon_sets");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static AddCouponCodesRequest AddCouponCodes(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_sets", CheckNull(id), "add_coupon_codes");
            return new AddCouponCodesRequest(url, HttpMethod.POST);
        }
        public static CouponSetListRequest List()
        {
            string url = ApiUtil.BuildUrl("coupon_sets");
            return new CouponSetListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_sets", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_sets", CheckNull(id), "update");
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_sets", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> DeleteUnusedCouponCodes(string id)
        {
            string url = ApiUtil.BuildUrl("coupon_sets", CheckNull(id), "delete_unused_coupon_codes");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string CouponId 
        {
            get { return GetValue<string>("coupon_id", true); }
        }
        public string Name 
        {
            get { return GetValue<string>("name", true); }
        }
        public int? TotalCount 
        {
            get { return GetValue<int?>("total_count", false); }
        }
        public int? RedeemedCount 
        {
            get { return GetValue<int?>("redeemed_count", false); }
        }
        public int? ArchivedCount 
        {
            get { return GetValue<int?>("archived_count", false); }
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

            public CreateRequest CouponId(string couponId) 
            {
                m_params.Add("coupon_id", couponId);
                return this;
            }
            public CreateRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public CreateRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
            public CreateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
        }
        public class AddCouponCodesRequest : EntityRequest<AddCouponCodesRequest> 
        {
            public AddCouponCodesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public AddCouponCodesRequest Code(List<string> code) 
            {
                m_params.AddOpt("code", code);
                return this;
            }
        }
        public class CouponSetListRequest : ListRequestBase<CouponSetListRequest> 
        {
            public CouponSetListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<CouponSetListRequest> Id() 
            {
                return new StringFilter<CouponSetListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CouponSetListRequest> Name() 
            {
                return new StringFilter<CouponSetListRequest>("name", this).SupportsMultiOperators(true);        
            }
            public StringFilter<CouponSetListRequest> CouponId() 
            {
                return new StringFilter<CouponSetListRequest>("coupon_id", this).SupportsMultiOperators(true);        
            }
            public NumberFilter<int, CouponSetListRequest> TotalCount() 
            {
                return new NumberFilter<int, CouponSetListRequest>("total_count", this);        
            }
            public NumberFilter<int, CouponSetListRequest> RedeemedCount() 
            {
                return new NumberFilter<int, CouponSetListRequest>("redeemed_count", this);        
            }
            public NumberFilter<int, CouponSetListRequest> ArchivedCount() 
            {
                return new NumberFilter<int, CouponSetListRequest>("archived_count", this);        
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
            public UpdateRequest MetaData(JToken metaData) 
            {
                m_params.AddOpt("meta_data", metaData);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
