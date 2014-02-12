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

    public class Download : Resource 
    {
    

        #region Methods
        #endregion
        
        #region Properties
        public string DownloadUrl 
        {
            get { return GetValue<string>("download_url", true); }
        }
        public DateTime ValidTill 
        {
            get { return (DateTime)GetDateTime("valid_till", true); }
        }
        
        #endregion
        


        #region Subclasses

        #endregion
    }
}
