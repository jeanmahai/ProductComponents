using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SohoWeb.Service.ControlPanel;

namespace SohoWeb.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = UserAuthService.Instance.GetDemoData(0);
            return View(data);
        }
    }
}
