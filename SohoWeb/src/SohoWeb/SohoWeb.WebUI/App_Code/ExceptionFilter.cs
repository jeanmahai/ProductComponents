using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SohoWeb.WebUI
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                if (AppSettingValue.MobileApiDebug)
                {
                    actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            JsonConvert.SerializeObject(
                            new PortalResult { Success = false, Message = actionExecutedContext.Exception.Message, Code = 0 }))
                    };
                }
                else
                {
                    actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            JsonConvert.SerializeObject(
                            new PortalResult { Success = false, Message = LanguageHelper.GetText("系统错误"), Code = 0 }))
                    };
                }
            }
        }
    }
}