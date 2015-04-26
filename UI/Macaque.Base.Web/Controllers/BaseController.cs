using Macaque.Base.BusinessEntity;
using Macaque.Base.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Macaque.Base.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        //protected SystemIdentity Identity
        //{
        //    get
        //    {
        //        return HttpContext.User.Identity as SystemIdentity;
        //    }
        //}

        //private string functionCode { get; set; }

        //protected string requestUrl { get; set; }

        //public BaseController()
        //{
        //    functionCode = FunctionCode.FN_DEFAULT.ToString();
        //}

        //public BaseController(FunctionCode functionCode)
        //{
        //    if (functionCode != FunctionCode.FN_OTHERS)
        //        this.functionCode = functionCode.ToString();
        //}

        //protected override void Initialize(RequestContext requestContext)
        //{
        //    var user = WebUtility.GetUser();

        //    if (user != null)
        //    {
        //        if (functionCode != null)
        //        {
        //            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
        //            {
        //                requestUrl = requestContext.HttpContext.Request.Url.AbsoluteUri;
        //                ViewBag.UserInfo = user;
        //                CheckUserAccess(functionCode, true);
        //            }
        //        }
        //    }

        //    base.Initialize(requestContext);
        //}

        //protected bool CheckUserAccess(FunctionCode functionCode)
        //{
        //    return CheckUserAccess(functionCode.ToString(), true);
        //}

        //protected bool CheckUserAccess(string functionCode, bool throwError)
        //{
        //    var result = false;
        //    var user = WebUtility.GetUser();

        //    if (user != null && functionCode.Equals(FunctionCode.FN_DEFAULT.ToString()))
        //        result = true;
        //    else if (user != null)
        //        result = user.GetFunctionsForUser().Contains(functionCode);

        //    if (result != true && throwError && string.IsNullOrEmpty(requestUrl))
        //        RedirectToActionPermanent("Index", "Home");

        //    if (result != true && throwError)
        //        WebUtility.ThrowException(string.Format(@"""{0}""<br/>{1}<br/>{2} - {3}",
        //            requestUrl, WebUtility.GetErrorMessage(ErrorCode.ECMAC01),
        //            user != null ? user.UserId : string.Empty,
        //            user != null ? string.Join(",", user.GetRolesForUser()) : string.Empty));

        //    return result;
        //}
    }
}
