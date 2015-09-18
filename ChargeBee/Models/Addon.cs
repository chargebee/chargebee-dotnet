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

    public class Addon : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("addons");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static UpdateRequest Update(string id)
        {
            string url = ApiUtil.BuildUrl("addons", CheckNull(id));
            return new UpdateRequest(url, HttpMethod.POST);
        }
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("addons");
            return new ListRequest(url);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("addons", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("addons", CheckNull(id), "delete");
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
        public string InvoiceName 
        {
            get { return GetValue<string>("invoice_name", false); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public TypeEnum AddonType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public ChargeTypeEnum ChargeType 
        {
            get { return GetEnum<ChargeTypeEnum>("charge_type", true); }
        }
        public int Price 
        {
            get { return GetValue<int>("price", true); }
        }
        public int? Period 
        {
            get { return GetValue<int?>("period", false); }
        }
        public PeriodUnitEnum PeriodUnit 
        {
            get { return GetEnum<PeriodUnitEnum>("period_unit", true); }
        }
        public string Unit 
        {
            get { return GetValue<string>("unit", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public string InvoiceNotes 
        {
            get { return GetValue<string>("invoice_notes", false); }
        }
        public bool? Taxable 
        {
            get { return GetValue<bool?>("taxable", false); }
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
            public CreateRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public CreateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public CreateRequest ChargeType(ChargeTypeEnum chargeType) 
            {
                m_params.Add("charge_type", chargeType);
                return this;
            }
            public CreateRequest Price(int price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public CreateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public CreateRequest PeriodUnit(PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public CreateRequest Type(TypeEnum type) 
            {
                m_params.Add("type", type);
                return this;
            }
            public CreateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public CreateRequest Taxable(bool taxable) 
            {
                m_params.AddOpt("taxable", taxable);
                return this;
            }
            public CreateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest<UpdateRequest> 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest Id(string id) 
            {
                m_params.AddOpt("id", id);
                return this;
            }
            public UpdateRequest Name(string name) 
            {
                m_params.AddOpt("name", name);
                return this;
            }
            public UpdateRequest InvoiceName(string invoiceName) 
            {
                m_params.AddOpt("invoice_name", invoiceName);
                return this;
            }
            public UpdateRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public UpdateRequest ChargeType(ChargeTypeEnum chargeType) 
            {
                m_params.AddOpt("charge_type", chargeType);
                return this;
            }
            public UpdateRequest Price(int price) 
            {
                m_params.AddOpt("price", price);
                return this;
            }
            public UpdateRequest Period(int period) 
            {
                m_params.AddOpt("period", period);
                return this;
            }
            public UpdateRequest PeriodUnit(PeriodUnitEnum periodUnit) 
            {
                m_params.AddOpt("period_unit", periodUnit);
                return this;
            }
            public UpdateRequest Type(TypeEnum type) 
            {
                m_params.AddOpt("type", type);
                return this;
            }
            public UpdateRequest Unit(string unit) 
            {
                m_params.AddOpt("unit", unit);
                return this;
            }
            public UpdateRequest Taxable(bool taxable) 
            {
                m_params.AddOpt("taxable", taxable);
                return this;
            }
            public UpdateRequest InvoiceNotes(string invoiceNotes) 
            {
                m_params.AddOpt("invoice_notes", invoiceNotes);
                return this;
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("on_off")]
            OnOff,
            [Description("quantity")]
            Quantity,

        }
        public enum ChargeTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("recurring")]
            Recurring,
            [Description("non_recurring")]
            NonRecurring,

        }
        public enum PeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("week")]
            Week,
            [Description("month")]
            Month,
            [Description("year")]
            Year,
            [Description("not_applicable")]
            NotApplicable,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("active")]
            Active,
            [Description("archived")]
            Archived,
            [Description("deleted")]
            Deleted,

        }

        #region Subclasses

        #endregion
    }
}
