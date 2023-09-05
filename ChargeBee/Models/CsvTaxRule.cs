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

    public class CsvTaxRule : Resource 
    {
    
        public CsvTaxRule() { }

        public CsvTaxRule(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CsvTaxRule(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CsvTaxRule(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("csv_tax_rules");
            return new CreateRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string TaxProfileName 
        {
            get { return GetValue<string>("tax_profile_name", false); }
        }
        public string Country 
        {
            get { return GetValue<string>("country", false); }
        }
        public string State 
        {
            get { return GetValue<string>("state", false); }
        }
        public string ZipCode 
        {
            get { return GetValue<string>("zip_code", false); }
        }
        public int? ZipCodeStart 
        {
            get { return GetValue<int?>("zip_code_start", false); }
        }
        public int? ZipCodeEnd 
        {
            get { return GetValue<int?>("zip_code_end", false); }
        }
        public string Tax1Name 
        {
            get { return GetValue<string>("tax1_name", true); }
        }
        public double Tax1Rate 
        {
            get { return GetValue<double>("tax1_rate", true); }
        }
        public Tax1JurisTypeEnum? Tax1JurisType 
        {
            get { return GetEnum<Tax1JurisTypeEnum>("tax1_juris_type", false); }
        }
        public string Tax1JurisName 
        {
            get { return GetValue<string>("tax1_juris_name", false); }
        }
        public string Tax1JurisCode 
        {
            get { return GetValue<string>("tax1_juris_code", false); }
        }
        public string Tax2Name 
        {
            get { return GetValue<string>("tax2_name", false); }
        }
        public double? Tax2Rate 
        {
            get { return GetValue<double?>("tax2_rate", false); }
        }
        public Tax2JurisTypeEnum? Tax2JurisType 
        {
            get { return GetEnum<Tax2JurisTypeEnum>("tax2_juris_type", false); }
        }
        public string Tax2JurisName 
        {
            get { return GetValue<string>("tax2_juris_name", false); }
        }
        public string Tax2JurisCode 
        {
            get { return GetValue<string>("tax2_juris_code", false); }
        }
        public string Tax3Name 
        {
            get { return GetValue<string>("tax3_name", false); }
        }
        public double? Tax3Rate 
        {
            get { return GetValue<double?>("tax3_rate", false); }
        }
        public Tax3JurisTypeEnum? Tax3JurisType 
        {
            get { return GetEnum<Tax3JurisTypeEnum>("tax3_juris_type", false); }
        }
        public string Tax3JurisName 
        {
            get { return GetValue<string>("tax3_juris_name", false); }
        }
        public string Tax3JurisCode 
        {
            get { return GetValue<string>("tax3_juris_code", false); }
        }
        public string Tax4Name 
        {
            get { return GetValue<string>("tax4_name", false); }
        }
        public double? Tax4Rate 
        {
            get { return GetValue<double?>("tax4_rate", false); }
        }
        public Tax4JurisTypeEnum? Tax4JurisType 
        {
            get { return GetEnum<Tax4JurisTypeEnum>("tax4_juris_type", false); }
        }
        public string Tax4JurisName 
        {
            get { return GetValue<string>("tax4_juris_name", false); }
        }
        public string Tax4JurisCode 
        {
            get { return GetValue<string>("tax4_juris_code", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string TimeZone 
        {
            get { return GetValue<string>("time_zone", false); }
        }
        public DateTime? ValidFrom 
        {
            get { return GetDateTime("valid_from", false); }
        }
        public DateTime? ValidTill 
        {
            get { return GetDateTime("valid_till", false); }
        }
        public ServiceTypeEnum? ServiceType 
        {
            get { return GetEnum<ServiceTypeEnum>("service_type", false); }
        }
        public int? RuleWeight 
        {
            get { return GetValue<int?>("rule_weight", false); }
        }
        public bool Overwrite 
        {
            get { return GetValue<bool>("overwrite", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest TaxProfileName(string taxProfileName) 
            {
                m_params.AddOpt("tax_profile_name", taxProfileName);
                return this;
            }
            public CreateRequest Country(string country) 
            {
                m_params.AddOpt("country", country);
                return this;
            }
            public CreateRequest State(string state) 
            {
                m_params.AddOpt("state", state);
                return this;
            }
            public CreateRequest ZipCode(string zipCode) 
            {
                m_params.AddOpt("zip_code", zipCode);
                return this;
            }
            public CreateRequest ZipCodeStart(int zipCodeStart) 
            {
                m_params.AddOpt("zip_code_start", zipCodeStart);
                return this;
            }
            public CreateRequest ZipCodeEnd(int zipCodeEnd) 
            {
                m_params.AddOpt("zip_code_end", zipCodeEnd);
                return this;
            }
            public CreateRequest Tax1Name(string tax1Name) 
            {
                m_params.AddOpt("tax1_name", tax1Name);
                return this;
            }
            public CreateRequest Tax1Rate(double tax1Rate) 
            {
                m_params.AddOpt("tax1_rate", tax1Rate);
                return this;
            }
            public CreateRequest Tax1JurisType(ChargeBee.Models.Enums.Tax1JurisTypeEnum tax1JurisType) 
            {
                m_params.AddOpt("tax1_juris_type", tax1JurisType);
                return this;
            }
            public CreateRequest Tax1JurisName(string tax1JurisName) 
            {
                m_params.AddOpt("tax1_juris_name", tax1JurisName);
                return this;
            }
            public CreateRequest Tax1JurisCode(string tax1JurisCode) 
            {
                m_params.AddOpt("tax1_juris_code", tax1JurisCode);
                return this;
            }
            public CreateRequest Tax2Name(string tax2Name) 
            {
                m_params.AddOpt("tax2_name", tax2Name);
                return this;
            }
            public CreateRequest Tax2Rate(double tax2Rate) 
            {
                m_params.AddOpt("tax2_rate", tax2Rate);
                return this;
            }
            public CreateRequest Tax2JurisType(ChargeBee.Models.Enums.Tax2JurisTypeEnum tax2JurisType) 
            {
                m_params.AddOpt("tax2_juris_type", tax2JurisType);
                return this;
            }
            public CreateRequest Tax2JurisName(string tax2JurisName) 
            {
                m_params.AddOpt("tax2_juris_name", tax2JurisName);
                return this;
            }
            public CreateRequest Tax2JurisCode(string tax2JurisCode) 
            {
                m_params.AddOpt("tax2_juris_code", tax2JurisCode);
                return this;
            }
            public CreateRequest Tax3Name(string tax3Name) 
            {
                m_params.AddOpt("tax3_name", tax3Name);
                return this;
            }
            public CreateRequest Tax3Rate(double tax3Rate) 
            {
                m_params.AddOpt("tax3_rate", tax3Rate);
                return this;
            }
            public CreateRequest Tax3JurisType(ChargeBee.Models.Enums.Tax3JurisTypeEnum tax3JurisType) 
            {
                m_params.AddOpt("tax3_juris_type", tax3JurisType);
                return this;
            }
            public CreateRequest Tax3JurisName(string tax3JurisName) 
            {
                m_params.AddOpt("tax3_juris_name", tax3JurisName);
                return this;
            }
            public CreateRequest Tax3JurisCode(string tax3JurisCode) 
            {
                m_params.AddOpt("tax3_juris_code", tax3JurisCode);
                return this;
            }
            public CreateRequest Tax4Name(string tax4Name) 
            {
                m_params.AddOpt("tax4_name", tax4Name);
                return this;
            }
            public CreateRequest Tax4Rate(double tax4Rate) 
            {
                m_params.AddOpt("tax4_rate", tax4Rate);
                return this;
            }
            public CreateRequest Tax4JurisType(ChargeBee.Models.Enums.Tax4JurisTypeEnum tax4JurisType) 
            {
                m_params.AddOpt("tax4_juris_type", tax4JurisType);
                return this;
            }
            public CreateRequest Tax4JurisName(string tax4JurisName) 
            {
                m_params.AddOpt("tax4_juris_name", tax4JurisName);
                return this;
            }
            public CreateRequest Tax4JurisCode(string tax4JurisCode) 
            {
                m_params.AddOpt("tax4_juris_code", tax4JurisCode);
                return this;
            }
            public CreateRequest ServiceType(CsvTaxRule.ServiceTypeEnum serviceType) 
            {
                m_params.AddOpt("service_type", serviceType);
                return this;
            }
            public CreateRequest TimeZone(string timeZone) 
            {
                m_params.AddOpt("time_zone", timeZone);
                return this;
            }
            public CreateRequest ValidFrom(long validFrom) 
            {
                m_params.AddOpt("valid_from", validFrom);
                return this;
            }
            public CreateRequest ValidTill(long validTill) 
            {
                m_params.AddOpt("valid_till", validTill);
                return this;
            }
            public CreateRequest Overwrite(bool overwrite) 
            {
                m_params.AddOpt("overwrite", overwrite);
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
            [EnumMember(Value = "expired")]
            Expired,
            [EnumMember(Value = "scheduled")]
            Scheduled,

        }
        public enum ServiceTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "digital")]
            Digital,
            [EnumMember(Value = "other")]
            Other,
            [EnumMember(Value = "not_applicable")]
            NotApplicable,

        }

        #region Subclasses

        #endregion
    }
}
