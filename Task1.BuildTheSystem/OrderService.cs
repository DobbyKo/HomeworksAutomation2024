
namespace Task1.BuildTheSystem
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ProductService _productService;

        public OrderService(IOrderRepository orderRepository, ProductService productService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
        }

        public bool PlaceOrder(int productId, int quantity)
        {
            if (_productService.CheckStock(productId, quantity))
            {
                var order = new Order
                {
                    ProductId = productId,
                    Quantity = quantity,
                    OrderDate = DateTime.Now
                };

                _orderRepository.PlaceOrder(order);
                _productService.UpdateProductStock(productId, quantity);

                return true;
            }
            return false;
        }
    }

}
