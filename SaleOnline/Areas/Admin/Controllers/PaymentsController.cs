using Microsoft.AspNetCore.Mvc;

namespace SaleOnline.Areas.Admin.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
