using Macaque.Base.BusinessEntity;
using Macaque.Base.BusinessEntity.Common;
using Macaque.Base.DataAccess.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessComponent.Admin
{
    public class UserManagementBC : BusinessComponentBase
    {
        private static UserManagementBC Instance { get; set; }

        public static UserManagementBC GetInstance()
        {
            return Instance ?? (Instance = new UserManagementBC());
        }

        public List<UserEntity> GetAllUser()
        {
            var list = UserManagementDA.GetAllUser();

            return list;
        }

        public List<RoleEntity> GetAllRoles()
        {
            var list = UserManagementDA.GetAllRoles();

            return list;
        }

        public UserEntity GetUserByID(int ID)
        {
            var result = UserManagementDA.GetUserByID(ID);

            return result;
        }
        public void DeleteUserByID(int ID)
        {
            UserManagementDA.DeleteUserByID(ID);
        }

        public List<UserRoleEntity> GetRoleByUserID(int userId)
        {
            return UserManagementDA.GetRoleByUserID(userId);
        }

        public List<FunctionEntity> GetFunctionByRoleCode(string roleCode)
        {
            return UserManagementDA.GetFunctionByRoleCode(roleCode);
        }

        public void SaveUserInfo(UserEntity entity, string userId)
        {
            if (entity.ID == 0)
            {
                UpdateCommonFields(entity, UpdateActionType.Add, userId);
                UserManagementDA.SaveUserInfo(entity, true);
            }
            else
            {
                UpdateCommonFields(entity, UpdateActionType.Update, userId);
                UserManagementDA.SaveUserInfo(entity, false);
            }
        }

        public void SaveUserRoleInfo(UserRoleEntity entity, string userId)
        {
            if (entity.ID == 0)
            {
                UpdateCommonFields(entity, UpdateActionType.Add, userId);
                UserManagementDA.SaveUserRoleInfo(entity, true);
            }
            else
            {
                UpdateCommonFields(entity, UpdateActionType.Update, userId);
                UserManagementDA.SaveUserRoleInfo(entity, false);
            }
        }
        
    }
}
