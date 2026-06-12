Imports System.ComponentModel.DataAnnotations

Namespace My.Models

    Public Class Product
        Public Property Id As Integer
        <Required(ErrorMessage:="商品名稱為必填")>
        <StringLength(200)>
        Public Property Name As String
        Public Property NameEn As String
        Public Property CategoryId As Integer
        Public Property Category As ProductCategory
        <StringLength(2000)>
        Public Property Description As String
        Public Property Content As String
        Public Property Price As Decimal
        Public Property SalePrice As Decimal?
        Public Property Stock As Integer
        Public Property ImagePath As String
        Public Property IsActive As Boolean
        Public Property IsRecommend As Boolean
        Public Property SortOrder As Integer
        Public Property CreatedAt As Date
        Public Property UpdatedAt As Date
    End Class

    Public Class ProductCategory
        Public Property Id As Integer
        <Required>
        <StringLength(100)>
        Public Property Name As String
        Public Property NameEn As String
        Public Property ParentId As Integer?
        Public Property SortOrder As Integer
        Public Property IsActive As Boolean
        Public Property Products As ICollection(Of Product)
    End Class

    Public Class ProductListViewModel
        Public Property Products As IEnumerable(Of Product)
        Public Property Categories As IEnumerable(Of ProductCategory)
        Public Property CurrentCategoryId As Integer?
        Public Property SearchKeyword As String
        Public Property TotalCount As Integer
        Public Property PageIndex As Integer
        Public Property PageSize As Integer
    End Class

End Namespace
