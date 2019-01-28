using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class AjaxController : Controller
    {
        Repositories.RepositoryHospital repo;
        public AjaxController() { this.repo = new Repositories.RepositoryHospital(); }
        // GET: Ajax
        public ActionResult Index()
        {

            return View(this.repo.GetDepartamento());
        }

        //Vamos a cargar los datos con un partialViewResult => Es igual pero me obliga a devolver un return PartialView()
        public PartialViewResult _EmpleadosDepartamento(int deptno)
        {
            return PartialView(this.repo.GetEmpleadosDepartamento(deptno));
        }
        public ActionResult MostrarEmpleadosAjax()
        {
            
            List<Empleado> empleados = this.repo.GetEmpleados();

            return View(empleados);
        }
        public PartialViewResult DatosEmpleadoAjax(int deptno) {
            
            //Buscar los datos del Empleado que viene en el parametro
            return PartialView(this.repo.GetEmpleado(deptno));
        }

        //public PartialViewResult BorrarEmpleadoAjax(int deptno)
        //{
            
        //    //Buscar los datos del Empleado que viene en el parametro
        //    //return PartialView(this.repo.GetEmpleado(deptno));
        //     return RedirectToAction("MostrarEmpleadosAjax");
        //}
    }
}