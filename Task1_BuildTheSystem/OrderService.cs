
namespace Task1_BuildTheSystem
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public bool PlaceOrder(Order order)
        {
            var product = _productRepository.GetProductById(order.ProductId);
            if (product == null || product.Stock < order.Quantity)
            {
                return false; 
            }

            product.Stock -= order.Quantity;
            _productRepository.UpdateProduct(product);

            order.OrderDate = DateTime.Now;
            _orderRepository.PlaceOrder(order);

            return true;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }
    }
}
