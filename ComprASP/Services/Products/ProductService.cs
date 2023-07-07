using ComprASP.Data;
using ComprASP.Repositories.Products;

namespace ComprASP.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<Product> ProductAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<IEnumerable<Product>> ProductsAsync(string userId)
        {
            return _repository.GetAllAsync(userId);
        }
    }
}
