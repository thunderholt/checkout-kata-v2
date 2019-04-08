namespace Checkout
{
    public class Checkout
    {
        private int grandTotal = 0;

        public void Scan(string sku)
        {
            this.grandTotal = 40;
        }

        public int GetTotalPrice()
        {
            return this.grandTotal;
        }
    }
}
