using System.Globalization;
using ChargeBee.Api;
using ChargeBee.Models;

namespace ChargeBee.Tests.Api
{
    public class ParamsTests
    {
        [Fact]
        public void AddOpt_Decimal_SerializesWithInvariantCulture()
        {
            var original = CultureInfo.CurrentCulture;
            try
            {
                // A comma decimal separator must not leak into the request.
                CultureInfo.CurrentCulture = new CultureInfo("de-DE");
                var parameters = new Params();

                parameters.AddOpt("credit_cost", 1.5m);

                Assert.Equal("credit_cost=1.5", parameters.GetQuery(false));
            }
            finally
            {
                CultureInfo.CurrentCulture = original;
            }
        }

        [Fact]
        public void AddOpt_DecimalList_SerializesEachItem()
        {
            var parameters = new Params();

            parameters.AddOpt("price_allocation", new List<decimal> { 12.5m, 87.5m });

            Assert.Equal("price_allocation[0]=12.5&price_allocation[1]=87.5", parameters.GetQuery(false));
        }

        [Fact]
        public void GeneratedDecimalSetter_DoesNotThrow()
        {
            // Generated request builders type format: decimal params as decimal and pass them
            // straight to Params, which used to throw "Type [System.Decimal] not handled".
            var request = Item.Create().BundleItemsToAddPriceAllocation(0, 25.5m);

            Assert.NotNull(request);
        }
    }
}
