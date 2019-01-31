using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcepcionesControl.Filters
{
    public class FilterMensajesLogAttribute : ActionFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("OnActionExecuted => Action: " + accion+" Fecha: "+DateTime.Now+".");
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("OnActionExecuting => Action: " + accion + " Fecha: " + DateTime.Now + ".");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("OnResultExecuted => Action: " + accion + " Fecha: " + DateTime.Now + ".");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            String accion = filterContext.RouteData.Values["action"].ToString();
            log.Debug("OnResultExecuting => Action: " + accion + " Fecha: " + DateTime.Now + ".");
        }
    }
}