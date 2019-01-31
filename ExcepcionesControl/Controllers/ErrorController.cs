using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcepcionesControl.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PaginaNoEncontrada()
        {
            //le indicamos el codigo del error
            //tambien se puede usar la clase HttpStatusCode que 
            //es una enumeracion de estos codigos
            Response.StatusCode = 404;
            ViewBag.mensaje = "Pagina no encontrada";
            return View();
        }

        public ActionResult Error()
        {
            ViewBag.mensaje = "Ha sucedido un error general";
            return View();
        }
    }
}