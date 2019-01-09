using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class EmpleadosController : Controller
    {
        HelperEmpleados helper;

        public EmpleadosController()
        {
            this.helper = new HelperEmpleados();
        }


        // GET: EmpleadosOficio
        public ActionResult EmpleadosOficio()
        {
            List<String> oficios = helper.GetOficios();
            ViewBag.Oficios = oficios;
            return View();
        }

        [HttpPost]
        public ActionResult EmpleadosOficio(String ofi)
        {
            List<String> oficios = helper.GetOficios();
            List<EMP> empleados = this.helper.GetEmpleadosOficio(ofi);

            ResumenEmpleados resumen = this.helper.GetResumenEmpleados(ofi);
            ViewBag.Oficios = oficios;
            ViewBag.Resumen = resumen;
            return View(empleados);

        }



        public ActionResult EmpleadosDepartamento()
        {
            ViewBag.Departamentos = this.helper.GetDepartamentos();
            return View();
        }

        [HttpPost]

        public ActionResult EmpleadosDepartamento(String dept)
        {
            ViewBag.Departamentos = this.helper.GetDepartamentos();
            List<EMP> empleados = this.helper.GetEmpleadosDepartamento(int.Parse(dept));

            ResumenEmpleados resumen = this.helper.GetResumenEmpleados(dept);
            
            ViewBag.Resumen = resumen;
            return View(empleados);

        }


        public ActionResult Index()
        {          
            return View();
        }


        //ORDENAR EMPLEADOS//

        public ActionResult ListaEmpleados(int? id)
        {

            if (id==null)
            {
                id = 1;
                ViewBag.OrdenSal = 3;
            }

            if (id==0)
            {
                ViewBag.OrdenApe = 1;
            }
            else if (id==1)
            {
                ViewBag.OrdenApe = 0;
            }

            else if (id == 2)
            {
                ViewBag.OrdenSal = 3;
            }
            else if (id == 3)
            {
                ViewBag.OrdenSal = 2;
            }


            List <EMP> empleados = this.helper.GetEmpleados(id.GetValueOrDefault());

            ViewBag.Empleados = empleados;
            return View();
        }

        public ActionResult PaginarEmpleadosInfo(int? posicion)
        {
            if (posicion==null)
            {
                posicion = 1;
            }
            ViewBag.Siguiente = posicion + 1;
            ViewBag.Anterior = posicion - 1;

            //El último se suele hacer con un parámetro de salida en el mismo procedimiento que uso para la paginación
            //Pero en este caso vamos a usar otro método.
            ViewBag.Ultimo = this.helper.GetNumeroEmpleados();

            if (ViewBag.Anterior < 1)
            {
                ViewBag.Anterior = 1;
            }
            else if(ViewBag.Siguiente > ViewBag.Ultimo)
            {
                ViewBag.Siguiente = ViewBag.Ultimo;
            }

            ViewBag.Mensaje = "Registro " + posicion +" de "+ ViewBag.Ultimo;

            return View(this.helper.GetEmpleadosInfo(posicion.GetValueOrDefault()));
        }
    }
}