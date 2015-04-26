using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.DataAccess.Account
{
    class AccountManagementDataContext : DataContextBase
    {
        [Function(Name = "dbo.P_GET_USER_BY_NAME_PWD")]
        public ISingleResult<UserEntity> P_GET_USER_BY_NAME_PWD(
            [ParameterAttribute(Name = "USER_NAME", DbType = "VARCHAR(50)")] string userName,
            [ParameterAttribute(Name = "USER_PWD", DbType = "VARCHAR(200)")] string password)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName, password);
            return ((ISingleResult<UserEntity>)(result.ReturnValue));
        }

        [Function(Name = "dbo.P_GET_USER_BY_USER_NAME")]
        public ISingleResult<UserEntity> P_GET_USER_BY_USER_NAME(
            [ParameterAttribute(Name = "USER_NAME", DbType = "VARCHAR(50)")] string userName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName);
            return ((ISingleResult<UserEntity>)(result.ReturnValue));
        }
    }
}
