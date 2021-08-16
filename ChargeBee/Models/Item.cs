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

    public class Item : Resource 
    {
    
        public Item() { }

        public Item(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Item(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Item(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("items");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("items", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("items", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static ItemListRequest List()
        {
            string url = ApiUtil.BuildUrl("items");
            return new ItemListRequest(url);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("items", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
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
        public string Description 
        {
            get { return GetValue<string>("description", false); }
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
        public string ItemFamilyId 
        {
            get { return GetValue<string>("item_family_id", false); }
        }
        public TypeEnum ItemType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public bool? IsShippable 
        {
            get { return GetValue<bool?>("is_shippable", false); }
        }
        public bool IsGiftable 
        {
            get { return GetValue<bool>("is_giftable", true); }
        }
        public string RedirectUrl 
        {
            get { return GetValue<string>("redirect_url", false); }
        }
        public bool EnabledForCheckout 
        {
            get { return GetValue<bool>("enabled_for_checkout", true); }
        }
        public bool EnabledInPortal 
        {
            get { return GetValue<bool>("enabled_in_portal", true); }
        }
        public bool? IncludedInMrr 
        {
            get { return GetValue<bool?>("included_in_mrr", false); }
        }
        public ItemApplicabilityEnum ItemApplicability 
        {
            get { return GetEnum<ItemApplicabilityEnum>("item_applicability", true); }
        }
        public string GiftClaimRedirectUrl 
        {
            get { return GetValue<string>("gift_claim_redirect_url", false); }
        }
        public string Unit 
        {
            get { return GetValue<string>("unit", false); }
        }
        public bool Metered 
        {
            get { return GetValue<bool>("metered", true); }
        }
        public UsageCalculationEnum? UsageCalculation 
        {
            get { return GetEnum<UsageCalculationEnum>("usage_calculation", false); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public List<ItemApplicableItem> ApplicableItems 
        {
            get { return GetResourceList<ItemApplicableItem>("applicable_items"); }
        }
        public JToken Metadata 
        {
            get { return GetJToken("metadata", false); }
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
                m_params.Add("id", id);
                return this;
            }
            public CreateRequest Name(string name) 
            {
                m_params.Add("name", name);
                return this;
            }
            public CreateRequest Type(Item.TypeEnum type) 
            {
                m_params.Add("type", type);
                return this;
            }
            public CreateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateRequest ItemFamilyId(string itemFamilyId) 
            {
                m_params.AddOpt("item_family_id", itemFamilyId);
                return this;
            }
            public CreateRequest IsGiftable(bool isGiftable) 
            {
                m_params.AddOpt("is_giftable", isGiftable);
                return this;
            }
            public CreateRequest IsShippable(bool isShippable) 
            {
                m_params.AddOpt("is_shippable", isShippable);
                return this;
            }
            public CreateRequest EnabledInPortal(bool enabledInPortal) 
            {
                m_params.AddOpt("enabled_in_portal", enabledInPortal);
                return this;
            }
            public CreateRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CreateRequest EnabledForCheckout(bool enabledForCheckout) 
            {
                m_params.AddOpt("enabled_for_checkout", enabledForCheckout);
                return this;
            }
            public CreateRequest ItemApplicability(Item.ItemApplicabilityEnum itemApplicability) 
            {
                m_params.AddOpt("item_applicability", itemApplicability);
                return this;
            }
            public CreateRequest ApplicableItems(List<string> applicableItems) 
            {
                m_params.AddOpt("applicable_items", applicableItems);
                return this;
            }
            public CreateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public CreateRequest GiftClaimRedirectUrl(string giftClaimRedirectUrl) 
            {
                m_params.AddOpt("gift_claim_redirect_url", giftClaimRedirectUrl);
                return this;
            }
            public CreateRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public CreateRequest Metered(bool metered) 
            {
                m_params.AddOpt("metered", metered);
                return this;
            }
            public CreateRequest UsageCalculation(Item.UsageCalculationEnum usageCalculation) 
            {
                m_params.AddOpt("usage_calculation", usageCalculation);
                return this;
            }
            public CreateRequest Metadata(JToken metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateRequest IsShippable(bool isShippable) 
            {
                m_params.AddOpt("is_shippable", isShippable);
                return this;
            }
            public UpdateRequest ItemFamilyId(string itemFamilyId) 
            {
                m_params.AddOpt("item_family_id", itemFamilyId);
                return this;
            }
            public UpdateRequest EnabledInPortal(bool enabledInPortal) 
            {
                m_params.AddOpt("enabled_in_portal", enabledInPortal);
                return this;
            }
            public UpdateRequest RedirectUrl(string redirectUrl) 
            {
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public UpdateRequest EnabledForCheckout(bool enabledForCheckout) 
            {
                m_params.AddOpt("enabled_for_checkout", enabledForCheckout);
                return this;
            }
            public UpdateRequest ItemApplicability(Item.ItemApplicabilityEnum itemApplicability) 
            {
                m_params.AddOpt("item_applicability", itemApplicability);
                return this;
            }
            [Obsolete]
            public UpdateRequest ClearApplicableItems(bool clearApplicableItems) 
            {
                m_params.AddOpt("clear_applicable_items", clearApplicableItems);
                return this;
            }
            public UpdateRequest ApplicableItems(List<string> applicableItems) 
            {
                m_params.AddOpt("applicable_items", applicableItems);
                return this;
            }
            public UpdateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public UpdateRequest GiftClaimRedirectUrl(string giftClaimRedirectUrl) 
            {
                m_params.AddOpt("gift_claim_redirect_url", giftClaimRedirectUrl);
                return this;
            }
            public UpdateRequest Metadata(JToken metadata) 
            {
                m_params.AddOpt("metadata", metadata);
                return this;
            }
            public UpdateRequest IncludedInMrr(bool includedInMrr) 
            {
                m_params.AddOpt("included_in_mrr", includedInMrr);
                return this;
            }
            public UpdateRequest Status(Item.StatusEnum status) 
            {
                m_params.AddOpt("status", status);
                return this;
            }
        }
        public class ItemListRequest : ListRequestBase<ItemListRequest> 
        {
            public ItemListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<ItemListRequest> Id() 
            {
                return new StringFilter<ItemListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<ItemListRequest> ItemFamilyId() 
            {
                return new StringFilter<ItemListRequest>("item_family_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<Item.TypeEnum, ItemListRequest> Type() 
            {
                return new EnumFilter<Item.TypeEnum, ItemListRequest>("type", this);        
            }
            public StringFilter<ItemListRequest> Name() 
            {
                return new StringFilter<ItemListRequest>("name", this);        
            }
            public EnumFilter<Item.ItemApplicabilityEnum, ItemListRequest> ItemApplicability() 
            {
                return new EnumFilter<Item.ItemApplicabilityEnum, ItemListRequest>("item_applicability", this);        
            }
            public EnumFilter<Item.StatusEnum, ItemListRequest> Status() 
            {
                return new EnumFilter<Item.StatusEnum, ItemListRequest>("status", this);        
            }
            public BooleanFilter<ItemListRequest> IsGiftable() 
            {
                return new BooleanFilter<ItemListRequest>("is_giftable", this);        
            }
            public TimestampFilter<ItemListRequest> UpdatedAt() 
            {
                return new TimestampFilter<ItemListRequest>("updated_at", this);        
            }
            public BooleanFilter<ItemListRequest> EnabledForCheckout() 
            {
                return new BooleanFilter<ItemListRequest>("enabled_for_checkout", this);        
            }
            public BooleanFilter<ItemListRequest> EnabledInPortal() 
            {
                return new BooleanFilter<ItemListRequest>("enabled_in_portal", this);        
            }
            public BooleanFilter<ItemListRequest> Metered() 
            {
                return new BooleanFilter<ItemListRequest>("metered", this);        
            }
            public EnumFilter<Item.UsageCalculationEnum, ItemListRequest> UsageCalculation() 
            {
                return new EnumFilter<Item.UsageCalculationEnum, ItemListRequest>("usage_calculation", this);        
            }
            public ItemListRequest SortByName(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","name");
                return this;
            }
            public ItemListRequest SortById(SortOrderEnum order) {
                m_params.AddOpt("sort_by["+order.ToString().ToLower()+"]","id");
                return this;
            }
            public ItemListRequest SortByUpdatedAt(SortOrderEnum order) {
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
        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "plan")]
            Plan,
            [EnumMember(Value = "addon")]
            Addon,
            [EnumMember(Value = "charge")]
            Charge,

        }
        public enum ItemApplicabilityEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "all")]
            All,
            [EnumMember(Value = "restricted")]
            Restricted,

        }
        public enum UsageCalculationEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "sum_of_usages")]
            SumOfUsages,
            [EnumMember(Value = "last_usage")]
            LastUsage,
            [EnumMember(Value = "max_usage")]
            MaxUsage,

        }

        #region Subclasses
        public class ItemApplicableItem : Resource
        {

            public string Id() {
                return GetValue<string>("id", false);
            }

        }

        #endregion
    }
}
