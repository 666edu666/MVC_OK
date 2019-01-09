using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class EnfermoController : Controller
    {
        HelperEnfermo helper;

        // GET: Enfermo

        public EnfermoController()
        {
            this.helper = new HelperEnfermo();
        }
       

        public ActionResult EliminarEnfermos()
        {
            
            return View(this.helper.GetEnfermos());
        }

        [HttpPost]
        public ActionResult EliminarEnfermos(int inscripcion)
        {
            int afectados = this.helper.EliminarEnfermo(inscripcion);
            ViewBag.Afetados = "Registro eliminados " + afectados;
            return View(this.helper.GetEnfermos());
        }


    }
}