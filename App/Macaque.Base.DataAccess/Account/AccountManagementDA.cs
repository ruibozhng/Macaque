using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.DataAccess.Account
{
    public class AccountManagementDA
    {
        /// <summary>
        /// Get user by user name and password
        /// </summary>
        /// <returns></returns>
        public static UserEntity GetUserByNamePWD(string userName, string password)
        {
            using (var db = new AccountManagementDataContext())
            {
                var result = db.P_GET_USER_BY_NAME_PWD(userName, password);
                var list = result.ToList();

                return list.Count > 0 ? list[0] : null;
            }
        }

        /// <summary>
        /// Get all user include that data is deleted
        /// </summary>
        /// <returns></returns>
        public static UserEntity GetUserByUserId(string userId)
        {
            using (var db = new AccountManagementDataContext())
            {
                var result = db.P_GET_USER_BY_USER_NAME(userId);
                var list = result.ToList();

                return list.Count > 0 ? list[0] : null;
            }
        }
    }
}
