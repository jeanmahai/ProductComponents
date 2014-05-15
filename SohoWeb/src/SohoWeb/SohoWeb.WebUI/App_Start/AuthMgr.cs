using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Soho.Utility.Web.Framework;

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
            return true;
        }

        #endregion
    }
}