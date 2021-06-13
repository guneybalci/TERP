using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TERP.WebUIMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Homepage",
                url: "anasayfa",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "CarControl",
                url: "arac-yonetim",
                defaults: new { controller = "Car", action = "Index" }
            );

            routes.MapRoute(
                name: "PersonManagement",
                url: "personel-yonetim",
                defaults: new { controller = "Personal", action = "Index" }
            );

            routes.MapRoute(
                name: "CostManagement",
                url: "masraf-yonetim",
                defaults: new { controller = "Cost", action = "Index" }
            );

            routes.MapRoute(
                name: "DocumentManagement",
                url: "evrak-islemleri",
                defaults: new { controller = "Document", action = "Index" }
            );

            routes.MapRoute(
                name: "CompanyInformation",
                url: "firma-bilgileri",
                defaults: new { controller = "Company", action = "Index" }
            );

            routes.MapRoute(
                name: "UserManager",
                url: "kullanici-listesi",
                defaults: new { controller = "User", action = "Index" }
            );


            routes.MapRoute(
                name: "CreateUser",
                url: "kullanici-ekle",
                defaults: new { controller = "User", action = "Add" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
