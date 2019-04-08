using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.UnitTests
{
    [TestClass]
    public class CheckoutTests
    {
        private Checkout checkout = new Checkout();

        [TestMethod]
        public void Checkout_WhenNothingIsScanned_TheTotalPriceIsZero()
        {
            Assert.AreEqual(0, this.checkout.GetTotalPrice());
        }

        [TestMethod]
        [DataRow("A", 40)] // Calc: 1 x £40 = £40
        [DataRow("AA", 80)] // Calc: 2 x £40 = £80
        public void Checkout_WhenProductsAreScanned_TheTotalPriceIsCorrect(string skuList, int expectedGrandTotal)
        {
            foreach (char sku in skuList)
            {
                checkout.Scan(sku.ToString());
            }

            Assert.AreEqual(expectedGrandTotal, this.checkout.GetTotalPrice());
        }
    }
}
