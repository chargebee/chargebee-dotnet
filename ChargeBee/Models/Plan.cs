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

    public class Plan : Resource 
    {
    

        #region Methods
        public static ListRequest List()
        {
            string url = ApiUtil.BuildUrl("plans");
            return new ListRequest(url);
        }
        public static EntityRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("plans", CheckNull(id));
            return new EntityRequest(url);
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
        public int Price 
        {
            get { return GetValue<int>("price", true); }
        }
        public int Period 
        {
            get { return GetValue<int>("period", true); }
        }
        public PeriodUnitEnum PeriodUnit 
        {
            get { return GetEnum<PeriodUnitEnum>("period_unit", true); }
        }
        public int? TrialPeriod 
        {
            get { return GetValue<int?>("trial_period", false); }
        }
        public TrialPeriodUnitEnum? TrialPeriodUnit 
        {
            get { return GetEnum<TrialPeriodUnitEnum>("trial_period_unit", false); }
        }
        public int FreeQuantity 
        {
            get { return GetValue<int>("free_quantity", true); }
        }
        public int? SetupCost 
        {
            get { return GetValue<int?>("setup_cost", false); }
        }
        public double? DowngradePenalty 
        {
            get { return GetValue<double?>("downgrade_penalty", false); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? ArchivedAt 
        {
            get { return GetDateTime("archived_at", false); }
        }
        public int? BillingCycles 
        {
            get { return GetValue<int?>("billing_cycles", false); }
        }
        public string RedirectUrl 
        {
            get { return GetValue<string>("redirect_url", false); }
        }

        #endregion
        

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

        }
        public enum TrialPeriodUnitEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("day")]
            Day,
            [Description("month")]
            Month,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("active")]
            Active,
            [Description("archived")]
            Archived,

        }

        #region Subclasses

        #endregion
    }
}
