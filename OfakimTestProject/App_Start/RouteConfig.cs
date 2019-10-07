using System.Web.Mvc;
using System.Web.Routing;

namespace OfakimTestProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetData",
                url: "GetData",
                defaults: new { controller = "Data", action = "GetData" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ofakim", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
