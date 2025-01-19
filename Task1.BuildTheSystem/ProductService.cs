
namespace Task1.BuildTheSystem
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool CheckStock(int productId, int quantity)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null)
                return false;

            return product.Stock >= quantity;
        }

        public void UpdateProductStock(int productId, int quantity)
        {
            var product = _productRepository.GetProductById(productId);
            if (product != null)
            {
                product.Stock -= quantity;
                _productRepository.UpdateProduct(product);
            }
        }
    }


}
