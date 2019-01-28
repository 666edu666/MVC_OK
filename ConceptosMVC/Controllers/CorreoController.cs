using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace ConceptosMVC.Controllers
{
    public class CorreoController : Controller
    {
        Repositories.RepositoryHospital repo;
        public AjaxController() { this.repo = new Repositories.RepositoryHospital(); }
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String destinatario, String asunto, String mensaje, String HttpPostedFile fichero)
        {
            MailMessage mail = new MailMessage();
            String cuenta = ConfigurationManager.AppSettings["correo"];
            String pass = ConfigurationManager.AppSettings["password"];
            mail.From = new MailAddress();
            mail.To.Add(destinatario);
            mail.Subject=asunto;
            mail.Body = mensaje;

            String ruta = Server.MapPath("../Temporal");

            fichero.SaveAs(ruta+"\\" + fichero.FileName);
            Attachment adjunto = new Attachment(ruta + "\\" + fichero.FileName);
            mail.Attachments.Add(adjunto);
            Smtp

            return View();
        }

    }

}