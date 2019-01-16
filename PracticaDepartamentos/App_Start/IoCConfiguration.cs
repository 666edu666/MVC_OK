using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using PracticaDepartamentos.Repositories;
using PracticaDepartamentos.Models;
using System.Web.Mvc;

namespace PracticaDepartamentos.App_Start
{
    public class IoCConfiguration
    {
        private static void RegistraControladores(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        private static void RegistraRepos(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryDepartamento>().As<IRepositoryDepartamento>().InstancePerRequest(); 
        }

        private static void RegistraClases(ContainerBuilder builder)
        {
            builder.Register(z => new HospitalContextSQL()).InstancePerRequest() ; 
        }

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegistraControladores(builder);
            RegistraRepos(builder);
            RegistraClases(builder);

            IContainer contenedor = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));
        }

    }
}