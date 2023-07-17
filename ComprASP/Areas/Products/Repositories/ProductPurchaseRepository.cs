﻿using ComprASP.Data;
using Microsoft.EntityFrameworkCore;

namespace ComprASP.Areas.Products.Repositories
{
    public class ProductPurchaseRepository : IProductPurchaseRepository
    {
        private readonly CompraspDbContext _context;

        public ProductPurchaseRepository(CompraspDbContext context)
        {
            _context = context;
        }

        public async Task<ProductPurchase> GetAsync(int ppId)
        {
            return await _context.ProductPurchases
                .Include(item => item.Product)
                    .ThenInclude(item => item.Market)
                .FirstOrDefaultAsync<ProductPurchase>(item => item.Id == ppId);
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