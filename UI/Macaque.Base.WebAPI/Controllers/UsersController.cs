using Macaque.Base.BusinessEntity;
using Macaque.Base.ProxyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Macaque.Base.WebAPI.Controllers
{
    public class UsersController : ApiController
    {       
        public IQueryable Get()
        {
            return UserManagementProxy.GetInstance().GetAllUser().AsQueryable();
        }

        public UserEntity Get(int id)
        {
            UserEntity user = UserManagementProxy.GetInstance().GetUserByID(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        public UserEntity Post(UserEntity value)
        {
            UserManagementProxy.GetInstance().SaveUserInfo(value, "");
            return value;
        }

        public bool Put(string id, UserEntity value)
        {
            try
            {
                int userId = Convert.ToInt32(id);
                UserEntity user = UserManagementProxy.GetInstance().GetUserByID(userId);
                user.Gender = value.Gender;
                user.Mobile = value.Mobile;
                user.Email = value.Email;
                user.Grade = value.Grade;
                if (value.UserAllRoles != null)
                    user.UserAllRoles = value.UserAllRoles;
                UserManagementProxy.GetInstance().SaveUserInfo(user, "");
                return true; 
            }
            catch (Exception)
            {
                return false;
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(string id)
        {
            int userId = 0;
            if (int.TryParse(id, out userId))
            {
                UserManagementProxy.GetInstance().DeleteUserByID(userId);
                UserEntity entity = UserManagementProxy.GetInstance().GetUserByID(userId);
                if (entity != null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }
    }
}
