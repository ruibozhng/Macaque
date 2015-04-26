using Macaque.Base.BusinessComponent.Admin;
using Macaque.Base.BusinessComponent.Code;
using Macaque.Base.BusinessContract;
using Macaque.Base.BusinessEntity;
using Macaque.Common.BusinessComponent.AppCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessService.Admin
{
    public class UserManagementService : IUserManagement
    {
        private readonly UserManagementBC userBC = new UserManagementBC();
        private readonly CodeManagementBC codeBC = new CodeManagementBC();

        public List<UserEntity> GetAllUser()
        {
            var result = userBC.GetAllUser();
            return result;
        }

        public List<RoleEntity> GetAllRoles()
        {
            var result = userBC.GetAllRoles();
            return result;
        }

        public List<CodeEntity> GetAllGrades()
        {
            //var key = string.Concat("CodeManagementBC.GetCodesByCategory.", "GRADESS");
            //List<CodeEntity> l = new List<CodeEntity>();
            //if (AppCache.Contains<List<CodeEntity>>(key) != true)
            //    AppCache.Add<List<CodeEntity>>(key, l);

            //return AppCache.GetValue<List<CodeEntity>>(key);

            var result = codeBC.GetCodesByCategory(Constants.GRADES);
            return result;
        }

        public UserEntity GetUserByID(int userID)
        {
            var result = userBC.GetUserByID(userID);
            List<UserRoleEntity> roles = userBC.GetRoleByUserID(userID);
            //List<FunctionEntity> functions = new List<FunctionEntity>();
            //foreach (var role in roles)
            //{
            //    List<FunctionEntity> f = userManagementBC.GetFunctionByRoleCode(role.RoleCode);
            //    functions.AddRange(f);
            //}
            result.UserAllRoles = roles.Where( x => x.IsDeleted == false).Select(m => m.RoleCode).ToList();
            //result.UserAllFunctions = functions;
            return result;
        }

        public void DeleteUserByID(int userID)
        {
            userBC.DeleteUserByID(userID);
        }

        public void SaveUserInfo(UserEntity userEntity, string userId)
        {
            userBC.SaveUserInfo(userEntity, userId);
            if (userEntity.UserAllRoles != null)
            {
                List<UserRoleEntity> roles = userBC.GetRoleByUserID(userEntity.ID);
                foreach (var item in roles)
                {
                    if (!userEntity.UserAllRoles.Contains(item.RoleCode))
                    {
                        item.IsDeleted = true;
                        userBC.SaveUserRoleInfo(item, userId);
                    }
                }
                foreach (var item in userEntity.UserAllRoles)
                {
                    if (!roles.Select(m => m.RoleCode).ToList().Contains(item))
                    {
                        UserRoleEntity ur = new UserRoleEntity() { UserID = userEntity.ID, RoleCode = item };
                        userBC.SaveUserRoleInfo(ur, userId);
                    }
                    else if (roles.Where(x=> x.IsDeleted == true).Select(m => m.RoleCode).ToList().Contains(item))
                    {
                        UserRoleEntity ur = roles.FirstOrDefault(x => x.RoleCode == item);
                        ur.IsDeleted = false;
                        userBC.SaveUserRoleInfo(ur, userId);
                    }
                }
            }
        }        
    }
}
