using ComprASP.Areas.Markets.Repositories;
using ComprASP.Areas.Purchases.Repositories;
using ComprASP.Areas.Purchases.ViewModels;
using ComprASP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ComprASP.Areas.Purchases.Controllers
{
    [Area("Purchases")]
    [Route("purchase/{purchaseId}/[controller]/[action]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMarketRepository _marketRepository;
        private readonly IProductPurchaseRepository _productPurchaseRepository;
        private readonly IProductRepository _productRepository;

        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public ProductController(IMarketRepository marketRepository, IProductPurchaseRepository productPurchaseRepository, IProductRepository productRepository)
        {
            _marketRepository = marketRepository;
            _productPurchaseRepository = productPurchaseRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> AddNewProduct(int purchaseId)
        {
            IEnumerable<Market> markets = await _marketRepository.GetAllAsync(UserId);

            AddProductViewModel model = new AddProductViewModel
            {
                Markets = new SelectList(markets, nameof(Market.Id), nameof(Market.Name)),
            };

            ViewBag.PurchaseId = purchaseId;

            return PartialView("_AddProduct", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel model, int purchaseId)
        {
            if (!ModelState.IsValid)
                return PartialView("_AddProduct", model);

            //TODO: el producto es nuevo
            Product product = await _productRepository.StoreAsync(new Product
            {
                Name = model.ProductName,
                MarketId = model.MarketId,
                UserId = UserId
            });

            await _productPurchaseRepository.StoreAsync(new ProductPurchase
            {
                PurchaseId = purchaseId,
                ProductId = product.Id,
                Quantity = model.Quantity,
            });

            return Redirect($"purchase/{purchaseId}/index");
        }
    }
}
