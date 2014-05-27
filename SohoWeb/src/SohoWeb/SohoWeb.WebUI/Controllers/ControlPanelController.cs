using System.Web;
using System.Web.Mvc;

using Soho.Utility;
using Soho.Utility.Web.Framework;
using SohoWeb.Service.ControlPanel;
using SohoWeb.Entity.ControlPanel;
using SohoWeb.WebUI.ViewModels;
using System.Collections.Generic;
using SohoWeb.Entity;
using SohoWeb.Entity.Enums;

namespace SohoWeb.WebUI.Controllers
{
    /// <summary>
    /// 控制面板
    /// </summary>
    public class ControlPanelController : SSLController
    {
        #region 用户
        /// <summary>
        /// 获取用户状态枚举列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCommonStatusList()
        {
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = EnumsHelper.GetKeyValuePairs<CommonStatus>(EnumAppendItemType.Select),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertUser()
        {
            var requestVM = GetParams<Users>();
            this.SetEntityBase(requestVM, true);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = UsersMgtService.Instance.InsertUser(requestVM),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUser()
        {
            var requestVM = GetParams<Users>();
            this.SetEntityBase(requestVM, false);
            UsersMgtService.Instance.UpdateUserBySysNo(requestVM);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新权限状态
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUserStatus()
        {
            var user = GetParams<Users>();
            UsersMgtService.Instance.UpdateUserStatusBySysNo(user);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUser()
        {
            var request = GetParams<List<string>>();

            if (request != null && request.Count > 0)
            {
                foreach (string str in request)
                {
                    Users entity = new Users()
                    {
                        SysNo = int.Parse(str),
                        Status = Entity.Enums.CommonStatus.Deleted
                    };
                    this.SetEntityBase(entity, false);
                    UsersMgtService.Instance.UpdateUserStatusBySysNo(entity);
                }
            }

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ModifyPassword()
        {
            var requestVM = GetParams<ModifyPasswordVM>();
            Users entity = new Users()
            {
                UserID = this.CurrUser.UserID,
                Password = requestVM.NewPassword
            };
            this.SetEntityBase(entity, false);
            UsersMgtService.Instance.UpdateUserPasswordBySysNo(entity, requestVM.OldPassword);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryUsers()
        {
            var filter = GetParams<UsersQueryFilter>();
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = UsersMgtService.Instance.QueryUsers(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 根据用户编号获取有效用户
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserByUserSysNo()
        {
            var user = GetParams<Users>();
            int sysNo = user.SysNo.Value;

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = UsersMgtService.Instance.GetValidUserByUserSysNo(sysNo),
                Message = ""
            };
            return View(result);
        }
        #endregion

        #region 权限点

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertFunctions()
        {
            var requestVM = GetParams<Functions>();
            this.SetEntityBase(requestVM, true);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = FunctionsMgtService.Instance.InsertFunctions(requestVM),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新权限
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateFunction()
        {
            var requestVM = GetParams<Functions>();
            this.SetEntityBase(requestVM, false);
            FunctionsMgtService.Instance.UpdateFunctionsBySysNo(requestVM);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新权限状态
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateFunctionStatus()
        {
            var functions = GetParams<Functions>();
            FunctionsMgtService.Instance.UpdateFunctionsStatusBySysNo(functions);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteFunction()
        {
            var request = GetParams<List<string>>();

            if (request != null && request.Count > 0)
            {
                foreach (string str in request)
                {
                    Functions entity = new Functions()
                    {
                        SysNo = int.Parse(str),
                        Status = Entity.Enums.CommonStatus.Deleted
                    };
                    this.SetEntityBase(entity, false);
                    FunctionsMgtService.Instance.UpdateFunctionsStatusBySysNo(entity);
                }
            }

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryFunctions()
        {
            var filter = GetParams<FunctionsQueryFilter>();
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = FunctionsMgtService.Instance.QueryFunctions(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 根据权限编号获取有效权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFunctionsBySysNo()
        {
            var user = GetParams<Functions>();
            int sysNo = user.SysNo.Value;

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = FunctionsMgtService.Instance.GetValidFunctionsBySysNo(sysNo),
                Message = ""
            };
            return View(result);
        }
        #endregion

        #region 角色

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertRoles()
        {
            var requestVM = GetParams<Roles>();
            this.SetEntityBase(requestVM, true);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = RolesMgtService.Instance.InsertRoles(requestVM),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRole()
        {
            var requestVM = GetParams<Roles>();
            this.SetEntityBase(requestVM, false);
            RolesMgtService.Instance.UpdateRolesBySysNo(requestVM);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 更新角色状态
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRoleStatus()
        {
            var role = GetParams<Roles>();
            RolesMgtService.Instance.UpdateRolesStatusBySysNo(role);

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteRole()
        {
            var request = GetParams<List<string>>();

            if (request != null && request.Count > 0)
            {
                foreach (string str in request)
                {
                    Roles entity = new Roles()
                    {
                        SysNo = int.Parse(str),
                        Status = Entity.Enums.CommonStatus.Deleted
                    };
                    this.SetEntityBase(entity, false);
                    RolesMgtService.Instance.UpdateRolesStatusBySysNo(entity);
                }
            }

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = true,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryRoles()
        {
            var filter = GetParams<RolesQueryFilter>();
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = RolesMgtService.Instance.QueryRoles(filter),
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 根据角色编号获取有效角色
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRolesBySysNo()
        {
            var user = GetParams<Roles>();
            int sysNo = user.SysNo.Value;

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = RolesMgtService.Instance.GetValidRolesBySysNo(sysNo),
                Message = ""
            };
            return View(result);
        }

        //public ActionResult GetRoleUsers()
        #endregion
    }
}
