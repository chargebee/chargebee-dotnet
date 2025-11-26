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
                    throw new Exception("Not in JSON format. Probably not a ChargeBee response. \n " + json, e);
                }
            }
        }

        internal ResultBase(JToken jobj)
        {
            m_jobj = jobj;
        }
        public string ToJson()
        {

            return m_jobj.ToString(Formatting.None) ;
        }


        public Subscription Subscription
        {
            get {  return GetResource<Subscription>("subscription"); }
        }
        public ContractTerm ContractTerm
        {
            get {  return GetResource<ContractTerm>("contract_term"); }
        }
        public Discount Discount
        {
            get {  return GetResource<Discount>("discount"); }
        }
        public AdvanceInvoiceSchedule AdvanceInvoiceSchedule
        {
            get {  return GetResource<AdvanceInvoiceSchedule>("advance_invoice_schedule"); }
        }
        public Customer Customer
        {
            get {  return GetResource<Customer>("customer"); }
        }
        public Hierarchy Hierarchy
        {
            get {  return GetResource<Hierarchy>("hierarchy"); }
        }
        public Contact Contact
        {
            get {  return GetResource<Contact>("contact"); }
        }
        public BusinessEntityTransfer BusinessEntityTransfer
        {
            get {  return GetResource<BusinessEntityTransfer>("business_entity_transfer"); }
        }
        public Token Token
        {
            get {  return GetResource<Token>("token"); }
        }
        public PaymentSource PaymentSource
        {
            get {  return GetResource<PaymentSource>("payment_source"); }
        }
        public ThirdPartyPaymentMethod ThirdPartyPaymentMethod
        {
            get {  return GetResource<ThirdPartyPaymentMethod>("third_party_payment_method"); }
        }
        public VirtualBankAccount VirtualBankAccount
        {
            get {  return GetResource<VirtualBankAccount>("virtual_bank_account"); }
        }
        public Card Card
        {
            get {  return GetResource<Card>("card"); }
        }
        public PromotionalCredit PromotionalCredit
        {
            get {  return GetResource<PromotionalCredit>("promotional_credit"); }
        }
        public Invoice Invoice
        {
            get {  return GetResource<Invoice>("invoice"); }
        }
        public PaymentReferenceNumber PaymentReferenceNumber
        {
            get {  return GetResource<PaymentReferenceNumber>("payment_reference_number"); }
        }
        public PaymentSchedule PaymentSchedule
        {
            get {  return GetResource<PaymentSchedule>("payment_schedule"); }
        }
        public Einvoice Einvoice
        {
            get {  return GetResource<Einvoice>("einvoice"); }
        }
        public TaxWithheld TaxWithheld
        {
            get {  return GetResource<TaxWithheld>("tax_withheld"); }
        }
        public CreditNote CreditNote
        {
            get {  return GetResource<CreditNote>("credit_note"); }
        }
        public UnbilledCharge UnbilledCharge
        {
            get {  return GetResource<UnbilledCharge>("unbilled_charge"); }
        }
        public Order Order
        {
            get {  return GetResource<Order>("order"); }
        }
        public Gift Gift
        {
            get {  return GetResource<Gift>("gift"); }
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
        public Quote Quote
        {
            get {  return GetResource<Quote>("quote"); }
        }
        public QuotedSubscription QuotedSubscription
        {
            get {  return GetResource<QuotedSubscription>("quoted_subscription"); }
        }
        public QuotedCharge QuotedCharge
        {
            get {  return GetResource<QuotedCharge>("quoted_charge"); }
        }
        public QuotedRamp QuotedRamp
        {
            get {  return GetResource<QuotedRamp>("quoted_ramp"); }
        }
        public QuotedDeltaRamp QuotedDeltaRamp
        {
            get {  return GetResource<QuotedDeltaRamp>("quoted_delta_ramp"); }
        }
        public BillingConfiguration BillingConfiguration
        {
            get {  return GetResource<BillingConfiguration>("billing_configuration"); }
        }
        public QuoteLineGroup QuoteLineGroup
        {
            get {  return GetResource<QuoteLineGroup>("quote_line_group"); }
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
        public CouponSet CouponSet
        {
            get {  return GetResource<CouponSet>("coupon_set"); }
        }
        public CouponCode CouponCode
        {
            get {  return GetResource<CouponCode>("coupon_code"); }
        }
        public Address Address
        {
            get {  return GetResource<Address>("address"); }
        }
        public Usage Usage
        {
            get {  return GetResource<Usage>("usage"); }
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
        public SiteMigrationDetail SiteMigrationDetail
        {
            get {  return GetResource<SiteMigrationDetail>("site_migration_detail"); }
        }
        public ResourceMigration ResourceMigration
        {
            get {  return GetResource<ResourceMigration>("resource_migration"); }
        }
        public TimeMachine TimeMachine
        {
            get {  return GetResource<TimeMachine>("time_machine"); }
        }
        public Export Export
        {
            get {  return GetResource<Export>("export"); }
        }
        public PaymentIntent PaymentIntent
        {
            get {  return GetResource<PaymentIntent>("payment_intent"); }
        }
        public GatewayErrorDetail GatewayErrorDetail
        {
            get {  return GetResource<GatewayErrorDetail>("gateway_error_detail"); }
        }
        public ItemFamily ItemFamily
        {
            get {  return GetResource<ItemFamily>("item_family"); }
        }
        public Item Item
        {
            get {  return GetResource<Item>("item"); }
        }
        public PriceVariant PriceVariant
        {
            get {  return GetResource<PriceVariant>("price_variant"); }
        }
        public ChargeBee.Models.Attribute Attribute
        {
            get {  return GetResource<ChargeBee.Models.Attribute>("attribute"); }
        }
        public ItemPrice ItemPrice
        {
            get {  return GetResource<ItemPrice>("item_price"); }
        }
        public AttachedItem AttachedItem
        {
            get {  return GetResource<AttachedItem>("attached_item"); }
        }
        public DifferentialPrice DifferentialPrice
        {
            get {  return GetResource<DifferentialPrice>("differential_price"); }
        }
        public Configuration Configuration
        {
            get {  return GetResource<Configuration>("configuration"); }
        }
        public Feature Feature
        {
            get {  return GetResource<Feature>("feature"); }
        }
        public ImpactedSubscription ImpactedSubscription
        {
            get {  return GetResource<ImpactedSubscription>("impacted_subscription"); }
        }
        public ImpactedItem ImpactedItem
        {
            get {  return GetResource<ImpactedItem>("impacted_item"); }
        }
        public ImpactedItemPrice ImpactedItemPrice
        {
            get {  return GetResource<ImpactedItemPrice>("impacted_item_price"); }
        }
        public Metadata Metadata
        {
            get {  return GetResource<Metadata>("metadata"); }
        }
        public SubscriptionEntitlement SubscriptionEntitlement
        {
            get {  return GetResource<SubscriptionEntitlement>("subscription_entitlement"); }
        }
        public CustomerEntitlement CustomerEntitlement
        {
            get {  return GetResource<CustomerEntitlement>("customer_entitlement"); }
        }
        public ItemEntitlement ItemEntitlement
        {
            get {  return GetResource<ItemEntitlement>("item_entitlement"); }
        }
        public Entitlement Entitlement
        {
            get {  return GetResource<Entitlement>("entitlement"); }
        }
        public InAppSubscription InAppSubscription
        {
            get {  return GetResource<InAppSubscription>("in_app_subscription"); }
        }
        public EntitlementOverride EntitlementOverride
        {
            get {  return GetResource<EntitlementOverride>("entitlement_override"); }
        }
        public BusinessEntity BusinessEntity
        {
            get {  return GetResource<BusinessEntity>("business_entity"); }
        }
        public Purchase Purchase
        {
            get {  return GetResource<Purchase>("purchase"); }
        }
        public PaymentVoucher PaymentVoucher
        {
            get {  return GetResource<PaymentVoucher>("payment_voucher"); }
        }
        public Currency Currency
        {
            get {  return GetResource<Currency>("currency"); }
        }
        public Ramp Ramp
        {
            get {  return GetResource<Ramp>("ramp"); }
        }
        public PaymentScheduleScheme PaymentScheduleScheme
        {
            get {  return GetResource<PaymentScheduleScheme>("payment_schedule_scheme"); }
        }
        public PricingPageSession PricingPageSession
        {
            get {  return GetResource<PricingPageSession>("pricing_page_session"); }
        }
        public OmnichannelSubscription OmnichannelSubscription
        {
            get {  return GetResource<OmnichannelSubscription>("omnichannel_subscription"); }
        }
        public OmnichannelTransaction OmnichannelTransaction
        {
            get {  return GetResource<OmnichannelTransaction>("omnichannel_transaction"); }
        }
        public OmnichannelSubscriptionItem OmnichannelSubscriptionItem
        {
            get {  return GetResource<OmnichannelSubscriptionItem>("omnichannel_subscription_item"); }
        }
        public RecordedPurchase RecordedPurchase
        {
            get {  return GetResource<RecordedPurchase>("recorded_purchase"); }
        }
        public OmnichannelOneTimeOrder OmnichannelOneTimeOrder
        {
            get {  return GetResource<OmnichannelOneTimeOrder>("omnichannel_one_time_order"); }
        }
        public OmnichannelOneTimeOrderItem OmnichannelOneTimeOrderItem
        {
            get {  return GetResource<OmnichannelOneTimeOrderItem>("omnichannel_one_time_order_item"); }
        }
        public Rule Rule
        {
            get {  return GetResource<Rule>("rule"); }
        }
        public UsageEvent UsageEvent
        {
            get {  return GetResource<UsageEvent>("usage_event"); }
        }
        public OmnichannelSubscriptionItemScheduledChange OmnichannelSubscriptionItemScheduledChange
        {
            get {  return GetResource<OmnichannelSubscriptionItemScheduledChange>("omnichannel_subscription_item_scheduled_change"); }
        }
        public UsageFile UsageFile
        {
            get {  return GetResource<UsageFile>("usage_file"); }
        }
        public PersonalizedOffer PersonalizedOffer
        {
            get {  return GetResource<PersonalizedOffer>("personalized_offer"); }
        }
        public Brand Brand
        {
            get {  return GetResource<Brand>("brand"); }
        }
        public OfferFulfillment OfferFulfillment
        {
            get {  return GetResource<OfferFulfillment>("offer_fulfillment"); }
        }
        public OfferEvent OfferEvent
        {
            get {  return GetResource<OfferEvent>("offer_event"); }
        }
        public WebhookEndpoint WebhookEndpoint
        {
            get {  return GetResource<WebhookEndpoint>("webhook_endpoint"); }
        }
        public ImpactedCustomer ImpactedCustomer
        {
            get {  return GetResource<ImpactedCustomer>("impacted_customer"); }
        }
        public SubscriptionEntitlementsUpdatedDetail SubscriptionEntitlementsUpdatedDetail
        {
            get {  return GetResource<SubscriptionEntitlementsUpdatedDetail>("subscription_entitlements_updated_detail"); }
        }
        public SubscriptionEntitlementsCreatedDetail SubscriptionEntitlementsCreatedDetail
        {
            get {  return GetResource<SubscriptionEntitlementsCreatedDetail>("subscription_entitlements_created_detail"); }
        }

        public List<AdvanceInvoiceSchedule> AdvanceInvoiceSchedules
        {
            get {  return (List<AdvanceInvoiceSchedule>)GetResourceList<AdvanceInvoiceSchedule>("advance_invoice_schedules", "advance_invoice_schedule"); }
        }

        public List<Hierarchy> Hierarchies
        {
            get {  return (List<Hierarchy>)GetResourceList<Hierarchy>("hierarchies", "hierarchy"); }
        }

        public List<Invoice> Invoices
        {
            get {  return (List<Invoice>)GetResourceList<Invoice>("invoices", "invoice"); }
        }

        public List<PaymentSchedule> PaymentSchedules
        {
            get {  return (List<PaymentSchedule>)GetResourceList<PaymentSchedule>("payment_schedules", "payment_schedule"); }
        }

        public List<CreditNote> CreditNotes
        {
            get {  return (List<CreditNote>)GetResourceList<CreditNote>("credit_notes", "credit_note"); }
        }

        public List<UnbilledCharge> UnbilledCharges
        {
            get {  return (List<UnbilledCharge>)GetResourceList<UnbilledCharge>("unbilled_charges", "unbilled_charge"); }
        }

        public List<Download> Downloads
        {
            get {  return (List<Download>)GetResourceList<Download>("downloads", "download"); }
        }

        public List<Configuration> Configurations
        {
            get {  return (List<Configuration>)GetResourceList<Configuration>("configurations", "configuration"); }
        }

        public List<InAppSubscription> InAppSubscriptions
        {
            get {  return (List<InAppSubscription>)GetResourceList<InAppSubscription>("in_app_subscriptions", "in_app_subscription"); }
        }

        public List<PersonalizedOffer> PersonalizedOffers
        {
            get {  return (List<PersonalizedOffer>)GetResourceList<PersonalizedOffer>("personalized_offers", "personalized_offer"); }
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
