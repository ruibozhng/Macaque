using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Macaque.Base.Web.Models
{
    public class SystemIdentity //: IIdentity
    {
        //private readonly FormsAuthenticationTicket formTicket;
        //private UserInfo currentUserInfo = null;

        //public SystemIdentity(FormsAuthenticationTicket ticket)
        //{
        //    this.formTicket = ticket;
        //}

        //public bool IsAuthenticated
        //{
        //    get { return true; }
        //}

        //internal UserInfo CurrentUserInfo
        //{
        //    get
        //    {
        //        if (currentUserInfo == null)
        //            currentUserInfo = PWOutreachPortal.Web.Common.WebUtility.GetUser();
        //        return currentUserInfo;
        //    }
        //}

        //public string Name
        //{
        //    get {
        //        if (this.CurrentUserInfo == null) return this.UserName; 
        //        return this.CurrentUserInfo.UserId;
        //    }
        //}

        //public string UserName
        //{
        //    get { return this.formTicket.Name; }
        //}

        //public string UserData
        //{
        //    get { return this.formTicket.UserData; }
        //}
    }
}