
using Moq;
using NUnit.Framework;
using Task1_BuildTheSystem.Interfaces;
using Task1_BuildTheSystem.Models;
using Task1_BuildTheSystem.Services;

namespace Task1_BuildTheSystem.UnitTests
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> mockProductRepo;
        private ProductService productService;

        [SetUp]  
        public void SetUp()
        {
            mockProductRepo = new Mock<IProductRepository>();
            productService = new ProductService(mockProductRepo.Object);
        }

        [Test]  
        public void GetAllProducts_ReturnsCorrectData()
        {
            mockProductRepo
                .Setup(repo => repo.GetAllProducts(1, 2))
                .Returns(new List<Product>
            {
                new Product { ProductId = 1, Name = "Laptop", Price = 1000, Stock = 10 },
                new Product { ProductId = 2, Name = "Phone", Price = 500, Stock = 5 }
            });

            var products = productService.GetAllProducts();

            Assert.That(products.Count(), Is.EqualTo(2));
            Assert.That(products.First().Name, Is.EqualTo("Laptop"));
            Assert.That(products.Any(p => p.Name == "Phone"));
        }

        [Test]
        public void AddProduct_ValidData_AddsProduct()
        {
            var newProduct = new Product { ProductId = 3, Name = "Tablet", Price = 300, Stock = 20 };
            mockProductRepo.Setup(repo => repo.AddProduct(It.IsAny<Product>())).Verifiable();

            productService.AddProduct(newProduct);

            mockProductRepo.Verify(repo => repo.AddProduct(It.Is<Product>(p => p.Name == "Tablet" && p.Price == 300 && p.Stock == 20)), Times.Once);
        }

        [Test]
        public void AddProduct_InvalidStock_ThrowsException()
        {
            var newProduct = new Product { ProductId = 3, Name = "Tablet", Price = 300, Stock = -5 };

            Assert.Throws<ArgumentException>(() => productService.AddProduct(newProduct));
        }

        [Test]
        public void AddProduct_InvalidPrice_ThrowsException()
        {
            var newProduct = new Product { ProductId = 3, Name = "Tablet", Price = -100, Stock = 20 };

            Assert.Throws<ArgumentException>(() => productService.AddProduct(newProduct));
        }

        [Test]
        public void UpdateProduct_ProductExists_UpdatesProduct()
        {
            var existingProduct = new Product { ProductId = 1, Name = "Laptop", Price = 1000, Stock = 10 };
            mockProductRepo.Setup(repo => repo.GetProductById(existingProduct.ProductId)).Returns(existingProduct);
            mockProductRepo.Setup(repo => repo.UpdateProduct(It.IsAny<Product>())).Verifiable();

            existingProduct.Price = 1100; 
            productService.UpdateProduct(existingProduct);

            mockProductRepo.Verify(repo => repo.UpdateProduct(It.Is<Product>(p => p.ProductId == 1 && p.Price == 1100)), Times.Once);
        }

        [Test]
        public void UpdateProduct_ProductNotFound_ThrowsException()
        {
            var nonExistentProduct = new Product { ProductId = 999, Name = "NonExistent", Price = 100, Stock = 10 };
            mockProductRepo.Setup(repo => repo.GetProductById(nonExistentProduct.ProductId)).Returns((Product)null);

            Assert.Throws<ArgumentException>(() => productService.UpdateProduct(nonExistentProduct));
        }
    }
}
