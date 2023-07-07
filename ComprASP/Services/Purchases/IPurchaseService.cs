using ComprASP.Data;
using ComprASP.ViewModels.Purchases;

namespace ComprASP.Services.Purchases
{
    public interface IPurchaseService
    {
        public Task<IEnumerable<Purchase>> PurchasesAsync(string userId);

        public Task<Purchase> PurchaseAsync(int id);

        public Task<Purchase> StoreAsync(Purchase purchaseViewModel, string userId);

        public Task<Purchase> UpdateAsync(Purchase purchaseViewModel, string userId);
    }
}
