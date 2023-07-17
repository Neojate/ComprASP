using ComprASP.Data;

namespace ComprASP.Areas.Products.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync(string userId);

        public Task<Product> GetAsync(int id);

        public Task<Product> GetByName(string name, string userId);

        public Task<Product> StoreAsync(Product product);

        public Task<Product> UpdateAsync(Product product);
    }
}
