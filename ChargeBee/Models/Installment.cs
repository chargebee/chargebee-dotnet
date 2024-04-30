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

    public class Installment : Resource 
    {
    
        public Installment() { }

        public Installment(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Installment(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Installment(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("installments", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static InstallmentListRequest List()
        {
            string url = ApiUtil.BuildUrl("installments");
            return new InstallmentListRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", true); }
        }
        public DateTime Date 
        {
            get { return (DateTime)GetDateTime("date", true); }
        }
        public long Amount 
        {
            get { return GetValue<long>("amount", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        
        #endregion
        
        #region Requests
        public class InstallmentListRequest : ListRequestBase<InstallmentListRequest> 
        {
            public InstallmentListRequest(string url) 
                    : base(url)
            {
            }

            public InstallmentListRequest SortBy(string sortBy) 
            {
                m_params.AddOpt("sort_by", sortBy);
                return this;
            }
            public StringFilter<InstallmentListRequest> InvoiceId() 
            {
                return new StringFilter<InstallmentListRequest>("invoice_id", this).SupportsMultiOperators(true);        
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "posted")]
            Posted,
            [EnumMember(Value = "payment_due")]
            PaymentDue,
            [EnumMember(Value = "paid")]
            Paid,

        }

        #region Subclasses

        #endregion
    }
}
