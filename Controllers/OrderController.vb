Imports System.Web.Mvc
Imports My.Models

Namespace My.Controllers
    <Authorize>
    Public Class OrderController
        Inherits Controller

        ' GET: /Order
        Function Index(status As String, page As Integer?) As ActionResult
            Dim memberId = CInt(Session("MemberId"))
            Dim vm = New OrderListViewModel With {
                .PageIndex = If(page, 1),
                .PageSize = 10,
                .StatusFilter = status
            }
            ' TODO: 查詢該會員的訂單列表
            Return View(vm)
        End Function

        ' GET: /Order/Detail/5
        Function Detail(id As Integer) As ActionResult
            Dim memberId = CInt(Session("MemberId"))
            ' TODO: 查詢訂單詳細資料（需驗證為本人訂單）
            Dim order As Order = Nothing
            If order Is Nothing Then Return HttpNotFound()
            Return View(order)
        End Function

        ' POST: /Order/Cancel/5
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Cancel(id As Integer) As ActionResult
            ' TODO: 取消訂單（僅 Pending 狀態可取消）
            Return RedirectToAction("Detail", New With {.id = id})
        End Function

    End Class
End Namespace
