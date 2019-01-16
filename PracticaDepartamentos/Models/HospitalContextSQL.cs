using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticaDepartamentos.Models
{
    public class HospitalContextSQL : DbContext

    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HospitalContextSQL>(null);
            base.OnModelCreating(modelBuilder);
        }
        public HospitalContextSQL() : base("name=cadenahospital") { } //Coge el connectonString de Web.config


        public DbSet<Departamento> Departamentos { get; set; }

    }
} 