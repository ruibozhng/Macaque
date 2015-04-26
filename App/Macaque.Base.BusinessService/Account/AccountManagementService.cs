using Macaque.Base.BusinessComponent.Account;
using Macaque.Base.BusinessComponent.Admin;
using Macaque.Base.BusinessContract;
using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessService.Account
{
    public class AccountManagementService : IAccountManagement
    {
        private readonly AccountManagementBC accountBC = new AccountManagementBC();
        private readonly UserManagementBC userBC = new UserManagementBC();

        public bool ValidateUser(string userName, string password)
        {
            var result = accountBC.GetUserByNamePWD(userName, password);

            return result == null ? false : true;
        }

        public string[] GetUserRolesByUserId(string userName)
        {
            List<UserRoleEntity> list = new List<UserRoleEntity>();
            var user = accountBC.GetUserByUserId(userName);

            if (user != null)
            {
                list = userBC.GetRoleByUserID(user.ID);
            }
            string[] roles = list.Select(x => x.RoleCode).ToArray();
            return roles;
        }

        public UserEntity GetUserByUserId(string userId)
        {
            return accountBC.GetUserByUserId(userId);
        }

        public void ForgotPassword(string userId)
        {
            accountBC.ForgotPassword(userId);
        }
    }
}
