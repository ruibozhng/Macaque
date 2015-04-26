using Macaque.Base.BusinessEntity;
using Macaque.Base.DataAccess.Code;
using Macaque.Common.BusinessComponent.AppCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessComponent.Code
{
    public class CodeManagementBC
    {
        private static CodeManagementBC Instance { get; set; }

        public static CodeManagementBC GetInstance()
        {
            return Instance ?? (Instance = new CodeManagementBC());
        }

        public List<CodeEntity> GetCodesByCategory(string cat)
        {
            var key = string.Concat("CodeManagementBC.GetCodesByCategory.", cat);

            if (AppCache.Contains<List<CodeEntity>>(key) != true)
                AppCache.Add<List<CodeEntity>>(key, CodeManagementDA.GetCodesByCategory(cat));

            return AppCache.GetValue<List<CodeEntity>>(key);
        }
    }
}
