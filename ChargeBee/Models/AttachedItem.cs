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

    public class AttachedItem : Resource 
    {
    
        public AttachedItem() { }

        public AttachedItem(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public AttachedItem(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public AttachedItem(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create(string id)
        {
            string url = ApiUtil.BuildUrl("items", CheckNull(id), "attached_items");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("attached_items", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static RetrieveRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("attached_items", CheckNull(id));
            return new RetrieveRequest(url, HttpMethod.GET);
        }
        public static DeleteRequest Delete(string id)
        {
            string url = ApiUtil.BuildUrl("attached_items", CheckNull(id), "delete");
            return new DeleteRequest(url, HttpMethod.POST);
        }
        public static AttachedItemListRequest List(string id)
        {
            string url = ApiUtil.BuildUrl("items", CheckNull(id), "attached_items");
            return new AttachedItemListRequest(url);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string ParentItemId 
        {
            get { return GetValue<string>("parent_item_id", true); }
        }
        public string ItemId 
        {
            get { return GetValue<string>("item_id", true); }
        }
        public TypeEnum AttachedItemType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public StatusEnum? Status 
        {
            get { return GetEnum<StatusEnum>("status", false); }
        }
        public int? Quantity 
        {
            get { return GetValue<int?>("quantity", false); }
        }
        public string QuantityInDecimal 
        {
            get { return GetValue<string>("quantity_in_decimal", false); }
        }
        public int? BillingCycles 
        {
            get { return GetValue<int?>("billing_cycles", false); }
        }
        public ChargeOnEventEnum ChargeOnEvent 
        {
            get { return GetEnum<ChargeOnEventEnum>("charge_on_event", true); }
        }
        public bool ChargeOnce 
        {
            get { return GetValue<bool>("charge_once", true); }
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
        public ChannelEnum? Channel 
        {
            get { return GetEnum<ChannelEnum>("channel", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest ItemId(string itemId) 
            {
                m_params.Add("item_id", itemId);
                return this;
            }
            public CreateRequest Type(AttachedItem.TypeEnum type) 
            {
                m_params.AddOpt("type", type);
                return this;
            }
            public CreateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateRequest Quantity(int quantity) 
            {
                m_params.AddOpt("quantity", quantity);
                return this;
            }
            public CreateRequest QuantityInDecimal(string quantityInDecimal) 
            {
                m_params.AddOpt("quantity_in_decimal", quantityInDecimal);
                return this;
            }
            public CreateRequest ChargeOnEvent(ChargeBee.Models.Enums.ChargeOnEventEnum chargeOnEvent) 
            {
                m_params.AddOpt("charge_on_event", chargeOnEvent);
                return this;
            }
            public CreateRequest ChargeOnce(bool chargeOnce) 
            {
                m_params.AddOpt("charge_once", chargeOnce);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest ParentItemId(string parentItemId) 
            {
                m_params.Add("parent_item_id", parentItemId);
                return this;
            }
            public UpdateRequest Type(AttachedItem.TypeEnum type) 
            {
                m_params.AddOpt("type", type);
                return this;
            }
            public UpdateRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateRequest Quantity(int quantity) 
            {
                m_params.AddOpt("quantity", quantity);
                return this;
            }
            public UpdateRequest QuantityInDecimal(string quantityInDecimal) 
            {
                m_params.AddOpt("quantity_in_decimal", quantityInDecimal);
                return this;
            }
            public UpdateRequest ChargeOnEvent(ChargeBee.Models.Enums.ChargeOnEventEnum chargeOnEvent) 
            {
                m_params.AddOpt("charge_on_event", chargeOnEvent);
                return this;
            }
            public UpdateRequest ChargeOnce(bool chargeOnce) 
            {
                m_params.AddOpt("charge_once", chargeOnce);
                return this;
            }
        }
        public class RetrieveRequest : EntityRequest<RetrieveRequest> 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveRequest ParentItemId(string parentItemId) 
            {
                m_params.Add("parent_item_id", parentItemId);
                return this;
            }
        }
        public class DeleteRequest : EntityRequest<DeleteRequest> 
        {
            public DeleteRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public DeleteRequest ParentItemId(string parentItemId) 
            {
                m_params.Add("parent_item_id", parentItemId);
                return this;
            }
        }
        public class AttachedItemListRequest : ListRequestBase<AttachedItemListRequest> 
        {
            public AttachedItemListRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<AttachedItemListRequest> Id() 
            {
                return new StringFilter<AttachedItemListRequest>("id", this).SupportsMultiOperators(true);        
            }
            public StringFilter<AttachedItemListRequest> ItemId() 
            {
                return new StringFilter<AttachedItemListRequest>("item_id", this).SupportsMultiOperators(true);        
            }
            public EnumFilter<AttachedItem.TypeEnum, AttachedItemListRequest> Type() 
            {
                return new EnumFilter<AttachedItem.TypeEnum, AttachedItemListRequest>("type", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, AttachedItemListRequest> ItemType() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ItemTypeEnum, AttachedItemListRequest>("item_type", this);        
            }
            public EnumFilter<ChargeBee.Models.Enums.ChargeOnEventEnum, AttachedItemListRequest> ChargeOnEvent() 
            {
                return new EnumFilter<ChargeBee.Models.Enums.ChargeOnEventEnum, AttachedItemListRequest>("charge_on_event", this);        
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "recommended")]
            Recommended,
            [EnumMember(Value = "mandatory")]
            Mandatory,
            [EnumMember(Value = "optional")]
            Optional,

        }
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

        #endregion
    }
}
