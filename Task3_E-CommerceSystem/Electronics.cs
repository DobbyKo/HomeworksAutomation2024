
namespace Task3_E_CommerceSystem
{
    public class Electronics : Product
    {
        public Electronics(string name, decimal price) : base(name, price)
        {
        }

        public override decimal GetDiscountedPrice()
        {
            return Price * 0.9m;
        }
    }
}
