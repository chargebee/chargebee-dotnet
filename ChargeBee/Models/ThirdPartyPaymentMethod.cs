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

    public class ThirdPartyPaymentMethod : Resource 
    {
    

        #region Methods
        #endregion
        
        #region Properties
        public TypeEnum ThirdPartyPaymentMethodType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public GatewayEnum Gateway 
        {
            get { return GetEnum<GatewayEnum>("gateway", true); }
        }
        public string GatewayAccountId 
        {
            get { return GetValue<string>("gateway_account_id", false); }
        }
        public string ReferenceId 
        {
            get { return GetValue<string>("reference_id", true); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
