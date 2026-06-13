using System.Linq;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        public ActionResult Index()
        {
            using (var db = new AppDbContext())
            {
                ViewBag.FeaturedProducts = db.Products
                    .Where(p => p.IsActive && p.IsRecommend)
                    .OrderBy(p => p.SortOrder)
                    .Take(4)
                    .ToList();

                ViewBag.LatestPosts = db.BlogPosts
                    .Where(p => p.IsPublished)
                    .OrderByDescending(p => p.PublishedAt)
                    .Take(3)
                    .ToList();
            }
            return View();
        }

        // GET: /Home/About
        public ActionResult About()
        {
            return View();
        }

        // GET: /Home/Contact
        public ActionResult Contact()
        {
            return View();
        }

        // POST: /Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(string name, string email, string message)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "感謝您的留言，我們將盡快與您聯絡！";
            }
            return View();
        }
    }
}
