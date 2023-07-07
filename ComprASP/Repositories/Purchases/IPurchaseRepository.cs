using ComprASP.Data;
using System.Collections;

namespace ComprASP.Repositories.Purchases
{
    public interface IPurchaseRepository
    {
        public Task<IEnumerable<Purchase>> GetAsync(string userId);

        public Task<Purchase> GetAsync(int id);

        public Task<Purchase> StoreAsync(Purchase purchase);

        public Task<Purchase> UpdateAsync(Purchase purchase);

        public Task<int> DeleteAsync(int id);
    }
}
