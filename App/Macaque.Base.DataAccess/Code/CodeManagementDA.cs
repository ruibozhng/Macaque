using Macaque.Base.BusinessEntity;
using Macaque.Base.DataAccess.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.DataAccess.Code
{
    public class CodeManagementDA
    {
        /// <summary>
        /// Get all code enety by category name
        /// </summary>
        /// <returns></returns>
        public static List<CodeEntity> GetCodesByCategory(string category)
        {
            using (var db = new CodeManagementDataContext())
            {
                var result = db.P_GET_CODES_BY_CATEGORY(category);

                return result.ToList();
            }
        }
    }
}
