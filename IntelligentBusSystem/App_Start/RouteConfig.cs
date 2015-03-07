using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IntelligentBusSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",//controller name
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UserAccounts", action = "Profile", id = UrlParameter.Optional }
            );
        }
    }
}