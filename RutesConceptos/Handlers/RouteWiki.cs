using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace RutesConceptos.Handlers
{
    public class RouteWiki : IRouteHandler
    {
        List<String> provincias;
        public RouteWiki(List<String> provincias)
        {
            this.provincias = provincias;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            //Manejador
            return new HandlerWiki(this.provincias, requestContext);
        }
    }
}