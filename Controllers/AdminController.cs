using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: /Admin
        public ActionResult Index()
        {
            return View();
        }

        // --- 商品管理 ---

        // GET: /Admin/Products
        public ActionResult Products(int? page)
        {
            // TODO: 查詢所有商品
            return View();
        }

        // GET: /Admin/ProductEdit/5
        public ActionResult ProductEdit(int? id)
        {
            // TODO: 查詢商品（id=null 為新增）
            return View();
        }

        // POST: /Admin/ProductEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(Product model)
        {
            if (!ModelState.IsValid) return View(model);
            // TODO: 儲存商品資料
            return RedirectToAction("Products");
        }

        // --- 訂單管理 ---

        // GET: /Admin/Orders
        public ActionResult Orders(string status, int? page)
        {
            // TODO: 查詢所有訂單
            return View();
        }

        // GET: /Admin/OrderDetail/5
        public ActionResult OrderDetail(int id)
        {
            // TODO: 查詢訂單詳細
            return View();
        }

        // POST: /Admin/UpdateOrderStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOrderStatus(int id, string status)
        {
            // TODO: 更新訂單狀態
            return RedirectToAction("OrderDetail", new { id = id });
        }

        // --- 會員管理 ---

        // GET: /Admin/Members
        public ActionResult Members(int? page)
        {
            // TODO: 查詢所有會員
            return View();
        }

        // --- 部落格管理 ---

        // GET: /Admin/Blogs
        public ActionResult Blogs(int? page)
        {
            return View();
        }

        // GET: /Admin/BlogEdit/5
        public ActionResult BlogEdit(int? id)
        {
            return View();
        }

        // POST: /Admin/BlogEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BlogEdit(BlogPost model)
        {
            if (!ModelState.IsValid) return View(model);
            // TODO: 儲存文章
            return RedirectToAction("Blogs");
        }
    }
}
