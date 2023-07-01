using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    public bool IsActive { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("User")]
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;
}
