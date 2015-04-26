using Macaque.Base.BusinessEntity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessComponent.Common
{
    public class CommonBC : BusinessComponentBase
    {
        private static CommonBC instance { get; set; }

        public static CommonBC GetInstance()
        {
            if (instance == null)
                instance = new CommonBC();
            return instance;
        }

        //public List<MenuEntity> GetMenuItems(string menuType)
        //{
        //    var key = string.Concat("CommonBC.GetMenuItems.", menuType);

        //    if (AppCache.Contains<List<MenuEntity>>(key) != true)
        //        AppCache.Add<List<MenuEntity>>(key, CommonDA.GetMenuByMenuType(menuType));

        //    return AppCache.GetValue<List<MenuEntity>>(key);
        //}

        public List<ParameterEntity> GetSystemParameters()
        {
            return new List<ParameterEntity>();
            //var key = "CommonBC.GetSystemParameters";

            //if (AppCache.Contains<List<ParameterEntity>>(key) != true)
            //    AppCache.Add<List<ParameterEntity>>(key, CommonDA.GetSystemParameters());

            //return AppCache.GetValue<List<ParameterEntity>>(key);
        }
    }
}
