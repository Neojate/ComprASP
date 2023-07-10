using ComprASP.Data;

namespace ComprASP.Areas.Purchases.Repositories
{
    public class ProductPurchaseRepository : IProductPurchaseRepository
    {
        private readonly CompraspDbContext _context;

        public ProductPurchaseRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<ProductPurchase> StoreAsync(ProductPurchase productPurchase)
        {
            await _context.ProductPurchases.AddAsync(productPurchase);
            await _context.SaveChangesAsync();

            return productPurchase;
        }

        public Task<ProductPurchase> UpdateAsync(ProductPurchase productPurchase)
        {
            throw new NotImplementedException();
        }
    }
}
