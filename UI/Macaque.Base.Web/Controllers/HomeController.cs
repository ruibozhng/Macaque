using Macaque.Base.BusinessEntity;
using Macaque.Base.ProxyService;
using Macaque.Common.BusinessComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Macaque.Base.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Prefix = "name")]String input)
        {
            UserManagementProxy.GetInstance().GetAllGrades();
            int id = 1;
            Int32.TryParse(input, out id);
            UserEntity user = UserManagementProxy.GetInstance().GetUserByID(id);
            LogHelper.Write("This is a test");
            return PartialView("Result", user.UserName);            
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
