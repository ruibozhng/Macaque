using Macaque.Base.BusinessEntity;
using Macaque.Base.ProxyService;
using Macaque.Base.Web.Common;
using Macaque.Base.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Macaque.Base.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /UserAccount/

        public ActionResult Index()
        {
            List<UserEntity> eList = UserManagementProxy.GetInstance().GetAllUser();
            List<UserModel> mList = new List<UserModel>();
            foreach (var item in eList)
            {
                mList.Add(AutoMapper.ConvertToUserModel(item));
            }
            return View(mList);
        }

        //[Authorize]
        public ActionResult Search()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Search([Bind(Prefix = "ID")]String input)
        {
            int id = 1;
            Int32.TryParse(input, out id);
            UserEntity user = UserManagementProxy.GetInstance().GetUserByID(id);

            return PartialView("Result", user.UserName);
        }

        public ActionResult APISearch()
        {
            return View();
        }

        //
        // GET: /User/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            UserEntity entity = UserManagementProxy.GetInstance().GetUserByID(id);
            UserModel model = AutoMapper.ConvertToUserModel(entity);
            //Get all grades
            List<CodeEntity> list = UserManagementProxy.GetInstance().GetAllGrades();
            model.Grade = list.Find(x => x.Code == entity.Grade).CodeDesc;
            //Get all roles
            List<RoleModel> roles = AutoMapper.ConvertToRoleMoleList(UserManagementProxy.GetInstance().GetAllRoles());
            model.AllRoles = roles;
            return View(model);
        }

        //
        // GET: /News/Create
        [Authorize(Roles="PUB, ADM")]
        public ActionResult Create()
        {
            List<CodeEntity> list = UserManagementProxy.GetInstance().GetAllGrades();
            List<SelectListItem> grades = new List<SelectListItem>();
            foreach (var item in list)
            {
                grades.Add(new SelectListItem { Text = item.CodeDesc, Value = item.Code });
            }
            ViewData["GRADES"] = grades;

            List<RoleModel> roles = AutoMapper.ConvertToRoleMoleList(UserManagementProxy.GetInstance().GetAllRoles());
            ViewData["ROLES"] = roles;

            return View();
        }

        //
        // POST: /News/Create
        [Authorize(Roles = "PUB, ADM")]
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                // TODO: Add insert logic here
                //UserEntity user = new UserEntity { UserName = model.UserName, Password = model.Password };
                UserEntity user = AutoMapper.ConvertToUserEntity(model);
                UserManagementProxy.GetInstance().SaveUserInfo(user, WebUtility.GetUser().UserId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5
        [Authorize(Roles = "ADM")]
        public ActionResult Edit(int id)
        {
            UserEntity entity = UserManagementProxy.GetInstance().GetUserByID(id);
            UserModel model = AutoMapper.ConvertToUserModel(entity);
            //Get all grades
            List<CodeEntity> list = UserManagementProxy.GetInstance().GetAllGrades();
            List<SelectListItem> grades = new List<SelectListItem>();
            foreach (var item in list)
            {
                if(entity.Grade == item.Code)
                    grades.Add(new SelectListItem { Text = item.CodeDesc, Value = item.Code });
                else
                    grades.Add(new SelectListItem { Text = item.CodeDesc, Value = item.Code, Selected = true });
            }
            ViewData["GRADES"] = grades;
            //Get all roles
            List<RoleModel> roles = AutoMapper.ConvertToRoleMoleList(UserManagementProxy.GetInstance().GetAllRoles());
            model.AllRoles = roles;
            return View(model);
        }

        //
        // POST: /User/Edit/5
        [Authorize(Roles = "ADM")]
        [HttpPost]
        public ActionResult Edit(int id, UserModel model)
        {
            try
            {
                UserEntity user = UserManagementProxy.GetInstance().GetUserByID(id);
                user.Gender = model.Gender;
                user.Mobile = model.Mobile;
                user.Email = model.Email;
                user.Grade = model.Grade;
                if (model.SelectedRoles != null)
                    user.UserAllRoles = model.SelectedRoles;
                UserManagementProxy.GetInstance().SaveUserInfo(user, WebUtility.GetUser().UserId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        [Authorize(Roles = "SUP")]
        public ActionResult Delete(int id)
        {
            UserEntity entity = UserManagementProxy.GetInstance().GetUserByID(id);
            UserModel model = AutoMapper.ConvertToUserModel(entity);
            //Get all grades
            List<CodeEntity> list = UserManagementProxy.GetInstance().GetAllGrades();
            model.Grade = list.Find(x => x.Code == entity.Grade).CodeDesc;
            //Get all roles
            List<RoleModel> roles = AutoMapper.ConvertToRoleMoleList(UserManagementProxy.GetInstance().GetAllRoles());
            model.AllRoles = roles;
            return View(model);
        }

        //
        // POST: /User/Delete/5
        [Authorize(Roles = "SUP")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                UserManagementProxy.GetInstance().DeleteUserByID(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UserListByPartialView(int id)
        {
            IEnumerable<UserEntity> list = UserManagementProxy.GetInstance().GetAllUser();
            return PartialView(list);
        }

        public JsonResult UserListByJson(int id)
        {
            IEnumerable<UserEntity> list = UserManagementProxy.GetInstance().GetAllUser();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
