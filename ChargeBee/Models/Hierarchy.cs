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

    public class Hierarchy : Resource 
    {
    

        #region Methods
        #endregion
        
        #region Properties
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public string ParentId 
        {
            get { return GetValue<string>("parent_id", false); }
        }
        public string PaymentOwnerId 
        {
            get { return GetValue<string>("payment_owner_id", true); }
        }
        public string InvoiceOwnerId 
        {
            get { return GetValue<string>("invoice_owner_id", true); }
        }
        public List<string> ChildrenIds 
        {
            get { return GetList<string>("children_ids"); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
