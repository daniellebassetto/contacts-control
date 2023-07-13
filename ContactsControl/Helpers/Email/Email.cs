using System.Net;
using System.Net.Mail;

namespace ContactsControl.Helpers
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(string email, string subject, string message)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string name = _configuration.GetValue<string>("SMTP:Name");
                string userName = _configuration.GetValue<string>("SMTP:UserName");
                string password = _configuration.GetValue<string>("SMTP:Password");
                int port = _configuration.GetValue<int>("SMTP:Port");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(userName, name)
                };

                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(userName, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
    }
}