using ProyectoMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVCEF.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        HelperDoctores helper;

        public DoctorController()
        {
            this.helper = new HelperDoctores();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult paginaDoctores(int? id)
        {

            return View();
        }
    }
}