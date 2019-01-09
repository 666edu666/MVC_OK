using ProyectoMVCReal.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCReal.Controllers
{
    public class DeptLinqController : Controller
    {
        // GET:Index
        HelperLinqDepartamentos helper;

        public DeptLinqController()
        {
            this.helper = new HelperLinqDepartamentos();
        }
        public ActionResult Index()
        {            
            return View(this.helper.GetDepartamentos());
        }

        public ActionResult BuscarLocalidad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarLocalidad(String loc)
        {            
            return View(this.helper.BuscarDepartamento(loc));
        }


        public ActionResult InsertarDepartamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertarDepartamento(String localidad, int numero, String nombre)
        {
            ViewBag.Mensaje ="Departamento insertado correctamente";
            this.helper.InsertaDepartamento(numero,nombre, localidad);
            return View();
        }

        public ActionResult EliminarDepartamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EliminarDepartamento(int deptno)
        {
            if (this.helper.EliminarDepartamento(deptno)==1){
                ViewBag.Mensaje = "Departamento borrado";
            }
            else
            {
                ViewBag.Mensaje = "No existe el departamento";
            }            
            return View();
        }

        public ActionResult ModificarDepartamento()
        {
            
            return View(this.helper.GetLocalidades());
        }

        [HttpPost]
        public ActionResult ModificarDepartamento(String oldLoc, String newLoc)
        {
            if (this.helper.ModificarDepartamento(oldLoc, newLoc) == 0)
            {
                ViewBag.Mensaje = "No se encuentran departamentos con la localidad " + oldLoc;
            }
            else
            {
                ViewBag.Mensaje = " La localidad de los departamentos se ha modificado correctamente";
            }            
            return View(this.helper.GetLocalidades());
        }
    }
}