using Microsoft.Extensions.Logging;
using Task1_BuildTheSystem.Interfaces;
using Task1_BuildTheSystem.Models;

namespace Task1_BuildTheSystem.Services
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public void PlaceOrder(Order order)
        {
            var product = _productRepository.GetProductById(order.ProductId);
            if (product == null)
            {
                _logger.LogError($"Order failed: Product with ID {order.ProductId} not found.");
                throw new KeyNotFoundException($"Product with ID {order.ProductId} not found.");
            }

            if (product.Stock < order.Quantity)
            {
                _logger.LogError($"Order failed: Not enough stock for product '{product.Name}' (Requested: {order.Quantity}, Available: {product.Stock}).");
                throw new InvalidOperationException($"Not enough stock to fulfill the order for '{product.Name}'.");
            }

            decimal discountAmount = product.Price * (product.Discount / 100);
            decimal finalPrice = product.Price - discountAmount;
            decimal totalPrice = finalPrice * order.Quantity;

            _orderRepository.PlaceOrder(order);
            product.Stock -= order.Quantity;
            _productRepository.UpdateProduct(product);

            _logger.LogError($"Order placed: {order.Quantity} units of '{product.Name}' at {finalPrice:C} each. Total: {totalPrice:C}");

            if (product.Discount > 0)
            {
                _logger.LogError($"Discount applied: {product.Discount}% off. Final price per unit: {finalPrice:C}");
            }
        }
        public IEnumerable<Order> GetOrders(int pageNumber = 1, int pageSize = 10)
        {
            return _orderRepository.GetOrders()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public Order GetOrderById(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }
    }
}
