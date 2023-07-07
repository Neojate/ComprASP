using ComprASP.Data;
using ComprASP.ViewModels;
using ComprASP.ViewModels.Markets;

namespace ComprASP.Services.Markets
{
    public interface IMarketService
    {
        public Task <IEnumerable<Market>> Markets(string userId);

        public Task<MarketViewModel> Market(int id);

        public Task<Market> Store(MarketViewModel marketViewModel, string userId);

        public Task<Market> Update(MarketViewModel marketViewModel, string userId);

        public Task<int> Delete(int id);
    }
}
