using System;

namespace Checkout
{
    public class ProductNotFoundException : Exception
    {
        private string sku = null;

        public ProductNotFoundException(string sku)
        {
            this.sku = sku;
        }

        public override string Message
        {
            get
            {
                return string.Format("No product was found with SKU '{0}'.", this.sku);
            }
        }
    }
}
