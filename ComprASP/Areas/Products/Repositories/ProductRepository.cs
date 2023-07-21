using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Areas.Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CompraspDbContext _context;

        public ProductRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string userId)
        {
            return await _context.Products.Where(item => item.UserId == userId).ToListAsync();
        }

        public async Task<Product> GetByName(string name, string userId)
        {
            return await _context.Products
                .Include(item => item.Market)
                .FirstOrDefaultAsync(item => item.UserId == userId && item.Name.Contains(name));
        }

        public async Task<Product> StoreAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
