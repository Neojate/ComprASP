using ComprASP.Data;
using ComprASP.Services.Purchases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComprASP.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Purchase> purchases = await _purchaseService.PurchasesAsync(userId);

            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.FormAction = nameof(Create);

            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Purchase purchase)
        {
            if (!ModelState.IsValid)
                return View("Edit", purchase);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Purchase p = await _purchaseService.StoreAsync(purchase, userId);

            return p == null
                ? View("Edit", purchase)
                : RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Purchase purchase = await _purchaseService.PurchaseAsync(id);

            if (purchase == null)
                return NotFound();

            ViewBag.FormAction = nameof(Update);

            return View(purchase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Purchase purchase)
        {
            if (!ModelState.IsValid)
                return View(purchase);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Purchase p = await _purchaseService.UpdateAsync(purchase, userId);

            if (purchase == null)
                return View(p);

            return RedirectToAction(nameof(Index));
        }
    }
}
