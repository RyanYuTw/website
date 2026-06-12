using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "標題為必填")]
        [StringLength(200)]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public BlogCategory Category { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public int ViewCount { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Tags { get; set; }
    }

    public class BlogCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class BlogListViewModel
    {
        public IEnumerable<BlogPost> Posts { get; set; }
        public IEnumerable<BlogCategory> Categories { get; set; }
        public int? CurrentCategoryId { get; set; }
        public string SearchKeyword { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
