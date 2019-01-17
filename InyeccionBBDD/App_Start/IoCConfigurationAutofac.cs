using Autofac;
using Autofac.Integration.Mvc;
using RepositorioHospital.Contexts;
using RepositorioHospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace InyeccionBBDD.App_Start
{
    public class IoCConfigurationAutofac
    {
        public static void RegistrarControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
        public static void RegistrarContextos(ContainerBuilder builder)
        {
            builder.RegisterType<HospitalContextSQL>().As<IHospitalContext>().InstancePerRequest();

        }
        public static void RegistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryDepartamentos>().As<IRepositoryDepartamentos>().InstancePerRequest();
        }

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegistrarControllers(builder);
            RegistrarContextos(builder);
            RegistrarRepos(builder);

            IContainer contenedor = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));
        }
    }
}