using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SohoWeb.Entity.ControlPanel;
using SohoWeb.DataAccess.ControlPanel;

namespace SohoWeb.Service.ControlPanel
{
    public class UserAuthService : BaseService<UserAuthService>
    {
        public List<Users> GetDemoData(int sysNo)
        {
            return UserAuthDA.GetDemoData(sysNo);
        }
    }
}
