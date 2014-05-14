using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SohoWeb.WebUI
{
    public class PortalResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int Code { get; set; }
    }
}