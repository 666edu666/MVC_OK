using RepositorioHospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InyeccionBBDD.Controllers
{
    public class DepartamentosController : Controller
    {
        IRepositoryDepartamentos repo;
        // GET: Departamentos

        public DepartamentosController(IRepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public ActionResult Index()
        {
            return View(this.repo.GetDepartamentos());
        }
    }
}