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
        public static ActivateRequest Activate(string id)
        {
            string url = ApiUtil.BuildUrl("portal_sessions", CheckNull(id), "activate");
            return new ActivateRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public string Token 
        {
            get { return GetValue<string>("token", true); }
        }
        public string AccessUrl 
        {
            get { return GetValue<string>("access_url", true); }
        }
        public string RedirectUrl 
        {
            get { return GetValue<string>("redirect_url", false); }
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
        public List<PortalSessionLinkedCustomer> LinkedCustomers 
        {
            get { return GetResourceList<PortalSessionLinkedCustomer>("linked_customers"); }
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
                m_params.AddOpt("redirect_url", redirectUrl);
                return this;
            }
            public CreateRequest ForwardUrl(string forwardUrl) 
            {
                m_params.AddOpt("forward_url", forwardUrl);
                return this;
            }
            public CreateRequest CustomerId(string customerId) 
            {
                m_params.Add("customer[id]", customerId);
                return this;
            }
        }
        public class ActivateRequest : EntityRequest<ActivateRequest> 
        {
            public ActivateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public ActivateRequest Token(string token) 
            {
                m_params.Add("token", token);
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
            [Description("not_yet_activated")]
            NotYetActivated,
            [Description("activated")]
            Activated,

        }

        #region Subclasses
        public class PortalSessionLinkedCustomer : Resource
        {

            public string CustomerId() {
                return GetValue<string>("customer_id", true);
            }

            public string Email() {
                return GetValue<string>("email", false);
            }

            public bool HasBillingAddress() {
                return GetValue<bool>("has_billing_address", true);
            }

            public bool HasPaymentMethod() {
                return GetValue<bool>("has_payment_method", true);
            }

            public bool HasActiveSubscription() {
                return GetValue<bool>("has_active_subscription", true);
            }

        }

        #endregion
    }
}
