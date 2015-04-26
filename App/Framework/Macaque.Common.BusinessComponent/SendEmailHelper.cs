using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Common.BusinessComponent
{
    public class SendEmailHelper
    {
        private string appIdentifier { get; set; }

        public SendEmailHelper(string appIdentifier)
        {
            this.appIdentifier = appIdentifier;
        }

        public void SendEmail(string recipient, string subject, string message)
        {
            SmtpClient smtpClient = new SmtpClient();

            MailMessage msg = new MailMessage(appIdentifier, recipient, subject, message);
            msg.IsBodyHtml = true;

            smtpClient.Send(msg);
            smtpClient.Dispose();
        }
    }
}
