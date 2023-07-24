using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Areas.Products.Repositories
{
    public class ProductPurchaseRepository : IProductPurchaseRepository
    {
        private readonly CompraspDbContext _context;

        public ProductPurchaseRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(ProductPurchase productPurchase)
        {
            _context.ProductPurchases.Remove(productPurchase);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ProductPurchase> GetAsync(int ppId)
        {
            return await _context.ProductPurchases
                .Include(item => item.Product)
                    .ThenInclude(item => item.Market)
                .FirstOrDefaultAsync<ProductPurchase>(item => item.Id == ppId);
        }

        public async Task<ProductPurchase> StoreAsync(ProductPurchase productPurchase)
        {
            await _context.ProductPurchases.AddAsync(productPurchase);
            await _context.SaveChangesAsync();

            return productPurchase;
        }

        public async Task<ProductPurchase> UpdateAsync(ProductPurchase productPurchase)
        {
            _context.ProductPurchases.Update(productPurchase);
            await _context.SaveChangesAsync();

            return productPurchase;
        }
    }
}
