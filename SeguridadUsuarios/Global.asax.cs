using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace SeguridadUsuarios
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //Método para el PRINCIPAL de seguridad 
        public void Application_PostAuthenticateRequest()
        {
            //En este método entrará cuando haya creado el ticket. 
            //Hay que recuperar la cookie


            //Request lee la Cookie
            HttpCookie cookie = Request.Cookies["NOMBRE_COOCKIE"]; //el nombre de la cookie viene de ValidacionContollre 
            if (cookie != null)
            {
                //Estamos en el sistema (factor 1)
                //recuperar la cookie
                String cookieCifrada = cookie.Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookieCifrada);
                String userName = ticket.Name;
                String role = ticket.UserData;
                //Un usuario normal es un generic principal
                //Un generic ppal tiene: identidad(name) y ROLES[]
                GenericIdentity identidad = new GenericIdentity(userName);
                GenericPrincipal user = new GenericPrincipal(identidad, new String[] { role}); //Si tiene más tipos de role se incluyen ahí separados por comas

                //Hay que poner al usuario en la session de la app
                //Se añade al contexto de la aplicación
                HttpContext.Current.User = user;




                //Si los he logueado contra  Windows es un usuario 
                //Si los he logueado contra Google es un usuario 

            }
        }
    }
}
