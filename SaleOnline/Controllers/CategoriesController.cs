using Microsoft.AspNetCore.Mvc;
using SaleOnline.Models;

namespace SaleOnline.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly SaleOnline1Context _context;
        public CategoriesController(SaleOnline1Context context)
        {
            _context = context;
        }
        public IActionResult Index(string? filter, int? categoryId)
        {
            var item = _context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                item = item.Where(c => c.CategoryName.Contains(filter) || c.Filter.Contains(filter));
            }
            if (categoryId.HasValue)
            {
                item = item.Where(c => c.CategoryId == categoryId.Value);
            }
            var result = item.ToList();
            return View(result);
        }

        public IActionResult Xoa(int categoryId)
        {
            var item = _context.Categories.FirstOrDefault(k => k.CategoryId == categoryId);
            if (item != null && item.IsActive == false)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private bool IsCategoryIdExist(int categoryId)
        {
            return _context.Categories.Any(c => c.CategoryId == categoryId);
        }
        [HttpPost]
        public IActionResult Them(int? categoryId, string categoryName, string filter, string? kichHoat)
        {
            if (categoryId.HasValue && !string.IsNullOrEmpty(categoryName))
            {
                if (IsCategoryIdExist(categoryId.Value))
                {
                    ViewBag.ErrorMessage = "Id đã tồn tại. Vui lòng chọn một Id khác.";
                    Category category = new Category();
                    return View(category);
                }
                else
                {
                    Category category = new Category(categoryId.Value, categoryName, filter, kichHoat == "on" ? true : false);
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Category category = new Category();
                return View(category);
            }
        }

        public IActionResult CapNhat(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(k => k.CategoryId == categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult CapNhat(int? categoryId, string categoryName, string filter, string? kichHoat)
        {
            if (!categoryId.HasValue)
            {
                return RedirectToAction("Index");
            }

            var category = _context.Categories.FirstOrDefault(k => k.CategoryId == categoryId.Value);

            if (category != null)
            {
                if (!string.IsNullOrEmpty(categoryName))
                {
                    category.CategoryName = categoryName.Trim();
                    if (!string.IsNullOrEmpty(filter))
                    {
                        category.Filter = filter.Trim();
                    }
                    //category.IsActive = isActive;
                    category.IsActive = kichHoat == "on";
                    _context.Categories.Update(category);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(category);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
