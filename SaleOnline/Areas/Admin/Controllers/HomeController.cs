using Microsoft.AspNetCore.Mvc;
using SaleOnline.Models;
using SaleOnline.Areas.Admin.Models.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SaleOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class HomeController : Controller
    {
        private readonly SaleOnline1Context _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, SaleOnline1Context context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            //var categories = _context.Categories.ToList();
            //var orderItems = _context.OrderItems.ToList();
            //var oders = _context.Orders.ToList();
            //var payments = _context.Payments.ToList();
            //var products = _context.Products.ToList();
            //var promotions = _context.Promotions.ToList();
            //var roles = _context.Roles.ToList();
            //var users = _context.Users.ToList();
            //var orderStatus = _context.OrderStatuses.ToList();
            //DataHome data = new DataHome
            //{
            //    DsCategories = categories,
            //    DsOrderItems = orderItems,
            //    DsOrders = orderItems,
            //    DsPayments = payments,
            //    DsProducts = products,
            //    DsPromotions = promotions,
            //    DsRoles = roles,
            //    DsUsers = users,
            //    DsOrderStatuses = orderStatus
            //};
            //return View(data);
            return View();
        }
        //[HttpPost("SomeAction")]
        //public ActionResult SomeAction()
        //{
        //    return View("~/Areas/Admin/Views/Categories/Index.cshtml");
        //}
        [HttpPost]
        public IActionResult Charts()
        {
            return View("~/Areas/Admin/Views/Home/charts.cshtml");
        }
        [HttpPost]
        public IActionResult Categories()
        {
            return View("~/Areas/Admin/Views/Home/Categories/Index.cshtml");
        }

    }
}
