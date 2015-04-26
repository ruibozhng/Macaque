using Macaque.Base.BusinessEntity;
using Macaque.Base.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Macaque.Base.Web.Common
{
    public class AutoMapper
    {
        public static UserEntity ConvertToUserEntity(UserModel model)
        {
            UserEntity entity = new UserEntity
            {
                ID = model.ID,
                UserID = model.UserID,
                UserName = model.UserName,
                Password = model.Password,
                Gender = model.Gender,
                Mobile = model.Mobile,
                Email = model.Email,
                Grade = model.Grade
            };
            if (model.SelectedRoles != null)
                entity.UserAllRoles = model.SelectedRoles;
            return entity;
        }

        public static UserModel ConvertToUserModel(UserEntity entity)
        {
            UserModel model = new UserModel
            {
                ID = entity.ID,
                UserID = entity.UserID,
                UserName = entity.UserName,
                Password = entity.Password,
                Gender = entity.Gender,
                Mobile = entity.Mobile,
                Email = entity.Email,
                Grade = entity.Grade
            };
            if (entity.UserAllRoles != null)
                model.SelectedRoles = entity.UserAllRoles;
            return model;
        }

        public static List<RoleEntity> ConvertToRoleEntityList(List<RoleModel> list)
        {
            List<RoleEntity> roles = new List<RoleEntity>();
            foreach (var item in list)
            {
                roles.Add(new RoleEntity { RoleCode = item.RoleCode, RoleDesc = item.RoleDesc });
            }
            return roles;
        }

        public static List<RoleModel> ConvertToRoleMoleList(List<RoleEntity> list)
        {
            List<RoleModel> roles = new List<RoleModel>();
            foreach (var item in list)
            {
                roles.Add(new RoleModel { RoleCode = item.RoleCode, RoleDesc = item.RoleDesc });
            }
            return roles;
        }
    }
}