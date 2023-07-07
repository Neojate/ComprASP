using ComprASP.Data;

namespace ComprASP.Repositories.Markets
{
    public interface IMarketRepository
    {
        public Task<IEnumerable<Market>> GetAllAsync(string userId);

        public Task<Market> GetAsync(int id);

        public Task<Market> StoreAsync(Market market);

        public Task<Market> UpdateAsync(Market market);

        public Task<int> DeleteAsync(int id);
    }
}
