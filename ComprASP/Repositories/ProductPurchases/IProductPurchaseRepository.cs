using ComprASP.Data;

namespace ComprASP.Repositories.ProductPurchases
{
    public interface IProductPurchaseRepository
    {
        public Task<ProductPurchase> GetAsync(int id);

        public Task<IEnumerable<ProductPurchase>> GetAllAsync(int purchaseId);

        public Task<ProductPurchase> StoreAsync(ProductPurchase productPurchase);

        public Task<ProductPurchase> UpdateAsync(ProductPurchase productPurchase);

        public Task<int> Delete(int id);
    }
}
