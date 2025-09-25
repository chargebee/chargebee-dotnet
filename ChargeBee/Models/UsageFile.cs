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

    public class UsageFile : Resource 
    {
    
        public UsageFile() { }

        public UsageFile(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public UsageFile(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public UsageFile(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static UploadUrlRequest UploadUrl()
        {
            string url = ApiUtil.BuildUrl("usage_files", "upload_url");
            return new UploadUrlRequest(url, HttpMethod.POST).SetSubDomain("file-ingest").SetIdempotent(false);
        }
        public static ProcessingStatusRequest ProcessingStatus(string id)
        {
            string url = ApiUtil.BuildUrl("usage_files", CheckNull(id), "processing_status");
            return new ProcessingStatusRequest(url, HttpMethod.GET).SetSubDomain("file-ingest");
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
        public string MimeType 
        {
            get { return GetValue<string>("mime_type", true); }
        }
        public string ErrorCode 
        {
            get { return GetValue<string>("error_code", false); }
        }
        public string ErrorReason 
        {
            get { return GetValue<string>("error_reason", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public long? TotalRecordsCount 
        {
            get { return GetValue<long?>("total_records_count", false); }
        }
        public long? ProcessedRecordsCount 
        {
            get { return GetValue<long?>("processed_records_count", false); }
        }
        public long? FailedRecordsCount 
        {
            get { return GetValue<long?>("failed_records_count", false); }
        }
        public long? FileSizeInBytes 
        {
            get { return GetValue<long?>("file_size_in_bytes", false); }
        }
        public DateTime? ProcessingStartedAt 
        {
            get { return GetDateTime("processing_started_at", false); }
        }
        public DateTime? ProcessingCompletedAt 
        {
            get { return GetDateTime("processing_completed_at", false); }
        }
        public string UploadedBy 
        {
            get { return GetValue<string>("uploaded_by", false); }
        }
        public DateTime? UploadedAt 
        {
            get { return GetDateTime("uploaded_at", false); }
        }
        public string ErrorFilePath 
        {
            get { return GetValue<string>("error_file_path", false); }
        }
        public string ErrorFileUrl 
        {
            get { return GetValue<string>("error_file_url", false); }
        }
        public UsageFileUploadDetail UploadDetails 
        {
            get { return GetSubResource<UsageFileUploadDetail>("upload_details"); }
        }
        
        #endregion
        
        #region Requests
        public class UploadUrlRequest : EntityRequest<UploadUrlRequest> 
        {
            public UploadUrlRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UploadUrlRequest FileName(string fileName) 
            {
                m_params.Add("file_name", fileName);
                return this;
            }
            public UploadUrlRequest MimeType(string mimeType) 
            {
                m_params.Add("mime_type", mimeType);
                return this;
            }
        }
        public class ProcessingStatusRequest : EntityRequest<ProcessingStatusRequest> 
        {
            public ProcessingStatusRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "queued")]
            Queued,
            [EnumMember(Value = "imported")]
            Imported,
            [EnumMember(Value = "processing")]
            Processing,
            [EnumMember(Value = "processed")]
            Processed,
            [EnumMember(Value = "failed")]
            Failed,

        }

        #region Subclasses
        public class UsageFileUploadDetail : Resource
        {

            public string Url {
                get { return GetValue<string>("url", true); }
            }

            public DateTime ExpiresAt {
                get { return (DateTime)GetDateTime("expires_at", true); }
            }

        }

        #endregion
    }
}
