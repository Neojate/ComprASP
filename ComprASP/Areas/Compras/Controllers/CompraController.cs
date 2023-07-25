using ComprASP.Areas.Compras.Repositories;
using ComprASP.Areas.Compras.ViewModels;
using ComprASP.Areas.Purchases.Repositories;
using ComprASP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComprASP.Areas.Compras.Controllers
{
    [Area("Compras")]
    [Route("[controller]/[action]")]
    [Authorize]
    public class CompraController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ICompraRepository _compraRepository;

        private string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public CompraController(IPurchaseRepository purchaseRepository, ICompraRepository compraRepository)
        {
            _purchaseRepository = purchaseRepository;
            _compraRepository = compraRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Purchase> purchases = await _purchaseRepository.GetAllForBuyAsync(UserId);

            List<PurchaseMarketViewModel> model = new List<PurchaseMarketViewModel>();

            foreach (Purchase purchase in purchases)
            {
                
            }

            return View(purchases);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    IEnumerable<PurchasePrice> result = await _compraRepository.GetAllAsync(id);
        //    List<PurchasePrice> prices = new List<PurchasePrice>();

        //    foreach (PurchasePrice price in result)
        //    {

        //    }
        //}
    }
}
