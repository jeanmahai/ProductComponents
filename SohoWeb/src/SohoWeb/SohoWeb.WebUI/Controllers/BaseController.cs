using System.Web.Mvc;

using Soho.Utility.Web.Framework;
using SohoWeb.WebUI.ViewModels;

namespace SohoWeb.WebUI.Controllers
{
    [ResultExecutAttribute]
    public class BaseController : Controller
    {
        protected LoginAuthVM CurrUser = (new AuthMgr()).ReadUserInfo();
    }

    [AuthAttribute(NeedAuth = true)]
    public class SSLController : BaseController
    { }

    [AuthAttribute(NeedAuth = false)]
    public class WWWController : BaseController
    { }
}