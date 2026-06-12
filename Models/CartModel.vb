Imports System.ComponentModel.DataAnnotations

Namespace My.Models

    Public Class CartItem
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property ImagePath As String
        Public Property UnitPrice As Decimal
        Public Property Quantity As Integer
        Public ReadOnly Property SubTotal As Decimal
            Get
                Return UnitPrice * Quantity
            End Get
        End Property
    End Class

    Public Class CartViewModel
        Public Property Items As List(Of CartItem)
        Public ReadOnly Property TotalAmount As Decimal
            Get
                If Items Is Nothing Then Return 0
                Return Items.Sum(Function(x) x.SubTotal)
            End Get
        End Property
        Public ReadOnly Property TotalQty As Integer
            Get
                If Items Is Nothing Then Return 0
                Return Items.Sum(Function(x) x.Quantity)
            End Get
        End Property
    End Class

    Public Class CheckoutViewModel
        Public Property Cart As CartViewModel
        <Required(ErrorMessage:="收件人姓名為必填")>
        Public Property ReceiverName As String
        <Required(ErrorMessage:="收件人電話為必填")>
        Public Property ReceiverPhone As String
        <Required(ErrorMessage:="收件地址為必填")>
        Public Property ReceiverAddress As String
        Public Property ReceiverEmail As String
        <Required(ErrorMessage:="請選擇付款方式")>
        Public Property PaymentMethod As String
        Public Property Remark As String
    End Class

End Namespace
