using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.DataAccess.Admin
{
    class UserManagementDataContext : DataContextBase
    {
        [Function(Name = "dbo.P_GET_ALL_USER")]
        public ISingleResult<UserEntity> P_GET_ALL_USER()
        {
            var result = ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod());
            return ((ISingleResult<UserEntity>)(result.ReturnValue));
        }

        [Function(Name = "dbo.P_GET_ALL_ROLES")]
        public ISingleResult<RoleEntity> P_GET_ALL_ROLES()
        {
            var result = ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod());
            return ((ISingleResult<RoleEntity>)(result.ReturnValue));
        }

        [Function(Name = "dbo.P_GET_USER_BY_ID")]
        public ISingleResult<UserEntity> P_GET_USER_BY_ID(
            [ParameterAttribute(Name = "USER_ID", DbType = "int")] int uSER_ID)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), uSER_ID);
            return ((ISingleResult<UserEntity>)(result.ReturnValue));
        }

        [Function(Name = "dbo.P_DELETE_USER_BY_ID")]
        public int P_DELETE_USER_BY_ID(
            [ParameterAttribute(Name = "ID", DbType = "int")] int uSER_ID)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), uSER_ID);
            return ((int)(result.ReturnValue));
        } 

        [Function(Name = "dbo.P_GET_ROLE_BY_USER_ID")]
        public ISingleResult<UserRoleEntity> P_GET_ROLE_BY_USER_ID(
            [ParameterAttribute(Name = "USER_ID", DbType = "int")] int userId)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId);
            return ((ISingleResult<UserRoleEntity>)(result.ReturnValue));
        }

        [Function(Name = "dbo.P_GET_FUNCTION_BY_ROLE_CODE")]
        public ISingleResult<FunctionEntity> P_GET_FUNCTION_BY_ROLE_CODE(
            [ParameterAttribute(Name = "ROLE_CODE", DbType = "VARCHAR(50)")] string roleCode)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), roleCode);
            return ((ISingleResult<FunctionEntity>)(result.ReturnValue));
        }

    }
}
