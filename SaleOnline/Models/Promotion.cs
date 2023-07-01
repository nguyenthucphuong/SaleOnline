using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

public partial class Promotion
{
    [Key]
    [Column("PromotionID")]
    public int PromotionId { get; set; }

    public int? UserId { get; set; }

    [Column("ProductID")]
    public int? ProductId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Discount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    public bool IsActive { get; set; }

    [InverseProperty("Promotion")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("ProductId")]
    [InverseProperty("Promotions")]
    public virtual Product? Product { get; set; }

    [InverseProperty("Promotion")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [ForeignKey("UserId")]
    [InverseProperty("Promotions")]
    public virtual User? User { get; set; }

    public Promotion() { }
    public Promotion(int promotionId, int userId, int productId, decimal discount, DateTime startDate, DateTime endDate, string filter, bool isActive)
    {
        PromotionId = promotionId;
        UserId = userId;
        ProductId = productId;
        Discount = discount;
        StartDate = startDate;
        EndDate = endDate;
        Filter = filter;
        IsActive = isActive;
    }


}
