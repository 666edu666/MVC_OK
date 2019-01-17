using RepositorioHospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioHospital.Contexts
{
    public class HospitalContextMysql : DbContext, IHospitalContext
    {

        public HospitalContextMysql() : base("name=cadenahospitalmysql") { } //Coge el connectonString de Web.config
        
        public DbSet<Departamento> Departamentos { get; set; }
        DbSet<Departamento> IHospitalContext.Departamentos { get; set; }
    }
}
