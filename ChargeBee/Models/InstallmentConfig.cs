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

    public class InstallmentConfig : Resource 
    {
    
        public InstallmentConfig() { }

        public InstallmentConfig(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public InstallmentConfig(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public InstallmentConfig(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("installment_configs");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("installment_configs", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("installment_configs", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public int NumberOfInstallments 
        {
            get { return GetValue<int>("number_of_installments", true); }
        }
        public PeriodUnitEnum PeriodUnit 
        {
            get { return GetEnum<PeriodUnitEnum>("period_unit", true); }
        }
        public int? Period 
        {
            get { return GetValue<int?>("period", false); }
        }
        public int? PreferredDay 
        {
            get { return GetValue<int?>("preferred_day", false); }
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
        public List<InstallmentConfigInstallment> Installments 
        {
            get { return GetResourceList<InstallmentConfigInstallment>("installments"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest NumberOfInstallments(int numberOfInstallments) 
            {
                m_params.Add("number_of_installments", numberOfInstallments);
                return this;
            }
            public CreateRequest PeriodUnit(InstallmentConfig.PeriodUnitEnum periodUnit) 
            {
                m_params.Add("period_unit", periodUnit);
                return this;
            }
            public CreateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public CreateRequest PreferredDay(int preferredDay) 
            {
                m_params.AddOpt("preferred_day", preferredDay);
                return this;
            }
            public CreateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateRequest InstallmentPeriod(int index, int installmentPeriod) 
            {
                m_params.AddOpt("installments[period][" + index + "]", installmentPeriod);
                return this;
            }
            public CreateRequest InstallmentAmountPercentage(int index, decimal installmentAmountPercentage) 
            {
                m_params.AddOpt("installments[amount_percentage][" + index + "]", installmentAmountPercentage);
                return this;
            }
        }
        #endregion

        public enum PeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "day")]
            Day,
            [EnumMember(Value = "week")]
            Week,
            [EnumMember(Value = "month")]
            Month,

        }

        #region Subclasses
        public class InstallmentConfigInstallment : Resource
        {

            public int? Period {
                get { return GetValue<int?>("period", false); }
            }

            public decimal? AmountPercentage {
                get { return GetValue<decimal?>("amount_percentage", false); }
            }

        }

        #endregion
    }
}
