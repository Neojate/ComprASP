using ComprASP.Data;
using ComprASP.Repositories.Markets;
using ComprASP.ViewModels.Markets;

namespace ComprASP.Services.Markets
{
    public class MarketService : IMarketService
    {
        private readonly IMarketRepository _marketRepository;

        public MarketService(IMarketRepository marketRepository) {
            _marketRepository = marketRepository;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MarketViewModel> Market(int id)
        {
            Market market = await _marketRepository.Get(id);

            return new MarketViewModel
            {
                Id = id,
                Name = market.Name,
                UserId = market.UserId,
            };
        }

        public async Task<IEnumerable<Market>> Markets(string userId)
        {
            return await _marketRepository.Get(userId);
        }

        public async Task<Market> Store(MarketViewModel marketViewModel, string userId)
        {
            //TODO: poner el automapper
            Market market = new Market
            {
                Name = marketViewModel.Name,
                UserId = userId
            };

            return await _marketRepository.Store(market);
        }

        public async Task<Market> Update(MarketViewModel marketViewModel, string userId)
        {
            //TODO: poner el automapper
            Market market = new Market
            {
                Id = marketViewModel.Id,
                Name = marketViewModel.Name,
                UserId = userId,
            };

            return await _marketRepository.Update(market);
        }
    }
}
