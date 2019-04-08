namespace Checkout
{
    public class Checkout
    {
        private IProductRepository productRepository = null;
        private decimal grandTotal = 0;

        public Checkout(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Scan(char sku)
        {
            this.Scan(sku.ToString());
        }

        public void Scan(string sku)
        {
            var product = this.productRepository.GetProduct(sku);

            this.grandTotal += product.UnitPrice;
        }

        public decimal GetTotalPrice()
        {
            return this.grandTotal;
        }
    }
}
