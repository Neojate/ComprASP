using ComprASP.Data;
using ComprASP.Repositories.Purchases;

namespace ComprASP.Services.Purchases
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Purchase> PurchaseAsync(int id)
        {
            return await _purchaseRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Purchase>> PurchasesAsync(string userId)
        {
            return await _purchaseRepository.GetAsync(userId);
        }

        public async Task<Purchase> StoreAsync(Purchase purchase, string userId)
        {
            return await _purchaseRepository.StoreAsync(
                purchase: new Purchase
                {
                    Name = purchase.Name ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    UserId = userId,
                    CreatedAt = DateTime.Now,
                }
            );
        }

        public async Task<Purchase> UpdateAsync(Purchase purchase, string userId)
        {
            Purchase p = await _purchaseRepository.GetAsync(purchase.Id);

            p.Name = purchase.Name;

            return await _purchaseRepository.UpdateAsync(p);
              
        }
    }
}
