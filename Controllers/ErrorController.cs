using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class ErrorController : Controller
    {
        // customErrors defaultRedirect="/Error" 的目標
        public ActionResult Index()
        {
            Response.StatusCode = 500;
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
