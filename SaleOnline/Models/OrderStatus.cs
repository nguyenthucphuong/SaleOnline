using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

[Table("OrderStatus")]
public partial class OrderStatus
{
    [Key]
    public int OrderStatusId { get; set; }

    [StringLength(50)]
    public string OrderStatusName { get; set; } = null!;

    public bool IsActive { get; set; }

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    [InverseProperty("OrderStatus")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
