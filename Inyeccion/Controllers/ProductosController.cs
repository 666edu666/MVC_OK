using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inyeccion.Models;

namespace Inyeccion.Controllers
{

    //Si un objeto depende de otro se debe de inyectar => Patrón de programación DI
    public class ProductosController : Controller
    {
        IRepositoryProductos repo;
        public ProductosController(IRepositoryProductos repo)
        {
            this.repo = repo;
        }
        // GET: Productos
        public ActionResult Index()
        {

            return View(this.repo.GetProductos());
        }
    }
}