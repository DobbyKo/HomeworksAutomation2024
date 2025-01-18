using Task1_BuildTheSystem.Models;

namespace Task1_BuildTheSystem.Interfaces
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int orderId);
    }
}
