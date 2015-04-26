using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.DataAccess.Code
{
    public class CodeManagementDataContext : DataContextBase
    {
        [Function(Name = "dbo.P_GET_CODES_BY_CATEGORY")]
        public ISingleResult<CodeEntity> P_GET_CODES_BY_CATEGORY(
            [ParameterAttribute(Name = "CATEGORY", DbType = "VARCHAR(50)")] string category)
        {
            var result = ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), category);
            return ((ISingleResult<CodeEntity>)(result.ReturnValue));
        }
    }
}
