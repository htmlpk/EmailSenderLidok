using System;
using System.Net;
using System.Net.Mail;

namespace EmailSender.EmailHandler
{
    public class SendEmail
    {
        public void Send(string to, string subject, string body, string from = "ffv438@gmail.com")
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("ffv438@gmail.com", "shkiper626"),
                EnableSsl = true
            };
            client.Send(from, to, subject, body);
        }
    }
}
