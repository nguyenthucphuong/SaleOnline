using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SaleOnline.Models;

namespace SaleOnline.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly SaleOnline1Context _context;
        public PromotionsController(SaleOnline1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Promotions.ToList();
            return View(result);
        }
        public IActionResult Xoa(int promotionId)
        {
            var item = _context.Promotions.FirstOrDefault(k => k.PromotionId == promotionId);
            if (item != null && item.IsActive == false)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        private bool IsPromotionIdExist(int promotionId)
        {
            return _context.Promotions.Any(c => c.PromotionId == promotionId);
        }
        [HttpPost]
        public IActionResult Them(int? promotionId, int userId, int productId, decimal discount, DateTime startDate, DateTime endDate, string filter, string? kichHoat)
        {
            if (promotionId.HasValue)
            {
                if (IsPromotionIdExist(promotionId.Value))
                {
                    ViewBag.ErrorMessage = "Id đã tồn tại. Vui lòng chọn một Id khác.";
                    Promotion promotion = new Promotion();
                    return View(promotion);
                }
                else
                {
                    Promotion promotion = new Promotion(promotionId.Value, userId, productId, discount, startDate, endDate, filter, kichHoat == "on" ? true : false);
                    _context.Promotions.Add(promotion);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Promotion promotion = new Promotion();
                return View(promotion);
            }
        }
        public IActionResult CapNhat(int promotionId)
        {
            var promotion = _context.Promotions.FirstOrDefault(k => k.PromotionId == promotionId);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }
        [HttpPost]
        public IActionResult CapNhat(int? promotionId, int userId, int productId, decimal discount, DateTime startDate, DateTime endDate, string filter, string? kichHoat)
        {
            if (!promotionId.HasValue)
            {
                return RedirectToAction("Index");
            }

            var promotion = _context.Promotions.FirstOrDefault(k => k.PromotionId == promotionId.Value);

            if (promotion != null)
            {
                    if (!string.IsNullOrEmpty(filter))
                    {
                       promotion.Filter = filter.Trim();
                    }
                promotion.IsActive = kichHoat == "on";
                    _context.Promotions.Update(promotion);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
