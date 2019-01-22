using SeguridadEmpleados.Model;
using SeguirdadEmpleados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace SeguirdadEmpleados
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public void Application_PostAuthenticateRequest()
        {
            HttpCookie cookie = Request.Cookies["TICKETEMPLEADO"];
            if (cookie!=null)
            {
                //Ya hemos pasado por login
                String datos = cookie.Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(datos);
                //Usa : sha256 
                //String[] roles = { ticket.UserData};
                String username = ticket.Name;
                int empno = int.Parse(ticket.UserData);

                GenericIdentity identidad = new GenericIdentity(username);

                //Creamos usuario genérico 
                //GenericPrincipal usuario = new GenericPrincipal(identidad,roles);

                //Con el cambio que hemos dado al poner al empleado heredando de IPrincipal
                //Lo que hacemos es meter al empleado ENTERO con todas sus propiedades 
                //En la Session
                RepositoryEmpleados repo = new RepositoryEmpleados();
                Empleado Emp = repo.BuscarEmpleado(empno);
                Emp.Identity = identidad;
                HttpContext.Current.User = Emp;
            }
        }
    }
}
