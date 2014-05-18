using System.Web;
using System.Web.Mvc;

using Soho.Utility;
using Soho.Utility.Web.Framework;
using SohoWeb.WebUI.ViewModels;

namespace SohoWeb.WebUI.Controllers
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SystemUserController : WWWController
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            var requestVM = SerializationUtility.JsonDeserialize2<LoginInfoVM>(HttpUtility.UrlDecode(Request.Params["data"]));
            bool loginResult = (new AuthMgr()).Login(requestVM.UserID, requestVM.UserPassword, requestVM.ValidateCode);
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = loginResult,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            bool loginResult = (new AuthMgr()).Logout();
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = loginResult,
                Message = ""
            };
            return View(result);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
    }
}
