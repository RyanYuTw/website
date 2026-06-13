using System.Linq;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class BlogController : Controller
    {
        // GET: /Blog
        public ActionResult Index(int? categoryId, string keyword, int? page)
        {
            int pageIndex = page ?? 1;
            const int pageSize = 9;

            using (var db = new AppDbContext())
            {
                var query = db.BlogPosts.Include("Category").Where(p => p.IsPublished);

                if (categoryId.HasValue)
                    query = query.Where(p => p.CategoryId == categoryId.Value);

                if (!string.IsNullOrWhiteSpace(keyword))
                    query = query.Where(p => p.Title.Contains(keyword) || p.Summary.Contains(keyword));

                int total = query.Count();
                var posts = query
                    .OrderByDescending(p => p.PublishedAt)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var vm = new BlogListViewModel
                {
                    Posts = posts,
                    Categories = db.BlogCategories.Where(c => c.IsActive).OrderBy(c => c.SortOrder).ToList(),
                    CurrentCategoryId = categoryId,
                    SearchKeyword = keyword,
                    TotalCount = total,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
                return View(vm);
            }
        }

        // GET: /Blog/Post/5
        public ActionResult Post(int id)
        {
            using (var db = new AppDbContext())
            {
                var post = db.BlogPosts.Include("Category").FirstOrDefault(p => p.Id == id && p.IsPublished);
                if (post == null) return HttpNotFound();

                // 更新瀏覽數
                post.ViewCount++;
                db.SaveChanges();

                return View(post);
            }
        }
    }
}
