using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{

    //Estamos haciendo un mapping de la BBDD
    
    public class HospitalContext : DbContext
    {
        //Coge la cadena de conexion llamada cadenahospital  del webconfig 
        public HospitalContext() : base("name=cadenahospital") { }


        //Este constructor coge la cadena de conexión que nosotros le enviemos
        public HospitalContext(String cnnstring) : base(cnnstring) { }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

    }
}