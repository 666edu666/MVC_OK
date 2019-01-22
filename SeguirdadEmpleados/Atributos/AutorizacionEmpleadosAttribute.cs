using SeguridadEmpleados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeguirdadEmpleados.Atributos
{
    public class AutorizacionEmpleadosAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //Esta clase sirve para redireccionar al usuario cuando no cumple lo que yo quiero
            base.OnAuthorization(filterContext);

           
            if (filterContext.HttpContext.User.Identity.IsAuthenticated) {
                //Con el cambio al meter el objeto empleado en la session
                //GenericPrincipal usuario = filterContext.HttpContext.User as GenericPrincipal;

                Empleado usuario = filterContext.HttpContext.User as Empleado;

                if (usuario.IsInRole("PRESIDENTE") == true || usuario.IsInRole("DIRECTOR") == true)
                {
                    
                }
                else
                {
                    //Si el usuario no tiene el rol que sea le redirecciono a X sitio
                    filterContext.Result = GetRuta("Validacion", "ErrorAcceso");
                }
            }
            else
            {
                filterContext.Result=this.GetRuta("Validacion","Login");
            }
        }
        public RedirectToRouteResult GetRuta(String controlador, String accion)
        {
            RouteValueDictionary ruta; //A que controller y a que action
            RedirectToRouteResult direccion; //Ejecutar la redireccion
            ruta = new RouteValueDictionary(new { controller = controlador, action = accion });
            direccion = new RedirectToRouteResult(ruta);
            return direccion;
        }
    }
}