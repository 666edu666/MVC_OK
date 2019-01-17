using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioHospital.Models;

namespace RepositorioHospital.Contexts
{
    public class HospitalContextSQL : DbContext, IHospitalContext
    {
                    

        public HospitalContextSQL() : base("name=cadenahospitalsql") { } //Coge el connectonString de Web.config


        public DbSet<Departamento> Departamentos { get; set; }
    }
}
