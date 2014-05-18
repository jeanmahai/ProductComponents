using Soho.Utility.Web;
using Soho.Utility.Web.Framework;
using SohoWeb.Service.ControlPanel;
using SohoWeb.WebUI.ViewModels;
using System;
using System.Configuration;

namespace SohoWeb.WebUI
{
    public class AuthMgr : IAuth
    {
        #region IAuth 成员

        public bool ValidateAuth(string controller, string action)
        {
            return true;
        }

        public bool ValidateLogin()
        {
            LoginAuthVM user = ReadUserInfo();
            if (user == null || user.UserSysNo <= 0)
                return false;

            if (user != null && DateTime.Now < user.Timeout)
            {
                return false;
            }
            else if (user != null && user.RememberLogin == true)
            {
                user.LoginDate = DateTime.Now;
                int mobileLoginTimeout = 30;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MobileLoginTimeout"]))
                {
                    int.TryParse(ConfigurationManager.AppSettings["MobileLoginTimeout"], out mobileLoginTimeout);
                    mobileLoginTimeout = mobileLoginTimeout <= 0 ? 30 : mobileLoginTimeout;
                }
                user.Timeout = DateTime.Now.AddMinutes(mobileLoginTimeout);
                CookieHelper.SaveCookie<LoginAuthVM>("LoginCookie", user);
            }

            return true;
        }

        #endregion

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPwd">用户密码，明文</param>
        /// <param name="validateCode">验证码</param>
        /// <returns>true-登录成功；false-登录失败</returns>
        public bool Login(string userID, string userPwd, string validateCode)
        {
            bool result = UserAuthService.Instance.Login(userID, userPwd, validateCode);
            if (result)
            {
                var user = UserAuthService.Instance.GetUserByUserID(userID);
                LoginAuthVM authUser = new LoginAuthVM()
                {
                    UserSysNo = user.SysNo.Value,
                    UserID = user.UserID,
                    UserName = user.UserName,
                    LoginDate = DateTime.Now,
                    Timeout = DateTime.Now.AddMinutes(30),
                    RememberLogin = true
                };
                CookieHelper.SaveCookie<LoginAuthVM>("LoginCookie", authUser);
            }
            return result;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public bool Logout()
        {
            LoginAuthVM authUser = null;
            CookieHelper.SaveCookie<LoginAuthVM>("LoginCookie", authUser);
            return true;
        }

        /// <summary>
        /// 读取用户信息
        /// </summary>
        /// <returns></returns>
        public LoginAuthVM ReadUserInfo()
        {
            return CookieHelper.GetCookie<LoginAuthVM>("LoginCookie");
        }
    }
}