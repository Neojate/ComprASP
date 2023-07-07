using ComprASP.Data;
using System.Collections;

namespace ComprASP.Areas.Purchases.Repositories
{
    public interface IPurchaseRepository
    {
        public Task<IEnumerable<Purchase>> GetAllAsync(string userId);

        public Task<Purchase> GetAsync(int id);

        public Task<Purchase> StoreAsync(Purchase purchase);

        public Task<Purchase> UpdateAsync(Purchase purchase);

        public Task<int> DeleteAsync(int id);
    }
}
