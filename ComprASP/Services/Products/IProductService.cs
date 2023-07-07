using ComprASP.Data;

namespace ComprASP.Services.Products
{
    public interface IProductService
    {
        public Task<Product> ProductAsync(int id);
        
        public Task<IEnumerable<Product>> ProductsAsync(string userId);
    }
}
