using InyeccionEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InyeccionEntity.Controllers
{
    public class HospitalesController : Controller
    {
        IRepositoryHospital repo;

        //Inyeccion de dependencias
        //Inyecto la interfac "abstracta" para poder luego desde el IoCConfiguration.RegistrarRepos
        //Le puedo mandar el repositoryHospital, repositoryHospitalJson, repositoryHospitalOracle...
        public HospitalesController(IRepositoryHospital repo) 
        {
            this.repo = repo;
        }
        // GET: Hospitales
        public ActionResult Index()
        {
            return View(repo.GetHospitales());
        }
    }
}