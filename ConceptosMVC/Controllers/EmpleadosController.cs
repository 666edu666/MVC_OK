using ConceptosMVC.Models;
using ConceptosMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;

        public EmpleadosController()
        {
            this.repo = new RepositoryEmpleados();
        }
        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AlmacenarSalarios(int? salario)
        {
            if (salario!=null)
            {
                if (Session["SALARIO"]==null)
                {
                    Session["SALARIO"] = salario;
                }
                else
                {    //Sumo el salario que había al que me han dado y lo vuelvo a meter en SESSION                 
                    Session["SALARIO"] = (int)Session["SALARIO"] + salario;
                    ViewBag.Salario = "Salario Recibido: " + Session["SALARIO"];
                }
            }
            
            return View(this.repo.GetEmpleados());
        }
        public ActionResult MostrarSalarios()
        {
            ViewBag.Total = Session["SALARIO"];
            return View();
        }

        public ActionResult AlmacenarEmpleados(int? empno)
        {

            //PREGUNTAMOS SI RECIBIMOS ID
            if (empno != null)
            {
                //EN LA SESION, ALMACENAREMOS UNA COLECCION CON LOS ID
                // DE TODOS LOS EMPLEADOS SELECCIONADOS

                List<int> codigoempleados;
                if (Session["EMPLEADOS"] == null)
                {
                    //CREAMOS LA NUEVA COLECCION DE EMPLEADOS
                    codigoempleados = new List<int>();

                }
                else
                {
                    codigoempleados = Session["EMPLEADOS"] as List<int>;
                }

                codigoempleados.Add(empno.Value);
                Session["EMPLEADOS"] = codigoempleados;

                ViewBag.Empleados = "Empleados almacenados: " + codigoempleados.Count;

            }
            return View(this.repo.GetEmpleados());
        }

        public ActionResult MostrarEmpleados()
        {
            if (Session["EMPLEADOS"] != null)
            {
                //RECUPERAMOS LA COLECCION DE LA SESSION
                List<int> codigos = (List<int>)Session["EMPLEADOS"];

                //BUSCAMOS LOS EMPLEADOS EN EL REPO
                List<Empleado> empleados = this.repo.BuscarEmpleadosSession(codigos);

                //DEVOLVEMOS LOS EMPLEADOS A LA VISTA
                return View(empleados);
            }

            return View();
        }

        public ActionResult AlmacenarEmpleadosComplejo(int? empno)
        {
            //PREGUNTAMOS SI RECIBIMOS ID
            if (empno != null)
            {
                //EN LA SESION, ALMACENAREMOS UNA COLECCION CON LOS ID
                // DE TODOS LOS EMPLEADOS SELECCIONADOS
                List<int> codigoempleados;
                if (Session["EMPLEADOS"] == null)
                {
                    //CREAMOS LA NUEVA COLECCION DE EMPLEADOS
                    codigoempleados = new List<int>();
                }
                else
                {
                    codigoempleados = Session["EMPLEADOS"] as List<int>;
                }
                codigoempleados.Add(empno.Value);
                Session["EMPLEADOS"] = codigoempleados;
                ViewBag.Empleados = "Empleados almacenados: " + codigoempleados.Count;

                return View(this.repo.GetEmpleados());
            }
            else
            {
                return View(this.repo.GetEmpleados());
            }
            
        }
        public ActionResult MostrarEmpleadosComplejo( int? idEmp)
        {
            List<int> codigos = (List<int>)Session["EMPLEADOS"];
            List<Empleado> empleados = this.repo.BuscarEmpleadosSession(codigos);
            if (idEmp !=null)
            {
                codigos.Remove(idEmp.Value);
                codigos = (List<int>)Session["EMPLEADOS"];
                empleados = this.repo.BuscarEmpleadosSession(codigos);

                Session["EMPLEADOS"] = codigos;
                if (codigos.Count==0)
                {
                    Session["EMPLEADOS"] = null;
                }
                return View(empleados);

            }
            else
            {
                return View(empleados);
            }
            
        }

    }
}