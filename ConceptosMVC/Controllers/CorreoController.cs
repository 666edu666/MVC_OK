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
        public CorreoController() { this.repo = new Repositories.RepositoryHospital(); }
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String destinatario, String asunto, String mensaje, 
            HttpPostedFile fichero)
        {
            //este es el propio mail
            MailMessage mail = new MailMessage();
            String cuenta = ConfigurationManager.AppSettings["correo"];
            String password = ConfigurationManager.AppSettings["password"];
            mail.From = new MailAddress(cuenta);
            mail.To.Add(destinatario);
            mail.Subject = asunto;
            mail.Body = mensaje;
            //necesitamos enviar adjuntos
            //para ello vamos a subir los adjuntos a nuestro servidor
            //necesitamos la ruta fisica de nuestro servidor
            String ruta = Server.MapPath("../Temporal");
            //para guardarlo
            
            fichero.SaveAs(ruta + "\\" + fichero.FileName);
            Attachment adjunto = new Attachment(ruta + "\\" + fichero.FileName);
            mail.Attachments.Add(adjunto);
            //se crea el cliente que mandara el objeto y se configura
            SmtpClient cliente = new SmtpClient();
            cliente.Host = "smtp.gmail.com";
            cliente.Port = 25;
            cliente.EnableSsl = true;
            cliente.UseDefaultCredentials = true;
            cliente.Credentials = new NetworkCredential(cuenta, password);
            cliente.Send(mail);
            ViewBag.Mensaje = "Correo enviado";

            return View();
        }

    }

}