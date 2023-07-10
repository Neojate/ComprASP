using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Areas.Purchases.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CompraspDbContext _context;

        public ProductRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public Task<Product> GetAsync(int id)
        {
            return _context.Products.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<Product> StoreAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
