 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class CifradoController : Controller
    {
        // GET: Cifrado
        public ActionResult CrifrarTexto()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult CrifrarTexto(String texto,String resultado, String accion)
        {
            String cifrado = this.cifrado(texto);
            if (accion.ToUpper() == "CIFRAR")
            {
                ViewBag.Resultado = cifrado;
            }
            else {//Comparar
                if (cifrado == resultado)
                {
                    ViewBag.Mensaje = "Los datos son iguales";
                }
                else {
                    ViewBag.Mensae = "Los datos son DIFERENTES";
                }
            }
            return View();
        }
        public String cifrado(String texto) {
            byte[] entrada;
            byte[] salida;

            UnicodeEncoding encoding = new UnicodeEncoding();

            //Convertimos el texto a bytes
            entrada = encoding.GetBytes(texto);

            SHA1Managed objCifrado = new SHA1Managed();

            //mediante el objeto de cifrado, convertimos a nivel de byte

            salida = objCifrado.ComputeHash(entrada);

            //Convertimos los bytes a texto
            String resultado = encoding.GetString(salida);
            return resultado;
        }

        public ActionResult CifradoSalt() {

            return View();
        }
        [HttpPost]
        public ActionResult CifradoSalt(String texto, String accion, String salt, String resultado,int vueltas)
        {
            string textocompleto = texto + salt;
            //DECLARAMOS EL OBJETO SHA256
            SHA256Managed objsha = new SHA256Managed();
            byte[] bytesalida = null;

            bytesalida =Encoding.UTF8.GetBytes(textocompleto);
            //ENCRIPTAMOS EL TEXTO 1000 VECES
            for (int i = 0; i < vueltas; i++) {
                bytesalida = objsha.ComputeHash(bytesalida);
            }
            String cifrado = Convert.ToBase64String(bytesalida);

            if (accion.ToUpper() == "CIFRAR")
            {
                ViewBag.Resultado = cifrado;
            }
            else
            {//Comparar
                if (cifrado == resultado)
                {
                    ViewBag.Mensaje = "Los datos son iguales";
                }
                else
                {
                    ViewBag.Mensae = "Los datos son DIFERENTES";
                }
            }

            return View();
        }
    }
}