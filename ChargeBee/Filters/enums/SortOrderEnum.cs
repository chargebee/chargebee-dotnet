using System.ComponentModel;

namespace ChargeBee.Filters.Enums
{
	public enum SortOrderEnum
	{

		[Description("Unknown Enum")]
		UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */

		[Description("asc")]
		Asc,

		[Description("desc")]
		Desc,

	}
}