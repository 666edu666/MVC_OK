using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPruebasUnitarias.Controllers;

namespace ProyectoPruebasUnitarias.Tests.Controllers
{
    [TestClass]
    public class PersonasControllerTest
    {
        [TestMethod]
        public void MostrarPersonas()
        {
            PersonasController controller = new PersonasController();

            //Para saber si el método MostrarPresonas es un View. 


            //Todo lo que yo pregunte desde result es lo que ha llegado a la vista
            ViewResult result = controller.MostrarPersonas() as ViewResult;           
            Assert.IsNotNull(result); // 


            //Tiene la vista result un modelo ¿?
            var datos = result.Model;
            Assert.IsNotNull(datos);

        }
    }
}
