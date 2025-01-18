
using Moq;
using NUnit.Framework;
using Task1_BuildTheSystem.Interfaces;
using Task1_BuildTheSystem.Models;
using Task1_BuildTheSystem.Services;

namespace Task1_BuildTheSystem.UnitTests
{
    public class OrderServiceTests
    {
        private Mock<IProductRepository> mockProductRepo;
        private Mock<IOrderRepository> mockOrderRepo;
        private Mock<ILogger> mockLogger;
        private OrderService orderService;

        [SetUp]
        public void SetUp()
        {
            mockProductRepo = new Mock<IProductRepository>();
            mockOrderRepo = new Mock<IOrderRepository>();
            mockLogger = new Mock<ILogger>();
            orderService = new OrderService(mockProductRepo.Object, mockOrderRepo.Object, mockLogger.Object);
        }

        [Test]
        public void PlaceOrder_ValidOrder_UpdatesStock()
        {
            var product = new Product { ProductId = 1, Name = "Laptop", Price = 1000, Stock = 10 };
            mockProductRepo.Setup(repo => repo.GetProductById(product.ProductId)).Returns(product);
            mockProductRepo.Setup(repo => repo.UpdateProduct(It.IsAny<Product>())).Verifiable();

            var order = new Order { ProductId = 1, Quantity = 5 };

            orderService.PlaceOrder(order);

            Assert.That(product.Stock, Is.EqualTo(5));
            mockProductRepo.Verify(repo => repo.UpdateProduct(It.Is<Product>(p => p.Stock == 5)), Times.Once);
        }

        [Test]
        public void PlaceOrder_InsufficientStock_ThrowsException()
        {
            var product = new Product { ProductId = 1, Name = "Laptop", Price = 1000, Stock = 3 };
            mockProductRepo.Setup(repo => repo.GetProductById(product.ProductId)).Returns(product);

            var order = new Order { ProductId = 1, Quantity = 5 };

            Assert.Throws<ArgumentException>(() => orderService.PlaceOrder(order));
        }

        [Test]
        public void PlaceOrder_NonExistentProduct_ThrowsException()
        {
            mockProductRepo
                .Setup(repo => repo.GetProductById(1))
                .Returns((Product)null);

            var order = new Order { ProductId = 1, Quantity = 1, OrderDate = DateTime.Now };

            Assert.Throws<ArgumentNullException>(() => orderService.PlaceOrder(order));
        }
    }
}
