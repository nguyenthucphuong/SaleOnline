using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int PaymentId { get; set; }

    public int PromotionId { get; set; }

    public int OrderStatusId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderDatetime { get; set; }

    public bool IsActive { get; set; }

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("OrderStatusId")]
    [InverseProperty("Orders")]
    public virtual OrderStatus OrderStatus { get; set; } = null!;

    [ForeignKey("PaymentId")]
    [InverseProperty("Orders")]
    public virtual Payment Payment { get; set; } = null!;

    [ForeignKey("PromotionId")]
    [InverseProperty("Orders")]
    public virtual Promotion Promotion { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;

}
