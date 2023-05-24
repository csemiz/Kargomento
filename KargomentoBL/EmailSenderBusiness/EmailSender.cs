using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace KargomentoBL.EmailSenderBusiness
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string SenderMail => _configuration.GetSection("EmailOptions:SenderMail").Value;

        //public string SenderMail => "";
        public string Password => _configuration.GetSection("EmailOptions:Password").Value;
        public string Smtp => _configuration.GetSection("EmailOptions:Smtp").Value;
        public int SmtpPort => Convert.ToInt32(_configuration.GetSection("EmailOptions:SmtpPort").Value);

        public string CCManagers => _configuration.GetSection("ProjectManagersEmails").Value;

        private void MailInfoSet(EmailMessage message, out MailMessage mail,
            out SmtpClient client)
        {
            try
            {
                mail = new MailMessage()
                {
                    From = new MailAddress(SenderMail) // sınıfın/projenin emaili
                };

                //to'yu ekleyelim
                foreach (var item in message.To)
                {
                    mail.To.Add(item);
                }
                if (message.CC != null)
                {
                    foreach (var item in message.CC)
                    {
                        mail.CC.Add(item);
                    }
                }
                if (message.BCC != null)
                {
                    foreach (var item in message.BCC)
                    {
                        mail.Bcc.Add(item);
                    }
                }

                if (CCManagers != null && CCManagers.Length > 0)
                {
                    foreach (var item in CCManagers.Split(","))
                    {
                        mail.CC.Add(item);
                    }
                }


                mail.Subject = message.Subject;
                mail.Body = message.Body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;

                client = new SmtpClient(Smtp, SmtpPort)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(SenderMail, Password) // emaile girebilmek için kullanıcı adı ve parolası gerekli
                };

            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool SendEmail(EmailMessage message)
        {
            try
            {
                MailInfoSet(message, out MailMessage mail, out SmtpClient client);
                client.Send(mail);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            try
            {
                MailInfoSet(message, out MailMessage mail, out SmtpClient client);
                await client.SendMailAsync(mail);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
