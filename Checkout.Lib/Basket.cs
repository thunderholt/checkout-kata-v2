using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Basket : IBasket
    {
        private List<BasketItem> items = new List<BasketItem>();

        public IReadOnlyCollection<BasketItem> Items
        {
            get { return this.items; }
        }

        public void AddItem(string sku)
        {
            var item = this.CoalesceItem(sku);
            item.Quantity++;
        }

        private BasketItem CoalesceItem(string sku)
        {
            var item = this.items.FirstOrDefault(i => i.Sku == sku);
            if (item == null)
            {
                item = new BasketItem
                {
                    Sku = sku
                };

                this.items.Add(item);
            }

            return item;
        }
    }
}
