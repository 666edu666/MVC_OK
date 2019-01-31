using ExcepcionesControl.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExcepcionesControl.Context
{
    public class HospitalContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HospitalContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public HospitalContext() : base("name=cadenahospital") { } //Coge el connectonString de Web.config


        public DbSet<Doctor> Doctores { get; set; }

        public DbSet<Excepcion> Excepciones { get; set; }

    }
}