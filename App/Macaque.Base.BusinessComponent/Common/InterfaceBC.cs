using Macaque.Base.BusinessEntity;
using Macaque.Common.BusinessComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessComponent.Common
{
    public class InterfaceBC
    {
        private static InterfaceBC instance { get; set; }

        public static InterfaceBC GetInstance()
        {
            if (instance == null)
                instance = new InterfaceBC();
            return instance;
        }

        public void SendEmail(string sendToEmailAddress, string subject, string message, string sender)
        {
            string senderEmail = AppUtility.GetAppSetting(Constant.EMAIL_SENDER);
            var emailServer = new SendEmailHelper(senderEmail);
            emailServer.SendEmail(sendToEmailAddress, subject, message);

        }
    }
}
