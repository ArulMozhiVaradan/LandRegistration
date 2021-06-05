using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace LandRegistrationUI.BusinessLogic
{
    public class Email
    {
        public static void SendMail(string toMailId, string subject, string body)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("projectrevenue1997@gmail.com");
                mail.To.Add(toMailId);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = Convert.ToInt32("587");
                SmtpServer.Credentials = new NetworkCredential("projectrevenue1997@gmail.com", "@#123456789");
                SmtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object es, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                SmtpServer.Send(mail);

            }
            catch (Exception)
            {

            }
        }
    }
}