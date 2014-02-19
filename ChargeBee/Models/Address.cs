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

    public class Address : Resource 
    {
    

        #region Methods
        public static RetrieveRequest Retrieve()
        {
            string url = ApiUtil.BuildUrl("addresses");
            return new RetrieveRequest(url, HttpMethod.GET);
        }
        public static UpdateRequest Update()
        {
            string url = ApiUtil.BuildUrl("addresses");
            return new UpdateRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Label 
        {
            get { return GetValue<string>("label", true); }
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
            get { return GetValue<string>("email", false); }
        }
        public string Company 
        {
            get { return GetValue<string>("company", false); }
        }
        public string Phone 
        {
            get { return GetValue<string>("phone", false); }
        }
        public string Addr 
        {
            get { return GetValue<string>("addr", false); }
        }
        public string ExtendedAddr 
        {
            get { return GetValue<string>("extended_addr", false); }
        }
        public string ExtendedAddr2 
        {
            get { return GetValue<string>("extended_addr2", false); }
        }
        public string City 
        {
            get { return GetValue<string>("city", false); }
        }
        public string State 
        {
            get { return GetValue<string>("state", false); }
        }
        public string Country 
        {
            get { return GetValue<string>("country", false); }
        }
        public string Zip 
        {
            get { return GetValue<string>("zip", false); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }
        
        #endregion
        
        #region Requests
        public class RetrieveRequest : EntityRequest 
        {
            public RetrieveRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RetrieveRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public RetrieveRequest Label(string label) 
            {
                m_params.Add("label", label);
                return this;
            }
        }
        public class UpdateRequest : EntityRequest 
        {
            public UpdateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription_id", subscriptionId);
                return this;
            }
            public UpdateRequest Label(string label) 
            {
                m_params.Add("label", label);
                return this;
            }
            public UpdateRequest FirstName(string firstName) 
            {
                m_params.AddOpt("first_name", firstName);
                return this;
            }
            public UpdateRequest LastName(string lastName) 
            {
                m_params.AddOpt("last_name", lastName);
                return this;
            }
            public UpdateRequest Company(string company) 
            {
                m_params.AddOpt("company", company);
                return this;
            }
            public UpdateRequest Addr(string addr) 
            {
                m_params.AddOpt("addr", addr);
                return this;
            }
            public UpdateRequest ExtendedAddr(string extendedAddr) 
            {
                m_params.AddOpt("extended_addr", extendedAddr);
                return this;
            }
            public UpdateRequest ExtendedAddr2(string extendedAddr2) 
            {
                m_params.AddOpt("extended_addr2", extendedAddr2);
                return this;
            }
            public UpdateRequest City(string city) 
            {
                m_params.AddOpt("city", city);
                return this;
            }
            public UpdateRequest State(string state) 
            {
                m_params.AddOpt("state", state);
                return this;
            }
            public UpdateRequest Zip(string zip) 
            {
                m_params.AddOpt("zip", zip);
                return this;
            }
            public UpdateRequest Country(string country) 
            {
                m_params.AddOpt("country", country);
                return this;
            }
        }
        #endregion


        #region Subclasses

        #endregion
    }
}
