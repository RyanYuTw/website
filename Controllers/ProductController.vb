Imports System.Web.Mvc
Imports My.Models

Namespace My.Controllers
    Public Class ProductController
        Inherits Controller

        ' GET: /Product
        Function Index(categoryId As Integer?, keyword As String, page As Integer?) As ActionResult
            Dim viewModel As New ProductListViewModel With {
                .CurrentCategoryId = categoryId,
                .SearchKeyword = keyword,
                .PageIndex = If(page, 1),
                .PageSize = 12
            }
            ' TODO: 從資料庫查詢商品列表
            Return View(viewModel)
        End Function

        ' GET: /Product/Detail/5
        Function Detail(id As Integer) As ActionResult
            ' TODO: 從資料庫查詢商品詳細資料
            Dim product As Product = Nothing
            If product Is Nothing Then Return HttpNotFound()
            Return View(product)
        End Function

        ' GET: /Product/Category/coffee
        Function Category(slug As String) As ActionResult
            ' TODO: 依分類顯示商品
            Return View()
        End Function

    End Class
End Namespace
