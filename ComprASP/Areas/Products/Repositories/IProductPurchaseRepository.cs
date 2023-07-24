using ComprASP.Data;

namespace ComprASP.Areas.Products.Repositories
{
    public interface IProductPurchaseRepository
    {
        public Task<ProductPurchase> GetAsync(int id);

        public Task<ProductPurchase> StoreAsync(ProductPurchase productPurchase);

        public Task<ProductPurchase> UpdateAsync(ProductPurchase productPurchase);

        public Task<bool> DeleteAsync(ProductPurchase productPurchase);
    }
}
