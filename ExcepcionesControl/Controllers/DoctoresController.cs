using ExcepcionesControl.Filters;
using ExcepcionesControl.Models;
using ExcepcionesControl.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcepcionesControl.Controllers
{
    public class DoctoresController : Controller 
    {
        HospitalRepository repo;
        private static readonly ILog log = LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public DoctoresController() { this.repo = new HospitalRepository(); }
        // GET: Doctores


        [FilterMensajesLog]
        public ActionResult Index()
        {
            //log.Debug("Estoy en Index" + DateTime.Now);
            return View(this.repo.GetDoctores());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HandleExceptionDoctor]
        [HttpPost]
        public ActionResult Create(Doctor doc)
        {
            if (doc.Salario > 65000)
            {
                throw new Exception(
                    "El doctor " + doc.Apellido + "ha sobrepasado el "
                    + "límite salarial de 650000"
                    );
            }
            else if (doc.Especialidad.ToLower() == "neura" && doc.Salario < 30000)
            {
                throw new Exception(
                    "Un doctor de Neurología debe cobrar al menos 300.000"
                    );
            }
            this.repo.InsertarDoctor(
                doc.IdDoctor, doc.CodigoHospital, doc.Apellido, doc.Especialidad, doc.Salario
                );
            return View();
        }

        public ActionResult ErrorSalarios() {
            return View();
        }
    }
}