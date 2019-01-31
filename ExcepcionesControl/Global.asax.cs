using ExcepcionesControl.App_Start;
using ExcepcionesControl.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExcepcionesControl
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            log4net.Config.XmlConfigurator.Configure();
        }
        public void Application_Error() {
            //Excepcion genérica,es para los error generales de la app. 
            //Para  el control de mis propias excepciones se usa FILTER

            Exception ex = Server.GetLastError();//Creo la excepcion de tipo servidor

            HttpException exhttp = ex as HttpException; //Es un error del tipo http


            String action = "";
            //Las excepciones tienen códigos de error, pero quiero las propias que se producen en http

            if (exhttp.GetHttpCode() == 404)
            { //En este caso quiero recoger el not found
                action = "PaginaNoEncontrada";
            }
            else {
                action = "ErrorGeneral";
            }

            Context.ClearError(); //Para quitar el error ya que nosotros lo vamos a manejar




            //Creamos las rutas para dirigir a nuestro controller
            RouteData ruta = new RouteData();

            ruta.Values.Add("controller","Error");
            ruta.Values.Add("action", action);


            //Usamos Interface para poder englobarlo mejor. Para poder aplicarlo a cualquier controlador
            IController controlador = new ErrorController();

            //Para ejecutar el redireccionamiento al controlador del error
            //Wrapper =>Envolvente
            controlador.Execute(
                new RequestContext(new HttpContextWrapper(Context),ruta)
                ); 
        }
    }
}
