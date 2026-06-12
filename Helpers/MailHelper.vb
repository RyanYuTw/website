Imports System.Net.Mail
Imports System.Web.Configuration

Namespace My.Helpers
    Public Class MailHelper
        Public Shared Sub SendMail(toAddress As String, subject As String, body As String)
            Dim smtpHost = WebConfigurationManager.AppSettings("SmtpHost")
            Dim smtpPort = CInt(WebConfigurationManager.AppSettings("SmtpPort"))
            Dim smtpUser = WebConfigurationManager.AppSettings("SmtpUser")
            Dim smtpPass = WebConfigurationManager.AppSettings("SmtpPassword")
            Dim fromEmail = WebConfigurationManager.AppSettings("SiteEmail")
            Dim siteName = WebConfigurationManager.AppSettings("SiteName")

            Using client = New SmtpClient(smtpHost, smtpPort)
                client.Credentials = New System.Net.NetworkCredential(smtpUser, smtpPass)
                client.EnableSsl = True

                Dim mail = New MailMessage()
                mail.From = New MailAddress(fromEmail, siteName)
                mail.To.Add(toAddress)
                mail.Subject = subject
                mail.Body = body
                mail.IsBodyHtml = True

                client.Send(mail)
            End Using
        End Sub
    End Class
End Namespace
