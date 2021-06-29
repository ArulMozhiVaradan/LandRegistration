using LandRegistrationUI.Models.ViewModels;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace LandRegistrationUI.BusinessLogic
{
    public class Email
    {
        public static void SendMail(EmailModel model)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("projectrevenue1997@gmail.com");
                mail.To.Add(model.ToMailId);
                mail.Subject = model.Subject;
                mail.Body = model.Body;

                if (model.File != null)
                {
                    //Attachment att = new Attachment(new MemoryStream(model.File), model.FileName);
                    //mail.Attachments.Add(att);
                    mail.Attachments.Add(new Attachment(model.File, model.FileName));
                }

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