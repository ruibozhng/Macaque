using Macaque.Base.ProxyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Macaque.Base.Web.Common
{
    [Serializable]
    public class UserInfo
    {
        public UserInfo()
        {
        }

        public UserInfo(int id)
        {
            var data = UserManagementProxy.GetInstance().GetUserByID(id);

            UserId = data.UserID;
            UserName = data.UserName;
            //Roles = data.UserAllRoles;
            //Functions = data.UserAllFunctions;
        }

        public UserInfo(string userId)
        {
            var data = AccountManagementProxy.GetInstance().GetUserByUserId(userId);

            UserId = data.UserID;
            UserName = data.UserName;
            //Roles = data.UserAllRoles;
            //Functions = data.UserAllFunctions;
        }

        public int ID { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public bool AccountIsLocked { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool PasswordIsExpired { get; set; }

        private List<string> Roles { get; set; }

        public List<string> GetRolesForUser()
        {
            Roles.Sort();
            return Roles;
        }

        private List<string> Functions { get; set; }

        public List<string> GetFunctionsForUser()
        {
            Functions.Sort();
            return Functions;
        }
    }
}