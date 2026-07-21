using System.ComponentModel;
using System.Runtime.Serialization;

namespace ChargeBee.Models.Enums
{
    public enum TaxOverrideReasonEnum
    {

        [EnumMember(Value = "Unknown Enum")]
        UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

        [EnumMember(Value = "zero_rated")]
         ZeroRated,

        [EnumMember(Value = "id_exempt")]
         IdExempt,

        [EnumMember(Value = "customer_exempt")]
         CustomerExempt,

        [EnumMember(Value = "region_non_taxable")]
         RegionNonTaxable,

        [EnumMember(Value = "product_exempt")]
         ProductExempt,

        [EnumMember(Value = "export")]
         Export,

        [EnumMember(Value = "high_value_physical_goods")]
         HighValuePhysicalGoods,

        [EnumMember(Value = "zero_value_item")]
         ZeroValueItem,

        [EnumMember(Value = "tax_not_configured_external_provider")]
         TaxNotConfiguredExternalProvider,

    }
}