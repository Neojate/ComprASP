using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Repositories.ProductPurchases
{
    public class ProductPurchaseRepository : IProductPurchaseRepository
    {
        private readonly CompraspDbContext _context;

        public ProductPurchaseRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductPurchase>> GetAllAsync(int purchaseId)
        {
            return await _context.ProductPurchases.Where(item => item.PurchaseId == purchaseId).ToListAsync();
        }

        public async Task<ProductPurchase> GetAsync(int id)
        {
            return await _context.ProductPurchases.FirstOrDefaultAsync(item => item.Id == id);
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
