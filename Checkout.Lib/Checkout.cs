namespace Checkout
{
    public class Checkout
    {
        private IProductRepository productRepository = null;
        private IBasket basket = null;

        public Checkout(IProductRepository productRepository, IBasket basket)
        {
            this.productRepository = productRepository;
            this.basket = basket;
        }

        public void Scan(char sku)
        {
            this.Scan(sku.ToString());
        }

        public void Scan(string sku)
        {
            this.basket.AddItem(sku);
        }

        public decimal GetTotalPrice()
        {
            decimal grandTotal = 0;

            foreach (var basketItem in this.basket.Items)
            {
                grandTotal += this.CalculateBasketItemPrice(basketItem);
            }

            return grandTotal;
        }

        private decimal CalculateBasketItemPrice(BasketItem basketItem)
        {
            decimal basketItemPrice = 0;

            var product = this.productRepository.GetProduct(basketItem.Sku);

            if (basketItem.Quantity >= product.BundleQuantity)
            {
                basketItemPrice = product.BundlePrice;

                int remainder = basketItem.Quantity - product.BundleQuantity;
                basketItemPrice += product.UnitPrice * remainder;
            }
            else
            {
                basketItemPrice = product.UnitPrice * basketItem.Quantity;
            }

            return basketItemPrice;
        }
    }
}
