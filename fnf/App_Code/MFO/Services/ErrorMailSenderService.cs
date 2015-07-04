using System;
using System.Web;
using System.Net;
using System.Net.Mail;
using MFO.Utils;

namespace MFO.services
{
    public static class ErrorMailSenderService
    {

        public static void SendMail(string from, string to, string subject,
        string body)
        {
            SmtpClient mailClient = new SmtpClient(ConfigUtil.MailServer);
            mailClient.Credentials = new NetworkCredential(ConfigUtil.MailUsername, ConfigUtil.MailPassword);
            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            mailClient.Send(mailMessage);
        }

        public static void MailErroInfo(string err)
        {
            if (ConfigUtil.EnableErrorLogEmail)
            {
                string from = ConfigUtil.MailFrom;
                string to = ConfigUtil.ErrorLogEmail;
                string subject = "MegaFactory Error Report";
                string body = err;
                SendMail(from, to, subject, body);
            }
        }

    }
}