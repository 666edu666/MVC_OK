using SeguirdadEmpleados.Atributos;
using SeguridadEmpleados.Model;
using SeguirdadEmpleados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeguirdadEmpleados.Controllers
{
    [AutorizacionEmpleados]
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;

        public EmpleadosController(){
            this.repo = new RepositoryEmpleados();
        }
        // GET: Empleados
        public ActionResult Index()
        {
            //Recuperar al usuario => Session
            //HttpContext.User.IsInRole
            int empno = ((Empleado)HttpContext.User).IdEmpleado;
            List<Empleado> empleados = this.repo.GetEmpleadosSubordinados(empno);
            return View(empleados);
        }

    }
}