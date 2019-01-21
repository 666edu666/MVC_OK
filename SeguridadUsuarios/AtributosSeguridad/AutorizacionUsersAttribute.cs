using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeguridadUsuarios.AtributosSeguridad
{
    public class AutorizacionUsersAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //Preguntamos si el usuario está autentificado
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //Si me da igual el rol o el name => No hago nada

                //Queremos: validar por el role dle usuario :
                if (! filterContext.HttpContext.User.IsInRole("ADMINISTRADOR"))
                {
                    //Enviar a erroracceso
                    //Clase RouteValueDictionary => Permite crea una ruta con action y controller
                    RouteValueDictionary ruta = 
                        new RouteValueDictionary(new { Controller = "Validacion", Action = "ErrorAcceso" });

                    //Una vez que tenemos la ruta donde llevamos al usuario=> ejecutarla : RedirectToRouteResult
                    RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
                    filterContext.Result = direccion;
                }
                else
                {
                    //Si no ejecuta ninguna accion de este método ejecuta su ruta normal 
                    
                }

            }
            else
            {
                RouteValueDictionary ruta =
                       new RouteValueDictionary(new { Controller = "Validacion", Action = "Login" });

                //Una vez que tenemos la ruta donde llevamos al usuario=> ejecutarla : RedirectToRouteResult
                RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
                filterContext.Result = direccion;
            }
        }
    }
}