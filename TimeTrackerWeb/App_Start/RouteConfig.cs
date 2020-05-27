using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TimeTrackerWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "UserReports",
                "Reports/GetReports/{userId:int}/{startDate:datetime}/{*endDate:datetime}",
                new { controller = "Reports", action = "GetReports"},
                new { startdate = @"\d{4}-\d{2}-\d{2}", enddate = @"\d{4}-\d{2}-\d{2}" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
