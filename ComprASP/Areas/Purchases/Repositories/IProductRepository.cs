using ComprASP.Data;

namespace ComprASP.Areas.Purchases.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> GetAsync(int id);

        public Task<Product> StoreAsync(Product product);

        public Task<Product> UpdateAsync(Product product);
    }
}
