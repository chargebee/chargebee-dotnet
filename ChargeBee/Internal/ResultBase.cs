using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json.Linq;

using ChargeBee.Models;

namespace ChargeBee.Internal
{
    public class ResultBase : JSONSupport
    {
        public ResultBase () { }

        internal ResultBase(string json)
        {
            if (!String.IsNullOrEmpty(json))
                m_jobj = JToken.Parse(json);
        }

        internal ResultBase(JToken jobj)
        {
            m_jobj = jobj;
        }
        
        public Subscription Subscription
        {
            get {  return GetResource<Subscription>("subscription"); }
        }
        public Customer Customer
        {
            get {  return GetResource<Customer>("customer"); }
        }
        public Card Card
        {
            get {  return GetResource<Card>("card"); }
        }
        public Invoice Invoice
        {
            get {  return GetResource<Invoice>("invoice"); }
        }
        public Transaction Transaction
        {
            get {  return GetResource<Transaction>("transaction"); }
        }
        public HostedPage HostedPage
        {
            get {  return GetResource<HostedPage>("hosted_page"); }
        }
        public Estimate Estimate
        {
            get {  return GetResource<Estimate>("estimate"); }
        }
        public Plan Plan
        {
            get {  return GetResource<Plan>("plan"); }
        }
        public Addon Addon
        {
            get {  return GetResource<Addon>("addon"); }
        }
        public Coupon Coupon
        {
            get {  return GetResource<Coupon>("coupon"); }
        }
        public CouponCode CouponCode
        {
            get {  return GetResource<CouponCode>("coupon_code"); }
        }
        public Address Address
        {
            get {  return GetResource<Address>("address"); }
        }
        public Event Event
        {
            get {  return GetResource<Event>("event"); }
        }
        public Comment Comment
        {
            get {  return GetResource<Comment>("comment"); }
        }

        private T GetResource<T>(string property) where T : Resource, new()
        {
            if (m_jobj == null)
                return default(T);

            JToken jobj = m_jobj[property];
            if (jobj != null)
            {
                T t = new T();
                t.JObj = jobj;
                return t;
            }
            else
            {
                return default(T);
            }
        }
    }
}
