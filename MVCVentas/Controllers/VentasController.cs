using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCVentas.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String usuario, String password)
        {
            if (usuario == "admin" && password=="admin")
            {
                //usuario logueado correctamente

                //EN SESSION SOLO SE GUARDA EL USUARO REGISTRADO, NO METER NADA M´SA POR RENDIMIENTO.

                Session["USUARIO"] = usuario;
                return RedirectToAction("Productos");
            }
            else
            {
                ViewBag.Mensaje = "Usuario y contraseñe no coinciden ";
                return View();
            }
            
        }

        public ActionResult Productos()
        {
            if (Session["USUARIO"]==null) {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Productos (String [] producto, String direccion)
        {
            //Cuando el usuario ha comprado, lo llevamos a pedidios para visualizar sus compras
            String datos = "<ul>";
            foreach (String prod in producto)
            {
                datos += "<li>" + prod + "</li>";
            }
            datos += "</ul>";

            datos += "<h2>Le enviaremos los datos a "+ direccion+"</h2> Gracias por confiar en nosotros";

            //La variable TEMPDATA pasa info de un ACTIOn a otro. CUANDO SE LEE SE DESTRUYE
            TempData["DATOS"] = datos;
            return RedirectToAction("Pedidos");
        }

        public ActionResult Pedidos() {
            if (Session["USUARIO"] == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Mensaje = TempData["DATOS"];
            return View();
        }
    }
}