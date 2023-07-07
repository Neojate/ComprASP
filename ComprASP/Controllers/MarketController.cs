using ComprASP.Data;
using ComprASP.Services.Markets;
using ComprASP.ViewModels.Markets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComprASP.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]

    public class MarketController : Controller
    {
        private readonly IMarketService _marketService;
        
        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;            
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            IEnumerable<Market> markets = await _marketService.Markets(userId);

            return View(markets);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.FormAction = nameof(Create);

            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarketViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Edit", viewModel);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Market market = await _marketService.Store(viewModel, userId);

            return market == null
                ? View("Edit", viewModel)
                : RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MarketViewModel market = await _marketService.Market(id);

            if (market == null || market.UserId != userId)
                return NotFound();

            ViewBag.FormAction = nameof(Update);

            return View(market);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Update(MarketViewModel marketViewModel)
        {
            if (!ModelState.IsValid)
                return View(marketViewModel);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Market market = await _marketService.Update(marketViewModel, userId);

            if (market == null)
                return View(marketViewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Market market = await _marketService.Market(id);

            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //if (market == null || market.UserId != userId)
            //    return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
