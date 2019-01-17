using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioHospital.Models;

namespace RepositorioHospital.Contexts
{
    public class HospitalContextOracle :  DbContext, IHospitalContext
    {

        public HospitalContextOracle() : base("name=cadenahospitaloracle") { } //Coge el connectonString de Web.config


        public DbSet<Departamento> Departamentos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");
            base.OnModelCreating(modelBuilder);
        }
    }
}
