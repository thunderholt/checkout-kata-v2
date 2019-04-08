using System;

namespace Checkout
{
    public class ProductPriceCalculator : IProductPriceCalculator
    {
        public decimal CalculateProductPrice(Product product, int quantity)
        {
            decimal productPrice = 0;

            int bundleCount = 0;
            int remainder = quantity;

            if (product.BundleQuantity > 0)
            {
                bundleCount = (int)Math.Floor(quantity / (float)product.BundleQuantity);
                remainder = quantity - bundleCount * product.BundleQuantity;
            }

            productPrice = 
                product.BundlePrice * bundleCount +
                product.UnitPrice * remainder;

            return productPrice;
        }
    }
}
