using RepositorioHospital.Contexts;
using RepositorioHospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace InyeccionBBDD.App_Start
{

    //Otra forma de hacer la Inyeccion de dependencias 
    public class IoCConfigurationUnity
    {
        public static void Configure()
        {
            UnityContainer container = new UnityContainer();
            RegistrarContextos(container);
            RegistrarRepos(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegistrarContextos(UnityContainer container)
        {
            container.RegisterType<IHospitalContext, HospitalContextSQL>();
        }
        public static void RegistrarRepos(UnityContainer container)
        {
            //container.RegisterType<interface,Clase>
            container.RegisterType<IRepositoryDepartamentos, RepositoryDepartamentos>();
        }
        

    }
}