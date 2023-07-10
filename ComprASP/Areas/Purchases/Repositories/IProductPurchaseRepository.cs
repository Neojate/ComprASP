using ComprASP.Data;

namespace ComprASP.Areas.Purchases.Repositories
{
    public interface IProductPurchaseRepository
    {
        public Task<ProductPurchase> StoreAsync(ProductPurchase productPurchase);

        public Task<ProductPurchase> UpdateAsync(ProductPurchase productPurchase);
    }
}
