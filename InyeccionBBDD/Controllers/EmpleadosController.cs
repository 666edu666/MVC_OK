using RepositorioHospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InyeccionBBDD.Controllers
{
    public class EmpleadosController : Controller
    {
        IRepositoryEmpleados repo;

        public EmpleadosController (IRepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        // GET: Empleados
        public ActionResult Index()
        {
            return View(this.repo.GetEmpleados());
        }
    }
}