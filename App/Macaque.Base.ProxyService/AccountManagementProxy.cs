using Macaque.Base.BusinessContract;
using Macaque.Base.BusinessEntity;
using Macaque.Common.BusinessComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.ProxyService
{
    public class AccountManagementProxy : ServiceProxyBase<IAccountManagement>, IAccountManagement
    {
        protected AccountManagementProxy(string endPointName)
            : base(endPointName)
        {
        }

        public AccountManagementProxy()
            : base(typeof(IAccountManagement).ToString())
        {
            base.WrapObject(new AccountManagementProxy(typeof(IAccountManagement).ToString()));
        }

        static AccountManagementProxy Instance { get; set; }

        public static AccountManagementProxy GetInstance()
        {
            return Instance ?? (Instance = new AccountManagementProxy());
        }

        public bool ValidateUser(string userName, string password)
        {
            return Proxy.ValidateUser(userName, password);
        }

        public string[] GetUserRolesByUserId(string userId)
        {
            return Proxy.GetUserRolesByUserId(userId);
        }

        public UserEntity GetUserByUserId(string userId)
        {
            return Proxy.GetUserByUserId(userId);
        }

        public void ForgotPassword(string userId)
        {
            Proxy.ForgotPassword(userId);
        }
    }
}
