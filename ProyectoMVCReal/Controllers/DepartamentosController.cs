using ProyectoMVCReal.Helper;
using ProyectoMVCReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCReal.Controllers
{
    public class DepartamentosController : Controller
    {
        // GET: Departamentos
        HelperDepartamento h;

        public ActionResult Index()
        {
            this.h = new HelperDepartamento();
            List<Departamento> listaDepartamentos = this.h.GetDepartamentos();

            return View(listaDepartamentos);
        }


        public ActionResult BuscarDepartamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarDepartamento(int deptno)
        {
            this.h = new HelperDepartamento();
            Departamento d = h.BuscarDepartamento(deptno);
            if (d !=null)
            {
                ViewBag.Error = "No se ha encontrado el departamento";
            } 
            return View(d);
        }

        //numero viene por GET en le URL
        public ActionResult DetalleDepartamento(int numero)
        {
            this.h = new HelperDepartamento();
            Departamento dept = this.h.BuscarDepartamento(numero);
            return View(dept);
        }

    }
}