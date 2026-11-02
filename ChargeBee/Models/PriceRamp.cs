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

    public class PriceRamp : Resource 
    {
    
        public PriceRamp() { }

        public PriceRamp(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public PriceRamp(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public PriceRamp(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("price_ramps");
            var request = new CreateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("priceRamp");
            request.SetTelemetryOperation("create");
            return request;
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("price_ramps", CheckNull(id));
            var request = new RetrieveRequest(url, HttpMethod.GET);
            request.SetTelemetryResource("priceRamp");
            request.SetTelemetryOperation("retrieve");
            return request;
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("price_ramps", CheckNull(id));
            var request = new UpdateRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("priceRamp");
            request.SetTelemetryOperation("update");
            return request;
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("price_ramps", CheckNull(id), "delete");
            var request = new DeleteRequest(url, HttpMethod.POST);
            request.SetTelemetryResource("priceRamp");
            request.SetTelemetryOperation("delete");
            return request;
        }
        public static PriceRampListRequest List()
        {
            string url = ApiUtil.BuildUrl("price_ramps");
            var request = new PriceRampListRequest(url);
            request.SetTelemetryResource("priceRamp");
            request.SetTelemetryOperation("list");
            return request;
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string ItemPriceId 
        {
            get { return GetValue<string>("item_price_id", true); }
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
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public List<PriceRampRampInterval> RampIntervals 
        {
            get { return GetResourceList<PriceRampRampInterval>("ramp_intervals"); }
        }
        public string BusinessEntityId 
        {
            get { return GetValue<string>("business_entity_id", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest ItemPriceId(string itemPriceId) 
            {
                m_params.Add("item_price_id", itemPriceId);
                return this;
            }
            public CreateRequest BusinessEntityId(string businessEntityId) 
            {
                m_params.AddOpt("business_entity_id", businessEntityId);
                return this;
            }
            public CreateRequest RampIntervalStartingBillingCycle(int index, int rampIntervalStartingBillingCycle) 
            {
                m_params.Add("ramp_intervals[starting_billing_cycle][" + index + "]", rampIntervalStartingBillingCycle);
                return this;
            }
            public CreateRequest RampIntervalEndingBillingCycle(int index, int rampIntervalEndingBillingCycle) 
            {
                m_params.AddOpt("ramp_intervals[ending_billing_cycle][" + index + "]", rampIntervalEndingBillingCycle);
                return this;
            }
            public CreateRequest RampIntervalApplyCatalogPrice(int index, bool rampIntervalApplyCatalogPrice) 
            {
                m_params.AddOpt("ramp_intervals[apply_catalog_price][" + index + "]", rampIntervalApplyCatalogPrice);
                return this;
            }
            public CreateRequest RampIntervalPrice(int index, long rampIntervalPrice) 
            {
                m_params.AddOpt("ramp_intervals[price][" + index + "]", rampIntervalPrice);
                return this;
            }
            public CreateRequest RampIntervalPriceInDecimal(int index, string rampIntervalPriceInDecimal) 
            {
                m_params.AddOpt("ramp_intervals[price_in_decimal][" + index + "]", rampIntervalPriceInDecimal);
                return this;
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Status(PriceRamp.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
            public UpdateRequest RampIntervalStartingBillingCycle(int index, int rampIntervalStartingBillingCycle) 
            {
                m_params.Add("ramp_intervals[starting_billing_cycle][" + index + "]", rampIntervalStartingBillingCycle);
                return this;
            }
            public UpdateRequest RampIntervalEndingBillingCycle(int index, int rampIntervalEndingBillingCycle) 
            {
                m_params.AddOpt("ramp_intervals[ending_billing_cycle][" + index + "]", rampIntervalEndingBillingCycle);
                return this;
            }
            public UpdateRequest RampIntervalApplyCatalogPrice(int index, bool rampIntervalApplyCatalogPrice) 
            {
                m_params.AddOpt("ramp_intervals[apply_catalog_price][" + index + "]", rampIntervalApplyCatalogPrice);
                return this;
            }
            public UpdateRequest RampIntervalPrice(int index, long rampIntervalPrice) 
            {
                m_params.AddOpt("ramp_intervals[price][" + index + "]", rampIntervalPrice);
                return this;
            }
            public UpdateRequest RampIntervalPriceInDecimal(int index, string rampIntervalPriceInDecimal) 
            {
                m_params.AddOpt("ramp_intervals[price_in_decimal][" + index + "]", rampIntervalPriceInDecimal);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

        }
        public class PriceRampListRequest : ListRequestBase<PriceRampListRequest> 
        {
            public PriceRampListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<PriceRampListRequest> Id() 
            {
                return new StringFilter<PriceRampListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<PriceRampListRequest> ItemPriceId() 
            {
                return new StringFilter<PriceRampListRequest>("item_price_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<PriceRamp.StatusEnum, PriceRampListRequest> Status() 
            {
                return new EnumFilter<PriceRamp.StatusEnum, PriceRampListRequest>("status", this);        
            }
            public TimestampFilter<PriceRampListRequest> UpdatedAt() 
            {
                return new TimestampFilter<PriceRampListRequest>("updated_at", this);        
            }
            public StringFilter<PriceRampListRequest> BusinessEntityId() 
            {
                return new StringFilter<PriceRampListRequest>("business_entity_id", this).SupportsPresenceOperator(true);        
            }
            public BooleanFilter<PriceRampListRequest> IncludeSiteLevelResources() 
            {
                return new BooleanFilter<PriceRampListRequest>("include_site_level_resources", this);        
            }
            
            public PriceRampListRequest SortById(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","id");
                return this;
            }
            public PriceRampListRequest SortByStatus(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","status");
                return this;
            }
            public PriceRampListRequest SortByUpdatedAt(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","updated_at");
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
            [EnumMember(Value = "deleted")]
            Deleted,

        }

        #region Subclasses
        public class PriceRampRampInterval : Resource
        {

            public int StartingBillingCycle {
                get { return GetValue<int>("starting_billing_cycle", true); }
            }

            public int? EndingBillingCycle {
                get { return GetValue<int?>("ending_billing_cycle", false); }
            }

            public bool? ApplyCatalogPrice {
                get { return GetValue<bool?>("apply_catalog_price", false); }
            }

            public long? Price {
                get { return GetValue<long?>("price", false); }
            }

            public string PriceInDecimal {
                get { return GetValue<string>("price_in_decimal", false); }
            }

        }

        #endregion
    }
}
