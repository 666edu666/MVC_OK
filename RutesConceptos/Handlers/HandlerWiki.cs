using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace RutesConceptos.Handlers
{
    public class HandlerWiki : IHttpHandler
    {
        private List<String> provincias;

        private RequestContext requestcontext;

        public HandlerWiki(List<String> provincias, RequestContext requestcontext){
            this.provincias = provincias;
            this.requestcontext = requestcontext;
        }

        public bool IsReusable => throw new NotImplementedException();

        //public void ProcessRequest(HttpContext context)
        //{
        //    //adminsitra la peticion y decide donde nos redirecciona



        //    String url = context.Request.RawUrl; // provincias/Madrid
        //    int barra = url.LastIndexOf('/') + 1; //Cojo la posicion de la ultima barra
        //    String provincia = url.Substring(barra);

        //    String wiki = "https://es.wikipedia.org/wiki/"+provincia;
        //    //context.Response.Redirect(wiki,true); //True cierra tu app

        //}
        public void ProcessRequest(HttpContext context)
        {
            RouteValueDictionary rutas = this.requestcontext.RouteData.Values;
            //Ya tengo todos los datos que vengan en la URl en ruta
            String provinciaRuta = rutas["nombreprovincia"].ToString();

            if (this.provincias.Contains(provinciaRuta))
            {
                context.AddError(new Exception("La provincia " + provinciaRuta
                    + " no está permitida"));
            }
            else {
                String wiki = "https://es.wikipedia.org/wiki/" + provinciaRuta;
                context.Response.Redirect(wiki,true); //True cierra tu app
            }
        }

    }
}