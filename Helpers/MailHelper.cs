using System.Net.Mail;
using System.Web.Configuration;

namespace MyWeb.Helpers
{
    public class MailHelper
    {
        public static void SendMail(string toAddress, string subject, string body)
        {
            string smtpHost = WebConfigurationManager.AppSettings["SmtpHost"];
            int smtpPort = int.Parse(WebConfigurationManager.AppSettings["SmtpPort"]);
            string smtpUser = WebConfigurationManager.AppSettings["SmtpUser"];
            string smtpPass = WebConfigurationManager.AppSettings["SmtpPassword"];
            string fromEmail = WebConfigurationManager.AppSettings["SiteEmail"];
            string siteName = WebConfigurationManager.AppSettings["SiteName"];

            var client = new SmtpClient();
            client.Host = smtpHost;
            client.Port = smtpPort;
            client.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
            client.EnableSsl = true;

            var mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, siteName);
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            client.Send(mail);
        }
    }
}
