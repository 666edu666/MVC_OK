using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RecursosGlobalizacion.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController() {

        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now.ToLongDateString();
            ViewBag.Saludo = Resources.Mensajes.Saludo;
            ViewBag.Imagen = Resources.Mensajes.Imagen;
            return View();
        }
        public ActionResult IdiomaDinamico()
        {

        //https://diegobersano.com.ar/2016/02/22/como-cambiar-la-cultura-manualmente-en-asp-net-mvc/
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");

            ViewBag.Fecha = DateTime.Now.ToLongDateString();
            ViewBag.Saludo = Resources.Mensajes.Saludo;
            ViewBag.Imagen = Resources.Mensajes.Imagen;
            return View();
        }
    }
}