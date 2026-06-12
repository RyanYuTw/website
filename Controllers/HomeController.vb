Imports System.Web.Mvc
Imports My.Models

Namespace My.Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: /
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: /Home/About
        Function About() As ActionResult
            Return View()
        End Function

        ' GET: /Home/Contact
        Function Contact() As ActionResult
            Return View()
        End Function

        ' POST: /Home/Contact
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Contact(name As String, email As String, message As String) As ActionResult
            If ModelState.IsValid Then
                ' TODO: 寄送聯絡表單 email
                ViewBag.Message = "感謝您的留言，我們將盡快與您聯絡！"
            End If
            Return View()
        End Function

    End Class
End Namespace
