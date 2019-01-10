using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InformacionController : Controller
    {
        // GET: Informacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ControladorVista()
        {

            //Para enviar informacion a la vista dos formas: viewData y viewBag
            //Son el mismo objeto y no son son case sensitive
            //Permiten creaar propiedades dinámicas
            //ViewData["propiedad"]=valor
            //ViewBag.Propiedad=valor

            ViewData["MENSAJE"]= "Mensaje desde el controlador";
            ViewBag.Fecha = "12/12/2018";

            //Enviar objetoPersona VIEWBAG

            Persona person = new Persona();
            person.Apellidos = "Hurtado";
            person.Nombre = "José";
            person.Edad = "123";

            ViewBag.Persona = person;
            return View();
        }

        public ActionResult ControladorVistaModel()
        {

            Persona person = new Persona();
            person.Apellidos = "Norris";
            person.Nombre = "Chuck";
            person.Edad = "60";

            
            //Una vista solamente reibe un modelo
            //El modelo estará tipado en la vista
            //Se envía al devolver la vista
            //@model DECLARAR
            //@Model UTILIZAR


            return View(person);
        }

        //La información se recibe como parámetros. El nombre de los param 

//Las varaiables primitivas, como INT no puede ser null. Para ello usamos System.Nullable <tipo>
//lo que permite es que pueda ser null. Es igual que poner TipoPrimitivo? ejemplo: int? numero;
        public ActionResult VistaControladorGet
            //(System.Nullable<int> nombre)
            (int? edad, String nombre)
            //(int nombre)
        {
            ViewBag.Nombre = nombre;
            ViewBag.Edad = edad;

            return View();
        }

        //
        
        public ActionResult VistaControladorPost()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult VistaControladorPost(String nombre, String edad)
        //{
        //    ViewBag.Mensaje = nombre + " " + edad;
        //    return View();
        //}

        [HttpPost]
        public ActionResult VistaControladorPost(Coche c)
        {
            ViewBag.Mensaje = "Coche salido del concesionario";
            return View(c);
        }
    }
}