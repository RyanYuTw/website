Imports System.Web.Mvc
Imports System.Web.Security
Imports My.Models
Imports My.Helpers

Namespace My.Controllers
    Public Class AccountController
        Inherits Controller

        ' GET: /Account/Login
        Function Login(returnUrl As String) As ActionResult
            ViewBag.ReturnUrl = returnUrl
            Return View()
        End Function

        ' POST: /Account/Login
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Login(model As LoginViewModel, returnUrl As String) As ActionResult
            If Not ModelState.IsValid Then Return View(model)

            ' TODO: 查詢資料庫驗證帳號密碼
            ' Dim encPass = CryptoHelper.Encrypt(model.Password)
            ' Dim member = db.Members.FirstOrDefault(Function(m) m.Account = model.Account AndAlso m.Password = encPass)
            Dim member As Member = Nothing ' 暫定，待接資料庫

            If member Is Nothing Then
                ModelState.AddModelError("", "帳號或密碼錯誤")
                Return View(model)
            End If

            FormsAuthentication.SetAuthCookie(member.Account, model.RememberMe)
            Session("MemberId") = member.Id
            Session("MemberName") = member.Name

            If Not String.IsNullOrEmpty(returnUrl) AndAlso Url.IsLocalUrl(returnUrl) Then
                Return Redirect(returnUrl)
            End If
            Return RedirectToAction("Index", "Home")
        End Function

        ' GET: /Account/Register
        Function Register() As ActionResult
            Return View()
        End Function

        ' POST: /Account/Register
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Register(model As RegisterViewModel) As ActionResult
            If Not ModelState.IsValid Then Return View(model)

            ' TODO: 檢查帳號是否重複，寫入資料庫
            ' Dim exists = db.Members.Any(Function(m) m.Account = model.Account)
            ' If exists Then ...

            ViewBag.Message = "註冊成功，請登入！"
            Return RedirectToAction("Login")
        End Function

        ' GET: /Account/Logout
        Function Logout() As ActionResult
            FormsAuthentication.SignOut()
            Session.Clear()
            Return RedirectToAction("Index", "Home")
        End Function

        ' GET: /Account/Profile
        <Authorize>
        Function Profile() As ActionResult
            ' TODO: 讀取會員資料
            Return View()
        End Function

        ' GET: /Account/ChangePassword
        <Authorize>
        Function ChangePassword() As ActionResult
            Return View()
        End Function

        ' POST: /Account/ChangePassword
        <HttpPost>
        <Authorize>
        <ValidateAntiForgeryToken>
        Function ChangePassword(model As ChangePasswordViewModel) As ActionResult
            If Not ModelState.IsValid Then Return View(model)
            ' TODO: 驗證舊密碼並更新新密碼
            ViewBag.Message = "密碼已成功更新！"
            Return View()
        End Function

        ' GET: /Account/ForgetPassword
        Function ForgetPassword() As ActionResult
            Return View()
        End Function

        ' POST: /Account/ForgetPassword
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function ForgetPassword(email As String) As ActionResult
            ' TODO: 寄送重設密碼 Email
            ViewBag.Message = "重設密碼連結已寄至您的信箱"
            Return View()
        End Function

    End Class
End Namespace
