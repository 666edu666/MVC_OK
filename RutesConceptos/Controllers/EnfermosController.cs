using RutesConceptos.Models;
using RutesConceptos.Reposiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RutesConceptos.Controllers
{
    public class EnfermosController : Controller
    {
        RepositoryHospital repo;

        public EnfermosController() { this.repo = new RepositoryHospital(); }
        // GET: Enfermos
        public ActionResult Index()
        {
            return View(this.repo.GetEnfermos());
        }

        public ActionResult Delete(int id) {

            Enfermo en = this.repo.BuscarEnfermo(id.ToString());
            return View(en);
        }
        [Route("EnfermosAux/{inscripcion}")] //Cuando recibas Delete/ID entra a EliminarEnfermo
        [HttpPost]
        public ActionResult EliminarEnfermo(String inscripcion)
        {
            //Enfermo en = this.repo.BuscarEnfermo(inscripcion);
            this.repo.EliminarEnfermo(inscripcion);
            return RedirectToAction("Index");
        }
    }
}