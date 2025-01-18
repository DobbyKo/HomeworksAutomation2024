using Task1_BuildTheSystem.Models;

namespace Task1_BuildTheSystem.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(int pageNumber, int pageSize);
        Product GetProductById(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
