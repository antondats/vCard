using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace vCard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                    "",
                    new
                    {
                        controller = "Home",
                        action = "Profile",
                        navigation = (string)null,
                    }
                );


            routes.MapRoute(null,
                "Contact",
                new { controller = "Contact", action = "Index" }
                );

            routes.MapRoute(null,
                "Portfolio",
                new { controller = "Portfolio", action = "List" }
                );

            

            routes.MapRoute(null,
                "Admin/Skills",
                new {controller = "Admin", action = "Index"}
                );

            routes.MapRoute(null,
                "Admin",
                new { controller = "Admin", action = "Index" }
                );

            routes.MapRoute(null,
                "Admin/Projects",
                new {controller = "Admin", action = "Projects"}           
                );

            routes.MapRoute(null,
                "Portfolio/{project}",
                new { controller = "Project", action = "Item", project = 0 }
                );

            routes.MapRoute(null,
                "Skills",
                new { controller = "Skills", action = "List" }
                );

            routes.MapRoute(null,
                "Profile",
                new { controller = "Home", action = "Profile" }
                );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Profile"}
            );
        }
    }
}
