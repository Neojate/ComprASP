using ComprASP.Repositories.Markets;
using ComprASP.Repositories.ProductPurchases;
using ComprASP.Repositories.Products;
using ComprASP.Repositories.Purchases;
using ComprASP.Services.Markets;
using ComprASP.Services.Products;
using ComprASP.Services.Purchases;

namespace ComprASP.Extensions
{
    public static class CompraspServices
    {
        public static void AddComprasServices(this IServiceCollection services)
        {
            services
                .AddScoped<IMarketRepository, MarketRepository>()
                .AddScoped<IMarketService, MarketService>()

                .AddScoped<IPurchaseRepository, PurchaseRepository>()
                .AddScoped<IPurchaseService, PurchaseService>()

                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IProductService, ProductService>()

                .AddScoped<IProductPurchaseRepository, ProductPurchaseRepository>();
        }
    }
}
