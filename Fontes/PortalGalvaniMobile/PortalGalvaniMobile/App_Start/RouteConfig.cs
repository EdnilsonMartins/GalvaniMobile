using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PortalGalvaniMobile
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Index4",
                url: "Interna/{Id}/{titulo}",
                defaults: new { controller = "Conteudo", action = "Index" }
            );

            routes.MapRoute(
                name: "Index5",
                url: "Materia/{Id}/{titulo}",
                defaults: new { controller = "Conteudo", action = "Index" }
            );

            routes.MapRoute(
                name: "Index6",
                url: "Noticia/{Id}/{titulo}",
                defaults: new { controller = "Conteudo", action = "Index" }
            );

            routes.MapRoute(
                name: "Index7",
                url: "Evento/{Id}/{titulo}",
                defaults: new { controller = "Conteudo", action = "Index" }
            );

            routes.MapRoute(
                name: "Index8",
                url: "Artigo/{Id}/{titulo}",
                defaults: new { controller = "Conteudo", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}