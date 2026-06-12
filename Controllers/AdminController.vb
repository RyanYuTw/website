Imports System.Web.Mvc
Imports My.Models

Namespace My.Controllers
    <Authorize(Roles:="Admin")>
    Public Class AdminController
        Inherits Controller

        ' GET: /Admin
        Function Index() As ActionResult
            Return View()
        End Function

        ' --- 商品管理 ---

        ' GET: /Admin/Products
        Function Products(page As Integer?) As ActionResult
            ' TODO: 查詢所有商品
            Return View()
        End Function

        ' GET: /Admin/ProductEdit/5
        Function ProductEdit(id As Integer?) As ActionResult
            ' TODO: 查詢商品（id=Nothing 為新增）
            Return View()
        End Function

        ' POST: /Admin/ProductEdit
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function ProductEdit(model As Product) As ActionResult
            If Not ModelState.IsValid Then Return View(model)
            ' TODO: 儲存商品資料
            Return RedirectToAction("Products")
        End Function

        ' --- 訂單管理 ---

        ' GET: /Admin/Orders
        Function Orders(status As String, page As Integer?) As ActionResult
            ' TODO: 查詢所有訂單
            Return View()
        End Function

        ' GET: /Admin/OrderDetail/5
        Function OrderDetail(id As Integer) As ActionResult
            ' TODO: 查詢訂單詳細
            Return View()
        End Function

        ' POST: /Admin/UpdateOrderStatus
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function UpdateOrderStatus(id As Integer, status As String) As ActionResult
            ' TODO: 更新訂單狀態
            Return RedirectToAction("OrderDetail", New With {.id = id})
        End Function

        ' --- 會員管理 ---

        ' GET: /Admin/Members
        Function Members(page As Integer?) As ActionResult
            ' TODO: 查詢所有會員
            Return View()
        End Function

        ' --- 部落格管理 ---

        ' GET: /Admin/Blogs
        Function Blogs(page As Integer?) As ActionResult
            Return View()
        End Function

        ' GET: /Admin/BlogEdit/5
        Function BlogEdit(id As Integer?) As ActionResult
            Return View()
        End Function

        ' POST: /Admin/BlogEdit
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function BlogEdit(model As BlogPost) As ActionResult
            If Not ModelState.IsValid Then Return View(model)
            ' TODO: 儲存文章
            Return RedirectToAction("Blogs")
        End Function

    End Class
End Namespace
