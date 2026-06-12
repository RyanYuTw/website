Imports System.ComponentModel.DataAnnotations

Namespace My.Models

    Public Class Order
        Public Property Id As Integer
        Public Property OrderNo As String
        Public Property MemberId As Integer
        Public Property Member As Member
        Public Property OrderDate As Date
        <Required>
        Public Property ReceiverName As String
        <Required>
        Public Property ReceiverPhone As String
        <Required>
        Public Property ReceiverAddress As String
        Public Property ReceiverEmail As String
        Public Property TotalAmount As Decimal
        Public Property ShippingFee As Decimal
        Public Property PaymentMethod As String
        ' Pending=待付款, Paid=已付款, Shipped=已出貨, Completed=完成, Cancelled=取消
        Public Property Status As String
        Public Property Remark As String
        Public Property CreatedAt As Date
        Public Property UpdatedAt As Date
        Public Property Items As ICollection(Of OrderItem)
    End Class

    Public Class OrderItem
        Public Property Id As Integer
        Public Property OrderId As Integer
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property UnitPrice As Decimal
        Public Property Quantity As Integer
        Public ReadOnly Property SubTotal As Decimal
            Get
                Return UnitPrice * Quantity
            End Get
        End Property
    End Class

    Public Class OrderListViewModel
        Public Property Orders As IEnumerable(Of Order)
        Public Property TotalCount As Integer
        Public Property PageIndex As Integer
        Public Property PageSize As Integer
        Public Property StatusFilter As String
    End Class

End Namespace
