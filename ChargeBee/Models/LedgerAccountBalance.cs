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

    public class LedgerAccountBalance : Resource 
    {
    
        public LedgerAccountBalance() { }

        public LedgerAccountBalance(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public LedgerAccountBalance(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public LedgerAccountBalance(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static LedgerAccountBalanceListLedgerAccountBalancesRequest ListLedgerAccountBalances()
        {
            string url = ApiUtil.BuildUrl("ledger_account_balances");
            return new LedgerAccountBalanceListLedgerAccountBalancesRequest(url).IsJsonRequest(true);
        }
        #endregion
        
        #region Properties
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        public string UnitId 
        {
            get { return GetValue<string>("unit_id", true); }
        }
        public UnitTypeEnum UnitType 
        {
            get { return GetEnum<UnitTypeEnum>("unit_type", true); }
        }
        public DateTime? ModifiedAt 
        {
            get { return GetDateTime("modified_at", false); }
        }
        public LedgerAccountBalanceProvisionedBalance ProvisionedBalance 
        {
            get { return GetSubResource<LedgerAccountBalanceProvisionedBalance>("provisioned_balance"); }
        }
        public LedgerAccountBalanceOverdraftBalance OverdraftBalance 
        {
            get { return GetSubResource<LedgerAccountBalanceOverdraftBalance>("overdraft_balance"); }
        }
        
        #endregion
        
        #region Requests
        public class LedgerAccountBalanceListLedgerAccountBalancesRequest : ListRequestBase<LedgerAccountBalanceListLedgerAccountBalancesRequest> 
        {
            public LedgerAccountBalanceListLedgerAccountBalancesRequest(string url) 
                    : base(url)
            {
            }

            public StringFilter<LedgerAccountBalanceListLedgerAccountBalancesRequest> SubscriptionId() 
            {
                return new StringFilter<LedgerAccountBalanceListLedgerAccountBalancesRequest>("subscription_id", this);        
            }
            public StringFilter<LedgerAccountBalanceListLedgerAccountBalancesRequest> UnitId() 
            {
                return new StringFilter<LedgerAccountBalanceListLedgerAccountBalancesRequest>("unit_id", this);        
            }
        
        }
        #endregion

        public enum UnitTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "credit_unit")]
            CreditUnit,

        }

        #region Subclasses
        public class LedgerAccountBalanceProvisionedBalance : Resource
        {

            public string TotalBalance {
                get { return GetValue<string>("total_balance", true); }
            }

            public string UsableBalance {
                get { return GetValue<string>("usable_balance", true); }
            }

            public string HoldAmount {
                get { return GetValue<string>("hold_amount", true); }
            }

        }
        public class LedgerAccountBalanceOverdraftBalance : Resource
        {

            public bool IsUnlimited {
                get { return GetValue<bool>("is_unlimited", true); }
            }

            public string Limit {
                get { return GetValue<string>("limit", false); }
            }

            public string TotalBalance {
                get { return GetValue<string>("total_balance", false); }
            }

            public string UsableBalance {
                get { return GetValue<string>("usable_balance", false); }
            }

            public string UsedAmount {
                get { return GetValue<string>("used_amount", true); }
            }

            public string HoldAmount {
                get { return GetValue<string>("hold_amount", true); }
            }

        }

        
        #endregion
    }
}
