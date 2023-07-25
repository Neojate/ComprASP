using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Areas.Purchases.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly CompraspDbContext _context;

        public PurchaseRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Purchase purchase)
        {
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync(string userId)
        {
            return await _context.Purchases
                .Include(item => item.PurchasePrices)
                .Where(item => item.UserId == userId && item.PurchasePrices.Count() == 0).ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetAllForBuyAsync(string userId)
        {
            return await _context.Purchases
                .Include(item => item.PurchasePrices)
                .Include(item => item.ProductPurchases)                    
                    .ThenInclude(item => item.Product)
                .Where(item => item.UserId == userId).ToListAsync();
        }

        public async Task<Purchase> GetAsync(int id)
        {
            return await _context.Purchases
                .Include(item => item.ProductPurchases)
                    .ThenInclude(item => item.Product)
                        .ThenInclude(item => item.Market)
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<Purchase> StoreAsync(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();

            return purchase;
        }

        public async Task<Purchase> UpdateAsync(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();

            return purchase;
        }
    }
}
