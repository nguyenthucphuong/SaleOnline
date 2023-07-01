using Microsoft.AspNetCore.Mvc;

namespace SaleOnline.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
