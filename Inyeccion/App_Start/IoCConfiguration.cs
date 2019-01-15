using Autofac;
using Autofac.Integration.Mvc;
using Inyeccion.IOC;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inyeccion.App_Start
{
    public class IoCConfiguration
    {
        //Por limpieza creamos esta clase.
        //Se llama desde Global.Asax, pero podríamos crearlo allí directamente
        public static void Configure()
        {
            //Necesitamos un constructor para el contenedor
            //Este constructor registrará todas las clases, views, controllers y personalizaDas
            ContainerBuilder builder = new ContainerBuilder();

            //Registramos los controladores
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Registramos las vsitas NO ES NECESARIO
            builder.RegisterSource(new ViewRegistrationSource());

            //Registramos las clases personalizadas
            builder.RegisterModule(new IoCModule());

            //Para la interfaz
            IoCModule.RegistrarRepos(builder);

            //Creamos el contenedor con el cosntructor (builder)
            IContainer contenedor = builder.Build();

            //Indicamos a nuestra aplicacion MVC que contenedor utilizamos para DI e IoC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));

            
        }
    }
}