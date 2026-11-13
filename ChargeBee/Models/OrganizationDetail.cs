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

    public class OrganizationDetail : Resource 
    {
    
        public OrganizationDetail() { }

        public OrganizationDetail(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public OrganizationDetail(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public OrganizationDetail(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("organization_details");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("organizationDetail");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("organization_details", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("organizationDetail");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static OrganizationDetailListRequest List()
        {
            string url = ApiUtil.BuildUrl("organization_details");
            var request = new OrganizationDetailListRequest(url);
            request.SetTelemetryResource("organizationDetail");
            request.SetTelemetryOperation("list");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string OrganizationName 
        {
            get { return GetValue<string>("organization_name", false); }
        }
        public string Email 
        {
            get { return GetValue<string>("email", false); }
        }
        public string AddressLine1 
        {
            get { return GetValue<string>("address_line1", false); }
        }
        public string AddressLine2 
        {
            get { return GetValue<string>("address_line2", false); }
        }
        public string AddressLine3 
        {
            get { return GetValue<string>("address_line3", false); }
        }
        public string City 
        {
            get { return GetValue<string>("city", false); }
        }
        public string StateCode 
        {
            get { return GetValue<string>("state_code", false); }
        }
        public string State 
        {
            get { return GetValue<string>("state", false); }
        }
        public string CountryCode 
        {
            get { return GetValue<string>("country_code", false); }
        }
        public string Zip 
        {
            get { return GetValue<string>("zip", false); }
        }
        public string Phone 
        {
            get { return GetValue<string>("phone", false); }
        }
        public string Fax 
        {
            get { return GetValue<string>("fax", false); }
        }
        public string Website 
        {
            get { return GetValue<string>("website", false); }
        }
        public bool? IsVatNumberPresent 
        {
            get { return GetValue<bool?>("is_vat_number_present", false); }
        }
        public string VatNumber 
        {
            get { return GetValue<string>("vat_number", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest OrganizationName(string organizationName) 
            {
                m_params.Add("organization_name", organizationName);
                return this;
            }
            public CreateRequest Email(string email) 
            {
                m_params.AddOpt("email", email);
                return this;
            }
            public CreateRequest AddressLine1(string addressLine1) 
            {
                m_params.Add("address_line1", addressLine1);
                return this;
            }
            public CreateRequest AddressLine2(string addressLine2) 
            {
                m_params.AddOpt("address_line2", addressLine2);
                return this;
            }
            public CreateRequest AddressLine3(string addressLine3) 
            {
                m_params.AddOpt("address_line3", addressLine3);
                return this;
            }
            public CreateRequest City(string city) 
            {
                m_params.Add("city", city);
                return this;
            }
            public CreateRequest StateCode(string stateCode) 
            {
                m_params.AddOpt("state_code", stateCode);
                return this;
            }
            public CreateRequest State(string state) 
            {
                m_params.Add("state", state);
                return this;
            }
            public CreateRequest Zip(string zip) 
            {
                m_params.Add("zip", zip);
                return this;
            }
            public CreateRequest CountryCode(string countryCode) 
            {
                m_params.AddOpt("country_code", countryCode);
                return this;
            }
            public CreateRequest Phone(string phone) 
            {
                m_params.Add("phone", phone);
                return this;
            }
            public CreateRequest Fax(string fax) 
            {
                m_params.AddOpt("fax", fax);
                return this;
            }
            public CreateRequest Website(string website) 
            {
                m_params.AddOpt("website", website);
                return this;
            }
            public CreateRequest IsVatNumberPresent(bool isVatNumberPresent) 
            {
                m_params.AddOpt("is_vat_number_present", isVatNumberPresent);
                return this;
            }
            public CreateRequest VatNumber(string vatNumber) 
            {
                m_params.AddOpt("vat_number", vatNumber);
                return this;
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class OrganizationDetailListRequest : ListRequestBase<OrganizationDetailListRequest> 
        {
            public OrganizationDetailListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<OrganizationDetailListRequest> BusinessEntityId() 
            {
                return new StringFilter<OrganizationDetailListRequest>("business_entity_id", this);        
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
