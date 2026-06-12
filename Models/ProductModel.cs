using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "商品名稱為必填")]
        [StringLength(200)]
        public string Name { get; set; }
        public string NameEn { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public bool IsRecommend { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class ProductCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string NameEn { get; set; }
        public int? ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        public int? CurrentCategoryId { get; set; }
        public string SearchKeyword { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
