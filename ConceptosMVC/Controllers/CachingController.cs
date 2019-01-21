using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConceptosMVC.Controllers
{
    public class CachingController : Controller
    {
        // GET: Caching
        //[OutputCache(Duration =5,VaryByParam ="dato"),VaryByParam ="dato", System.Web.UI.OutputCacheLocation =System.Web.UI.OutputCacheLocation.Server] //EN SEGUNDOS

        [OutputCache(CacheProfile ="perfil1")] //Con esto le digo que coja la conf que se encuentra en WEb.Config


    //<caching>
    //  <outputCacheSettings>
    //    <outputCacheProfiles>
    //      <add name = "perfil1" duration="1"/>
    //      <add name = "perfil2" duration="2"/>
    //    </outputCacheProfiles>
    //  </outputCacheSettings>
    //</caching>

        public ActionResult HoraSistema(String dato)
        {
            ViewBag.Hora = "Fecha " + DateTime.Now.ToLongDateString() + ".Hora: " + DateTime.Now.ToLongTimeString();
            return View();
        }
    }
}