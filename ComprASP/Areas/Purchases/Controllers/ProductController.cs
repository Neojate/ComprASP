using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComprASP.Areas.Purchases.Controllers
{
    [Area("Purchases")]
    [Route("purchases/{purchaseId}/[controller]/[action]")]
    [Authorize]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewProduct()
        {
            return PartialView("_AddProduct");
        }
    }
}
