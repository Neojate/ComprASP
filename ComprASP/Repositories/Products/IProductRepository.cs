using ComprASP.Data;

namespace ComprASP.Repositories.Products
{
    public interface IProductRepository
    {
        public Task<Product> GetAsync(int id);

        public Task<IEnumerable<Product>> GetAllAsync(string userId);
    }
}
