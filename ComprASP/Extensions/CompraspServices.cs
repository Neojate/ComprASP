using ComprASP.Areas.Markets.Repositories;
using ComprASP.Areas.Purchases.Repositories;

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
