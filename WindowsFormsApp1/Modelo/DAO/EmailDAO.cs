using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sushi_Time_PTC_2024.Modelo.DTO;

namespace Sushi_Time_PTC_2024.Modelo.DAO
{
    public class EmailDAO
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _alias;

        public EmailDAO(string email, string password, string alias)
        {
            _email = email;
            _password = password;
            _alias = alias;
        }
        public void SendEmail(EmailDTO emailDTO)
        {
            using (var mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_email, _alias, System.Text.Encoding.UTF8);
                mailMessage.To.Add(emailDTO.To);
                mailMessage.Subject = emailDTO.Subject;
                mailMessage.Body = emailDTO.Body;
                mailMessage.Priority = MailPriority.High;

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(_email, _password);
                    smtpClient.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                    smtpClient.Send(mailMessage);
                }
            }
        }
    }
}
