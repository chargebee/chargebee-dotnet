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

    public class Usage : Resource 
    {
    

        #region Methods
        public static CreateRequest Create(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "usages");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "usage");
            return new RetrieveRequest(url, HttpMethod.GET);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "delete_usage");
            return new DeleteRequest(url, HttpMethod.POST);
        }
        public static UsageListRequest List()
        {
            string url = ApiUtil.BuildUrl("usages");
            return new UsageListRequest(url);
        }
        public static PdfRequest Pdf()
        {
            string url = ApiUtil.BuildUrl("usages", "pdf");
            return new PdfRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public DateTime UsageDate 
        {
            get { return (DateTime)GetDateTime("usage_date", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string ItemPriceId 
        {
            get { return GetValue<string>("item_price_id", true); }
        }
        public string InvoiceId 
        {
            get { return GetValue<string>("invoice_id", false); }
        }
        public string LineItemId 
        {
            get { return GetValue<string>("line_item_id", false); }
        }
        public string Quantity 
        {
            get { return GetValue<string>("quantity", true); }
        }
        public SourceEnum? Source 
        {
            get { return GetEnum<SourceEnum>("source", false); }
        }
        public string Note 
        {
            get { return GetValue<string>("note", false); }
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
            public CreateRequest ItemPriceId(string itemPriceId) 
            {
                m_params.Add("item_price_id", itemPriceId);
                return this;
            }
            public CreateRequest Quantity(string quantity) 
            {
                m_params.Add("quantity", quantity);
                return this;
            }
            public CreateRequest UsageDate(long usageDate) 
            {
                m_params.Add("usage_date", usageDate);
                return this;
            }
            [Obsolete]
            public CreateRequest DedupeOption(ChargeBee.Models.Enums.DedupeOptionEnum dedupeOption) 
            {
                m_params.AddOpt("dedupe_option", dedupeOption);
                return this;
            }
            public CreateRequest Note(string note) 
            {
                m_params.AddOpt("note", note);
                return this;
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteRequest Id(string id) 
            {
                m_params.Add("id", id);
                return this;
            }
        }
        public class UsageListRequest : ListRequestBase<UsageListRequest> 
        {
            public UsageListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<UsageListRequest> Id() 
            {
                return new StringFilter<UsageListRequest>("id", this);        
            }
            public StringFilter<UsageListRequest> SubscriptionId() 
            {
                return new StringFilter<UsageListRequest>("subscription_id", this);        
            }
            public TimestampFilter<UsageListRequest> UsageDate() 
            {
                return new TimestampFilter<UsageListRequest>("usage_date", this);        
            }
            public StringFilter<UsageListRequest> ItemPriceId() 
            {
                return new StringFilter<UsageListRequest>("item_price_id", this);        
            }
            public StringFilter<UsageListRequest> InvoiceId() 
            {
                return new StringFilter<UsageListRequest>("invoice_id", this).SupportsPresenceOperator(true);        
            }
            public EnumFilter<ChargeBee.Models.Enums.SourceEnum, UsageListRequest> Source() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.SourceEnum, UsageListRequest>("source", this);        
            }
        }
        public class PdfRequest : EntityRequest<PdfRequest> 
        {
            public PdfRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PdfRequest DispositionType(ChargeBee.Models.Enums.DispositionTypeEnum dispositionType) 
            {
                m_params.AddOpt("disposition_type", dispositionType);
                return this;
            }
            public PdfRequest InvoiceId(string invoiceId) 
            {
                m_params.Add("invoice[id]", invoiceId);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
