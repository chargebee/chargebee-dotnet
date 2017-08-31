using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class UnbilledCharge : Resource 
    {
    

        #region Methods
        public static InvoiceUnbilledChargesRequest InvoiceUnbilledCharges()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges", "invoice_unbilled_charges");
            return new InvoiceUnbilledChargesRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Delete(string id)
        {
            string url = ApiUtil.BuildUrl("unbilled_charges", CheckNull(id), "delete");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static UnbilledChargeListRequest List()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges");
            return new UnbilledChargeListRequest(url);
        }
        public static InvoiceNowEstimateRequest InvoiceNowEstimate()
        {
            string url = ApiUtil.BuildUrl("unbilled_charges", "invoice_now_estimate");
            return new InvoiceNowEstimateRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public DateTime? DateFrom 
        {
            get { return GetDateTime("date_from", false); }
        }
        public DateTime? DateTo 
        {
            get { return GetDateTime("date_to", false); }
        }
        public int? UnitAmount 
        {
            get { return GetValue<int?>("unit_amount", false); }
        }
        public int? Quantity 
        {
            get { return GetValue<int?>("quantity", false); }
        }
        public int? Amount 
        {
            get { return GetValue<int?>("amount", false); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public int? DiscountAmount 
        {
            get { return GetValue<int?>("discount_amount", false); }
        }
        public string Description 
        {
            get { return GetValue<string>("description", false); }
        }
        public EntityTypeEnum EntityType 
        {
            get { return GetEnum<EntityTypeEnum>("entity_type", true); }
        }
        public string EntityId 
        {
            get { return GetValue<string>("entity_id", false); }
        }
        public bool IsVoided 
        {
            get { return GetValue<bool>("is_voided", true); }
        }
        public DateTime? VoidedAt 
        {
            get { return GetDateTime("voided_at", false); }
        }
        public bool Deleted 
        {
            get { return GetValue<bool>("deleted", true); }
        }
        
        #endregion
        
        #region Requests
        public class InvoiceUnbilledChargesRequest : EntityRequest<InvoiceUnbilledChargesRequest> 
        {
            public InvoiceUnbilledChargesRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public InvoiceUnbilledChargesRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public InvoiceUnbilledChargesRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
        }
        public class UnbilledChargeListRequest : ListRequestBase<UnbilledChargeListRequest> 
        {
            public UnbilledChargeListRequest(string url) 
                    : base(url)
            {
            }

            public UnbilledChargeListRequest IncludeDeleted(bool includeDeleted) 
            {
                m_params.AddOpt("include_deleted", includeDeleted);
                return this;
            }
            public StringFilter<UnbilledChargeListRequest> SubscriptionId() 
            {
                return new StringFilter<UnbilledChargeListRequest>("subscription_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
            public StringFilter<UnbilledChargeListRequest> CustomerId() 
            {
                return new StringFilter<UnbilledChargeListRequest>("customer_id", this).SupportsMultiOperators(true).SupportsPresenceOperator(true);        
            }
        }
        public class InvoiceNowEstimateRequest : EntityRequest<InvoiceNowEstimateRequest> 
        {
            public InvoiceNowEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public InvoiceNowEstimateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription_id", subscriptionId);
                return this;
            }
            public InvoiceNowEstimateRequest CustomerId(string customerId) 
            {
                m_params.AddOpt("customer_id", customerId);
                return this;
            }
        }
        #endregion

        public enum EntityTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("plan_setup")]
            PlanSetup,
            [Description("plan")]
            Plan,
            [Description("addon")]
            Addon,
            [Description("adhoc")]
            Adhoc,

        }

        #region Subclasses

        #endregion
    }
}
