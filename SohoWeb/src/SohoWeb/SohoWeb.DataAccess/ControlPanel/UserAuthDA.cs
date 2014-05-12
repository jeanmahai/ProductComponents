using System.Collections.Generic;

using Common.Utility.DataAccess;
using SohoWeb.Entity.ControlPanel;

namespace SohoWeb.DataAccess.ControlPanel
{
    public class UserAuthDA
    {
        public static List<Users> GetDemoData(int sysNo)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("Demo");
            cmd.SetParameterValue("@SysNo", sysNo);
            return cmd.ExecuteEntityList<Users>();
        }
    }
}
