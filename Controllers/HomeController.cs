using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        public ActionResult Index()
        {
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
                // TODO: 寄送聯絡表單 email
                ViewBag.Message = "感謝您的留言，我們將盡快與您聯絡！";
            }
            return View();
        }
    }
}
