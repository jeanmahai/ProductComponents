using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SohoWeb.Service.ControlPanel;
using Newtonsoft.Json;
using Soho.Utility.Web.Framework;

namespace SohoWeb.WebUI.Controllers
{
    public class HomeController : SSLController
    {
        public ActionResult Index()
        {
            PortalResult result = new PortalResult()
            {
                Code = 0,
                Success = true,
                Data = UserAuthService.Instance.GetDemoData(0),
                Message = ""
            };
            return View(result);
        }

        public ActionResult GetDatas()
        {
            PortalResult result = new PortalResult()
                    {
                        Code = 0,
                        Success = true,
                        Data = UserAuthService.Instance.GetDemoData(0),
                        Message = ""
                    };
            return View(result);
        }
    }
}
