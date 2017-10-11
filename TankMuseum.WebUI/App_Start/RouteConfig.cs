using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TankMuseum.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");         
            routes.MapRoute(null, "", new { controller = "Exhibit", action = "List", category = (string)null, page = 1 });
            routes.MapRoute(null, "Page{page}", new { controller = "Exhibit", action = "List", category = (string)null, subcategory = (string)null }, new { page = @"\d+" });
            routes.MapRoute(null, "Page{page}", new { controller = "Exhibit", action = "List", category = (string)null }, new { page = @"\d+" });
            routes.MapRoute(null, "{category}", new { controller = "Exhibit", action = "List", page = 1 });
            routes.MapRoute(null, "{category}/Page{page}", new { controller = "Exhibit", action = "List" }, new { page = @"\d+" });
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
