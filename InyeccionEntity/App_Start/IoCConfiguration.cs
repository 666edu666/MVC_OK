using Autofac;
using Autofac.Integration.Mvc;
using InyeccionEntity.Models;
using InyeccionEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace InyeccionEntity.App_Start
{
    public class IoCConfiguration
    {
        /*Vamos a registarr los controladores, las interfaces y las clases propias*/
        private static void RegistrarControladores (ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        private static void RegistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryHospital>().As<IRepositoryHospital>().InstancePerRequest();
        }

        private static void RegistrarClases(ContainerBuilder builder)
        {
            //Registramos los contextos de los que depende un repositorio
            builder.Register(z=> new HospitalContext()).InstancePerRequest();
        }

        public static void Configure()
        {
            //Creamos el constructor del contenedor
            ContainerBuilder builder = new ContainerBuilder();
            RegistrarControladores(builder);
            RegistrarRepos(builder);
            RegistrarClases(builder);
            //Construimos el contenedor
            IContainer contenedor = builder.Build();

            //indicamos a mvc que contenedor utilizará para la inyeccion de dependencias
            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));

        }
    }
}