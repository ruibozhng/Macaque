using Macaque.Base.BusinessComponent.Common;
using Macaque.Base.BusinessEntity;
using Macaque.Base.DataAccess.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessComponent.Account
{
    public class AccountManagementBC : BusinessComponentBase
    {
        private static AccountManagementBC Instance { get; set; }

        public static AccountManagementBC GetInstance()
        {
            return Instance ?? (Instance = new AccountManagementBC());
        }

        public UserEntity GetUserByNamePWD(string userName, string password)
        {
            var result = AccountManagementDA.GetUserByNamePWD(userName, password);
            return result;
        }

        public UserEntity GetUserByUserId(string userId)
        {
            return AccountManagementDA.GetUserByUserId(userId);
        }

        public void ForgotPassword(string userId)
        {
            UserEntity user = AccountManagementDA.GetUserByUserId(userId);
            InterfaceBC.GetInstance().SendEmail("receive@abc.com", "Password Reset", user.Password, "");        
        }
    }
}
