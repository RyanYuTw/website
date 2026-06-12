using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: /Order
        public ActionResult Index(string status, int? page)
        {
            var memberId = (int)Session["MemberId"];
            var vm = new OrderListViewModel
            {
                PageIndex = page ?? 1,
                PageSize = 10,
                StatusFilter = status
            };
            // TODO: 查詢該會員的訂單列表
            return View(vm);
        }

        // GET: /Order/Detail/5
        public ActionResult Detail(int id)
        {
            var memberId = (int)Session["MemberId"];
            // TODO: 查詢訂單詳細資料（需驗證為本人訂單）
            Order order = null;
            if (order == null) return HttpNotFound();
            return View(order);
        }

        // POST: /Order/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            // TODO: 取消訂單（僅 Pending 狀態可取消）
            return RedirectToAction("Detail", new { id = id });
        }
    }
}
