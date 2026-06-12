using System.Web.Mvc;
using System.Web.Security;
using MyWeb.Models;
using MyWeb.Helpers;

namespace MyWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            // TODO: 查詢資料庫驗證帳號密碼
            // var member = db.Members.FirstOrDefault(m => m.Account == model.Account);
            // if (member == null || !CryptoHelper.Verify(model.Password, member.Password)) ...
            Member member = null; // 暫定，待接資料庫

            if (member == null)
            {
                ModelState.AddModelError("", "帳號或密碼錯誤");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(member.Account, model.RememberMe);
            Session["MemberId"] = member.Id;
            Session["MemberName"] = member.Name;

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // TODO: 檢查帳號是否重複，寫入資料庫
            // var exists = db.Members.Any(m => m.Account == model.Account);
            // if (exists) ...

            ViewBag.Message = "註冊成功，請登入！";
            return RedirectToAction("Login");
        }

        // GET: /Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Profile
        [Authorize]
        public ActionResult Profile()
        {
            // TODO: 讀取會員資料
            return View();
        }

        // GET: /Account/ChangePassword
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            // TODO: 驗證舊密碼並更新新密碼
            ViewBag.Message = "密碼已成功更新！";
            return View();
        }

        // GET: /Account/ForgetPassword
        public ActionResult ForgetPassword()
        {
            return View();
        }

        // POST: /Account/ForgetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetPassword(string email)
        {
            // TODO: 寄送重設密碼 Email
            ViewBag.Message = "重設密碼連結已寄至您的信箱";
            return View();
        }
    }
}
