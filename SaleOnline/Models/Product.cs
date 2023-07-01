using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    public int? UserId { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column("PromotionID")]
    public int? PromotionId { get; set; }

    [StringLength(100)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? ProductPrice { get; set; }

    public string? ProducDes { get; set; }

    public string? ProductImage { get; set; }

    public bool IsNew { get; set; }

    public bool IsSale { get; set; }

    public bool IsPro { get; set; }

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    public bool IsActive { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("PromotionId")]
    [InverseProperty("Products")]
    public virtual Promotion? Promotion { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    [ForeignKey("UserId")]
    [InverseProperty("Products")]
    public virtual User? User { get; set; }

    public Product() { }
    
    public Product(InProduct inProduct)
    {
        ProductId = inProduct.ProductId;
        UserId = inProduct.UserId;
        CategoryId = inProduct.CategoryId;
        PromotionId = inProduct.PromotionId;
        ProductName = inProduct.ProductName;
        ProductPrice = inProduct.ProductPrice;
        ProducDes = inProduct.ProducDes;
        ProductImage = inProduct.ProductImage;
        IsNew = inProduct.IsNew;
        IsSale = inProduct.IsSale;
        IsPro = inProduct.IsPro;
        Filter = inProduct.Filter;
        IsActive = inProduct.IsActive;
    }
    public Product(int productId, int userId, int categoryId, int promotionId, string productName, decimal productPrice, string producDes, string productImage, bool isNew, bool isSale, bool isPro, string filter, bool isActive)
    {
        ProductId = productId;
        UserId = userId;
        CategoryId = categoryId;
        PromotionId = promotionId;
        ProductName = productName;
        ProductPrice = productPrice;
        ProducDes = producDes;
        ProductImage = productImage;
        IsNew = isNew;
        IsSale = isSale;
        IsPro = isPro;
        Filter = productName+ producDes;
        IsActive = isActive;
    }
}

//public Product(int productId, int userId, int categoryId, int promotionId, string productName, decimal productPrice, string producDes, string productImage, bool isNew, bool isSale, bool isPro, string filter, bool isActive)
//{
//    ProductId = productId;
//    UserId = userId;
//    CategoryId = categoryId;
//    PromotionId = promotionId;
//    ProductName = productName;
//    ProductPrice = productPrice;
//    ProducDes = producDes;
//    ProductImage = productImage;
//    IsNew = isNew;
//    IsSale = isSale;
//    IsPro = isPro;
//    IsActive = isActive;
//    Filter = filter;
//    IsActive = isActive;
//}
