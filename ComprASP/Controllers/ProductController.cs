using ComprASP.Data;
using ComprASP.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ComprASP.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        //private readonly IMarketService _marketService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
            //_marketService = marketService;
        }

        [HttpGet("{purchaseId}")]
        public async Task<IActionResult> Create(int purchaseId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //IEnumerable<Market> markets = await _marketService.Markets(userId);
            //ViewBag.Markets = new SelectList(markets, nameof(Market.Id), nameof(Market.Name));

            return PartialView("_Edit");
        }
    }
}
