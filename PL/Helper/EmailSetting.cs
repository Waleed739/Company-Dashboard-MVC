using DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace PL.Helper
{
    public class EmailSetting
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("waleedhammad770@gmail.com", "uvurrfzzwfhzeqvp");
            client.Send("waleedhammad770@gmail.com", email.To, email.Title, email.Body);

        }
    }
}
