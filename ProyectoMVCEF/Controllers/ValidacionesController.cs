using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMVCEF.Models;

namespace ProyectoMVCEF.Controllers
{
    public class ValidacionesController : Controller
    {
        // GET: Validaciones
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Correcto()
        {
            return View();
        }

        //GET 
        public ActionResult InsertarPersona()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertarPersona(Persona p)
        {
            if (ModelState.IsValid)
            {
                //Aquí está validado correctamente
                return View("Correcto");
            }
            else
            {
                //Alguna validación es incorrecta
                return View(p);
            }
            
        }
    }
}