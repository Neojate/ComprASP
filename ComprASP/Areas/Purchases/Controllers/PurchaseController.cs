using ComprASP.Areas.Purchases.Repositories;
using ComprASP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComprASP.Areas.Purchases.Controllers
{
    [Area("Purchases")]
    [Route("[controller]/[action]")]
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;

        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Purchase> purchases = await _purchaseRepository.GetAllAsync(UserId);

            return View(purchases);
        }

        [HttpGet]
        public IActionResult Create()
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

            purchase.UserId = UserId;
            purchase.Name = purchase.Name ?? DateTime.Now.ToString();
            purchase.CreatedAt = DateTime.Now;

            return await _purchaseRepository.StoreAsync(purchase) == null
                ? View("Edit", purchase)
                : RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Purchase purchase = await _purchaseRepository.GetAsync(id);

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

            purchase.UserId = UserId;

            return await _purchaseRepository.UpdateAsync(purchase) == null
                ? View(purchase)
                : RedirectToAction(nameof(Index));
        }
    }
}
