Imports System.Security.Cryptography
Imports System.Text

Namespace My.Helpers
    Public Class CryptoHelper
        Private Shared ReadOnly Key As String = System.Web.Configuration.WebConfigurationManager.AppSettings("EncryptKey")

        Public Shared Function Encrypt(plainText As String) As String
            Using md5 = MD5.Create()
                Dim inputBytes = Encoding.UTF8.GetBytes(Key & plainText)
                Dim hashBytes = md5.ComputeHash(inputBytes)
                Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
            End Using
        End Function

        Public Shared Function Verify(plainText As String, hash As String) As Boolean
            Return Encrypt(plainText) = hash
        End Function
    End Class
End Namespace
