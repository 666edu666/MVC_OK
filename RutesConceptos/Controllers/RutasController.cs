using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RutesConceptos.Controllers
{
    public class RutasController : Controller
    {
        // GET: Rutas
        public ActionResult Index()
        {
            RouteValueDictionary ruta = RouteData.Values;

            String html = "";

            //Recorro las KEYS que hay dentr de la ruta de la petición que ha llegado a este controller
            foreach (String key in ruta.Keys)
            {
                String valor = ruta[key].ToString();
                html += "<p><b>" + key + ":</b>" + valor + "</p>";
            }
            //Este objeto envia una cadena interpretada por el navegador
            MvcHtmlString htmlstring = new MvcHtmlString(html);

            ViewBag.Rutas = htmlstring;
            return View();
        }

        public ActionResult Buscar()
        {
            String tipoaccion = RouteData.Values["tipoaccion"].ToString();
            String iddato = RouteData.Values["iddato"].ToString();

            String resultado = String.Empty;

            switch (tipoaccion.ToLower())
            {
                case "peliculas":
                    {
                        switch (iddato.ToLower())
                        {
                            case "regreso al futuro":
                                {
                                    resultado = "Disponibles 5";
                                    break;
                                }
                            case "avatar":
                                {
                                    resultado = "Disponible 7";
                                    break;
                                }
                            default:
                                {
                                    resultado = "La película " + iddato + " no existe en stock";
                                    break;
                                }
                        }
                        break;
                    }
                case "comics":
                    {
                        switch (iddato.ToLower())
                        {
                            case "batman":
                                {
                                    resultado = "Disponibles 4 unidades.";
                                    break;
                                }
                            case "lobezno":
                                {
                                    resultado = "Disponibles 12 unidades.";
                                    break;
                                }
                            default:
                                {
                                    resultado = String.Format("El comic " + iddato + " no existe en stock");
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    break;
            }
            return Content("<h2 style='color:blueviolet'>" + resultado + "</h2>");
        }
    }
}