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

    public class CollectionsDispute : Resource 
    {
    
        public CollectionsDispute() { }

        public CollectionsDispute(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public CollectionsDispute(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public CollectionsDispute(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", true); }
        }
        public string LineItemId 
        {
            get { return GetValue<string>("line_item_id", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public long BilledAmount 
        {
            get { return GetValue<long>("billed_amount", true); }
        }
        public long ClaimedDeduction 
        {
            get { return GetValue<long>("claimed_deduction", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public string DisputeReasonCode 
        {
            get { return GetValue<string>("dispute_reason_code", true); }
        }
        public string ResolvedReasonCode 
        {
            get { return GetValue<string>("resolved_reason_code", false); }
        }
        public string Reason 
        {
            get { return GetValue<string>("reason", false); }
        }
        public DateTime OpenedAt 
        {
            get { return (DateTime)GetDateTime("opened_at", true); }
        }
        public DateTime? ResolvedAt 
        {
            get { return GetDateTime("resolved_at", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public long? UndisputedAmount 
        {
            get { return GetValue<long?>("undisputed_amount", false); }
        }
        
        #endregion
        

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "open")]
            Open,
            [EnumMember(Value = "resolved")]
            Resolved,
            [EnumMember(Value = "withdrawn")]
            Withdrawn,

        }

        #region Subclasses

        #endregion
    }
}
