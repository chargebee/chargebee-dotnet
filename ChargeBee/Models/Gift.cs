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

    public class Gift : Resource 
    {
    
        public Gift() { }

        public Gift(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public Gift(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public Gift(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
        public static CreateRequest Create()
        {
            string url = ApiUtil.BuildUrl("gifts");
            return new CreateRequest(url, HttpMethod.POST);
        }
        public static CreateForItemsRequest CreateForItems()
        {
            string url = ApiUtil.BuildUrl("gifts", "create_for_items");
            return new CreateForItemsRequest(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Retrieve(string id)
        {
            string url = ApiUtil.BuildUrl("gifts", CheckNull(id));
            return new EntityRequest<Type>(url, HttpMethod.GET);
        }
        public static GiftListRequest List()
        {
            string url = ApiUtil.BuildUrl("gifts");
            return new GiftListRequest(url);
        }
        public static EntityRequest<Type> Claim(string id)
        {
            string url = ApiUtil.BuildUrl("gifts", CheckNull(id), "claim");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static EntityRequest<Type> Cancel(string id)
        {
            string url = ApiUtil.BuildUrl("gifts", CheckNull(id), "cancel");
            return new EntityRequest<Type>(url, HttpMethod.POST);
        }
        public static UpdateGiftRequest UpdateGift(string id)
        {
            string url = ApiUtil.BuildUrl("gifts", CheckNull(id), "update_gift");
            return new UpdateGiftRequest(url, HttpMethod.POST);
        }
        #endregion
        
        #region Properties
        public string Id 
        {
            get { return GetValue<string>("id", true); }
        }
        public StatusEnum Status 
        {
            get { return GetEnum<StatusEnum>("status", true); }
        }
        public DateTime? ScheduledAt 
        {
            get { return GetDateTime("scheduled_at", false); }
        }
        public bool AutoClaim 
        {
            get { return GetValue<bool>("auto_claim", true); }
        }
        public bool NoExpiry 
        {
            get { return GetValue<bool>("no_expiry", true); }
        }
        public DateTime? ClaimExpiryDate 
        {
            get { return GetDateTime("claim_expiry_date", false); }
        }
        public long? ResourceVersion 
        {
            get { return GetValue<long?>("resource_version", false); }
        }
        public DateTime? UpdatedAt 
        {
            get { return GetDateTime("updated_at", false); }
        }
        public GiftGifter Gifter 
        {
            get { return GetSubResource<GiftGifter>("gifter"); }
        }
        public GiftGiftReceiver GiftReceiver 
        {
            get { return GetSubResource<GiftGiftReceiver>("gift_receiver"); }
        }
        public List<GiftGiftTimeline> GiftTimelines 
        {
            get { return GetResourceList<GiftGiftTimeline>("gift_timelines"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateRequest : EntityRequest<CreateRequest> 
        {
            public CreateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateRequest ScheduledAt(long scheduledAt) 
            {
                m_params.AddOpt("scheduled_at", scheduledAt);
                return this;
            }
            public CreateRequest AutoClaim(bool autoClaim) 
            {
                m_params.AddOpt("auto_claim", autoClaim);
                return this;
            }
            public CreateRequest NoExpiry(bool noExpiry) 
            {
                m_params.AddOpt("no_expiry", noExpiry);
                return this;
            }
            public CreateRequest ClaimExpiryDate(long claimExpiryDate) 
            {
                m_params.AddOpt("claim_expiry_date", claimExpiryDate);
                return this;
            }
            public CreateRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateRequest GifterCustomerId(string gifterCustomerId) 
            {
                m_params.Add("gifter[customer_id]", gifterCustomerId);
                return this;
            }
            public CreateRequest GifterSignature(string gifterSignature) 
            {
                m_params.Add("gifter[signature]", gifterSignature);
                return this;
            }
            public CreateRequest GifterNote(string gifterNote) 
            {
                m_params.AddOpt("gifter[note]", gifterNote);
                return this;
            }
            public CreateRequest GifterPaymentSrcId(string gifterPaymentSrcId) 
            {
                m_params.AddOpt("gifter[payment_src_id]", gifterPaymentSrcId);
                return this;
            }
            public CreateRequest GiftReceiverCustomerId(string giftReceiverCustomerId) 
            {
                m_params.Add("gift_receiver[customer_id]", giftReceiverCustomerId);
                return this;
            }
            public CreateRequest GiftReceiverFirstName(string giftReceiverFirstName) 
            {
                m_params.Add("gift_receiver[first_name]", giftReceiverFirstName);
                return this;
            }
            public CreateRequest GiftReceiverLastName(string giftReceiverLastName) 
            {
                m_params.Add("gift_receiver[last_name]", giftReceiverLastName);
                return this;
            }
            public CreateRequest GiftReceiverEmail(string giftReceiverEmail) 
            {
                m_params.Add("gift_receiver[email]", giftReceiverEmail);
                return this;
            }
            public CreateRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public CreateRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CreateRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public CreateRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateRequest SubscriptionPlanQuantityInDecimal(string subscriptionPlanQuantityInDecimal) 
            {
                m_params.AddOpt("subscription[plan_quantity_in_decimal]", subscriptionPlanQuantityInDecimal);
                return this;
            }
            public CreateRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
            public CreateRequest AddonQuantityInDecimal(int index, string addonQuantityInDecimal) 
            {
                m_params.AddOpt("addons[quantity_in_decimal][" + index + "]", addonQuantityInDecimal);
                return this;
            }
        }
        public class CreateForItemsRequest : EntityRequest<CreateForItemsRequest> 
        {
            public CreateForItemsRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateForItemsRequest ScheduledAt(long scheduledAt) 
            {
                m_params.AddOpt("scheduled_at", scheduledAt);
                return this;
            }
            public CreateForItemsRequest AutoClaim(bool autoClaim) 
            {
                m_params.AddOpt("auto_claim", autoClaim);
                return this;
            }
            public CreateForItemsRequest NoExpiry(bool noExpiry) 
            {
                m_params.AddOpt("no_expiry", noExpiry);
                return this;
            }
            public CreateForItemsRequest ClaimExpiryDate(long claimExpiryDate) 
            {
                m_params.AddOpt("claim_expiry_date", claimExpiryDate);
                return this;
            }
            public CreateForItemsRequest CouponIds(List<string> couponIds) 
            {
                m_params.AddOpt("coupon_ids", couponIds);
                return this;
            }
            public CreateForItemsRequest GifterCustomerId(string gifterCustomerId) 
            {
                m_params.Add("gifter[customer_id]", gifterCustomerId);
                return this;
            }
            public CreateForItemsRequest GifterSignature(string gifterSignature) 
            {
                m_params.Add("gifter[signature]", gifterSignature);
                return this;
            }
            public CreateForItemsRequest GifterNote(string gifterNote) 
            {
                m_params.AddOpt("gifter[note]", gifterNote);
                return this;
            }
            public CreateForItemsRequest GifterPaymentSrcId(string gifterPaymentSrcId) 
            {
                m_params.AddOpt("gifter[payment_src_id]", gifterPaymentSrcId);
                return this;
            }
            public CreateForItemsRequest GiftReceiverCustomerId(string giftReceiverCustomerId) 
            {
                m_params.Add("gift_receiver[customer_id]", giftReceiverCustomerId);
                return this;
            }
            public CreateForItemsRequest GiftReceiverFirstName(string giftReceiverFirstName) 
            {
                m_params.Add("gift_receiver[first_name]", giftReceiverFirstName);
                return this;
            }
            public CreateForItemsRequest GiftReceiverLastName(string giftReceiverLastName) 
            {
                m_params.Add("gift_receiver[last_name]", giftReceiverLastName);
                return this;
            }
            public CreateForItemsRequest GiftReceiverEmail(string giftReceiverEmail) 
            {
                m_params.Add("gift_receiver[email]", giftReceiverEmail);
                return this;
            }
            public CreateForItemsRequest PaymentIntentId(string paymentIntentId) 
            {
                m_params.AddOpt("payment_intent[id]", paymentIntentId);
                return this;
            }
            public CreateForItemsRequest PaymentIntentGatewayAccountId(string paymentIntentGatewayAccountId) 
            {
                m_params.AddOpt("payment_intent[gateway_account_id]", paymentIntentGatewayAccountId);
                return this;
            }
            public CreateForItemsRequest PaymentIntentGwToken(string paymentIntentGwToken) 
            {
                m_params.AddOpt("payment_intent[gw_token]", paymentIntentGwToken);
                return this;
            }
            public CreateForItemsRequest PaymentIntentReferenceId(string paymentIntentReferenceId) 
            {
                m_params.AddOpt("payment_intent[reference_id]", paymentIntentReferenceId);
                return this;
            }
            [Obsolete]
            public CreateForItemsRequest PaymentIntentGwPaymentMethodId(string paymentIntentGwPaymentMethodId) 
            {
                m_params.AddOpt("payment_intent[gw_payment_method_id]", paymentIntentGwPaymentMethodId);
                return this;
            }
            public CreateForItemsRequest PaymentIntentAdditionalInformation(JToken paymentIntentAdditionalInformation) 
            {
                m_params.AddOpt("payment_intent[additional_information]", paymentIntentAdditionalInformation);
                return this;
            }
            public CreateForItemsRequest ShippingAddressFirstName(string shippingAddressFirstName) 
            {
                m_params.AddOpt("shipping_address[first_name]", shippingAddressFirstName);
                return this;
            }
            public CreateForItemsRequest ShippingAddressLastName(string shippingAddressLastName) 
            {
                m_params.AddOpt("shipping_address[last_name]", shippingAddressLastName);
                return this;
            }
            public CreateForItemsRequest ShippingAddressEmail(string shippingAddressEmail) 
            {
                m_params.AddOpt("shipping_address[email]", shippingAddressEmail);
                return this;
            }
            public CreateForItemsRequest ShippingAddressCompany(string shippingAddressCompany) 
            {
                m_params.AddOpt("shipping_address[company]", shippingAddressCompany);
                return this;
            }
            public CreateForItemsRequest ShippingAddressPhone(string shippingAddressPhone) 
            {
                m_params.AddOpt("shipping_address[phone]", shippingAddressPhone);
                return this;
            }
            public CreateForItemsRequest ShippingAddressLine1(string shippingAddressLine1) 
            {
                m_params.AddOpt("shipping_address[line1]", shippingAddressLine1);
                return this;
            }
            public CreateForItemsRequest ShippingAddressLine2(string shippingAddressLine2) 
            {
                m_params.AddOpt("shipping_address[line2]", shippingAddressLine2);
                return this;
            }
            public CreateForItemsRequest ShippingAddressLine3(string shippingAddressLine3) 
            {
                m_params.AddOpt("shipping_address[line3]", shippingAddressLine3);
                return this;
            }
            public CreateForItemsRequest ShippingAddressCity(string shippingAddressCity) 
            {
                m_params.AddOpt("shipping_address[city]", shippingAddressCity);
                return this;
            }
            public CreateForItemsRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateForItemsRequest ShippingAddressState(string shippingAddressState) 
            {
                m_params.AddOpt("shipping_address[state]", shippingAddressState);
                return this;
            }
            public CreateForItemsRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateForItemsRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateForItemsRequest ShippingAddressValidationStatus(ChargeBee.Models.Enums.ValidationStatusEnum shippingAddressValidationStatus) 
            {
                m_params.AddOpt("shipping_address[validation_status]", shippingAddressValidationStatus);
                return this;
            }
            public CreateForItemsRequest SubscriptionItemItemPriceId(int index, string subscriptionItemItemPriceId) 
            {
                m_params.AddOpt("subscription_items[item_price_id][" + index + "]", subscriptionItemItemPriceId);
                return this;
            }
            public CreateForItemsRequest SubscriptionItemQuantity(int index, int subscriptionItemQuantity) 
            {
                m_params.AddOpt("subscription_items[quantity][" + index + "]", subscriptionItemQuantity);
                return this;
            }
            public CreateForItemsRequest SubscriptionItemQuantityInDecimal(int index, string subscriptionItemQuantityInDecimal) 
            {
                m_params.AddOpt("subscription_items[quantity_in_decimal][" + index + "]", subscriptionItemQuantityInDecimal);
                return this;
            }
        }
        public class GiftListRequest : ListRequestBase<GiftListRequest> 
        {
            public GiftListRequest(string url) 
                    : base(url)
            {
            }

            public EnumFilter<Gift.StatusEnum, GiftListRequest> Status() 
            {
                return new EnumFilter<Gift.StatusEnum, GiftListRequest>("status", this);        
            }
            public StringFilter<GiftListRequest> GiftReceiverEmail() 
            {
                return new StringFilter<GiftListRequest>("gift_receiver[email]", this);        
            }

            public StringFilter<GiftListRequest> GifterCustomerId() 
            {
                return new StringFilter<GiftListRequest>("gifter[customer_id]", this);        
            }

            public StringFilter<GiftListRequest> GiftReceiverCustomerId() 
            {
                return new StringFilter<GiftListRequest>("gift_receiver[customer_id]", this);        
            }

        }
        public class UpdateGiftRequest : EntityRequest<UpdateGiftRequest> 
        {
            public UpdateGiftRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateGiftRequest ScheduledAt(long scheduledAt) 
            {
                m_params.Add("scheduled_at", scheduledAt);
                return this;
            }
            public UpdateGiftRequest Comment(string comment) 
            {
                m_params.AddOpt("comment", comment);
                return this;
            }
        }
        #endregion

        public enum StatusEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "scheduled")]
            Scheduled,
            [EnumMember(Value = "unclaimed")]
            Unclaimed,
            [EnumMember(Value = "claimed")]
            Claimed,
            [EnumMember(Value = "cancelled")]
            Cancelled,
            [EnumMember(Value = "expired")]
            Expired,

        }

        #region Subclasses
        public class GiftGifter : Resource
        {

            public string CustomerId() {
                return GetValue<string>("customer_id", true);
            }

            public string InvoiceId() {
                return GetValue<string>("invoice_id", false);
            }

            public string Signature() {
                return GetValue<string>("signature", false);
            }

            public string Note() {
                return GetValue<string>("note", false);
            }

        }
        public class GiftGiftReceiver : Resource
        {

            public string CustomerId() {
                return GetValue<string>("customer_id", true);
            }

            public string SubscriptionId() {
                return GetValue<string>("subscription_id", true);
            }

            public string FirstName() {
                return GetValue<string>("first_name", false);
            }

            public string LastName() {
                return GetValue<string>("last_name", false);
            }

            public string Email() {
                return GetValue<string>("email", false);
            }

        }
        public class GiftGiftTimeline : Resource
        {

            public StatusEnum Status() {
                return GetEnum<StatusEnum>("status", true);
            }

            public DateTime? OccurredAt() {
                return GetDateTime("occurred_at", false);
            }

        }

        #endregion
    }
}
