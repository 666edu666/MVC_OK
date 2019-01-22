using SeguridadEmpleados.Model;
using SeguirdadEmpleados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Principal;

namespace SeguirdadEmpleados.Controllers
{
    public class ValidacionController : Controller
    {
        RepositoryEmpleados repo;

        public ValidacionController() {
            this.repo = new RepositoryEmpleados();
        }
        // GET: Validacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String apellido,int idempleado)
        {
            Empleado em=this.repo.ExisteEmpleado(apellido, idempleado);

            if(em != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (1, apellido, DateTime.Now, DateTime.Now.AddMinutes(5), true, em.IdEmpleado.ToString());
                String cifrado = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie("TICKETEMPLEADO", cifrado);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index","Empleados");
            }
            else
            {
                ViewBag.Mensaje = "Error de credenciales";
                //Error de credenciales
            }
            return View();
        }
        

        public ActionResult ErrorAcceso() {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            //Debemos quitar al usuario y su identidad
            HttpContext.User = new GenericPrincipal(new GenericIdentity(""),null);

            //Salir de la autentificación
            FormsAuthentication.SignOut();

            //Recuperar la cookie y caducarla
            HttpCookie cookie = Request.Cookies["TICKETEMPLEADO"];
            cookie.Expires = DateTime.Now.AddMonths(1);
            //Volver a escribir la cookie
            Response.Cookies.Add(cookie);
            //Donde me lo llevo? => Tengo todo protegido con login.
            return RedirectToAction("Presentacion");
        }

        [AllowAnonymous]
        public ActionResult Presentacion()
        {
            return View();
        }
    }
}