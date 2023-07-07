using ComprASP.Data;

namespace ComprASP.Services.ProductPurchases
{
    public interface IProductPurchaseService
    {
        public Task<ProductPurchase> ProductPurchaseAsync(int id);

        public Task<IEnumerable<ProductPurchase>> ProductPurchasesAsync(int purchaseId);
    }
}
