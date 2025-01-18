using NUnit.Framework;
using Task1_BuildTheSystem.Interfaces;
using Task1_BuildTheSystem.Models;
using Task1_BuildTheSystem.Repos;

namespace Task1_BuildTheSystem.UnitTests
{
    public class DatabaseIntegrationTests
    {
        private string connectionString;
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;

        [SetUp]
        public void SetUp()
        {
            connectionString = "...";
            productRepository = new ProductRepository(connectionString);
            orderRepository = new OrderRepository(connectionString);
        }

        [Test]
        public void AddProduct_ShouldInsertProduct()
        {
            var product = new Product
            {
                Name = "Smartwatch",
                Price = 20.99m,
                Stock = 100
            };

            productRepository.AddProduct(product);

            var addedProduct = productRepository.GetAllProducts(1, 2)
                .FirstOrDefault(p => p.Name == "Smartwatch");

            Assert.That(addedProduct, Is.Not.Null);
            Assert.That(addedProduct.Name, Is.EqualTo("Smartwatch"));
            Assert.That(addedProduct.Price, Is.EqualTo(20.99m));
            Assert.That(addedProduct.Stock, Is.EqualTo(100));
        }

        [Test]
        public void GetAllProducts_ShouldReturnProducts()
        {
            var products = productRepository.GetAllProducts(1, 2);
            Assert.That(products.Any(), Is.True);
        }

        [Test]
        public void PlaceOrder_ShouldUpdateStock()
        {
            var product = productRepository.GetAllProducts(1, 2).First();
            int initialStock = product.Stock;

            var order = new Order
            {
                ProductId = product.ProductId,
                Quantity = 2,
                OrderDate = DateTime.Now
            };

            orderRepository.PlaceOrder(order);

            var updatedProduct = productRepository.GetProductById(product.ProductId);
            Assert.That(updatedProduct.Stock, Is.EqualTo(initialStock - 2));
        }

        [TearDown]
        public void CleanUp()
        {
            var product = productRepository.GetAllProducts(1, 2)
                .FirstOrDefault(p => p.Name == "Smartwatcht");
            if (product != null)
            {
                productRepository.DeleteProduct(product.ProductId);
            }
        }
    }
}
