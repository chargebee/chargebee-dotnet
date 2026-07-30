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

    public class CreditUnit : Resource 
    {
    
        public CreditUnit() { }

        public CreditUnit(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CreditUnit(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CreditUnit(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreditUnitListRequest List()
        {
            string url = ApiUtil.BuildUrl("credit_units");
            var request = new CreditUnitListRequest(url);
            request.SetTelemetryResource("creditUnit");
            request.SetTelemetryOperation("list");
            return request;
        }
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("credit_units");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("creditUnit");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("credit_units", CheckNull(id));
            var request = new UpdateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("creditUnit");
            request.SetTelemetryOperation("update");
            return request;
        }
        public static EntityRequest<Type> Archive(string id)
        {
            string url = ApiUtil.BuildUrl("credit_units", CheckNull(id), "archive_command");
            var request = new EntityRequest<Type>(url, HttpMethod.POST);
            request.SetTelemetryResource("creditUnit");
            request.SetTelemetryOperation("archive");
            return request;
        }
        public static EntityRequest<Type> Reactivate(string id)
        {
            string url = ApiUtil.BuildUrl("credit_units", CheckNull(id), "reactivate_command");
            var request = new EntityRequest<Type>(url, HttpMethod.POST);
            request.SetTelemetryResource("creditUnit");
            request.SetTelemetryOperation("reactivate");
            return request;
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
        public string ExternalName 
        {
            get { return GetValue<string>("external_name", true); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public string CreatedBy 
        {
            get { return GetValue<string>("created_by", false); }
        }
        public string UpdatedBy 
        {
            get { return GetValue<string>("updated_by", false); }
        }
        public bool IsUnlimited 
        {
            get { return GetValue<bool>("is_unlimited", true); }
        }
        public string OverdraftAmount 
        {
            get { return GetValue<string>("overdraft_amount", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreditUnitListRequest : ListRequestBase<CreditUnitListRequest> 
        {
            public CreditUnitListRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<CreditUnit.StatusEnum, CreditUnitListRequest> Status() 
            {
                return new EnumFilter<CreditUnit.StatusEnum, CreditUnitListRequest>("status", this);        
            }
            public StringFilter<CreditUnitListRequest> Id() 
            {
                return new StringFilter<CreditUnitListRequest>("id", this).SupportsMultiOperators(true);        
            }
        }
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
            public CreateRequest IsUnlimited(bool isUnlimited) 
            {
                m_params.Add("is_unlimited", isUnlimited);
                return this;
            }
            public CreateRequest OverdraftAmount(string overdraftAmount) 
            {
                m_params.AddOpt("overdraft_amount", overdraftAmount);
                return this;
            }
            public CreateRequest ExternalName(string externalName) 
            {
                m_params.AddOpt("external_name", externalName);
                return this;
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
            public UpdateRequest ExternalName(string externalName) 
            {
                m_params.AddOpt("external_name", externalName);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "archived")]
            Archived,

        }

        #region Subclasses

        #endregion
    }
}
