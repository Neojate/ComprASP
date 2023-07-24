using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Areas.Compras.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly CompraspDbContext _context;

        public CompraRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchasePrice>> GetAllAsync(int purchaseId)
        {
            return await _context.PurchasePrices
                .Where(item => item.PurchaseId == purchaseId)
                .GroupBy(item => item.MarketId)
                .ToListAsync();
        }

        public async Task<PurchasePrice> GetAsync(int id)
        {
            return await _context.PurchasePrices.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<PurchasePrice> Store(PurchasePrice purchasePrice)
        {
            await _context.PurchasePrices.AddAsync(purchasePrice);
            await _context.SaveChangesAsync();

            return purchasePrice;
        }
    }
}
