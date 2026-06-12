Imports System.Web.Mvc
Imports My.Models

Namespace My.Controllers
    Public Class BlogController
        Inherits Controller

        ' GET: /Blog
        Function Index(categoryId As Integer?, keyword As String, page As Integer?) As ActionResult
            Dim vm = New BlogListViewModel With {
                .CurrentCategoryId = categoryId,
                .SearchKeyword = keyword,
                .PageIndex = If(page, 1),
                .PageSize = 9
            }
            ' TODO: 查詢文章列表
            Return View(vm)
        End Function

        ' GET: /Blog/Post/5
        Function Post(id As Integer) As ActionResult
            ' TODO: 查詢文章詳細內容
            Dim post As BlogPost = Nothing
            If post Is Nothing Then Return HttpNotFound()
            Return View(post)
        End Function

    End Class
End Namespace
