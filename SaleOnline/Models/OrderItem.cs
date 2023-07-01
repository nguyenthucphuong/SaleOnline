using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

public partial class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //public int OrderItemId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderItemDatetime { get; set; }

    public bool IsActive { get; set; }

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product Product { get; set; } = null!;
}
