using ProyectoMVCReal.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCReal.Controllers
{
    public class DoctorController : Controller
    {

        HelperDoctor helpDoc;

        // GET: Doctor
        public ActionResult Index()
        {
            this.helpDoc = new HelperDoctor();   
            return View(helpDoc.GetDoctores());
        }

        public ActionResult DetalleDoctor(int cod)
        {
            this.helpDoc = new HelperDoctor();            
            return View(helpDoc.BuscarDoctor(cod));
        }

        public ActionResult EliminarDoctor(int cod)
        {
           
            this.helpDoc = new HelperDoctor();
            return View(helpDoc.BuscarDoctor(cod));
        }

        [HttpPost]
        public ActionResult EliminarDoctor(String cod)
        {
            ViewBag.Borrado = "Correcto";
            this.helpDoc = new HelperDoctor();
            this.helpDoc.BorraDoctor(int.Parse(cod));
            return View();
        }

    }
}