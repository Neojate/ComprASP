using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly CompraspDbContext _context;

        public ProductRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string userId)
        {
            return await _context.Products.Where(item => item.UserId == userId).ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
