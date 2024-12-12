
using System.Diagnostics;

namespace Task3_E_CommerceSystem
{
    public class Clothing : Product
    {
        public Clothing(string name, decimal price) : base(name, price)
        {
        }

        public override decimal GetDiscountedPrice()
        {
            return Price * 0.8m;
        }
    }
}
