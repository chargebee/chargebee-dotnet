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
using System.Threading;

namespace ChargeBee.Models
{

    public class Export : Resource 
    {
    

        #region Methods
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("exports", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static RevenueRecognitionRequest RevenueRecognition()
        {
            string url = ApiUtil.BuildUrl("exports", "revenue_recognition");
            return new RevenueRecognitionRequest(url, HttpMethod.POST);
        }
        public static DeferredRevenueRequest DeferredRevenue()
        {
            string url = ApiUtil.BuildUrl("exports", "deferred_revenue");
            return new DeferredRevenueRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string OperationType 
        {
            get { return GetValue<string>("operation_type", true); }
        }
        public MimeTypeEnum MimeType 
        {
            get { return GetEnum<MimeTypeEnum>("mime_type", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public ExportDownload Download 
        {
            get { return GetSubResource<ExportDownload>("download"); }
        }
        public Export WaitForExportCompletion() 
		{
			int count = 0;
			int sleepTime = System.Environment.GetEnvironmentVariable("cb.dotnet.export.sleep.millis") != null
				? Convert.ToInt32(System.Environment.GetEnvironmentVariable("cb.dotnet.export.sleep.millis"))
				: 10000;
			while(this.Status == Export.StatusEnum.InProcess){
				if(count++ > 50)
				{
					throw new SystemException("Export is taking too long");
				}
				Thread.Sleep(sleepTime);
				EntityRequest<Type> req = Retrieve(Id);
				this.JObj = req.Request().Export.JObj;
			}
			return this;
		}		
        #endregion
        
        #region Requests
        public class RevenueRecognitionRequest : EntityRequest<RevenueRecognitionRequest> 
        {
            public RevenueRecognitionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RevenueRecognitionRequest ReportBy(ChargeBee.Models.Enums.ReportByEnum reportBy) 
            {
                m_params.Add("report_by", reportBy);
                return this;
            }
            public RevenueRecognitionRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public RevenueRecognitionRequest ReportFromMonth(int reportFromMonth) 
            {
                m_params.Add("report_from_month", reportFromMonth);
                return this;
            }
            public RevenueRecognitionRequest ReportFromYear(int reportFromYear) 
            {
                m_params.Add("report_from_year", reportFromYear);
                return this;
            }
            public RevenueRecognitionRequest ReportToMonth(int reportToMonth) 
            {
                m_params.Add("report_to_month", reportToMonth);
                return this;
            }
            public RevenueRecognitionRequest ReportToYear(int reportToYear) 
            {
                m_params.Add("report_to_year", reportToYear);
                return this;
            }
            public RevenueRecognitionRequest IncludeDiscounts(bool includeDiscounts) 
            {
                m_params.AddOpt("include_discounts", includeDiscounts);
                return this;
            }

        }
        public class DeferredRevenueRequest : EntityRequest<DeferredRevenueRequest> 
        {
            public DeferredRevenueRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeferredRevenueRequest ReportBy(ChargeBee.Models.Enums.ReportByEnum reportBy) 
            {
                m_params.Add("report_by", reportBy);
                return this;
            }
            public DeferredRevenueRequest CurrencyCode(string currencyCode) 
            {
                m_params.AddOpt("currency_code", currencyCode);
                return this;
            }
            public DeferredRevenueRequest ReportFromMonth(int reportFromMonth) 
            {
                m_params.Add("report_from_month", reportFromMonth);
                return this;
            }
            public DeferredRevenueRequest ReportFromYear(int reportFromYear) 
            {
                m_params.Add("report_from_year", reportFromYear);
                return this;
            }
            public DeferredRevenueRequest ReportToMonth(int reportToMonth) 
            {
                m_params.Add("report_to_month", reportToMonth);
                return this;
            }
            public DeferredRevenueRequest ReportToYear(int reportToYear) 
            {
                m_params.Add("report_to_year", reportToYear);
                return this;
            }
            public DeferredRevenueRequest IncludeDiscounts(bool includeDiscounts) 
            {
                m_params.AddOpt("include_discounts", includeDiscounts);
                return this;
            }
        }
        #endregion

        public enum MimeTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("pdf")]
            Pdf,
            [Description("zip")]
            Zip,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("in_process")]
            InProcess,
            [Description("completed")]
            Completed,
            [Description("failed")]
            Failed,

        }

        #region Subclasses
        public class ExportDownload : Resource
        {

            public string DownloadUrl() {
                return GetValue<string>("download_url", true);
            }

            public DateTime ValidTill() {
                return (DateTime)GetDateTime("valid_till", true);
            }

        }

        #endregion
    }
}
