using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeddingStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "sklep",
                defaults: new { controller = "Product", action = "Shop", category = (string)null, subpage = 1 }
            );

            routes.MapRoute(
                name: null,
                url: "sklep/strona/{subpage}",
                defaults: new { controller = "Product", action = "Shop", category = (string)null },
                          new { subpage = @"\d+" }
            );

            routes.MapRoute(
                name: null,
                url: "sklep/{category}",
                defaults: new { controller = "Product", action = "Shop", subpage = 1 }
            );

            routes.MapRoute(
                name: null,
                url: "sklep/{category}/strona/{subpage}",
                defaults: new { controller = "Product", action = "Shop" },
                          new { subpage = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
