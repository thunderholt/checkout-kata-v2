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
                bundleCount = Math.DivRem(quantity, product.BundleQuantity, out remainder);
            }

            productPrice = 
                product.BundlePrice * bundleCount +
                product.UnitPrice * remainder;

            return productPrice;
        }
    }
}
