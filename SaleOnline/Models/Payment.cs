using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

public partial class Payment
{
    [Key]
    public int PaymentId { get; set; }

    [StringLength(50)]
    public string PaymentName { get; set; } = null!;

    public bool IsActive { get; set; }

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    [InverseProperty("Payment")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
