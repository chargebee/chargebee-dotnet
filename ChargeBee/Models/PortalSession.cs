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

    public class PortalSession : Resource 
    {
    

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("portal_sessions");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("portal_sessions", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static EntityRequest<Type> Logout(string id)
        {
            string url = ApiUtil.BuildUrl("portal_sessions", CheckNull(id), "logout");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string AccessUrl 
        {
            get { return GetValue<string>("access_url", true); }
        }
        public string RedirectUrl 
        {
            get { return GetValue<string>("redirect_url", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime? ExpiresAt 
        {
            get { return GetDateTime("expires_at", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", true); }
        }
        public DateTime? LoginAt 
        {
            get { return GetDateTime("login_at", false); }
        }
        public DateTime? LogoutAt 
        {
            get { return GetDateTime("logout_at", false); }
        }
        public string LoginIpaddress 
        {
            get { return GetValue<string>("login_ipaddress", false); }
        }
        public string LogoutIpaddress 
        {
            get { return GetValue<string>("logout_ipaddress", false); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest RedirectUrl(string redirectUrl) 
            {
                m_params.Add("redirect_url", redirectUrl);
                return this;
            }
            public CreateRequest CustomerId(string customerId) 
            {
                m_params.Add("customer[id]", customerId);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("created")]
            Created,
            [Description("logged_in")]
            LoggedIn,
            [Description("logged_out")]
            LoggedOut,

        }

        #region Subclasses

        #endregion
    }
}
