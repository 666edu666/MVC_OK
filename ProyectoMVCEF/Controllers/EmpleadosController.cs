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

        public ActionResult ParametrosSalida()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ParametrosSalida(int departamento)
        {
            ResumenEmpleados resumen = this.helper.GetResumenParametrosSalida(departamento);
            return View(resumen);
        }

        public ActionResult paginarGrupo(int? posicion)
        {
            if (posicion ==null)
            {
                posicion = 1;
            }

            int numeroPagina = 1;
            String html = "";
            //Esta variable la envío al Helper por REFERENCIA. De esta manera al cambiar el valor 
            //   en el helper puedo recoger el valor cuando la llame desde aquí
            int totalRegistros = 0;

            List<paginar_empleados_grupo_Result> emp = this.helper.GetEmpleadosGrupo(posicion.GetValueOrDefault(), ref totalRegistros);

            for (int i=1; i<=totalRegistros; i+=3)
            {
                html += "<a href='PaginarGrupo?posicion=" + i + "'>" + numeroPagina + "</a>";
                numeroPagina += 1;
            }
            ViewBag.CadenaPaginacion = html;
            return View(emp);
        }

        public ActionResult PaginacionDoctorPlantillaEmpleado(int? posicion, int? salario)
        {
            int totalRegistros = 0;
            if (posicion==null)
            {
                posicion = 1;
            }
            if (salario == null)
            {
                salario = 0;
            }
            List<paginarDoctorPlantillaEmpleado_Result> emp =
                this.helper.PaginacionDoctorPlantillaEmpleado(posicion.GetValueOrDefault(), salario.GetValueOrDefault(), ref totalRegistros);

            int numeroPagina = 1;
            String html = "";
            for (int i = 1; i <= totalRegistros; i += 3)
            {
                html += "<a href='PaginacionDoctorPlantillaEmpleado?posicion=" + i + "&salario=" + salario.GetValueOrDefault() + "'>" + numeroPagina + "</a> | ";
                numeroPagina += 1;
            }
            ViewBag.CadenaPaginacion = html;
            ViewBag.total = totalRegistros;
            return View(emp);
        }

        [HttpPost]
        public ActionResult PaginacionDoctorPlantillaEmpleado(int? posicion, int? salario, int? aux)
        {
            #region procedure 
                //create procedure paginarDoctorPlantillaEmpleado(@salario int, @posicion int, @totalRegistros int out)
                //as
                //    select @totalRegistros = max(posicion) from
                //      (
                //          SELECT   ROW_NUMBER()over(order by apellido) as posicion, *FROM
                //          (
                //              select   PLANTILLA.APELLIDO as apellido, PLANTILLA.FUNCION, PLANTILLA.SALARIO from PLANTILLA where PLANTILLA.SALARIO > @salario

                //                  union

                //              select  DOCTOR.APELLIDO as apellido, DOCTOR.ESPECIALIDAD, DOCTOR.SALARIO from DOCTOR where DOCTOR.SALARIO > @salario

                //                  union

                //              select   EMP.APELLIDO as apellido, EMP.OFICIO, EMP.SALARIO from EMP where EMP.SALARIO > @salario

                //          )consulta1
                //      )consulta2


                //        select* from
                //        (
                //            SELECT ROW_NUMBER () over (order by apellido) as posicion,*FROM
                //           (
                //                   select   PLANTILLA.APELLIDO as apellido, PLANTILLA.FUNCION, PLANTILLA.SALARIO from PLANTILLA where PLANTILLA.SALARIO > @salario

                //                       union

                //                   select  DOCTOR.APELLIDO as apellido, DOCTOR.ESPECIALIDAD, DOCTOR.SALARIO from DOCTOR where DOCTOR.SALARIO > @salario

                //                       union

                //                   select   EMP.APELLIDO as apellido, EMP.OFICIO, EMP.SALARIO from EMP where EMP.SALARIO > @salario

                //           )consulta1
		              //  )consulta2 where  posicion >= @posicion and posicion< (@posicion+3) 	
                //go
            #endregion
            int numeroPagina = 1;
            String html = "";
            if (posicion==null)
            {
                posicion = 1;
            }
            if (salario==null)
            {
                salario = 0;
            }
            int totalRegistros = 0;
            List<paginarDoctorPlantillaEmpleado_Result> emp =
                this.helper.PaginacionDoctorPlantillaEmpleado(posicion.GetValueOrDefault(), salario.GetValueOrDefault(), ref totalRegistros);

            for (int i = 1; i <= totalRegistros; i += 3)
            {
                html += "<a href='PaginacionDoctorPlantillaEmpleado?posicion=" + i + "&salario="+salario.GetValueOrDefault()+"'>" + numeroPagina + "</a> | ";
                numeroPagina += 1;
            }
            ViewBag.CadenaPaginacion = html;
            ViewBag.total = totalRegistros;
            return View(emp);

        }

        public ActionResult PaginacionViewEntidad(int? cantidad, int?indice)
        {
            if (cantidad==null)
            {
                cantidad = 3;
            }
            if (indice==null)
            {
                indice = 1;
            }
            int totalRegistros = 0;
            List<todosEmpleados> miLista = 
                this.helper.paginacionViewEntidad(cantidad.GetValueOrDefault(),
                                                    indice.GetValueOrDefault(),
                                                    ref totalRegistros);
            ViewBag.Total = totalRegistros;
            ViewBag.PaginaActual = indice;
            ViewBag.Cantidad = cantidad;
            return View(miLista);
        }

        public ActionResult SeleccionMutiple()
        {
            List<DEPT> departamentos = this.helper.GetDepartamentos();

            ViewBag.Departamentos = departamentos;
            return View();
        }

        [HttpPost]
        //int[]departamento es porque viene de un select múltiple
        public ActionResult SeleccionMutiple(int[] departamento)
        {
            List<DEPT> departamentos = this.helper.GetDepartamentos();

            ViewBag.Departamentos = departamentos;
            List<EMP> empleados = this.helper.GetEmpleadosDepartamentoMultiple(departamento);
            return View(empleados);
        }
    }
}