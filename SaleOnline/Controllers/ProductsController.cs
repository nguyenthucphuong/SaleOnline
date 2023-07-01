using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SaleOnline.Models;

namespace SaleOnline.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SaleOnline1Context _context;
        public ProductsController(SaleOnline1Context context)
        {
            _context = context;
        }


        public IActionResult Index(string? filter, int? productId)
        {
            var item = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                item = item.Where(c => c.ProductName.Contains(filter) || c.Filter.Contains(filter));
            }
            if (productId.HasValue)
            {
                item = item.Where(c => c.ProductId == productId.Value);
            }
            var result = item.ToList();
            return View(result);
        }

        public IActionResult Xoa(int productId)
        {
            var item = _context.Products.FirstOrDefault(k => k.ProductId == productId);
            if (item != null && item.IsActive == false)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        private bool IsProductIdExist(int? productId)
        {
            return _context.Products.Any(c => c.ProductId == productId);
        }
        

        [HttpPost]
        public IActionResult Them(int? productId, int userId, int categoryId, int promotionId, string productName, decimal productPrice, string producDes, string productImage, string? isNew, string? isSale, string? isPro, string filter, string? kichHoat)
        {
            if (productId.HasValue && !string.IsNullOrEmpty(productName))
            {
                if (IsProductIdExist(productId.Value))
                {
                    // Nếu categoryId đã tồn tại, hiển thị thông báo lỗi và cho phép người dùng sửa lại
                    //ModelState.AddModelError("categoryId", "CategoryId đã tồn tại. Vui lòng chọn một categoryId khác.");
                    //ModelState.AddModelError(string.Empty, "Id đã tồn tại. Vui lòng chọn một Id khác.");
                    TempData["ErrorMessage"] = "ID da ton tai. Vui long nhap ID khac!";
                    Product product = new Product();
                    return View(product);
                }
                else
                {
                    Product product = new Product(productId.Value, userId, categoryId, promotionId, productName, productPrice, producDes, productImage, isNew == "on" ? true : false, isSale == "on" ? true : false, isPro == "on" ? true : false, filter, kichHoat == "on" ? true : false);
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Product product = new Product();
                return View(product);
            }
        }



        public IActionResult CapNhat(int productId)
        {
            var product = _context.Products.FirstOrDefault(k => k.ProductId == productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        
        [HttpPost]
        public IActionResult CapNhat(int? productId, int userId, int categoryId, int promotionId, string productName, decimal productPrice, string producDes, string productImage, string? isNew, string? isSale, string? isPro, string filter, string? kichHoat)
        {
            if (!productId.HasValue)
            {
                return RedirectToAction("Index");
            }
            var product = _context.Products.FirstOrDefault(k => k.ProductId == productId.Value);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(productName))
                {
                    product.ProductName = productName.Trim();
                    if (!string.IsNullOrEmpty(filter))
                    {
                        product.Filter = filter.Trim();
                    }
                    if (!string.IsNullOrEmpty(producDes))
                    {
                        product.ProducDes = producDes.Trim();
                    }
                    product.UserId = userId;
                    product.CategoryId = categoryId;
                    product.PromotionId = promotionId;
                    product.ProductName = productName;
                    product.ProductPrice = productPrice;
                    product.ProductImage = productImage;
                    product.IsNew = isNew == "on";
                    product.IsSale = isSale == "on";
                    product.IsPro = isPro == "on";
                    product.IsActive = kichHoat == "on";
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
            }
            return RedirectToAction("Index");
        }

    }
}

