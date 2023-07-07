using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Repositories.Markets
{
    public class MarketRepository : IMarketRepository
    {
        private readonly CompraspDbContext _context;

        public MarketRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteAsync(int id)
        {
            Market? market = await _context.Markets.FirstOrDefaultAsync(item => item.Id == id);

            if (market == null)
                return -1;

            _context.Markets.Remove(market);
            await _context.SaveChangesAsync();

            return 1;
        }

        public async Task<IEnumerable<Market>> GetAllAsync(string userId)
        {
            return await _context.Markets.Where(item => item.UserId == userId).ToListAsync();  
        }

        public async Task<Market> GetAsync(int id)
        {
            return await _context.Markets.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<Market> StoreAsync(Market market)
        {
            await _context.Markets.AddAsync(market);
            await _context.SaveChangesAsync();

            return market;
        }

        public async Task<Market> UpdateAsync(Market market)
        {
            _context.Update(market);
            await _context.SaveChangesAsync();

            return market;
        }
    }
}
