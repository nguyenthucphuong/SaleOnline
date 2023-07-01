using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using SaleOnline.Models;
using Microsoft.AspNetCore.Http;

namespace SaleOnline.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SaleOnline1Context? _dbContext;
        public HomeController(ILogger<HomeController> logger, SaleOnline1Context dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string? filter, int? productId)
        {
            if (_dbContext == null)
            {
                  return NotFound(); 
            }
            var item = _dbContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                item = item.Where(c => c.ProductName.Contains(filter) || c.Filter.Contains(filter));
            }
            if (productId.HasValue)
            {
                item = item.Where(c => c.CategoryId == productId.Value);
            }
            var result = item.ToList();
            return View(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Shop(string? filter, int? productId)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var products = _dbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                products = products.Where(p => p.ProductName.Contains(filter));
            }

            if (productId.HasValue)
            {
                products = products.Where(p => p.ProductId == productId.Value);
            }

            var result = products.ToList();
            return View(result);
        }

        public IActionResult Detail(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}


