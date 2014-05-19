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
            routes.MapRoute(section);
=======
            
            routes.MapRoute(section);
>>>>>>> 715f3d5ac970e4474d26eef38e174efa017fc342
        }
    }
}