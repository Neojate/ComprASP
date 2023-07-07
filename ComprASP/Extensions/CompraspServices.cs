using ComprASP.Repositories.Markets;
using ComprASP.Repositories.ProductPurchases;
using ComprASP.Repositories.Products;
using ComprASP.Repositories.Purchases;

namespace ComprASP.Extensions
{
    public static class CompraspServices
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IMarketRepository, MarketRepository>()
                .AddScoped<IPurchaseRepository, PurchaseRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IProductPurchaseRepository, ProductPurchaseRepository>();
        }
    }
}
