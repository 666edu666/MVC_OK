using Autofac;
using Inyeccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inyeccion.IOC
{
    public class IoCModule :Module
    {
        //protected override void Load(ContainerBuilder builder)
        //{
        //    //Para registrar mi clase personalizada
        //    builder.Register(z=> new RepositoryProductos()).InstancePerRequest();
            
        //    //Tengo que registrar una a una

        //    base.Load(builder);
        //}
        public static void RegistrarRepos(ContainerBuilder builder)
        {
            //Aquí decidimos que repo inyectamos y cçomo. Se realiza registrando el tipo con su interface
            builder.RegisterType<RepositoryProductos>().As<IRepositoryProductos>().InstancePerRequest();
        }
    }
}