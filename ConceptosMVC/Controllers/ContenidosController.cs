using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConceptosMVC.Models;

namespace ConceptosMVC.Controllers
{
    public class ContenidosController : Controller
    {

        HelperDepartamento helper;
        public ContenidosController()
        {
            this.helper = new HelperDepartamento();
        }
        // GET: Contenidos

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContenidoContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContenidoContent(String video)
        {
            int posicion = video.IndexOf("v=");
            String idvideo = video.Substring(posicion + 2);
            return Content("<iframe width='560' height='315' src = 'https://www.youtube.com/embed/" + idvideo + "' frameborder = '0'allowfullscreen ></ iframe > ");

        }

        public ActionResult ContenidoJavascript()
        {
            return View();
        }
        public ActionResult CodigoJavascript()
        {
            //Devolvemos el contenido mediante un Script de JavaScript
            String imagen = Url.Content("~/Images/2.png");
            String script = "$('#imagen').attr('src', '" + imagen + "');";
            return JavaScript(script);

        }

        public ActionResult ContenidoFile()
        {


            String ruta = Url.Content("~/Images/1.png");

            //Se supone que si el tipo "FormatoInventado" no es un tipo reconocido para poder ser interpretado por el navegador
            // se descarga para que el usuario lo abra con alguna app propia

            //El motor de firefox lo interpreta directamente porqeu ES MU LISTO
            return File(ruta, "FormatoInventado");
        }

        public ActionResult ContenidoJson()
        {
            Personaje p = new Personaje();
            p.Nombre = "NOMBRE";
            p.Edad = "12";
            p.Apellido = "APELLIDO";
            //Deuelve un objerto PERSONAJE en formato JSON
            return Json(p, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Departamentos()
        {
            
            return View(this.helper.GetDepartamentos());
        }

        [HttpPost]
        public ActionResult Departamentos(int departamento)
        {
            Departamento d =
            this.helper.GetDepartamento(departamento);
            Console.WriteLine("CODIGO DEL DEPT SELECCIONADO ===>"+d.Numero);

            //Mando el objeto departamento al CONTROLADOR UpdateDepartamento
            return RedirectToAction("UpdateDepartamento", d);
        }

        public ActionResult UpdateDepartamento(Departamento d)
        {
            ViewBag.Mensaje = d.Numero;
            return View(d);
        }

        [HttpPost]
        public ActionResult UpdateDepartamento(Departamento d, String a){
            ViewBag.Mensaje = d.Numero;
            if (ModelState.IsValid)
            {
                this.helper.ModificarDepartamento(d.Numero,d.Nombre,d.Localidad);
                ViewBag.Mensaje = "Se ha modificado correctamente.";
                //Aquí está validado correctamente
                return View( d);
            }
            else
            {
                //Alguna validación es incorrecta
                ViewBag.Mensaje = "No se ha podido modificar porque los campos no cumplen los requisitos.";
                return View(d);
            }
        }

        public ActionResult insertaDepartamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertaDepartamento(int deptNo, String deptNombre, String deptLocalidad)
        {
            this.helper.InsertarDepartamento(deptNo,deptNombre,deptLocalidad);
            ViewBag.Mensaje = "Departamento insertado correctamente";
            return View();
        }
    }
}