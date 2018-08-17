using System.ComponentModel;

namespace ChargeBee.Models.Enums
{
    public enum TaxExemptReasonEnum
    {

        [Description("Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [Description("tax_not_configured")]
         TaxNotConfigured,

        [Description("region_non_taxable")]
         RegionNonTaxable,

        [Description("export")]
         Export,

        [Description("customer_exempt")]
         CustomerExempt,

        [Description("product_exempt")]
         ProductExempt,

        [Description("zero_rated")]
         ZeroRated,

        [Description("reverse_charge")]
         ReverseCharge,

        [Description("high_value_physical_goods")]
         HighValuePhysicalGoods,

    }
}