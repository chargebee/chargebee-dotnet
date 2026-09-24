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

    public class PaymentSchedule : Resource 
    {
    
        public PaymentSchedule() { }

        public PaymentSchedule(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PaymentSchedule(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PaymentSchedule(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static PaymentScheduleListRequest List()
        {
            string url = ApiUtil.BuildUrl("payment_schedules");
            var request = new PaymentScheduleListRequest(url);
            request.SetTelemetryResource("paymentSchedule");
            request.SetTelemetryOperation("list");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string SchemeId 
        {
            get { return GetValue<string>("scheme_id", true); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", true); }
        }
        public long? Amount 
        {
            get { return GetValue<long?>("amount", false); }
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
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", false); }
        }
        public List<PaymentScheduleScheduleEntry> ScheduleEntries 
        {
            get { return GetResourceList<PaymentScheduleScheduleEntry>("schedule_entries"); }
        }
        public List<PaymentScheduleReferenceTransaction> ReferenceTransactions 
        {
            get { return GetResourceList<PaymentScheduleReferenceTransaction>("reference_transactions"); }
        }
        
        #endregion
        
        #region Requests
        public class PaymentScheduleListRequest : ListRequestBase<PaymentScheduleListRequest> 
        {
            public PaymentScheduleListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<PaymentScheduleListRequest> InvoiceId() 
            {
                return new StringFilter<PaymentScheduleListRequest>("invoice_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<PaymentScheduleListRequest> Id() 
            {
                return new StringFilter<PaymentScheduleListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public TimestampFilter<PaymentScheduleListRequest> UpdatedAt() 
            {
                return new TimestampFilter<PaymentScheduleListRequest>("updated_at", this);        
            }
        }
        #endregion

        public enum EntityTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "invoice")]
            Invoice,

        }

        #region Subclasses
        public class PaymentScheduleScheduleEntry : Resource
        {
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

            public string Id {
                get { return GetValue<string>("id", true); }
            }

            public DateTime Date {
                get { return (DateTime)GetDateTime("date", true); }
            }

            public long Amount {
                get { return GetValue<long>("amount", true); }
            }

            public long ScheduledAmount {
                get { return GetValue<long>("scheduled_amount", true); }
            }

            public StatusEnum Status {
                get { return GetEnum<StatusEnum>("status", true); }
            }

        }
        public class PaymentScheduleReferenceTransaction : Resource
        {

            public string ScheduleEntryId {
                get { return GetValue<string>("schedule_entry_id", true); }
            }

            public long? AppliedAmount {
                get { return GetValue<long?>("applied_amount", false); }
            }

            public string TxnId {
                get { return GetValue<string>("txn_id", true); }
            }

            public Transaction.StatusEnum? TxnStatus {
                get { return GetEnum<Transaction.StatusEnum>("txn_status", false); }
            }

            public DateTime? TxnDate {
                get { return GetDateTime("txn_date", false); }
            }

            public long? TxnAmount {
                get { return GetValue<long?>("txn_amount", false); }
            }

        }

        #endregion
    }
}
