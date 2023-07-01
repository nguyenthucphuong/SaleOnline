using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SaleOnline.Models;

public partial class Category
{
    [Key]
    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string CategoryName { get; set; } = null!;

    [StringLength(50)]
    public string Filter { get; set; } = null!;

    public bool IsActive { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public Category() { }
    public Category(int categoryId, string categoryName, string filter, bool isActive)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
       Filter = filter;
        IsActive = isActive;
    }


}




////public bool IsCategoryIdExists(int id)
////{
////    using (var context = new SaleOnline1Context())
////    {
////        return context.Categories.Any(c => c.CategoryId == id);
////    }
////}
//private readonly SaleOnline1Context _context;

//public Category(SaleOnline1Context context)
//{
//    _context = context;
//}
////public bool IsDatabaseEmpty()
////{
////    using (var context = new SaleOnline1Context())
////    {
////        return !context.Categories.Any();
////    }
////}
//public bool IsDatabaseEmpty()
//{
//    return !_context.Categories.Any();
//}
////public bool IsCategoryIdExists(int id)
////{
////    using (var context = new SaleOnline1Context())
////    {
////        var category = context.Categories.Find(id);
////        return category != null;
////    }
////}
//public bool IsCategoryIdExists(int categoryId)
//{
//    var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
//    return category != null;
//}

////public List<Category> GetCategories()
////{
////    using (var context = new SaleOnline1Context())
////    {
////        return context.Categories.ToList();
////    }
////}
//public List<Category> GetCategories()
//{
//    return _context.Categories.ToList();
//}
////public Category GetCategoryById(int id)
////{
////    using (var context = new SaleOnline1Context())
////    {
////        return context.Categories.FirstOrDefault(c => c.CategoryId == id);
////    }
////}
//public Category GetCategoryById(int id)
//{
//    return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
//}

////public List<Category> SearchResults(string filter)
////{
////    var allCategories = GetCategories();
////    return allCategories.Where(c => c.CategoryName.Contains(filter)).ToList();
////}
////public List<Category> SearchResults(string filter)
////{
////    var allCategories = GetCategories();
////    return allCategories.Where(c => c.CategoryName.Contains(filter)).ToList();
////}
//public List<Category> SearchResults(string filter)
//{
//    return _context.Categories.Where(c => c.CategoryName.Contains(filter)).ToList();
//}

////public bool CreateCategory(Category category)
////{
////    if (string.IsNullOrEmpty(category.CategoryName) && string.IsNullOrEmpty(category.Filter))
////    {
////        return false;
////    }
////    else
////    {
////        using (var context = new SaleOnline1Context())
////        {
////            // Kiểm tra xem CategoryId đã tồn tại trong cơ sở dữ liệu chưa
////            if (!IsCategoryIdExists(category.CategoryId))
////            {
////                context.Categories.Add(category);
////                context.SaveChanges();
////                return true;
////            }
////            else
////            {
////                // Xử lý trường hợp CategoryId đã tồn tại trong cơ sở dữ liệu
////                return false;
////            }
////        }
////    }
////}
////public bool CreateCategory(Category category)
////{
////    if (string.IsNullOrEmpty(category.CategoryName) && string.IsNullOrEmpty(category.Filter))
////    {
////        return false;
////    }
////    else
////    {
////        using (var context = new SaleOnline1Context())
////        {
////            // Kiểm tra xem CategoryId đã tồn tại trong cơ sở dữ liệu chưa
////            if (!IsCategoryIdExists(category.CategoryId))
////            {
////                context.Categories.Add(category);
////                context.SaveChanges();
////                return true;
////            }
////            else
////            {
////                // Xử lý trường hợp CategoryId đã tồn tại trong cơ sở dữ liệu
////                return false;
////            }
////        }
////    }
////}
//public bool CreateCategory(Category category)
//{
//    if (string.IsNullOrEmpty(category.CategoryName) && string.IsNullOrEmpty(category.Filter))
//    {
//        return false;
//    }
//    else
//    {
//        // Kiểm tra xem CategoryId đã tồn tại trong cơ sở dữ liệu chưa
//        if (!IsCategoryIdExists(category.CategoryId))
//        {
//            _context.Categories.Add(category);
//            _context.SaveChanges();
//            return true;
//        }
//        else
//        {
//            // Xử lý trường hợp CategoryId đã tồn tại trong cơ sở dữ liệu
//            return false;
//        }
//    }
//}
////public void Update(int id, string categoryName, string filter, bool isActive)
////{
////    var allCategories = GetCategories();
////    var category = allCategories.FirstOrDefault(c => c.CategoryId == id);
////    if (category != null)
////    {
////        category.CategoryName = categoryName;
////        category.Filter = filter;
////        category.IsActive = isActive;
////        using (var context = new SaleOnline1Context())
////        {
////            context.Entry(category).State = EntityState.Modified;
////            context.SaveChanges();
////        }
////    }
////}
////public void Update(int id, string categoryName, string filter, bool isActive)
////{
////    var allCategories = GetCategories();
////    var category = allCategories.FirstOrDefault(c => c.CategoryId == id);
////    if (category != null)
////    {
////        category.CategoryName = categoryName;
////        category.Filter = filter;
////        category.IsActive = isActive;
////        _context.Entry(category).State = EntityState.Modified;
////        _context.SaveChanges();
////    }
////}
//public void Update(int id, string categoryName, string filter, bool isActive)
//{
//    var category = _context.Categories.Find(id);
//    if (category != null)
//    {
//        category.CategoryName = categoryName;
//        category.Filter = filter;
//        category.IsActive = isActive;
//        _context.Entry(category).State = EntityState.Modified;
//        _context.SaveChanges();
//    }
//}

////public void Delete(int id)
////{
////    var allCategories = GetCategories();
////    var category = allCategories.FirstOrDefault(c => c.CategoryId == id);
////    if (category != null && !category.IsActive)
////    {
////        using (var context = new SaleOnline1Context())
////        {
////            context.Categories.Remove(category);
////            context.SaveChanges();
////        }
////    }
////}
//public void Delete(int id)
//{
//    var allCategories = GetCategories();
//    var category = allCategories.FirstOrDefault(c => c.CategoryId == id);
//    if (category != null && !category.IsActive)
//    {
//        _context.Categories.Remove(category);
//        _context.SaveChanges();
//    }
//}
