using Microsoft.AspNetCore.Mvc;

namespace SaleOnline.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
