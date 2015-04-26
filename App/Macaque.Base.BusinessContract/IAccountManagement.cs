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
    public interface IAccountManagement
    {
        [OperationContract]
        bool ValidateUser(string userName, string password);

        [OperationContract]
        string[] GetUserRolesByUserId(string userId);

        [OperationContract]
        UserEntity GetUserByUserId(string userId);

        [OperationContract]
        void ForgotPassword(string userId);
    }
}
