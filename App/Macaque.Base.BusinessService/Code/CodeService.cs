using Macaque.Base.BusinessComponent.Code;
using Macaque.Base.BusinessContract;
using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessService.Code
{
    public class CodeService : ICodeManagement
    {
        private readonly CodeManagementBC codeBC = new CodeManagementBC();

        public List<CodeEntity> GetAllGrades()
        {
            var result = codeBC.GetCodesByCategory(Constants.GRADES);
            return result;
        }

    }
}
