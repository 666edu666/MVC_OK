using RepositorioHospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioHospital.Contexts
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public class HospitalContextMysql : DbContext, IHospitalContext
    {
        

        public HospitalContextMysql() : base("name=cadenahospitalmysql") { } //Coge el connectonString de Web.config
        
        public DbSet<Departamento> Departamentos { get; set; }

    }
}
