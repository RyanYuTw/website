Imports System.Web.Mvc
Imports System.Web.Mvc.Html
Imports System.Text

Namespace My.Helpers
    Public Module PagingHelper
        <System.Runtime.CompilerServices.Extension>
        Public Function PageLinks(html As HtmlHelper,
                                  currentPage As Integer,
                                  totalPages As Integer,
                                  pageUrl As Func(Of Integer, String)) As MvcHtmlString
            Dim sb = New StringBuilder()
            sb.Append("<nav><ul class=""pagination"">")
            For i = 1 To totalPages
                Dim tag = New TagBuilder("li")
                tag.AddCssClass("page-item")
                If i = currentPage Then tag.AddCssClass("active")
                Dim link = New TagBuilder("a")
                link.AddCssClass("page-link")
                link.MergeAttribute("href", pageUrl(i))
                link.InnerHtml = i.ToString()
                tag.InnerHtml = link.ToString()
                sb.Append(tag.ToString())
            Next
            sb.Append("</ul></nav>")
            Return MvcHtmlString.Create(sb.ToString())
        End Function

        Public Function TotalPages(totalCount As Integer, pageSize As Integer) As Integer
            Return CInt(Math.Ceiling(totalCount / CDbl(pageSize)))
        End Function
    End Module
End Namespace
