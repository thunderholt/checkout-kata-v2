namespace Checkout
{
    public class Checkout
    {
        private decimal grandTotal = 0;

        public void Scan(char sku)
        {
            this.Scan(sku.ToString());
        }

        public void Scan(string sku)
        {
            if (sku == "A")
            {
                this.grandTotal += 40;
            }
            else if (sku == "B")
            {
                this.grandTotal += 50;
            }
        }

        public decimal GetTotalPrice()
        {
            return this.grandTotal;
        }
    }
}
