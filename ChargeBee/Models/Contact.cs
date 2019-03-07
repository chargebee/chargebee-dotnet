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

    public class Contact : Resource 
    {
    

        #region Methods
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string FirstName 
        {
            get { return GetValue<string>("first_name", false); }
        }
        public string LastName 
        {
            get { return GetValue<string>("last_name", false); }
        }
        public string Email 
        {
            get { return GetValue<string>("email", true); }
        }
        public string Phone 
        {
            get { return GetValue<string>("phone", false); }
        }
        public string Label 
        {
            get { return GetValue<string>("label", false); }
        }
        public bool Enabled 
        {
            get { return GetValue<bool>("enabled", true); }
        }
        public bool SendAccountEmail 
        {
            get { return GetValue<bool>("send_account_email", true); }
        }
        public bool SendBillingEmail 
        {
            get { return GetValue<bool>("send_billing_email", true); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
