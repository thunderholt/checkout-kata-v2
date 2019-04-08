namespace Checkout
{
    public class Checkout
    {
        private IProductRepository productRepository = null;
        private IBasket basket = null;
        private IProductPriceCalculator productPriceCalculator = null;

        public Checkout(IProductRepository productRepository, IBasket basket, IProductPriceCalculator productPriceCalculator)
        {
            this.productRepository = productRepository;
            this.basket = basket;
            this.productPriceCalculator = productPriceCalculator;
        }

        public void Scan(char sku)
        {
            this.Scan(sku.ToString());
        }

        public void Scan(string sku)
        {
            var product = this.productRepository.GetProduct(sku);
            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            this.basket.AddItem(sku);
        }

        public decimal GetTotalPrice()
        {
            decimal grandTotal = 0;

            foreach (var basketItem in this.basket.Items)
            {
                var product = this.productRepository.GetProduct(basketItem.Sku);
                grandTotal += this.productPriceCalculator.CalculateProductPrice(product, basketItem.Quantity);
            }

            return grandTotal;
        }
    }
}
