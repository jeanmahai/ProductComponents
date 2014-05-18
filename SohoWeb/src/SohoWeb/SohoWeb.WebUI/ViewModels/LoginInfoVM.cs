using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SohoWeb.WebUI.ViewModels
{
    public class LoginInfoVM
    {
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public string ValidateCode { get; set; }
    }
}