using PracticasMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticasMVC.Models
{
    public class ModulesController : Controller
    {
        // GET: SumarNumeros
        public ActionResult SumarNumerosView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SumarNumerosView(int n1, int n2)
        {
            Operaciones c = new Operaciones(n1, n2);
            ViewBag.Mensaje = "ESTOY EN POST";
            return View(c);
        }

        public ActionResult DobleRandomView()
        {
            Random rd = new Random();
            ViewBag.rand = rd.Next();
            return View();
        }

        [HttpPost]
        public ActionResult DobleRandomView(int n)
        {
            ViewBag.Mensaje = "ESTOY EN POST";
            Doble d = new Doble(n);
            return View(d);
        }


        public ActionResult TablaMultiplicarView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TablaMultiplicarView(int num)
        {
            ViewBag.Mensaje = "ESTOY EN POST";
            TablaMultipicar t = new TablaMultipicar(num);
            ViewBag.n = num;
            return View(t);
        }

        public ActionResult TablaMultiplicarObjeto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TablaMultiplicarObjeto(int num)
        {
            ViewBag.Mensaje = "ESTOY EN POST";
            TablaMultipicar t = new TablaMultipicar(num);
            ViewBag.n = num;
            return View(t);
        }
        public ActionResult TablaMultiplicarHTMLView()
        {
            return View();
        }


        [HttpPost]
        public ActionResult TablaMultiplicarHTMLView(int? num)
        {
            String html = "<table class='table table-borderer'>";

            for (int i = 1; i < 11; i++)
            {
                int resultado = num.Value * i;
                html += "<tr>";
                html += "<td>" + num + "*" + i + "</td>";
                html += "<td>" + resultado + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            ViewBag.html = html;
            return View();
        }

        public ActionResult VideosYoutubeView()
        {
            return View();
        }


        [HttpPost]
        public ActionResult VideosYoutubeView(String cad)
        {

            //Introduciendo el código se carga el video

            String html = "<iframe width='560' height='315' src='https://www.youtube.com/embed/";

             //cad = SXUJGlXxKSI
            html += cad;
            html +=  "' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";

            ViewBag.res = html;
            return View();
        }

        HelperVideo help = new HelperVideo();
        HelperVimeo helpVim = new HelperVimeo();
        public ActionResult VideosYoutubeModeloView()
        {
            ViewBag.lista = helpVim.VideosVimeo(); 
            return View();
        }

        [HttpPost]
        public ActionResult VideosYoutubeModeloView(String cod)
        {
            //Introduciendo el código se carga el video
            
            ViewBag.res = helpVim.GetCodigoHTMLVimeo(cod);
            ViewBag.lista = helpVim.VideosVimeo();
            return View();
        }
    }
}