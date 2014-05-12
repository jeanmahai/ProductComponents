using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SohoWeb.Entity.ControlPanel;
using SohoWeb.DataAccess.ControlPanel;

namespace SohoWeb.Service.ControlPanel
{
    public class UserAuthService
    {
        #region 服务实例
        private static UserAuthService _instance;
        public static UserAuthService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserAuthService();
                return _instance;
            }
        }
        #endregion

        public List<Users> GetDemoData(int sysNo)
        {
            return UserAuthDA.GetDemoData(sysNo);
        }
    }
}
