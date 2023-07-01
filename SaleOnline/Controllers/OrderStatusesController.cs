using Microsoft.AspNetCore.Mvc;

namespace SaleOnline.Controllers
{
    public class OrderStatusesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
