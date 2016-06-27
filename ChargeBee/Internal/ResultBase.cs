using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json;
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
            {
                try
                {
                    m_jobj = JToken.Parse(json);
                }
                catch(JsonException e)
                {
                    throw new SystemException("Not in JSON format. Probably not a ChargeBee response. \n " + json, e);
                }
            }
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
        public ThirdPartyPaymentMethod ThirdPartyPaymentMethod
        {
            get {  return GetResource<ThirdPartyPaymentMethod>("third_party_payment_method"); }
        }
        public Invoice Invoice
        {
            get {  return GetResource<Invoice>("invoice"); }
        }
        public CreditNote CreditNote
        {
            get {  return GetResource<CreditNote>("credit_note"); }
        }
        public Order Order
        {
            get {  return GetResource<Order>("order"); }
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
        public Download Download
        {
            get {  return GetResource<Download>("download"); }
        }
        public PortalSession PortalSession
        {
            get {  return GetResource<PortalSession>("portal_session"); }
        }

        public List<CreditNote> CreditNotes
        {
            get {  return (List<CreditNote>)GetResourceList<CreditNote>("credit_notes", "credit_note"); }
        }


        private List<T> GetResourceList<T>(string property, string propertySingularName) where T : Resource, new() 
        {
            List<T> list = new List<T> ();
            JArray jArr = (JArray)m_jobj.SelectToken (property);
			if (jArr != null) {
				foreach (JToken jObj in jArr.Children()) {
					T t = new T();
					t.JObj = jObj;
					list.Add(t);
				}				
			}
			return list;
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
