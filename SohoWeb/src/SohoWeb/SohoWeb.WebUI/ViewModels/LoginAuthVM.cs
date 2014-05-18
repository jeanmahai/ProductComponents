using System;

namespace SohoWeb.WebUI.ViewModels
{
    public class LoginAuthVM
    {
        public int UserSysNo { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }

        public bool RememberLogin { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime Timeout { get; set; }
    }
}