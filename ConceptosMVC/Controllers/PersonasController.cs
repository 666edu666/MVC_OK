using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetallesPersona()
        {
            List<Persona> listapersonas = new List<Persona>();
            Persona p = new Persona("Carlos", "Tormo", 30, "Futbol");
            listapersonas.Add(p);
            p = new Persona("Alejandro", "Gutierrez", 34, "Padel");
            listapersonas.Add(p);
            p = new Persona("Pedro", "Casales", 35, "Running");
            listapersonas.Add(p);
            p = new Persona("Adrian", "Ramos", 18, "Atletismo");
            listapersonas.Add(p);
            p = new Persona("Fran", "Sanchez", 33, "Rugby");
            listapersonas.Add(p);
            p = new Persona("Lucia", "Serrano", 12, "Curling");
            listapersonas.Add(p);

           
            return View(listapersonas);
        }
    }
}