using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Data
{
    public class CompraspDbContext : IdentityDbContext
    {
        public CompraspDbContext(DbContextOptions<CompraspDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Market> Markets { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        
        public DbSet<ProductPurchase> ProductPurchases { get; set; }

        public DbSet<PurchasePrice> PurchasePrices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Purchase>()
                .HasMany<ProductPurchase>(p => p.ProductPurchases);

            builder.Entity<ProductPurchase>()
                .HasOne<Product>(item => item.Product);

            builder.Entity<ProductPurchase>()
                .HasOne<Purchase>(item => item.Purchase);

            builder.Entity<Product>()
                .HasOne<Market>(item => item.Market);
        }

    }
}