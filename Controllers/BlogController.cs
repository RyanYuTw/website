using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class BlogController : Controller
    {
        // GET: /Blog
        public ActionResult Index(int? categoryId, string keyword, int? page)
        {
            var vm = new BlogListViewModel
            {
                CurrentCategoryId = categoryId,
                SearchKeyword = keyword,
                PageIndex = page ?? 1,
                PageSize = 9
            };
            // TODO: 查詢文章列表
            return View(vm);
        }

        // GET: /Blog/Post/5
        public ActionResult Post(int id)
        {
            // TODO: 查詢文章詳細內容
            BlogPost blogPost = null;
            if (blogPost == null) return HttpNotFound();
            return View(blogPost);
        }
    }
}
