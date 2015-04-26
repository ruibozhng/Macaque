using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Macaque.Base.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute("BookByPublisher",
            //                "book/bookbypublisher/",
            //                new { controller = "Book", action = "BookByPublisher" },
            //                new[] { "Macaque.Base.Web.Controllers.Book" });
            //routes.MapRoute("BooksByPublisherId",
            //                "book/booksbypublisherid/",
            //                new { controller = "Book", action = "BooksByPublisherId" },
            //                new[] { "Macaque.Base.Web.Controllers.Book" });

            routes.MapRoute("UserListByPartialView",
                           "User/UserListByPartialView/",
                           new { controller = "User", action = "UserListByPartialView" },
                           new[] { "Macaque.Base.Web.Controllers.User" });
            routes.MapRoute("UserListByJson",
                            "User/UserListByJson/",
                            new { controller = "User", action = "UserListByJson" },
                            new[] { "Macaque.Base.Web.Controllers.User" });

        }
    }
}