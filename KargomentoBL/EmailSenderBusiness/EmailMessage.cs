using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoBL.EmailSenderBusiness
{
    public class EmailMessage
    {
        public string[] To { get; set; } //kime
        public string Subject { get; set; } //konu
        public string Body { get; set; } //içerik
        public string[] CC { get; set; }
        public string[] BCC { get; set; }

    }
}
