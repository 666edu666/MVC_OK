using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeguridadAspnetDb.Controllers
{
    public class HomeController : Controller
    {
        // [Authorize] a nivel de clase, protejo todo los ActionResult que hay en este controller. Si no lo está me redirecciona al LOGIN
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Users ="user@user.es")] //Cuando entro en About necesito ser ese usuario
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "administradores")] //Cuando entro en About necesito ser ese usuario
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}