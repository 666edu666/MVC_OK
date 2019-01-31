using ExcepcionesControl.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExcepcionesControl.Filters

{
    public class HandleExceptionDoctorAttribute : FilterAttribute, IExceptionFilter
    {
        //En algún momento nos llevaremos los datos a una vista de errores en doctor
        public void OnException(ExceptionContext filterContext)
        {
            //Vamos a insertar en excepciones en sqlServer

            if (filterContext.ExceptionHandled == false)
            {
                String mensaje = filterContext.Exception.Message;
                String controlador = filterContext.RouteData.Values["controller"].ToString();
                HospitalRepository repo = new HospitalRepository();
                repo.InsertarExcepcion(mensaje, controlador, DateTime.Now);


                //Para que las excepciones las controle yo y no me pare la app
                filterContext.ExceptionHandled = true;

                RouteValueDictionary ruta = new RouteValueDictionary(
                    new { controller = "Doctores", action = "ErrorSalarios" });

                RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);

                filterContext.Result = direccion;
            }
            else {
                //Aqui son la excepciones que yo no controlo, como 404 o 1/0
            }
        }
    }
}