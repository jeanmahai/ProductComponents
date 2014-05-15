using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace SohoWeb.WebUI
{
    public class Auth2 : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (false)
            {
                //HttpContext.Current.Response.Filter

                ViewResult result = filterContext.Result as ViewResult;

                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(result.Model));
                HttpContext.Current.Response.End();

                //string AppId = "101";
                //HttpContext.Current.Response.Headers.Add("x-newegg-app-id", AppId);
                //var httpResponseMessage = actionExecutedContext.Response;
                //if (httpResponseMessage != null)
                //{
                //    var content = ((System.Net.Http.ObjectContent)((HttpContent)actionExecutedContext.Response.Content));
                //    var cookieStr = HttpContext.Current.Response.Headers["x-newegg-mobile-cookie"].ToString();
                //    PortalResult value = (PortalResult)content.Value;
                //    var result = new
                //    {
                //        Success = value.Success,
                //        Message = value.Message,
                //        Data = "1000",
                //        Code = value.Code,
                //        Cookie = cookieStr
                //    };
                //    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(result));
                //    HttpContext.Current.Response.End();
                }
            }
        }
    }
