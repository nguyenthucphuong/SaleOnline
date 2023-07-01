using Microsoft.AspNetCore.Mvc;

namespace SaleOnline.Controllers
{
    public class OrderItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
