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

    public class LedgerEntry : Resource 
    {
    
        public LedgerEntry() { }

        public LedgerEntry(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public LedgerEntry(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public LedgerEntry(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public AccountTypeEnum? AccountType 
        {
            get { return GetEnum<AccountTypeEnum>("account_type", false); }
        }
        public string UnitId 
        {
            get { return GetValue<string>("unit_id", false); }
        }
        public UnitTypeEnum? UnitType 
        {
            get { return GetEnum<UnitTypeEnum>("unit_type", false); }
        }
        public string Amount 
        {
            get { return GetValue<string>("amount", true); }
        }
        public string GrantBlockStartBalance 
        {
            get { return GetValue<string>("grant_block_start_balance", true); }
        }
        public string GrantBlockEndBalance 
        {
            get { return GetValue<string>("grant_block_end_balance", true); }
        }
        public string AccountStartBalance 
        {
            get { return GetValue<string>("account_start_balance", true); }
        }
        public string AccountEndBalance 
        {
            get { return GetValue<string>("account_end_balance", true); }
        }
        public TypeEnum LedgerEntryType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public string LedgerOperationId 
        {
            get { return GetValue<string>("ledger_operation_id", true); }
        }
        public string GrantBlockId 
        {
            get { return GetValue<string>("grant_block_id", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime ModifiedAt 
        {
            get { return (DateTime)GetDateTime("modified_at", true); }
        }
        
        #endregion
        

        public enum AccountTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "provisioned")]
            Provisioned,
            [EnumMember(Value = "overdraft")]
            Overdraft,

        }
        public enum UnitTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "credit_unit")]
            CreditUnit,

        }

        #region Subclasses

        #endregion
    }
}
