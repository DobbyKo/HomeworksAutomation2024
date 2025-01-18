
namespace Task1.BuildTheSystem
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int orderId);
    }
}
