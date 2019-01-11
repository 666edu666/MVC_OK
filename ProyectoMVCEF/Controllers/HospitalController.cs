using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class HospitalController : Controller
    {
        HelperHospital helper;

        public HospitalController()
        {
            this.helper = new HelperHospital();
        }
        // GET: Hospital
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HospitalesPlantilla(int? [] hospital, int? orden)
        {
            //Cuadno vengo del enlace del orden necesito Traer la lista de hospitales
            ViewBag.Hospitales=this.helper.GetHospitales();
            return View();
        }

        [HttpPost]
        public ActionResult HospitalesPlantilla(int [] hospital, int? orden)
        {
            if (orden==null)
            {
                orden = 0;
            }
            ViewBag.Orden = orden;
            ViewBag.Hospitales = this.helper.GetHospitales();            
            return View(this.helper.GetPlantilla(hospital,orden.GetValueOrDefault()));
        }
    }
}