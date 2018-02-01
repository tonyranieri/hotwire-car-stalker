using System;
using System.Net;
using System.Net.Mail;
using HotwireCarStalker.Configuration;

namespace HotwireCarStalker.Util
{
    public class Emailer
    {
        public static void Send(AppSettings config, string body)
        {
            using (var mailMessage = new MailMessage())
            using (var client = new SmtpClient(config.Email.SmtpServer, config.Email.SmtpPort))
            {
                // configure the client and send the message
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(config.Email.SmtpUser, config.Email.SmtpPassword);
                client.EnableSsl = true;

                // configure the mail message
                mailMessage.From = new MailAddress(config.Email.AlertEmailFrom);
                mailMessage.To.Insert(0, new MailAddress(config.Email.AlertEmailTo));
                mailMessage.Subject = config.Email.AlertEmailSubject;
                mailMessage.Body = body;
                // mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
        }
    }
}