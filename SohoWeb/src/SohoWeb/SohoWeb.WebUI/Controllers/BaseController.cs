﻿using System;
using System.Web.Mvc;

using Soho.Utility.Web.Framework;
using SohoWeb.Entity;
using SohoWeb.WebUI.ViewModels;

namespace SohoWeb.WebUI.Controllers
{
    [ResultExecutAttribute]
    public class BaseController : Controller
    {
        protected LoginAuthVM CurrUser = (new AuthMgr()).ReadUserInfo();

        public EntityBase SetEntityBase(EntityBase entity, bool? bIsCreate = null)
        {
            var user = (new AuthMgr()).ReadUserInfo();
            if (bIsCreate.HasValue && bIsCreate.Value)
            {
                entity.InDate = DateTime.Now;
                entity.InUserSysNo = user.UserSysNo;
                entity.InUserName = user.UserName;
            }
            else if (bIsCreate.HasValue && !bIsCreate.Value)
            {
                entity.EditDate = DateTime.Now;
                entity.EditUserSysNo = user.UserSysNo;
                entity.EditUserName = user.UserName;
            }
            else
            {
                entity.InDate = DateTime.Now;
                entity.InUserSysNo = user.UserSysNo;
                entity.InUserName = user.UserName;
                entity.EditDate = DateTime.Now;
                entity.EditUserSysNo = user.UserSysNo;
                entity.EditUserName = user.UserName;
            }
            return entity;
        }
    }

    [AuthAttribute(NeedAuth = true)]
    public class SSLController : BaseController
    { }

    [AuthAttribute(NeedAuth = false)]
    public class WWWController : BaseController
    { }
}