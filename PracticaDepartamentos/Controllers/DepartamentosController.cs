using PracticaDepartamentos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        IRepositoryDepartamento repo;
        public DepartamentosController(IRepositoryDepartamento repo)
        {
            this.repo = repo;
        }
        // GET: Departamentos
        public ActionResult Index()
        {
            return View(this.repo.GetDepartamentos());
        }
    }
}