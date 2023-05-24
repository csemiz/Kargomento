using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoBL.EmailSenderBusiness
{
    public interface IEmailSender
    {
        bool SendEmail(EmailMessage message);
        Task SendEmailAsync(EmailMessage message);
    }
}
