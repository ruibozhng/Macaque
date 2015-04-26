using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.DataAccess.Admin
{
    public class UserManagementDA
    {
        /// <summary>
        /// Get all user include that data is deleted
        /// </summary>
        /// <returns></returns>
        public static List<UserEntity> GetAllUser()
        {
            using (var db = new UserManagementDataContext())
            {
                var result = db.P_GET_ALL_USER();

                return result.ToList();
            }
        }

        /// <summary>
        /// Get all user include that data is deleted
        /// </summary>
        /// <returns></returns>
        public static List<RoleEntity> GetAllRoles()
        {
            using (var db = new UserManagementDataContext())
            {
                var result = db.P_GET_ALL_ROLES();

                return result.ToList();
            }
        }        

        /// <summary>
        /// Get all user include that data is deleted
        /// </summary>
        /// <returns></returns>
        public static UserEntity GetUserByID(int ID)
        {
            using (var db = new UserManagementDataContext())
            {
                var result = db.P_GET_USER_BY_ID(ID);
                var list = result.ToList();

                return list.Count > 0 ? list[0] : null;
            }
        }

        /// <summary>
        /// insert/update data to dbo.T_USER
        /// </summary>
        /// <param name="userEntity"></param>
        /// <param name="isNew"></param>
        public static void SaveUserInfo(UserEntity userEntity, bool isNew)
        {
            using (var db = new UserManagementDataContext())
            {
                if (isNew)
                {
                    db.GetTable<UserEntity>().InsertOnSubmit(userEntity);
                }
                else
                {
                    db.GetTable<UserEntity>().Attach(userEntity, true);
                }

                db.SubmitChanges();
            }
        }

        public static void SaveUserRoleInfo(UserRoleEntity entity, bool isNew)
        {
            using (var db = new UserManagementDataContext())
            {
                if (isNew)
                {
                    db.GetTable<UserRoleEntity>().InsertOnSubmit(entity);
                }
                else
                {
                    db.GetTable<UserRoleEntity>().Attach(entity, true);
                }

                db.SubmitChanges();
            }
        }

        public static void DeleteUserByID(int Id)
        {
            using (var db = new UserManagementDataContext())
            {
                var result = db.P_DELETE_USER_BY_ID(Id);
            }
        }

        public static List<UserRoleEntity> GetRoleByUserID(int userId)
        {
            using (var db = new UserManagementDataContext())
            {
                var result = db.P_GET_ROLE_BY_USER_ID(userId);
                return result.ToList();
            }
        }

        public static List<FunctionEntity> GetFunctionByRoleCode(string roleCode)
        {
            using (var db = new UserManagementDataContext())
            {
                var result = db.P_GET_FUNCTION_BY_ROLE_CODE(roleCode);
                return result.ToList();
            }
        }
    }
}
