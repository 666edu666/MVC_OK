using RutesConceptos.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RutesConceptos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            //routes.MapMvcAttributeRoutes(); //Para poder acoplar [Route] en los controladores
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name:"RoutingBuscar",
            //    url:"Rutas/{tipoaccion}/{iddato}",
            //    defaults: new
            //    { // UrlParameter.Optional = ""
            //        controller = "Rutas",
            //        action = "Buscar",
            //        //tipoaacion = "",
            //        //iddato = ""
            //    });
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}/{nombre}",
            //    defaults: new {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional,
            //        nombre=UrlParameter.Optional}
            //);
            List<String> bloqueos = new List<String>();
            bloqueos.Add("Barcelona");

            RouteTable.Routes.Add(
                "WikiProvincias",
                new Route(
                    "Provincias/Region/{nombreprovincia}",
                    new RouteWiki(bloqueos)));

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}/{nombre}",
               defaults: new
               {
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional,
                   nombre = UrlParameter.Optional
               }
           );
        }
    }
}
