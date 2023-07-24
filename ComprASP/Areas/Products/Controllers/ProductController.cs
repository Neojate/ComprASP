using ComprASP.Areas.Markets.Repositories;
using ComprASP.Areas.Products.Repositories;
using ComprASP.Areas.Products.ViewModels;
using ComprASP.Data;
using ComprASP.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ComprASP.Areas.Products.Controllers
{
    [Area("Products")]
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

        public async Task<IActionResult> Create(int purchaseId)
        {
            IEnumerable<Market> markets = await _marketRepository.GetAllAsync(UserId);

            AddProductViewModel model = new AddProductViewModel
            {
                Markets = new SelectList(markets, nameof(Market.Id), nameof(Market.Name))
            };

            ViewBag.PurchaseId = purchaseId;
            ViewBag.FormAction = nameof(Create);

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductViewModel model, int purchaseId)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

            Product product = await CheckProduct(model);

            await _productPurchaseRepository.StoreAsync(new ProductPurchase
            {
                PurchaseId = purchaseId,
                ProductId = product.Id,
                Quantity = model.Quantity,
            });

            return Redirect($"/purchase/edit/{purchaseId}");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int purchaseId, int id)
        {
            ProductPurchase pp = await _productPurchaseRepository.GetAsync(id);

            if (pp.PurchaseId != purchaseId)
                return NotFound();

            IEnumerable<Market> markets = await _marketRepository.GetAllAsync(UserId);

            AddProductViewModel model = new AddProductViewModel
            {
                Id = pp.Id,
                ProductName = pp.Product.Name,
                ProductId = pp.Product.Id,
                MarketId = pp.Product.MarketId,
                Quantity = pp.Quantity,
                Markets = new SelectList(markets, nameof(Market.Id), nameof(Market.Name))
            };

            ViewBag.PurchaseId = purchaseId;
            ViewBag.FormAction = nameof(Update);

            return View(model);
        }

        public async Task<IActionResult> Update(AddProductViewModel model, int purchaseId)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            Product product = await CheckProduct(model);

            await _productPurchaseRepository.UpdateAsync(new ProductPurchase
            {
                Id = model.Id ?? default(int),
                ProductId = product.Id,
                PurchaseId = purchaseId,
                Quantity = model.Quantity,
            });

            return Redirect($"/purchase/edit/{purchaseId}");
        }

        [HttpPost]
        public async Task<IActionResult> FoundProduct(ProductName model)
        {
            Product product = await _productRepository.GetByName(model.Name, UserId);

            return product == null
                ? NotFound()
                : Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int purchaseId, int id)
        {
            ProductPurchase productPurchase = await _productPurchaseRepository.GetAsync(id);

            return await _productPurchaseRepository.DeleteAsync(productPurchase)
                ? Redirect($"/purchase/edit/{purchaseId}")
                : NotFound();
        }

        private async Task<Product> CheckProduct(AddProductViewModel model)
        {
            if (model.ProductId == null)
            {
                return await _productRepository.StoreAsync(new Product
                {
                    Name = model.ProductName,
                    MarketId = model.MarketId,
                    UserId = UserId
                });
            }

            return await _productRepository.UpdateAsync(new Product
            {
                Id = model.ProductId ?? default(int),
                Name = model.ProductName,
                MarketId = model.MarketId,
                UserId = UserId
            });
        }

    }
}
