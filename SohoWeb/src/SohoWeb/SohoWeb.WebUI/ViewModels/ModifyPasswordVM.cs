using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SohoWeb.WebUI.ViewModels
{
    public class ModifyPasswordVM
    {
        public string UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}