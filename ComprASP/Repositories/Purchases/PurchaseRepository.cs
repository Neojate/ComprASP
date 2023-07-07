using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Repositories.Purchases
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly CompraspDbContext _context;

        public PurchaseRepository(CompraspDbContext context)
        {
            _context = context;
        }   

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Purchase>> GetAsync(string userId)
        {
            return await _context.Purchases.Where(item => item.UserId == userId).ToListAsync();
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
