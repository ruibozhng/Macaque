using Macaque.Base.BusinessEntity;
using Macaque.Base.ProxyService;
using Macaque.Base.Web.Common;
using Macaque.Base.Web.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Macaque.Base.Web.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        public bool GenerateReport()
        {
            List<UserEntity> eList = UserManagementProxy.GetInstance().GetAllUser();
            string mimeType;
            var ds = new UserDataSet();
            var dt = ds.T_USER;

            foreach (var entity in eList)
            {
                var dr = GetObservation(dt.NewT_USERRow(), entity);
                dt.Rows.Add(dr);
            }

            var list = new List<KeyValuePair<string, DataTable>>
                {
                    new KeyValuePair<string, DataTable>("T_USER",dt)
                };

            var stream = ReportUtility.GenerateReport("UserReport", null, list, out mimeType);
            Session["Generated_Report"] = stream;
            Session["mimeType"] = mimeType;
            return true;
        }

        private UserDataSet.T_USERRow GetObservation(UserDataSet.T_USERRow dr, UserEntity entity)
        {
            dr.USER_ID = entity.UserID;
            dr.USER_NAME = entity.UserName;
            dr.USER_PWD = entity.Password;
            dr.GENDER = entity.Gender;
            dr.EMAIL_ADDRESS = entity.Email;
            dr.MOBILE_NUMBER = entity.Mobile;
            dr.GRADE = entity.Grade;
            dr.IS_DELETED = entity.IsDeleted;

            return dr;
        }

        public ActionResult GetReport()
        {
            var stream = Session["Generated_Report"] as byte[];
            string mimeType = Session["mimeType"].ToString();

            Session["Generated_Report"] = null;
            Session["mimeType"] = null;

            return File(stream, mimeType, "TestReport.pdf");
        }

    }
}
