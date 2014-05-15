using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Soho.Utility.Web.Framework;

namespace SohoWeb.WebUI.Controllers
{
    [ResultExecutAttribute]
    public class BaseController : Controller
    {
    }

    [AuthAttribute(NeedAuth = true)]
    public class SSLController : BaseController
    { }

    [AuthAttribute(NeedAuth = false)]
    public class WWWController : BaseController
    { }
}