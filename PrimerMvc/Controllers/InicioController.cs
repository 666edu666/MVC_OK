using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimerMvc.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            ViewData["Mensaje"]="Mensaje de controlador para visualizar en la vista";
            return View();
        }
    }
}