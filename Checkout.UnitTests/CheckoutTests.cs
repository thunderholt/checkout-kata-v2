using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.UnitTests
{
    [TestClass]
    public class CheckoutTests
    {
        private IProductRepository productRepository = new ProductRepository();
        private IBasket basket = new Basket();
        private IProductPriceCalculator productPriceCalculator = new ProductPriceCalculator();
        private Checkout checkout = null;

        [TestInitialize]
        public void Init()
        {
            this.productRepository.AddProduct(new Product
            {
                Sku = "A",
                UnitPrice = 40,
                BundleQuantity = 3,
                BundlePrice = 110
            });

            this.productRepository.AddProduct(new Product
            {
                Sku = "B",
                UnitPrice = 50
            });

            this.checkout = new Checkout(this.productRepository, this.basket, this.productPriceCalculator);
        }

        [TestMethod]
        public void Checkout_WhenNothingIsScanned_TheTotalPriceIsZero()
        {
            Assert.AreEqual(0, this.checkout.GetTotalPrice());
        }

        [TestMethod]
        [DataRow("A", 40)] // Calc: 1 x £40 = £40
        [DataRow("AA", 80)] // Calc: 2 x £40 = £80
        [DataRow("B", 50)] // Calc: 1 x £50 = £50
        [DataRow("AAA", 110)] // Calc: 1 x £110 (bundle price) = £110
        [DataRow("AAAA", 150)] // Calc: 1 x £110 (bundle price) + 1 x £40 = £150
        [DataRow("AAAAAAA", 260)] // Calc: 2 x £110 (bundle price) + 1 x £40 = £260
        public void Checkout_WhenProductsAreScanned_TheTotalPriceIsCorrect(string skuList, int expectedGrandTotal)
        {
            foreach (char sku in skuList)
            {
                this.checkout.Scan(sku);
            }

            Assert.AreEqual(expectedGrandTotal, this.checkout.GetTotalPrice());
        }

        [TestMethod]
        [ExpectedException(typeof(ProductNotFoundException))]
        public void Checkout_WhenAnUnrecognisedSkuIsScanned_AProductNotFoundExceptionIsThrown()
        {
            this.checkout.Scan("F");
        }
    }
}
