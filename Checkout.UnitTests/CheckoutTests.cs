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
        public void Checkout_WhenProductAIsScanned_TheTotalPriceIs40()
        {
            checkout.Scan("A");

            Assert.AreEqual(40, this.checkout.GetTotalPrice());
        }
    }
}
