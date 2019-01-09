using ProyectoLinQ.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace ProyectoLinQ.Controllers
{

    
    public class IndexController : Controller
    {

        HelperHospital help;
        // GET: Index



        public IndexController() {
            this.help = new HelperHospital();
        }

        public ActionResult Index()
        {
            
            ViewBag.Oficios=this.help.GetOficios();
            return View(this.help.GetEmpleados());
        }

        [HttpPost]
        public ActionResult Index(String oficios, int incremento)
        {
            ViewBag.Oficios = this.help.GetOficios();
            ViewBag.Numero=this.help.ModificarEmpleados(oficios,incremento);
            return View(this.help.GetEmpleadosOficio(oficios));
        }


        [WebMethod]        

        public JsonResult CargaTabla(JsonResult oficio)
        {
            Debug.WriteLine("Datos recibidos del cliente AJAX:"+oficio);
            
            return Json("'Success':'true'");
        }


        public ActionResult Departamentos()
        {
            ViewBag.Depart= this.help.GetDepartamentos();
            return View();
        }
        [HttpPost]
        public ActionResult Departamentos(int select)
        {
            ViewBag.Depart = this.help.GetDepartamentos();
            return View(this.help.GetEmpleadosDepartamento(select));
        }

    }
}