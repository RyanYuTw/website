Imports System.ComponentModel.DataAnnotations

Namespace My.Models

    Public Class Member
        Public Property Id As Integer
        <Required(ErrorMessage:="帳號為必填")>
        <StringLength(50)>
        Public Property Account As String
        <Required(ErrorMessage:="密碼為必填")>
        Public Property Password As String
        <StringLength(20)>
        Public Property Name As String
        <EmailAddress(ErrorMessage:="Email 格式不正確")>
        Public Property Email As String
        <StringLength(20)>
        Public Property Phone As String
        <StringLength(20)>
        Public Property Mobile As String
        Public Property Address As String
        Public Property Birthday As Date?
        Public Property Gender As String
        ' B2B = 經銷商, B2C = 一般會員, Admin = 管理員
        Public Property Kind As String
        Public Property IsActive As Boolean
        Public Property CreatedAt As Date
        Public Property LastLoginAt As Date?
    End Class

    Public Class LoginViewModel
        <Required(ErrorMessage:="請輸入帳號")>
        Public Property Account As String
        <Required(ErrorMessage:="請輸入密碼")>
        <DataType(DataType.Password)>
        Public Property Password As String
        Public Property RememberMe As Boolean
    End Class

    Public Class RegisterViewModel
        <Required(ErrorMessage:="帳號為必填")>
        <StringLength(50, MinimumLength:=4, ErrorMessage:="帳號長度須介於 4-50 字元")>
        Public Property Account As String
        <Required(ErrorMessage:="密碼為必填")>
        <StringLength(100, MinimumLength:=6, ErrorMessage:="密碼長度須介於 6-100 字元")>
        <DataType(DataType.Password)>
        Public Property Password As String
        <Required(ErrorMessage:="請再次輸入密碼")>
        <DataType(DataType.Password)>
        <Compare("Password", ErrorMessage:="兩次密碼輸入不一致")>
        Public Property ConfirmPassword As String
        <Required(ErrorMessage:="姓名為必填")>
        Public Property Name As String
        <Required(ErrorMessage:="Email 為必填")>
        <EmailAddress(ErrorMessage:="Email 格式不正確")>
        Public Property Email As String
        <Required(ErrorMessage:="手機為必填")>
        Public Property Mobile As String
    End Class

    Public Class ChangePasswordViewModel
        <Required(ErrorMessage:="請輸入舊密碼")>
        <DataType(DataType.Password)>
        Public Property OldPassword As String
        <Required(ErrorMessage:="請輸入新密碼")>
        <StringLength(100, MinimumLength:=6)>
        <DataType(DataType.Password)>
        Public Property NewPassword As String
        <Required(ErrorMessage:="請再次輸入新密碼")>
        <DataType(DataType.Password)>
        <Compare("NewPassword", ErrorMessage:="兩次密碼輸入不一致")>
        Public Property ConfirmPassword As String
    End Class

End Namespace
