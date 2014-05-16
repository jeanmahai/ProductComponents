using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SohoWeb.Entity.ControlPanel;
using SohoWeb.DataAccess.ControlPanel;
using Soho.Utility;

namespace SohoWeb.Service.ControlPanel
{
    public class UserAuthService : BaseService<UserAuthService>
    {
        public List<Users> GetDemoData(int sysNo)
        {
            throw new BusinessException("不继续执行！");
            return UserAuthDA.GetDemoData(sysNo);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="userPwd">用户密码，明文</param>
        /// <param name="validateCode">验证码</param>
        /// <returns>true-登录成功；false-登录失败</returns>
        public bool Login(string userID, string userPwd, string validateCode)
        {
            return true;
        }
    }
}
