using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessContract
{
    [ServiceContract]
    public interface IUserManagement
    {
        [OperationContract]
        List<UserEntity> GetAllUser();

        [OperationContract]
        List<RoleEntity> GetAllRoles();

        [OperationContract]
        List<CodeEntity> GetAllGrades();

        [OperationContract]
        UserEntity GetUserByID(int userID);

        [OperationContract]
        void DeleteUserByID(int userID);

        [OperationContract]
        void SaveUserInfo(UserEntity entity, string userId);     
    }
}
