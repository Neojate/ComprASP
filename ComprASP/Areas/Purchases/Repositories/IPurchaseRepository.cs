using ComprASP.Data;

namespace ComprASP.Areas.Purchases.Repositories
{
    public interface IPurchaseRepository
    {
        public Task<IEnumerable<Purchase>> GetAllAsync(string userId);

        public Task<IEnumerable<Purchase>> GetAllForBuyAsync(string userId);

        public Task<Purchase> GetAsync(int id);

        public Task<Purchase> StoreAsync(Purchase purchase);

        public Task<Purchase> UpdateAsync(Purchase purchase);

        public Task<bool> DeleteAsync(Purchase purhcase);
    }
}
