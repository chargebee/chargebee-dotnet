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

    public class DifferentialPrice : Resource 
    {
    
        public DifferentialPrice() { }

        public DifferentialPrice(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public DifferentialPrice(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public DifferentialPrice(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create(string id)
        {
            string url = ApiUtil.BuildUrl("item_prices", CheckNull(id), "differential_prices");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("differential_prices", CheckNull(id));
            return new RetrieveRequest(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("differential_prices", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("differential_prices", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
        }
        public static DifferentialPriceListRequest List()
        {
            string url = ApiUtil.BuildUrl("differential_prices");
            return new DifferentialPriceListRequest(url);
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
        public string ParentItemId 
        {
            get { return GetValue<string>("parent_item_id", true); }
        }
        public int? Price 
        {
            get { return GetValue<int?>("price", false); }
        }
        public string PriceInDecimal 
        {
            get { return GetValue<string>("price_in_decimal", false); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
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
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        public List<DifferentialPriceTier> Tiers 
        {
            get { return GetResourceList<DifferentialPriceTier>("tiers"); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public List<DifferentialPriceParentPeriod> ParentPeriods 
        {
            get { return GetResourceList<DifferentialPriceParentPeriod>("parent_periods"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest ParentItemId(string parentItemId) 
            {
                m_params.Add("parent_item_id", parentItemId);
                return this;
            }
            public CreateRequest Price(int price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public CreateRequest PriceInDecimal(string priceInDecimal) 
            {
                m_params.AddOpt("price_in_decimal", priceInDecimal);
                return this;
            }
            public CreateRequest ParentPeriodPeriodUnit(int index, DifferentialPriceParentPeriod.PeriodUnitEnum parentPeriodPeriodUnit) 
            {
                m_params.Add("parent_periods[period_unit][" + index + "]", parentPeriodPeriodUnit);
                return this;
            }
            public CreateRequest ParentPeriodPeriod(int index, JArray parentPeriodPeriod) 
            {
                m_params.AddOpt("parent_periods[period][" + index + "]", parentPeriodPeriod);
                return this;
            }
            public CreateRequest TierStartingUnit(int index, int tierStartingUnit) 
            {
                m_params.AddOpt("tiers[starting_unit][" + index + "]", tierStartingUnit);
                return this;
            }
            public CreateRequest TierEndingUnit(int index, int tierEndingUnit) 
            {
                m_params.AddOpt("tiers[ending_unit][" + index + "]", tierEndingUnit);
                return this;
            }
            public CreateRequest TierPrice(int index, int tierPrice) 
            {
                m_params.AddOpt("tiers[price][" + index + "]", tierPrice);
                return this;
            }
            public CreateRequest TierStartingUnitInDecimal(int index, string tierStartingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[starting_unit_in_decimal][" + index + "]", tierStartingUnitInDecimal);
                return this;
            }
            public CreateRequest TierEndingUnitInDecimal(int index, string tierEndingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[ending_unit_in_decimal][" + index + "]", tierEndingUnitInDecimal);
                return this;
            }
            public CreateRequest TierPriceInDecimal(int index, string tierPriceInDecimal) 
            {
                m_params.AddOpt("tiers[price_in_decimal][" + index + "]", tierPriceInDecimal);
                return this;
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveRequest ItemPriceId(string itemPriceId) 
            {
                m_params.Add("item_price_id", itemPriceId);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest ItemPriceId(string itemPriceId) 
            {
                m_params.Add("item_price_id", itemPriceId);
                return this;
            }
            public UpdateRequest Price(int price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public UpdateRequest PriceInDecimal(string priceInDecimal) 
            {
                m_params.AddOpt("price_in_decimal", priceInDecimal);
                return this;
            }
            public UpdateRequest ParentPeriodPeriodUnit(int index, DifferentialPriceParentPeriod.PeriodUnitEnum parentPeriodPeriodUnit) 
            {
                m_params.Add("parent_periods[period_unit][" + index + "]", parentPeriodPeriodUnit);
                return this;
            }
            public UpdateRequest ParentPeriodPeriod(int index, JArray parentPeriodPeriod) 
            {
                m_params.AddOpt("parent_periods[period][" + index + "]", parentPeriodPeriod);
                return this;
            }
            public UpdateRequest TierStartingUnit(int index, int tierStartingUnit) 
            {
                m_params.AddOpt("tiers[starting_unit][" + index + "]", tierStartingUnit);
                return this;
            }
            public UpdateRequest TierEndingUnit(int index, int tierEndingUnit) 
            {
                m_params.AddOpt("tiers[ending_unit][" + index + "]", tierEndingUnit);
                return this;
            }
            public UpdateRequest TierPrice(int index, int tierPrice) 
            {
                m_params.AddOpt("tiers[price][" + index + "]", tierPrice);
                return this;
            }
            public UpdateRequest TierStartingUnitInDecimal(int index, string tierStartingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[starting_unit_in_decimal][" + index + "]", tierStartingUnitInDecimal);
                return this;
            }
            public UpdateRequest TierEndingUnitInDecimal(int index, string tierEndingUnitInDecimal) 
            {
                m_params.AddOpt("tiers[ending_unit_in_decimal][" + index + "]", tierEndingUnitInDecimal);
                return this;
            }
            public UpdateRequest TierPriceInDecimal(int index, string tierPriceInDecimal) 
            {
                m_params.AddOpt("tiers[price_in_decimal][" + index + "]", tierPriceInDecimal);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteRequest ItemPriceId(string itemPriceId) 
            {
                m_params.Add("item_price_id", itemPriceId);
                return this;
            }
        }
        public class DifferentialPriceListRequest : ListRequestBase<DifferentialPriceListRequest> 
        {
            public DifferentialPriceListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<DifferentialPriceListRequest> ItemPriceId() 
            {
                return new StringFilter<DifferentialPriceListRequest>("item_price_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DifferentialPriceListRequest> ItemId() 
            {
                return new StringFilter<DifferentialPriceListRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DifferentialPriceListRequest> Id() 
            {
                return new StringFilter<DifferentialPriceListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<DifferentialPriceListRequest> ParentItemId() 
            {
                return new StringFilter<DifferentialPriceListRequest>("parent_item_id", this).SupportsMultiOperators(true);        
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "active")]
            Active,
            [EnumMember(Value = "deleted")]
            Deleted,

        }

        #region Subclasses
        public class DifferentialPriceTier : Resource
        {

            public int StartingUnit() {
                return GetValue<int>("starting_unit", true);
            }

            public int? EndingUnit() {
                return GetValue<int?>("ending_unit", false);
            }

            public int Price() {
                return GetValue<int>("price", true);
            }

            public string StartingUnitInDecimal() {
                return GetValue<string>("starting_unit_in_decimal", false);
            }

            public string EndingUnitInDecimal() {
                return GetValue<string>("ending_unit_in_decimal", false);
            }

            public string PriceInDecimal() {
                return GetValue<string>("price_in_decimal", false);
            }

        }
        public class DifferentialPriceParentPeriod : Resource
        {
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
                [EnumMember(Value = "year")]
                Year,
            }

            public PeriodUnitEnum PeriodUnit() {
                return GetEnum<PeriodUnitEnum>("period_unit", true);
            }

            public JArray Period() {
                return GetJArray("period", false);
            }

        }

        #endregion
    }
}
