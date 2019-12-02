using System;
using System.Net;
using System.Net.Mail;

namespace AceBook.Helpers
{
    public static class EmailHelper
    {
        public static void SendEmail(string emailAddress)
        {
            MailAddress to = new MailAddress(emailAddress);
            MailAddress from = new MailAddress("acebook.noreply@gmail.com");

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Welcome!";
            message.Body = "Thank you for signing up to AceBook!";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("acebook.noreply@gmail.com", "AceBook$$$1"),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
                Console.WriteLine("sent");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
