using Macaque.Base.BusinessEntity;
using Macaque.Base.BusinessEntity.Common;
using Macaque.Common.BusinessComponent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessComponent.Common
{
    public class AppUtility
    {
        public static string GetSystemParameter(string key)
        {
            var result = CommonBC.GetInstance().GetSystemParameters().Find(p => p.Code.Trim().Equals(key));
            if (result == null)
                ThrowException(string.Format(Constant.ERROR_SYSTEM_PARAMETER_NOT_FOUND, key));
            return result.CodeValue;
        }

        public static string GetSystemParameter(SystemParameter key)
        {
            return GetSystemParameter(key.ToString());
        }

        public static string GetErrorMessage(ErrorCode errorCode, params object[] args)
        {
            return string.Format(GetSystemParameter(errorCode.ToString()), args);
        }

        public static string GetAppSetting(string key)
        {
            string result = ConfigurationManager.AppSettings[key];
            if (result == null)
                ThrowException(string.Format(Constant.ERROR_APPSETTING_NOT_FOUND, key));
            return result;
        }

        public static void ThrowException(string error)
        {
            throw new BusinessException(error);
        }

        public static void ThrowException(ErrorCode errorCode)
        {
            ThrowException(GetSystemParameter(errorCode.ToString()));
        }
    }
}
