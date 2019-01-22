using SeguridadEmpleados.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeguirdadEmpleados.Context
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext() : base("name=cadenahospital") { }
        public DbSet<Empleado> Empleados { set; get; }
    }
}