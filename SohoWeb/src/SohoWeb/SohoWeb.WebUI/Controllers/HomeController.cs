using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SohoWeb.Service.ControlPanel;
using Newtonsoft.Json;

namespace SohoWeb.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = UserAuthService.Instance.GetDemoData(0);
            return View(data);
        }

        [Auth2]
        public ActionResult GetDatas()
        {
            PortalResult result = new PortalResult()
                    {
                        Code = 0,
                        Success = true,
                        Data = 1,
                        Message = ""
                    };
            return View(result);

            //return new JsonResult()
            //{
            //    JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet,
            //    Data = new PortalResult()
            //        {
            //            Code = 0,
            //            Success = true,
            //            Data = 1,
            //            Message = ""
            //        }
            //};
        }
    }
}
