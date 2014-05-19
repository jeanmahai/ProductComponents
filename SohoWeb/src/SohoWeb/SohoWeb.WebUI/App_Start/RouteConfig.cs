using System.Web.Routing;
using System.Configuration;
using Soho.Utility.Web.Mvc;

namespace SohoWeb.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteConfigurationSection section = (RouteConfigurationSection)ConfigurationManager.GetSection("routeConfig");
<<<<<<< HEAD
            
            routes.MapRoute(section);
=======

            routes.MapRoute(section);
>>>>>>> 94123e9c49a6f12f2de765e4f0105921514c681f
        }
    }
}