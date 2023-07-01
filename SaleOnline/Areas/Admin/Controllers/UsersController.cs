using Microsoft.AspNetCore.Mvc;
using SaleOnline.Models;

namespace SaleOnline.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly SaleOnline1Context db;
        public IActionResult Index()
        {
            var user = new User();
            return View(user);
        }
        
       
           

            public UsersController(SaleOnline1Context context)
            {
                db = context;
            }

            [HttpPost]
            public ActionResult Login(string email, string password)
            {
                // Kiểm tra thông tin đăng nhập
                var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user != null)
                {
                    // Đăng nhập thành công
                    // Lưu thông tin người dùng vào session
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("UserName", user.UserName);
                    HttpContext.Session.SetInt32("RoleId", user.RoleId);

                    // Chuyển hướng người dùng tùy thuộc vào vai trò
                    if (user.RoleId == 1)
                    {
                        // Chuyển đến trang quản lý của admin
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (user.RoleId == 2)
                    {
                        // Chuyển đến trang mua hàng của người dùng
                        return RedirectToAction("Index", "OrderItems");
                    }
                }
                else
                {
                    // Đăng nhập thất bại
                    ViewBag.Message = "Email hoặc mật khẩu không đúng";
                }

                return View();
            }
        

    }
}
