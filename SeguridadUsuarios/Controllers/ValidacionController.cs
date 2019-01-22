using SeguridadUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SeguridadUsuarios.Controllers
{
    public class ValidacionController : Controller
    {
        // GET: Validacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String usuario, String password)
        {
            //Validar si el usuario que nos han enviado es correcto. Si es correcto creamos un TICKET =>cookie encriptada
            //Doble factor de seguridad, Session y cookcie encriptada
            ControlUsuarioscs control = new ControlUsuarioscs();
            if (control.ExisteUsuario(usuario,password))
            {
    //Version, fecha de creacion, fecha de caducar, name(id User), donde almacenar la coockie,
    //userdata (datos que no sirven, es info extra del usuario, como el ROLE)
    FormsAuthenticationTicket ticket= new FormsAuthenticationTicket(1,usuario,DateTime.Now,DateTime.Now.AddMinutes(5),true,control.Role);

//La cookie debe ser encriptada, por lo que no pasa nada si como segundo parámetro de ticket le paso el id
//Al llegar al cliente no va a saber que datos son los que tienen
                String datosCifrados = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie= new HttpCookie("NOMBRE_COOCKIE", datosCifrados);
                //Response escribe le coockie
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index","Administracion");
            }
            return View();
        }

        public ActionResult ErrorAcceso()
        {
            return View();
        }
    }
}