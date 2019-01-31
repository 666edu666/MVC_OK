using ExcepcionesControl.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcepcionesControl.App_Start
{
    public class FilterConfig
    {
        //Tendra un metodo para registrrar todos los filtros que utilice,
        //en nuestra aplicacion

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            //Registramos filtros para atributos de excepcion
            filters.Add(new HandleErrorAttribute());
            //Registramos nuestro filtro de excepciones
            filters.Add(new HandleExceptionDoctorAttribute());
            //Al registrarlo en el sistema voy a tener ese filtro en todas
            //las acciones al sistema
            filters.Add(new FilterMensajesLogAttribute()); 
        }
    }
}