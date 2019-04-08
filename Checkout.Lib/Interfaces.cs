namespace Checkout
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProduct(string sku);
    }
}
