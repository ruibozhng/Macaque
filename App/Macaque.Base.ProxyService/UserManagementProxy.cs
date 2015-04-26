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
    public class UserManagementProxy : ServiceProxyBase<IUserManagement>, IUserManagement
    {
        protected UserManagementProxy(string endPointName)
            : base(endPointName)
        {
        }

        public UserManagementProxy()
            : base(typeof(IUserManagement).ToString())
        {
            base.WrapObject(new UserManagementProxy(typeof(IUserManagement).ToString()));
        }

        static UserManagementProxy Instance { get; set; }

        public static UserManagementProxy GetInstance()
        {
            return Instance ?? (Instance = new UserManagementProxy());
        }

        public List<UserEntity> GetAllUser()
        {
            return Proxy.GetAllUser();
        }

        public List<RoleEntity> GetAllRoles()
        {
            return Proxy.GetAllRoles();
        }

        public List<CodeEntity> GetAllGrades()
        {           
            return Proxy.GetAllGrades();
        }

        public UserEntity GetUserByID(int id)
        {
            return Proxy.GetUserByID(id);
        }

        public void DeleteUserByID(int id)
        {
            Proxy.DeleteUserByID(id);
        }

        public void SaveUserInfo(UserEntity userEntity, string userId)
        {
            Proxy.SaveUserInfo(userEntity, userId);
        }        
    }
}
