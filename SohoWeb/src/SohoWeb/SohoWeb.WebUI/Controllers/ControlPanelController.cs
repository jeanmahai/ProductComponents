using System.Web;
using System.Web.Mvc;

using Soho.Utility;
using Soho.Utility.Web.Framework;
using SohoWeb.Service.ControlPanel;
using SohoWeb.Entity.ControlPanel;
using SohoWeb.WebUI.ViewModels;

namespace SohoWeb.WebUI.Controllers
{
    /// <summary>
    /// 控制面板
    /// </summary>
    public class ControlPanelController : SSLController
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertUser()
        {
            //var requestVM = SerializationUtility.JsonDeserialize2<Users>(HttpUtility.UrlDecode(Request.Params["data"]));
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
            //var requestVM = SerializationUtility.JsonDeserialize2<Users>(HttpUtility.UrlDecode(Request.Params["data"]));
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
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUser()
        {
            int sysNo = int.Parse(Request.Params["SysNo"]);
            Users entity = new Users()
            {
                SysNo = sysNo,
                Status = Entity.Enums.CommonStatus.InValid
            };
            this.SetEntityBase(entity, false);
            UsersMgtService.Instance.UpdateUserStatusBySysNo(entity);

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
            //var requestVM = SerializationUtility.JsonDeserialize2<ModifyPasswordVM>(HttpUtility.UrlDecode(Request.Params["data"]));
            var requestVM = GetParams<ModifyPasswordVM>();
            Users entity = new Users()
            {
                UserID = requestVM.UserID,
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

            //var filter = SerializationUtility.JsonDeserialize2<UsersQueryFilter>(HttpUtility.UrlDecode(Request.Params["data"]));
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
            //int sysNo = int.Parse(Request.Params["SysNo"]);
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

        /// <summary>
        /// 根据用户ID获取有效用户
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserByUserID()
        {
            string userID = Request.Params["UserID"];

            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = UsersMgtService.Instance.GetValidUserByUserID(userID),
                Message = ""
            };
            return View(result);
        }
    }
}
