using Task1_BuildTheSystem.Interfaces;
using Task1_BuildTheSystem.Models;

namespace Task1_BuildTheSystem.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _productRepository.GetProductById(product.ProductId);
            if (existingProduct != null)
            {
                if (product.Stock < 0)
                    throw new InvalidOperationException("Stock cannot be negative.");

                _productRepository.UpdateProduct(product);
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {product.ProductId} not found.");
            }
        }
        public void AddProduct(Product product)
        {
            if (product.Price < 0)
                throw new InvalidOperationException("Price cannot be negative.");

            if (product.Stock < 0)
                throw new InvalidOperationException("Stock cannot be negative.");

            _productRepository.AddProduct(product);
            Console.WriteLine($"Product '{product.Name}' added successfully!");
        }

        public void DeleteProduct(int productId)
        {
            var existingProduct = _productRepository.GetProductById(productId);
            if (existingProduct != null)
            {
                _productRepository.DeleteProduct(productId);
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }
    }
}
