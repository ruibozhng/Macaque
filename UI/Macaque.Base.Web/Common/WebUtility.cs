using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Macaque.Base.Web.Common
{
    public class WebUtility
    {
        public static void SetUserSession(UserInfo userInfo)
        {
            SessionManager.Add<UserInfo>(WebConstant.SessionKey.UserInfo, userInfo);

            //ApplicationContext.Current.ServerHostName = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            //ApplicationContext.Current.ClientHostName = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //ApplicationContext.Current.PageObjectName = HttpContext.Current.Request.Url.AbsolutePath;
            //ApplicationContext.Current.ApplicationId = "POP";
            //ApplicationContext.Current.UserId = userInfo.UserId;
            //ApplicationContext.Current.SessionId = SessionManager.ID;
        }

        public static UserInfo GetUser()
        {
            try
            {
                if (SessionManager.ContainsKey<UserInfo>(WebConstant.SessionKey.UserInfo))
                    return SessionManager.GetValue<UserInfo>(WebConstant.SessionKey.UserInfo);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}