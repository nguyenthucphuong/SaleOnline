using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SaleOnline.Models;

namespace SaleOnline.Controllers
{
    public class CartsController : Controller
    {
        private readonly SaleOnline1Context _context;
        public CartsController(SaleOnline1Context context)
        {
            _context = context;
        }
        public IActionResult Cart()
        {
            if (_context == null)
            {
                return NotFound();
            }
            var cart = _context.Carts.ToList();
            return View(cart);
        }

        public IActionResult AddToCart(int productId, int quantity)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return NotFound();
            }

            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem == null)
            {
                // Nếu chưa có, thêm một đối tượng Cart mới
                cartItem = new Cart
                {
                    ProductId = productId,
                    ProductName = product.ProductName,
                    ProductImage= product.ProductImage,
                    ProductPrice = product.ProductPrice ?? 0,
                    Quantity = quantity
                };
                _context.Carts.Add(cartItem);
            }
            else
            {
                // Nếu đã có, cập nhật số lượng
                cartItem.Quantity += quantity;
            }
            _context.SaveChanges();
            return RedirectToAction("Shop", "Home");
        }
        public IActionResult Delete(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var cartItem = _context.Carts.FirstOrDefault(k => k.ProductId == productId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int changeQuantity)
        {
            if (_context == null)
            {
                return NotFound();
            }
            // Tìm sản phẩm trong giỏ hàng
            var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem == null)
            {
                return NotFound();
            }

            // Cập nhật số lượng
            cartItem.Quantity += changeQuantity;
            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpPost]
        
        public IActionResult UpdateCart(List<Cart> cartItems, string submitButton)
        {
             if (submitButton == "minus")
            {
                foreach (var item in cartItems)
                {
                    if (item.Quantity > 0)
                    {
                        item.Quantity--;
                    }
                }
            }
            else if (submitButton == "plus")
            {
                foreach (var item in cartItems)
                {
                    item.Quantity++;
                }
            }
            decimal subTotal = 0;
            foreach (var item in cartItems)
            {
                subTotal += item.ProductPrice * item.Quantity;
            }
            ViewBag.SubTotal = subTotal;

            // Trả lại view "Cart" với danh sách cartItems và ViewBag.SubTotal
            return View("Cart", cartItems);
        }
        //[HttpPost]
        public IActionResult Checkout()
        {
            if (_context == null)
            {
                return NotFound();
            }

            // Lấy dữ liệu từ bảng Cart
            var cart = _context.Carts.ToList();
            return View(cart);
        }
        [HttpPost]
        public IActionResult PlaceOrder()
        {
            if (_context == null)
            {
                return NotFound();
            }

            // Lấy dữ liệu từ bảng Cart
            var cart = _context.Carts.ToList();

            // Tạo một đối tượng Order mới
            var order = new Order
            {
                UserId = 1, 
                PaymentId = 1, 
                PromotionId = 1, 
                OrderStatusId = 1, 
                Total = cart.Sum(item => item.Total),
                OrderDatetime = DateTime.Now,
                IsActive = true,
                Filter = "filter",
                OrderItems = new List<OrderItem>()
            };

            // Tạo các đối tượng OrderItem mới
            foreach (var item in cart)
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.ProductPrice,
                    OrderItemDatetime = DateTime.Now,
                    IsActive = true,
                    Filter = "filter"
                };
                order.OrderItems.Add(orderItem);
            }
            _context.Orders.Add(order);
            _context.SaveChanges();

            // Xóa dữ liệu trong bảng Cart
            _context.Carts.RemoveRange(cart);
            _context.SaveChanges();
            return RedirectToAction("Shop", "Home");

        }

    }
}
