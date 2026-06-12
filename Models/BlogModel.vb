Imports System.ComponentModel.DataAnnotations

Namespace My.Models

    Public Class BlogPost
        Public Property Id As Integer
        <Required(ErrorMessage:="標題為必填")>
        <StringLength(200)>
        Public Property Title As String
        Public Property CategoryId As Integer
        Public Property Category As BlogCategory
        Public Property Summary As String
        Public Property Content As String
        Public Property ImagePath As String
        Public Property Author As String
        Public Property ViewCount As Integer
        Public Property IsPublished As Boolean
        Public Property PublishedAt As Date?
        Public Property CreatedAt As Date
        Public Property UpdatedAt As Date
        Public Property Tags As String
    End Class

    Public Class BlogCategory
        Public Property Id As Integer
        <Required>
        <StringLength(100)>
        Public Property Name As String
        Public Property SortOrder As Integer
        Public Property IsActive As Boolean
    End Class

    Public Class BlogListViewModel
        Public Property Posts As IEnumerable(Of BlogPost)
        Public Property Categories As IEnumerable(Of BlogCategory)
        Public Property CurrentCategoryId As Integer?
        Public Property SearchKeyword As String
        Public Property TotalCount As Integer
        Public Property PageIndex As Integer
        Public Property PageSize As Integer
    End Class

End Namespace
