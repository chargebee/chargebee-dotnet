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

    public class OfflineCheckout : Resource 
    {
    

        #region Methods
        public static EntityRequest Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("offline_checkouts", CheckNull(id));
            return new EntityRequest(url, HttpMethod.GET);
        }
        public static PreRegisterRequest PreRegister()
        {
            string url = ApiUtil.BuildUrl("offline_checkouts", "pre_register");
            return new PreRegisterRequest(url, HttpMethod.POST);
        }
        public static PostRegisterRequest PostRegister(string id)
        {
            string url = ApiUtil.BuildUrl("offline_checkouts", CheckNull(id), "post_register");
            return new PostRegisterRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public TypeEnum OfflineCheckoutType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public int Amount 
        {
            get { return GetValue<int>("amount", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public DateTime UpdatedAt 
        {
            get { return (DateTime)GetDateTime("updated_at", true); }
        }
        
        #endregion
        
        #region Requests
        public class PreRegisterRequest : EntityRequest 
        {
            public PreRegisterRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PreRegisterRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public PreRegisterRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public PreRegisterRequest CustomerEmail(string customerEmail) 
            {
                m_params.Add("customer[email]", customerEmail);
                return this;
            }
            public PreRegisterRequest CustomerFirstName(string customerFirstName) 
            {
                m_params.AddOpt("customer[first_name]", customerFirstName);
                return this;
            }
            public PreRegisterRequest CustomerLastName(string customerLastName) 
            {
                m_params.AddOpt("customer[last_name]", customerLastName);
                return this;
            }
            public PreRegisterRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public PreRegisterRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public PreRegisterRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public PreRegisterRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public PreRegisterRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        public class PostRegisterRequest : EntityRequest 
        {
            public PostRegisterRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public PostRegisterRequest Succeeded(bool succeeded) 
            {
                m_params.Add("succeeded", succeeded);
                return this;
            }
            public PostRegisterRequest ReferenceNumber(string referenceNumber) 
            {
                m_params.AddOpt("reference_number", referenceNumber);
                return this;
            }
            public PostRegisterRequest Description(string description) 
            {
                m_params.AddOpt("description", description);
                return this;
            }
            public PostRegisterRequest ErrorMessage(string errorMessage) 
            {
                m_params.AddOpt("error_message", errorMessage);
                return this;
            }
        }
        #endregion

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("checkout_new")]
            CheckoutNew,

        }
        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("created")]
            Created,
            [Description("completed")]
            Completed,

        }

        #region Subclasses

        #endregion
    }
}
