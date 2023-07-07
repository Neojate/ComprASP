using ComprASP.Data;

namespace ComprASP.Repositories.Markets
{
    public interface IMarketRepository
    {
        public Task<IEnumerable<Market>> Get(string userId);

        public Task<Market> Get(int id);

        public Task<Market> Store(Market market);

        public Task<Market> Update(Market market);

        public Task<int> Delete(int id);
    }
}
