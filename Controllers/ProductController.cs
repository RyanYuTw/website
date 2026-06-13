using System.Linq;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product
        public ActionResult Index(int? categoryId, string keyword, int? page)
        {
            int pageIndex = page ?? 1;
            const int pageSize = 12;

            using (var db = new AppDbContext())
            {
                var query = db.Products.Include("Category").Where(p => p.IsActive);

                if (categoryId.HasValue)
                    query = query.Where(p => p.CategoryId == categoryId.Value);

                if (!string.IsNullOrWhiteSpace(keyword))
                    query = query.Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword));

                int total = query.Count();
                var products = query
                    .OrderBy(p => p.SortOrder)
                    .ThenByDescending(p => p.CreatedAt)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var vm = new ProductListViewModel
                {
                    Products = products,
                    Categories = db.ProductCategories.Where(c => c.IsActive).OrderBy(c => c.SortOrder).ToList(),
                    CurrentCategoryId = categoryId,
                    SearchKeyword = keyword,
                    TotalCount = total,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
                return View(vm);
            }
        }

        // GET: /Product/Detail/5
        public ActionResult Detail(int id)
        {
            using (var db = new AppDbContext())
            {
                var product = db.Products.Include("Category").FirstOrDefault(p => p.Id == id && p.IsActive);
                if (product == null) return HttpNotFound();
                return View(product);
            }
        }
    }
}
