using ComprASP.Areas.Markets.Repositories;
using ComprASP.Areas.Products.Repositories;
using ComprASP.Areas.Products.ViewModels;
using ComprASP.Data;
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

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductViewModel model, int purchaseId)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

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
                ProductName = pp.Product.Name,
                MarketId = pp.Product.MarketId,
                Quantity = pp.Quantity,
                Markets = new SelectList(markets, nameof(Market.Id), nameof(Market.Name))
            };

            ViewBag.PurchaseId = purchaseId;

            return View(model);
        }

        public async Task<IActionResult> Update(AddProductViewModel model, int purchaseId)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            Product product = (await _productRepository.GetAllAsync(UserId)).Where(item => item.Name == model.ProductName).FirstOrDefault();

            if (product == null)
                return NotFound();



            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FoundProduct(ProductName model)
        {
            Product product = await _productRepository.GetByName(model.Name, UserId);

            return product == null
                ? NotFound()
                : Ok(product);
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
