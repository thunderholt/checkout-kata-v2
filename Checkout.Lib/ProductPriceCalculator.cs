namespace Checkout
{
    public class ProductPriceCalculator : IProductPriceCalculator
    {
        public decimal CalculateProductPrice(Product product, int quantity)
        {
            decimal productPrice = 0;

            if (quantity >= product.BundleQuantity)
            {
                productPrice = product.BundlePrice;

                int remainder = quantity - product.BundleQuantity;
                productPrice += product.UnitPrice * remainder;
            }
            else
            {
                productPrice = product.UnitPrice * quantity;
            }

            return productPrice;
        }
    }
}
