namespace Checkout
{
    public class Checkout
    {
        private decimal grandTotal = 0;

        public void Scan(string sku)
        {
            this.grandTotal += 40;
        }

        public decimal GetTotalPrice()
        {
            return this.grandTotal;
        }
    }
}
