using System.Web.Mvc;
using Soho.Utility.Web.Framework;
using Soho.Utility;
using SohoWeb.WebUI.ViewModels;
using System.Web;
using SohoWeb.Service.ControlPanel;

namespace SohoWeb.WebUI.Controllers
{
    /// <summary>
    /// 控制面板
    /// </summary>
    public class ControlPanelController : SSLController
    {
        public ActionResult Index()
        {
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = UserAuthService.Instance.GetUserByUserID("sohoadmin"),
                Message = ""
            };
            return View(result);
        }
    }
}
