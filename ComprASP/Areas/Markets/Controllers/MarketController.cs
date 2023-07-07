using ComprASP.Areas.Markets.Repositories;
using ComprASP.Data;
using ComprASP.ViewModels.Markets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComprASP.Areas.Markets.Controllers
{
    [Area("Markets")]
    [Route("[controller]/[action]")]
    [Authorize]

    public class MarketController : Controller
    {
        private readonly IMarketRepository _marketRepository;

        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public MarketController(IMarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Market> markets = await _marketRepository.GetAllAsync(userId);

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
        public async Task<IActionResult> Create(Market market)
        {
            if (!ModelState.IsValid)
                return View("Edit", market);

            market.UserId = UserId;

            return await _marketRepository.StoreAsync(market) == null
                ? View("Edit", market)
                : RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Market market = await _marketRepository.GetAsync(id);

            if (market == null || market.UserId != userId)
                return NotFound();

            ViewBag.FormAction = nameof(Update);

            return View(market);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Market market)
        {
            if (!ModelState.IsValid)
                return View(market);

            market.UserId = UserId;

            return _marketRepository.UpdateAsync(market) == null
                ? View(market)
                : RedirectToAction(nameof(Index));
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    //Market market = await _marketService.Market(id);

        //    //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    //if (market == null || market.UserId != userId)
        //    //    return NotFound();

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
