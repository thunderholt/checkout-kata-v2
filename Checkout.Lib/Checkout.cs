using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Checkout
    {
        private IProductRepository productRepository = null;
        private List<BasketItem> basketItems = new List<BasketItem>();

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
            var basketItem = this.CoalesceBasketItem(sku);
            basketItem.Quantity++;
        }

        public decimal GetTotalPrice()
        {
            decimal grandTotal = 0;

            foreach (var basketItem in this.basketItems)
            {
                grandTotal += this.CalculateBasketItemPrice(basketItem);
            }

            return grandTotal;
        }

        private BasketItem CoalesceBasketItem(string sku)
        {
            var item = this.basketItems.FirstOrDefault(i => i.Sku == sku);
            if (item == null)
            {
                item = new BasketItem
                {
                    Sku = sku
                };

                this.basketItems.Add(item);
            }

            return item;
        }

        private decimal CalculateBasketItemPrice(BasketItem basketItem)
        {
            decimal basketItemPrice = 0;

            var product = this.productRepository.GetProduct(basketItem.Sku);

            if (basketItem.Quantity == product.BundleQuantity)
            {
                basketItemPrice = product.BundlePrice;
            }
            else
            {
                basketItemPrice = product.UnitPrice * basketItem.Quantity;
            }

            return basketItemPrice;
        }

        private class BasketItem
        {
            public string Sku { get; set; }
            public int Quantity { get; set; }
        }
    }
}
