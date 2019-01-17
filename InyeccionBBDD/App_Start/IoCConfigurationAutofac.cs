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
            //Para registrar sin interface
            //builder.Register (z= new EntidaEmpeados()).InstancePerRequest)
            builder.Register(z => new HOSPITALEntities1()).InstancePerRequest();
            //builder.RegisterType<HOSPITALEntities1>().As<IHospitalEntities1>().InstancePerRequest();


            //Para qe HospitalContext venga del SQL
            builder.RegisterType<HospitalContextSQL>().As<IHospitalContext>().InstancePerRequest();

            //Para qe HospitalContext venga del MYSQL
            //builder.RegisterType<HospitalContextMysql>().As<IHospitalContext>().InstancePerRequest();

            //Para qe HospitalContext venga del ORACLE
            //builder.RegisterType<HospitalContextOracle>().As<IHospitalContext>().InstancePerRequest();

        }
        public static void RegistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryDepartamentos>().As<IRepositoryDepartamentos>().InstancePerRequest();
            builder.RegisterType<RepositoryEmpleados>().As<IRepositoryEmpleados>().InstancePerRequest();
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