using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;

namespace ChargeBee.Models
{

    public class Order : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("orders");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("orders", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("orders");
            return new ListRequest(url);
        }
        public static ListRequest OrdersForInvoice(string id)
        {
            string url = ApiUtil.BuildUrl("invoices", CheckNull(id), "orders");
            return new ListRequest(url);
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
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public string ReferenceId 
        {
            get { return GetValue<string>("reference_id", false); }
        }
        public string FulfillmentStatus 
        {
            get { return GetValue<string>("fulfillment_status", false); }
        }
        public string Note 
        {
            get { return GetValue<string>("note", false); }
        }
        public string TrackingId 
        {
            get { return GetValue<string>("tracking_id", false); }
        }
        public string BatchId 
        {
            get { return GetValue<string>("batch_id", false); }
        }
        public string CreatedBy 
        {
            get { return GetValue<string>("created_by", false); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime StatusUpdateAt 
        {
            get { return (DateTime)GetDateTime("status_update_at", true); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public CreateRequest InvoiceId(string invoiceId) 
            {
                m_params.Add("invoice_id", invoiceId);
                return this;
            }
            public CreateRequest Status(StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public CreateRequest ReferenceId(string referenceId) 
            {
                m_params.AddOpt("reference_id", referenceId);
                return this;
            }
            public CreateRequest FulfillmentStatus(string fulfillmentStatus) 
            {
                m_params.AddOpt("fulfillment_status", fulfillmentStatus);
                return this;
            }
            public CreateRequest Note(string note) 
            {
                m_params.AddOpt("note", note);
                return this;
            }
            public CreateRequest TrackingId(string trackingId) 
            {
                m_params.AddOpt("tracking_id", trackingId);
                return this;
            }
            public CreateRequest BatchId(string batchId) 
            {
                m_params.AddOpt("batch_id", batchId);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Status(StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public UpdateRequest ReferenceId(string referenceId) 
            {
                m_params.AddOpt("reference_id", referenceId);
                return this;
            }
            public UpdateRequest FulfillmentStatus(string fulfillmentStatus) 
            {
                m_params.AddOpt("fulfillment_status", fulfillmentStatus);
                return this;
            }
            public UpdateRequest Note(string note) 
            {
                m_params.AddOpt("note", note);
                return this;
            }
            public UpdateRequest TrackingId(string trackingId) 
            {
                m_params.AddOpt("tracking_id", trackingId);
                return this;
            }
            public UpdateRequest BatchId(string batchId) 
            {
                m_params.AddOpt("batch_id", batchId);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("new")]
            New,
            [Description("processing")]
            Processing,
            [Description("complete")]
            Complete,
            [Description("cancelled")]
            Cancelled,
            [Description("voided")]
            Voided,

        }

        #region Subclasses

        #endregion
    }
}
