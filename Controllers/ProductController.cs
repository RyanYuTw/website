using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product
        public ActionResult Index(int? categoryId, string keyword, int? page)
        {
            var viewModel = new ProductListViewModel
            {
                CurrentCategoryId = categoryId,
                SearchKeyword = keyword,
                PageIndex = page ?? 1,
                PageSize = 12
            };
            // TODO: 從資料庫查詢商品列表
            return View(viewModel);
        }

        // GET: /Product/Detail/5
        public ActionResult Detail(int id)
        {
            // TODO: 從資料庫查詢商品詳細資料
            Product product = null;
            if (product == null) return HttpNotFound();
            return View(product);
        }

        // GET: /Product/Category/coffee
        public ActionResult Category(string slug)
        {
            // TODO: 依分類顯示商品
            return View();
        }
    }
}
