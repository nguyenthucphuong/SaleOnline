using System.ComponentModel.DataAnnotations;

namespace SaleOnline.Models
{
    public class Cart
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }="";
        public string? ProductImage { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public Cart()
        {
            ProductName = "";
            //Quantity = 1;
        }
        public decimal Total
        {
            get
            {
                return ProductPrice * Quantity;
            }
        }
    }
}
