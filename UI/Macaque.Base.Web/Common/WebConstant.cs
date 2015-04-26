using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Macaque.Base.Web.Common
{
    public class WebConstant
    {
        public class SessionKey
        {
            public const string Key = "Session.Key";
            public const string UserInfo = "Session.UserInfo";
            public const string MenuHtml = "Session.MenuHtml";
            public const string AdminMenuHtml = "Session.AdminMenuHtml";
            public const string MyProfileMenuHtml = "Session.MyProfileMenuHtml";
        }
    }
}