using SeguridadUsuarios.AtributosSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeguridadUsuarios.Controllers
{
    [AutorizacionUsers]
    public class AdministracionController : Controller
    {
        // GET: Administracion

            
        public ActionResult Index()
        {
            return View();
        }

        
    }
}