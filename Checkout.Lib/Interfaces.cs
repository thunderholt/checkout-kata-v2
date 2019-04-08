using System.Collections.Generic;

namespace Checkout
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProduct(string sku);
    }

    public interface IBasket
    {
        IReadOnlyCollection<BasketItem> Items { get; }
        void AddItem(string sku);
    }
}
